﻿using Application.UseCase;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeviceService 
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly ManufacturerService _manufacturerService;
       
        public DeviceService(DeviceRepository deviceRepository, ManufacturerService manufacturerService)
        {
            _deviceRepository = deviceRepository;
            _manufacturerService = manufacturerService;
        }

        public async Task CreateDevice(Device device) => await _deviceRepository.AddAsync(device);

        public async Task UpdateDevice(Device device) => await _deviceRepository.UpdateAsync(device);
        public async Task DeleteDevice(Device device) => await _deviceRepository.RemoveAsync(device);

        public async Task<IQueryable<Device>> GetAll() => await _deviceRepository.FindAllAsync();

        public async Task<Device> GetDevice(Guid id)=> await _deviceRepository.GetAsync(id);

        public async Task<List<Device>> GetListDeviceByManufacturer(string manuName)
        {
            
           return  await _deviceRepository.GetListDeviceByManufacturer(manuName);
        }
    }
}

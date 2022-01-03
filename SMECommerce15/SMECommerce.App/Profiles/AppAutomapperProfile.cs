using AutoMapper;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.App.Configurations
{
    public class AppAutomapperProfile : Profile
    {
        public AppAutomapperProfile()
        {
            CreateMap<CategoryCreate, Category>();
            CreateMap<CategoryEditVm, Category>();
            CreateMap<Category, CategoryCreate>();
            CreateMap<Category, CategoryEditVm>();
        }
    }
}

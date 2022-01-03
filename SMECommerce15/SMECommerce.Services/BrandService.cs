using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services
{
    public class BrandService:Service<Brand>, IBrandService
    {
        IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository):base(brandRepository)
        {
            this._brandRepository = brandRepository;
        }

    }
}

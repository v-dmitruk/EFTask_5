using System;

namespace DAL
{
    public class UnitOfWork
    {
        private ProductDBContext _dBContext = new ProductDBContext();
        private EFProductRepository _ProductRepository;
        private EFProviderRepository _ProviderRepository;
        private EFCategoryRepository _CategoryRepository;

        public EFProductRepository ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                    _ProductRepository = new EFProductRepository(_dBContext);
                return _ProductRepository;
            }
        }

        public EFProviderRepository ProviderRepository
        {
            get
            {
                if (_ProviderRepository == null)
                    _ProviderRepository = new EFProviderRepository(_dBContext);
                return _ProviderRepository;
            }
        }

        public EFCategoryRepository CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                    _CategoryRepository = new EFCategoryRepository(_dBContext);
                return _CategoryRepository;
            }
        }


    }



}

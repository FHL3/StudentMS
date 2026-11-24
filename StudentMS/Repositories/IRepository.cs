namespace StudentMS.Repositories
{
    interface IRepository<T>
        where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T value);
        void Update(T value);
        void Delete(T value);
    }
}

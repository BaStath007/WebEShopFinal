using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebEShopFinal.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int? id);
        Task<ICollection<T>> GetAll();
        Task<T> Add(T? entity);
        bool Update(T? entity);
        bool Delete(int? id);
    }
}

using Domain.Entities;

public interface ICustomerRepository {
    void Save(Customer customer);
    IEnumerable<Customer> GetAll();
    Customer? GetById(Guid id);
    bool Update(Guid id, string name, string email);
    bool Delete(Guid id);
}
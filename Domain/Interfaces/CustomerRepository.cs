
using Domain.Entities;

public interface ICustomerRepository {
    void Save(Customer customer);
    IEnumerable<Customer> GetAll();
    Customer? GetById(Guid id);
}
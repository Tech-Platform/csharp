using Domain.Entities;

public class UpdateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public bool Execute(Guid id, string name, string email)
    {
        return _repository.Update(id, name, email);
    }
}

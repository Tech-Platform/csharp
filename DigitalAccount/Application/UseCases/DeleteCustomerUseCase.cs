public class DeleteCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public bool Execute(Guid id)
    {
        return _repository.Delete(id);
    }
}

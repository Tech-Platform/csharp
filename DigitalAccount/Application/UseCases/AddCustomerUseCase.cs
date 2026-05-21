using Domain.Entities;

public class AddCustomerUseCase {
    private readonly ICustomerRepository _repository;

    public AddCustomerUseCase(ICustomerRepository repository) {
        // Recebe a implementação do repositório de clientes por injeção de dependência.
        // Isso permite salvar o cliente em memória, banco de dados ou outro armazenamento.
        _repository = repository; 
    }

    public void Execute(string name, string email) {
        // Cria uma nova entidade Customer com os dados fornecidos pelo usuário.
        var customer = new Customer(name, email);

        // Persiste o cliente usando o repositório injetado.
        _repository.Save(customer);
    }
}
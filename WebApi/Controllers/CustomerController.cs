using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase {
    // Repositório para leitura de clientes.
    private readonly ICustomerRepository _repository;
    // Use case para criar um novo cliente.
    private readonly AddCustomerUseCase _useCase;

    public CustomerController(ICustomerRepository repository, AddCustomerUseCase useCase) {
        // O repositório é injetado para permitir obtenção dos dados de clientes.
        _repository = repository;
        // O caso de uso é injetado para encapsular a lógica de criação de cliente.
        _useCase = useCase;
    }

    [HttpPost]
    public IActionResult Create(string name, string email) {
        // Executa a lógica de criação de cliente usando os dados fornecidos.
        _useCase.Execute(name, email);

        // Retorna uma resposta 200 OK com mensagem de confirmação.
        return Ok($"Cliente {name} com email {email} criado com sucesso no MVP!");
    }

    [HttpGet]
    public IActionResult GetAll() {
        // Solicita ao repositório todos os clientes armazenados.
        var customers = _repository.GetAll();

        // Retorna a lista de clientes com status 200 OK.
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) {
        // Busca um cliente específico pelo ID.
        var customer = _repository.GetById(id);

        // Se não encontrar, retorna 404 Not Found.
        if (customer == null) return NotFound();

        // Caso encontre, retorna o cliente com 200 OK.
        return Ok(customer);
    }
}
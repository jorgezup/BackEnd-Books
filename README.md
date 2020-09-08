# API Books

## Desafio Tasklist
- [x] Criar uma API simples para buscar produtos no arquivo JSON disponibilizado.
- [x] Buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- [x] É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- [x] Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

## Passos para Execução
- Clonar o projeto
- Executar o projeto (dotnet run)

## URLs do Projeto
- Listar Todos os Livros
[GetAllBooks][[https://localhost:5001/api/books]
- Listar Apenas um Livro
[GetById][[https://localhost:5001/api/books/{id}]
- Calcular o frete de um Livro
[GetFrete][[https://localhost:5001/api/books/{id}/frete]
- Ordernar pelo preço (order=all, order=desc, order=asc)
[Price][https://localhost:5001/api/books/price?order=desc]
- Buscar por nome (do Livro) ou Autor (?name=)(?author=)
[Search][https://localhost:5001/api/books/search?name=sea]
- Buscar por nome (do Livro) ou Autor (?name=)(?author=) e Ordenar por Preço
[Search][https://localhost:5001/api/books/search?name=the&order=desc]

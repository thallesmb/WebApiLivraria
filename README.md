# 📚 API de Gerenciamento de Livros

Este projeto é uma API RESTful desenvolvida com **ASP.NET Core** e **Entity Framework Core**, com o objetivo de gerenciar um acervo de livros e seus respectivos autores.

## 🚀 Funcionalidades

- ✅ Cadastro, edição e exclusão de livros
- ✅ Cadastro, edição e exclusão de autores
- ✅ Associação de livros a autores
- ✅ Consulta de livros com os dados do autor incluídos automaticamente (`Include`)
- ✅ Documentação interativa com Swagger
- ✅ Repository Pattern

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)

## ▶️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git

2. Acesse a pasta do projeto:
   ```bash
   cd seu-repositorio

3. Configure a connection string no appsettings.json
   ```bash
   "DefaultConnection": "server= localhost\\SQLEXPRESS; database= WebApiLivraria; trusted_connection=true; trustservercertificate=true;"

4. Aplique as migrations:
   ```bash
   dotnet ef database update

5. Execute o projeto:
   ```bash
   dotnet run

6. Acesse a documentação Swagger:
   ```bash
   https://localhost:{porta}/swagger

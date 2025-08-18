🦸‍♂️ Hero API (.NET)










API REST para gerenciar heróis — feita em .NET 9 com foco em simplicidade de código, organização por camadas (Models/DTOs/Interfaces) e persistência local usando SQLite (arquivo heroes.db). 
GitHub

Dica: este README foi escrito para ser amigável a quem chega agora no repo — com passo a passo, comandos prontos e exemplos de requisições.

✨ Funcionalidades

CRUD de heróis (modelo base com Models e DTOs)

Persistência com Entity Framework Core + Migrations

Banco local SQLite (heroes.db) para desenvolvimento rápido

Estrutura simples e direta para evoluir (Services/Interfaces/Validation/Swagger etc.)

🗂 Estrutura do projeto
hero-api-dotnet/
├─ Context/                 # DbContext e configuração do EF Core
├─ Dto/                     # Data Transfer Objects (entrada/saída)
├─ Enum/                    # Enums do domínio
├─ Interfaces/              # Contratos (ex.: repositórios/serviços)
├─ Migrations/              # Histórico de migrações do EF Core
├─ Models/                  # Entidades do domínio (ex.: Hero)
├─ Program.cs               # Bootstrap da Web API
├─ appsettings.json         # Configurações (DB, etc.)
├─ heroes.db                # Banco SQLite (dev)
└─ hero-api-dotnet.csproj


A árvore acima reflete as pastas públicas do repo no GitHub. Ajuste se você renomear/organizar diretórios. 
GitHub

🚀 Começando
Pré-requisitos

📦 .NET SDK 9.0 (ou versão compatível)

🗄 SQLite (opcional — a API cria/usa heroes.db local)

(Opcional) EF Core Tools para rodar migrações via CLI:
dotnet tool install --global dotnet-ef

Clonar e restaurar
git clone https://github.com/devdiego97/hero-api-dotnet.git
cd hero-api-dotnet
dotnet restore

Configurar conexão (se necessário)

No appsettings.json, confirme a connection string do SQLite. Um exemplo comum:

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=heroes.db"
  }
}

Banco de dados (Migrations)

Se você quiser recriar o banco limpo a partir das migrações:

dotnet ef database update


Caso prefira “code-first sem migração manual”, você pode habilitar Database.EnsureCreated() no DbContext (apenas para dev). Em produção, use migrations.

Rodar a API
dotnet run


Por padrão, a API sobe em algo como:

http://localhost:5070

https://localhost:7070

A porta exata pode variar; o terminal informa a URL ao iniciar.

📚 Endpoints (exemplos)

Observação importante: como as rotas podem variar de acordo com seus Controllers/Minimal APIs, abaixo segue um padrão sugerido comum em projetos REST. Ajuste os paths conforme o que você definiu no código (ex.: api/heroes).

Heroes

GET /api/heroes — lista todos os heróis

GET /api/heroes/{id} — obtém 1 herói

POST /api/heroes — cria herói (envie um DTO)

PUT /api/heroes/{id} — atualiza herói

DELETE /api/heroes/{id} — exclui herói

Exemplo de POST /api/heroes
{
  "name": "Peter Parker",
  "alias": "Homem-Aranha",
  "powerLevel": 87
}

cURL de exemplo
curl -X POST http://localhost:5070/api/heroes \
  -H "Content-Type: application/json" \
  -d '{"name":"Peter Parker","alias":"Homem-Aranha","powerLevel":87}'

🧪 Testando rapidamente

Use HTTP Client do VS Code (.http), Thunder Client, Insomnia ou Postman.

(Opcional) Ative Swagger/OpenAPI para explorar a API no navegador. Se ainda não adicionou:

dotnet add package Swashbuckle.AspNetCore


E no Program.cs, adicione builder.Services.AddEndpointsApiExplorer(); e builder.Services.AddSwaggerGen();, além de app.UseSwagger(); app.UseSwaggerUI(); no pipeline.

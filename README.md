# 🦣 Mammoth Response Network
### Emergency Response Platform → Public Safety ERP

Mammoth is a modern, event‑driven platform designed to coordinate volunteers, incidents, teams, logistics, and intelligence for emergency response agencies.
It evolves into a full ERP for municipalities, fire brigades, civil protection, and NGOs.

---

## 🚀 Vision

Mammoth begins as an emergency‑response coordination system and expands into a multi‑tenant, AI‑powered ERP for public safety organizations.

Core principles:
- Event‑sourced domain model
- CQRS with EventStoreDB + PostgreSQL
- Modular microservices
- Multi‑tenant SaaS architecture
- AI‑driven intelligence
- Cloud‑native deployment

---

## 📦 Repository Structure

mammoth/
│
├── src/
│   ├── services/          # Microservices (Volunteer, Incident, CheckIn, etc.)
│   ├── shared/            # Domain, Contracts, Infrastructure
│   ├── gateway/           # YARP API Gateway
│   ├── ui/                # Web (React) + Mobile (MAUI)
│   └── ai/                # AI modules (Classification, Routing, Vision, Forecast)
│
├── infrastructure/        # Docker, K8s, Terraform, Ansible
├── docs/                  # Architecture, C4, Roadmap, ERP strategy
├── build/                 # CI/CD pipelines
├── tools/                 # Scripts, migrations, benchmarks
└── tests/                 # Integration + E2E tests

---

## 🧱 Technology Stack

### Backend
- .NET 8
- EventStoreDB (event‑sourcing)
- PostgreSQL + PostGIS (read models + geo)
- Redis (cache + ephemeral state)
- Aspire (local orchestration)
- YARP Gateway
- Keycloak (identity + tenancy)

### Frontend
- React (Web)
- MAUI (Mobile)

### AI
- Classification
- Routing
- Vision
- Forecasting

---

## 🛠️ Getting Started (Local Dev)

### 1. Install prerequisites
- .NET 8 SDK
- Node.js LTS
- Docker Desktop
- PowerShell 7
- PostgreSQL
- EventStoreDB
- Redis

### 2. Clone the repository

git clone https://github.com/<your-org>/mammoth.git
cd mammoth

### 3. Restore dependencies

dotnet restore
npm install --prefix src/ui/web


### 4. Run the platform (Aspire)

dotnet run --project src/Mammoth.AppHost

---

## 📘 Documentation

All architecture and ERP strategy documents are inside:

/docs


Including:
- ERP Roadmap
- ERP Architecture
- ERP Domain Model
- ERP SaaS Strategy

---

## 🧭 Roadmap (High‑Level)

1. MVP: Volunteers, Incidents, Check‑In
2. Operational: Teams, Logistics, Geo, Reporting
3. Intelligence: AI Classification, Routing, Vision, Forecast
4. Scale: Multi‑tenant SaaS, Kubernetes, HA
5. ERP: HR, Logistics, Finance, Compliance

---

## 🤝 Contributing

Mammoth is designed as a public, open, modular platform.
Contributions are welcome — architecture discussions happen in `/docs`.

---

## 📄 License

MIT (or your preferred license)

---

## 🦣 Mammoth — Built for those who protect others.



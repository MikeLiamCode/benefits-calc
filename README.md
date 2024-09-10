# Employee Paycheck Calculation System

## Overview

This is a backend solution to calculate employee paychecks based on a set of defined business rules. The system allows users to view employees and their dependents and compute paycheck amounts after considering benefit deductions.

## Features

- View employees and their dependents.
- An employee may have:
  - One spouse/domestic partner.
  - Unlimited number of children.
- Calculate and view paychecks for employees, considering:
  - 26 paychecks per year.
  - Benefit costs for employees and dependents.
  - Additional benefit costs for high-income employees and older dependents.

## Paycheck Calculation Rules

- Employees receive 26 paychecks per year, with deductions spread as evenly as possible across each paycheck.
- Benefit costs:
  - Employees have a base cost of **$1,000 per month**.
  - Each dependent adds an additional **$600 per month**.
- Additional rules:
  - Employees earning more than **$80,000 per year** incur an extra **2% of their yearly salary** as additional benefit costs.
  - Dependents over the age of **50** incur an additional **$200 per month**.

## Getting Started

### Prerequisites

To run the application, you need the following tools installed on your machine:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or an equivalent database engine.
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) for running database migrations.

### Setup Instructions

1. **Clone the repository**:
2. **Run DB Migrations using `update-database`**
3. **Run the application**
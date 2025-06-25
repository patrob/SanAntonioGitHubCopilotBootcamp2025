# UrlListApp

UrlListApp is a simple ASP.NET Core web application designed to manage and display a list of URLs. It demonstrates basic web application structure using Razor Pages, configuration management, and static content delivery.

## Features
- Displays a list of URLs on the main page
- Uses Razor Pages for UI rendering
- Configuration via `appsettings.json` and environment-specific settings
- Includes basic error handling and privacy page
- Utilizes Bootstrap for responsive design

## Project Structure
- `Pages/` - Contains Razor Pages for the UI (Index, Privacy, Error, Shared Layout)
- `wwwroot/` - Static files (CSS, JS, images, libraries)
- `appsettings.json` - Application configuration
- `Program.cs` - Application startup and configuration

## How the App Works

```mermaid
flowchart TD
    A[User visits site] --> B[Request handled by ASP.NET Core]
    B --> C[Program.cs configures app]
    C --> D[Routes to Razor Page (Index.cshtml)]
    D --> E[Index.cshtml.cs loads URL list]
    E --> F[Page rendered with URLs]
    F --> G[User interacts with page]
    G -->|Optional| D
```

## Getting Started
1. **Build the project:**
   ```bash
   dotnet build UrlListApp/UrlListApp.csproj
   ```
2. **Run the app:**
   ```bash
   dotnet run --project UrlListApp/UrlListApp.csproj
   ```
3. **Open in browser:**
   Navigate to the URL shown in the terminal (usually `https://localhost:5001` or `http://localhost:5000`).

## Customization
- Add or modify URLs in the data source (see `Pages/Index.cshtml.cs` for logic)
- Update styles in `wwwroot/css/site.css`

## Requirements
- .NET 9.0 SDK or later

## License
This project is for educational purposes as part of the San Antonio GitHub Copilot Bootcamp 2025.

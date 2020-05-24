FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY [".", "dotnet-refresh/"]
RUN dotnet restore "dotnet-refresh/dotnet-refresh.csproj"
COPY . .
WORKDIR "/src/dotnet-refresh"
RUN dotnet build "dotnet-refresh.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-refresh.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-refresh.dll"]

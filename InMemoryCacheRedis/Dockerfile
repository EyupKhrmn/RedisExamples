FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InMemoryCacheRedis/InMemoryCacheRedis.csproj", "InMemoryCacheRedis/"]
RUN dotnet restore "InMemoryCacheRedis/InMemoryCacheRedis.csproj"
COPY . .
WORKDIR "/src/InMemoryCacheRedis"
RUN dotnet build "InMemoryCacheRedis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InMemoryCacheRedis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InMemoryCacheRedis.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DistributedCachingRedis/DistributedCachingRedis.csproj", "DistributedCachingRedis/"]
RUN dotnet restore "DistributedCachingRedis/DistributedCachingRedis.csproj"
COPY . .
WORKDIR "/src/DistributedCachingRedis"
RUN dotnet build "DistributedCachingRedis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DistributedCachingRedis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistributedCachingRedis.dll"]

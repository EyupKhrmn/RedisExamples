FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisPubSub.Subscriber.Example/RedisPubSub.Subscriber.Example.csproj", "RedisPubSub.Subscriber.Example/"]
RUN dotnet restore "RedisPubSub.Subscriber.Example/RedisPubSub.Subscriber.Example.csproj"
COPY . .
WORKDIR "/src/RedisPubSub.Subscriber.Example"
RUN dotnet build "RedisPubSub.Subscriber.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisPubSub.Subscriber.Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisPubSub.Subscriber.Example.dll"]

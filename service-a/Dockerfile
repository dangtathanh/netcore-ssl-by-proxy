FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["src/app/app.csproj", "src/app/"]
RUN dotnet restore "src/app/app.csproj"
COPY . .
WORKDIR "/src/src/app"
RUN dotnet build "app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "app.dll"]

FROM  mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM  mcr.microsoft.com/dotnet/core/sdk:3.1 as build

COPY src/StatlerWaldorfCorp.TeamService/StatlerWaldorfCorp.TeamService.csproj \
    src/StatlerWaldorfCorp.TeamService/StatlerWaldorfCorp.TeamService.csproj

COPY test/StatlerWaldorfCorp.TeamService.Tests/StatlerWaldorfCorp.TeamService.Tests.csproj \
    test/StatlerWaldorfCorp.TeamService.Tests/StatlerWaldorfCorp.TeamService.Tests.csproj

RUN dotnet restore "src/StatlerWaldorfCorp.TeamService/StatlerWaldorfCorp.TeamService.csproj"
RUN dotnet restore "test/StatlerWaldorfCorp.TeamService.Tests/StatlerWaldorfCorp.TeamService.Tests.csproj"

COPY src/StatlerWaldorfCorp.TeamService/ \
    src/StatlerWaldorfCorp.TeamService/
COPY test/StatlerWaldorfCorp.TeamService.Tests/ \
    test/StatlerWaldorfCorp.TeamService.Tests/

RUN dotnet build    "src/StatlerWaldorfCorp.TeamService/StatlerWaldorfCorp.TeamService.csproj"
RUN dotnet build    "test/StatlerWaldorfCorp.TeamService.Tests/StatlerWaldorfCorp.TeamService.Tests.csproj"

RUN dotnet test     "test/StatlerWaldorfCorp.TeamService.Tests/StatlerWaldorfCorp.TeamService.Tests.csproj"

FROM build AS publish
RUN dotnet build "src/StatlerWaldorfCorp.TeamService/StatlerWaldorfCorp.TeamService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StatlerWaldorfCorp.TeamService.dll"]

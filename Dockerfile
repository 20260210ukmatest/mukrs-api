ARG MUKRS_CONNECTION_STRING

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["MahjongUKRankingSystem.API/MahjongUKRankingSystem.API.csproj", "MahjongUKRankingSystem.API/"]
COPY ["MahjongUKRankingSystem.DbModels/MahjongUKRankingSystem.DbModels.csproj", "MahjongUKRankingSystem.DbModels/"]
COPY ["MahjongUKRankingSystem.Logic/MahjongUKRankingSystem.Logic.csproj", "MahjongUKRankingSystem.Logic/"]
RUN dotnet restore "MahjongUKRankingSystem.API/MahjongUKRankingSystem.API.csproj"
COPY . .
WORKDIR "/src/MahjongUKRankingSystem.API"
RUN dotnet build "MahjongUKRankingSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MahjongUKRankingSystem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionStrings__MukrsConnection=${MUKRS_CONNECTION_STRING}
ENTRYPOINT ["dotnet", "MahjongUKRankingSystem.API.dll"]

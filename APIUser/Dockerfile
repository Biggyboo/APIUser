FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["APIUser/APIUser.csproj", "APIUser/"]
RUN dotnet restore "APIUser/APIUser.csproj"
COPY . .
WORKDIR "/src/APIUser"
RUN dotnet build "APIUser.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "APIUser.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "APIUser.dll"]
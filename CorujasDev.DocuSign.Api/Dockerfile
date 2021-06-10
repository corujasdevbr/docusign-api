#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CorujasDev.DocuSign.Api/CorujasDev.DocuSign.Api.csproj", "CorujasDev.DocuSign.Api/"]
RUN dotnet restore "CorujasDev.DocuSign.Api/CorujasDev.DocuSign.Api.csproj"
COPY . .
WORKDIR "/src/CorujasDev.DocuSign.Api"
RUN dotnet build "CorujasDev.DocuSign.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CorujasDev.DocuSign.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CorujasDev.DocuSign.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EventsProducer/EventsProducer.csproj", "EventsProducer/"]
RUN dotnet restore "EventsProducer/EventsProducer.csproj"
COPY . .
WORKDIR "/src/EventsProducer"
RUN dotnet build "EventsProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventsProducer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventsProducer.dll"]

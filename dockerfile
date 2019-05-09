FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /.
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

# Change name of dll for your application 
ENTRYPOINT ["dotnet", "Personal-Website-ASPNET.dll"]
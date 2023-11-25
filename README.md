# Descripcion del repositorio
Pruebas 

# Consideraciones de Desarrollo
Developers: para desarrollos y pruebas en nuevos requerimientos o incidencencias, considerar le siguiente:
1. Tu aplicacion debe considerar lectura de variables de entorno
2. Crear un archivo "appsettings.json" en la raíz del proyecto Facade para desarrollos/pruebas locales, con la siguiente estructura:


```json
{
  "Sql": {
    "DataSource": "xxxx",
    "User": "xxxx",
    "Password": "xxxx"
  },
  "ConsultaSunat": {
    "URL": "https://apiperu.dev/api/dni/",
    "Token": "xxxxxx"
  },
  "Setting": {
    "TiempoEsperaBdSegundos": "600"
  }
}
```
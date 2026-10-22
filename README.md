<!--

Este repositorio tiene la configuración base para todos los demás repositorios de ejercicios y proyectos de Programación II.

Los nuevos ejercicios tendrían que ser creados como forks de este repositorio.
Para los existentes que no tienen este como base, es necesario:

1. Configurar los otros repositorios para que tomen este como base
2. Sincronizar las diferencias la primera vez y cada vez que haya cambios en
  este repositorio.

Hay que configurar los demás repositorios para poder sincronizar cambios con
este. Para eso, en el otro repositorio ejecutar:

git remote add upstream https://github.com/ucudal/PII_MasterTemplate.git
git fetch upstream

Confirmar con:

git remote -v

Este repositorio será upstream y el otro repositorio será origin.

En general las historias de ambos repositorios no están relacionadas. Para
unirlas es necesario:

git checkout -b sync
git merge upstream/main --allow-unrelated-histories

Resolver conflictos. Luego:

git add .
git commit -m "Sync'd with master template"
git checkout main
git merge sync
git branch -u origin/main main
git push origin main

A partir de ahí en adelante es posible usar GitHub Desktop y seleccionar la
rama main para comparar con la rama upstream/main y sincronizar los cambios.

-->

<!-- markdownlint-disable-next-line MD033 MD041 -->
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Programación II

# Plantilla de ejercicios

## Descripción

Esta plantilla proporciona una estructura base para los ejercicios de
Programación II. Incluye la configuración necesaria para desarrollar
aplicaciones en C# con buenas prácticas de programación, pruebas automatizadas y
documentación.

¿Qué hay configurado en esta plantilla?

1. Un proyecto de biblioteca (creado con [`dotnet new classlib --name
   Library`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22))
   en la carpeta `src\Library`.

2. Un proyecto de aplicación de consola, creado con [`dotnet new console --name
   Program`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22),
   en la carpeta `src\Program`.

3. Un proyecto de prueba en [NUnit](https://nunit.org/), creado con [`dotnet new
   nunit --name
   LibraryTests`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore22),
   en la carpeta `test\LibraryTests`.

4. Un proyecto de [Doxygen](https://www.doxygen.nl/index.html) para generación
   de sitio web de documentación en la carpeta `docs`.

5. Análisis estático con [Roslyn
   analyzers](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview)
   en los proyectos de biblioteca y de aplicación.

6. Análisis de estilo con
   [StyleCop](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/README.md)
   en los proyectos de biblioteca y de aplicación.

7. Una solución `Project.sln` que referencia todos los proyectos de C# y
   facilita la compilación con [`dotnet
   build`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build).

8. Tareas preconfiguradas para ejecutar las pruebas con cobertura y generar
   documentación desde VSCode en la carpeta `.vscode`.

9. Análisis de cobertura de los casos de prueba mediante los indicadores que
   aparecen en los márgenes con el complemento de Visual Studio Code [Coverage
   Gutters](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters).

10. Ejecución automática de compilación y prueba mediante [GitHub
    Actions](https://docs.github.com/en/actions) configuradas en el repositorio
    al hacer [push](https://github.com/git-guides/git-push) o [pull
    request](https://docs.github.com/en/github/collaborating-with-pull-requests).

## Convenciones de código

[Convenciones de código en
C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

[Convenciones de nombres en
C#](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)

[C# Compiler Errors
(CS*)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/)

[Roslyn Analyzer Warnings
(CA*)](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/categories)

[StyleCop Analyzer Warnings
(SA*)](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/DOCUMENTATION.md)

Las violaciones a estas convenciones son reportadas como *warnings* al compilar.
Aunque recomendamos corregir las violaciones, es posible omitir esta
configuración de la siguiente forma:

Comentar las siguientes líneas en los archivos de proyecto (`*.csproj`)

```xml
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisMode>All</AnalysisMode>
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
```

Comentar la línea `<PackageReference Include="StyleCop.Analyzers"
Version="1.1.118"/>` en los archivos de proyecto (`*.csproj`)

## Estructura

Los archivos README.md de los ejercicios **deben** incluir:

* El o los temas involucrados en el ejercicio; idealmente con vínculos al
  teórico correspondiente.

* La consigna, dividida en partes, de lo que se espera que los estudiantes
  hagan.

* Una rúbrica que evaluación que sirva tanto para guiar a los estudiantes en la
  resolución del ejercicio como a los profesores para la corrección.

## Uso de ![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-000?logo=githubcopilot&logoColor=fff)

Es posible usar GitHub Copilot en este repositorio. Consulta [cómo usar Copilot
para aprender](./COPILOT.md).

La plantilla está configurada para usar GitHub Copilot, tanto por los profesores
como por los estudiantes.

La configuración para controlar el comportamiento de lo que puede o no hacer
Copilot, y de los aspectos genéricos relacionados con el curso, está en el
archivo [`copilot-instructions.md`](/.github/copilot-instructions.md). Para
ejercicios específicos, puede ser necesario ajustar estas instrucciones.

La configuración para controlar cómo Copilot hace la revisión de los archivos
`.csproj` está en el archivo
[`csproj.instructions.md`](/.github/instructions/csproj.instructions.md).

La configuración para controlar cómo Copilot hace la revisión de los casos de
prueba está en el archivo
[`tests.instructions.md`](/.github/instructions/csproj.instructions.md).

El archivo
[`README.instructions.md`](.github/instructions/README.instructions.md) tiene
instrucciones para que Copilot asegure la consistencia y corrección de las
consignas de ejercicios en esos archivos.

> [!IMPORTANT]
> Hay que copiar el contenido del archivo [`COPILOT.md`](./COPILOT.md) al final
> del archivo `README.md`; ese archivo tiene las instrucciones para que los
> estudiantes puedan usar Copilot.

## Corrección automática

La plantilla permite corrección automática con GitHub Copilot y el complemento
de Visual Studio Code [Grading
Agent](https://github.com/ucudal/GradingAgent_VSCode_Extension).

> [!IMPORTANT]
> El agente para corrección automática no está incluido en esta plantilla, sino
> qu está disponible como parte del complemento **Grading Agent**
> [aquí](https://github.com/ucudal/GradingAgent_VSCode_Extension/blob/main/assets/grade.agent.md).

Para que el complemento **Grading Agent** funcione, el archivo README.md del
ejercicio debe tener una rúbrica de evaluación.

> [!IMPORTANT]
> El archivo README.md **debe** incluir una rúbrica de evaluación
> independientemente de que usemos corrección automática o no.
<!--  -->
> [!TIP]
> Las rúbricas de evaluación pueden ser generadas con GitHub Copilot. Hay que
> pasar a Copilot los objetivos de aprendizaje relacionados con el ejercicio y
> la consigna, más un ejemplo de rúbrica como el que aparece [a
> continuación](#ejemplo-de-rúbrica).

## Ejemplo de rúbrica

A continuación, aparece un ejemplo de rúbrica de evaluación y, debajo, de
cálculo de puntos en base a esa rúbrica.

| Criterio | Ponderación | Experto | En desarrollo | Incipiente | Insuficiente |
| --- | --- | --- | --- | --- | --- |
| **Funcionalidad** | 40% | Cumple con la consigna correctamente y de forma consistente. | Cumple casi toda la consigna; fallos menores. | Funciona parcialmente o con errores frecuentes. | No funciona o no compila. |
| **Aplicación de Expert** | 20% | Clases con responsabilidades claras, una sola razón de cambio; se evidencia Expert | Algunas responsabilidades bien distribuidas, otras no | Distribución confusa o acoplada | No hay diseño por responsabilidades |
| **Aplicación de SRP** | 20% | Aplica SRP/Expert explícitamente y los justifica. | Aplica algunos criterios pero sin consistencia o explicación parcial | Aplicación débil o poco justificada | No aplica ni justifica |
| **Diseño orientado a objetos** | 10% | Clases y colaboraciones coherentes con el dominio | Diseño razonable con algunas inconsistencias | Diseño pobre; falta claridad en relaciones | Diseño inexistente o incorrecto |
| **Comentarios de justificación** | 5% | Todas las clases justificadas con claridad | La mayoría justificadas de forma aceptable | Pocas justificaciones o poco claras | Sin justificaciones o incorrectas |
| **Calidad y convenciones C#** | 5% | Nombres, formato y estilo consistentes | Algunos desvíos menores | Múltiples problemas de estilo | Estilo y convenciones ignoradas |

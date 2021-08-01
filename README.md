# Forest Control
API creada para una prueba.

Se solicitó la creación de un API Rest que permita calcular y devolver la ubicación final de los drones que estarán participando en el sobrevuelo de un área del parque forestal de Montserrat, con la finalidad de detectar fuentes de calor.

## Features
Consta de un único recurso, POST, al que deben informarse datos sobre el área que los drones estarán cubriendo, el punto de partida de cada dron dentro del perímetro, y las acciones que estará ejecutando cada dron (giro a la izquierda o derecha, y moverse al frente).

De acuerdo al ejercicio planteado, se solicita como entrada un JSON con la siguiente información:

    {
		"area": <string>,
		"drones": [
			{
				"initialPosition": <string>,
				"actions": <string>
			}
		]
    }
En la propiedad `area` deberá informarse el perímetro que estará sobrevolando cada dron: Alto y ancho, separado por un espacio (`5 5`).
En la propiedad `initialPosition` deberá informarse el punto de inicio del dron dentro del perímetro: Valores X Y y punto cardinal (`3 3 N`).
Por último, en la propiedad `actions` se indicarán los movimientos que hará cada dron. Para ello tiene a disposición las siguientes acciones:
- Giro a la izquierda: `L`
- Giro a la derecha: `R`
- Moverse hacia adelante: `M`

La salida corresponde también a un JSON con una sola propiedad para indicar la posición final de cada dron luego de completar las acciones recibidas:

    [
		{
			"finalPosition": <string>
		}
    ]
Donde `finalPosition` retornará la posición del dron: Valores X Y y punto cardinal (`1 5 N`).

## Prerequisites
- .Net Core 3.1.
- AutoMapper.Extensions.Microsoft.DependencyInjection.
- Swashbuckle.AspNetCore.

## Examples

Ejemplo de una petición POST:

    {
		"area": "5 5",
		"drones": [
			{
				"initialPosition": "3 3 E",
				"actions": "L"
			},
			{
				"initialPosition": "3 3 E",
				"actions": "MMRMMRMRRM"
			},
			{
				"initialPosition": "1 2 N",
				"actions": "LMLMLMLMMLMLMLMLMM"
			}
		]
    }

Respuesta de la API:

    [
		{
			"finalPosition": "3 3 N"
		},
		{
			"finalPosition": "5 1 E"
		},
		{
			"finalPosition": "1 4 N"
		}
    ]
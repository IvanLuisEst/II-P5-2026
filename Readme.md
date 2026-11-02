# Práctica 5

## Ejercicio 1

Para comenzar con esta práctica se nos pedía crear un proyecto Cardboard el cual sería un Asset propio de Google el cual nos generaría un escena con unos scripts ya programados y GameObjects ya preparados para que nosotros configuremos el proyecto siguiendo los pasos que el propio Google nos ofrece para poder generar un proyecto Cardboard que sea desplegable en Android.

## Ejercicio 2

En este ejercicio se nos pedía conseguir un terreno a través de unos assets y lo mismo con unos objetos los cuales el usuario utilizaría como recolectables. Para ello utilicé estos dos assets:

[Asset para el terreno](https://assetstore.unity.com/packages/3d/vegetation/environment-pack-free-forest-sample-168396)
[Asset para los recolectables](https://assetstore.unity.com/packages/3d/props/guns/low-poly-cartoon-axe-pack-201669)

Una vez obtenidos los assets, mantuvimos los principales scripts ofrecidos por Google en la primera escena del primer ejercicio, y a partir de ese punto creamos un nuevo script asociado al player el cual consistía en que el jugador podría desplazarse por el terreno. Para ello primero le colocamos físicas al player para que pudiese moverse por el terreno sin que el mismo transpasase el terreno y ya dentro del script haríamos que el personaje se moviese a un lugar si mantenía la mirada fija durante dos segundos en una zona del terreno siempre y cuando esta zona estuviese dentro de unos límites de distancia.

Por otro lado, para la recolección de objetos se crearía otro script el cual se encargaría de hacer que el personaje recoge el recolectable si se queda mirando al mismo durante un periodo de tiempo, al retirar la mirada después de ese periodo de tiempo el recolectable desaparecería.

[Ejercicio2](./GIFS/Ejercicio2.gif)

## Ejercicio 3

Aprovechandonos del anterior ejercicio colocamos un nuevo GameObject dentro de la escena el cual funcionaría como recolector el cual si el mismo era mirado desde una distancia reconocible crearía un evento el cual generaría que todos los demás recolectables se moviesen hacia el personaje haciendo que cuando estos se colisionaran con el mismo como el personaje tenía un Rigidbody y los recolectables tenian colisiones harían que se generase un función `OnCollisionEnter()` la cual generaria que el personaje relcolectase esos objectos.

Esos serían los contenidos relacionados a los dos scripts los cuales se usarían para dar forma en este ejercicio uno de ellos asociado a ese nuevo objeto del asset el cual enviaría el mensaje del evento de movimiento, y el segundo script asociado a todos los demás recolectables que harían que estos se moviesen hacia el jugador haciendo que al colisionarse esos se recolectaran.

[Ejercicio3](./GIFS/Ejercicio3.gif)
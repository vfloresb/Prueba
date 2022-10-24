Creamos el repositorio sr para la prueba
#Hemos creado la solución, con la aplicación Web MVC (simple) que mostrará los resultados y hará las acciones descritas en la prueba:

Al arrancar el proyecto, mostrará una página inicial, donde tendremos las opciones:

  - Visualizar Marcador en juego
    *Si pulsamos, nos muestra los resultados de los partidos en juego (Jugandose o en descanso).
  - Resumen de Partidos
    *Si pulsamos, nos muestra los resultados finalizados, ordenando por el número de goles en cada uno de ellos y la fecha de inserción en el sistema.
  -Nuevo Partido
   *Pulsando el botón nos lleva al formulario para crear un nuevo partido, con campos a introducir de local y visitante, el marcador local/visitante no se podrá modificar y saldrá 0 por defecto. Una vez pulsemso en crearlo nos redirigirá a la pantalla de actualizar Partido con el partido creado seleccionado.
  -Actualizar Partido
    *Seleccionamos el partido de los que se encuentran no finalizados, y pulsamos sobre el botón actualizar que nos llevará al formulario de edición del partido y desde el cual podremos modificar los datos.
    
Indicar que en todas las pantallas, pulsando sobre en enlace a la pantalla de inicio, no llevará al Home y podremos acceder a cualquier opción.

#Test
Hemos creado un proyecto de test donde hemos realizado las pruebas básicas de crear un nuevo partido, editar un nuevo partido y listar los partidos finalizados según lo indicado.

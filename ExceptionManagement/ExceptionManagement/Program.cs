using System;

namespace ExceptionManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConnectionException.Connection(); // Gestione dell'eccezione per la connessione al DB

            try
            {
                throw new UserNotFoundException("User not found!"); //uso il secondo costruttore
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Non ha preso l'eccezione personalizzata per lo user non trovato");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExceptionManagement
{
	public class ConnectionException
	{
		const string connectionString = @"Persist Security Info= false; Integrated Security = true; Initial Catalog = Galileo; Server = ./SQLEXPRESS";
		//creo una stringa riferita al DB Galielo che non esiste
		public static void Connection()
		{
			try
			{
				OpenConnection();
			}
			// separo la gestione degli errori in riferimento alla guida microsoft: 
			//https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception?view=sqlclient-dotnet-core-2.1
			catch (SqlException e) when (e.Class <= 10)
			{
				Console.WriteLine("Classe dell'errore è sotto il livello 10: problemi causati da errori nelle informazioni che un utente ha inserito.\n" + e.Message);
			}
			catch (SqlException e) when (e.Class > 10 && e.Class <= 16)
			{
				Console.WriteLine("Classe dell'errore è compreso tra 10 e 16: errori generati dall'utente e possono essere corretti dall'utente.\n" + e.Message);
			}
			catch (SqlException e) when (e.Class >= 17 && e.Class <= 19)
			{
				Console.WriteLine("Classe dell'errore compresa tra 17 e 19: errori software o hardware; è comunque possibile continuare a lavorare, anche se potrebbe non essere possibile eseguire un'istruzione particolare\n" + e.Message);
			}
			catch (SqlException e) when (e.Class >= 19)
			// il programma entra qui in quanto la classe di appartenza dell'errore relativo al fatto di non trovar il DB è in questo intervallo 
			{
				Console.WriteLine("Classe dell'errore è compreso tra 20 e 25: errori software o hardware; Connessione non aperta \n" + e.Message);
			}

		}

		public static void OpenConnection()
			{
				SqlConnection connection = new SqlConnection(connectionString);
				connection.Open();
			}

	}
}

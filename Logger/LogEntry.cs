using System;

namespace Logger
{
	public static class LogEntry
	{
		private static readonly LogBase Logger = new FileLogger ( );

		public static void Log ( string fileName , string message )
		{
			Logger.Log ( fileName , message );
		}

		public static void LogExceptionError ( Exception ex )
		{
			Logger.LogExceptionError ( ex.Message );
		}

		public static void LogExceptionError ( string message )
		{
			Logger.LogExceptionError ( message );
		}

		public static void LogError ( string message )
		{
			Logger.LogError ( message );
		}
	}
}
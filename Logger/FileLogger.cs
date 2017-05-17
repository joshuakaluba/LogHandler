using System;
using System.IO;

namespace Logger
{
	public class FileLogger : LogBase
	{
		private static readonly object LockObj = new object ( );
		private static string masterLog = @"C:\Log\";
		private static string fileType = @".txt";
		private static string applicationErrorLogDirectory = @"ApplicationErrors";
		private static string generalErrorLogFileName = @"ErrorLog";

		private static readonly string Date = DateTime.Today.ToString ( "yyyy-MM-dd" );

		private static void WriteFile ( string textFile , string message )
		{
			if ( string.IsNullOrEmpty ( textFile ) || ( string.IsNullOrEmpty ( message ) ) )
			{
				throw new ArgumentException ( );
			}

			CreateFile ( textFile );

			var time = DateTime.Now.ToString ( "h:mm:ss tt" );

			lock ( LockObj )
			{
				using ( var streamWriter = File.AppendText ( textFile ) )
				{
					streamWriter.WriteLine ( Date + " : " + time + " : " + message );
					streamWriter.Close ( );
				}
			}
		}

		private static void CreateFile ( string textFile )
		{
			if ( !File.Exists ( textFile ) )
			{
				lock ( LockObj )
				{
					using ( var sw = File.CreateText ( textFile ) )
					{
					}
				}
			}
		}

		private static void MakeDirectory ( string directoryName )
		{
			if ( !Directory.Exists ( directoryName ) )
			{
				lock ( LockObj )
				{
					Directory.CreateDirectory ( directoryName );
				}
			}
		}

		public override void Log ( string fileName , string fileContent )
		{
			MakeDirectory ( masterLog + @"\" + Date );

			var textFile = masterLog + @"\" + Date + @"\" + fileName + fileType;

			WriteFile ( textFile , fileContent );
		}

		public override void LogError ( string message )
		{
			if ( message == null )
				throw new ArgumentNullException ( nameof ( message ) );

			string textFile = masterLog + applicationErrorLogDirectory + @"\" + Date + fileType;

			WriteFile ( textFile , message );
		}

		public override void LogExceptionError ( string message )
		{
			string textFile = masterLog + applicationErrorLogDirectory + @"\" + generalErrorLogFileName + fileType;

			WriteFile ( textFile , message );
		}
	}
}
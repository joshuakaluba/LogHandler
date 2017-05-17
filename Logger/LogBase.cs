using System;

namespace Logger
{
	public abstract class LogBase
	{
		public abstract void Log ( string fileName , String message );

		public abstract void LogError ( string message );

		public abstract void LogExceptionError ( string message );
	}
}
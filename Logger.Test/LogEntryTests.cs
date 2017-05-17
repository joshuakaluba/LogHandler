using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Test
{
	[TestClass]
	public class LogEntryTests
	{
		[TestMethod]
		[ExpectedException ( typeof ( ArgumentException ) )]
		public void LogTestEmptyFileName ( )
		{
			LogEntry.Log ( String.Empty , String.Empty );
			Assert.Fail ( );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ArgumentException ) )]
		public void LogTestInvalidCharacters ( )
		{
			LogEntry.Log ( "#@&*!:" , "message content" );
			Assert.Fail ( );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ArgumentException ) )]
		public void LogErrorEmptyString ( )
		{
			LogEntry.LogError ( String.Empty );
			Assert.Fail ( );
		}

		[TestMethod]
		public void LogExceptionErrorTest ( )
		{
			try
			{
				int denominator = 0;

				int numerator = 12;

				//dividing by zero, this will fail and an exception will be thrown
				int operation = numerator / denominator;
			}
			catch ( DivideByZeroException ex )
			{
				LogEntry.LogExceptionError ( ex );
			}
		}

		[TestMethod]
		public void LogMessageTest ( )
		{
			LogEntry.Log ( "Transactions" , "The document was successfully saved" );
		}
	}
}
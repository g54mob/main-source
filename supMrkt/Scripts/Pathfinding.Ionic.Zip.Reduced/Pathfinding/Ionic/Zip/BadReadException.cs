using System;
using System.Runtime.InteropServices;

namespace Pathfinding.Ionic.Zip
{
	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000A")]
	public class BadReadException : ZipException
	{
		public BadReadException()
		{
		}

		public BadReadException(string message)
		{
		}

		public BadReadException(string message, Exception innerException)
		{
		}
	}
}

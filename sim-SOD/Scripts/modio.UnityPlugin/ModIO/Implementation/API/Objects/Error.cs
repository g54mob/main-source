using System;
using System.Collections.Generic;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	public struct Error
	{
		public long code;

		public long error_ref;

		public string message;

		public Dictionary<string, string> errors;
	}
}

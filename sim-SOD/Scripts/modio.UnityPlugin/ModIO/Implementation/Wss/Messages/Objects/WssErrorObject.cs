using System;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.Wss.Messages.Objects
{
	[Serializable]
	internal struct WssErrorObject
	{
		public Error error;

		public string operation;
	}
}

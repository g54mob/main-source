using System;

namespace Gh
{
	public class NotEnoughStorageSpaceException : ApplicationException
	{
		public ulong ExpectedSize { get; }

		public ulong AvailableSize { get; }

		public bool IsSteamCloudStorage { get; set; }

		public NotEnoughStorageSpaceException(string message, ulong expectedSize, ulong availableSize)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using Jundroo.SocialPlatforms.Steam.RemoteStorage;

namespace Jundroo.SocialPlatforms.Steam.Events
{
	public class RemoteStorageLocalFileChangeEventArgs : EventArgs
	{
		public IReadOnlyList<RemoteStorageLocalFileChange> Changes { get; }

		public RemoteStorageLocalFileChangeEventArgs(IReadOnlyList<RemoteStorageLocalFileChange> changes)
		{
			Changes = changes;
		}
	}
}

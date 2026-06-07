using System;
using System.Collections.ObjectModel;

namespace Jundroo.SocialPlatforms.Steam.Events
{
	public class UserPublishedWorkshopItemsChangedEventArgs : EventArgs
	{
		public ReadOnlyCollection<WorkshopItemInfo> Items { get; private set; }

		public UserPublishedWorkshopItemsChangedEventArgs(ReadOnlyCollection<WorkshopItemInfo> items)
		{
			Items = items;
		}
	}
}

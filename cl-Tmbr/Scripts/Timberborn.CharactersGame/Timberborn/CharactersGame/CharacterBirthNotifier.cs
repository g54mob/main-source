using Timberborn.BaseComponentSystem;
using Timberborn.EntityNaming;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.NotificationSystem;

namespace Timberborn.CharactersGame
{
	public class CharacterBirthNotifier : BaseComponent, IPostInitializableEntity
	{
		private readonly NotificationBus _notificationBus;

		private readonly ILoc _loc;

		private bool _notificationEnabled;

		public CharacterBirthNotifier(NotificationBus notificationBus, ILoc loc)
		{
			_notificationBus = notificationBus;
			_loc = loc;
		}

		public void PostInitializeEntity()
		{
			if (_notificationEnabled)
			{
				_notificationBus.Post(_loc.T(GetComponent<CharacterBirthNotifierSpec>().NotificationLocKey, GetComponent<NamedEntity>().EntityName), this);
			}
		}

		public void EnableNotification()
		{
			_notificationEnabled = true;
		}
	}
}

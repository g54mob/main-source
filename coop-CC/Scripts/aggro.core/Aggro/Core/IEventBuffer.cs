using System.Collections.Generic;

namespace Aggro.Core
{
	internal interface IEventBuffer
	{
		int typeIndex { get; }

		void AddGlobalGenericListener(GlobalGenericEntityEvent callback);

		void RemoveGlobalGenericListener(GlobalGenericEntityEvent callback);

		void AddLocalGenericListener(Entity entity, LocalGenericEntityEvent callback);

		void RemoveLocalGenericListener(Entity entity, LocalGenericEntityEvent callback);

		void ProcessEvents();

		void AddGlobalRegistrations(List<EntityEventManager.GlobalRegistration> registrations);
	}
}

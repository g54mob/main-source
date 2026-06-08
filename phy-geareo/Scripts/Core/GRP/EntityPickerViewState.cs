using System;
using Rhizomatic.ImUI;

namespace GRP
{
	public class EntityPickerViewState : ImUIViewState
	{
		public EntityManager manager;

		public Id id;

		public Func<Entity, bool> filter;

		public EntityPickerViewState(EntityManager manager, Id id, Func<Entity, bool> filter)
		{
		}
	}
}

using System;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class EntityPickerItemViewable : Viewable
	{
		[TextCrew]
		public string name;

		[GameObjectCrew]
		public bool selected;

		public Entity entity;

		private Action onSelect;

		public EntityPickerItemViewable(Entity entity, Id selectedId, Action onSelect)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}

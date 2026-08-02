using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP.Pages.NSKitFrame
{
	public class KitPartViewable : Viewable
	{
		[RawImageCrew]
		public State<Texture> image;

		[TextCrew]
		public StateSelector<string> countText;

		[GameObjectCrew]
		public bool number;

		[GameObjectCrew]
		public StateSelector<bool> available;

		[GameObjectCrew]
		public StateSelector<bool> notAvailable;

		[GameObjectCrew]
		public StateSelector<bool> selected;

		[GameObjectCrew]
		public StateSelector<bool> notSelected;

		public StateSelector<int> currentCount;

		public KitPart part;

		public KitFramePage page;

		public StateList<Id> createdIds;

		public KitPartViewable(KitFramePage page, KitPart part)
		{
		}

		public void Fetch()
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}

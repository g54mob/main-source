using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Pages.NSProjectFrame
{
	public class PartCategoryItemViewable : Viewable
	{
		[ImageCrew]
		public Sprite icon;

		[GameObjectCrew]
		public StateSelector<bool> selected;

		[GameObjectCrew]
		public StateSelector<bool> notSelected;

		public CatalogViewable catalog;

		public PartCategory category;

		public PartCategoryItemViewable(CatalogViewable catalog, PartCategory category)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}

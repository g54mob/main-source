using System;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class LayoutSampleView : MonoBehaviour
	{
		public MeshRenderer Renderer;

		public SiteView DisplayPrefab;

		private MemoryManagerHandle MemoryManagerHandle => this;

		private void OnDestroy()
		{
			MemoryManagerHandle.Dispose();
		}

		public void UpdateBlueprint(LayoutProfile profile)
		{
			LayoutBlueprint blueprint = ConstructLayout(profile);
			if (Renderer != null)
			{
				MemoryManagerHandle.Register(Renderer.material).SetTexture("_Image", PrefabSnapshot.GetLayoutSnapshot(DisplayPrefab, blueprint));
			}
		}

		private LayoutBlueprint ConstructLayout(LayoutProfile profile)
		{
			LayoutDecorator layoutDecorator = null;
			LayoutBlueprint layoutBlueprint = null;
			int num = 100;
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				try
				{
					layoutBlueprint = profile.Graph.Build();
					layoutDecorator = new LayoutDecorator(layoutBlueprint, profile, GameData.Main.Get<RestaurantSetting>(AssetReference.DefaultSetting));
					layoutDecorator.AttemptDecoration();
					flag = true;
				}
				catch (LayoutFailureException)
				{
					continue;
				}
				break;
			}
			if (!flag || layoutDecorator?.Decorations == null)
			{
				throw new Exception($"Giving up after {num} attempts");
			}
			return layoutBlueprint;
		}
	}
}

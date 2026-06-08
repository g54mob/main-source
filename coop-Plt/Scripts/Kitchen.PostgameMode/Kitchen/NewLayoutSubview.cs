using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class NewLayoutSubview : MonoBehaviour, INewsItemSubview
	{
		public List<LayoutSampleView> Views;

		public bool IsInitialised;

		public void SetItem(int id)
		{
			if (IsInitialised)
			{
				return;
			}
			IsInitialised = true;
			foreach (LayoutSampleView view in Views)
			{
				if (GameData.Main.TryGet<LayoutProfile>(id, out var output, warn_if_fail: true))
				{
					view.UpdateBlueprint(output);
				}
			}
		}
	}
}

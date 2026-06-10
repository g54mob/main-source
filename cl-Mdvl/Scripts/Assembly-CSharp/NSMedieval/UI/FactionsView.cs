using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.UI
{
	public class FactionsView : UIView
	{
		[SerializeField]
		private LayoutGroupView entriesGroup;

		private readonly List<FactionEntryLayoutItemView> entries = new List<FactionEntryLayoutItemView>();

		public override void Show()
		{
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFriendlinessChanged;
			base.Show();
			UpdateFactionsPanel();
		}

		private void OnFriendlinessChanged(FactionFriendliness factionFriendliness, FactionInstance factionInstance)
		{
			UpdateFactionsPanel();
		}

		public override void Hide()
		{
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFriendlinessChanged;
			base.Hide();
		}

		public void UpdateFactionsPanel()
		{
			int num = 0;
			WorldMapData worldMapData = GlobalSaveController.CurrentVillageData.WorldMapData;
			foreach (FactionInstance factionInstance in worldMapData.FactionInstances)
			{
				if (worldMapData.VillagePlaceExistsForFaction(factionInstance.BlueprintId))
				{
					entries.GetAt(entriesGroup, num).SetData(factionInstance);
					num++;
				}
			}
			entries.SetActiveFromIndex(num, active: false);
		}
	}
}

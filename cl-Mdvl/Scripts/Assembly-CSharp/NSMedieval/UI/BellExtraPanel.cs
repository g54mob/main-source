using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class BellExtraPanel : SelectionExtraWindowView
	{
		[SerializeField]
		private TMP_InputField bellName;

		[SerializeField]
		private LayoutGroupView entriesContent;

		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private SoundButton allowAllButton;

		[SerializeField]
		private SoundButton clearAllButton;

		[NonSerialized]
		private List<BellListEntry> entries = new List<BellListEntry>();

		[NonSerialized]
		private BellComponentInstance bell;

		public void UpdatePanel(InfoPanelBell infoPanel)
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
			{
				return;
			}
			BaseBuildingInstance baseBuildingInstance = infoPanel.BaseBuildingInstance;
			bell = baseBuildingInstance?.Map.BellComponentManager.GetComponentInstance(baseBuildingInstance);
			if (bell == null)
			{
				Log.Error("No bell here!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\BellExtraPanel.cs");
				return;
			}
			bell.RemoveDisposedRallyPoints();
			Show();
			RefreshListEntries();
			if (MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				bellName.SetTextWithoutNotify(bell.Name);
			}
		}

		private void Start()
		{
			bellName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			bellName.onDeselect.AddListener(OnNameEdit);
			bellName.onEndEdit.AddListener(OnNameEdit);
			allowAllButton.AddCleanListener(AllowAll);
			clearAllButton.AddCleanListener(ClearAll);
		}

		private void AllowAll()
		{
			bell.AssignAllRallyPoints();
			RefreshListEntries();
		}

		private void ClearAll()
		{
			bell.ClearAllRallyPoints();
			RefreshListEntries();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			bellName.onSelect.RemoveAllListeners();
			bellName.onDeselect.RemoveAllListeners();
			bellName.onEndEdit.RemoveAllListeners();
			allowAllButton.RemoveAllListeners();
			clearAllButton.RemoveAllListeners();
			bell = null;
			entries.Clear();
		}

		private void OnNameEdit(string value)
		{
			if (bell != null)
			{
				bell.Name = value;
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
		}

		private void RefreshListEntries()
		{
			int num = 0;
			using PooledList<RallyPointMarkerComponentInstance> pooledList = VillageManager.ActiveVillage.Map.RallyPointMarkerComponentManager.ComponentInstances.ToPooledListJanitor();
			pooledList.Sort((RallyPointMarkerComponentInstance x, RallyPointMarkerComponentInstance y) => x.UniqueID.CompareTo(y.UniqueID));
			foreach (RallyPointMarkerComponentInstance item in pooledList)
			{
				entries.GetAt(entriesContent, num).Init(item, bell);
				num++;
			}
			entries.SetActiveFromIndex(num, active: false);
		}
	}
}

using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using TMPro;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapItemVillagePlace : WorldMapItemClickable
	{
		private static WorldMapItemVillagePlace selected;

		[SerializeField]
		private GameObject selectedMarker;

		private bool isSelected;

		private readonly List<string> tooltipLines = new List<string>();

		private List<string> TooltipLines
		{
			get
			{
				if (tooltipLines.Count == 0)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(MonoSingleton<WorldMap>.Instance.GetMapTypeName(base.GridPosition));
					tooltipLines.Add(text);
				}
				return tooltipLines;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			selected = null;
		}

		public string GetMapTypeName()
		{
			return MonoSingleton<WorldMap>.Instance.GetMapTypeName(base.GridPosition);
		}

		private void SetVillageName(string villageName)
		{
			TMP_Text componentInChildren = GetComponentInChildren<TMP_Text>();
			if (componentInChildren != null)
			{
				componentInChildren.SetText(villageName);
			}
		}

		public void SetVillagePlace(bool isSelectedVillagePlace)
		{
			if (!(this == null))
			{
				isSelected = isSelectedVillagePlace;
				if (selectedMarker != null)
				{
					selectedMarker.SetActive(isSelectedVillagePlace);
				}
				SetVillageName(MonoSingleton<GameStartController>.Instance.SelectedVillageName);
			}
		}

		public override void OnPointerEnter()
		{
			MonoSingleton<TooltipController>.Instance.Show(TooltipLines, null);
		}

		public override void OnPointerLeave()
		{
			MonoSingleton<TooltipController>.Instance.Hide();
		}

		public override void OnClick()
		{
			SetVillagePlace(isSelectedVillagePlace: true);
			if (selected != null && selected != this)
			{
				selected.SetVillagePlace(isSelectedVillagePlace: false);
			}
			selected = this;
			MonoSingleton<WorldMapController>.Instance.PlaceSelected(base.GridPosition);
		}

		private void Start()
		{
			if (MonoSingleton<GameStartController>.IsInstantiated())
			{
				GameStartController instance = MonoSingleton<GameStartController>.Instance;
				instance.VillageNameChangedEvent = (Action<string>)Delegate.Combine(instance.VillageNameChangedEvent, new Action<string>(OnVillageNameChanged));
			}
			if (this != selected)
			{
				SetVillagePlace(isSelectedVillagePlace: false);
			}
		}

		private void OnVillageNameChanged(string villageName)
		{
			SetVillageName(villageName);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<GameStartController>.IsInstantiated())
			{
				GameStartController instance = MonoSingleton<GameStartController>.Instance;
				instance.VillageNameChangedEvent = (Action<string>)Delegate.Remove(instance.VillageNameChangedEvent, new Action<string>(OnVillageNameChanged));
			}
		}

		public static void SetSelected(WorldMapItemVillagePlace villagePlace, bool silent)
		{
			selected = villagePlace;
			if (!silent)
			{
				MonoSingleton<WorldMapController>.Instance.PlaceSelected(villagePlace.GridPosition);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapItemVillage : WorldMapItemClickable
	{
		[SerializeField]
		private MeshRenderer markerRenderer;

		[SerializeField]
		private MeshRenderer villageRenderer;

		[NonSerialized]
		private VillagePlace villagePlace;

		[NonSerialized]
		private Color friendlinessColor;

		[NonSerialized]
		private readonly List<string> tooltipLines = new List<string>();

		private MaterialPropertyBlock villageMaterialPropertyBlock;

		private MaterialPropertyBlock markerPropertyBlock;

		private MaterialPropertyBlock VillageRendererMaterialPropertyBlock => villageMaterialPropertyBlock ?? (villageMaterialPropertyBlock = new MaterialPropertyBlock());

		private MaterialPropertyBlock MarkerPropertyBlock => markerPropertyBlock ?? (markerPropertyBlock = new MaterialPropertyBlock());

		private List<string> TooltipLines
		{
			get
			{
				RefreshTooltipTextLines();
				return tooltipLines;
			}
		}

		private string GetVillageName()
		{
			if (villagePlace == null)
			{
				return GlobalSaveController.CurrentVillageData.Name;
			}
			return villagePlace.Name;
		}

		private void RefreshTooltipTextLines()
		{
			tooltipLines.Clear();
			tooltipLines.Add(GetVillageName());
			if (villagePlace == null)
			{
				tooltipLines.Add(MonoSingleton<LocalizationController>.Instance.GetText("village_yours"));
			}
			else
			{
				CreateFactionTooltip(tooltipLines);
			}
		}

		public void SetVillagePlace(VillagePlace villagePlace)
		{
			this.villagePlace = villagePlace;
			UpdateFriendlinessColors();
		}

		public void UpdateFriendlinessColors()
		{
			if (villageRenderer != null)
			{
				friendlinessColor = WorldMapUtils.GetFriendlinessColor(villagePlace?.FactionInstance);
				Color color = villagePlace.FactionInstance.Blueprint.Color;
				MarkerPropertyBlock.SetColor("_BaseColor", color);
				markerRenderer.SetPropertyBlock(MarkerPropertyBlock);
				Texture2D heraldryCrestTexture = villagePlace.FactionInstance.Blueprint.HeraldryCrestTexture;
				Texture2D heraldryBackgroundTexture = villagePlace.FactionInstance.Blueprint.HeraldryBackgroundTexture;
				VillageRendererMaterialPropertyBlock.SetTexture("_FactionHeraldryCrest", heraldryCrestTexture);
				VillageRendererMaterialPropertyBlock.SetTexture("_FactionHeraldryBackground", heraldryBackgroundTexture);
				VillageRendererMaterialPropertyBlock.SetColor("_outlinecolor", friendlinessColor);
				villageRenderer.SetPropertyBlock(VillageRendererMaterialPropertyBlock);
			}
		}

		public override void OnPointerEnter()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				MonoSingleton<TooltipController>.Instance.Show(TooltipLines, null);
			}
		}

		public override void OnPointerLeave()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				MonoSingleton<TooltipController>.Instance.Hide();
			}
		}

		public override void OnClick()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				if (villagePlace == null)
				{
					MonoSingleton<TooltipController>.Instance.Hide();
					MonoSingleton<WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: false);
				}
				else
				{
					MonoSingleton<WorldMapController>.Instance.PlaceClicked(villagePlace);
				}
			}
		}

		private void CreateFactionTooltip(List<string> textLines)
		{
			if (textLines != null)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(villagePlace.FactionInstance.Blueprint.FactionType.LocKeys));
				textLines.Add(villagePlace.FactionInstance.NameLocalized + " (" + text + ")");
				textLines.Add(WorldMapUtils.GetFriendlinessText(villagePlace?.FactionInstance));
				UpdateFriendlinessColors();
			}
		}
	}
}

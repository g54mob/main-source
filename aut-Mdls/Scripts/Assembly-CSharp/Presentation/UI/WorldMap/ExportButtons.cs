using System.Collections.Generic;
using Data.LevelData;
using Data.ResourceTypes;
using UnityEngine;

namespace Presentation.UI.WorldMap
{
	public class ExportButtons : MonoBehaviour
	{
		[SerializeField]
		private GameObject _button;

		[SerializeField]
		private CityWorldMapUI _cityWorldMapUI;

		private List<ResourceExportButton> _exportButtons = new List<ResourceExportButton>();

		private void AddResource(ResourceType type, bool isUnlocked)
		{
			GameObject obj = Object.Instantiate(_button);
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			ResourceExportButton component = obj.GetComponent<ResourceExportButton>();
			component.Initialize(this, type, isUnlocked);
			_exportButtons.Add(component);
		}

		public void AddResources(int cityRank, List<ExportResource> exportResources)
		{
			foreach (ExportResource exportResource in exportResources)
			{
				if (exportResource.RequiredRankForUnlock <= cityRank)
				{
					AddResource(exportResource.ResourceType, isUnlocked: true);
				}
				else
				{
					AddResource(exportResource.ResourceType, isUnlocked: false);
				}
			}
		}

		public void ResetButtons()
		{
			foreach (ResourceExportButton exportButton in _exportButtons)
			{
				exportButton.ResetButton();
			}
		}

		public void Export(ResourceExportButton button)
		{
			if (button.IsExporting)
			{
				_cityWorldMapUI.RemoveExportLine(button);
			}
			button.IsExporting = true;
			_cityWorldMapUI.CreateExportLine(button);
		}

		public void AnimateLine(ResourceExportButton button)
		{
			_cityWorldMapUI.AnimateLine(button);
		}

		public void StopAnimationLine(ResourceExportButton button)
		{
			_cityWorldMapUI.StopAnimationLine(button);
		}

		public ResourceExportButton GetUnusedButton(ResourceType type)
		{
			foreach (ResourceExportButton exportButton in _exportButtons)
			{
				if (!exportButton.IsExporting && exportButton.ResourceType == type)
				{
					return exportButton;
				}
			}
			return null;
		}
	}
}

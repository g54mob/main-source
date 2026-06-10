using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class AnimalPenExtraPanel : SelectionExtraWindowView
	{
		[SerializeField]
		private TMP_InputField penName;

		[SerializeField]
		private LayoutGroupView entriesContent;

		[SerializeField]
		private TMP_Text descriptionText;

		[NonSerialized]
		private List<AnimalPenListEntry> entries = new List<AnimalPenListEntry>();

		[NonSerialized]
		private PenMarkerComponentInstance penMarker;

		public void UpdatePanel(InfoPanelPenMarker infoPanelMeshVariations)
		{
			BaseBuildingInstance baseBuildingInstance = infoPanelMeshVariations.Selection.FirstOrDefault();
			penMarker = baseBuildingInstance?.Map.PenMarkerComponentManager.GetComponentInstance(baseBuildingInstance);
			if (penMarker == null)
			{
				Log.Error("No pen here!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\AnimalPenExtraPanel.cs");
				return;
			}
			Show();
			SetupAnimals();
			if (MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				penName.SetTextWithoutNotify(penMarker.Name);
			}
			SetupDescriptionText();
		}

		private void Start()
		{
			penName.onSelect.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			penName.onDeselect.AddListener(OnNameEdit);
			penName.onEndEdit.AddListener(OnNameEdit);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			penMarker = null;
			entries.Clear();
		}

		private void OnNameEdit(string value)
		{
			if (penMarker != null)
			{
				penMarker.SetNameToAllInPen(value);
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
		}

		private void SetupDescriptionText()
		{
			if (!(descriptionText == null))
			{
				if (penMarker.GetAnimalPen() == null)
				{
					entriesContent.gameObject.SetActive(value: false);
					descriptionText.text = MonoSingleton<LocalizationController>.Instance.GetText("animal_pen_disabled_outside");
				}
				else
				{
					entriesContent.gameObject.SetActive(value: true);
					descriptionText.text = MonoSingleton<LocalizationController>.Instance.GetText("animal_pen_panel_description");
				}
			}
		}

		private void SetupAnimals()
		{
			int num = 0;
			foreach (Animal item in Repository<AnimalBaseRepository, Animal>.Instance.AnimalsCanBeInPen)
			{
				entries.GetAt(entriesContent, num).Init(item, penMarker);
				num++;
			}
			entries.SetActiveFromIndex(num, active: false);
		}
	}
}

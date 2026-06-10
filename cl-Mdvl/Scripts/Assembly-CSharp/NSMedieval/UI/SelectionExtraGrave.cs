using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.UI
{
	[Serializable]
	public class SelectionExtraGrave : SelectionExtraWindowView
	{
		[SerializeField]
		private LayoutGroupView checkboxParent;

		[SerializeField]
		private TextMeshProUGUI title;

		private Dictionary<string, ResourceToggleItemView> checkboxDictionary = new Dictionary<string, ResourceToggleItemView>();

		[NonSerialized]
		private List<GraveComponentInstance> graveComponentInstances;

		public void UpdatePanel(InfoPanelGraves infoPanelGraves)
		{
			graveComponentInstances = infoPanelGraves.GraveComponentInstances;
			Refresh();
		}

		public override void Initialize()
		{
			base.Initialize();
			Setup();
		}

		public override void Hide()
		{
			graveComponentInstances = null;
			EventSystem.current.SetSelectedGameObject(null);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			base.Hide();
		}

		private void Setup()
		{
			SetupCheckBox("enemy");
			SetupCheckBox("worker");
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			graveComponentInstances = null;
		}

		private void SetupCheckBox(string resourceID)
		{
			ResourceToggleItemView component = UnityEngine.Object.Instantiate(checkboxParent.Prefab, checkboxParent.transform).GetComponent<ResourceToggleItemView>();
			component.gameObject.name = resourceID;
			component.SetupGroup(resourceID, "name", 0);
			OnResourceToggleChange(resourceID, component);
			checkboxDictionary.Add(resourceID, component);
		}

		private void OnResourceToggleChange(string bodyID, ResourceToggleItemView view)
		{
			view.GroupSelectToggle.onValueChanged.AddListener(delegate(bool allowed)
			{
				if (graveComponentInstances == null)
				{
					return;
				}
				view.SetSelected(allowed);
				foreach (GraveComponentInstance graveComponentInstance in graveComponentInstances)
				{
					if (allowed)
					{
						graveComponentInstance.AllowBody(bodyID);
					}
					else
					{
						graveComponentInstance.ForbidBody(bodyID);
					}
				}
			});
		}

		private void Refresh()
		{
			Show();
			foreach (string bodyID in checkboxDictionary.Keys)
			{
				checkboxDictionary[bodyID].GroupSelectToggle.SetIsOnWithoutNotify(graveComponentInstances.Any((GraveComponentInstance g) => g.AllowedBodies.Contains(bodyID)));
			}
			if (graveComponentInstances.Count > 1)
			{
				title.text = $"Multiple Graves - {graveComponentInstances.Count}";
				return;
			}
			if (graveComponentInstances[0].Empty())
			{
				title.text = graveComponentInstances[0].GetBodyName();
				return;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("grave");
			string bodyName = graveComponentInstances[0].GetBodyName();
			title.text = text + " - " + bodyName;
		}
	}
}

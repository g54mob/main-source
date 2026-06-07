using System.Collections.Generic;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class StagingPanelController : FlightPanelController
	{
		private class StageGroup
		{
			public TextMeshProUGUI CountText { get; set; }

			public GameObject GameObject { get; set; }

			public StageActivationType StageActivationType { get; set; }
		}

		private Dictionary<StageActivationType, int> _activationTypeCounts = new Dictionary<StageActivationType, int>();

		private int _currentStage = -1;

		private TextMeshProUGUI _currentStageText;

		private List<IPartScript> _parts = new List<IPartScript>();

		private List<StageGroup> _stageGroups = new List<StageGroup>();

		public override void CraftNodeChanged(CraftNode craftNode)
		{
			_currentStage = -1;
			HighlightStageGroup(null);
		}

		public override void CraftStructureChanged(CraftNode craftNode)
		{
			_currentStage = -1;
			HighlightStageGroup(null);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			_currentStage = -1;
			_stageGroups.Clear();
			AddStageGroup(StageActivationType.Engine, "stage-group-engines");
			AddStageGroup(StageActivationType.Detacher, "stage-group-interstages");
			AddStageGroup(StageActivationType.Fairing, "stage-group-fairings");
			AddStageGroup(StageActivationType.LandingLeg, "stage-group-landing-legs");
			AddStageGroup(StageActivationType.Parachute, "stage-group-parachutes");
			AddStageGroup(StageActivationType.Payload, "stage-group-payloads");
			_currentStageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("current-stage-number");
			HideStagingGroups();
		}

		public override void UpdatePanel(CraftNode craftNode)
		{
			if (craftNode != null)
			{
				if (_currentStage != craftNode.CraftScript.ActiveCommandPod.CurrentStage)
				{
					UpdateStaging(craftNode);
				}
			}
			else
			{
				HideStagingGroups();
			}
		}

		private void AddStageGroup(StageActivationType stageActivationType, string elementId)
		{
			StageGroup stageGroup = new StageGroup();
			XmlElement elementById = base.xmlLayout.GetElementById(elementId);
			stageGroup.CountText = elementById.GetComponentInChildren<TextMeshProUGUI>();
			stageGroup.StageActivationType = stageActivationType;
			stageGroup.GameObject = elementById.gameObject;
			_stageGroups.Add(stageGroup);
		}

		private void HideStagingGroups()
		{
			foreach (StageGroup stageGroup in _stageGroups)
			{
				stageGroup.GameObject.SetActive(value: false);
			}
		}

		private void HighlightStageGroup(StageGroup stageGroup)
		{
			foreach (IPartScript part in _parts)
			{
				if (part.GameObject != null)
				{
					part.PartMaterialScript.IsHighlighted = false;
				}
			}
			_parts.Clear();
			if (stageGroup == null || base.CraftNode == null)
			{
				return;
			}
			foreach (PartData part2 in base.CraftNode.CraftScript.Data.Assembly.Parts)
			{
				if (part2.Config.StageActivationType == stageGroup.StageActivationType && part2.ActivationStage == _currentStage)
				{
					part2.PartScript.PartMaterialScript.IsHighlighted = true;
					_parts.Add(part2.PartScript);
				}
			}
		}

		private void OnMouseEnter(XmlElement xmlElement)
		{
			StageGroup stageGroup = null;
			foreach (StageGroup stageGroup2 in _stageGroups)
			{
				if (stageGroup2.GameObject == xmlElement.gameObject)
				{
					stageGroup = stageGroup2;
				}
			}
			HighlightStageGroup(stageGroup);
		}

		private void OnMouseExit(XmlElement xmlElement)
		{
			HighlightStageGroup(null);
		}

		private void OnStagingButtonClicked()
		{
			base.FlightSceneUiController.CraftNode.CraftScript.ActiveCommandPod.ActivateStage();
		}

		private void UpdateStaging(CraftNode craftNode)
		{
			_currentStage = craftNode.CraftScript.ActiveCommandPod.CurrentStage;
			if (_currentStage < craftNode.CraftScript.ActiveCommandPod.NumStages)
			{
				_activationTypeCounts.Clear();
				foreach (StageGroup stageGroup in _stageGroups)
				{
					_activationTypeCounts[stageGroup.StageActivationType] = 0;
				}
				foreach (PartData part in craftNode.CraftScript.Data.Assembly.Parts)
				{
					if (part.PartScript.CommandPod == craftNode.CraftScript.ActiveCommandPod && !part.PartScript.Disconnected && part.Config.StageActivationType != StageActivationType.None && part.ActivationStage == _currentStage)
					{
						_activationTypeCounts[part.Config.StageActivationType]++;
					}
				}
				foreach (StageGroup stageGroup2 in _stageGroups)
				{
					int num = _activationTypeCounts[stageGroup2.StageActivationType];
					if (num > 0)
					{
						stageGroup2.CountText.text = "x" + num;
						stageGroup2.GameObject.SetActive(value: true);
					}
					else
					{
						stageGroup2.GameObject.SetActive(value: false);
					}
				}
				_currentStageText.text = "STG " + (_currentStage + 1);
			}
			else
			{
				_currentStageText.text = "END";
				HideStagingGroups();
			}
		}
	}
}

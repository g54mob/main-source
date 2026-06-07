using System.Collections.Generic;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Math;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.Staging
{
	public class StageNodeScript : TreeNodeScript
	{
		private Transform _borderImage;

		private List<CategoryNodeScript> _categories = new List<CategoryNodeScript>();

		private TextMeshProUGUI _countText;

		private GameObject _deleteButton;

		private GameObject _emptyStageUI;

		private TextMeshProUGUI _infoBurnTime;

		private TextMeshProUGUI _infoDeltaV;

		private GameObject _infoPanel;

		private TextMeshProUGUI _infoThrustToWeightRatio;

		private bool _selected;

		private int _stageNumber;

		public bool IsUserAddedStage { get; set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					if (_selected)
					{
						base.XmlElement.AddClass("selected");
					}
					else
					{
						base.XmlElement.RemoveClass("selected");
					}
				}
			}
		}

		public int StageNumber
		{
			get
			{
				return _stageNumber;
			}
			set
			{
				if (_stageNumber != value)
				{
					_stageNumber = value;
					base.Text = "STAGE " + _stageNumber;
				}
			}
		}

		public override void AddChild(TreeNodeScript child)
		{
			base.AddChild(child);
			_infoPanel.transform.SetAsLastSibling();
			_borderImage.SetAsLastSibling();
		}

		public void AddPartNode(PartNodeScript partNode)
		{
			GetOrCreateCategory(partNode.PartData.Config.StageActivationType).AddPartNode(partNode);
		}

		public void ApplyStaging()
		{
			foreach (PartNodeScript partNode in GetPartNodes())
			{
				partNode.PartData.ActivationStage = StageNumber - 1;
			}
		}

		public void Initialize(StagingEditorScript stagingEditor, XmlElement element)
		{
			InitializeNode(stagingEditor, element);
			_borderImage = Utilities.FindFirstGameObjectMyselfOrChildren("_BorderImage_", base.gameObject).transform;
			_emptyStageUI = element.GetElementByInternalId("empty").gameObject;
			_countText = element.GetElementByInternalId<TextMeshProUGUI>("count");
			_deleteButton = element.GetElementByInternalId("delete-button").gameObject;
			_infoPanel = element.GetElementByInternalId("info-panel").gameObject;
			_infoBurnTime = element.GetElementByInternalId<TextMeshProUGUI>("info-burn-time");
			_infoThrustToWeightRatio = element.GetElementByInternalId<TextMeshProUGUI>("info-twr");
			_infoDeltaV = element.GetElementByInternalId<TextMeshProUGUI>("info-delta-v");
			base.gameObject.AddComponent<TreeNodeDropTargetScript>();
		}

		public override void UpdateContent()
		{
			base.UpdateContent();
			bool flag = true;
			foreach (TreeNodeScript child in base.Children)
			{
				if (!child.Empty)
				{
					flag = false;
				}
			}
			if (flag)
			{
				_countText.text = "Empty";
			}
			else
			{
				_countText.text = "x" + GetPartNodes().Count;
			}
			_emptyStageUI.SetActive(flag && base.Expanded);
			_deleteButton.SetActive(flag);
			_countText.gameObject.SetActive(!flag);
		}

		public void UpdateStatistics(StageAnalysis.Stage stageInfo)
		{
			if (stageInfo == null)
			{
				_infoPanel.SetActive(value: false);
				return;
			}
			_infoPanel.SetActive(value: true);
			_infoBurnTime.text = Units.GetRelativeTimeString(stageInfo.BurnTime);
			_infoThrustToWeightRatio.text = $"{stageInfo.StartingThrustToWeightRatio:n2}:1";
			_infoDeltaV.text = Units.GetVelocityString((int)stageInfo.DeltaV);
		}

		protected virtual void Update()
		{
		}

		private CategoryNodeScript GetOrCreateCategory(StageActivationType stageActivationType)
		{
			CategoryNodeScript categoryNodeScript = null;
			foreach (CategoryNodeScript category in _categories)
			{
				if (category.ActivationType == stageActivationType)
				{
					categoryNodeScript = category;
					break;
				}
			}
			if (categoryNodeScript == null)
			{
				categoryNodeScript = base.StagingEditor.CreateCategoryNode(stageActivationType);
				categoryNodeScript.Order = (int)stageActivationType;
				AddChild(categoryNodeScript);
				_categories.Add(categoryNodeScript);
			}
			return categoryNodeScript;
		}
	}
}

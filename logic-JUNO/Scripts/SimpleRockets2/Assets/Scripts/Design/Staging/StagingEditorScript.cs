using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.State;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Staging
{
	public class StagingEditorScript : MonoBehaviour
	{
		private TreeNodeScript _activeTreeNode;

		private float _autoScrollAmount;

		private ICraftScript _craftScript;

		private Transform _dragParent;

		private TreeNodeScript _dragSource;

		private StageNodeScript _dropTarget;

		private TextMeshProUGUI _infoTotalDeltaV;

		private XmlElement _infoTotalPanel;

		private Dictionary<PartData, PartNodeScript> _partNodes = new Dictionary<PartData, PartNodeScript>();

		private CraftPerformanceAnalysis _performanceAnalysis;

		private GameObject _rearrangeIndicator;

		private StageNodeScript _rearrangeTargetButton;

		private GameObject _resetStagingButton;

		private bool _resetStagingButtonEnabled = true;

		private ScrollRect _scrollRect;

		private bool _showDeltaV;

		private List<StageNodeScript> _stageNodes = new List<StageNodeScript>();

		private XmlElement _toggleAutoRecalculateButton;

		private XmlElement _toggleDeltaVButton;

		private Transform _treeNodeParent;

		private bool _updateDeltaV;

		private XmlLayout _xmlLayout;

		public Transform DragParent => _dragParent;

		public bool IsDragging => _dragSource != null;

		public bool ResetStagingButtonEnabled
		{
			get
			{
				return _resetStagingButtonEnabled;
			}
			set
			{
				_resetStagingButtonEnabled = value;
				_resetStagingButton.SetActive(value);
			}
		}

		public Action<string> ShowMessage { get; set; }

		public IUserInterface UserInterface { get; set; }

		public XmlElement CloneTemplateElement(string templateId, Transform parent)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_xmlLayout.GetElementById(templateId).gameObject);
			obj.transform.SetParent(parent, worldPositionStays: false);
			XmlElement component = obj.GetComponent<XmlElement>();
			component.SetAttribute("id", null);
			component.SetAttribute("active", "true");
			component.ApplyAttributesRecursive();
			component.gameObject.SetActive(value: true);
			return component;
		}

		public CategoryNodeScript CreateCategoryNode(StageActivationType stageActivationType)
		{
			XmlElement xmlElement = CloneTemplateElement("template-category-node", _treeNodeParent);
			xmlElement.gameObject.transform.SetAsFirstSibling();
			CategoryNodeScript categoryNodeScript = xmlElement.gameObject.AddComponent<CategoryNodeScript>();
			categoryNodeScript.Initialize(this, xmlElement, stageActivationType);
			return categoryNodeScript;
		}

		public void Dragging(PointerEventData eventData)
		{
			_autoScrollAmount = 0f;
			if (!(_dragSource is StageNodeScript))
			{
				return;
			}
			StageNodeScript stageNodeScript = null;
			foreach (StageNodeScript stageNode in _stageNodes)
			{
				if (eventData.position.y > stageNode.transform.position.y - 40f && (stageNodeScript == null || stageNode.transform.position.y > stageNodeScript.transform.position.y))
				{
					stageNodeScript = stageNode;
				}
			}
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.viewport, eventData.position, null, out var localPoint))
			{
				float num = Mathf.Clamp(0f - localPoint.y, 0f, _scrollRect.viewport.rect.height);
				if (num < 50f)
				{
					_autoScrollAmount = Mathf.Clamp01((50f - num) / 50f * 2f);
				}
				else if (num > _scrollRect.viewport.rect.height - 50f)
				{
					float num2 = _scrollRect.viewport.rect.height - num;
					_autoScrollAmount = 0f - Mathf.Clamp01((50f - num2) / 50f * 2f);
				}
			}
			_rearrangeIndicator.SetActive(value: true);
			if (stageNodeScript != null)
			{
				if (_rearrangeIndicator.transform.GetSiblingIndex() > stageNodeScript.transform.GetSiblingIndex())
				{
					_rearrangeIndicator.transform.SetSiblingIndex(stageNodeScript.transform.GetSiblingIndex());
				}
				else
				{
					int num3 = stageNodeScript.transform.GetSiblingIndex() - 1;
					if (_rearrangeIndicator.transform.GetSiblingIndex() != num3)
					{
						_rearrangeIndicator.transform.SetSiblingIndex(num3);
					}
				}
			}
			else
			{
				_rearrangeIndicator.transform.SetAsLastSibling();
			}
			_rearrangeTargetButton = stageNodeScript;
		}

		public void EndDrag(TreeNodeScript treeNode)
		{
			if (_dragSource is StageNodeScript)
			{
				StageNodeScript stageNodeScript = _dragSource as StageNodeScript;
				if (_rearrangeTargetButton != null)
				{
					if (_rearrangeTargetButton != stageNodeScript)
					{
						stageNodeScript.transform.SetSiblingIndex(_rearrangeTargetButton.transform.GetSiblingIndex() - 1);
						_stageNodes.Remove(stageNodeScript);
						int num = _stageNodes.IndexOf(_rearrangeTargetButton);
						_stageNodes.Insert(num + 1, stageNodeScript);
					}
				}
				else
				{
					stageNodeScript.transform.SetAsLastSibling();
					_stageNodes.Remove(stageNodeScript);
					_stageNodes.Insert(0, stageNodeScript);
				}
				UpdateStageNumbers();
				_rearrangeTargetButton = null;
				_rearrangeIndicator.SetActive(value: false);
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDropStage);
				foreach (PartNodeScript partNode in stageNodeScript.GetPartNodes())
				{
					partNode.PartData.ActivationStageOverride = true;
				}
			}
			else if (_dropTarget != null)
			{
				_dropTarget.Selected = false;
				if (_dropTarget != _dragSource.StageNode)
				{
					foreach (PartNodeScript partNode2 in _dragSource.GetPartNodes())
					{
						partNode2.PartData.ActivationStageOverride = true;
						_dropTarget.AddPartNode(partNode2);
					}
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDropPart);
				}
			}
			_dragSource = null;
			_dropTarget = null;
			_autoScrollAmount = 0f;
			ApplyStaging();
			_performanceAnalysis?.OnStagingChanged();
			UpdateStageNodeContent();
		}

		public void EnterDropTarget(StageNodeScript stageNode, PointerEventData eventData)
		{
			if (_dragSource != null && _dropTarget != stageNode && !(_dragSource is StageNodeScript) && _dragSource.StageNode != stageNode)
			{
				if (_dropTarget != null)
				{
					_dropTarget.Selected = false;
				}
				_dropTarget = stageNode;
				_dropTarget.Selected = true;
			}
		}

		public void ExitDropTarget(StageNodeScript stagingButton)
		{
			if (_dragSource != null && _dropTarget == stagingButton)
			{
				_dropTarget.Selected = false;
				_dropTarget = null;
			}
		}

		public PartNodeScript GetPartNode(PartData part)
		{
			if (_partNodes.ContainsKey(part))
			{
				return _partNodes[part];
			}
			return null;
		}

		public StageNodeScript GetStageNode(int stageNumber)
		{
			int num = stageNumber - 1;
			if (num >= 0 && num < _stageNodes.Count)
			{
				return _stageNodes[num];
			}
			return null;
		}

		public void OnClose()
		{
			OnMouseExitNode();
		}

		public void OnDeleteStageNodeClicked(XmlElement element)
		{
			StageNodeScript componentInParent = element.GetComponentInParent<StageNodeScript>();
			RemoveStageNode(componentInParent);
			UpdateStageNumbers();
			ApplyStaging();
			_performanceAnalysis?.OnStagingChanged();
			ShowMessage("Deleted Stage");
		}

		public void OnLayoutRebuilt(XmlLayoutController controller)
		{
			_xmlLayout = controller.xmlLayout;
			_dragParent = _xmlLayout.GetElementById("drag-parent").transform;
			_rearrangeIndicator = _xmlLayout.GetElementById("rearrange-indicator").gameObject;
			_scrollRect = GetComponentInChildren<ScrollRect>(includeInactive: true);
			_resetStagingButton = _xmlLayout.GetElementById("reset-staging-button").gameObject;
			_treeNodeParent = _xmlLayout.GetElementById("content-root").transform;
			_toggleDeltaVButton = _xmlLayout.GetElementById("show-deltav-button");
			_toggleAutoRecalculateButton = _xmlLayout.GetElementById("auto-recalculate-button");
			_infoTotalPanel = _xmlLayout.GetElementById("info-total-panel");
			_infoTotalDeltaV = _xmlLayout.GetElementById<TextMeshProUGUI>("info-total-delta-v");
			_performanceAnalysis = Game.Instance.Designer.PerformanceAnalysis as CraftPerformanceAnalysis;
			_performanceAnalysis.EnvironmentChanged += OnPerformanceAnalysisEnvironmentChanged;
		}

		public void StartDrag(TreeNodeScript treeNode)
		{
			_dragSource = treeNode;
			if (treeNode is StageNodeScript)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDragStage);
			}
			else
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDragPart);
			}
		}

		public void UpdateStaging(ICraftScript craftScript, bool removeEmptyStages)
		{
			if (_craftScript != craftScript)
			{
				_craftScript = craftScript;
			}
			StagingData stages = new StageCalculator(craftScript.PrimaryCommandPod).GetStages();
			UpdateStagingFromCraft(stages, removeEmptyStages, _craftScript.Data.DesignerSettings.UserStages);
			UpdateAutoRecalculateStagesButton();
		}

		protected virtual void Update()
		{
			if (_updateDeltaV)
			{
				_updateDeltaV = false;
				UpdateStageNodeContent();
			}
			if (_dragSource != null && _autoScrollAmount != 0f)
			{
				float num = 1000f / _scrollRect.content.rect.height;
				_scrollRect.verticalNormalizedPosition += _autoScrollAmount * num * Time.deltaTime;
				_scrollRect.verticalNormalizedPosition = Mathf.Clamp01(_scrollRect.verticalNormalizedPosition);
			}
		}

		private StageNodeScript AddStageNode()
		{
			int stageNumber = _stageNodes.Count + 1;
			XmlElement xmlElement = CloneTemplateElement("template-stage-node", _treeNodeParent);
			xmlElement.gameObject.transform.SetAsFirstSibling();
			StageNodeScript stageNodeScript = xmlElement.gameObject.AddComponent<StageNodeScript>();
			stageNodeScript.Initialize(this, xmlElement);
			stageNodeScript.StageNumber = stageNumber;
			_stageNodes.Add(stageNodeScript);
			_infoTotalPanel.transform.SetAsFirstSibling();
			return stageNodeScript;
		}

		private void ApplyStaging()
		{
			_craftScript.Data.DesignerSettings.UserStages.Clear();
			foreach (StageNodeScript stageNode in _stageNodes)
			{
				if (stageNode.IsUserAddedStage)
				{
					_craftScript.Data.DesignerSettings.UserStages.Add(stageNode.StageNumber - 1);
				}
				stageNode.ApplyStaging();
			}
		}

		private PartNodeScript CreatePartNode(PartData partData)
		{
			XmlElement xmlElement = CloneTemplateElement("template-part-node", _treeNodeParent);
			xmlElement.gameObject.transform.SetAsFirstSibling();
			PartNodeScript partNodeScript = xmlElement.gameObject.AddComponent<PartNodeScript>();
			partNodeScript.Initialize(this, xmlElement, partData);
			return partNodeScript;
		}

		private StageNodeScript GetOrCreateStageNode(int stageNumber)
		{
			if (stageNumber > 100)
			{
				throw new ArgumentException($"Attempting to create more than the maximum of {100} stages.");
			}
			int num = stageNumber - 1;
			while (_stageNodes.Count <= num)
			{
				AddStageNode();
			}
			return _stageNodes[num];
		}

		private void OnAddStageButtonClicked()
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			int num = (validator.IsCareerMode ? ((int)validator.ItemValue("Craft.Stages")) : 99);
			if (_stageNodes.Count < num || CareerState.IsDebugMode)
			{
				StageNodeScript stageNodeScript = AddStageNode();
				stageNodeScript.IsUserAddedStage = true;
				stageNodeScript.UpdateContent();
				ShowMessage("Added New Stage");
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You have reached the maximum number of stages." + (validator.IsCareerMode ? " You can unlock more in the Tech Tree." : string.Empty);
			}
		}

		private void OnMouseEnterNode(XmlElement element)
		{
			if (!IsDragging)
			{
				_activeTreeNode = element.GetComponentInParent<TreeNodeScript>();
				if (_activeTreeNode != null)
				{
					_activeTreeNode.HighlightParts(highlight: true);
				}
			}
		}

		private void OnMouseExitNode()
		{
			if (_activeTreeNode != null)
			{
				_activeTreeNode.HighlightParts(highlight: false);
			}
		}

		private void OnPerformanceAnalysisEnvironmentChanged(object sender, EventArgs e)
		{
			if (base.gameObject.activeInHierarchy)
			{
				_updateDeltaV = _showDeltaV;
			}
		}

		private void OnResetStagingButtonClicked()
		{
			MessageDialogScript messageDialogScript = UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "This will reset all changes you've made to staging.\n\nPlease, confirm that you wish to reset your staging.";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += OnResetStagingConfirmClicked;
		}

		private void OnResetStagingConfirmClicked(MessageDialogScript messageDialog)
		{
			messageDialog.Close();
			foreach (PartData part in _craftScript.Data.Assembly.Parts)
			{
				part.ActivationStageOverride = false;
			}
			_craftScript.Data.DesignerSettings.UserStages.Clear();
			_craftScript.PrimaryCommandPod.StageCalculationVersion = 2;
			_performanceAnalysis?.RecalculateStaging();
			UpdateStaging(_craftScript, removeEmptyStages: true);
			ShowMessage("Staging Reset");
		}

		private void OnToggleAutoRecalculateButtonClicked()
		{
			_craftScript.PrimaryCommandPod.AutoRecalculateStages = !_craftScript.PrimaryCommandPod.AutoRecalculateStages;
			UpdateAutoRecalculateStagesButton();
		}

		private void OnToggleDeltaVButtonClicked()
		{
			_showDeltaV = !_showDeltaV;
			if (!_showDeltaV)
			{
				_toggleDeltaVButton.RemoveClass("btn-primary");
				_infoTotalPanel.SetActive(active: false);
				foreach (StageNodeScript stageNode in _stageNodes)
				{
					stageNode.UpdateStatistics(null);
				}
			}
			else
			{
				_toggleDeltaVButton.AddClass("btn-primary");
				_infoTotalPanel.SetActive(active: true);
				UpdateStageNodeContent();
			}
			_toggleDeltaVButton.ApplyAttributesRecursive();
		}

		private void RemoveStageNode(StageNodeScript stageNode)
		{
			_stageNodes.Remove(stageNode);
			UnityEngine.Object.Destroy(stageNode.gameObject);
		}

		private void UpdateAutoRecalculateStagesButton()
		{
			if (!_craftScript.PrimaryCommandPod.AutoRecalculateStages)
			{
				_toggleAutoRecalculateButton.RemoveClass("btn-primary");
			}
			else
			{
				_toggleAutoRecalculateButton.AddClass("btn-primary");
			}
			_toggleAutoRecalculateButton.ApplyAttributesRecursive();
		}

		private void UpdateStageNodeContent()
		{
			foreach (StageNodeScript stageNode2 in _stageNodes)
			{
				stageNode2.UpdateContent();
			}
			if (!_showDeltaV)
			{
				return;
			}
			StageAnalysis stageAnalysis = _performanceAnalysis.StageAnalysis;
			_infoTotalDeltaV.text = $"Total Delta-V: {Units.GetVelocityString((int)stageAnalysis.TotalDeltaV)}";
			foreach (StageNodeScript stageNode in _stageNodes)
			{
				StageAnalysis.Stage stageInfo = stageAnalysis.Stages.Where((StageAnalysis.Stage x) => x.StageNumber == stageNode.StageNumber).FirstOrDefault();
				stageNode.UpdateStatistics(stageInfo);
			}
		}

		private void UpdateStageNumbers()
		{
			for (int i = 0; i < _stageNodes.Count; i++)
			{
				_stageNodes[i].StageNumber = i + 1;
			}
		}

		private void UpdateStagingFromCraft(StagingData stagingData, bool removeEmptyStages, List<int> userStages)
		{
			foreach (PartNodeScript value2 in _partNodes.Values)
			{
				value2.FlaggedForDeletion = true;
			}
			for (int i = 0; i < stagingData.Stages.Count; i++)
			{
				ActivationStage activationStage = stagingData.Stages[i];
				StageNodeScript orCreateStageNode = GetOrCreateStageNode(i + 1);
				foreach (PartData part in activationStage.Parts)
				{
					PartNodeScript value = null;
					if (!_partNodes.TryGetValue(part, out value))
					{
						value = CreatePartNode(part);
						_partNodes[part] = value;
					}
					value.FlaggedForDeletion = false;
					value.Text = part.Name;
					if (value.CategoryNode != null)
					{
						value.CategoryNode.RemovePartNode(value);
					}
					orCreateStageNode.AddPartNode(value);
				}
			}
			List<PartNodeScript> list = new List<PartNodeScript>();
			foreach (PartNodeScript value3 in _partNodes.Values)
			{
				if (value3.FlaggedForDeletion)
				{
					list.Add(value3);
				}
			}
			foreach (PartNodeScript item in list)
			{
				_partNodes.Remove(item.PartData);
				item.Parent.RemoveChild(item);
				item.PartData = null;
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (StageNodeScript stageNode2 in _stageNodes)
			{
				stageNode2.IsUserAddedStage = false;
			}
			foreach (int userStage in userStages)
			{
				if (userStage >= 0 && userStage < _stageNodes.Count)
				{
					_stageNodes[userStage].IsUserAddedStage = true;
				}
			}
			if (removeEmptyStages)
			{
				for (int num = _stageNodes.Count - 1; num >= stagingData.Stages.Count; num--)
				{
					StageNodeScript stageNode = _stageNodes[num];
					RemoveStageNode(stageNode);
				}
			}
			UpdateStageNodeContent();
		}
	}
}

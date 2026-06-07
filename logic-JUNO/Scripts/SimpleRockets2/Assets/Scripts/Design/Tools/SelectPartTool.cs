using System;
using ModApi.Craft.Parts;
using ModApi.Design;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class SelectPartTool : DesignerToolBase, ISelectPartTool
	{
		private Action _cancelAction;

		private Action<PartData> _completeAction;

		private bool _enableGizmosRestore;

		private IPartScript _initiallySelectedPart;

		private Func<PartData, bool> _partFilter;

		private XmlElement _selectButton;

		private IPartScript _selectedPart;

		private XmlElement _selectPartPanel;

		public override bool IsBaseTool => false;

		public SelectPartTool(DesignerScript designer)
			: base(designer)
		{
		}

		public override void Activate()
		{
			base.Activate();
			if (_selectPartPanel == null)
			{
				DesignerUiScript designerUiScript = base.Designer.DesignerUi as DesignerUiScript;
				_selectPartPanel = designerUiScript.DesignerUiController.xmlLayout.GetElementById("select-part-panel");
				_selectButton = _selectPartPanel.GetElementByInternalId("select-button");
				_selectButton.AddOnClickEvent(delegate
				{
					OnSelectButtonClicked();
				});
				_selectPartPanel.GetElementByInternalId("cancel-button").AddOnClickEvent(delegate
				{
					OnCancelButtonClicked();
				});
			}
			_selectPartPanel.Show();
			_selectButton.Hide();
			base.Designer.HighlightedPart = null;
			base.Designer.AllowPartSelection = true;
			base.Designer.AllowPartMovement = false;
			if (_initiallySelectedPart != null)
			{
				base.Designer.SelectPart(_initiallySelectedPart, null, justAdded: false);
				_initiallySelectedPart = null;
			}
			else
			{
				base.Designer.DeselectPart();
			}
			foreach (PartData part in base.DesignerScript.CraftScript.Data.Assembly.Parts)
			{
				if (_partFilter(part))
				{
					part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Normal;
				}
				else
				{
					part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Disabled;
				}
			}
			_enableGizmosRestore = Game.Instance.Settings.Game.Designer.EnableGizmos.Value;
			Game.Instance.Settings.Game.Designer.EnableGizmos.Value = false;
		}

		public void Activate(Func<PartData, bool> partFilter, PartData selectedPart, Action<PartData> completeAction, Action cancelAction)
		{
			_initiallySelectedPart = selectedPart?.PartScript;
			_partFilter = partFilter;
			_completeAction = completeAction;
			_cancelAction = cancelAction;
			base.Designer.SelectTool(this);
			base.Designer.DesignerUi.SetMainPanelVisibility(visible: false);
		}

		public override void Deactivate()
		{
			base.Deactivate();
			base.Designer.AllowPartMovement = true;
			_partFilter = null;
			_completeAction = null;
			_cancelAction = null;
			_selectPartPanel.Hide();
			base.Designer.DesignerUi.SetMainPanelVisibility(visible: true);
			foreach (PartData part in base.DesignerScript.CraftScript.Data.Assembly.Parts)
			{
				part.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Normal;
			}
			Game.Instance.Settings.Game.Designer.EnableGizmos.Value = _enableGizmosRestore;
		}

		public override void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
			base.SelectedPartChanged(newPart, hit, justAdded);
			if (newPart != null)
			{
				_selectButton?.Show();
			}
			else
			{
				_selectButton?.Hide();
			}
		}

		private void OnCancelButtonClicked()
		{
			_cancelAction?.Invoke();
			base.Designer.DeselectTool(this);
		}

		private void OnSelectButtonClicked()
		{
			if (base.Designer.SelectedPart?.Data != null)
			{
				_completeAction?.Invoke(base.Designer.SelectedPart.Data);
				base.Designer.DeselectTool(this);
			}
			else
			{
				OnCancelButtonClicked();
			}
		}
	}
}

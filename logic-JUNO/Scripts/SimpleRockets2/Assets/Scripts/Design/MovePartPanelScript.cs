using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Settings;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class MovePartPanelScript : DesignerSubPanelScript
	{
		private DesignerSettings _designerSettings;

		private Toggle _enableAutoResizeToggle;

		private Toggle _enableSurfaceAttachmentsToggle;

		private Toggle _enableAutoRotationToggle;

		private Toggle _enableGizmosToggle;

		private bool _refreshingPanel;

		private Toggle _showAttachPointsToggle;

		private SpinnerScript _spinnerAngleSnap;

		private SpinnerScript _spinnerGridSize;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			_designerSettings = Game.Instance.Settings.Game.Designer;
			_designerSettings.EnableAutoRotation.UpdateAndCommit(value: true);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_spinnerGridSize = base.xmlLayout.GetElementById<SpinnerScript>("spinner-grid-size");
			_spinnerAngleSnap = base.xmlLayout.GetElementById<SpinnerScript>("spinner-angle-snap");
			_enableGizmosToggle = base.xmlLayout.GetElementById<Toggle>("enable-gizmos-toggle");
			_enableAutoRotationToggle = base.xmlLayout.GetElementById<Toggle>("enable-auto-rotation");
			_enableAutoResizeToggle = base.xmlLayout.GetElementById<Toggle>("enable-auto-resize");
			_enableSurfaceAttachmentsToggle = base.xmlLayout.GetElementById<Toggle>("enable-surface-attachments");
			_showAttachPointsToggle = base.xmlLayout.GetElementById<Toggle>("show-attach-points");
		}

		public override void OnOpened()
		{
			base.OnOpened();
			RefreshPanel();
		}

		private void OnAngleSnapChanged()
		{
			_designerSettings.AngleSnap.UpdateAndCommit(_spinnerAngleSnap.NumericValue);
		}

		private void OnEnableAutoResizeChanged()
		{
			bool isOn = _enableAutoResizeToggle.isOn;
			if (_designerSettings.EnableAutoResize.Value != isOn)
			{
				_designerSettings.EnableAutoResize.UpdateAndCommit(isOn);
				if (!_refreshingPanel)
				{
					ReselectPart();
				}
			}
		}

		private void OnEnableSurfaceAttachmentsChanged()
		{
			bool isOn = _enableSurfaceAttachmentsToggle.isOn;
			if (_designerSettings.EnableSurfaceAttachments.Value != isOn)
			{
				_designerSettings.EnableSurfaceAttachments.UpdateAndCommit(isOn);
				if (!_refreshingPanel)
				{
					ReselectPart();
				}
			}
		}

		private void OnEnableAutoRotationChanged()
		{
			_designerSettings.EnableAutoRotation.UpdateAndCommit(_enableAutoRotationToggle.isOn);
		}

		private void OnEnableGizmosChanged()
		{
			bool isOn = _enableGizmosToggle.isOn;
			if (_designerSettings.EnableGizmos.Value != isOn)
			{
				_designerSettings.EnableGizmos.UpdateAndCommit(isOn);
				if (!_refreshingPanel)
				{
					ReselectPart();
				}
			}
		}

		private void OnGridSizeChanged()
		{
			_designerSettings.GridSize.UpdateAndCommit(_spinnerGridSize.NumericValue);
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.IsOpen)
			{
				RefreshPanel();
			}
		}

		private void OnShowAttachPointsChanged()
		{
			_designerSettings.ShowAttachPoints.UpdateAndCommit(_showAttachPointsToggle.isOn);
		}

		private void RefreshPanel()
		{
			try
			{
				_refreshingPanel = true;
				_spinnerGridSize.SetNumericValue(_designerSettings.GridSize);
				_spinnerAngleSnap.SetNumericValue(_designerSettings.AngleSnap);
				_enableGizmosToggle.isOn = _designerSettings.EnableGizmos;
				_enableAutoRotationToggle.isOn = _designerSettings.EnableAutoRotation;
				_enableAutoResizeToggle.isOn = _designerSettings.EnableAutoResize;
				_enableSurfaceAttachmentsToggle.isOn = _designerSettings.EnableSurfaceAttachments;
				_showAttachPointsToggle.isOn = _designerSettings.ShowAttachPoints;
			}
			finally
			{
				_refreshingPanel = false;
			}
		}

		private void ReselectPart()
		{
			IPartScript selectedPart = base.DesignerUi.Designer.SelectedPart;
			base.DesignerUi.Designer.SelectPart(selectedPart, null, justAdded: false);
		}
	}
}

using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class SymmetryPanelScript : DesignerPanelScript
	{
		private Bounds _craftBounds;

		private Transform _mirrorPlane;

		private NumericSpinnerControl _mirrorPlaneSpinner;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			base.Designer.CraftLoaded += OnCraftLoaded;
			Widget widget = base.Widget.FindWidget("mirror-plane-spinner");
			_mirrorPlaneSpinner = new NumericSpinnerControl(widget);
			_mirrorPlaneSpinner.Value = 0f;
			_mirrorPlaneSpinner.MinValue = -1000f;
			_mirrorPlaneSpinner.MaxValue = 1000f;
			_mirrorPlaneSpinner.StepSize = 0.1f;
			_mirrorPlaneSpinner.NumericFormat = "0.####";
			_mirrorPlaneSpinner.OnValueChanged = delegate(float _, float x)
			{
				base.Designer.Aircraft.Aircraft.MirrorPlaneOffset = x;
				base.Designer.UpdateSymmetryConfig();
				UpdateMirrorPlanePosition();
			};
			_mirrorPlane = base.Designer.DesignerScript.transform.Find("MirrorPlane");
			_mirrorPlane.gameObject.SetActive(value: false);
		}

		private void OnCraftLoaded()
		{
			if (base.Flyout.IsOpen)
			{
				RefreshPanel();
			}
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			_mirrorPlane.gameObject.SetActive(value: false);
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			RefreshPanel();
		}

		private void RefreshPanel()
		{
			_mirrorPlaneSpinner.Value = (base.Designer?.Aircraft?.Aircraft?.MirrorPlaneOffset).GetValueOrDefault();
			UpdateMirrorPlaneBounds();
			UpdateMirrorPlanePosition();
			_mirrorPlane.gameObject.SetActive(value: true);
		}

		private void UpdateMirrorPlaneBounds()
		{
			_craftBounds = base.Designer.Aircraft.CalculateBounds(includeDisconnectedParts: true);
			Vector3 size = _craftBounds.size;
			Vector3 localScale = new Vector3(_mirrorPlane.localScale.x, size.y + 1f, size.z + 1f);
			_mirrorPlane.localScale = localScale;
		}

		private void UpdateMirrorPlanePosition()
		{
			float valueOrDefault = (base.Designer?.Aircraft?.Aircraft?.MirrorPlaneOffset).GetValueOrDefault();
			Vector3 vector = base.Designer?.Aircraft?.MainCockpit?.transform.position ?? Vector3.zero;
			Vector3 center = _craftBounds.center;
			_mirrorPlane.position = new Vector3(vector.x + valueOrDefault, center.y, center.z);
		}
	}
}

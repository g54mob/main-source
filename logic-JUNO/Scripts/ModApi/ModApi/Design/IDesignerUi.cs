using ModApi.Craft.Parts;
using ModApi.Ui;
using UnityEngine;

namespace ModApi.Design
{
	public interface IDesignerUi
	{
		IDesigner Designer { get; }

		IFingerTool FingerTool { get; }

		IFlyouts Flyouts { get; }

		IFlyout SelectedFlyout { get; set; }

		RectTransform Transform { get; }

		event FlyoutDelegate SelectedFlyoutChanged;

		void CloseFlyout(IFlyout flyout);

		void EditFlightProgram(PartData part);

		void SetMainPanelVisibility(bool visible);

		void ShowMessage(string message, float time = 7f);

		void ShowValidationPanel();

		void ToggleFlyout(IFlyout flyout);
	}
}

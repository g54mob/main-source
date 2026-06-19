using UnityEngine;

namespace TH20
{
	public interface ICursorSelectable
	{
		bool IsSelectable();

		void ToggleDebugInfo();

		bool HasTooltip();

		bool CanHighlight();

		Renderer GetHighlightGameObject();

		Vector3 GetMenuAnchorPosition();

		GameObject GetCameraTrackObject();

		bool CanDragHoldSelect();

		void SetActiveMenu(InWorldMenuObject menu);

		InWorldMenuObject GetActiveMenu();
	}
}

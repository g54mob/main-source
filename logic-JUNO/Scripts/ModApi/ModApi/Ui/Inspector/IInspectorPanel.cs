using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public interface IInspectorPanel
	{
		bool IsPinned { get; set; }

		InspectorModel Model { get; }

		Vector2 Position { get; set; }

		float ScrollOffset { get; set; }

		RectTransform Transform { get; }

		bool Visible { get; set; }

		event InspectorPanelDelegate CloseButtonClicked;

		event InspectorPanelDelegate Closed;

		event InspectorPanelDelegate Pinned;

		event InspectorPanelDelegate Unpinned;

		void Close();

		InspectorPanelCreationInfo.InspectorPanelRestoreState GenerateRestoreState();

		void RebuildModelElements();

		void ReplaceGroup(GroupModel originalGroup, GroupModel newGroup);
	}
}

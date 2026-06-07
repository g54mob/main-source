using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class InspectorPanelCreationInfo
	{
		public enum InspectorStartPosition
		{
			UpperLeft = 0,
			UpperRight = 1,
			Center = 2
		}

		public class InspectorPanelRestoreState
		{
			public Vector2? Position { get; set; }

			public float ScrollOffset { get; set; }
		}

		public bool AllowVerticalScrolling => PanelMaxHeight > 0f;

		public bool CanClose { get; set; }

		public bool CanPin { get; set; }

		public float PanelMaxHeight { get; set; } = 0.5f;

		public int PanelWidth { get; set; }

		public bool Resizable { get; set; }

		public InspectorPanelRestoreState RestoreState { get; private set; }

		public Vector2 StartOffset { get; set; }

		public InspectorStartPosition StartPosition { get; set; }

		public InspectorPanelCreationInfo(InspectorPanelRestoreState restoreState = null)
		{
			CanClose = true;
			CanPin = true;
			StartPosition = InspectorStartPosition.UpperLeft;
			StartOffset = Vector2.zero;
			PanelWidth = 250;
			RestoreState = restoreState;
		}
	}
}

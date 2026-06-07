using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleRightPanels : RComponent
	{
		[Header("References")]
		[SerializeField]
		private RectTransform _topPanel;

		[SerializeField]
		private RectTransform _bottomPanel;

		private Vector4 _originalTopPanelAnchors;

		private Vector4 _collapsedTopPanelAnchors;

		private Vector4 _expandedTopPanelAnchors;

		private Vector4 _originalBottomPanelAnchors;

		private Vector4 _collapsedBottomPanelAnchors;

		private Vector4 _expandedBottomPanelAnchors;

		private Ref<CommandConsoleRightPanelsExpandState> State { get; }

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		private void SetState(CommandConsoleRightPanelsExpandState state)
		{
		}

		public void ClickedExpandTop()
		{
		}

		public void ClickedExpandBottom()
		{
		}
	}
}

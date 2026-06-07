using System;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class DecorationToolbar3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Button3DUIView _pickUpButton;

		[SerializeField]
		private Button3DUIView _undoButton;

		[SerializeField]
		private Button3DUIView _redoButton;

		[SerializeField]
		private Button3DUIView _defaultGizmoModeButton;

		[SerializeField]
		private Button3DUIView _scaleGizmoModeButton;

		[SerializeField]
		private GameObject _snapPivotGo;

		[SerializeField]
		private GameObject _centerPivotGo;

		[SerializeField]
		private Button3DUIView _pivotToggleButton;

		[SerializeField]
		private GameObject _localSpaceGo;

		[SerializeField]
		private GameObject _worldSpaceGo;

		[SerializeField]
		private Button3DUIView _handleModeButton;

		[SerializeField]
		private Button3DUIView _rotationSnappingButton;

		[SerializeField]
		private Button3DUIView _swatchButton;

		[SerializeField]
		private Button3DUIView _hierachyButton;

		[SerializeField]
		private Button3DUIView _contextMenuButton;

		[SerializeField]
		private TextMeshProI18n _headerLabel;

		private EditingGizmo.EditingMode _editingMode;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnBuildMenuClosed(object sender, EventArgs eventArgs)
		{
		}

		public void Init()
		{
		}

		private void OnHierarchyStateChanged(object sender, EventArgs e)
		{
		}

		private void DecorationBuilder_HandleSpaceModeChanged(object sender, ValueChangedEventArgs<bool> e)
		{
		}

		private void DecorationBuilder_SnapPivotModeChanged(object sender, ValueChangedEventArgs<bool> e)
		{
		}

		private void ToggleGizmoMode()
		{
		}

		private void SetGizmoMode(EditingGizmo.EditingMode mode)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void ApplyCurrentState()
		{
		}

		public void ResetToolbar()
		{
		}
	}
}

using System.Collections.Generic;
using Restory.Infrastructure.CommonServices;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class MenuCursorView : SerializedMonoBehaviour
	{
		[Header("General settings")]
		[SerializeField]
		private bool showCursor = true;

		[SerializeField]
		private MenuCursorDetector cursorDetector;

		[OdinSerialize]
		private Dictionary<GUICursorState, Texture2D> stateTextures = new Dictionary<GUICursorState, Texture2D>();

		[SerializeField]
		private Texture2D defaultCursor;

		[SerializeField]
		private Texture2D overInteractiveButtonCursor;

		private ControlsManager controlsManager;

		private VirtualCursorView virtualCursor;

		public bool ShowCursor => showCursor;

		[Inject]
		private void Construct(ControlsManager controlsManager, VirtualCursorView virtualCursor)
		{
			this.controlsManager = controlsManager;
			this.virtualCursor = virtualCursor;
			if (base.isActiveAndEnabled)
			{
				this.controlsManager.OnControlsTypeChanged += OnControlsTypeChanged;
				OnControlsTypeChanged(this.controlsManager.ControlType);
				UpdateView();
			}
		}

		private void OnEnable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged += OnControlsTypeChanged;
				OnControlsTypeChanged(controlsManager.ControlType);
			}
			cursorDetector.OnObjectChanged.AddListener(UpdateView);
			UpdateView();
		}

		private void OnDisable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged -= OnControlsTypeChanged;
			}
			cursorDetector.OnObjectChanged.RemoveListener(UpdateView);
		}

		private void Show(bool value)
		{
			if (showCursor != value)
			{
				showCursor = value;
				UpdateView();
			}
		}

		private void UpdateView()
		{
			if (!(virtualCursor == null))
			{
				UpdateCursorVisible();
				if (showCursor)
				{
					UpdateCursorIcon();
				}
			}
		}

		private void UpdateCursorVisible()
		{
			virtualCursor.Locked = !showCursor;
			virtualCursor.Visible = showCursor;
		}

		private void UpdateCursorIcon()
		{
			if (ShouldCursorIconUpdate())
			{
				if ((bool)cursorDetector.CursorStateSwitcher && cursorDetector.CursorStateSwitcher.CanSwitchState)
				{
					Texture2D value;
					bool flag = stateTextures.TryGetValue(cursorDetector.CursorStateSwitcher.State, out value);
					virtualCursor.SetIcon(flag ? value : defaultCursor);
				}
				else if ((bool)cursorDetector.Selectable && cursorDetector.Selectable.interactable)
				{
					virtualCursor.SetIcon(overInteractiveButtonCursor);
				}
				else if ((bool)cursorDetector.GUISelectable && cursorDetector.GUISelectable.Interactable)
				{
					virtualCursor.SetIcon(overInteractiveButtonCursor);
				}
				else
				{
					virtualCursor.SetIcon(defaultCursor);
				}
			}
		}

		protected virtual bool ShouldCursorIconUpdate()
		{
			return true;
		}

		private void OnControlsTypeChanged(InputControlsType controlsType)
		{
			if (controlsType == InputControlsType.KeyboardAndMouse)
			{
				Show(value: true);
			}
			else
			{
				Show(value: false);
			}
		}
	}
}

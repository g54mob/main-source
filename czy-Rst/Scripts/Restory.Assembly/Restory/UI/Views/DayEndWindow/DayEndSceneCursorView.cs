using System;
using Restory.Infrastructure.CommonServices;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Restory.UI.Views.DayEndWindow
{
	public class DayEndSceneCursorView : MonoBehaviour
	{
		[SerializeField]
		private Texture2D defaultCursor;

		[FormerlySerializedAs("overInteractiveObjectCursor")]
		[SerializeField]
		private Texture2D overInteractiveTargetCursor;

		[SerializeField]
		private Texture2D stampCursor;

		private MenuCursorDetector cursorDetector;

		private VirtualCursorView cursorView;

		private DayEndSceneCursorModes currentMode;

		private float stampRotationAngle;

		public DayEndSceneCursorModes CurrentMode
		{
			get
			{
				return currentMode;
			}
			set
			{
				switch (value)
				{
				case DayEndSceneCursorModes.None:
					cursorView.Visible = false;
					break;
				case DayEndSceneCursorModes.Default:
					cursorView.Visible = true;
					cursorView.SetIcon(defaultCursor);
					break;
				case DayEndSceneCursorModes.Stamping:
					cursorView.Visible = true;
					stampRotationAngle = UnityEngine.Random.Range(-30f, 30f);
					break;
				case DayEndSceneCursorModes.AfterStamping:
					cursorView.Visible = false;
					break;
				default:
					throw new NotImplementedException();
				}
				if (value != currentMode)
				{
					currentMode = value;
					this.OnModeChanged?.Invoke();
				}
			}
		}

		public event Action OnModeChanged;

		[Inject]
		private void Construct(MenuCursorDetector cursorDetector, VirtualCursorView cursorView)
		{
			this.cursorDetector = cursorDetector;
			this.cursorView = cursorView;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)cursorView)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (cursorDetector.MonoShellExists())
			{
				cursorDetector.OnObjectChanged.RemoveListener(UpdateView);
			}
		}

		private void Init()
		{
			CurrentMode = DayEndSceneCursorModes.Default;
			UpdateView();
			cursorDetector.OnObjectChanged.AddListener(UpdateView);
		}

		public bool TryToGetStampCursorParameters(out StampCursorParameters stampCursorParameters)
		{
			stampCursorParameters = default(StampCursorParameters);
			DayEndSceneCursorModes dayEndSceneCursorModes = currentMode;
			if (dayEndSceneCursorModes != DayEndSceneCursorModes.Stamping && dayEndSceneCursorModes != DayEndSceneCursorModes.AfterStamping)
			{
				return false;
			}
			stampCursorParameters = new StampCursorParameters
			{
				StampIcon = stampCursor,
				StampPosition = cursorView.transform.position,
				StampZRotation = cursorView.GetIconRotationAngle()
			};
			return true;
		}

		private void UpdateView()
		{
			if (!cursorView.MonoShellExists())
			{
				return;
			}
			switch (currentMode)
			{
			case DayEndSceneCursorModes.None:
			case DayEndSceneCursorModes.AfterStamping:
				break;
			case DayEndSceneCursorModes.Default:
				if (((bool)cursorDetector.Selectable && cursorDetector.Selectable.interactable) || ((bool)cursorDetector.GUISelectable && cursorDetector.GUISelectable.Interactable))
				{
					cursorView.SetIcon(overInteractiveTargetCursor);
				}
				else
				{
					cursorView.SetIcon(defaultCursor);
				}
				break;
			case DayEndSceneCursorModes.Stamping:
			{
				if ((bool)cursorDetector.DetectedGameObject && cursorDetector.DetectedGameObject.TryGetComponent<GUI_DayEndWindowStampingSurface>(out var _))
				{
					cursorView.SetIcon(stampCursor, stampRotationAngle);
				}
				else if (((bool)cursorDetector.Selectable && cursorDetector.Selectable.interactable) || ((bool)cursorDetector.GUISelectable && cursorDetector.GUISelectable.Interactable))
				{
					cursorView.SetIcon(overInteractiveTargetCursor);
				}
				else
				{
					cursorView.SetIcon(defaultCursor);
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
		}
	}
}

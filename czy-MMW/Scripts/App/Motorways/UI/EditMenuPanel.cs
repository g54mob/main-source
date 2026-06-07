using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client;
using Factory;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI.EditMenu;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class EditMenuPanel : MonoBehaviour, IView, ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("EditMenuPanel");

		[Dependency]
		private MenuNavigation _navigation;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameUIScreen _gameUI;

		[Dependency]
		protected City _city;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private TilemapView _tilemapView;

		[SerializeField]
		private ButtonGroup _buttonGroup;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private EditMenuControllerWidget _editMenuControllerWidget;

		[Tooltip("How many tiles from the edge of the map will result in a camera pan.")]
		[SerializeField]
		private int _panArea = 5;

		[Tooltip("Horizontal multiplier for camera panning.")]
		[SerializeField]
		private float _horizontalOffsetScalar = 0.3f;

		[Tooltip("Vertical multiplier for camera panning.")]
		[SerializeField]
		private float _verticalOffsetScalar = 0.8f;

		private bool _cancelCloseSequence;

		private readonly List<EditMenuButton> _editMenuButtons = new List<EditMenuButton>();

		private int _maxGroupIndex = -1;

		[SerializeField]
		private float ButtonShowDelay = 0.5f;

		[SerializeField]
		private float PanelOutroTime = 0.2f;

		[SerializeField]
		private float Radius = 10f;

		[SerializeField]
		private float Offset = 10f;

		private Coroutine _rotateFlipButtonCoroutine;

		[SerializeField]
		private float _flipButtonRotationSeconds = 0.15f;

		[SerializeField]
		private Sprite _upgradeSprite;

		[SerializeField]
		private Sprite _downgradeSprite;

		public ICreativeModeEditableObject EditableObject { get; private set; }

		public bool IsOpen => base.gameObject.activeInHierarchy;

		public bool IsPlayingOpenEditMenuSequence { get; private set; }

		public bool IsPlayingCloseEditMenuSequence { get; private set; }

		public async Task OpenEditMenu(ICreativeModeEditableObject editableObject)
		{
			if (EditableObject != null && EditableObject != editableObject)
			{
				ConfirmEdit();
			}
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditMenu, _scope);
			base.transform.localScale = Vector3.one;
			_canvasGroup.alpha = 1f;
			_cancelCloseSequence = true;
			base.gameObject.SetActive(value: true);
			EditableObject = editableObject;
			if (_cameraView.playerZoomedIn)
			{
				_cameraView.FocusOnWorldPosition(EditableObject.GetWorldPosition());
			}
			else
			{
				ApplyCameraOffset();
			}
			_editMenuControllerWidget.Close();
			_gameUI.SetFocusPointActive(active: false);
			IsPlayingOpenEditMenuSequence = true;
			await PlayOpeningSequence();
			IsPlayingOpenEditMenuSequence = false;
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Controller)
			{
				InitControllerNavigation();
			}
			else if (_inputState.CurrentDeviceInputType == DeviceInputType.Remote)
			{
				InitRemoteNavigation();
			}
			EmitEditMenuOpenedEvent();
		}

		private void InitControllerNavigation()
		{
			if (Diagnostics.Verify(_inputState.CurrentDeviceInputType == DeviceInputType.Controller, "Call this method only when the input type is Controller"))
			{
				Selectable firstActiveButton = GetFirstActiveButton();
				_inputState.BlockGameInput = false;
				_editMenuControllerWidget.Open();
				_editMenuControllerWidget.TurnToFace(firstActiveButton.transform.position, animate: false);
				_navigation.SetNewFocus(firstActiveButton);
				_gameUI.SetFocusPointActive(active: false);
			}
		}

		private void InitRemoteNavigation()
		{
			if (Diagnostics.Verify(_inputState.CurrentDeviceInputType == DeviceInputType.Remote, "Call this method only when the input type is Remote"))
			{
				_gameUI.SetFocusPointActive(active: true);
				_editMenuControllerWidget.Close();
			}
		}

		private void EmitEditMenuOpenedEvent()
		{
			InputEventSource inputEventSource = InputEventSource.Any;
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Controller)
			{
				inputEventSource = InputEventSource.Generic;
			}
			else if (_inputState.CurrentDeviceInputType == DeviceInputType.Remote)
			{
				inputEventSource = InputEventSource.Remote;
			}
			if (inputEventSource != InputEventSource.Any)
			{
				InputEvent inputEvent = MotorwaysUIInputEvent.CreateGenericUIEvent(_scope, 2, inputEventSource, InputEventButtonState.JustDown, GameUIButtonType.EditMenuOpened);
				_scope.Get<PlayerActionController>().OnInputEvent((float)_scope.Get<ClockModel>().Time, inputEvent);
			}
		}

		private async Task PlayOpeningSequence()
		{
			AudioPlayer.UI?.PlaySample("UpgradeReleased", 0.5f, 0.5f);
			EditMenuButtonType editOptions = EditableObject.GetEditOptions();
			foreach (EditMenuButton editMenuButton in _editMenuButtons)
			{
				editMenuButton.gameObject.SetActive(value: false);
			}
			foreach (EditMenuButton editMenuButton2 in _editMenuButtons)
			{
				Navigation navigation = editMenuButton2.navigation;
				navigation.mode = Navigation.Mode.None;
				editMenuButton2.navigation = navigation;
				editMenuButton2.gameObject.SetActive(value: true);
				if (editMenuButton2.ButtonType == (EditMenuButtonType)0 || !editOptions.HasFlag(editMenuButton2.ButtonType))
				{
					editMenuButton2.SetButtonToState(EditMenuButton.ButtonState.Hidden);
					goto IL_0269;
				}
				bool flag = editMenuButton2.ButtonType == EditMenuButtonType.Flip;
				bool flag2;
				if (flag)
				{
					ICreativeModeEditableObject editableObject = EditableObject;
					if (editableObject is CreativeModeEditableDestination creativeModeEditableDestination)
					{
						if (creativeModeEditableDestination.IsDouble)
						{
							goto IL_0166;
						}
					}
					else if (editableObject is DraftDestination { IsDouble: not false })
					{
						goto IL_0166;
					}
					flag2 = false;
					goto IL_016e;
				}
				goto IL_0172;
				IL_016e:
				flag = flag2;
				goto IL_0172;
				IL_0172:
				int num;
				if (!flag)
				{
					if (editMenuButton2.ButtonType == EditMenuButtonType.Move)
					{
						DeviceInputType currentDeviceInputType = _inputState.CurrentDeviceInputType;
						num = ((currentDeviceInputType == DeviceInputType.Mouse || currentDeviceInputType == DeviceInputType.Touch) ? 1 : 0);
					}
					else
					{
						num = 0;
					}
				}
				else
				{
					num = 1;
				}
				bool flag3 = (byte)num != 0;
				bool flag4;
				if (!flag3)
				{
					flag2 = editMenuButton2.ButtonType == EditMenuButtonType.UpgradeDowngrade;
					if (flag2)
					{
						ICreativeModeEditableObject editableObject = EditableObject;
						if (editableObject is CreativeModeEditableDestination creativeModeEditableDestination2)
						{
							if (creativeModeEditableDestination2.IsTrainStation)
							{
								goto IL_01f1;
							}
						}
						else if (editableObject is DraftDestination { IsTrainStation: not false })
						{
							goto IL_01f1;
						}
						flag4 = false;
						goto IL_01f9;
					}
					goto IL_01fd;
				}
				goto IL_0201;
				IL_01fd:
				flag3 = flag2;
				goto IL_0201;
				IL_01f9:
				flag2 = flag4;
				goto IL_01fd;
				IL_0201:
				if (flag3)
				{
					editMenuButton2.SetButtonToState(EditMenuButton.ButtonState.Hidden);
				}
				else if (editMenuButton2.ButtonType == EditMenuButtonType.Confirm && !(EditableObject?.IsConfirmable() ?? false))
				{
					editMenuButton2.SetButtonToState(EditMenuButton.ButtonState.Disabled);
				}
				else
				{
					editMenuButton2.SetButtonToState(EditMenuButton.ButtonState.Normal);
					AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.CreativeModeEditPanelButtonAppears));
				}
				goto IL_0269;
				IL_01f1:
				flag4 = true;
				goto IL_01f9;
				IL_0269:
				RefreshView(instantly: true);
				await Task.Delay((int)(ButtonShowDelay * 100f));
				continue;
				IL_0166:
				flag2 = true;
				goto IL_016e;
			}
		}

		public void RefreshView(bool instantly = false)
		{
			foreach (EditMenuButton editMenuButton in _editMenuButtons)
			{
				if (EditableObject == null || !EditableObject.GetEditOptions().HasFlag(editMenuButton.ButtonType))
				{
					continue;
				}
				bool flag;
				switch (editMenuButton.ButtonType)
				{
				case EditMenuButtonType.Confirm:
					if (EditableObject == null || !EditableObject.IsConfirmable())
					{
						editMenuButton.SetButtonToState(EditMenuButton.ButtonState.Disabled);
					}
					else
					{
						editMenuButton.SetButtonToState(EditMenuButton.ButtonState.Normal);
					}
					break;
				case EditMenuButtonType.Flip:
				{
					if (_rotateFlipButtonCoroutine != null)
					{
						StopCoroutine(_rotateFlipButtonCoroutine);
					}
					Quaternion flipButtonRotation = GetFlipButtonRotation();
					if (instantly)
					{
						editMenuButton.transform.rotation = flipButtonRotation;
					}
					else
					{
						StartCoroutine(RotateFlipButton(editMenuButton.transform.rotation, flipButtonRotation, editMenuButton));
					}
					break;
				}
				case EditMenuButtonType.UpgradeDowngrade:
				{
					ICreativeModeEditableObject editableObject = EditableObject;
					if (editableObject is CreativeModeEditableDestination creativeModeEditableDestination)
					{
						if (creativeModeEditableDestination.IsTrainStation)
						{
							goto IL_0127;
						}
					}
					else if (editableObject is DraftDestination { IsTrainStation: not false })
					{
						goto IL_0127;
					}
					flag = false;
					goto IL_012f;
				}
				case EditMenuButtonType.Delete:
					{
						editMenuButton.SetButtonToState(EditMenuButton.ButtonState.Normal);
						break;
					}
					IL_012f:
					if (flag)
					{
						editMenuButton.SetButtonToState(EditMenuButton.ButtonState.Hidden);
						break;
					}
					editMenuButton.SetButtonToState(EditMenuButton.ButtonState.Normal);
					if ((EditableObject is DraftDestination draftDestination2 && draftDestination2.viewModel.activeBuilding.upgradeLevel == 0) || (EditableObject is CreativeModeEditableDestination creativeModeEditableDestination2 && !creativeModeEditableDestination2.view.Model.IsUpgraded))
					{
						editMenuButton.IconImage.sprite = _upgradeSprite;
					}
					else
					{
						editMenuButton.IconImage.sprite = _downgradeSprite;
					}
					break;
					IL_0127:
					flag = true;
					goto IL_012f;
				}
			}
		}

		private Quaternion GetFlipButtonRotation()
		{
			if (EditableObject != null && EditableObject.GetBuildingLayout() == BuildingLayout.BuildingToSide)
			{
				return Quaternion.Euler(0f, 0f, -90f);
			}
			return Quaternion.identity;
		}

		private IEnumerator RotateFlipButton(Quaternion startRotation, Quaternion endRotation, EditMenuButton flipButton)
		{
			float startTime = Time.time;
			if (!(startRotation == endRotation))
			{
				while (Time.time < startTime + _flipButtonRotationSeconds)
				{
					float num = (Time.time - startTime) / _flipButtonRotationSeconds;
					float t = (float)Math.Pow(num, 3.0) * (num * (6f * num - 15f) + 10f);
					flipButton.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
					yield return new WaitForSeconds(0.001f);
				}
				flipButton.transform.rotation = endRotation;
			}
		}

		private TouchButton GetFirstActiveButton()
		{
			EditMenuButtonType editMenuButtonType = (Diagnostics.Verify(EditableObject != null) ? EditableObject.GetEditOptions() : EditMenuButtonType.Decline);
			foreach (EditMenuButton editMenuButton in _editMenuButtons)
			{
				if (editMenuButton.ButtonType != 0 && editMenuButtonType.HasFlag(editMenuButton.ButtonType) && editMenuButton.gameObject.activeInHierarchy && editMenuButton.interactable)
				{
					return editMenuButton;
				}
			}
			Log.Error("No active button found in EditMenuPanel!");
			return null;
		}

		public void ShowHideEditMenu(bool show)
		{
			CloseEditMenu();
		}

		private async Task CloseEditMenu()
		{
			foreach (EditMenuButton editMenuButton in _editMenuButtons)
			{
				editMenuButton.interactable = false;
			}
			_cancelCloseSequence = false;
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _scope);
			_navigation.ReleaseUIFocus();
			IsPlayingCloseEditMenuSequence = true;
			await PlayCloseSequence();
			IsPlayingCloseEditMenuSequence = false;
			if (!_cancelCloseSequence)
			{
				base.gameObject.SetActive(value: false);
				_editMenuControllerWidget.Close();
				if (!_cameraView.playerZoomedIn)
				{
					_cameraView.SetEditMenuFocusPoint(Vector3.zero);
				}
				if (_inputState.CurrentInputTypeRequiresFocus)
				{
					_inputState.BlockGameInput = false;
					_gameUI.SetFocusPointActive(active: true);
				}
			}
		}

		private async Task PlayCloseSequence()
		{
			float timeElapsed = 0f;
			while (timeElapsed < PanelOutroTime && !_cancelCloseSequence)
			{
				timeElapsed += Time.deltaTime;
				base.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.8f, timeElapsed / PanelOutroTime);
				_canvasGroup.alpha = Mathf.Lerp(1f, 0.8f, timeElapsed / PanelOutroTime);
				await Task.Delay(1);
			}
		}

		public void DeleteButton()
		{
			if (Diagnostics.Verify(EditableObject != null, "EditableObjects shouldn't be null at time of deletion!"))
			{
				OpenGhostPreview(out var isOriginalDeleted);
				EditableObject.Delete(isOriginalDeleted);
				EditableObject = null;
				CloseEditMenu();
			}
		}

		public void ConfirmEdit()
		{
			Log.Info("Confirming edit at position {0}", base.transform.position);
			if (EditableObject != null)
			{
				if (EditableObject.IsConfirmable())
				{
					EditableObject.Confirm();
				}
				else
				{
					EditableObject.Cancel();
				}
			}
			EditableObject = null;
			CloseEditMenu();
		}

		public void CancelEdit()
		{
			if (EditableObject != null)
			{
				EditableObject.Cancel();
				EditableObject = null;
			}
			CloseEditMenu();
		}

		public void FlipButton()
		{
			OpenGhostPreview(out var isOriginalDeleted);
			EditableObject.Flip(isOriginalDeleted);
		}

		public void UpgradeDowngradeButton()
		{
			OpenGhostPreview(out var isOriginalDeleted);
			EditableObject.UpgradeOrDowngrade(isOriginalDeleted);
		}

		public void RotateButton()
		{
			OpenGhostPreview(out var isOriginalDeleted);
			EditableObject.Rotate(isOriginalDeleted);
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			UpdatePanelPosition();
			return TickResult.ContinueTicking;
		}

		private void UpdatePanelPosition()
		{
			if (EditableObject != null)
			{
				Vector2 centerForEditMenuPosition = EditableObject.GetCenterForEditMenuPosition();
				Vector2 position = _gameCamera.UICamera.WorldToScreenPoint(centerForEditMenuPosition);
				Vector2 anchoredPosition = _gameUI.NormalizePositionToScaledScreenSize(position);
				base.gameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
			}
		}

		public void SetGameobjectActive(bool isActive)
		{
		}

		public void OnCreatedInScope(IScope newScope)
		{
			_scope = newScope;
			foreach (TouchButton button in _buttonGroup.buttons)
			{
				button.Initialize(_scope);
				if (button is EditMenuButton editMenuButton)
				{
					_editMenuButtons.Add(editMenuButton);
					editMenuButton.onPointerEnter = (EditMenuButton.OnFocusPointerEnter)Delegate.Combine(editMenuButton.onPointerEnter, new EditMenuButton.OnFocusPointerEnter(OnAssetButtonPointerEnter));
					editMenuButton.onPointerExit = (EditMenuButton.OnFocusPointerExit)Delegate.Combine(editMenuButton.onPointerExit, new EditMenuButton.OnFocusPointerExit(OnAssetButtonPointerExit));
					editMenuButton.AddOnSelectedEvent(OnAssetButtonSelected);
				}
			}
			_cameraView.OnCameraZoomLevelChanged += HandleCameraZoom;
		}

		private void OnAssetButtonPointerEnter(EditMenuButton button)
		{
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Remote)
			{
				_navigation.SetNewFocus(button);
			}
		}

		private void OnAssetButtonPointerExit(EditMenuButton button)
		{
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Remote)
			{
				_navigation.ReleaseUIFocus();
			}
		}

		public void SelectButtonAtDirection(Vector2 direction)
		{
			float num = float.MaxValue;
			TouchButton touchButton = null;
			foreach (TouchButton button in _buttonGroup.buttons)
			{
				if (button.gameObject.activeInHierarchy && button.interactable)
				{
					Vector2 vector = button.transform.localPosition;
					float current2 = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
					float target = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
					float num2 = Mathf.Abs(Mathf.DeltaAngle(current2, target));
					if (num2 < num)
					{
						num = num2;
						touchButton = button;
					}
				}
			}
			if (touchButton != null)
			{
				_navigation.SetNewFocus(touchButton);
			}
		}

		private void OnAssetButtonSelected()
		{
			EditMenuButton editMenuButton = _navigation.GetCurrentFocus() as EditMenuButton;
			if (!(editMenuButton == null) && Diagnostics.Verify(_editMenuControllerWidget != null, "EditMenuControllerWidget is null, set it in the prefab."))
			{
				_editMenuControllerWidget.TurnToFace(editMenuButton.transform.position);
			}
		}

		public void MoveButton()
		{
			Log.Info("MoveButton pressed, from device with input type ", _inputState.CurrentDeviceInputType);
			if (Diagnostics.Verify(_scope != null))
			{
				InputEvent inputEvent = _inputState.CurrentDeviceInputType switch
				{
					DeviceInputType.Touch => MotorwaysUIInputEvent.CreateTouchUIEvent(_scope, 0, InputEventButtonState.JustDown, GameUIButtonType.MoveCreativeModeObject), 
					DeviceInputType.Mouse => MotorwaysUIInputEvent.CreateMouseUIEvent(_scope, InputEventMouseButtonType.LeftMouse, InputEventButtonState.JustDown, GameUIButtonType.MoveCreativeModeObject), 
					_ => MotorwaysUIInputEvent.CreateGenericUIEvent(_scope, 2, InputEventSource.Generic, InputEventButtonState.JustDown, GameUIButtonType.MoveCreativeModeObject), 
				};
				_scope.Get<PlayerActionController>().OnInputEvent((float)_scope.Get<ClockModel>().Time, inputEvent);
			}
		}

		public void LayoutButtons()
		{
			if (_buttonGroup == null || _buttonGroup.transform.childCount == 0)
			{
				return;
			}
			float num = 360f / (float)_buttonGroup.transform.childCount;
			float num2 = Offset;
			for (int i = 0; i < _buttonGroup.transform.childCount; i++)
			{
				RectTransform rectTransform = (RectTransform)_buttonGroup.transform.GetChild(i);
				if (rectTransform != null)
				{
					Vector3 vector = new Vector3(Mathf.Sin(num2 * ((float)Math.PI / 180f)), Mathf.Cos(num2 * ((float)Math.PI / 180f)), 0f);
					rectTransform.localPosition = vector * Radius;
					num2 += num;
				}
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			CleanUpColourManagement();
			if (EditableObject != null)
			{
				scope.Release(EditableObject);
				EditableObject = null;
			}
			_editMenuButtons.Clear();
			_cameraView.OnCameraZoomLevelChanged -= HandleCameraZoom;
		}

		private ICreativeModeEditableObject OpenGhostPreview(out bool isOriginalDeleted)
		{
			EditableObject = EditableObject.GetGhostPreview(out isOriginalDeleted);
			return EditableObject;
		}

		public void ColourButton()
		{
			OpenGhostPreview(out var isOriginalDeleted);
			int nextGroupIndex = GetNextGroupIndex();
			Log.Info("CreativeModeEditableDestination: changed {0} to {1}", EditableObject.GetGroupIndex(), nextGroupIndex);
			EditableObject.SetGroupIndex(nextGroupIndex, isOriginalDeleted);
		}

		private int GetMaxGroupIndices()
		{
			return _scope.Get<City>().Definition.schedulePlanner.demandOscillationData.Count;
		}

		private void HandleCameraZoom()
		{
			if (!IsOpen)
			{
				return;
			}
			if (EditableObject != null)
			{
				if (EditableObject.IsConfirmable())
				{
					EditableObject.Confirm();
				}
				else
				{
					EditableObject.Cancel();
				}
			}
			EditableObject = null;
			CloseEditMenu();
		}

		private void ApplyCameraOffset()
		{
			RectFixed clientPlayableAreaAtTime = _city.GetClientPlayableAreaAtTime(Fix64.MaxValue);
			Vector2Int tilePosition = EditableObject.GetTilePosition();
			int num = Mathf.Abs(tilePosition.x);
			int num2 = Mathf.Abs(tilePosition.y);
			float num3 = Mathf.Abs((float)clientPlayableAreaAtTime.x / 2f);
			float num4 = Mathf.Abs((float)clientPlayableAreaAtTime.y / 2f);
			if ((float)num > num3 - (float)_panArea || (float)num2 > num4 - (float)_panArea)
			{
				Vector2Fixed worldPositionForCoordinates = TilemapModel.GetWorldPositionForCoordinates(tilePosition);
				Vector3 editMenuFocusPoint = new Vector3(Mathf.RoundToInt((float)worldPositionForCoordinates.x * _horizontalOffsetScalar), Mathf.RoundToInt((float)worldPositionForCoordinates.y * _verticalOffsetScalar));
				_cameraView.SetEditMenuFocusPoint(editMenuFocusPoint);
			}
		}

		private int GetNextGroupIndex()
		{
			if (_maxGroupIndex < 0)
			{
				_maxGroupIndex = GetMaxGroupIndices();
				if (_maxGroupIndex <= 0)
				{
					return EditableObject.GetGroupIndex();
				}
			}
			return (EditableObject.GetGroupIndex() + 1) % _maxGroupIndex;
		}

		private void CleanUpColourManagement()
		{
			_maxGroupIndex = -1;
		}
	}
}

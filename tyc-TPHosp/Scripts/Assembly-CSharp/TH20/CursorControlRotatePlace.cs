using System;
using UnityEngine;

namespace TH20
{
	public class CursorControlRotatePlace : MustCallDestroy
	{
		private const int MacMouseRotationBoost = 20;

		private const int OtherPlatformRotationBoost = 2;

		private bool _mouseWasHeld;

		private bool _startedRotating;

		private bool _waitingForMouseUp = true;

		private bool _roomCopyMode;

		private Vector2 _cursorStart;

		private float _rotationLastUpdate;

		private CursorManager _cursorManager;

		private const string RotateObject_Small_AudioEvent = "RotateObject:Small";

		private const string RotateObject_Medium_AudioEvent = "RotateObject:Medium";

		private const string RotateObject_Large_AudioEvent = "RotateObject:Large";

		public bool Place { get; private set; }

		public bool Cancel { get; private set; }

		public bool Rotating { get; private set; }

		public float Rotation { get; set; }

		public float SnapRotation { get; private set; }

		public bool RoomCopyMode
		{
			get
			{
				return _roomCopyMode;
			}
			set
			{
				_roomCopyMode = value;
			}
		}

		public CursorControlRotatePlace(float rotation, CursorManager cursorManager)
		{
			Rotation = rotation;
			for (_cursorManager = cursorManager; Rotation < 0f; Rotation += 360f)
			{
			}
			_rotationLastUpdate = Rotation;
		}

		public void Initialise()
		{
			_waitingForMouseUp = true;
		}

		public override void Destroy()
		{
			_cursorManager.SetCursorIconVisible(visible: true);
			base.Destroy();
		}

		public void Update(InputManager inputManager, Level level, float rotationSnap, RoomItemDefinition.Size itemSize, RoomItem roomItem = null)
		{
			if (_waitingForMouseUp && !inputManager.GetMouse(MouseButton.Left) && !inputManager.GetMouseQuickOnScene(MouseButton.Left) && !inputManager.GetButtonDown(10))
			{
				_waitingForMouseUp = false;
			}
			bool flag = !inputManager.IsMouseOverGuiOrDraggingScrollbar() && !_waitingForMouseUp && inputManager.GetMouseOnScene(MouseButton.Left);
			bool flag2 = !_waitingForMouseUp && (inputManager.GetMouseQuickOnScene(MouseButton.Left) || inputManager.GetButtonDown(10));
			Place = !inputManager.IsMouseOverGuiOrDraggingScrollbar() && !_startedRotating && flag2;
			Cancel = !inputManager.IsMouseOverGuiOrDraggingScrollbar() && inputManager.GetMouseQuickOnScene(MouseButton.Right) && !flag && !_roomCopyMode;
			if (flag && !Place)
			{
				if (!_mouseWasHeld)
				{
					_mouseWasHeld = true;
					_cursorStart = inputManager.GetCursorPos();
					_cursorManager.SetCursorIconVisible(visible: false);
				}
				if (!level.UserPreferences.Control.MouseDirectionItemRotation)
				{
					float num = _cursorStart.x - inputManager.GetCursorPos().x;
					if (Mathf.Abs(num) > level.UserPreferences.Control.MouseRotateSensitivity)
					{
						inputManager.Flush();
						_startedRotating = true;
						Rotation += num / level.UserPreferences.Control.MouseRotateSensitivity * 2f;
						inputManager.SetCursorPos(_cursorStart);
					}
				}
				else
				{
					Vector2 to = inputManager.GetCursorPos() - _cursorStart;
					if (to.magnitude > level.UserPreferences.Control.MouseRotateSensitivity)
					{
						float num2 = Vector2.SignedAngle(new Vector2(0f, -1f), to);
						Rotation = num2 + Camera.main.transform.rotation.eulerAngles.y;
						if (roomItem != null)
						{
							Rotation += roomItem.Definition.DefaultRotation;
						}
						inputManager.Flush();
						_startedRotating = true;
					}
					if (to.magnitude > 64f)
					{
						inputManager.SetCursorPos(_cursorStart + to.normalized * 64f);
					}
				}
				Rotating = _startedRotating;
			}
			else
			{
				Rotating = false;
				if (rotationSnap <= 1f)
				{
					float num3 = GameAlgorithms.Config.CursorItemRotateWithKeysDelta * GameTime.unscaledDeltaTime;
					if (inputManager.GetButton(16))
					{
						Rotating = true;
						Rotation += num3;
					}
					if (inputManager.GetButton(17))
					{
						Rotating = true;
						Rotation -= num3;
					}
				}
				else
				{
					if (inputManager.GetButtonDown(16))
					{
						Rotating = true;
						Rotation += rotationSnap;
					}
					if (inputManager.GetButtonDown(17))
					{
						Rotating = true;
						Rotation -= rotationSnap;
					}
				}
				if (_mouseWasHeld)
				{
					_mouseWasHeld = false;
					inputManager.SetCursorPos(_cursorStart);
					_cursorManager.SetCursorIconVisible(visible: true);
				}
			}
			if (_startedRotating && !inputManager.GetMouse(MouseButton.Left) && !inputManager.GetMouseDown(MouseButton.Left))
			{
				Rotating = true;
				_startedRotating = false;
				inputManager.SetCursorPos(_cursorStart);
				_cursorManager.SetCursorIconVisible(visible: true);
			}
			float num4 = Mathf.Sign(Rotation);
			float num5 = Mathf.Abs(Rotation);
			SnapRotation = (float)(int)((num5 + rotationSnap * 0.5f) / rotationSnap) * rotationSnap;
			SnapRotation *= num4;
			if (!Rotating)
			{
				Rotation = SnapRotation;
			}
			if (!MathUtils.Approximately(SnapRotation, _rotationLastUpdate, 0.1f) && rotationSnap >= 45f && roomItem != null)
			{
				bool placeOnWall = roomItem.Definition.PlaceOnWall;
				bool flag3 = roomItem.Definition.WallMagnetism && level.UserPreferences.Control.UseWallMagnetism;
				if (!placeOnWall && !flag3)
				{
					PlayRotateObjectEffect(itemSize);
					level.BuildEvents.OnRoomItemRotated.InvokeSafe(roomItem);
				}
			}
			_rotationLastUpdate = SnapRotation;
		}

		private void PlayRotateObjectEffect(RoomItemDefinition.Size itemSize)
		{
			string audioEventName = itemSize switch
			{
				RoomItemDefinition.Size.Small => "RotateObject:Small", 
				RoomItemDefinition.Size.Medium => "RotateObject:Medium", 
				RoomItemDefinition.Size.Large => "RotateObject:Large", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			AudioManager.Instance.Play(audioEventName);
		}
	}
}

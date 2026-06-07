using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("Rewired/Player Mouse")]
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}

		[SerializeField]
		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		[CustomObfuscation(rename = false)]
		private bool _defaultToCenter = true;

		[SerializeField]
		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		[CustomObfuscation(rename = false)]
		private float _pointerSpeed = 1f;

		[SerializeField]
		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		[CustomObfuscation(rename = false)]
		private bool _useHardwarePointerPosition = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, movement will be clamped to the Movement Area.")]
		private bool _clampToMovementArea = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[CustomObfuscation(rename = false)]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[SerializeField]
		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		[CustomObfuscation(rename = false)]
		private ScreenPositionChangedHandler _onScreenPositionChanged = new ScreenPositionChangedHandler();

		private Rewired.PlayerMouse yGdZHAmdUeDYveLTSINOCvUHtMoHA => base.source as Rewired.PlayerMouse;

		public bool defaultToCenter
		{
			get
			{
				if (!base.initialized)
				{
					return _defaultToCenter;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.defaultToCenter;
			}
			set
			{
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA == null)
				{
					_defaultToCenter = value;
					return;
				}
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.defaultToCenter = value;
				_defaultToCenter = yGdZHAmdUeDYveLTSINOCvUHtMoHA.defaultToCenter;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				if (!base.initialized)
				{
					return _clampToMovementArea;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.clampToMovementArea;
			}
			set
			{
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA == null)
				{
					_clampToMovementArea = value;
					return;
				}
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.clampToMovementArea = value;
				_clampToMovementArea = yGdZHAmdUeDYveLTSINOCvUHtMoHA.clampToMovementArea;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (!base.initialized)
				{
					return new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea;
			}
			set
			{
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA == null)
				{
					_movementArea = new Rect(value.xMin, value.yMin, value.width, value.height);
					return;
				}
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea = value;
				_movementArea = new Rect(yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea.xMin, yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea.yMin, yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea.width, yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementArea.height);
			}
		}

		public Rewired.PlayerMouse.MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (!base.initialized)
				{
					return _movementAreaUnit;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementAreaUnit;
			}
			set
			{
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA == null)
				{
					_movementAreaUnit = value;
					return;
				}
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementAreaUnit = value;
				_movementAreaUnit = yGdZHAmdUeDYveLTSINOCvUHtMoHA.movementAreaUnit;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.screenPosition;
			}
			set
			{
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA != null)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.screenPosition = value;
				}
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.screenPositionPrev;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.screenPositionDelta;
			}
		}

		public Rewired.PlayerController.MouseAxis xAxis
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.xAxis;
			}
		}

		public Rewired.PlayerController.MouseAxis yAxis
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.yAxis;
			}
		}

		public Rewired.PlayerController.MouseWheel wheel
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.wheel;
			}
		}

		public Rewired.PlayerController.Button leftButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.leftButton;
			}
		}

		public Rewired.PlayerController.Button rightButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.rightButton;
			}
		}

		public Rewired.PlayerController.Button middleButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.middleButton;
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (!base.initialized)
				{
					return _pointerSpeed;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.pointerSpeed;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				_pointerSpeed = value;
				if (base.initialized)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.pointerSpeed = value;
					_pointerSpeed = yGdZHAmdUeDYveLTSINOCvUHtMoHA.pointerSpeed;
				}
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (!base.initialized)
				{
					return _useHardwarePointerPosition;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.useHardwarePointerPosition;
			}
			set
			{
				_useHardwarePointerPosition = value;
				if (base.initialized)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.useHardwarePointerPosition = value;
				}
			}
		}

		bool IMouseInputSource.enabled
		{
			get
			{
				if (!base.initialized)
				{
					return false;
				}
				return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).enabled;
			}
		}

		Vector2 IMouseInputSource.screenPosition
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).screenPosition;
			}
		}

		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).screenPositionDelta;
			}
		}

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).wheelDelta;
			}
		}

		bool IMouseInputSource.locked
		{
			get
			{
				if (!base.initialized)
				{
					return false;
				}
				return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).locked;
			}
		}

		bool IPlayerController.enabled
		{
			get
			{
				return base.enabled;
			}
			set
			{
				base.enabled = value;
			}
		}

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (base.initialized)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.ScreenPositionChangedEvent += value;
				}
			}
			remove
			{
				if (base.initialized)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.ScreenPositionChangedEvent -= value;
				}
			}
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			defaultToCenter = _defaultToCenter;
			clampToMovementArea = _clampToMovementArea;
			movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
			movementAreaUnit = _movementAreaUnit;
			pointerSpeed = _pointerSpeed;
			useHardwarePointerPosition = _useHardwarePointerPosition;
		}

		protected override void OnReset()
		{
			base.OnReset();
			_clampToMovementArea = true;
			_defaultToCenter = true;
			_pointerSpeed = 1f;
			_useHardwarePointerPosition = true;
			_movementArea = new Rect(0f, 0f, 1f, 1f);
			_movementAreaUnit = Rewired.PlayerMouse.MovementAreaUnit.Screen;
			_onScreenPositionChanged = new ScreenPositionChangedHandler();
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			IList<ElementInfo> list = args as IList<ElementInfo>;
			if (list == null || list.Count == 0)
			{
				Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
				list = KNoWOpeWgdlxCnBGGhQMtQLkTkVM();
			}
			List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
			foreach (ElementInfo item in list)
			{
				list2.Add(item.ToDefinition());
			}
			return Rewired.PlayerMouse.Factory.Create(new Rewired.PlayerMouse.Definition
			{
				playerId = base.playerId,
				elements = list2,
				defaultToCenter = _defaultToCenter,
				clampToMovementArea = _clampToMovementArea,
				movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height),
				movementAreaUnit = _movementAreaUnit,
				pointerSpeed = _pointerSpeed,
				useHardwarePointerPosition = _useHardwarePointerPosition
			});
		}

		protected override void Deinitialize()
		{
			base.Deinitialize();
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			if (yGdZHAmdUeDYveLTSINOCvUHtMoHA != null)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.ScreenPositionChangedEvent += TMJsPWyfwxDkdGHuOryyBJvhmWNI;
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (yGdZHAmdUeDYveLTSINOCvUHtMoHA != null)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.ScreenPositionChangedEvent -= TMJsPWyfwxDkdGHuOryyBJvhmWNI;
			}
		}

		internal override List<ElementInfo> KNoWOpeWgdlxCnBGGhQMtQLkTkVM()
		{
			List<ElementInfo> list = new List<ElementInfo>();
			list.Add(new ElementInfo
			{
				name = "Movement",
				elementType = Rewired.PlayerController.Element.Type.MouseAxis2D,
				elements = new ElementWithSourceInfo[2]
				{
					new ElementWithSourceInfo
					{
						name = "Horizontal",
						elementType = Rewired.PlayerController.Element.TypeWithSource.MouseAxis,
						coordinateMode = AxisCoordinateMode.Relative,
						absoluteSourceSensitivity = 600f
					},
					new ElementWithSourceInfo
					{
						name = "Vertical",
						elementType = Rewired.PlayerController.Element.TypeWithSource.MouseAxis,
						coordinateMode = AxisCoordinateMode.Relative,
						absoluteSourceSensitivity = 600f
					}
				}
			});
			list.Add(new ElementInfo
			{
				name = "Wheel",
				elementType = Rewired.PlayerController.Element.Type.MouseWheel,
				elements = new ElementWithSourceInfo[2]
				{
					new ElementWithSourceInfo
					{
						name = "Wheel Horizontal",
						elementType = Rewired.PlayerController.Element.TypeWithSource.MouseWheelAxis,
						coordinateMode = AxisCoordinateMode.Relative
					},
					new ElementWithSourceInfo
					{
						name = "Wheel Vertical",
						elementType = Rewired.PlayerController.Element.TypeWithSource.MouseWheelAxis,
						coordinateMode = AxisCoordinateMode.Relative
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Left Button",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Right Button",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			list.Add(new ElementInfo
			{
				elements = new ElementWithSourceInfo[1]
				{
					new ElementWithSourceInfo
					{
						name = "Middle Button",
						elementType = Rewired.PlayerController.Element.TypeWithSource.Button
					}
				}
			});
			return list;
		}

		private void TMJsPWyfwxDkdGHuOryyBJvhmWNI(Vector2 P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(this))
			{
				return;
			}
			try
			{
				if (_onScreenPositionChanged != null)
				{
					_onScreenPositionChanged.Invoke(P_0);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).GetButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).GetButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)yGdZHAmdUeDYveLTSINOCvUHtMoHA).GetButton(button);
		}
	}
}

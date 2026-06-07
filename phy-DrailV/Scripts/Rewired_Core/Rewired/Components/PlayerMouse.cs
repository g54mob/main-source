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
	[AddComponentMenu("Rewired/Player Controllers/Player Mouse")]
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		private bool _defaultToCenter = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		private float _pointerSpeed = 1f;

		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useHardwarePointerPosition = true;

		[SerializeField]
		[Tooltip("If enabled, movement will be clamped to the Movement Area.")]
		[CustomObfuscation(rename = false)]
		private bool _clampToMovementArea = true;

		[SerializeField]
		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		[CustomObfuscation(rename = false)]
		private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[CustomObfuscation(rename = false)]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[CustomObfuscation(rename = false)]
		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		[SerializeField]
		private ScreenPositionChangedHandler _onScreenPositionChanged = new ScreenPositionChangedHandler();

		private Rewired.PlayerMouse HXvQzPApsqliDaJnhjuqaWlQGmel => base.source as Rewired.PlayerMouse;

		public bool defaultToCenter
		{
			get
			{
				if (!base.initialized)
				{
					return _defaultToCenter;
				}
				return HXvQzPApsqliDaJnhjuqaWlQGmel.defaultToCenter;
			}
			set
			{
				if (HXvQzPApsqliDaJnhjuqaWlQGmel == null)
				{
					_defaultToCenter = value;
					return;
				}
				HXvQzPApsqliDaJnhjuqaWlQGmel.defaultToCenter = value;
				_defaultToCenter = HXvQzPApsqliDaJnhjuqaWlQGmel.defaultToCenter;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.clampToMovementArea;
			}
			set
			{
				if (HXvQzPApsqliDaJnhjuqaWlQGmel == null)
				{
					_clampToMovementArea = value;
					return;
				}
				HXvQzPApsqliDaJnhjuqaWlQGmel.clampToMovementArea = value;
				_clampToMovementArea = HXvQzPApsqliDaJnhjuqaWlQGmel.clampToMovementArea;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea;
			}
			set
			{
				if (HXvQzPApsqliDaJnhjuqaWlQGmel == null)
				{
					_movementArea = new Rect(value.xMin, value.yMin, value.width, value.height);
					return;
				}
				HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea = value;
				_movementArea = new Rect(HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea.xMin, HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea.yMin, HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea.width, HXvQzPApsqliDaJnhjuqaWlQGmel.movementArea.height);
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.movementAreaUnit;
			}
			set
			{
				if (HXvQzPApsqliDaJnhjuqaWlQGmel == null)
				{
					_movementAreaUnit = value;
					return;
				}
				HXvQzPApsqliDaJnhjuqaWlQGmel.movementAreaUnit = value;
				_movementAreaUnit = HXvQzPApsqliDaJnhjuqaWlQGmel.movementAreaUnit;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.screenPosition;
			}
			set
			{
				if (HXvQzPApsqliDaJnhjuqaWlQGmel != null)
				{
					HXvQzPApsqliDaJnhjuqaWlQGmel.screenPosition = value;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.screenPositionPrev;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.screenPositionDelta;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.xAxis;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.yAxis;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.wheel;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.leftButton;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.rightButton;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.middleButton;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.pointerSpeed;
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
					HXvQzPApsqliDaJnhjuqaWlQGmel.pointerSpeed = value;
					_pointerSpeed = HXvQzPApsqliDaJnhjuqaWlQGmel.pointerSpeed;
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
				return HXvQzPApsqliDaJnhjuqaWlQGmel.useHardwarePointerPosition;
			}
			set
			{
				_useHardwarePointerPosition = value;
				if (base.initialized)
				{
					HXvQzPApsqliDaJnhjuqaWlQGmel.useHardwarePointerPosition = value;
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
				return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).enabled;
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
				return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).screenPosition;
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
				return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).screenPositionDelta;
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
				return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).wheelDelta;
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
				return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).locked;
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
					HXvQzPApsqliDaJnhjuqaWlQGmel.ScreenPositionChangedEvent += value;
				}
			}
			remove
			{
				if (base.initialized)
				{
					HXvQzPApsqliDaJnhjuqaWlQGmel.ScreenPositionChangedEvent -= value;
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
				list = driRyyGhYfItsSTwrekwkDqrsQXh();
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
			if (HXvQzPApsqliDaJnhjuqaWlQGmel != null)
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.ScreenPositionChangedEvent += kwVntVMzItugFvICjaPOWvMcigPfA;
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (HXvQzPApsqliDaJnhjuqaWlQGmel != null)
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.ScreenPositionChangedEvent -= kwVntVMzItugFvICjaPOWvMcigPfA;
			}
		}

		internal override List<ElementInfo> driRyyGhYfItsSTwrekwkDqrsQXh()
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

		private void kwVntVMzItugFvICjaPOWvMcigPfA(Vector2 P_0)
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
			return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).GetButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).GetButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)HXvQzPApsqliDaJnhjuqaWlQGmel).GetButton(button);
		}
	}
}

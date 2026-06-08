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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		private bool _defaultToCenter = true;

		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _pointerSpeed = 1f;

		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
		[CustomObfuscation(rename = false)]
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ScreenPositionChangedHandler _onScreenPositionChanged = new ScreenPositionChangedHandler();

		private new Rewired.PlayerMouse source => base.source as Rewired.PlayerMouse;

		public bool defaultToCenter
		{
			get
			{
				if (!base.initialized)
				{
					return _defaultToCenter;
				}
				return source.defaultToCenter;
			}
			set
			{
				if (source == null)
				{
					_defaultToCenter = value;
					while (true)
					{
						switch (-1659082401 ^ -1659082402)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				source.defaultToCenter = value;
				_defaultToCenter = source.defaultToCenter;
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
				return source.clampToMovementArea;
			}
			set
			{
				if (source == null)
				{
					_clampToMovementArea = value;
					return;
				}
				source.clampToMovementArea = value;
				_clampToMovementArea = source.clampToMovementArea;
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
				return source.movementArea;
			}
			set
			{
				if (source == null)
				{
					_movementArea = new Rect(value.xMin, value.yMin, value.width, value.height);
					while (true)
					{
						switch (0x76B086E ^ 0x76B086C)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				source.movementArea = value;
				_movementArea = new Rect(source.movementArea.xMin, source.movementArea.yMin, source.movementArea.width, source.movementArea.height);
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
				return source.movementAreaUnit;
			}
			set
			{
				if (source == null)
				{
					_movementAreaUnit = value;
					while (true)
					{
						switch (-226561485 ^ -226561486)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				source.movementAreaUnit = value;
				_movementAreaUnit = source.movementAreaUnit;
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
				return source.screenPosition;
			}
			set
			{
				if (source != null)
				{
					source.screenPosition = value;
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
				return source.screenPositionPrev;
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
				return source.screenPositionDelta;
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
				return source.xAxis;
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
				return source.yAxis;
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
				return source.wheel;
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
				return source.leftButton;
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
				return source.rightButton;
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
				return source.middleButton;
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
				return source.pointerSpeed;
			}
			set
			{
				if (value < 0f)
				{
					goto IL_0008;
				}
				goto IL_0038;
				IL_0008:
				int num = -1857084649;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -1857084652)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						value = 0f;
						num = -1857084652;
						continue;
					case 0:
						goto IL_0038;
					case 1:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0038:
				_pointerSpeed = value;
				if (base.initialized)
				{
					source.pointerSpeed = value;
					_pointerSpeed = source.pointerSpeed;
					num = -1857084651;
					goto IL_000d;
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
				return source.useHardwarePointerPosition;
			}
			set
			{
				_useHardwarePointerPosition = value;
				if (base.initialized)
				{
					source.useHardwarePointerPosition = value;
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
				return ((IMouseInputSource)source).enabled;
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
				return ((IMouseInputSource)source).screenPosition;
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
				return ((IMouseInputSource)source).screenPositionDelta;
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
				return ((IMouseInputSource)source).wheelDelta;
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
				return ((IMouseInputSource)source).locked;
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
				base.enabled = flag;
			}
		}

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (base.initialized)
				{
					source.ScreenPositionChangedEvent += value;
				}
			}
			remove
			{
				if (base.initialized)
				{
					source.ScreenPositionChangedEvent -= value;
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
			while (true)
			{
				int num = -763044464;
				while (true)
				{
					switch (num ^ -763044463)
					{
					case 2:
						break;
					case 1:
						goto IL_002b;
					default:
						_pointerSpeed = 1f;
						_useHardwarePointerPosition = true;
						_movementArea = new Rect(0f, 0f, 1f, 1f);
						_movementAreaUnit = Rewired.PlayerMouse.MovementAreaUnit.Screen;
						_onScreenPositionChanged = new ScreenPositionChangedHandler();
						return;
					}
					break;
					IL_002b:
					_defaultToCenter = true;
					num = -763044463;
				}
			}
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			IList<ElementInfo> list = args as IList<ElementInfo>;
			if (list == null)
			{
				goto IL_0034;
			}
			if (list.Count == 0)
			{
				goto IL_0012;
			}
			goto IL_004c;
			IL_004c:
			List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
			int num = -1269127035;
			goto IL_0017;
			IL_0012:
			num = -1269127034;
			goto IL_0017;
			IL_0017:
			switch (num ^ -1269127036)
			{
			case 0:
				break;
			case 2:
				goto IL_0034;
			case 3:
				goto IL_004c;
			default:
			{
				using (IEnumerator<ElementInfo> enumerator = list.GetEnumerator())
				{
					ElementInfo current = default(ElementInfo);
					while (true)
					{
						IL_009e:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -1269127033;
							num3 = num2;
						}
						else
						{
							num2 = -1269127034;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1269127036)
							{
							case 4:
								num2 = -1269127034;
								continue;
							default:
								goto end_IL_006e;
							case 2:
								current = enumerator.Current;
								num2 = -1269127035;
								continue;
							case 0:
								break;
							case 1:
								list2.Add(current.ToDefinition());
								num2 = -1269127036;
								continue;
							case 3:
								goto end_IL_006e;
							}
							goto IL_009e;
							continue;
							end_IL_006e:
							break;
						}
						break;
					}
				}
				Rewired.PlayerMouse.Definition definition = new Rewired.PlayerMouse.Definition();
				definition.playerId = base.playerId;
				Rewired.PlayerMouse result = default(Rewired.PlayerMouse);
				while (true)
				{
					int num4 = -1269127035;
					while (true)
					{
						switch (num4 ^ -1269127036)
						{
						case 3:
							break;
						case 1:
							definition.elements = list2;
							num4 = -1269127036;
							continue;
						case 0:
							definition.defaultToCenter = _defaultToCenter;
							definition.clampToMovementArea = _clampToMovementArea;
							definition.movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
							definition.movementAreaUnit = _movementAreaUnit;
							definition.pointerSpeed = _pointerSpeed;
							definition.useHardwarePointerPosition = _useHardwarePointerPosition;
							result = Rewired.PlayerMouse.Factory.Create(definition);
							num4 = -1269127034;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}
			}
			goto IL_0012;
			IL_0034:
			Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
			list = aBrYrGQJXebUVwGGLglKxCeODnq();
			num = -1269127033;
			goto IL_0017;
		}

		protected override void Deinitialize()
		{
			base.Deinitialize();
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			if (source != null)
			{
				source.ScreenPositionChangedEvent += xhITuvSGDkzNeDhsHaLqhRQFjBs;
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (source == null)
			{
				return;
			}
			while (true)
			{
				int num = 1754409257;
				while (true)
				{
					switch (num ^ 0x68922928)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 2:
						return;
					}
					break;
					IL_002c:
					source.ScreenPositionChangedEvent -= xhITuvSGDkzNeDhsHaLqhRQFjBs;
					num = 1754409258;
				}
			}
		}

		internal override List<ElementInfo> aBrYrGQJXebUVwGGLglKxCeODnq()
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

		private void xhITuvSGDkzNeDhsHaLqhRQFjBs(Vector2 P_0)
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

		private bool idAXnyFzJhjjeXdFKIiOKlWXSgF(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in idAXnyFzJhjjeXdFKIiOKlWXSgF
			return this.idAXnyFzJhjjeXdFKIiOKlWXSgF(P_0);
		}

		private bool DEMORJVdvLvETJClEIwJyxFMzFC(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DEMORJVdvLvETJClEIwJyxFMzFC
			return this.DEMORJVdvLvETJClEIwJyxFMzFC(P_0);
		}

		private bool hBkkdIiZEqgNhGhdvTZMjCpqpgU(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButton(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hBkkdIiZEqgNhGhdvTZMjCpqpgU
			return this.hBkkdIiZEqgNhGhdvTZMjCpqpgU(P_0);
		}
	}
}

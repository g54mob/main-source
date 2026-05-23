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
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}

		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _defaultToCenter = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		private float _pointerSpeed = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		private bool _useHardwarePointerPosition = true;

		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

		[CustomObfuscation(rename = false)]
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[SerializeField]
		private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		private ScreenPositionChangedHandler _onScreenPositionChanged = new ScreenPositionChangedHandler();

		private new Rewired.PlayerMouse source
		{
			get
			{
				return base.source as Rewired.PlayerMouse;
			}
		}

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
					while (true)
					{
						switch (0x668C3CA3 ^ 0x668C3CA1)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				source.defaultToCenter = value;
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
				if (source != null)
				{
					source.movementArea = value;
				}
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
				if (source != null)
				{
					source.movementAreaUnit = value;
				}
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
					value = 0f;
					goto IL_000f;
				}
				goto IL_002d;
				IL_002d:
				_pointerSpeed = value;
				int num;
				if (base.initialized)
				{
					source.pointerSpeed = value;
					num = -417630712;
					goto IL_0014;
				}
				return;
				IL_000f:
				num = -417630709;
				goto IL_0014;
				IL_0014:
				switch (num ^ -417630711)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002d;
				case 1:
					return;
				}
				goto IL_000f;
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
				if (!base.initialized)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 1105874146;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x41EA4CE3)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0032;
				case 3:
					return;
				}
				goto IL_0008;
				IL_0032:
				source.ScreenPositionChangedEvent += value;
				num = 1105874144;
				goto IL_000d;
			}
			remove
			{
				if (!base.initialized)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = -957508951;
				goto IL_000d;
				IL_000d:
				switch (num ^ -957508952)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0032;
				case 0:
					return;
				}
				goto IL_0008;
				IL_0032:
				source.ScreenPositionChangedEvent -= value;
				num = -957508952;
				goto IL_000d;
			}
		}

		protected override void OnValidated()
		{
			base.OnValidated();
			defaultToCenter = _defaultToCenter;
			_defaultToCenter = defaultToCenter;
			movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
			ScreenRect screenRect = default(ScreenRect);
			while (true)
			{
				int num = 189769040;
				while (true)
				{
					switch (num ^ 0xB4FA551)
					{
					case 2:
						break;
					case 1:
						screenRect = movementArea;
						num = 189769042;
						continue;
					case 4:
						pointerSpeed = _pointerSpeed;
						_pointerSpeed = pointerSpeed;
						num = 189769041;
						continue;
					case 3:
						_movementArea = new Rect(screenRect.xMin, screenRect.yMin, screenRect.width, screenRect.height);
						movementAreaUnit = _movementAreaUnit;
						_movementAreaUnit = movementAreaUnit;
						num = 189769045;
						continue;
					default:
						useHardwarePointerPosition = _useHardwarePointerPosition;
						return;
					}
					break;
				}
			}
		}

		protected override void OnReset()
		{
			base.OnReset();
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
			if (list == null)
			{
				goto IL_0030;
			}
			if (list.Count == 0)
			{
				goto IL_0012;
			}
			goto IL_0048;
			IL_0048:
			List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
			using (IEnumerator<ElementInfo> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						ElementInfo current = enumerator.Current;
						int num = 326210880;
						while (true)
						{
							switch (num ^ 0x13719541)
							{
							case 0:
								num = 326210882;
								continue;
							case 3:
								break;
							case 1:
								list2.Add(current.ToDefinition());
								num = 326210883;
								continue;
							default:
								goto end_IL_0080;
							}
							break;
						}
						continue;
						end_IL_0080:
						break;
					}
				}
			}
			Rewired.PlayerMouse.Definition definition = new Rewired.PlayerMouse.Definition();
			definition.playerId = base.playerId;
			definition.elements = list2;
			Rewired.PlayerMouse result = default(Rewired.PlayerMouse);
			while (true)
			{
				int num2 = 326210880;
				while (true)
				{
					switch (num2 ^ 0x13719541)
					{
					case 2:
						break;
					case 1:
						definition.defaultToCenter = _defaultToCenter;
						definition.movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
						definition.movementAreaUnit = _movementAreaUnit;
						definition.pointerSpeed = _pointerSpeed;
						definition.useHardwarePointerPosition = _useHardwarePointerPosition;
						num2 = 326210881;
						continue;
					case 0:
						result = Rewired.PlayerMouse.Factory.Create(definition);
						num2 = 326210882;
						continue;
					default:
						return result;
					}
					break;
				}
			}
			IL_0012:
			int num3 = 326210883;
			goto IL_0017;
			IL_0017:
			switch (num3 ^ 0x13719541)
			{
			case 0:
				break;
			case 2:
				goto IL_0030;
			default:
				goto IL_0048;
			}
			goto IL_0012;
			IL_0030:
			Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
			list = CreateDefaultElementInfos();
			num3 = 326210880;
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
				source.ScreenPositionChangedEvent += dcMYGxUbuujICKGUcqavgluIZPY;
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
				int num = 782067312;
				while (true)
				{
					switch (num ^ 0x2E9D6671)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 0:
						return;
					}
					break;
					IL_002c:
					source.ScreenPositionChangedEvent -= dcMYGxUbuujICKGUcqavgluIZPY;
					num = 782067313;
				}
			}
		}

		internal override List<ElementInfo> CreateDefaultElementInfos()
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

		private void dcMYGxUbuujICKGUcqavgluIZPY(Vector2 P_0)
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

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)source).GetButton(P_0);
		}
	}
}

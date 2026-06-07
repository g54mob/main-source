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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		private bool _defaultToCenter = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		private float _pointerSpeed = 1f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		private bool _useHardwarePointerPosition = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[CustomObfuscation(rename = false)]
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
				if (source != null)
				{
					source.defaultToCenter = value;
				}
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
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 1267628839;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x4B8E7B25)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_0032;
				case 1:
					return;
				}
				goto IL_0008;
				IL_0032:
				source.movementArea = value;
				num = 1267628836;
				goto IL_000d;
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
				if (source == null)
				{
					while (true)
					{
						switch (0x4E29C1D ^ 0x4E29C1C)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				source.screenPosition = value;
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
					num = 1635670671;
					goto IL_0014;
				}
				return;
				IL_000f:
				num = 1635670668;
				goto IL_0014;
				IL_0014:
				switch (num ^ 0x617E5A8D)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_002d;
				case 2:
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
				while (true)
				{
					int num = -760718875;
					while (true)
					{
						switch (num ^ -760718876)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (base.initialized)
							{
								goto IL_002d;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_002d:
						source.useHardwarePointerPosition = value;
						num = -760718874;
					}
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
			_defaultToCenter = defaultToCenter;
			movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
			ScreenRect screenRect = movementArea;
			_movementArea = new Rect(screenRect.xMin, screenRect.yMin, screenRect.width, screenRect.height);
			while (true)
			{
				int num = 1838217711;
				while (true)
				{
					switch (num ^ 0x6D90F9EC)
					{
					case 2:
						break;
					case 3:
						movementAreaUnit = _movementAreaUnit;
						_movementAreaUnit = movementAreaUnit;
						pointerSpeed = _pointerSpeed;
						num = 1838217708;
						continue;
					case 0:
						_pointerSpeed = pointerSpeed;
						num = 1838217709;
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
			while (true)
			{
				int num = 1246142091;
				while (true)
				{
					switch (num ^ 0x4A469E8A)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002b;
					case 2:
						return;
					}
					break;
					IL_002b:
					_pointerSpeed = 1f;
					_useHardwarePointerPosition = true;
					_movementArea = new Rect(0f, 0f, 1f, 1f);
					_movementAreaUnit = Rewired.PlayerMouse.MovementAreaUnit.Screen;
					_onScreenPositionChanged = new ScreenPositionChangedHandler();
					num = 1246142088;
				}
			}
		}

		protected override Rewired.PlayerController CreateSource(object args)
		{
			IList<ElementInfo> list = args as IList<ElementInfo>;
			if (list != null)
			{
				goto IL_000a;
			}
			goto IL_0045;
			IL_000a:
			int num = -1094745661;
			goto IL_000f;
			IL_000f:
			Rewired.PlayerMouse result = default(Rewired.PlayerMouse);
			while (true)
			{
				switch (num ^ -1094745663)
				{
				case 3:
					break;
				case 2:
					goto IL_002c;
				case 1:
					goto IL_0045;
				default:
				{
					List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
					using (IEnumerator<ElementInfo> enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								ElementInfo current = enumerator.Current;
								list2.Add(current.ToDefinition());
								int num2 = -1094745664;
								while (true)
								{
									switch (num2 ^ -1094745663)
									{
									case 0:
										num2 = -1094745661;
										continue;
									case 2:
										break;
									default:
										goto end_IL_0091;
									}
									break;
								}
								continue;
								end_IL_0091:
								break;
							}
						}
					}
					Rewired.PlayerMouse.Definition definition = new Rewired.PlayerMouse.Definition();
					definition.playerId = base.playerId;
					definition.elements = list2;
					while (true)
					{
						int num3 = -1094745661;
						while (true)
						{
							switch (num3 ^ -1094745663)
							{
							case 0:
								break;
							case 2:
								goto IL_00fd;
							default:
								return result;
							}
							break;
							IL_00fd:
							definition.defaultToCenter = _defaultToCenter;
							definition.movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
							definition.movementAreaUnit = _movementAreaUnit;
							definition.pointerSpeed = _pointerSpeed;
							definition.useHardwarePointerPosition = _useHardwarePointerPosition;
							result = Rewired.PlayerMouse.Factory.Create(definition);
							num3 = -1094745664;
						}
					}
				}
				}
				break;
				IL_002c:
				int num4;
				if (list.Count == 0)
				{
					num = -1094745664;
					num4 = num;
				}
				else
				{
					num = -1094745663;
					num4 = num;
				}
			}
			goto IL_000a;
			IL_0045:
			Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
			list = CreateDefaultElementInfos();
			num = -1094745663;
			goto IL_000f;
		}

		protected override void Deinitialize()
		{
			base.Deinitialize();
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			if (source == null)
			{
				return;
			}
			while (true)
			{
				int num = -1765675654;
				while (true)
				{
					switch (num ^ -1765675656)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002c;
					case 1:
						return;
					}
					break;
					IL_002c:
					source.ScreenPositionChangedEvent += CCDsQekcmYJlqLmUkGrJKcIYDP;
					num = -1765675655;
				}
			}
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (source != null)
			{
				source.ScreenPositionChangedEvent -= CCDsQekcmYJlqLmUkGrJKcIYDP;
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

		private void CCDsQekcmYJlqLmUkGrJKcIYDP(Vector2 P_0)
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

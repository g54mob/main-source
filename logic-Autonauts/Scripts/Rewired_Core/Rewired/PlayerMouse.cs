using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerController, IPlayerMouse, IMouseInputSource
	{
		public new sealed class Definition : PlayerController.Definition
		{
			public bool defaultToCenter = true;

			public ScreenRect movementArea = jhncZppQbSAeoriXEYNnUgpfwmF;

			public MovementAreaUnit movementAreaUnit;

			public float pointerSpeed = 1f;

			public bool useHardwarePointerPosition = true;

			internal Definition()
			{
			}
		}

		public new static class Factory
		{
			public static PlayerMouse Create()
			{
				return rHXUBQoqejbkONabpWgwEqatBJ(3, 3);
			}

			private static PlayerMouse rHXUBQoqejbkONabpWgwEqatBJ(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
					goto IL_000a;
				}
				goto IL_01e0;
				IL_01e0:
				int num;
				if (P_1 < 0)
				{
					P_1 = 0;
					num = -1428111117;
					goto IL_000f;
				}
				goto IL_00bc;
				IL_000a:
				num = -1428111111;
				goto IL_000f;
				IL_000f:
				List<Element.Definition> list = default(List<Element.Definition>);
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1428111105)
					{
					case 9:
						break;
					case 8:
						list.Add(new MouseWheel.Definition
						{
							name = "Wheel",
							xAxis = new MouseWheelAxis.Definition
							{
								name = "Wheel Horizontal"
							},
							yAxis = new MouseWheelAxis.Definition
							{
								name = "Wheel Vertical"
							}
						});
						num = -1428111110;
						continue;
					case 12:
						goto IL_00bc;
					case 5:
						num3 = 4;
						num = -1428111106;
						continue;
					case 11:
						if (P_0 >= 2)
						{
							list.Add(new Button.Definition
							{
								name = "Right Button"
							});
							num = -1428111108;
							continue;
						}
						goto case 3;
					case 3:
						if (P_0 >= 3)
						{
							list.Add(new Button.Definition
							{
								name = "Middle Button"
							});
							num = -1428111119;
							continue;
						}
						goto case 14;
					case 0:
						list.Add(new Button.Definition
						{
							name = "Left Button"
						});
						num = -1428111116;
						continue;
					case 2:
						if (num3 >= P_1)
						{
							goto IL_01ad;
						}
						goto case 15;
					case 13:
						list.Add(new Button.Definition());
						num2++;
						num = -1428111109;
						continue;
					case 6:
						goto IL_01e0;
					case 7:
						num = -1428111109;
						continue;
					case 14:
						num2 = 3;
						num = -1428111112;
						continue;
					case 1:
						num = -1428111107;
						continue;
					case 10:
						goto IL_0215;
					case 15:
						list.Add(new Axis.Definition
						{
							coordinateMode = AxisCoordinateMode.Relative
						});
						num3++;
						num = -1428111107;
						continue;
					default:
						if (num2 >= P_0)
						{
							Definition definition = new Definition();
							definition.elements = list;
							return new PlayerMouse(definition);
						}
						goto case 13;
					}
					break;
					IL_01ad:
					int num4;
					if (P_0 < 1)
					{
						num = -1428111116;
						num4 = num;
					}
					else
					{
						num = -1428111105;
						num4 = num;
					}
				}
				goto IL_000a;
				IL_0215:
				int num5;
				if (P_1 < 3)
				{
					num = -1428111110;
					num5 = num;
				}
				else
				{
					num = -1428111113;
					num5 = num;
				}
				goto IL_000f;
				IL_00bc:
				list = new List<Element.Definition>(P_0 + P_1);
				if (P_1 >= 1)
				{
					list.Add(new MouseAxis2D.Definition
					{
						name = "Movement",
						xAxis = new MouseAxis.Definition
						{
							name = "Horizontal"
						},
						yAxis = new MouseAxis.Definition
						{
							name = "Vertical"
						}
					});
					num = -1428111115;
					goto IL_000f;
				}
				goto IL_0215;
			}

			public static PlayerMouse Create(Definition definition)
			{
				return new PlayerMouse(definition);
			}
		}

		public enum MovementAreaUnit
		{
			Screen = 0,
			Pixel = 1
		}

		internal const bool wDNBRbEulRwjKAKyCrJArcGQNkqN = true;

		internal const float SKiCBziLyhJKUNKWFlaAXVNYQaEj = 1f;

		internal const bool BzTBpIktMbJmUGfyEcoSlsuVOdjE = true;

		internal const MovementAreaUnit bbZDrrDpBDQOaugtIhMxhtXYtcan = MovementAreaUnit.Screen;

		private const int SoMGReKJGmLNmrmtxrdqolueBaIO = 3;

		private const int YAnNfJvYgdwSfEzHgllbnFNKuig = 3;

		internal const string IskEztokfeKiwBTsoiUXAnbrtAn = "Movement";

		internal const string bCZrQdoLHRMotvotDcjhKdUmqpNX = "Horizontal";

		internal const string WTuWneeFdMwpYcoPZikHxXzYsTt = "Vertical";

		internal const string ODlyriUBDSDIvqhtNtXaauOOgYw = "Wheel";

		internal const string dsJAYECvqCKrkNsuXdqWzSKZLtZN = "Wheel Horizontal";

		internal const string cncaVXzAwhrswTkrpYFVLJpyPpR = "Wheel Vertical";

		internal const string fHekhfcRVEujtOjRGjZZtkgcTnF = "Left Button";

		internal const string sZmzmihLNVxaoHLedzqPJzvjcGi = "Right Button";

		internal const string QVrTiUaaOCFdpPaeaYKXScoeXzJ = "Middle Button";

		internal static readonly ScreenRect jhncZppQbSAeoriXEYNnUgpfwmF = new ScreenRect(0f, 0f, 1f, 1f);

		private readonly int fxSjBBUBHBrfyCosuertmPnvctyk = -1;

		private readonly int PRwGNcqPEdIxTPzIOeULtUFVoHQ = -1;

		private readonly int vRtqYfznDBfQqAXeANCFWRUvxTc = -1;

		private readonly int xMCazNyKqvCFtqEqLInbHNVGIIQ = -1;

		private readonly int ZvjdstNiuQBfhCGDczeogLyyghv = -1;

		private readonly int GlZXxPlkSbdZvTJJgQJigDdLIbdc = -1;

		private bool zpYIeajMHnQnHLlAakYKlJXoHQe;

		private Vector2 oQNoToqrjFsKBmbKcwwamAYicpa;

		private Vector2 pILDXIZNZMgatIJnWvZGipvXPyGT;

		private Vector2 JhNnbXRVINzwabVBedwQENWxhtD;

		private Vector2 ZcOBcRPWjZzsNPAUXgEzciyTfge;

		private Vector2 GLMqXqqjajnDfzIugKqnHmQIWcp;

		private float CndxAZQxwekvyDsNunUYDoybJGz;

		private bool NtdqzCUbgngaIAKSDiczhIjbKiNy;

		private Action<Vector2> xiNPFSTpzpYfkdLRrDYoHPinSec;

		private bool wMCSbSAHHGYdaWlmpLzmymzxqfu;

		private ScreenRect fgStsnyCRZDyVzTImBUsRUxCQYs;

		private MovementAreaUnit KGuCBclnOeJNYAImGCyDAcvZxxfe;

		[CompilerGenerated]
		private static Predicate<Axis> GyZiWpwRwosxGLUULQtnUoicfHh;

		[CompilerGenerated]
		private static Predicate<Axis> gjWpSCTHTdhtCYRkbGgvESMQzBx;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return wMCSbSAHHGYdaWlmpLzmymzxqfu;
			}
			set
			{
				wMCSbSAHHGYdaWlmpLzmymzxqfu = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return default(ScreenRect);
				}
				return fgStsnyCRZDyVzTImBUsRUxCQYs;
			}
			set
			{
				fgStsnyCRZDyVzTImBUsRUxCQYs = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 330548976;
						while (true)
						{
							switch (num ^ 0x13B3C6F1)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return MovementAreaUnit.Screen;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 330548977;
						}
					}
				}
				return KGuCBclnOeJNYAImGCyDAcvZxxfe;
			}
			set
			{
				KGuCBclnOeJNYAImGCyDAcvZxxfe = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return JhNnbXRVINzwabVBedwQENWxhtD;
			}
			set
			{
				vLsYYLvyjIbDqaHJasbfnrfpjwm(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					goto IL_000d;
				}
				int num;
				if (!base.enabled)
				{
					num = -812537919;
					goto IL_0012;
				}
				return ZcOBcRPWjZzsNPAUXgEzciyTfge;
				IL_000d:
				num = -812537918;
				goto IL_0012;
				IL_0012:
				switch (num ^ -812537920)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				default:
					return Vector2.zero;
				}
				goto IL_000d;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					goto IL_0019;
				}
				int num;
				if (!base.enabled)
				{
					num = -122641600;
					goto IL_001e;
				}
				return GLMqXqqjajnDfzIugKqnHmQIWcp;
				IL_0019:
				num = -122641599;
				goto IL_001e;
				IL_001e:
				switch (num ^ -122641600)
				{
				case 2:
					break;
				case 1:
					return Vector2.zero;
				default:
					return Vector2.zero;
				}
				goto IL_0019;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 1378300464;
						while (true)
						{
							switch (num ^ 0x52273232)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 1378300467;
						}
					}
				}
				if (PRwGNcqPEdIxTPzIOeULtUFVoHQ < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[PRwGNcqPEdIxTPzIOeULtUFVoHQ];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				if (vRtqYfznDBfQqAXeANCFWRUvxTc < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[vRtqYfznDBfQqAXeANCFWRUvxTc];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					goto IL_000d;
				}
				int num;
				if (fxSjBBUBHBrfyCosuertmPnvctyk < 0)
				{
					num = 8050606;
					goto IL_0012;
				}
				return (MouseWheel)base.elements[fxSjBBUBHBrfyCosuertmPnvctyk];
				IL_000d:
				num = 8050607;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x7AD7AE)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				default:
					return null;
				}
				goto IL_000d;
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				if (xMCazNyKqvCFtqEqLInbHNVGIIQ < 0)
				{
					return null;
				}
				return base.buttons[xMCazNyKqvCFtqEqLInbHNVGIIQ];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				if (ZvjdstNiuQBfhCGDczeogLyyghv < 0)
				{
					return null;
				}
				return base.buttons[ZvjdstNiuQBfhCGDczeogLyyghv];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				if (GlZXxPlkSbdZvTJJgQJigDdLIbdc < 0)
				{
					return null;
				}
				return base.buttons[GlZXxPlkSbdZvTJJgQJigDdLIbdc];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				}
				return CndxAZQxwekvyDsNunUYDoybJGz;
			}
			set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				}
				while (value < 0f)
				{
					value = 0f;
					int num = -1571225652;
					while (true)
					{
						switch (num ^ -1571225650)
						{
						case 0:
							num = -1571225649;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0038;
						}
						break;
					}
					continue;
					end_IL_0038:
					break;
				}
				CndxAZQxwekvyDsNunUYDoybJGz = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return NtdqzCUbgngaIAKSDiczhIjbKiNy;
			}
			set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				}
				while (true)
				{
					NtdqzCUbgngaIAKSDiczhIjbKiNy = value;
					if (value)
					{
						break;
					}
					JVEKrFRjZNsHuvMiQDxLhJnBKWH();
					int num = -1172820036;
					while (true)
					{
						switch (num ^ -1172820035)
						{
						case 0:
							goto IL_001a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_001a:
						num = -1172820033;
					}
				}
			}
		}

		bool IMouseInputSource.enabled
		{
			get
			{
				return base.enabled;
			}
		}

		Vector2 IMouseInputSource.screenPosition
		{
			get
			{
				return JhNnbXRVINzwabVBedwQENWxhtD;
			}
		}

		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				return GLMqXqqjajnDfzIugKqnHmQIWcp;
			}
		}

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (wheel == null)
				{
					return Vector2.zero;
				}
				return wheel.value;
			}
		}

		bool IMouseInputSource.locked
		{
			get
			{
				return false;
			}
		}

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = -1379506821;
						while (true)
						{
							switch (num ^ -1379506822)
							{
							case 2:
								break;
							case 1:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -1379506823;
								continue;
							case 3:
								return;
							default:
								goto end_IL_000d;
							}
							break;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				xiNPFSTpzpYfkdLRrDYoHPinSec = (Action<Vector2>)Delegate.Combine(xiNPFSTpzpYfkdLRrDYoHPinSec, value);
			}
			remove
			{
				xiNPFSTpzpYfkdLRrDYoHPinSec = (Action<Vector2>)Delegate.Remove(xiNPFSTpzpYfkdLRrDYoHPinSec, value);
			}
		}

		private PlayerMouse(Definition definition)
			: base(definition)
		{
			wMCSbSAHHGYdaWlmpLzmymzxqfu = definition.defaultToCenter;
			fgStsnyCRZDyVzTImBUsRUxCQYs = definition.movementArea;
			KGuCBclnOeJNYAImGCyDAcvZxxfe = definition.movementAreaUnit;
			CndxAZQxwekvyDsNunUYDoybJGz = definition.pointerSpeed;
			NtdqzCUbgngaIAKSDiczhIjbKiNy = definition.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && object.ReferenceEquals(base.elements[i].GetType(), typeof(MouseAxis)))
				{
					if (num2 == 0)
					{
						PRwGNcqPEdIxTPzIOeULtUFVoHQ = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						vRtqYfznDBfQqAXeANCFWRUvxTc = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (fxSjBBUBHBrfyCosuertmPnvctyk < 0 && base.elements[i] is MouseWheel)
				{
					fxSjBBUBHBrfyCosuertmPnvctyk = i;
				}
				else if (num3 < 3 && object.ReferenceEquals(base.elements[i].GetType(), typeof(Button)))
				{
					switch (num3)
					{
					case 0:
						xMCazNyKqvCFtqEqLInbHNVGIIQ = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						ZvjdstNiuQBfhCGDczeogLyyghv = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						GlZXxPlkSbdZvTJJgQJigDdLIbdc = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (fxSjBBUBHBrfyCosuertmPnvctyk < 0)
			{
				int num4 = PlayerController.NhwuMsaBZhNRgrlbmGtKvnkDBwq(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 1);
				int num5 = PlayerController.NhwuMsaBZhNRgrlbmGtKvnkDBwq(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					DaOirHIMrqCgwPvMGCDKpJCcEFCO(mouseWheel);
					fxSjBBUBHBrfyCosuertmPnvctyk = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						DaOirHIMrqCgwPvMGCDKpJCcEFCO(element);
						mouseWheel.DaOirHIMrqCgwPvMGCDKpJCcEFCO(element);
						mouseWheel.DaOirHIMrqCgwPvMGCDKpJCcEFCO((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.DaOirHIMrqCgwPvMGCDKpJCcEFCO(base.axes[num4]);
						mouseWheel.DaOirHIMrqCgwPvMGCDKpJCcEFCO(base.axes[num5]);
					}
				}
			}
			if (wMCSbSAHHGYdaWlmpLzmymzxqfu)
			{
				ScreenRect screenRect = FzeHhbGcKpaHSYYsQaLzYUqiMde();
				JhNnbXRVINzwabVBedwQENWxhtD = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				JhNnbXRVINzwabVBedwQENWxhtD = Vector2.zero;
			}
		}

		protected override bool Update(UpdateLoopType updateLoop)
		{
			if (!base.Update(updateLoop))
			{
				return false;
			}
			if (updateLoop != UpdateLoopType.Update)
			{
				return false;
			}
			Player player = default(Player);
			if (NtdqzCUbgngaIAKSDiczhIjbKiNy && (player = base.player) != null)
			{
				goto IL_0028;
			}
			goto IL_014d;
			IL_014d:
			int num;
			if (PRwGNcqPEdIxTPzIOeULtUFVoHQ >= 0)
			{
				JhNnbXRVINzwabVBedwQENWxhtD.x = kaOXwStGmJCGcJIErHtcDPYsPpNM(base.axes[PRwGNcqPEdIxTPzIOeULtUFVoHQ], JhNnbXRVINzwabVBedwQENWxhtD.x, CndxAZQxwekvyDsNunUYDoybJGz);
				num = 1286654127;
				goto IL_002d;
			}
			goto IL_0192;
			IL_0192:
			if (vRtqYfznDBfQqAXeANCFWRUvxTc >= 0)
			{
				JhNnbXRVINzwabVBedwQENWxhtD.y = kaOXwStGmJCGcJIErHtcDPYsPpNM(base.axes[vRtqYfznDBfQqAXeANCFWRUvxTc], JhNnbXRVINzwabVBedwQENWxhtD.y, CndxAZQxwekvyDsNunUYDoybJGz);
				num = 1286654117;
				goto IL_002d;
			}
			goto IL_01d7;
			IL_01d7:
			vLsYYLvyjIbDqaHJasbfnrfpjwm(JhNnbXRVINzwabVBedwQENWxhtD);
			num = 1286654123;
			goto IL_002d;
			IL_0028:
			num = 1286654120;
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num ^ 0x4CB0C8AE)
				{
				case 4:
					break;
				case 7:
					pILDXIZNZMgatIJnWvZGipvXPyGT.x = oQNoToqrjFsKBmbKcwwamAYicpa.x;
					pILDXIZNZMgatIJnWvZGipvXPyGT.y = oQNoToqrjFsKBmbKcwwamAYicpa.y;
					num = 1286654118;
					continue;
				case 0:
					goto IL_00a0;
				case 9:
					num = 1286654118;
					continue;
				case 2:
					goto IL_00eb;
				case 3:
					JhNnbXRVINzwabVBedwQENWxhtD.x = oQNoToqrjFsKBmbKcwwamAYicpa.x;
					JhNnbXRVINzwabVBedwQENWxhtD.y = oQNoToqrjFsKBmbKcwwamAYicpa.y;
					num = 1286654121;
					continue;
				case 8:
					goto IL_014d;
				case 1:
					goto IL_0192;
				case 11:
					goto IL_01d7;
				case 5:
					GLMqXqqjajnDfzIugKqnHmQIWcp.x = JhNnbXRVINzwabVBedwQENWxhtD.x - ZcOBcRPWjZzsNPAUXgEzciyTfge.x;
					GLMqXqqjajnDfzIugKqnHmQIWcp.y = JhNnbXRVINzwabVBedwQENWxhtD.y - ZcOBcRPWjZzsNPAUXgEzciyTfge.y;
					zpYIeajMHnQnHLlAakYKlJXoHQe = JhNnbXRVINzwabVBedwQENWxhtD.x != ZcOBcRPWjZzsNPAUXgEzciyTfge.x || JhNnbXRVINzwabVBedwQENWxhtD.y != ZcOBcRPWjZzsNPAUXgEzciyTfge.y;
					num = 1286654116;
					continue;
				case 6:
					if (!player.controllers.hasMouse)
					{
						JVEKrFRjZNsHuvMiQDxLhJnBKWH();
						num = 1286654119;
						continue;
					}
					goto IL_00a0;
				default:
					ZcOBcRPWjZzsNPAUXgEzciyTfge.x = JhNnbXRVINzwabVBedwQENWxhtD.x;
					ZcOBcRPWjZzsNPAUXgEzciyTfge.y = JhNnbXRVINzwabVBedwQENWxhtD.y;
					return true;
				}
				break;
				IL_00eb:
				int num2;
				if (oQNoToqrjFsKBmbKcwwamAYicpa.y == pILDXIZNZMgatIJnWvZGipvXPyGT.y)
				{
					num = 1286654121;
					num2 = num;
				}
				else
				{
					num = 1286654125;
					num2 = num;
				}
				continue;
				IL_00a0:
				oQNoToqrjFsKBmbKcwwamAYicpa = ReInput.controllers.Mouse.screenPosition;
				int num3;
				if (oQNoToqrjFsKBmbKcwwamAYicpa.x != pILDXIZNZMgatIJnWvZGipvXPyGT.x)
				{
					num = 1286654125;
					num3 = num;
				}
				else
				{
					num = 1286654124;
					num3 = num;
				}
			}
			goto IL_0028;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (zpYIeajMHnQnHLlAakYKlJXoHQe && xiNPFSTpzpYfkdLRrDYoHPinSec != null)
			{
				try
				{
					xiNPFSTpzpYfkdLRrDYoHPinSec(JhNnbXRVINzwabVBedwQENWxhtD);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				zpYIeajMHnQnHLlAakYKlJXoHQe = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			ZcOBcRPWjZzsNPAUXgEzciyTfge = JhNnbXRVINzwabVBedwQENWxhtD;
			GLMqXqqjajnDfzIugKqnHmQIWcp = Vector2.zero;
			JVEKrFRjZNsHuvMiQDxLhJnBKWH();
			zpYIeajMHnQnHLlAakYKlJXoHQe = false;
		}

		private void vLsYYLvyjIbDqaHJasbfnrfpjwm(Vector2 P_0)
		{
			if (KGuCBclnOeJNYAImGCyDAcvZxxfe == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				JhNnbXRVINzwabVBedwQENWxhtD.x = Mathf.Clamp(P_0.x, fgStsnyCRZDyVzTImBUsRUxCQYs.xMin * num, fgStsnyCRZDyVzTImBUsRUxCQYs.xMax * num);
				JhNnbXRVINzwabVBedwQENWxhtD.y = Mathf.Clamp(P_0.y, fgStsnyCRZDyVzTImBUsRUxCQYs.yMin * num2, fgStsnyCRZDyVzTImBUsRUxCQYs.yMax * num2);
				return;
			}
			while (true)
			{
				int num3;
				int num4;
				if (KGuCBclnOeJNYAImGCyDAcvZxxfe == MovementAreaUnit.Pixel)
				{
					num3 = 566207;
					num4 = num3;
				}
				else
				{
					num3 = 566206;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x8A3BF)
					{
					case 2:
						num3 = 566203;
						continue;
					case 4:
						break;
					case 3:
						return;
					case 0:
						JhNnbXRVINzwabVBedwQENWxhtD.x = Mathf.Clamp(P_0.x, fgStsnyCRZDyVzTImBUsRUxCQYs.xMin, fgStsnyCRZDyVzTImBUsRUxCQYs.xMax);
						JhNnbXRVINzwabVBedwQENWxhtD.y = Mathf.Clamp(P_0.y, fgStsnyCRZDyVzTImBUsRUxCQYs.yMin, fgStsnyCRZDyVzTImBUsRUxCQYs.yMax);
						num3 = 566204;
						continue;
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		private ScreenRect FzeHhbGcKpaHSYYsQaLzYUqiMde()
		{
			if (KGuCBclnOeJNYAImGCyDAcvZxxfe == MovementAreaUnit.Screen)
			{
				return new ScreenRect(fgStsnyCRZDyVzTImBUsRUxCQYs.xMin * (float)Screen.width, fgStsnyCRZDyVzTImBUsRUxCQYs.yMin * (float)Screen.height, fgStsnyCRZDyVzTImBUsRUxCQYs.width * (float)Screen.width, fgStsnyCRZDyVzTImBUsRUxCQYs.height * (float)Screen.height);
			}
			if (KGuCBclnOeJNYAImGCyDAcvZxxfe == MovementAreaUnit.Pixel)
			{
				return fgStsnyCRZDyVzTImBUsRUxCQYs;
			}
			throw new NotImplementedException();
		}

		private void JVEKrFRjZNsHuvMiQDxLhJnBKWH()
		{
			oQNoToqrjFsKBmbKcwwamAYicpa = Vector2.zero;
			pILDXIZNZMgatIJnWvZGipvXPyGT = Vector2.zero;
		}

		private static float kaOXwStGmJCGcJIErHtcDPYsPpNM(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			return P_1 + P_0.value * P_2;
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			return GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			return GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			return GetButton(P_0);
		}

		[CompilerGenerated]
		private static bool vOalFrpgXOTEVTikVYelbkzwSww(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}

		[CompilerGenerated]
		private static bool UGSMGGdoJLEUJdHOFggXZHGKsyUk(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}
	}
}

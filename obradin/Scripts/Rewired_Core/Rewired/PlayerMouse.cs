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

			public ScreenRect movementArea = YSjYxgDVpYPjXROHwHwxzrblxcS;

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
				return MdLShCgeucAqBomYFlMaHVWokJC(3, 3);
			}

			private static PlayerMouse MdLShCgeucAqBomYFlMaHVWokJC(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
					goto IL_0007;
				}
				goto IL_0078;
				IL_0064:
				int num = 4;
				int num2 = 1899105853;
				goto IL_000c;
				IL_0007:
				num2 = 1899105850;
				goto IL_000c;
				IL_000c:
				int num3 = default(int);
				List<Element.Definition> list = default(List<Element.Definition>);
				while (true)
				{
					switch (num2 ^ 0x71320E32)
					{
					case 13:
						break;
					case 0:
						goto IL_0064;
					case 11:
						num3 = 3;
						num2 = 1899105840;
						continue;
					case 8:
						goto IL_0078;
					case 12:
						goto IL_0089;
					case 4:
						list.Add(new Button.Definition
						{
							name = "Right Button"
						});
						num2 = 1899105854;
						continue;
					case 17:
						goto IL_00c6;
					case 3:
						list.Add(new Button.Definition
						{
							name = "Left Button"
						});
						num2 = 1899105851;
						continue;
					case 7:
						list.Add(new Button.Definition
						{
							name = "Middle Button"
						});
						num2 = 1899105849;
						continue;
					case 16:
						list.Add(new Axis.Definition
						{
							coordinateMode = AxisCoordinateMode.Relative
						});
						num++;
						num2 = 1899105853;
						continue;
					case 14:
						num3++;
						num2 = 1899105843;
						continue;
					case 9:
						goto IL_01a8;
					case 15:
						goto IL_01c0;
					case 10:
						list.Add(new Button.Definition());
						num2 = 1899105852;
						continue;
					case 6:
						goto IL_01ee;
					case 5:
						goto IL_0206;
					case 2:
						num2 = 1899105843;
						continue;
					default:
						if (num3 >= P_0)
						{
							Definition definition = new Definition();
							definition.elements = list;
							return new PlayerMouse(definition);
						}
						goto case 10;
					}
					break;
					IL_01ee:
					int num4;
					if (P_0 >= 1)
					{
						num2 = 1899105841;
						num4 = num2;
					}
					else
					{
						num2 = 1899105851;
						num4 = num2;
					}
					continue;
					IL_01a8:
					int num5;
					if (P_0 < 2)
					{
						num2 = 1899105854;
						num5 = num2;
					}
					else
					{
						num2 = 1899105846;
						num5 = num2;
					}
					continue;
					IL_0089:
					int num6;
					if (P_0 >= 3)
					{
						num2 = 1899105845;
						num6 = num2;
					}
					else
					{
						num2 = 1899105849;
						num6 = num2;
					}
					continue;
					IL_01c0:
					int num7;
					if (num < P_1)
					{
						num2 = 1899105826;
						num7 = num2;
					}
					else
					{
						num2 = 1899105844;
						num7 = num2;
					}
				}
				goto IL_0007;
				IL_00c6:
				if (P_1 >= 3)
				{
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
					num2 = 1899105842;
					goto IL_000c;
				}
				goto IL_0064;
				IL_0206:
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
					num2 = 1899105827;
					goto IL_000c;
				}
				goto IL_00c6;
				IL_0078:
				if (P_1 < 0)
				{
					P_1 = 0;
					num2 = 1899105847;
					goto IL_000c;
				}
				goto IL_0206;
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

		internal const bool PdDGWmDQnXTKvmwfydNERLOONzxR = true;

		internal const float dykSAmdJqhAzlceRfRiGAeDGQnZY = 1f;

		internal const bool kkLxsBINWdgNbNJfuUoYBraJjee = true;

		internal const MovementAreaUnit KoTTyoBlPNrvZAQgcbItGYLClfvI = MovementAreaUnit.Screen;

		private const int hBEzQrrNYcbiBiUeVbhcpOiiadLF = 3;

		private const int lIfecUDtmbTvWseEEbfxbQZAqdpH = 3;

		internal const string zJsoayGytsgDBtMvSQYXjntvQVe = "Movement";

		internal const string IdJMLeMkTBLVORBwryhfIhWmGcQk = "Horizontal";

		internal const string dwygqddOlIeGzlWSnPmJHWzMPCmS = "Vertical";

		internal const string bUbzIdgBgQqwQOamhpVwVKxCjep = "Wheel";

		internal const string InXVVDLgeWKQLGYhrgaIpWMVcuI = "Wheel Horizontal";

		internal const string LPeQBABWoxZmPlTwHDxNqebomSO = "Wheel Vertical";

		internal const string WiAvujQLGURStqkmilTHSaIiWQI = "Left Button";

		internal const string RJeGflIRPHVLZIndDMkJCebdyDxL = "Right Button";

		internal const string xGfMmJImCEYVEdWlOKvPbAmgsJY = "Middle Button";

		internal static readonly ScreenRect YSjYxgDVpYPjXROHwHwxzrblxcS = new ScreenRect(0f, 0f, 1f, 1f);

		private readonly int ChYqYGwvDNhYTakpGivdFHvxccz = -1;

		private readonly int uTcrGhQTSriSmfxZwHQFUgBLdERI = -1;

		private readonly int WeXrkTRjHTWAbkIbgLgVvCJtoRl = -1;

		private readonly int UWOhvIObchKnEKBbhgpneuJIUNPq = -1;

		private readonly int ciflcypBiQCSCiPAWNamPTgyIgw = -1;

		private readonly int dYVfaKBJSnhwKcnEdAXkLDnBFyHs = -1;

		private bool CHpXxlVUmLfEOfkyqwJSMgHVWfD;

		private Vector2 VQTtsbGHvZhToSgFEPoePcOaOkr;

		private Vector2 MGHuEFhuPMjHIdLywCDGIGnZPpHm;

		private Vector2 uTVCwSvYSLRKJRnKMIfIHjEvQgSc;

		private Vector2 iXAvxEnpxXQtkdaXtGnbLwsBxqb;

		private Vector2 fLKdxYGpPdOqKDTsUKvzsczEFOi;

		private float pWbagIeweoWFXdPIMWjGiSunaQo;

		private bool krfgeFkRmxCVdaeFdJkjKpnIvzWs;

		private Action<Vector2> WUPFYHbBtdAWHDwMFgSoDsyhJltb;

		private bool TrAXxkqHUEjuVgcLBLuyFsNtdQv;

		private ScreenRect URSyhqONoHoesXPICDrgaAoADyf;

		private MovementAreaUnit rWmYzzDnEamNdaytwsZXXkdVgos;

		[CompilerGenerated]
		private static Predicate<Axis> nhZhHiEaFeFZfvvFfeUphFgcpoy;

		[CompilerGenerated]
		private static Predicate<Axis> VwQiXDpZbbShTuzxBExijEwCecS;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return TrAXxkqHUEjuVgcLBLuyFsNtdQv;
			}
			set
			{
				TrAXxkqHUEjuVgcLBLuyFsNtdQv = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return default(ScreenRect);
				}
				return URSyhqONoHoesXPICDrgaAoADyf;
			}
			set
			{
				URSyhqONoHoesXPICDrgaAoADyf = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return MovementAreaUnit.Screen;
				}
				return rWmYzzDnEamNdaytwsZXXkdVgos;
			}
			set
			{
				rWmYzzDnEamNdaytwsZXXkdVgos = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return uTVCwSvYSLRKJRnKMIfIHjEvQgSc;
			}
			set
			{
				KIZXINRaKvMGoWKXzeijQdKlcDh(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return iXAvxEnpxXQtkdaXtGnbLwsBxqb;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return fLKdxYGpPdOqKDTsUKvzsczEFOi;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					goto IL_000d;
				}
				int num;
				if (uTcrGhQTSriSmfxZwHQFUgBLdERI < 0)
				{
					num = 642247787;
					goto IL_0012;
				}
				return (MouseAxis)base.axes[uTcrGhQTSriSmfxZwHQFUgBLdERI];
				IL_000d:
				num = 642247786;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x2647EC6B)
					{
					case 2:
						break;
					case 1:
						goto IL_002f;
					case 3:
						return null;
					default:
						return null;
					}
					break;
					IL_002f:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = 642247784;
				}
				goto IL_000d;
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				if (WeXrkTRjHTWAbkIbgLgVvCJtoRl < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[WeXrkTRjHTWAbkIbgLgVvCJtoRl];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				if (ChYqYGwvDNhYTakpGivdFHvxccz < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[ChYqYGwvDNhYTakpGivdFHvxccz];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				if (UWOhvIObchKnEKBbhgpneuJIUNPq < 0)
				{
					return null;
				}
				return base.buttons[UWOhvIObchKnEKBbhgpneuJIUNPq];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				if (ciflcypBiQCSCiPAWNamPTgyIgw < 0)
				{
					return null;
				}
				return base.buttons[ciflcypBiQCSCiPAWNamPTgyIgw];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -212755370;
						while (true)
						{
							switch (num ^ -212755369)
							{
							case 0:
								break;
							case 1:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -212755371;
						}
					}
				}
				if (dYVfaKBJSnhwKcnEdAXkLDnBFyHs < 0)
				{
					return null;
				}
				return base.buttons[dYVfaKBJSnhwKcnEdAXkLDnBFyHs];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				}
				return pWbagIeweoWFXdPIMWjGiSunaQo;
			}
			set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (value < 0f)
					{
						num = -959160320;
						num2 = num;
					}
					else
					{
						num = -959160319;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -959160318)
						{
						case 0:
							num = -959160317;
							continue;
						case 1:
							break;
						case 2:
							value = 0f;
							num = -959160319;
							continue;
						default:
							pWbagIeweoWFXdPIMWjGiSunaQo = value;
							return;
						}
						break;
					}
				}
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return krfgeFkRmxCVdaeFdJkjKpnIvzWs;
			}
			set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					goto IL_000d;
				}
				goto IL_0046;
				IL_000d:
				int num = -1514813027;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ -1514813025)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1514813029;
						continue;
					case 1:
						goto IL_0046;
					case 4:
						return;
					case 3:
						return;
					}
					break;
				}
				goto IL_000d;
				IL_0046:
				krfgeFkRmxCVdaeFdJkjKpnIvzWs = value;
				if (!value)
				{
					kJKRkClMNTPsPRlzyhbZGFnRuZM();
					num = -1514813028;
					goto IL_0012;
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
				return uTVCwSvYSLRKJRnKMIfIHjEvQgSc;
			}
		}

		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				return fLKdxYGpPdOqKDTsUKvzsczEFOi;
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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					goto IL_0019;
				}
				goto IL_0043;
				IL_0043:
				WUPFYHbBtdAWHDwMFgSoDsyhJltb = (Action<Vector2>)Delegate.Combine(WUPFYHbBtdAWHDwMFgSoDsyhJltb, value);
				int num = -1876364059;
				goto IL_001e;
				IL_0019:
				num = -1876364058;
				goto IL_001e;
				IL_001e:
				switch (num ^ -1876364057)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					goto IL_0043;
				case 2:
					return;
				}
				goto IL_0019;
			}
			remove
			{
				WUPFYHbBtdAWHDwMFgSoDsyhJltb = (Action<Vector2>)Delegate.Remove(WUPFYHbBtdAWHDwMFgSoDsyhJltb, value);
			}
		}

		private PlayerMouse(Definition definition)
			: base(definition)
		{
			TrAXxkqHUEjuVgcLBLuyFsNtdQv = definition.defaultToCenter;
			URSyhqONoHoesXPICDrgaAoADyf = definition.movementArea;
			rWmYzzDnEamNdaytwsZXXkdVgos = definition.movementAreaUnit;
			pWbagIeweoWFXdPIMWjGiSunaQo = definition.pointerSpeed;
			krfgeFkRmxCVdaeFdJkjKpnIvzWs = definition.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && object.ReferenceEquals(base.elements[i].GetType(), typeof(MouseAxis)))
				{
					if (num2 == 0)
					{
						uTcrGhQTSriSmfxZwHQFUgBLdERI = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						WeXrkTRjHTWAbkIbgLgVvCJtoRl = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (ChYqYGwvDNhYTakpGivdFHvxccz < 0 && base.elements[i] is MouseWheel)
				{
					ChYqYGwvDNhYTakpGivdFHvxccz = i;
				}
				else if (num3 < 3 && object.ReferenceEquals(base.elements[i].GetType(), typeof(Button)))
				{
					switch (num3)
					{
					case 0:
						UWOhvIObchKnEKBbhgpneuJIUNPq = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						ciflcypBiQCSCiPAWNamPTgyIgw = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						dYVfaKBJSnhwKcnEdAXkLDnBFyHs = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (ChYqYGwvDNhYTakpGivdFHvxccz < 0)
			{
				int num4 = PlayerController.eEaeRhdMBvlgJyTeGHlQmUkRWOvh(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 1);
				int num5 = PlayerController.eEaeRhdMBvlgJyTeGHlQmUkRWOvh(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					uiIyqEcLjeCLLGNLkqHYomAmAGZF(mouseWheel);
					ChYqYGwvDNhYTakpGivdFHvxccz = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						uiIyqEcLjeCLLGNLkqHYomAmAGZF(element);
						mouseWheel.uiIyqEcLjeCLLGNLkqHYomAmAGZF(element);
						mouseWheel.uiIyqEcLjeCLLGNLkqHYomAmAGZF((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.uiIyqEcLjeCLLGNLkqHYomAmAGZF(base.axes[num4]);
						mouseWheel.uiIyqEcLjeCLLGNLkqHYomAmAGZF(base.axes[num5]);
					}
				}
			}
			if (TrAXxkqHUEjuVgcLBLuyFsNtdQv)
			{
				ScreenRect screenRect = aHmMwwaCwjuAviahmZJvnRmaqtj();
				uTVCwSvYSLRKJRnKMIfIHjEvQgSc = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				uTVCwSvYSLRKJRnKMIfIHjEvQgSc = Vector2.zero;
			}
		}

		protected override bool Update(UpdateLoopType updateLoop)
		{
			if (!base.Update(updateLoop))
			{
				goto IL_000c;
			}
			if (updateLoop != UpdateLoopType.Update)
			{
				return false;
			}
			int num;
			int num2;
			if (!krfgeFkRmxCVdaeFdJkjKpnIvzWs)
			{
				num = 1273670541;
				num2 = num;
			}
			else
			{
				num = 1273670535;
				num2 = num;
			}
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ 0x4BEAAB8E)
				{
				case 8:
					break;
				case 12:
					if (VQTtsbGHvZhToSgFEPoePcOaOkr.x == MGHuEFhuPMjHIdLywCDGIGnZPpHm.x)
					{
						int num3;
						if (VQTtsbGHvZhToSgFEPoePcOaOkr.y != MGHuEFhuPMjHIdLywCDGIGnZPpHm.y)
						{
							num = 1273670536;
							num3 = num;
						}
						else
						{
							num = 1273670533;
							num3 = num;
						}
						continue;
					}
					goto case 6;
				case 5:
					if (WeXrkTRjHTWAbkIbgLgVvCJtoRl >= 0)
					{
						uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y = XHMEzZNeiHlMVlNPHtdqoFAqIcS(base.axes[WeXrkTRjHTWAbkIbgLgVvCJtoRl], uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y, pWbagIeweoWFXdPIMWjGiSunaQo);
						num = 1273670537;
						continue;
					}
					goto case 7;
				case 4:
					num = 1273670541;
					continue;
				case 3:
					if (uTcrGhQTSriSmfxZwHQFUgBLdERI >= 0)
					{
						uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x = XHMEzZNeiHlMVlNPHtdqoFAqIcS(base.axes[uTcrGhQTSriSmfxZwHQFUgBLdERI], uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x, pWbagIeweoWFXdPIMWjGiSunaQo);
						num = 1273670539;
						continue;
					}
					goto case 5;
				case 0:
					VQTtsbGHvZhToSgFEPoePcOaOkr = ReInput.controllers.Mouse.screenPosition;
					num = 1273670530;
					continue;
				case 11:
					MGHuEFhuPMjHIdLywCDGIGnZPpHm.x = VQTtsbGHvZhToSgFEPoePcOaOkr.x;
					num = 1273670540;
					continue;
				case 1:
					return false;
				case 9:
				{
					Player player;
					if ((player = base.player) == null)
					{
						goto case 3;
					}
					if (!player.controllers.hasMouse)
					{
						kJKRkClMNTPsPRlzyhbZGFnRuZM();
						num = 1273670538;
						continue;
					}
					goto case 0;
				}
				case 6:
					uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x = VQTtsbGHvZhToSgFEPoePcOaOkr.x;
					uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y = VQTtsbGHvZhToSgFEPoePcOaOkr.y;
					num = 1273670533;
					continue;
				case 2:
					MGHuEFhuPMjHIdLywCDGIGnZPpHm.y = VQTtsbGHvZhToSgFEPoePcOaOkr.y;
					num = 1273670541;
					continue;
				case 7:
					KIZXINRaKvMGoWKXzeijQdKlcDh(uTVCwSvYSLRKJRnKMIfIHjEvQgSc);
					fLKdxYGpPdOqKDTsUKvzsczEFOi.x = uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x - iXAvxEnpxXQtkdaXtGnbLwsBxqb.x;
					fLKdxYGpPdOqKDTsUKvzsczEFOi.y = uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y - iXAvxEnpxXQtkdaXtGnbLwsBxqb.y;
					CHpXxlVUmLfEOfkyqwJSMgHVWfD = uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x != iXAvxEnpxXQtkdaXtGnbLwsBxqb.x || uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y != iXAvxEnpxXQtkdaXtGnbLwsBxqb.y;
					num = 1273670532;
					continue;
				default:
					iXAvxEnpxXQtkdaXtGnbLwsBxqb.x = uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x;
					iXAvxEnpxXQtkdaXtGnbLwsBxqb.y = uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y;
					return true;
				}
				break;
			}
			goto IL_000c;
			IL_000c:
			num = 1273670543;
			goto IL_0011;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (CHpXxlVUmLfEOfkyqwJSMgHVWfD && WUPFYHbBtdAWHDwMFgSoDsyhJltb != null)
			{
				try
				{
					WUPFYHbBtdAWHDwMFgSoDsyhJltb(uTVCwSvYSLRKJRnKMIfIHjEvQgSc);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				CHpXxlVUmLfEOfkyqwJSMgHVWfD = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			iXAvxEnpxXQtkdaXtGnbLwsBxqb = uTVCwSvYSLRKJRnKMIfIHjEvQgSc;
			fLKdxYGpPdOqKDTsUKvzsczEFOi = Vector2.zero;
			kJKRkClMNTPsPRlzyhbZGFnRuZM();
			while (true)
			{
				int num = -198345571;
				while (true)
				{
					switch (num ^ -198345569)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0041;
					case 1:
						return;
					}
					break;
					IL_0041:
					CHpXxlVUmLfEOfkyqwJSMgHVWfD = false;
					num = -198345570;
				}
			}
		}

		private void KIZXINRaKvMGoWKXzeijQdKlcDh(Vector2 P_0)
		{
			if (rWmYzzDnEamNdaytwsZXXkdVgos == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x = Mathf.Clamp(P_0.x, URSyhqONoHoesXPICDrgaAoADyf.xMin * num, URSyhqONoHoesXPICDrgaAoADyf.xMax * num);
				while (true)
				{
					switch (-651526555 ^ -651526556)
					{
					case 0:
						break;
					case 1:
						uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y = Mathf.Clamp(P_0.y, URSyhqONoHoesXPICDrgaAoADyf.yMin * num2, URSyhqONoHoesXPICDrgaAoADyf.yMax * num2);
						return;
					case 2:
						goto end_IL_004a;
					default:
						goto IL_0116;
					}
					continue;
					end_IL_004a:
					break;
				}
			}
			if (rWmYzzDnEamNdaytwsZXXkdVgos == MovementAreaUnit.Pixel)
			{
				uTVCwSvYSLRKJRnKMIfIHjEvQgSc.x = Mathf.Clamp(P_0.x, URSyhqONoHoesXPICDrgaAoADyf.xMin, URSyhqONoHoesXPICDrgaAoADyf.xMax);
				uTVCwSvYSLRKJRnKMIfIHjEvQgSc.y = Mathf.Clamp(P_0.y, URSyhqONoHoesXPICDrgaAoADyf.yMin, URSyhqONoHoesXPICDrgaAoADyf.yMax);
				return;
			}
			goto IL_0116;
			IL_0116:
			throw new NotImplementedException();
		}

		private ScreenRect aHmMwwaCwjuAviahmZJvnRmaqtj()
		{
			if (rWmYzzDnEamNdaytwsZXXkdVgos == MovementAreaUnit.Screen)
			{
				return new ScreenRect(URSyhqONoHoesXPICDrgaAoADyf.xMin * (float)Screen.width, URSyhqONoHoesXPICDrgaAoADyf.yMin * (float)Screen.height, URSyhqONoHoesXPICDrgaAoADyf.width * (float)Screen.width, URSyhqONoHoesXPICDrgaAoADyf.height * (float)Screen.height);
			}
			if (rWmYzzDnEamNdaytwsZXXkdVgos == MovementAreaUnit.Pixel)
			{
				return URSyhqONoHoesXPICDrgaAoADyf;
			}
			throw new NotImplementedException();
		}

		private void kJKRkClMNTPsPRlzyhbZGFnRuZM()
		{
			VQTtsbGHvZhToSgFEPoePcOaOkr = Vector2.zero;
			while (true)
			{
				int num = 110462480;
				while (true)
				{
					switch (num ^ 0x6958611)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0029;
					case 0:
						return;
					}
					break;
					IL_0029:
					MGHuEFhuPMjHIdLywCDGIGnZPpHm = Vector2.zero;
					num = 110462481;
				}
			}
		}

		private static float XHMEzZNeiHlMVlNPHtdqoFAqIcS(Axis P_0, float P_1, float P_2)
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
		private static bool IouyBqDasSqmwbPjfCKjSfakNjb(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}

		[CompilerGenerated]
		private static bool tBCiNVZOPZercCbJfMoHdoIKPpTv(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}
	}
}

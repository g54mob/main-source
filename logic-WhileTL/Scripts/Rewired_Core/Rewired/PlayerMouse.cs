using System;
using System.Collections.Generic;
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

			public bool clampToMovementArea = true;

			public ScreenRect movementArea = wHicjJlMdHxzwNcNMKzoAePSQBXf;

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
				return goGesjEFofcTayLyzynfoITRPCBk(3, 3);
			}

			private static PlayerMouse goGesjEFofcTayLyzynfoITRPCBk(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
				}
				if (P_1 < 0)
				{
					P_1 = 0;
				}
				List<Element.Definition> list = new List<Element.Definition>(P_0 + P_1);
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
				}
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
				}
				for (int i = 4; i < P_1; i++)
				{
					list.Add(new Axis.Definition
					{
						coordinateMode = AxisCoordinateMode.Relative
					});
				}
				if (P_0 >= 1)
				{
					list.Add(new Button.Definition
					{
						name = "Left Button"
					});
				}
				if (P_0 >= 2)
				{
					list.Add(new Button.Definition
					{
						name = "Right Button"
					});
				}
				if (P_0 >= 3)
				{
					list.Add(new Button.Definition
					{
						name = "Middle Button"
					});
				}
				for (int j = 3; j < P_0; j++)
				{
					list.Add(new Button.Definition());
				}
				return new PlayerMouse(new Definition
				{
					elements = list
				});
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

		[Serializable]
		private sealed class JQUhhHLddIEMgGJChcuaTIHgwNPSA
		{
			public static readonly JQUhhHLddIEMgGJChcuaTIHgwNPSA _003C_003E9 = new JQUhhHLddIEMgGJChcuaTIHgwNPSA();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool mmyHjISlDoMXkdXfbNguuMIIZlUO(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.EmbhxShZpSdinJOCBRHmiAsqvDuRA;
				}
				return false;
			}

			internal bool OGlSkPZhCHbaEEreGeXQXFldjnBOA(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.EmbhxShZpSdinJOCBRHmiAsqvDuRA;
				}
				return false;
			}
		}

		internal const bool dSWAqHKsdOKgYhmXMgSHTsFpsQcbb = true;

		internal const float JjjyiZTYcmqVOaLbHdpTdDOfBEMjb = 1f;

		internal const bool WZYYKeuDSctjELkJABvVqejaRLrS = true;

		internal const bool DDqbeknynfBqPnkUKEzvUaEdApk = true;

		internal const MovementAreaUnit qzAxSHdNLMeZudIKCvPwjlUzzMoZ = MovementAreaUnit.Screen;

		internal static readonly ScreenRect wHicjJlMdHxzwNcNMKzoAePSQBXf = new ScreenRect(0f, 0f, 1f, 1f);

		private const int VLHTsEHlUppQqIsMdiVnderNHCER = 3;

		private const int JYehQthdygfZtbissPuavrUxnMklA = 3;

		internal const string XUpqSFodxtthwtGTwXFAOMmWFabaA = "Movement";

		internal const string gnWijJgOPSyrtDbQHQaspSJVqNNN = "Horizontal";

		internal const string VgzdYIuUvBfmEeYoFTrIwhubovtAb = "Vertical";

		internal const string DEsBCMIBLLIrVMUqVervwXMtYgKB = "Wheel";

		internal const string gdIazuxgwZvugOYHXKhXWFZaJPPq = "Wheel Horizontal";

		internal const string vAdwBnhyumxIovtWnESGLSuXBPDl = "Wheel Vertical";

		internal const string eFnZGVgDINnobwEhIcuAbxNLnWHE = "Left Button";

		internal const string xYzALQFjZCTfsqvTvobKYZoUtuuSA = "Right Button";

		internal const string DxsyTgoVMHcxfhVJyNGECzfJVfXH = "Middle Button";

		private readonly int iwBlmrYTJWHcmywVqPouwsqIxXoU = -1;

		private readonly int MevNeOeHWeuwJvvfEsLGfrMmmpUn = -1;

		private readonly int epEPbclKpOwMYmEgOIQOYCIMRxyE = -1;

		private readonly int amPBgvuCogHTlGOZZiNyVbYvdkWP = -1;

		private readonly int UsgVbHRqmLkFleUkuzEluflBiPtm = -1;

		private readonly int NNUcOrCfGinWjtsaaEQdjwgipDbAA = -1;

		private bool wsofnKbSwMJFpjjYWlGNlVOgdgYk;

		private Vector2 lFWPICmzzKtBVSwhctofqGXDDnel;

		private Vector2 qwGxyaXxJLIdnpKUCJYJjimoRKCW;

		private Vector2 IjYAEdNZIIrgmPNomOmDKnVCEFLBA;

		private Vector2 YmBZIlLSvMypLnbwJRCemKxeWyqJ;

		private Vector2 HBFNsxaBbosljLIniFKkZilvuOpH;

		private float HmmEqnMfqxJjsrqayBmRcXnIXfnWA;

		private bool QgieMoYtmeqbGiBfXEfeiSifYGPLA;

		private Action<Vector2> ggAkkgXxbaqckZYwjpBbBivEGUwFA;

		private bool dBNzoFUVAPDVucYrlGrbcxeCYdoG;

		private ScreenRect ihLIBumLsYWRsDniqSzXPHkreanc;

		private bool urQthugGxOMihwbiMGTqjjntwRjF;

		private MovementAreaUnit JhzeQQrSQfACCwYBIjoWiMuaJNvg;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return dBNzoFUVAPDVucYrlGrbcxeCYdoG;
			}
			set
			{
				dBNzoFUVAPDVucYrlGrbcxeCYdoG = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return urQthugGxOMihwbiMGTqjjntwRjF;
			}
			set
			{
				urQthugGxOMihwbiMGTqjjntwRjF = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return default(ScreenRect);
				}
				return ihLIBumLsYWRsDniqSzXPHkreanc;
			}
			set
			{
				ihLIBumLsYWRsDniqSzXPHkreanc = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return MovementAreaUnit.Screen;
				}
				return JhzeQQrSQfACCwYBIjoWiMuaJNvg;
			}
			set
			{
				JhzeQQrSQfACCwYBIjoWiMuaJNvg = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return IjYAEdNZIIrgmPNomOmDKnVCEFLBA;
			}
			set
			{
				wtYdykpqpgoeNICyHjhyrsaIBkgk(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return YmBZIlLSvMypLnbwJRCemKxeWyqJ;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return HBFNsxaBbosljLIniFKkZilvuOpH;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (MevNeOeHWeuwJvvfEsLGfrMmmpUn < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[MevNeOeHWeuwJvvfEsLGfrMmmpUn];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (epEPbclKpOwMYmEgOIQOYCIMRxyE < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[epEPbclKpOwMYmEgOIQOYCIMRxyE];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (iwBlmrYTJWHcmywVqPouwsqIxXoU < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[iwBlmrYTJWHcmywVqPouwsqIxXoU];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (amPBgvuCogHTlGOZZiNyVbYvdkWP < 0)
				{
					return null;
				}
				return base.buttons[amPBgvuCogHTlGOZZiNyVbYvdkWP];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (UsgVbHRqmLkFleUkuzEluflBiPtm < 0)
				{
					return null;
				}
				return base.buttons[UsgVbHRqmLkFleUkuzEluflBiPtm];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				if (NNUcOrCfGinWjtsaaEQdjwgipDbAA < 0)
				{
					return null;
				}
				return base.buttons[NNUcOrCfGinWjtsaaEQdjwgipDbAA];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0f;
				}
				return HmmEqnMfqxJjsrqayBmRcXnIXfnWA;
			}
			set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				HmmEqnMfqxJjsrqayBmRcXnIXfnWA = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return QgieMoYtmeqbGiBfXEfeiSifYGPLA;
			}
			set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return;
				}
				QgieMoYtmeqbGiBfXEfeiSifYGPLA = value;
				if (!value)
				{
					GuNmIlJmNSCKygRZEacWRlmeNaPSA();
				}
			}
		}

		bool IMouseInputSource.enabled => base.enabled;

		Vector2 IMouseInputSource.screenPosition => IjYAEdNZIIrgmPNomOmDKnVCEFLBA;

		Vector2 IMouseInputSource.screenPositionDelta => HBFNsxaBbosljLIniFKkZilvuOpH;

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

		bool IMouseInputSource.locked => false;

		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else
				{
					ggAkkgXxbaqckZYwjpBbBivEGUwFA = (Action<Vector2>)Delegate.Combine(ggAkkgXxbaqckZYwjpBbBivEGUwFA, value);
				}
			}
			remove
			{
				ggAkkgXxbaqckZYwjpBbBivEGUwFA = (Action<Vector2>)Delegate.Remove(ggAkkgXxbaqckZYwjpBbBivEGUwFA, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			dBNzoFUVAPDVucYrlGrbcxeCYdoG = P_0.defaultToCenter;
			urQthugGxOMihwbiMGTqjjntwRjF = P_0.clampToMovementArea;
			ihLIBumLsYWRsDniqSzXPHkreanc = P_0.movementArea;
			JhzeQQrSQfACCwYBIjoWiMuaJNvg = P_0.movementAreaUnit;
			HmmEqnMfqxJjsrqayBmRcXnIXfnWA = P_0.pointerSpeed;
			QgieMoYtmeqbGiBfXEfeiSifYGPLA = P_0.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.elements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						MevNeOeHWeuwJvvfEsLGfrMmmpUn = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						epEPbclKpOwMYmEgOIQOYCIMRxyE = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (iwBlmrYTJWHcmywVqPouwsqIxXoU < 0 && base.elements[i] is MouseWheel)
				{
					iwBlmrYTJWHcmywVqPouwsqIxXoU = i;
				}
				else if (num3 < 3 && (object)base.elements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						amPBgvuCogHTlGOZZiNyVbYvdkWP = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						UsgVbHRqmLkFleUkuzEluflBiPtm = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						NNUcOrCfGinWjtsaaEQdjwgipDbAA = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (iwBlmrYTJWHcmywVqPouwsqIxXoU < 0)
			{
				int num4 = PlayerController.IuxFzWiQBqbOyePCizqDplvmnxcy(base.axes, JQUhhHLddIEMgGJChcuaTIHgwNPSA._003C_003E9.mmyHjISlDoMXkdXfbNguuMIIZlUO, 1);
				int num5 = PlayerController.IuxFzWiQBqbOyePCizqDplvmnxcy(base.axes, JQUhhHLddIEMgGJChcuaTIHgwNPSA._003C_003E9.OGlSkPZhCHbaEEreGeXQXFldjnBOA, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					EXLSSjQnrrQtaZMvCcEDTNZBhhQt(mouseWheel);
					iwBlmrYTJWHcmywVqPouwsqIxXoU = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						EXLSSjQnrrQtaZMvCcEDTNZBhhQt(element);
						mouseWheel.EXLSSjQnrrQtaZMvCcEDTNZBhhQt(element);
						mouseWheel.EXLSSjQnrrQtaZMvCcEDTNZBhhQt((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.EXLSSjQnrrQtaZMvCcEDTNZBhhQt(base.axes[num4]);
						mouseWheel.EXLSSjQnrrQtaZMvCcEDTNZBhhQt(base.axes[num5]);
					}
				}
			}
			if (dBNzoFUVAPDVucYrlGrbcxeCYdoG)
			{
				ScreenRect screenRect = UxvslNCuSeQLUmFvCIZaAzcJNaif();
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA = Vector2.zero;
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
			Player player;
			if (QgieMoYtmeqbGiBfXEfeiSifYGPLA && (player = base.EVSYfBRoRmlZGWzbtVEKHpHdIHIm) != null)
			{
				if (!player.controllers.hasMouse)
				{
					GuNmIlJmNSCKygRZEacWRlmeNaPSA();
				}
				else
				{
					lFWPICmzzKtBVSwhctofqGXDDnel = ReInput.controllers.Mouse.screenPosition;
					if (lFWPICmzzKtBVSwhctofqGXDDnel.x != qwGxyaXxJLIdnpKUCJYJjimoRKCW.x || lFWPICmzzKtBVSwhctofqGXDDnel.y != qwGxyaXxJLIdnpKUCJYJjimoRKCW.y)
					{
						IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x = lFWPICmzzKtBVSwhctofqGXDDnel.x;
						IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y = lFWPICmzzKtBVSwhctofqGXDDnel.y;
					}
					qwGxyaXxJLIdnpKUCJYJjimoRKCW.x = lFWPICmzzKtBVSwhctofqGXDDnel.x;
					qwGxyaXxJLIdnpKUCJYJjimoRKCW.y = lFWPICmzzKtBVSwhctofqGXDDnel.y;
				}
			}
			if (MevNeOeHWeuwJvvfEsLGfrMmmpUn >= 0)
			{
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x = fXJiIkxOuYFuwxCjdaVnZiNFPPJH(base.axes[MevNeOeHWeuwJvvfEsLGfrMmmpUn], IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x, HmmEqnMfqxJjsrqayBmRcXnIXfnWA);
			}
			if (epEPbclKpOwMYmEgOIQOYCIMRxyE >= 0)
			{
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y = fXJiIkxOuYFuwxCjdaVnZiNFPPJH(base.axes[epEPbclKpOwMYmEgOIQOYCIMRxyE], IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y, HmmEqnMfqxJjsrqayBmRcXnIXfnWA);
			}
			wtYdykpqpgoeNICyHjhyrsaIBkgk(IjYAEdNZIIrgmPNomOmDKnVCEFLBA);
			HBFNsxaBbosljLIniFKkZilvuOpH.x = IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x - YmBZIlLSvMypLnbwJRCemKxeWyqJ.x;
			HBFNsxaBbosljLIniFKkZilvuOpH.y = IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y - YmBZIlLSvMypLnbwJRCemKxeWyqJ.y;
			wsofnKbSwMJFpjjYWlGNlVOgdgYk = IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x != YmBZIlLSvMypLnbwJRCemKxeWyqJ.x || IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y != YmBZIlLSvMypLnbwJRCemKxeWyqJ.y;
			YmBZIlLSvMypLnbwJRCemKxeWyqJ.x = IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x;
			YmBZIlLSvMypLnbwJRCemKxeWyqJ.y = IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (wsofnKbSwMJFpjjYWlGNlVOgdgYk && ggAkkgXxbaqckZYwjpBbBivEGUwFA != null)
			{
				try
				{
					ggAkkgXxbaqckZYwjpBbBivEGUwFA(IjYAEdNZIIrgmPNomOmDKnVCEFLBA);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				wsofnKbSwMJFpjjYWlGNlVOgdgYk = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			YmBZIlLSvMypLnbwJRCemKxeWyqJ = IjYAEdNZIIrgmPNomOmDKnVCEFLBA;
			HBFNsxaBbosljLIniFKkZilvuOpH = Vector2.zero;
			GuNmIlJmNSCKygRZEacWRlmeNaPSA();
			wsofnKbSwMJFpjjYWlGNlVOgdgYk = false;
		}

		private void wtYdykpqpgoeNICyHjhyrsaIBkgk(Vector2 P_0)
		{
			if (!urQthugGxOMihwbiMGTqjjntwRjF)
			{
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA = P_0;
				return;
			}
			if (JhzeQQrSQfACCwYBIjoWiMuaJNvg == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x = Mathf.Clamp(P_0.x, ihLIBumLsYWRsDniqSzXPHkreanc.xMin * num, ihLIBumLsYWRsDniqSzXPHkreanc.xMax * num);
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y = Mathf.Clamp(P_0.y, ihLIBumLsYWRsDniqSzXPHkreanc.yMin * num2, ihLIBumLsYWRsDniqSzXPHkreanc.yMax * num2);
				return;
			}
			if (JhzeQQrSQfACCwYBIjoWiMuaJNvg == MovementAreaUnit.Pixel)
			{
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.x = Mathf.Clamp(P_0.x, ihLIBumLsYWRsDniqSzXPHkreanc.xMin, ihLIBumLsYWRsDniqSzXPHkreanc.xMax);
				IjYAEdNZIIrgmPNomOmDKnVCEFLBA.y = Mathf.Clamp(P_0.y, ihLIBumLsYWRsDniqSzXPHkreanc.yMin, ihLIBumLsYWRsDniqSzXPHkreanc.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect UxvslNCuSeQLUmFvCIZaAzcJNaif()
		{
			if (JhzeQQrSQfACCwYBIjoWiMuaJNvg == MovementAreaUnit.Screen)
			{
				return new ScreenRect(ihLIBumLsYWRsDniqSzXPHkreanc.xMin * (float)Screen.width, ihLIBumLsYWRsDniqSzXPHkreanc.yMin * (float)Screen.height, ihLIBumLsYWRsDniqSzXPHkreanc.width * (float)Screen.width, ihLIBumLsYWRsDniqSzXPHkreanc.height * (float)Screen.height);
			}
			if (JhzeQQrSQfACCwYBIjoWiMuaJNvg == MovementAreaUnit.Pixel)
			{
				return ihLIBumLsYWRsDniqSzXPHkreanc;
			}
			throw new NotImplementedException();
		}

		private void GuNmIlJmNSCKygRZEacWRlmeNaPSA()
		{
			lFWPICmzzKtBVSwhctofqGXDDnel = Vector2.zero;
			qwGxyaXxJLIdnpKUCJYJjimoRKCW = Vector2.zero;
		}

		private static float fXJiIkxOuYFuwxCjdaVnZiNFPPJH(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			return P_0.coordinateMode switch
			{
				AxisCoordinateMode.Absolute => P_0.value, 
				AxisCoordinateMode.Relative => P_1 + P_0.value * P_2, 
				_ => throw new NotImplementedException(), 
			};
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			return GetButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			return GetButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			return GetButton(button);
		}
	}
}

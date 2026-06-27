using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		public new sealed class Definition : PlayerController.Definition
		{
			public bool defaultToCenter = true;

			public bool clampToMovementArea = true;

			public ScreenRect movementArea = AoPoNxTNjMSpbZmlBLjdkkEMUtA;

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
				return HunSbzIOJAsozVkKELsZmAleaGPt(3, 3);
			}

			private static PlayerMouse HunSbzIOJAsozVkKELsZmAleaGPt(int P_0, int P_1)
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
		private sealed class iBTPxkTZHksrHBfnFdPFnCdwHsnEA
		{
			public static readonly iBTPxkTZHksrHBfnFdPFnCdwHsnEA _003C_003E9 = new iBTPxkTZHksrHBfnFdPFnCdwHsnEA();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool oGzdelpfvcfxeCOfvSTkgeXgJRzU(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.OKicQiBEstVKpOWENiehMfLqoJiFb;
				}
				return false;
			}

			internal bool LWSdXnmlPtUeugoKQAgTjatcZTGp(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.OKicQiBEstVKpOWENiehMfLqoJiFb;
				}
				return false;
			}
		}

		internal const bool vRBHjdnpmCAIDdNpIHJLJykSVMSD = true;

		internal const float OaAmphIDwbXwxfxIAtoivWswywaI = 1f;

		internal const bool OIMmbawraYDmrIXINsBaFLZIyAKo = true;

		internal const bool isPFQiqfrsByhjxKLUpPmDCysBPJ = true;

		internal const MovementAreaUnit IFWPDtBifFrBSnjLhpbxbfXFRDge = MovementAreaUnit.Screen;

		internal static readonly ScreenRect AoPoNxTNjMSpbZmlBLjdkkEMUtA = new ScreenRect(0f, 0f, 1f, 1f);

		private const int VfKjCwfjCyXtRXOvEmqUHAXpBXACA = 3;

		private const int qIasEDggSKbRMYmtBIEhMHGftgU = 3;

		internal const string CSOuUlJVLGUgbBzHizaWZEffeigE = "Movement";

		internal const string lbrqhrPNOTTTnFWAQFhySxIyNHHF = "Horizontal";

		internal const string PfKSlaVdxbcSUMoAEQGHnJiAHFnM = "Vertical";

		internal const string bqPMznayNLeXNtzgtRObKRJGwBwu = "Wheel";

		internal const string KtHeaUIBGxdDBPRRhLywCPSRYQUaA = "Wheel Horizontal";

		internal const string WYrAbQJKmtcGcsEWvgjntjRFXPrl = "Wheel Vertical";

		internal const string YNCfrqEDiKnZsthScqRQalQVZAi = "Left Button";

		internal const string bRsfcaXvclbVPaLrgvZqMtdhAFAaA = "Right Button";

		internal const string obpGEZczsXqZPHdlVQKaEpqlRlHTA = "Middle Button";

		private readonly int vrTabcjIIyHlcGVylfcvShrAfmOSA = -1;

		private readonly int AlCoNmvIsnZDHePHREXWyMBKzHvX = -1;

		private readonly int PgbrYswaFSzvotTRqqthaluRfaUY = -1;

		private readonly int bZgfYjAUsBJAxivLbGZNbbniGLOHb = -1;

		private readonly int bQCIHLOrwxundBtsgFFMJwnutZVy = -1;

		private readonly int RQxDpbMuDUbaJyVIfVIDAWXvebvU = -1;

		private bool gpOkGUAhiLQjPgtcGAZfmRoxliGJ;

		private Vector2 BDhgfbJilfRjJhkSpeCDVzFJWzDrA;

		private Vector2 CAUnHRaRMoBnFVBrUwpjapieqOck;

		private Vector2 dauvdpwfwYXvnUlBOCZkYKkRiMdz;

		private Vector2 NHAiCFiVtNaFFMqELCgbJfUhPNdgA;

		private Vector2 RpuDvvPtVIzZRsQvgjHHIkTjbGoT;

		private float hEfoSxufUbOJrOdQpwHASfxpigOG;

		private bool BkVGuYWEBdDvRyaTiBpXhgdkFPsN;

		private Action<Vector2> DpkSQBPuqwyHHbENvFkLslIRvTeV;

		private bool bedsXidxWOcCnPOPjFcGwfklguik;

		private ScreenRect GlGaTRMNUzBNUkiLvgcxHdqlqxnv;

		private bool fCEDCHzrDMuaHLgXssFOOhVKFVBA;

		private MovementAreaUnit pAmGTQhQJNVJLnqoKcJwXgAJuzur;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return false;
				}
				return bedsXidxWOcCnPOPjFcGwfklguik;
			}
			set
			{
				bedsXidxWOcCnPOPjFcGwfklguik = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return fCEDCHzrDMuaHLgXssFOOhVKFVBA;
			}
			set
			{
				fCEDCHzrDMuaHLgXssFOOhVKFVBA = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return default(ScreenRect);
				}
				return GlGaTRMNUzBNUkiLvgcxHdqlqxnv;
			}
			set
			{
				GlGaTRMNUzBNUkiLvgcxHdqlqxnv = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return MovementAreaUnit.Screen;
				}
				return pAmGTQhQJNVJLnqoKcJwXgAJuzur;
			}
			set
			{
				pAmGTQhQJNVJLnqoKcJwXgAJuzur = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return dauvdpwfwYXvnUlBOCZkYKkRiMdz;
			}
			set
			{
				hjfCbrSIdbocerggnXPsiEKGscJX(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return NHAiCFiVtNaFFMqELCgbJfUhPNdgA;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return RpuDvvPtVIzZRsQvgjHHIkTjbGoT;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (AlCoNmvIsnZDHePHREXWyMBKzHvX < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[AlCoNmvIsnZDHePHREXWyMBKzHvX];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (PgbrYswaFSzvotTRqqthaluRfaUY < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[PgbrYswaFSzvotTRqqthaluRfaUY];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (vrTabcjIIyHlcGVylfcvShrAfmOSA < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[vrTabcjIIyHlcGVylfcvShrAfmOSA];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (bZgfYjAUsBJAxivLbGZNbbniGLOHb < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[bZgfYjAUsBJAxivLbGZNbbniGLOHb];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (bQCIHLOrwxundBtsgFFMJwnutZVy < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[bQCIHLOrwxundBtsgFFMJwnutZVy];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				if (RQxDpbMuDUbaJyVIfVIDAWXvebvU < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[RQxDpbMuDUbaJyVIfVIDAWXvebvU];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return 0f;
				}
				return hEfoSxufUbOJrOdQpwHASfxpigOG;
			}
			set
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				hEfoSxufUbOJrOdQpwHASfxpigOG = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return false;
				}
				return BkVGuYWEBdDvRyaTiBpXhgdkFPsN;
			}
			set
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return;
				}
				BkVGuYWEBdDvRyaTiBpXhgdkFPsN = value;
				if (!value)
				{
					dQBCxJuDIjmqmqscqhLisSSFqIRP();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => dauvdpwfwYXvnUlBOCZkYKkRiMdz;

		Vector2 IMouseInputSource.screenPositionDelta => RpuDvvPtVIzZRsQvgjHHIkTjbGoT;

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (((IPlayerMouse)this).wheel == null)
				{
					return Vector2.zero;
				}
				return ((IPlayerMouse)this).wheel.value;
			}
		}

		bool IMouseInputSource.locked => false;

		event Action<Vector2> IPlayerMouse.ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else
				{
					DpkSQBPuqwyHHbENvFkLslIRvTeV = (Action<Vector2>)Delegate.Combine(DpkSQBPuqwyHHbENvFkLslIRvTeV, value);
				}
			}
			remove
			{
				DpkSQBPuqwyHHbENvFkLslIRvTeV = (Action<Vector2>)Delegate.Remove(DpkSQBPuqwyHHbENvFkLslIRvTeV, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			bedsXidxWOcCnPOPjFcGwfklguik = P_0.defaultToCenter;
			fCEDCHzrDMuaHLgXssFOOhVKFVBA = P_0.clampToMovementArea;
			GlGaTRMNUzBNUkiLvgcxHdqlqxnv = P_0.movementArea;
			pAmGTQhQJNVJLnqoKcJwXgAJuzur = P_0.movementAreaUnit;
			hEfoSxufUbOJrOdQpwHASfxpigOG = P_0.pointerSpeed;
			BkVGuYWEBdDvRyaTiBpXhgdkFPsN = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						AlCoNmvIsnZDHePHREXWyMBKzHvX = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						PgbrYswaFSzvotTRqqthaluRfaUY = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (vrTabcjIIyHlcGVylfcvShrAfmOSA < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					vrTabcjIIyHlcGVylfcvShrAfmOSA = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						bZgfYjAUsBJAxivLbGZNbbniGLOHb = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						bQCIHLOrwxundBtsgFFMJwnutZVy = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						RQxDpbMuDUbaJyVIfVIDAWXvebvU = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (vrTabcjIIyHlcGVylfcvShrAfmOSA < 0)
			{
				int num4 = PlayerController.epXCAyhmsanjwlKyWerCHErytnxZ(base.Rewired_002EIPlayerController_002Eaxes, iBTPxkTZHksrHBfnFdPFnCdwHsnEA._003C_003E9.oGzdelpfvcfxeCOfvSTkgeXgJRzU, 1);
				int num5 = PlayerController.epXCAyhmsanjwlKyWerCHErytnxZ(base.Rewired_002EIPlayerController_002Eaxes, iBTPxkTZHksrHBfnFdPFnCdwHsnEA._003C_003E9.LWSdXnmlPtUeugoKQAgTjatcZTGp, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					qqFUsNYFvJuhFeUqKyzsHdwRdDxG(mouseWheel);
					vrTabcjIIyHlcGVylfcvShrAfmOSA = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						qqFUsNYFvJuhFeUqKyzsHdwRdDxG(element);
						mouseWheel.aNFbxGiXWeWMXzEFpIdEclzKnWwwA(element);
						mouseWheel.aNFbxGiXWeWMXzEFpIdEclzKnWwwA((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.aNFbxGiXWeWMXzEFpIdEclzKnWwwA(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.aNFbxGiXWeWMXzEFpIdEclzKnWwwA(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (bedsXidxWOcCnPOPjFcGwfklguik)
			{
				ScreenRect screenRect = YUelSMTNHlxPRJaCNHMMeNiGZpMc();
				dauvdpwfwYXvnUlBOCZkYKkRiMdz = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				dauvdpwfwYXvnUlBOCZkYKkRiMdz = Vector2.zero;
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
			if (BkVGuYWEBdDvRyaTiBpXhgdkFPsN && (player = base.MDDgkwbJiEBbIwTqycYiMjItJMYL) != null)
			{
				if (!player.controllers.hasMouse)
				{
					dQBCxJuDIjmqmqscqhLisSSFqIRP();
				}
				else
				{
					BDhgfbJilfRjJhkSpeCDVzFJWzDrA = ReInput.controllers.Mouse.screenPosition;
					if (BDhgfbJilfRjJhkSpeCDVzFJWzDrA.x != CAUnHRaRMoBnFVBrUwpjapieqOck.x || BDhgfbJilfRjJhkSpeCDVzFJWzDrA.y != CAUnHRaRMoBnFVBrUwpjapieqOck.y)
					{
						dauvdpwfwYXvnUlBOCZkYKkRiMdz.x = BDhgfbJilfRjJhkSpeCDVzFJWzDrA.x;
						dauvdpwfwYXvnUlBOCZkYKkRiMdz.y = BDhgfbJilfRjJhkSpeCDVzFJWzDrA.y;
					}
					CAUnHRaRMoBnFVBrUwpjapieqOck.x = BDhgfbJilfRjJhkSpeCDVzFJWzDrA.x;
					CAUnHRaRMoBnFVBrUwpjapieqOck.y = BDhgfbJilfRjJhkSpeCDVzFJWzDrA.y;
				}
			}
			if (AlCoNmvIsnZDHePHREXWyMBKzHvX >= 0)
			{
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.x = oJXQhBCcnQbZRaVmQaavKpJIyKqrA(base.Rewired_002EIPlayerController_002Eaxes[AlCoNmvIsnZDHePHREXWyMBKzHvX], dauvdpwfwYXvnUlBOCZkYKkRiMdz.x, hEfoSxufUbOJrOdQpwHASfxpigOG);
			}
			if (PgbrYswaFSzvotTRqqthaluRfaUY >= 0)
			{
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.y = oJXQhBCcnQbZRaVmQaavKpJIyKqrA(base.Rewired_002EIPlayerController_002Eaxes[PgbrYswaFSzvotTRqqthaluRfaUY], dauvdpwfwYXvnUlBOCZkYKkRiMdz.y, hEfoSxufUbOJrOdQpwHASfxpigOG);
			}
			hjfCbrSIdbocerggnXPsiEKGscJX(dauvdpwfwYXvnUlBOCZkYKkRiMdz);
			RpuDvvPtVIzZRsQvgjHHIkTjbGoT.x = dauvdpwfwYXvnUlBOCZkYKkRiMdz.x - NHAiCFiVtNaFFMqELCgbJfUhPNdgA.x;
			RpuDvvPtVIzZRsQvgjHHIkTjbGoT.y = dauvdpwfwYXvnUlBOCZkYKkRiMdz.y - NHAiCFiVtNaFFMqELCgbJfUhPNdgA.y;
			gpOkGUAhiLQjPgtcGAZfmRoxliGJ = dauvdpwfwYXvnUlBOCZkYKkRiMdz.x != NHAiCFiVtNaFFMqELCgbJfUhPNdgA.x || dauvdpwfwYXvnUlBOCZkYKkRiMdz.y != NHAiCFiVtNaFFMqELCgbJfUhPNdgA.y;
			NHAiCFiVtNaFFMqELCgbJfUhPNdgA.x = dauvdpwfwYXvnUlBOCZkYKkRiMdz.x;
			NHAiCFiVtNaFFMqELCgbJfUhPNdgA.y = dauvdpwfwYXvnUlBOCZkYKkRiMdz.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (gpOkGUAhiLQjPgtcGAZfmRoxliGJ && DpkSQBPuqwyHHbENvFkLslIRvTeV != null)
			{
				try
				{
					DpkSQBPuqwyHHbENvFkLslIRvTeV(dauvdpwfwYXvnUlBOCZkYKkRiMdz);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				gpOkGUAhiLQjPgtcGAZfmRoxliGJ = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			NHAiCFiVtNaFFMqELCgbJfUhPNdgA = dauvdpwfwYXvnUlBOCZkYKkRiMdz;
			RpuDvvPtVIzZRsQvgjHHIkTjbGoT = Vector2.zero;
			dQBCxJuDIjmqmqscqhLisSSFqIRP();
			gpOkGUAhiLQjPgtcGAZfmRoxliGJ = false;
		}

		private void hjfCbrSIdbocerggnXPsiEKGscJX(Vector2 P_0)
		{
			if (!fCEDCHzrDMuaHLgXssFOOhVKFVBA)
			{
				dauvdpwfwYXvnUlBOCZkYKkRiMdz = P_0;
				return;
			}
			if (pAmGTQhQJNVJLnqoKcJwXgAJuzur == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.x = Mathf.Clamp(P_0.x, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.xMin * num, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.xMax * num);
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.y = Mathf.Clamp(P_0.y, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.yMin * num2, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.yMax * num2);
				return;
			}
			if (pAmGTQhQJNVJLnqoKcJwXgAJuzur == MovementAreaUnit.Pixel)
			{
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.x = Mathf.Clamp(P_0.x, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.xMin, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.xMax);
				dauvdpwfwYXvnUlBOCZkYKkRiMdz.y = Mathf.Clamp(P_0.y, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.yMin, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect YUelSMTNHlxPRJaCNHMMeNiGZpMc()
		{
			if (pAmGTQhQJNVJLnqoKcJwXgAJuzur == MovementAreaUnit.Screen)
			{
				return new ScreenRect(GlGaTRMNUzBNUkiLvgcxHdqlqxnv.xMin * (float)Screen.width, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.yMin * (float)Screen.height, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.width * (float)Screen.width, GlGaTRMNUzBNUkiLvgcxHdqlqxnv.height * (float)Screen.height);
			}
			if (pAmGTQhQJNVJLnqoKcJwXgAJuzur == MovementAreaUnit.Pixel)
			{
				return GlGaTRMNUzBNUkiLvgcxHdqlqxnv;
			}
			throw new NotImplementedException();
		}

		private void dQBCxJuDIjmqmqscqhLisSSFqIRP()
		{
			BDhgfbJilfRjJhkSpeCDVzFJWzDrA = Vector2.zero;
			CAUnHRaRMoBnFVBrUwpjapieqOck = Vector2.zero;
		}

		private static float oJXQhBCcnQbZRaVmQaavKpJIyKqrA(Axis P_0, float P_1, float P_2)
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

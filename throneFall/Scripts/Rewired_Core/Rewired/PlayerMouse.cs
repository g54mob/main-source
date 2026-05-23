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

			public ScreenRect movementArea = aPDUuXkYRTwpkajUrwAyAMWdauuhA;

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
				return tmkDfOXdLUfTDbQXNQCohBVrOcdeA(3, 3);
			}

			private static PlayerMouse tmkDfOXdLUfTDbQXNQCohBVrOcdeA(int P_0, int P_1)
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
		private sealed class QQWSXPSFDgiJvIIcEzIkYUPfPWNS
		{
			public static readonly QQWSXPSFDgiJvIIcEzIkYUPfPWNS _003C_003E9 = new QQWSXPSFDgiJvIIcEzIkYUPfPWNS();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool WXyGCMeLngLWYHnmuIMRTwnvHxJU(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.oVlpRVDypdrPXVPzItMrEjFflHQD;
				}
				return false;
			}

			internal bool lNRQeItRFldDYvxPNPbeYxNfQniQ(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.oVlpRVDypdrPXVPzItMrEjFflHQD;
				}
				return false;
			}
		}

		internal const bool HmAyyMaavMcfxiaUFiAwQgYLxpehA = true;

		internal const float aSJjJEFIizdoVKmVZKmRDKUnzAKwA = 1f;

		internal const bool oRJKFFxxwEZeFLDRMiCPknnLjayY = true;

		internal const bool GNOEgZbxxomyFSiJMnZocJalnEfqA = true;

		internal const MovementAreaUnit mZFWmcYLiNrIoaqsadiCaCTEHdILA = MovementAreaUnit.Screen;

		internal static readonly ScreenRect aPDUuXkYRTwpkajUrwAyAMWdauuhA = new ScreenRect(0f, 0f, 1f, 1f);

		private const int lUHpqPoWEiWZjQNeNfMbgPvivXaI = 3;

		private const int QuJTBfOloABSlXOfcLLtSOrNgVWU = 3;

		internal const string cHNxNdKrXOFjMKtgrxkJqOkaqAIw = "Movement";

		internal const string VLmhDKQdUTkyPIuTTeUBvRejHjvq = "Horizontal";

		internal const string trHnjPOExdubgNZXBRVsQFCXhQRL = "Vertical";

		internal const string FeSKjQbeXBawnwAniuNWzjlTNhSv = "Wheel";

		internal const string yYAXalODIfqRpSMEizqTaLuAmZmi = "Wheel Horizontal";

		internal const string itoYbhWmKvPVAnBZgNdIQEfQAjJhA = "Wheel Vertical";

		internal const string gRCtnMdwTwSdhlViFpfoxDZZUbqq = "Left Button";

		internal const string PxlVsJEFqtmilMbejCYFfsNeKnun = "Right Button";

		internal const string YFqboyquQFwylymfIFwVUYqoFpzd = "Middle Button";

		private readonly int ZdWqEByCGkOGOOsbgibIOcVNZWkV = -1;

		private readonly int wYHqpPeEybicprjOQUEbPodFhnZW = -1;

		private readonly int xvwAhRhuBEgUKggWhSqELNUCcYeY = -1;

		private readonly int TkhfSGJDmFbwXtqKoYqcEWJvtWaj = -1;

		private readonly int BZXkzsROytCuDQbsbWedVeHfrdzh = -1;

		private readonly int hgqACGDOVALQnlFFiGHchgngnHLv = -1;

		private bool CdNfJdcJgXfvpSnvHdTGwHIqWZcIA;

		private Vector2 tocSySlhVpGqrpDOeHsaYpAKRbxg;

		private Vector2 ymZhEslxYmfqvIbqXgrAkREdyEMPA;

		private Vector2 ZFvWCwlgOWCVLBYlNSVUdKjCkRXb;

		private Vector2 rVHrZeddtXmLzXlRElWUQQmkhSHh;

		private Vector2 vbxQYSIDiGmXvpgMnSbyfdWgsTKE;

		private float PTmaBYHvjdrnHFrguGnzdlVwfAwEb;

		private bool tUQEdnBgHlfypfOGzgMybQHdppSXA;

		private Action<Vector2> zAhjnqSjgscBnyjOqGpyERgOntSgA;

		private bool VwaiRRmIWQfFPaIIguEhLDSacQMpA;

		private ScreenRect aDFNocPdWxFiwixGcStQLyIgJNXSA;

		private bool DGVtcteTzPiXOSzlEGzgzbTQqjbQ;

		private MovementAreaUnit PJhePzioNZeCtkolPEnHqIgATPMh;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return false;
				}
				return VwaiRRmIWQfFPaIIguEhLDSacQMpA;
			}
			set
			{
				VwaiRRmIWQfFPaIIguEhLDSacQMpA = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return DGVtcteTzPiXOSzlEGzgzbTQqjbQ;
			}
			set
			{
				DGVtcteTzPiXOSzlEGzgzbTQqjbQ = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return default(ScreenRect);
				}
				return aDFNocPdWxFiwixGcStQLyIgJNXSA;
			}
			set
			{
				aDFNocPdWxFiwixGcStQLyIgJNXSA = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return MovementAreaUnit.Screen;
				}
				return PJhePzioNZeCtkolPEnHqIgATPMh;
			}
			set
			{
				PJhePzioNZeCtkolPEnHqIgATPMh = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return ZFvWCwlgOWCVLBYlNSVUdKjCkRXb;
			}
			set
			{
				PacqSELMnbIDMkrncaOZbVgDHUrFb(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return rVHrZeddtXmLzXlRElWUQQmkhSHh;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return vbxQYSIDiGmXvpgMnSbyfdWgsTKE;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (wYHqpPeEybicprjOQUEbPodFhnZW < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[wYHqpPeEybicprjOQUEbPodFhnZW];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (xvwAhRhuBEgUKggWhSqELNUCcYeY < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[xvwAhRhuBEgUKggWhSqELNUCcYeY];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (ZdWqEByCGkOGOOsbgibIOcVNZWkV < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[ZdWqEByCGkOGOOsbgibIOcVNZWkV];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (TkhfSGJDmFbwXtqKoYqcEWJvtWaj < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[TkhfSGJDmFbwXtqKoYqcEWJvtWaj];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (BZXkzsROytCuDQbsbWedVeHfrdzh < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[BZXkzsROytCuDQbsbWedVeHfrdzh];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				if (hgqACGDOVALQnlFFiGHchgngnHLv < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[hgqACGDOVALQnlFFiGHchgngnHLv];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return 0f;
				}
				return PTmaBYHvjdrnHFrguGnzdlVwfAwEb;
			}
			set
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				PTmaBYHvjdrnHFrguGnzdlVwfAwEb = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return false;
				}
				return tUQEdnBgHlfypfOGzgMybQHdppSXA;
			}
			set
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return;
				}
				tUQEdnBgHlfypfOGzgMybQHdppSXA = value;
				if (!value)
				{
					NbESOklkUzCPGejzbrMZPXgGlexcA();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => ZFvWCwlgOWCVLBYlNSVUdKjCkRXb;

		Vector2 IMouseInputSource.screenPositionDelta => vbxQYSIDiGmXvpgMnSbyfdWgsTKE;

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
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else
				{
					zAhjnqSjgscBnyjOqGpyERgOntSgA = (Action<Vector2>)Delegate.Combine(zAhjnqSjgscBnyjOqGpyERgOntSgA, value);
				}
			}
			remove
			{
				zAhjnqSjgscBnyjOqGpyERgOntSgA = (Action<Vector2>)Delegate.Remove(zAhjnqSjgscBnyjOqGpyERgOntSgA, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			VwaiRRmIWQfFPaIIguEhLDSacQMpA = P_0.defaultToCenter;
			DGVtcteTzPiXOSzlEGzgzbTQqjbQ = P_0.clampToMovementArea;
			aDFNocPdWxFiwixGcStQLyIgJNXSA = P_0.movementArea;
			PJhePzioNZeCtkolPEnHqIgATPMh = P_0.movementAreaUnit;
			PTmaBYHvjdrnHFrguGnzdlVwfAwEb = P_0.pointerSpeed;
			tUQEdnBgHlfypfOGzgMybQHdppSXA = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						wYHqpPeEybicprjOQUEbPodFhnZW = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						xvwAhRhuBEgUKggWhSqELNUCcYeY = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (ZdWqEByCGkOGOOsbgibIOcVNZWkV < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					ZdWqEByCGkOGOOsbgibIOcVNZWkV = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						TkhfSGJDmFbwXtqKoYqcEWJvtWaj = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						BZXkzsROytCuDQbsbWedVeHfrdzh = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						hgqACGDOVALQnlFFiGHchgngnHLv = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (ZdWqEByCGkOGOOsbgibIOcVNZWkV < 0)
			{
				int num4 = PlayerController.WZCQtDeIkocIIcezZRqfttHjSTHZ(base.Rewired_002EIPlayerController_002Eaxes, QQWSXPSFDgiJvIIcEzIkYUPfPWNS._003C_003E9.WXyGCMeLngLWYHnmuIMRTwnvHxJU, 1);
				int num5 = PlayerController.WZCQtDeIkocIIcezZRqfttHjSTHZ(base.Rewired_002EIPlayerController_002Eaxes, QQWSXPSFDgiJvIIcEzIkYUPfPWNS._003C_003E9.lNRQeItRFldDYvxPNPbeYxNfQniQ, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					MeCHdwNSzDfJpftfRyfTcPNKqZLR(mouseWheel);
					ZdWqEByCGkOGOOsbgibIOcVNZWkV = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						MeCHdwNSzDfJpftfRyfTcPNKqZLR(element);
						mouseWheel.CsGYmrhCgstajekEmgarUdZZseEK(element);
						mouseWheel.CsGYmrhCgstajekEmgarUdZZseEK((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.CsGYmrhCgstajekEmgarUdZZseEK(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.CsGYmrhCgstajekEmgarUdZZseEK(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (VwaiRRmIWQfFPaIIguEhLDSacQMpA)
			{
				ScreenRect screenRect = gkbYUbCGXnWEvGOxWsQfHfjPojFv();
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb = Vector2.zero;
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
			if (tUQEdnBgHlfypfOGzgMybQHdppSXA && (player = base.eOGHRXaBmIViwhvhzLjDfkqkbzsp) != null)
			{
				if (!player.controllers.hasMouse)
				{
					NbESOklkUzCPGejzbrMZPXgGlexcA();
				}
				else
				{
					tocSySlhVpGqrpDOeHsaYpAKRbxg = ReInput.controllers.Mouse.screenPosition;
					if (tocSySlhVpGqrpDOeHsaYpAKRbxg.x != ymZhEslxYmfqvIbqXgrAkREdyEMPA.x || tocSySlhVpGqrpDOeHsaYpAKRbxg.y != ymZhEslxYmfqvIbqXgrAkREdyEMPA.y)
					{
						ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x = tocSySlhVpGqrpDOeHsaYpAKRbxg.x;
						ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y = tocSySlhVpGqrpDOeHsaYpAKRbxg.y;
					}
					ymZhEslxYmfqvIbqXgrAkREdyEMPA.x = tocSySlhVpGqrpDOeHsaYpAKRbxg.x;
					ymZhEslxYmfqvIbqXgrAkREdyEMPA.y = tocSySlhVpGqrpDOeHsaYpAKRbxg.y;
				}
			}
			if (wYHqpPeEybicprjOQUEbPodFhnZW >= 0)
			{
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x = WYAbAyVTfIJsdlPjLLbOSgzLfkKEA(base.Rewired_002EIPlayerController_002Eaxes[wYHqpPeEybicprjOQUEbPodFhnZW], ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x, PTmaBYHvjdrnHFrguGnzdlVwfAwEb);
			}
			if (xvwAhRhuBEgUKggWhSqELNUCcYeY >= 0)
			{
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y = WYAbAyVTfIJsdlPjLLbOSgzLfkKEA(base.Rewired_002EIPlayerController_002Eaxes[xvwAhRhuBEgUKggWhSqELNUCcYeY], ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y, PTmaBYHvjdrnHFrguGnzdlVwfAwEb);
			}
			PacqSELMnbIDMkrncaOZbVgDHUrFb(ZFvWCwlgOWCVLBYlNSVUdKjCkRXb);
			vbxQYSIDiGmXvpgMnSbyfdWgsTKE.x = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x - rVHrZeddtXmLzXlRElWUQQmkhSHh.x;
			vbxQYSIDiGmXvpgMnSbyfdWgsTKE.y = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y - rVHrZeddtXmLzXlRElWUQQmkhSHh.y;
			CdNfJdcJgXfvpSnvHdTGwHIqWZcIA = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x != rVHrZeddtXmLzXlRElWUQQmkhSHh.x || ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y != rVHrZeddtXmLzXlRElWUQQmkhSHh.y;
			rVHrZeddtXmLzXlRElWUQQmkhSHh.x = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x;
			rVHrZeddtXmLzXlRElWUQQmkhSHh.y = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (CdNfJdcJgXfvpSnvHdTGwHIqWZcIA && zAhjnqSjgscBnyjOqGpyERgOntSgA != null)
			{
				try
				{
					zAhjnqSjgscBnyjOqGpyERgOntSgA(ZFvWCwlgOWCVLBYlNSVUdKjCkRXb);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				CdNfJdcJgXfvpSnvHdTGwHIqWZcIA = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			rVHrZeddtXmLzXlRElWUQQmkhSHh = ZFvWCwlgOWCVLBYlNSVUdKjCkRXb;
			vbxQYSIDiGmXvpgMnSbyfdWgsTKE = Vector2.zero;
			NbESOklkUzCPGejzbrMZPXgGlexcA();
			CdNfJdcJgXfvpSnvHdTGwHIqWZcIA = false;
		}

		private void PacqSELMnbIDMkrncaOZbVgDHUrFb(Vector2 P_0)
		{
			if (!DGVtcteTzPiXOSzlEGzgzbTQqjbQ)
			{
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb = P_0;
				return;
			}
			if (PJhePzioNZeCtkolPEnHqIgATPMh == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x = Mathf.Clamp(P_0.x, aDFNocPdWxFiwixGcStQLyIgJNXSA.xMin * num, aDFNocPdWxFiwixGcStQLyIgJNXSA.xMax * num);
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y = Mathf.Clamp(P_0.y, aDFNocPdWxFiwixGcStQLyIgJNXSA.yMin * num2, aDFNocPdWxFiwixGcStQLyIgJNXSA.yMax * num2);
				return;
			}
			if (PJhePzioNZeCtkolPEnHqIgATPMh == MovementAreaUnit.Pixel)
			{
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.x = Mathf.Clamp(P_0.x, aDFNocPdWxFiwixGcStQLyIgJNXSA.xMin, aDFNocPdWxFiwixGcStQLyIgJNXSA.xMax);
				ZFvWCwlgOWCVLBYlNSVUdKjCkRXb.y = Mathf.Clamp(P_0.y, aDFNocPdWxFiwixGcStQLyIgJNXSA.yMin, aDFNocPdWxFiwixGcStQLyIgJNXSA.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect gkbYUbCGXnWEvGOxWsQfHfjPojFv()
		{
			if (PJhePzioNZeCtkolPEnHqIgATPMh == MovementAreaUnit.Screen)
			{
				return new ScreenRect(aDFNocPdWxFiwixGcStQLyIgJNXSA.xMin * (float)Screen.width, aDFNocPdWxFiwixGcStQLyIgJNXSA.yMin * (float)Screen.height, aDFNocPdWxFiwixGcStQLyIgJNXSA.width * (float)Screen.width, aDFNocPdWxFiwixGcStQLyIgJNXSA.height * (float)Screen.height);
			}
			if (PJhePzioNZeCtkolPEnHqIgATPMh == MovementAreaUnit.Pixel)
			{
				return aDFNocPdWxFiwixGcStQLyIgJNXSA;
			}
			throw new NotImplementedException();
		}

		private void NbESOklkUzCPGejzbrMZPXgGlexcA()
		{
			tocSySlhVpGqrpDOeHsaYpAKRbxg = Vector2.zero;
			ymZhEslxYmfqvIbqXgrAkREdyEMPA = Vector2.zero;
		}

		private static float WYAbAyVTfIJsdlPjLLbOSgzLfkKEA(Axis P_0, float P_1, float P_2)
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

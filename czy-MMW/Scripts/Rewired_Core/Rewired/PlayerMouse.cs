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

			public ScreenRect movementArea = DboCGVtuXYRYCdFUiOJdlHWHpiKy;

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
				return CwDJBIQdZHuJfXqTGTcvsFLNHsTP(3, 3);
			}

			private static PlayerMouse CwDJBIQdZHuJfXqTGTcvsFLNHsTP(int P_0, int P_1)
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
		private sealed class vFruuHFMNtwiLJRcDsVplNDLcIpV
		{
			public static readonly vFruuHFMNtwiLJRcDsVplNDLcIpV _003C_003E9 = new vFruuHFMNtwiLJRcDsVplNDLcIpV();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool dKZglUdxHrtYsKmKxNWYyrcLfPpC(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.RlYkHLUTywqWzOeZDjmVjgzZNxit;
				}
				return false;
			}

			internal bool ImOSAAsTkswoxsPCLalbpFBBbUdb(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.RlYkHLUTywqWzOeZDjmVjgzZNxit;
				}
				return false;
			}
		}

		internal const bool gynCgStxvNMJDpdGIFLzJgIzZlIW = true;

		internal const float PdazyMAsgiHihfDNYzAGtNULIAuj = 1f;

		internal const bool DIeyqBcMmVdmdDMRTbBEcJrAleOWb = true;

		internal const bool dWzOwNciptDRxjDZVOQtabwNUNPi = true;

		internal const MovementAreaUnit NLsQqkZgaKKjGlMkzVnHvRDmLbsO = MovementAreaUnit.Screen;

		internal static readonly ScreenRect DboCGVtuXYRYCdFUiOJdlHWHpiKy = new ScreenRect(0f, 0f, 1f, 1f);

		private const int WLkbRJdxKnjzDFZcOkkmbBpURhSNA = 3;

		private const int tFgdvfJdwPjdDGLfbEMcjTzhTHcy = 3;

		internal const string HSadKvPALDDKeNPyqNnKVrsOEUqW = "Movement";

		internal const string iYVpRQNBSEDFhDQTMXKAMjgFGvDr = "Horizontal";

		internal const string CbmXgHDbhsSTCADMAUdjxFGbrrng = "Vertical";

		internal const string kSxUwSchVGPVVvebrGITMQdnbloFA = "Wheel";

		internal const string TorDtzVHMuaFTFpGlnuEBlusEcUY = "Wheel Horizontal";

		internal const string PFBbDnNtYkhsiaFHrXgDbajePzrR = "Wheel Vertical";

		internal const string PDpbFQwNNlCANCwqEJunmSXjUfQAA = "Left Button";

		internal const string onAHvTPFygCXNXPmyyFWOeHQHxGz = "Right Button";

		internal const string pwBeLsnayIyJHfQiDGGAAxYOaTPqA = "Middle Button";

		private readonly int wnVqBjlExApyFJrlUcPvcZrOIEX = -1;

		private readonly int BqiYMRpImifLXgMOZcRoDybvfpzsA = -1;

		private readonly int GlXTPLyoRDJtsnJGiExZCoSozSUaA = -1;

		private readonly int eBKiVWYccSHYxcrGvjTjkbXTCvEUA = -1;

		private readonly int oomeMsFCisHzzFDdbsTiYcRjVhPkb = -1;

		private readonly int IVDEwEiYTRPqLeyHjeYhuEnEVJxRA = -1;

		private bool bNanwnAIyMONFsTpOEOBivUORmIF;

		private Vector2 OfPegEinpsAnTyhNhVCdfSnoRLRt;

		private Vector2 ByiorcsHUfBpRPYaIsaJmHCPdUyq;

		private Vector2 uUMrsOoJcHKxnKsKAOVKUqIcpahN;

		private Vector2 WogERykklEPJFWUZFOcBFhiGfrlDb;

		private Vector2 UpWjqMFyZPtHTeAoqyLzOmpISouS;

		private float gBHpYMqozsUmhMqafeqyKdZSWpQK;

		private bool QhxNSxYFJqPiNkaYkiVtbyVPubsm;

		private Action<Vector2> SmIFmuPonraVPjUFloErcHiydVsF;

		private bool ihLnrZxKyTmmvPUnrPJkeKSEQsuc;

		private ScreenRect BNiIdoSAEkLvIyCmjeMFDAkATAbC;

		private bool mqaWTtbdnYEuuPpvTEofKWZyyrLPA;

		private MovementAreaUnit azGgSpdnXAjPRAlvWYLKkBqouJcuA;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return false;
				}
				return ihLnrZxKyTmmvPUnrPJkeKSEQsuc;
			}
			set
			{
				ihLnrZxKyTmmvPUnrPJkeKSEQsuc = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return mqaWTtbdnYEuuPpvTEofKWZyyrLPA;
			}
			set
			{
				mqaWTtbdnYEuuPpvTEofKWZyyrLPA = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return default(ScreenRect);
				}
				return BNiIdoSAEkLvIyCmjeMFDAkATAbC;
			}
			set
			{
				BNiIdoSAEkLvIyCmjeMFDAkATAbC = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return MovementAreaUnit.Screen;
				}
				return azGgSpdnXAjPRAlvWYLKkBqouJcuA;
			}
			set
			{
				azGgSpdnXAjPRAlvWYLKkBqouJcuA = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return uUMrsOoJcHKxnKsKAOVKUqIcpahN;
			}
			set
			{
				oHoyMCgzgsuexntxKTSeyqpMULW(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return WogERykklEPJFWUZFOcBFhiGfrlDb;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return UpWjqMFyZPtHTeAoqyLzOmpISouS;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (BqiYMRpImifLXgMOZcRoDybvfpzsA < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[BqiYMRpImifLXgMOZcRoDybvfpzsA];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (GlXTPLyoRDJtsnJGiExZCoSozSUaA < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[GlXTPLyoRDJtsnJGiExZCoSozSUaA];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (wnVqBjlExApyFJrlUcPvcZrOIEX < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[wnVqBjlExApyFJrlUcPvcZrOIEX];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (eBKiVWYccSHYxcrGvjTjkbXTCvEUA < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[eBKiVWYccSHYxcrGvjTjkbXTCvEUA];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (oomeMsFCisHzzFDdbsTiYcRjVhPkb < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[oomeMsFCisHzzFDdbsTiYcRjVhPkb];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return null;
				}
				if (IVDEwEiYTRPqLeyHjeYhuEnEVJxRA < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[IVDEwEiYTRPqLeyHjeYhuEnEVJxRA];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return 0f;
				}
				return gBHpYMqozsUmhMqafeqyKdZSWpQK;
			}
			set
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				gBHpYMqozsUmhMqafeqyKdZSWpQK = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return false;
				}
				return QhxNSxYFJqPiNkaYkiVtbyVPubsm;
			}
			set
			{
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
					return;
				}
				QhxNSxYFJqPiNkaYkiVtbyVPubsm = value;
				if (!value)
				{
					mjhkidoSnuaslutcoTUSguSysXNb();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => uUMrsOoJcHKxnKsKAOVKUqIcpahN;

		Vector2 IMouseInputSource.screenPositionDelta => UpWjqMFyZPtHTeAoqyLzOmpISouS;

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
				if (ReInput._id != DGnEkWBJwKSeEfmWAgVsYGPpHltFA)
				{
					ReInput.CheckInitialized(DGnEkWBJwKSeEfmWAgVsYGPpHltFA);
				}
				else
				{
					SmIFmuPonraVPjUFloErcHiydVsF = (Action<Vector2>)Delegate.Combine(SmIFmuPonraVPjUFloErcHiydVsF, value);
				}
			}
			remove
			{
				SmIFmuPonraVPjUFloErcHiydVsF = (Action<Vector2>)Delegate.Remove(SmIFmuPonraVPjUFloErcHiydVsF, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			ihLnrZxKyTmmvPUnrPJkeKSEQsuc = P_0.defaultToCenter;
			mqaWTtbdnYEuuPpvTEofKWZyyrLPA = P_0.clampToMovementArea;
			BNiIdoSAEkLvIyCmjeMFDAkATAbC = P_0.movementArea;
			azGgSpdnXAjPRAlvWYLKkBqouJcuA = P_0.movementAreaUnit;
			gBHpYMqozsUmhMqafeqyKdZSWpQK = P_0.pointerSpeed;
			QhxNSxYFJqPiNkaYkiVtbyVPubsm = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						BqiYMRpImifLXgMOZcRoDybvfpzsA = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						GlXTPLyoRDJtsnJGiExZCoSozSUaA = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (wnVqBjlExApyFJrlUcPvcZrOIEX < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					wnVqBjlExApyFJrlUcPvcZrOIEX = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						eBKiVWYccSHYxcrGvjTjkbXTCvEUA = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						oomeMsFCisHzzFDdbsTiYcRjVhPkb = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						IVDEwEiYTRPqLeyHjeYhuEnEVJxRA = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (wnVqBjlExApyFJrlUcPvcZrOIEX < 0)
			{
				int num4 = PlayerController.lKhRPqnykfpsRxjOCzoGAJgPJdrc(base.Rewired_002EIPlayerController_002Eaxes, vFruuHFMNtwiLJRcDsVplNDLcIpV._003C_003E9.dKZglUdxHrtYsKmKxNWYyrcLfPpC, 1);
				int num5 = PlayerController.lKhRPqnykfpsRxjOCzoGAJgPJdrc(base.Rewired_002EIPlayerController_002Eaxes, vFruuHFMNtwiLJRcDsVplNDLcIpV._003C_003E9.ImOSAAsTkswoxsPCLalbpFBBbUdb, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					vonHLgKTlCsLPcSfCsMMHrTyRObI(mouseWheel);
					wnVqBjlExApyFJrlUcPvcZrOIEX = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						vonHLgKTlCsLPcSfCsMMHrTyRObI(element);
						mouseWheel.dkfjsbgYGxUEJxKMvFxwHbDnlskY(element);
						mouseWheel.dkfjsbgYGxUEJxKMvFxwHbDnlskY((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.dkfjsbgYGxUEJxKMvFxwHbDnlskY(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.dkfjsbgYGxUEJxKMvFxwHbDnlskY(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (ihLnrZxKyTmmvPUnrPJkeKSEQsuc)
			{
				ScreenRect screenRect = LvOqPrPbNqCnFDIhBfRoiebpatvRA();
				uUMrsOoJcHKxnKsKAOVKUqIcpahN = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				uUMrsOoJcHKxnKsKAOVKUqIcpahN = Vector2.zero;
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
			if (QhxNSxYFJqPiNkaYkiVtbyVPubsm && (player = base.DbfpgXxKeDTUSktfwyjEKpeOvbCI) != null)
			{
				if (!player.controllers.hasMouse)
				{
					mjhkidoSnuaslutcoTUSguSysXNb();
				}
				else
				{
					OfPegEinpsAnTyhNhVCdfSnoRLRt = ReInput.controllers.Mouse.screenPosition;
					if (OfPegEinpsAnTyhNhVCdfSnoRLRt.x != ByiorcsHUfBpRPYaIsaJmHCPdUyq.x || OfPegEinpsAnTyhNhVCdfSnoRLRt.y != ByiorcsHUfBpRPYaIsaJmHCPdUyq.y)
					{
						uUMrsOoJcHKxnKsKAOVKUqIcpahN.x = OfPegEinpsAnTyhNhVCdfSnoRLRt.x;
						uUMrsOoJcHKxnKsKAOVKUqIcpahN.y = OfPegEinpsAnTyhNhVCdfSnoRLRt.y;
					}
					ByiorcsHUfBpRPYaIsaJmHCPdUyq.x = OfPegEinpsAnTyhNhVCdfSnoRLRt.x;
					ByiorcsHUfBpRPYaIsaJmHCPdUyq.y = OfPegEinpsAnTyhNhVCdfSnoRLRt.y;
				}
			}
			if (BqiYMRpImifLXgMOZcRoDybvfpzsA >= 0)
			{
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.x = zmtTsaWBlTsDVgJbIEiJfzpjHgou(base.Rewired_002EIPlayerController_002Eaxes[BqiYMRpImifLXgMOZcRoDybvfpzsA], uUMrsOoJcHKxnKsKAOVKUqIcpahN.x, gBHpYMqozsUmhMqafeqyKdZSWpQK);
			}
			if (GlXTPLyoRDJtsnJGiExZCoSozSUaA >= 0)
			{
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.y = zmtTsaWBlTsDVgJbIEiJfzpjHgou(base.Rewired_002EIPlayerController_002Eaxes[GlXTPLyoRDJtsnJGiExZCoSozSUaA], uUMrsOoJcHKxnKsKAOVKUqIcpahN.y, gBHpYMqozsUmhMqafeqyKdZSWpQK);
			}
			oHoyMCgzgsuexntxKTSeyqpMULW(uUMrsOoJcHKxnKsKAOVKUqIcpahN);
			UpWjqMFyZPtHTeAoqyLzOmpISouS.x = uUMrsOoJcHKxnKsKAOVKUqIcpahN.x - WogERykklEPJFWUZFOcBFhiGfrlDb.x;
			UpWjqMFyZPtHTeAoqyLzOmpISouS.y = uUMrsOoJcHKxnKsKAOVKUqIcpahN.y - WogERykklEPJFWUZFOcBFhiGfrlDb.y;
			bNanwnAIyMONFsTpOEOBivUORmIF = uUMrsOoJcHKxnKsKAOVKUqIcpahN.x != WogERykklEPJFWUZFOcBFhiGfrlDb.x || uUMrsOoJcHKxnKsKAOVKUqIcpahN.y != WogERykklEPJFWUZFOcBFhiGfrlDb.y;
			WogERykklEPJFWUZFOcBFhiGfrlDb.x = uUMrsOoJcHKxnKsKAOVKUqIcpahN.x;
			WogERykklEPJFWUZFOcBFhiGfrlDb.y = uUMrsOoJcHKxnKsKAOVKUqIcpahN.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (bNanwnAIyMONFsTpOEOBivUORmIF && SmIFmuPonraVPjUFloErcHiydVsF != null)
			{
				try
				{
					SmIFmuPonraVPjUFloErcHiydVsF(uUMrsOoJcHKxnKsKAOVKUqIcpahN);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				bNanwnAIyMONFsTpOEOBivUORmIF = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			WogERykklEPJFWUZFOcBFhiGfrlDb = uUMrsOoJcHKxnKsKAOVKUqIcpahN;
			UpWjqMFyZPtHTeAoqyLzOmpISouS = Vector2.zero;
			mjhkidoSnuaslutcoTUSguSysXNb();
			bNanwnAIyMONFsTpOEOBivUORmIF = false;
		}

		private void oHoyMCgzgsuexntxKTSeyqpMULW(Vector2 P_0)
		{
			if (!mqaWTtbdnYEuuPpvTEofKWZyyrLPA)
			{
				uUMrsOoJcHKxnKsKAOVKUqIcpahN = P_0;
				return;
			}
			if (azGgSpdnXAjPRAlvWYLKkBqouJcuA == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.x = Mathf.Clamp(P_0.x, BNiIdoSAEkLvIyCmjeMFDAkATAbC.xMin * num, BNiIdoSAEkLvIyCmjeMFDAkATAbC.xMax * num);
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.y = Mathf.Clamp(P_0.y, BNiIdoSAEkLvIyCmjeMFDAkATAbC.yMin * num2, BNiIdoSAEkLvIyCmjeMFDAkATAbC.yMax * num2);
				return;
			}
			if (azGgSpdnXAjPRAlvWYLKkBqouJcuA == MovementAreaUnit.Pixel)
			{
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.x = Mathf.Clamp(P_0.x, BNiIdoSAEkLvIyCmjeMFDAkATAbC.xMin, BNiIdoSAEkLvIyCmjeMFDAkATAbC.xMax);
				uUMrsOoJcHKxnKsKAOVKUqIcpahN.y = Mathf.Clamp(P_0.y, BNiIdoSAEkLvIyCmjeMFDAkATAbC.yMin, BNiIdoSAEkLvIyCmjeMFDAkATAbC.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect LvOqPrPbNqCnFDIhBfRoiebpatvRA()
		{
			if (azGgSpdnXAjPRAlvWYLKkBqouJcuA == MovementAreaUnit.Screen)
			{
				return new ScreenRect(BNiIdoSAEkLvIyCmjeMFDAkATAbC.xMin * (float)Screen.width, BNiIdoSAEkLvIyCmjeMFDAkATAbC.yMin * (float)Screen.height, BNiIdoSAEkLvIyCmjeMFDAkATAbC.width * (float)Screen.width, BNiIdoSAEkLvIyCmjeMFDAkATAbC.height * (float)Screen.height);
			}
			if (azGgSpdnXAjPRAlvWYLKkBqouJcuA == MovementAreaUnit.Pixel)
			{
				return BNiIdoSAEkLvIyCmjeMFDAkATAbC;
			}
			throw new NotImplementedException();
		}

		private void mjhkidoSnuaslutcoTUSguSysXNb()
		{
			OfPegEinpsAnTyhNhVCdfSnoRLRt = Vector2.zero;
			ByiorcsHUfBpRPYaIsaJmHCPdUyq = Vector2.zero;
		}

		private static float zmtTsaWBlTsDVgJbIEiJfzpjHgou(Axis P_0, float P_1, float P_2)
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

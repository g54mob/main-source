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

			public ScreenRect movementArea = JctbJraqMNJglFHHRluFRAhDTqdoA;

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
				return SMOjGyFqCEnAClwKrUgBPmoPYcqy(3, 3);
			}

			private static PlayerMouse SMOjGyFqCEnAClwKrUgBPmoPYcqy(int P_0, int P_1)
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
		private sealed class dCeAplITEeEYkfBhoNsNUGuDFWQz
		{
			public static readonly dCeAplITEeEYkfBhoNsNUGuDFWQz _003C_003E9 = new dCeAplITEeEYkfBhoNsNUGuDFWQz();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool pbQgbcqzmixPNeBzCeieLtSTXvYq(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.VTRSEbLgtjyuMkiCeZgfMOIDdhLK;
				}
				return false;
			}

			internal bool INnlFyfQOldQBExUdvLZOGuLWvrw(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.VTRSEbLgtjyuMkiCeZgfMOIDdhLK;
				}
				return false;
			}
		}

		internal const bool sLaSZmoeaQfoiZLHnbcXaZpfgbrS = true;

		internal const float RhjDyeTJphBhEBJSfOQuStnVVCTR = 1f;

		internal const bool JUnBfjjxlQEUKiaWcDsoiOYnocbw = true;

		internal const bool vLaAVpDbymOnYCNMkGnDmHVLUWyHA = true;

		internal const MovementAreaUnit JdjxPMYynVbZrJurKHMpYbiyqpJv = MovementAreaUnit.Screen;

		internal static readonly ScreenRect JctbJraqMNJglFHHRluFRAhDTqdoA = new ScreenRect(0f, 0f, 1f, 1f);

		private const int AWbOcrctHgVJkjRvdNPGedEWjfxI = 3;

		private const int txjzaFIhjIDLmsTeQblKCGCbNVVBA = 3;

		internal const string BJxvcLOEYUkuLfOdDPUkmATKwGPt = "Movement";

		internal const string kCSkmcCsTNFhCKrIjDqybrXbTbeUb = "Horizontal";

		internal const string KDtTWvGqwbIkxyWWhppTUDjxrhWT = "Vertical";

		internal const string opkbvwtpGPIloBiqCCvhGjQfDtXVA = "Wheel";

		internal const string BlsowLYFYzroobJJIHXaqBucwvWc = "Wheel Horizontal";

		internal const string HjAUONMxNhpMBELMCZTrQFOgUlYN = "Wheel Vertical";

		internal const string TeoZYsxTKwAsiCTbzNvTpGkxEvts = "Left Button";

		internal const string emHcQjUrUpzUklxiHeOirgVMfpde = "Right Button";

		internal const string xIOMxCgxqDriuTxLwrkyQpRYFSoe = "Middle Button";

		private readonly int iMcOtxmoVuqZXzFqOvLdSocriShbA = -1;

		private readonly int TzxJxxedzfjLaQjZqFgUVXMzAfAq = -1;

		private readonly int QxUGntnzEARRNNMRJSrvFsjmSKnk = -1;

		private readonly int mkPYVkJpBToqGQJpYqlLWoJRxfhg = -1;

		private readonly int uljRDKZnnzRbUvFsVhcUTXsTSdqV = -1;

		private readonly int AqUrCcTeSOSugUzQQrLDphEWGZCK = -1;

		private bool jqlcwTeBrHfmwBQwabxxjRhRCRlpB;

		private Vector2 QbGpbofkebTVkSNQGzAZUdImABan;

		private Vector2 HcfKtStFZunlolYtteJrPBvXGGPIA;

		private Vector2 ycPdfujrqOBnSoLBjwSuxxricTKC;

		private Vector2 AwbUIAhQeNhFeswWeFrrMQVSxiSH;

		private Vector2 OoBpdsGHOWdCmGxlHmRBhIMMyVBF;

		private float mDOicyFjsrTcUuatUBHCZzeKBShxA;

		private bool IYqkCTZJWxcpoAHDJvmHALeJdlJS;

		private Action<Vector2> AnBgWICVtsqQuFcPYPTLJZBoUxFr;

		private bool aYYEqxoMBAbYSvMZSqsUVVtIESDk;

		private ScreenRect XSjoBCFsZbjbhWVZCFHdkmzGqBIS;

		private bool qQnXNLeiuJVKThoagjNVhWayYjex;

		private MovementAreaUnit iGXZYBspKNjgkLuehqbicvXgFSNH;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return false;
				}
				return aYYEqxoMBAbYSvMZSqsUVVtIESDk;
			}
			set
			{
				aYYEqxoMBAbYSvMZSqsUVVtIESDk = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return qQnXNLeiuJVKThoagjNVhWayYjex;
			}
			set
			{
				qQnXNLeiuJVKThoagjNVhWayYjex = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return default(ScreenRect);
				}
				return XSjoBCFsZbjbhWVZCFHdkmzGqBIS;
			}
			set
			{
				XSjoBCFsZbjbhWVZCFHdkmzGqBIS = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return MovementAreaUnit.Screen;
				}
				return iGXZYBspKNjgkLuehqbicvXgFSNH;
			}
			set
			{
				iGXZYBspKNjgkLuehqbicvXgFSNH = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return ycPdfujrqOBnSoLBjwSuxxricTKC;
			}
			set
			{
				ebIotuRQqzSRVPgyGqoiHzNnAdyl(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return AwbUIAhQeNhFeswWeFrrMQVSxiSH;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return OoBpdsGHOWdCmGxlHmRBhIMMyVBF;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (TzxJxxedzfjLaQjZqFgUVXMzAfAq < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[TzxJxxedzfjLaQjZqFgUVXMzAfAq];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (QxUGntnzEARRNNMRJSrvFsjmSKnk < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[QxUGntnzEARRNNMRJSrvFsjmSKnk];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (iMcOtxmoVuqZXzFqOvLdSocriShbA < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[iMcOtxmoVuqZXzFqOvLdSocriShbA];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (mkPYVkJpBToqGQJpYqlLWoJRxfhg < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[mkPYVkJpBToqGQJpYqlLWoJRxfhg];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (uljRDKZnnzRbUvFsVhcUTXsTSdqV < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[uljRDKZnnzRbUvFsVhcUTXsTSdqV];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return null;
				}
				if (AqUrCcTeSOSugUzQQrLDphEWGZCK < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[AqUrCcTeSOSugUzQQrLDphEWGZCK];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return 0f;
				}
				return mDOicyFjsrTcUuatUBHCZzeKBShxA;
			}
			set
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				mDOicyFjsrTcUuatUBHCZzeKBShxA = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return false;
				}
				return IYqkCTZJWxcpoAHDJvmHALeJdlJS;
			}
			set
			{
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
					return;
				}
				IYqkCTZJWxcpoAHDJvmHALeJdlJS = value;
				if (!value)
				{
					uOoLpKvoBnFYDSjgFhsmFsBgSkax();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => ycPdfujrqOBnSoLBjwSuxxricTKC;

		Vector2 IMouseInputSource.screenPositionDelta => OoBpdsGHOWdCmGxlHmRBhIMMyVBF;

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
				if (ReInput._id != BColakSjrXYdzLJJhcOAtYyjrySF)
				{
					ReInput.CheckInitialized(BColakSjrXYdzLJJhcOAtYyjrySF);
				}
				else
				{
					AnBgWICVtsqQuFcPYPTLJZBoUxFr = (Action<Vector2>)Delegate.Combine(AnBgWICVtsqQuFcPYPTLJZBoUxFr, value);
				}
			}
			remove
			{
				AnBgWICVtsqQuFcPYPTLJZBoUxFr = (Action<Vector2>)Delegate.Remove(AnBgWICVtsqQuFcPYPTLJZBoUxFr, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			aYYEqxoMBAbYSvMZSqsUVVtIESDk = P_0.defaultToCenter;
			qQnXNLeiuJVKThoagjNVhWayYjex = P_0.clampToMovementArea;
			XSjoBCFsZbjbhWVZCFHdkmzGqBIS = P_0.movementArea;
			iGXZYBspKNjgkLuehqbicvXgFSNH = P_0.movementAreaUnit;
			mDOicyFjsrTcUuatUBHCZzeKBShxA = P_0.pointerSpeed;
			IYqkCTZJWxcpoAHDJvmHALeJdlJS = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						TzxJxxedzfjLaQjZqFgUVXMzAfAq = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						QxUGntnzEARRNNMRJSrvFsjmSKnk = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (iMcOtxmoVuqZXzFqOvLdSocriShbA < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					iMcOtxmoVuqZXzFqOvLdSocriShbA = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						mkPYVkJpBToqGQJpYqlLWoJRxfhg = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						uljRDKZnnzRbUvFsVhcUTXsTSdqV = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						AqUrCcTeSOSugUzQQrLDphEWGZCK = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (iMcOtxmoVuqZXzFqOvLdSocriShbA < 0)
			{
				int num4 = PlayerController.fPclSdsJruCRRFBcrEIUehqBkJSfA(base.Rewired_002EIPlayerController_002Eaxes, dCeAplITEeEYkfBhoNsNUGuDFWQz._003C_003E9.pbQgbcqzmixPNeBzCeieLtSTXvYq, 1);
				int num5 = PlayerController.fPclSdsJruCRRFBcrEIUehqBkJSfA(base.Rewired_002EIPlayerController_002Eaxes, dCeAplITEeEYkfBhoNsNUGuDFWQz._003C_003E9.INnlFyfQOldQBExUdvLZOGuLWvrw, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					vTqACGIFuVUScfSshJZyMaqwUVQAA(mouseWheel);
					iMcOtxmoVuqZXzFqOvLdSocriShbA = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						vTqACGIFuVUScfSshJZyMaqwUVQAA(element);
						mouseWheel.nwkfnNvjXsifsZlPSQGMWDohfeJv(element);
						mouseWheel.nwkfnNvjXsifsZlPSQGMWDohfeJv((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.nwkfnNvjXsifsZlPSQGMWDohfeJv(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.nwkfnNvjXsifsZlPSQGMWDohfeJv(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (aYYEqxoMBAbYSvMZSqsUVVtIESDk)
			{
				ScreenRect screenRect = TLHWlJCsAjJTolJkseeSaVMnqhUXA();
				ycPdfujrqOBnSoLBjwSuxxricTKC = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				ycPdfujrqOBnSoLBjwSuxxricTKC = Vector2.zero;
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
			if (TzxJxxedzfjLaQjZqFgUVXMzAfAq >= 0)
			{
				ycPdfujrqOBnSoLBjwSuxxricTKC.x = nYyxNKTYwOlruQcgdNExMKOdgDDj(base.Rewired_002EIPlayerController_002Eaxes[TzxJxxedzfjLaQjZqFgUVXMzAfAq], ycPdfujrqOBnSoLBjwSuxxricTKC.x, mDOicyFjsrTcUuatUBHCZzeKBShxA);
			}
			if (QxUGntnzEARRNNMRJSrvFsjmSKnk >= 0)
			{
				ycPdfujrqOBnSoLBjwSuxxricTKC.y = nYyxNKTYwOlruQcgdNExMKOdgDDj(base.Rewired_002EIPlayerController_002Eaxes[QxUGntnzEARRNNMRJSrvFsjmSKnk], ycPdfujrqOBnSoLBjwSuxxricTKC.y, mDOicyFjsrTcUuatUBHCZzeKBShxA);
			}
			Player player;
			if (IYqkCTZJWxcpoAHDJvmHALeJdlJS && (player = base.XEmKonepnKndlQCaJOTwvtZQhtxV) != null)
			{
				if (!player.controllers.hasMouse)
				{
					uOoLpKvoBnFYDSjgFhsmFsBgSkax();
				}
				else
				{
					QbGpbofkebTVkSNQGzAZUdImABan = ReInput.controllers.Mouse.screenPosition;
					if (QbGpbofkebTVkSNQGzAZUdImABan.x != HcfKtStFZunlolYtteJrPBvXGGPIA.x || QbGpbofkebTVkSNQGzAZUdImABan.y != HcfKtStFZunlolYtteJrPBvXGGPIA.y)
					{
						ycPdfujrqOBnSoLBjwSuxxricTKC.x = QbGpbofkebTVkSNQGzAZUdImABan.x;
						ycPdfujrqOBnSoLBjwSuxxricTKC.y = QbGpbofkebTVkSNQGzAZUdImABan.y;
					}
					HcfKtStFZunlolYtteJrPBvXGGPIA.x = QbGpbofkebTVkSNQGzAZUdImABan.x;
					HcfKtStFZunlolYtteJrPBvXGGPIA.y = QbGpbofkebTVkSNQGzAZUdImABan.y;
				}
			}
			ebIotuRQqzSRVPgyGqoiHzNnAdyl(ycPdfujrqOBnSoLBjwSuxxricTKC);
			OoBpdsGHOWdCmGxlHmRBhIMMyVBF.x = ycPdfujrqOBnSoLBjwSuxxricTKC.x - AwbUIAhQeNhFeswWeFrrMQVSxiSH.x;
			OoBpdsGHOWdCmGxlHmRBhIMMyVBF.y = ycPdfujrqOBnSoLBjwSuxxricTKC.y - AwbUIAhQeNhFeswWeFrrMQVSxiSH.y;
			jqlcwTeBrHfmwBQwabxxjRhRCRlpB = ycPdfujrqOBnSoLBjwSuxxricTKC.x != AwbUIAhQeNhFeswWeFrrMQVSxiSH.x || ycPdfujrqOBnSoLBjwSuxxricTKC.y != AwbUIAhQeNhFeswWeFrrMQVSxiSH.y;
			AwbUIAhQeNhFeswWeFrrMQVSxiSH.x = ycPdfujrqOBnSoLBjwSuxxricTKC.x;
			AwbUIAhQeNhFeswWeFrrMQVSxiSH.y = ycPdfujrqOBnSoLBjwSuxxricTKC.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (jqlcwTeBrHfmwBQwabxxjRhRCRlpB && AnBgWICVtsqQuFcPYPTLJZBoUxFr != null)
			{
				try
				{
					AnBgWICVtsqQuFcPYPTLJZBoUxFr(ycPdfujrqOBnSoLBjwSuxxricTKC);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				jqlcwTeBrHfmwBQwabxxjRhRCRlpB = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			AwbUIAhQeNhFeswWeFrrMQVSxiSH = ycPdfujrqOBnSoLBjwSuxxricTKC;
			OoBpdsGHOWdCmGxlHmRBhIMMyVBF = Vector2.zero;
			uOoLpKvoBnFYDSjgFhsmFsBgSkax();
			jqlcwTeBrHfmwBQwabxxjRhRCRlpB = false;
		}

		private void ebIotuRQqzSRVPgyGqoiHzNnAdyl(Vector2 P_0)
		{
			if (!qQnXNLeiuJVKThoagjNVhWayYjex)
			{
				ycPdfujrqOBnSoLBjwSuxxricTKC = P_0;
				return;
			}
			if (iGXZYBspKNjgkLuehqbicvXgFSNH == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				ycPdfujrqOBnSoLBjwSuxxricTKC.x = Mathf.Clamp(P_0.x, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.xMin * num, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.xMax * num);
				ycPdfujrqOBnSoLBjwSuxxricTKC.y = Mathf.Clamp(P_0.y, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.yMin * num2, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.yMax * num2);
				return;
			}
			if (iGXZYBspKNjgkLuehqbicvXgFSNH == MovementAreaUnit.Pixel)
			{
				ycPdfujrqOBnSoLBjwSuxxricTKC.x = Mathf.Clamp(P_0.x, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.xMin, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.xMax);
				ycPdfujrqOBnSoLBjwSuxxricTKC.y = Mathf.Clamp(P_0.y, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.yMin, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect TLHWlJCsAjJTolJkseeSaVMnqhUXA()
		{
			if (iGXZYBspKNjgkLuehqbicvXgFSNH == MovementAreaUnit.Screen)
			{
				return new ScreenRect(XSjoBCFsZbjbhWVZCFHdkmzGqBIS.xMin * (float)Screen.width, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.yMin * (float)Screen.height, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.width * (float)Screen.width, XSjoBCFsZbjbhWVZCFHdkmzGqBIS.height * (float)Screen.height);
			}
			if (iGXZYBspKNjgkLuehqbicvXgFSNH == MovementAreaUnit.Pixel)
			{
				return XSjoBCFsZbjbhWVZCFHdkmzGqBIS;
			}
			throw new NotImplementedException();
		}

		private void uOoLpKvoBnFYDSjgFhsmFsBgSkax()
		{
			QbGpbofkebTVkSNQGzAZUdImABan = Vector2.zero;
			HcfKtStFZunlolYtteJrPBvXGGPIA = Vector2.zero;
		}

		private static float nYyxNKTYwOlruQcgdNExMKOdgDDj(Axis P_0, float P_1, float P_2)
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

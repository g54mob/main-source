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

			public ScreenRect movementArea = PrsTdMHUJZHAYwYAvogCVqZJqKVO;

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
				return VxSNvmooWfTkIVcICGUZnqoUJPDW(3, 3);
			}

			private static PlayerMouse VxSNvmooWfTkIVcICGUZnqoUJPDW(int P_0, int P_1)
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
		private sealed class qhKabSdZrQdESoaUSOtWLqJhNjDC
		{
			public static readonly qhKabSdZrQdESoaUSOtWLqJhNjDC _003C_003E9 = new qhKabSdZrQdESoaUSOtWLqJhNjDC();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool XywqTiWryCiUAYNIRMYdjrDgzGfb(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.jCjEmPjlJInDPluwqfVWLCDlDLwy;
				}
				return false;
			}

			internal bool bXtfCWxQqLFTgAWGxfcyIPYcjzLd(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.jCjEmPjlJInDPluwqfVWLCDlDLwy;
				}
				return false;
			}
		}

		internal const bool GjMpsSWUTWJGiNnvvoLpntwuKeeL = true;

		internal const float mZzdeQbcMoksgTURqINlOmpqDEGFA = 1f;

		internal const bool hdMLUpEOgsEfsqqxnZYpfsKvBctl = true;

		internal const bool kZHDbfCuCvUKSqoUnoyTeJPXRltw = true;

		internal const MovementAreaUnit VPIFYCNsbCoNCzegbhSOyMhmCXcF = MovementAreaUnit.Screen;

		internal static readonly ScreenRect PrsTdMHUJZHAYwYAvogCVqZJqKVO = new ScreenRect(0f, 0f, 1f, 1f);

		private const int cCPfHJxsgxfjIdcySDMRmCKAJEMIA = 3;

		private const int qpsVJyJWfyqfXHCoLYwOyvUyQCqC = 3;

		internal const string oyvNcQIBTjKgWATlPbtmDURBgPzl = "Movement";

		internal const string VSBeOSCvGQOTDyycTGAyxeKFPLfA = "Horizontal";

		internal const string eJlTfXUFRVCTerEKcsJuueJgRvpW = "Vertical";

		internal const string uNqDALuJjRgjNlGgwFWNDbswDAoXA = "Wheel";

		internal const string VgAgCnPjIJFNAhvvieXdJywplTPv = "Wheel Horizontal";

		internal const string CXzXtkLeIymMSKigCoogKTTUTNZM = "Wheel Vertical";

		internal const string VcvlWWImzBFQZZqcrnYiaXYCheZj = "Left Button";

		internal const string IPlGSZFwvMOJEGTxGVZyKGBTsDwh = "Right Button";

		internal const string qgmYxrYgsPnDFIJrHAhuBRUSnBDDA = "Middle Button";

		private readonly int VMHlcgaIdIVzMFHlZOLKxbVLHTyp = -1;

		private readonly int xhjhSJEaRoZxlUXubrSootinbuId = -1;

		private readonly int ZLKROnPIZYeJsgDKdQkobTxZzBkz = -1;

		private readonly int VIVdGejEWmIqZUxdkdCUqSloNcEjA = -1;

		private readonly int hpoUIMfmAZjBLNiSDANRJvASADlfb = -1;

		private readonly int arERLiLacmKhVElMRIiJcfZvzVpsA = -1;

		private bool LBesqNTucMjmPAXinLFxeolvDpOZ;

		private Vector2 ECOeKVFKBUJUtFxXGNPZpfqqCXegc;

		private Vector2 DnSbXppwvHScJMVklcIrsOPxEyCH;

		private Vector2 bSSATaJnwShFMgcULfMbPBkJqZJhA;

		private Vector2 zVLTYmtZDKRTtSPJgjeAnFSjIEko;

		private Vector2 syTqEyWjLmDXHcaNDozSTWWopqflA;

		private float oIyCXuDgQnKSSLUGLrCnWOITydvFA;

		private bool dklHrjyEDqSoKTTquBOxRVBiYJkc;

		private Action<Vector2> HWSpAltHiiXQMkYNMbiXQbIXQjkL;

		private bool WyZMqSsPlFEmUHHeQpwFxuAFBKkO;

		private ScreenRect BQJDFIKwfUrdbiLXRboHGouiRaao;

		private bool VAKripAeqWLhJHCOzDeMHyGyVovVA;

		private MovementAreaUnit aQptbJZVgtBtgZOjrWTqtxJxKDrq;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return WyZMqSsPlFEmUHHeQpwFxuAFBKkO;
			}
			set
			{
				WyZMqSsPlFEmUHHeQpwFxuAFBKkO = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return VAKripAeqWLhJHCOzDeMHyGyVovVA;
			}
			set
			{
				VAKripAeqWLhJHCOzDeMHyGyVovVA = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return default(ScreenRect);
				}
				return BQJDFIKwfUrdbiLXRboHGouiRaao;
			}
			set
			{
				BQJDFIKwfUrdbiLXRboHGouiRaao = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return MovementAreaUnit.Screen;
				}
				return aQptbJZVgtBtgZOjrWTqtxJxKDrq;
			}
			set
			{
				aQptbJZVgtBtgZOjrWTqtxJxKDrq = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return bSSATaJnwShFMgcULfMbPBkJqZJhA;
			}
			set
			{
				NqQRyxZWOqVethGIkkVMwPHPIRcu(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return zVLTYmtZDKRTtSPJgjeAnFSjIEko;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return syTqEyWjLmDXHcaNDozSTWWopqflA;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (xhjhSJEaRoZxlUXubrSootinbuId < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[xhjhSJEaRoZxlUXubrSootinbuId];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (ZLKROnPIZYeJsgDKdQkobTxZzBkz < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[ZLKROnPIZYeJsgDKdQkobTxZzBkz];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (VMHlcgaIdIVzMFHlZOLKxbVLHTyp < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[VMHlcgaIdIVzMFHlZOLKxbVLHTyp];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (VIVdGejEWmIqZUxdkdCUqSloNcEjA < 0)
				{
					return null;
				}
				return base.buttons[VIVdGejEWmIqZUxdkdCUqSloNcEjA];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (hpoUIMfmAZjBLNiSDANRJvASADlfb < 0)
				{
					return null;
				}
				return base.buttons[hpoUIMfmAZjBLNiSDANRJvASADlfb];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (arERLiLacmKhVElMRIiJcfZvzVpsA < 0)
				{
					return null;
				}
				return base.buttons[arERLiLacmKhVElMRIiJcfZvzVpsA];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0f;
				}
				return oIyCXuDgQnKSSLUGLrCnWOITydvFA;
			}
			set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				oIyCXuDgQnKSSLUGLrCnWOITydvFA = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return dklHrjyEDqSoKTTquBOxRVBiYJkc;
			}
			set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return;
				}
				dklHrjyEDqSoKTTquBOxRVBiYJkc = value;
				if (!value)
				{
					hKVZwethTCbJKgvWpMWuyThfuqDC();
				}
			}
		}

		bool IMouseInputSource.enabled => base.enabled;

		Vector2 IMouseInputSource.screenPosition => bSSATaJnwShFMgcULfMbPBkJqZJhA;

		Vector2 IMouseInputSource.screenPositionDelta => syTqEyWjLmDXHcaNDozSTWWopqflA;

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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else
				{
					HWSpAltHiiXQMkYNMbiXQbIXQjkL = (Action<Vector2>)Delegate.Combine(HWSpAltHiiXQMkYNMbiXQbIXQjkL, value);
				}
			}
			remove
			{
				HWSpAltHiiXQMkYNMbiXQbIXQjkL = (Action<Vector2>)Delegate.Remove(HWSpAltHiiXQMkYNMbiXQbIXQjkL, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			WyZMqSsPlFEmUHHeQpwFxuAFBKkO = P_0.defaultToCenter;
			VAKripAeqWLhJHCOzDeMHyGyVovVA = P_0.clampToMovementArea;
			BQJDFIKwfUrdbiLXRboHGouiRaao = P_0.movementArea;
			aQptbJZVgtBtgZOjrWTqtxJxKDrq = P_0.movementAreaUnit;
			oIyCXuDgQnKSSLUGLrCnWOITydvFA = P_0.pointerSpeed;
			dklHrjyEDqSoKTTquBOxRVBiYJkc = P_0.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.elements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						xhjhSJEaRoZxlUXubrSootinbuId = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						ZLKROnPIZYeJsgDKdQkobTxZzBkz = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (VMHlcgaIdIVzMFHlZOLKxbVLHTyp < 0 && base.elements[i] is MouseWheel)
				{
					VMHlcgaIdIVzMFHlZOLKxbVLHTyp = i;
				}
				else if (num3 < 3 && (object)base.elements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						VIVdGejEWmIqZUxdkdCUqSloNcEjA = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						hpoUIMfmAZjBLNiSDANRJvASADlfb = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						arERLiLacmKhVElMRIiJcfZvzVpsA = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (VMHlcgaIdIVzMFHlZOLKxbVLHTyp < 0)
			{
				int num4 = PlayerController.bXjiRLKfveGrYifyXTArupYjztiT(base.axes, qhKabSdZrQdESoaUSOtWLqJhNjDC._003C_003E9.XywqTiWryCiUAYNIRMYdjrDgzGfb, 1);
				int num5 = PlayerController.bXjiRLKfveGrYifyXTArupYjztiT(base.axes, qhKabSdZrQdESoaUSOtWLqJhNjDC._003C_003E9.bXtfCWxQqLFTgAWGxfcyIPYcjzLd, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					noRZOaiqNhQVUigJbcItGViYdGAm(mouseWheel);
					VMHlcgaIdIVzMFHlZOLKxbVLHTyp = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						noRZOaiqNhQVUigJbcItGViYdGAm(element);
						mouseWheel.noRZOaiqNhQVUigJbcItGViYdGAm(element);
						mouseWheel.noRZOaiqNhQVUigJbcItGViYdGAm((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.noRZOaiqNhQVUigJbcItGViYdGAm(base.axes[num4]);
						mouseWheel.noRZOaiqNhQVUigJbcItGViYdGAm(base.axes[num5]);
					}
				}
			}
			if (WyZMqSsPlFEmUHHeQpwFxuAFBKkO)
			{
				ScreenRect screenRect = pufZlGuKysEbaNDjloiCDgYINFau();
				bSSATaJnwShFMgcULfMbPBkJqZJhA = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				bSSATaJnwShFMgcULfMbPBkJqZJhA = Vector2.zero;
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
			if (dklHrjyEDqSoKTTquBOxRVBiYJkc && (player = base.tYEyiSjpdwwbqdDLYhlcYJwwGWGV) != null)
			{
				if (!player.controllers.hasMouse)
				{
					hKVZwethTCbJKgvWpMWuyThfuqDC();
				}
				else
				{
					ECOeKVFKBUJUtFxXGNPZpfqqCXegc = ReInput.controllers.Mouse.screenPosition;
					if (ECOeKVFKBUJUtFxXGNPZpfqqCXegc.x != DnSbXppwvHScJMVklcIrsOPxEyCH.x || ECOeKVFKBUJUtFxXGNPZpfqqCXegc.y != DnSbXppwvHScJMVklcIrsOPxEyCH.y)
					{
						bSSATaJnwShFMgcULfMbPBkJqZJhA.x = ECOeKVFKBUJUtFxXGNPZpfqqCXegc.x;
						bSSATaJnwShFMgcULfMbPBkJqZJhA.y = ECOeKVFKBUJUtFxXGNPZpfqqCXegc.y;
					}
					DnSbXppwvHScJMVklcIrsOPxEyCH.x = ECOeKVFKBUJUtFxXGNPZpfqqCXegc.x;
					DnSbXppwvHScJMVklcIrsOPxEyCH.y = ECOeKVFKBUJUtFxXGNPZpfqqCXegc.y;
				}
			}
			if (xhjhSJEaRoZxlUXubrSootinbuId >= 0)
			{
				bSSATaJnwShFMgcULfMbPBkJqZJhA.x = UuPYvbLEGAwyAMTRYrYFKEgGTPFR(base.axes[xhjhSJEaRoZxlUXubrSootinbuId], bSSATaJnwShFMgcULfMbPBkJqZJhA.x, oIyCXuDgQnKSSLUGLrCnWOITydvFA);
			}
			if (ZLKROnPIZYeJsgDKdQkobTxZzBkz >= 0)
			{
				bSSATaJnwShFMgcULfMbPBkJqZJhA.y = UuPYvbLEGAwyAMTRYrYFKEgGTPFR(base.axes[ZLKROnPIZYeJsgDKdQkobTxZzBkz], bSSATaJnwShFMgcULfMbPBkJqZJhA.y, oIyCXuDgQnKSSLUGLrCnWOITydvFA);
			}
			NqQRyxZWOqVethGIkkVMwPHPIRcu(bSSATaJnwShFMgcULfMbPBkJqZJhA);
			syTqEyWjLmDXHcaNDozSTWWopqflA.x = bSSATaJnwShFMgcULfMbPBkJqZJhA.x - zVLTYmtZDKRTtSPJgjeAnFSjIEko.x;
			syTqEyWjLmDXHcaNDozSTWWopqflA.y = bSSATaJnwShFMgcULfMbPBkJqZJhA.y - zVLTYmtZDKRTtSPJgjeAnFSjIEko.y;
			LBesqNTucMjmPAXinLFxeolvDpOZ = bSSATaJnwShFMgcULfMbPBkJqZJhA.x != zVLTYmtZDKRTtSPJgjeAnFSjIEko.x || bSSATaJnwShFMgcULfMbPBkJqZJhA.y != zVLTYmtZDKRTtSPJgjeAnFSjIEko.y;
			zVLTYmtZDKRTtSPJgjeAnFSjIEko.x = bSSATaJnwShFMgcULfMbPBkJqZJhA.x;
			zVLTYmtZDKRTtSPJgjeAnFSjIEko.y = bSSATaJnwShFMgcULfMbPBkJqZJhA.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (LBesqNTucMjmPAXinLFxeolvDpOZ && HWSpAltHiiXQMkYNMbiXQbIXQjkL != null)
			{
				try
				{
					HWSpAltHiiXQMkYNMbiXQbIXQjkL(bSSATaJnwShFMgcULfMbPBkJqZJhA);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				LBesqNTucMjmPAXinLFxeolvDpOZ = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			zVLTYmtZDKRTtSPJgjeAnFSjIEko = bSSATaJnwShFMgcULfMbPBkJqZJhA;
			syTqEyWjLmDXHcaNDozSTWWopqflA = Vector2.zero;
			hKVZwethTCbJKgvWpMWuyThfuqDC();
			LBesqNTucMjmPAXinLFxeolvDpOZ = false;
		}

		private void NqQRyxZWOqVethGIkkVMwPHPIRcu(Vector2 P_0)
		{
			if (!VAKripAeqWLhJHCOzDeMHyGyVovVA)
			{
				bSSATaJnwShFMgcULfMbPBkJqZJhA = P_0;
				return;
			}
			if (aQptbJZVgtBtgZOjrWTqtxJxKDrq == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				bSSATaJnwShFMgcULfMbPBkJqZJhA.x = Mathf.Clamp(P_0.x, BQJDFIKwfUrdbiLXRboHGouiRaao.xMin * num, BQJDFIKwfUrdbiLXRboHGouiRaao.xMax * num);
				bSSATaJnwShFMgcULfMbPBkJqZJhA.y = Mathf.Clamp(P_0.y, BQJDFIKwfUrdbiLXRboHGouiRaao.yMin * num2, BQJDFIKwfUrdbiLXRboHGouiRaao.yMax * num2);
				return;
			}
			if (aQptbJZVgtBtgZOjrWTqtxJxKDrq == MovementAreaUnit.Pixel)
			{
				bSSATaJnwShFMgcULfMbPBkJqZJhA.x = Mathf.Clamp(P_0.x, BQJDFIKwfUrdbiLXRboHGouiRaao.xMin, BQJDFIKwfUrdbiLXRboHGouiRaao.xMax);
				bSSATaJnwShFMgcULfMbPBkJqZJhA.y = Mathf.Clamp(P_0.y, BQJDFIKwfUrdbiLXRboHGouiRaao.yMin, BQJDFIKwfUrdbiLXRboHGouiRaao.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect pufZlGuKysEbaNDjloiCDgYINFau()
		{
			if (aQptbJZVgtBtgZOjrWTqtxJxKDrq == MovementAreaUnit.Screen)
			{
				return new ScreenRect(BQJDFIKwfUrdbiLXRboHGouiRaao.xMin * (float)Screen.width, BQJDFIKwfUrdbiLXRboHGouiRaao.yMin * (float)Screen.height, BQJDFIKwfUrdbiLXRboHGouiRaao.width * (float)Screen.width, BQJDFIKwfUrdbiLXRboHGouiRaao.height * (float)Screen.height);
			}
			if (aQptbJZVgtBtgZOjrWTqtxJxKDrq == MovementAreaUnit.Pixel)
			{
				return BQJDFIKwfUrdbiLXRboHGouiRaao;
			}
			throw new NotImplementedException();
		}

		private void hKVZwethTCbJKgvWpMWuyThfuqDC()
		{
			ECOeKVFKBUJUtFxXGNPZpfqqCXegc = Vector2.zero;
			DnSbXppwvHScJMVklcIrsOPxEyCH = Vector2.zero;
		}

		private static float UuPYvbLEGAwyAMTRYrYFKEgGTPFR(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			switch (P_0.coordinateMode)
			{
			case AxisCoordinateMode.Absolute:
				return P_0.value;
			case AxisCoordinateMode.Relative:
				return P_1 + P_0.value * P_2;
			default:
				throw new NotImplementedException();
			}
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

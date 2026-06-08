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

			public bool clampToMovementArea = true;

			public ScreenRect movementArea = CgpqwoFsIIAhzExqBOimCKNgbzyA;

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
				return GIHuiEkmFihgdjpqkqIhwXanlmm(3, 3);
			}

			private static PlayerMouse GIHuiEkmFihgdjpqkqIhwXanlmm(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
					goto IL_0007;
				}
				goto IL_004c;
				IL_004c:
				int num;
				if (P_1 < 0)
				{
					P_1 = 0;
					num = -59992152;
					goto IL_000c;
				}
				goto IL_012b;
				IL_0007:
				num = -59992153;
				goto IL_000c;
				IL_000c:
				int num2 = default(int);
				List<Element.Definition> list = default(List<Element.Definition>);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -59992147)
					{
					case 0:
						break;
					case 10:
						goto IL_004c;
					case 11:
						goto IL_005d;
					case 8:
						num2 = 3;
						num = -59992150;
						continue;
					case 1:
						if (P_0 >= 3)
						{
							list.Add(new Button.Definition
							{
								name = "Middle Button"
							});
							num = -59992155;
							continue;
						}
						goto case 8;
					case 6:
						if (num3 < P_1)
						{
							goto case 4;
						}
						if (P_0 >= 1)
						{
							list.Add(new Button.Definition
							{
								name = "Left Button"
							});
							num = -59992145;
							continue;
						}
						goto case 2;
					case 5:
						goto IL_012b;
					case 3:
						goto IL_018d;
					case 4:
						list.Add(new Axis.Definition
						{
							coordinateMode = AxisCoordinateMode.Relative
						});
						num3++;
						num = -59992149;
						continue;
					case 9:
						list.Add(new Button.Definition());
						num2++;
						num = -59992150;
						continue;
					case 2:
						if (P_0 >= 2)
						{
							list.Add(new Button.Definition
							{
								name = "Right Button"
							});
							num = -59992148;
							continue;
						}
						goto case 1;
					default:
						if (num2 >= P_0)
						{
							Definition definition = new Definition();
							definition.elements = list;
							return new PlayerMouse(definition);
						}
						goto case 9;
					}
					break;
				}
				goto IL_0007;
				IL_005d:
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
					num = -59992146;
					goto IL_000c;
				}
				goto IL_018d;
				IL_012b:
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
					num = -59992154;
					goto IL_000c;
				}
				goto IL_005d;
				IL_018d:
				num3 = 4;
				num = -59992149;
				goto IL_000c;
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

		internal const bool ZWJyEwCYTDgRVrZYXyRdeqSNbBB = true;

		internal const float rIoqBmjbTtHbLhVdKTHVZBzRbfh = 1f;

		internal const bool mRHGSBArpnpuXCPuZFoTqEWKccW = true;

		internal const bool dRUFmZCUDkmpjfEyBWwbtmTmAWQF = true;

		internal const MovementAreaUnit YYHKwiPavNRCfPWNLvWilhgHdeL = MovementAreaUnit.Screen;

		private const int vmGuQnvFlyOynFBKqAIdpmEbxnh = 3;

		private const int jxnUKQVXTxXnqxCetdUotqvJdrR = 3;

		internal const string ttkQwyYCOqlOvwgTnDrOSEZuVNW = "Movement";

		internal const string QdBDpmAiyTKlcOJUClOgrngppsy = "Horizontal";

		internal const string vRoCtMEIsCyPwTapSLQozTdDWQx = "Vertical";

		internal const string jKbgBrbeuSEEihZEaUMpHygNBlZm = "Wheel";

		internal const string IlTxLVZXsOysjPBlMZaTQeqEebm = "Wheel Horizontal";

		internal const string FrmpwILhFfuptckWmoiQZkXpgRi = "Wheel Vertical";

		internal const string GJyDBoQvyQWlyfrSHnYAzTOzPSg = "Left Button";

		internal const string DtkPFdTsYTlajuHvcXNKPRqyFBV = "Right Button";

		internal const string xUflaNEwvGsaeaLBvAzYhQYpJuix = "Middle Button";

		internal static readonly ScreenRect CgpqwoFsIIAhzExqBOimCKNgbzyA = new ScreenRect(0f, 0f, 1f, 1f);

		private readonly int StOeSWmUsVsjlptVnQAogdXiarD = -1;

		private readonly int qSmuixSspjyGEiGdLkfSlWjUVSv = -1;

		private readonly int WgBVVRVsWLKmDvweLuwOKdfgegXf = -1;

		private readonly int OmEIFMEKDxhNiIDPCBCwjRdkFXnq = -1;

		private readonly int eZlrVeroDGEckhHctaZlBkUxmqUH = -1;

		private readonly int neJGCuRlFpMKkmoHbqupsDXGcUA = -1;

		private bool OWptnpXsbNeLoszYHLFVlYdCDMb;

		private Vector2 RPNjPfAcKZHbKJHxblBfBggvCsRa;

		private Vector2 IBLghTzGwGbbgiIYZDkTfaBKadtA;

		private Vector2 sgRKSEhzxVPaxWuqpWSTCuuwnaw;

		private Vector2 aBGqBQdAYLIiImbnKezaccMCTdXq;

		private Vector2 vNCWJWYNIdzwqYZnjhhqBzGTBRA;

		private float jmdKCUmtByUdlgzgjkINZGYcRYY;

		private bool aPlBANapZfDfLDrzEULueQVTNrmw;

		private Action<Vector2> UjJacTdoGlbgrFUmwfrtwVYysfVq;

		private bool PuEynkypqMTWbrxYquElmMSwzXV;

		private ScreenRect SiSFQcDKoBfWIIMbdmgbTxqPZDX;

		private bool EGRsdVIrhXQAindeJguodVUBfPUE;

		private MovementAreaUnit rKesyfFZjsOiNlcVXHRCiFFAWiG;

		[CompilerGenerated]
		private static Predicate<Axis> nxRDNsQycmbjNuLzCodsWNAlkcQ;

		[CompilerGenerated]
		private static Predicate<Axis> VqWFQXijanCwPkbVsFhwOEwJgwAF;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return PuEynkypqMTWbrxYquElmMSwzXV;
			}
			set
			{
				PuEynkypqMTWbrxYquElmMSwzXV = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return EGRsdVIrhXQAindeJguodVUBfPUE;
			}
			set
			{
				EGRsdVIrhXQAindeJguodVUBfPUE = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return default(ScreenRect);
				}
				return SiSFQcDKoBfWIIMbdmgbTxqPZDX;
			}
			set
			{
				SiSFQcDKoBfWIIMbdmgbTxqPZDX = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return MovementAreaUnit.Screen;
				}
				return rKesyfFZjsOiNlcVXHRCiFFAWiG;
			}
			set
			{
				rKesyfFZjsOiNlcVXHRCiFFAWiG = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return sgRKSEhzxVPaxWuqpWSTCuuwnaw;
			}
			set
			{
				SAVvbRHwRjbaQFrsGHJchXJsmkR(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return aBGqBQdAYLIiImbnKezaccMCTdXq;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return vNCWJWYNIdzwqYZnjhhqBzGTBRA;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				if (qSmuixSspjyGEiGdLkfSlWjUVSv < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[qSmuixSspjyGEiGdLkfSlWjUVSv];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				if (WgBVVRVsWLKmDvweLuwOKdfgegXf < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[WgBVVRVsWLKmDvweLuwOKdfgegXf];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				if (StOeSWmUsVsjlptVnQAogdXiarD < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[StOeSWmUsVsjlptVnQAogdXiarD];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				if (OmEIFMEKDxhNiIDPCBCwjRdkFXnq < 0)
				{
					return null;
				}
				return base.buttons[OmEIFMEKDxhNiIDPCBCwjRdkFXnq];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				if (eZlrVeroDGEckhHctaZlBkUxmqUH < 0)
				{
					return null;
				}
				return base.buttons[eZlrVeroDGEckhHctaZlBkUxmqUH];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					goto IL_0019;
				}
				int num;
				if (neJGCuRlFpMKkmoHbqupsDXGcUA < 0)
				{
					num = -1957547359;
					goto IL_001e;
				}
				return base.buttons[neJGCuRlFpMKkmoHbqupsDXGcUA];
				IL_0019:
				num = -1957547360;
				goto IL_001e;
				IL_001e:
				switch (num ^ -1957547359)
				{
				case 2:
					break;
				case 1:
					return null;
				default:
					return null;
				}
				goto IL_0019;
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0f;
				}
				return jmdKCUmtByUdlgzgjkINZGYcRYY;
			}
			set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				}
				while (value < 0f)
				{
					value = 0f;
					int num = 1683076363;
					while (true)
					{
						switch (num ^ 0x6451B509)
						{
						case 0:
							num = 1683076360;
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
				jmdKCUmtByUdlgzgjkINZGYcRYY = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return aPlBANapZfDfLDrzEULueQVTNrmw;
			}
			set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				}
				while (true)
				{
					aPlBANapZfDfLDrzEULueQVTNrmw = value;
					if (value)
					{
						break;
					}
					gWAKAWbciVHUbAFBZWMGnaLQpLe();
					int num = 1192540810;
					while (true)
					{
						switch (num ^ 0x4714BA88)
						{
						case 0:
							goto IL_001a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_001a:
						num = 1192540809;
					}
				}
			}
		}

		bool IMouseInputSource.enabled => base.enabled;

		Vector2 IMouseInputSource.screenPosition => sgRKSEhzxVPaxWuqpWSTCuuwnaw;

		Vector2 IMouseInputSource.screenPositionDelta => vNCWJWYNIdzwqYZnjhhqBzGTBRA;

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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				}
				while (true)
				{
					UjJacTdoGlbgrFUmwfrtwVYysfVq = (Action<Vector2>)Delegate.Combine(UjJacTdoGlbgrFUmwfrtwVYysfVq, value);
					int num = 393782921;
					while (true)
					{
						switch (num ^ 0x1778A689)
						{
						case 2:
							goto IL_001a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_001a:
						num = 393782920;
					}
				}
			}
			remove
			{
				UjJacTdoGlbgrFUmwfrtwVYysfVq = (Action<Vector2>)Delegate.Remove(UjJacTdoGlbgrFUmwfrtwVYysfVq, value);
			}
		}

		private PlayerMouse(Definition definition)
			: base(definition)
		{
			PuEynkypqMTWbrxYquElmMSwzXV = definition.defaultToCenter;
			EGRsdVIrhXQAindeJguodVUBfPUE = definition.clampToMovementArea;
			SiSFQcDKoBfWIIMbdmgbTxqPZDX = definition.movementArea;
			rKesyfFZjsOiNlcVXHRCiFFAWiG = definition.movementAreaUnit;
			jmdKCUmtByUdlgzgjkINZGYcRYY = definition.pointerSpeed;
			aPlBANapZfDfLDrzEULueQVTNrmw = definition.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && object.ReferenceEquals(base.elements[i].GetType(), typeof(MouseAxis)))
				{
					if (num2 == 0)
					{
						qSmuixSspjyGEiGdLkfSlWjUVSv = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						WgBVVRVsWLKmDvweLuwOKdfgegXf = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (StOeSWmUsVsjlptVnQAogdXiarD < 0 && base.elements[i] is MouseWheel)
				{
					StOeSWmUsVsjlptVnQAogdXiarD = i;
				}
				else if (num3 < 3 && object.ReferenceEquals(base.elements[i].GetType(), typeof(Button)))
				{
					switch (num3)
					{
					case 0:
						OmEIFMEKDxhNiIDPCBCwjRdkFXnq = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						eZlrVeroDGEckhHctaZlBkUxmqUH = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						neJGCuRlFpMKkmoHbqupsDXGcUA = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (StOeSWmUsVsjlptVnQAogdXiarD < 0)
			{
				int num4 = PlayerController.sEpfEHqnNOzQdObWILhWKKhIL(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 1);
				int num5 = PlayerController.sEpfEHqnNOzQdObWILhWKKhIL(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					itKYLEidIwjerGGrDGqPNskdaYz(mouseWheel);
					StOeSWmUsVsjlptVnQAogdXiarD = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						itKYLEidIwjerGGrDGqPNskdaYz(element);
						mouseWheel.itKYLEidIwjerGGrDGqPNskdaYz(element);
						mouseWheel.itKYLEidIwjerGGrDGqPNskdaYz((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.itKYLEidIwjerGGrDGqPNskdaYz(base.axes[num4]);
						mouseWheel.itKYLEidIwjerGGrDGqPNskdaYz(base.axes[num5]);
					}
				}
			}
			if (PuEynkypqMTWbrxYquElmMSwzXV)
			{
				ScreenRect screenRect = wyemoykidbaYDptBNeayIGIpDcDK();
				sgRKSEhzxVPaxWuqpWSTCuuwnaw = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				sgRKSEhzxVPaxWuqpWSTCuuwnaw = Vector2.zero;
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
			if (aPlBANapZfDfLDrzEULueQVTNrmw)
			{
				goto IL_001b;
			}
			goto IL_011d;
			IL_0100:
			int num;
			int num2;
			if (WgBVVRVsWLKmDvweLuwOKdfgegXf < 0)
			{
				num = 1669950780;
				num2 = num;
			}
			else
			{
				num = 1669950782;
				num2 = num;
			}
			goto IL_0020;
			IL_011d:
			if (qSmuixSspjyGEiGdLkfSlWjUVSv >= 0)
			{
				sgRKSEhzxVPaxWuqpWSTCuuwnaw.x = JzSlqDLBDTOTbgthcuQnXJepaseK(base.axes[qSmuixSspjyGEiGdLkfSlWjUVSv], sgRKSEhzxVPaxWuqpWSTCuuwnaw.x, jmdKCUmtByUdlgzgjkINZGYcRYY);
				num = 1669950783;
				goto IL_0020;
			}
			goto IL_0100;
			IL_001b:
			num = 1669950772;
			goto IL_0020;
			IL_0020:
			while (true)
			{
				switch (num ^ 0x63896D37)
				{
				case 0:
					break;
				case 9:
					sgRKSEhzxVPaxWuqpWSTCuuwnaw.y = JzSlqDLBDTOTbgthcuQnXJepaseK(base.axes[WgBVVRVsWLKmDvweLuwOKdfgegXf], sgRKSEhzxVPaxWuqpWSTCuuwnaw.y, jmdKCUmtByUdlgzgjkINZGYcRYY);
					num = 1669950780;
					continue;
				case 11:
					SAVvbRHwRjbaQFrsGHJchXJsmkR(sgRKSEhzxVPaxWuqpWSTCuuwnaw);
					vNCWJWYNIdzwqYZnjhhqBzGTBRA.x = sgRKSEhzxVPaxWuqpWSTCuuwnaw.x - aBGqBQdAYLIiImbnKezaccMCTdXq.x;
					num = 1669950773;
					continue;
				case 3:
					goto IL_00d5;
				case 8:
					goto IL_0100;
				case 6:
					goto IL_011d;
				case 2:
					vNCWJWYNIdzwqYZnjhhqBzGTBRA.y = sgRKSEhzxVPaxWuqpWSTCuuwnaw.y - aBGqBQdAYLIiImbnKezaccMCTdXq.y;
					OWptnpXsbNeLoszYHLFVlYdCDMb = sgRKSEhzxVPaxWuqpWSTCuuwnaw.x != aBGqBQdAYLIiImbnKezaccMCTdXq.x || sgRKSEhzxVPaxWuqpWSTCuuwnaw.y != aBGqBQdAYLIiImbnKezaccMCTdXq.y;
					aBGqBQdAYLIiImbnKezaccMCTdXq.x = sgRKSEhzxVPaxWuqpWSTCuuwnaw.x;
					aBGqBQdAYLIiImbnKezaccMCTdXq.y = sgRKSEhzxVPaxWuqpWSTCuuwnaw.y;
					num = 1669950779;
					continue;
				case 5:
					gWAKAWbciVHUbAFBZWMGnaLQpLe();
					num = 1669950769;
					continue;
				case 1:
					sgRKSEhzxVPaxWuqpWSTCuuwnaw.x = RPNjPfAcKZHbKJHxblBfBggvCsRa.x;
					sgRKSEhzxVPaxWuqpWSTCuuwnaw.y = RPNjPfAcKZHbKJHxblBfBggvCsRa.y;
					num = 1669950771;
					continue;
				case 4:
					IBLghTzGwGbbgiIYZDkTfaBKadtA.x = RPNjPfAcKZHbKJHxblBfBggvCsRa.x;
					IBLghTzGwGbbgiIYZDkTfaBKadtA.y = RPNjPfAcKZHbKJHxblBfBggvCsRa.y;
					num = 1669950769;
					continue;
				case 10:
					goto IL_0272;
				case 7:
					goto IL_029e;
				default:
					return true;
				}
				break;
				IL_029e:
				RPNjPfAcKZHbKJHxblBfBggvCsRa = ReInput.controllers.Mouse.screenPosition;
				int num3;
				if (RPNjPfAcKZHbKJHxblBfBggvCsRa.x != IBLghTzGwGbbgiIYZDkTfaBKadtA.x)
				{
					num = 1669950774;
					num3 = num;
				}
				else
				{
					num = 1669950781;
					num3 = num;
				}
				continue;
				IL_0272:
				int num4;
				if (RPNjPfAcKZHbKJHxblBfBggvCsRa.y == IBLghTzGwGbbgiIYZDkTfaBKadtA.y)
				{
					num = 1669950771;
					num4 = num;
				}
				else
				{
					num = 1669950774;
					num4 = num;
				}
				continue;
				IL_00d5:
				Player player;
				if ((player = base.player) != null)
				{
					int num5;
					if (!player.controllers.hasMouse)
					{
						num = 1669950770;
						num5 = num;
					}
					else
					{
						num = 1669950768;
						num5 = num;
					}
					continue;
				}
				goto IL_011d;
			}
			goto IL_001b;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (!OWptnpXsbNeLoszYHLFVlYdCDMb || UjJacTdoGlbgrFUmwfrtwVYysfVq == null)
			{
				return;
			}
			try
			{
				UjJacTdoGlbgrFUmwfrtwVYysfVq(sgRKSEhzxVPaxWuqpWSTCuuwnaw);
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_002a:
					int num = -1754884143;
					while (true)
					{
						switch (num ^ -1754884144)
						{
						case 2:
							break;
						default:
							goto end_IL_002f;
						case 1:
							goto IL_0048;
						case 0:
							goto end_IL_002f;
						}
						goto IL_002a;
						IL_0048:
						Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
						num = -1754884144;
						continue;
						end_IL_002f:
						break;
					}
					break;
				}
			}
			OWptnpXsbNeLoszYHLFVlYdCDMb = false;
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			aBGqBQdAYLIiImbnKezaccMCTdXq = sgRKSEhzxVPaxWuqpWSTCuuwnaw;
			vNCWJWYNIdzwqYZnjhhqBzGTBRA = Vector2.zero;
			gWAKAWbciVHUbAFBZWMGnaLQpLe();
			OWptnpXsbNeLoszYHLFVlYdCDMb = false;
		}

		private void SAVvbRHwRjbaQFrsGHJchXJsmkR(Vector2 P_0)
		{
			if (!EGRsdVIrhXQAindeJguodVUBfPUE)
			{
				sgRKSEhzxVPaxWuqpWSTCuuwnaw = P_0;
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (rKesyfFZjsOiNlcVXHRCiFFAWiG == MovementAreaUnit.Screen)
				{
					num = 868564686;
					num2 = num;
				}
				else
				{
					num = 868564685;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x33C53ECE)
					{
					case 4:
						num = 868564687;
						continue;
					case 5:
						sgRKSEhzxVPaxWuqpWSTCuuwnaw.y = Mathf.Clamp(P_0.y, SiSFQcDKoBfWIIMbdmgbTxqPZDX.yMin, SiSFQcDKoBfWIIMbdmgbTxqPZDX.yMax);
						return;
					case 0:
					{
						float num3 = Screen.width;
						float num4 = Screen.height;
						sgRKSEhzxVPaxWuqpWSTCuuwnaw.x = Mathf.Clamp(P_0.x, SiSFQcDKoBfWIIMbdmgbTxqPZDX.xMin * num3, SiSFQcDKoBfWIIMbdmgbTxqPZDX.xMax * num3);
						sgRKSEhzxVPaxWuqpWSTCuuwnaw.y = Mathf.Clamp(P_0.y, SiSFQcDKoBfWIIMbdmgbTxqPZDX.yMin * num4, SiSFQcDKoBfWIIMbdmgbTxqPZDX.yMax * num4);
						num = 868564680;
						continue;
					}
					case 3:
						if (rKesyfFZjsOiNlcVXHRCiFFAWiG == MovementAreaUnit.Pixel)
						{
							sgRKSEhzxVPaxWuqpWSTCuuwnaw.x = Mathf.Clamp(P_0.x, SiSFQcDKoBfWIIMbdmgbTxqPZDX.xMin, SiSFQcDKoBfWIIMbdmgbTxqPZDX.xMax);
							num = 868564683;
							continue;
						}
						goto default;
					case 6:
						return;
					case 1:
						break;
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		private ScreenRect wyemoykidbaYDptBNeayIGIpDcDK()
		{
			if (rKesyfFZjsOiNlcVXHRCiFFAWiG == MovementAreaUnit.Screen)
			{
				return new ScreenRect(SiSFQcDKoBfWIIMbdmgbTxqPZDX.xMin * (float)Screen.width, SiSFQcDKoBfWIIMbdmgbTxqPZDX.yMin * (float)Screen.height, SiSFQcDKoBfWIIMbdmgbTxqPZDX.width * (float)Screen.width, SiSFQcDKoBfWIIMbdmgbTxqPZDX.height * (float)Screen.height);
			}
			if (rKesyfFZjsOiNlcVXHRCiFFAWiG == MovementAreaUnit.Pixel)
			{
				return SiSFQcDKoBfWIIMbdmgbTxqPZDX;
			}
			throw new NotImplementedException();
		}

		private void gWAKAWbciVHUbAFBZWMGnaLQpLe()
		{
			RPNjPfAcKZHbKJHxblBfBggvCsRa = Vector2.zero;
			IBLghTzGwGbbgiIYZDkTfaBKadtA = Vector2.zero;
		}

		private static float JzSlqDLBDTOTbgthcuQnXJepaseK(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			AxisCoordinateMode coordinateMode = P_0.coordinateMode;
			while (true)
			{
				switch (-335397650 ^ -335397649)
				{
				case 0:
					continue;
				case 1:
					switch (coordinateMode)
					{
					case AxisCoordinateMode.Absolute:
						break;
					case AxisCoordinateMode.Relative:
						return P_1 + P_0.value * P_2;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return P_0.value;
		}

		private bool idAXnyFzJhjjeXdFKIiOKlWXSgF(int P_0)
		{
			return GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in idAXnyFzJhjjeXdFKIiOKlWXSgF
			return this.idAXnyFzJhjjeXdFKIiOKlWXSgF(P_0);
		}

		private bool DEMORJVdvLvETJClEIwJyxFMzFC(int P_0)
		{
			return GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DEMORJVdvLvETJClEIwJyxFMzFC
			return this.DEMORJVdvLvETJClEIwJyxFMzFC(P_0);
		}

		private bool hBkkdIiZEqgNhGhdvTZMjCpqpgU(int P_0)
		{
			return GetButton(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hBkkdIiZEqgNhGhdvTZMjCpqpgU
			return this.hBkkdIiZEqgNhGhdvTZMjCpqpgU(P_0);
		}

		[CompilerGenerated]
		private static bool EreXIoHgZSDQKKoBEjvcjrGvsLZN(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}

		[CompilerGenerated]
		private static bool hCIvNRRFeBGJEqklKBXQPNqJbfp(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}
	}
}

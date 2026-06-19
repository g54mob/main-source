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

			public ScreenRect movementArea = CtevvXTDvcGHFjnMqLRnViXuNYja;

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
				return AxGMnpcloIAUTQTSFCdghQatHHxd(3, 3);
			}

			private static PlayerMouse AxGMnpcloIAUTQTSFCdghQatHHxd(int P_0, int P_1)
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
				Definition definition = new Definition();
				definition.elements = list;
				return new PlayerMouse(definition);
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

		internal const bool JJWcbXQglxUOvASnchVWMEgNxKY = true;

		internal const float xepzKZxOsBfQvUMZjyvCxQhZYVc = 1f;

		internal const bool uCCRfeQNQXLsrdcjqakCObUEbXN = true;

		internal const bool jvPJhsGdeMcRDhbOaHFkYDPshtXD = true;

		internal const MovementAreaUnit OoWFQXBpXzpyHaGmiEHlNwvPWrI = MovementAreaUnit.Screen;

		private const int dBXpjAbFISekFwAiJCbgbHIpJSmf = 3;

		private const int hIiDrKJovDhKfMSfGzIrFtlLKRO = 3;

		internal const string delTMJQvYSDJHLdlKUALuROouAB = "Movement";

		internal const string WWOmFJKFBhVkInshvjwnBcorNsz = "Horizontal";

		internal const string nItcHIUDxazKzqoYtFwNBSLPopB = "Vertical";

		internal const string ttaHSOeVXiSaIaDmjDjeAMgThQGb = "Wheel";

		internal const string MhSmxkLkgmApJuzjbgXGqRkATPx = "Wheel Horizontal";

		internal const string NcnWztDqeXrRZLXsJoFHzLLnFuf = "Wheel Vertical";

		internal const string AclHOFSJLcGTWgYsqLlXFNChepdm = "Left Button";

		internal const string DqvcGCHLPxINPTlfXamNjQFiHwMa = "Right Button";

		internal const string fgeSrcSVKudYQNohAOWDuaUjdZr = "Middle Button";

		internal static readonly ScreenRect CtevvXTDvcGHFjnMqLRnViXuNYja = new ScreenRect(0f, 0f, 1f, 1f);

		private readonly int OnTzInojThQYFSFrQnAfCELwZtC = -1;

		private readonly int qHtlLMGkCJMWaJeByUnHRArSgtu = -1;

		private readonly int KkAoWkPKttiOrCpGeGZZHgxyPHWE = -1;

		private readonly int YCFhOxWtmPXnKqcbtGthKxhJBaeU = -1;

		private readonly int eUyyAPfkgiFQYFWQKvaiQMErLPLT = -1;

		private readonly int vrQFSzLyOXwdAHbWCHVqEBTUBJNj = -1;

		private bool UgwLiUJOIxftKkZoywoAcLfKXjwp;

		private Vector2 JWAFEMdMnfvPaQmXCJmmlWybRXOb;

		private Vector2 SgGxuinWZiReQFkUkVYMNVCQQZo;

		private Vector2 ctCEBnclQdYIFKzGOHbQUiuiWZfF;

		private Vector2 eXXUQvfvptsScDkRpeCjEAKIyECE;

		private Vector2 hyJMMrGplBkUWbpJEhSxtaQVnqF;

		private float bdgjRdBsyIhDHfRYGDrUZlIgQxB;

		private bool griBBuygpJHCzYHNxaNjmbNNGit;

		private Action<Vector2> QbGbuVpvOLMDInIWNSsPjKasOcA;

		private bool XxJQiVcNDeipDiYiNMHqSOEuvYUB;

		private ScreenRect CrThZHCyLlakodEBANFarmiXBcA;

		private bool KuClogCPGxokMSeImgRjDxONioHF;

		private MovementAreaUnit zVzWtMJHMCyazIinygcNCUNWfFBN;

		[CompilerGenerated]
		private static Predicate<Axis> lOQcCRGEDAZVfMHZnMEpswIpjBVD;

		[CompilerGenerated]
		private static Predicate<Axis> LDLmDsvfHVpKxKAhJlObsDuRmDN;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return XxJQiVcNDeipDiYiNMHqSOEuvYUB;
			}
			set
			{
				XxJQiVcNDeipDiYiNMHqSOEuvYUB = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return KuClogCPGxokMSeImgRjDxONioHF;
			}
			set
			{
				KuClogCPGxokMSeImgRjDxONioHF = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return default(ScreenRect);
				}
				return CrThZHCyLlakodEBANFarmiXBcA;
			}
			set
			{
				CrThZHCyLlakodEBANFarmiXBcA = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return MovementAreaUnit.Screen;
				}
				return zVzWtMJHMCyazIinygcNCUNWfFBN;
			}
			set
			{
				zVzWtMJHMCyazIinygcNCUNWfFBN = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return ctCEBnclQdYIFKzGOHbQUiuiWZfF;
			}
			set
			{
				KPGoqyNToDqKyiUOdHexBWVqMLA(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return eXXUQvfvptsScDkRpeCjEAKIyECE;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return hyJMMrGplBkUWbpJEhSxtaQVnqF;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (qHtlLMGkCJMWaJeByUnHRArSgtu < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[qHtlLMGkCJMWaJeByUnHRArSgtu];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (KkAoWkPKttiOrCpGeGZZHgxyPHWE < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[KkAoWkPKttiOrCpGeGZZHgxyPHWE];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (OnTzInojThQYFSFrQnAfCELwZtC < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[OnTzInojThQYFSFrQnAfCELwZtC];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (YCFhOxWtmPXnKqcbtGthKxhJBaeU < 0)
				{
					return null;
				}
				return base.buttons[YCFhOxWtmPXnKqcbtGthKxhJBaeU];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (eUyyAPfkgiFQYFWQKvaiQMErLPLT < 0)
				{
					return null;
				}
				return base.buttons[eUyyAPfkgiFQYFWQKvaiQMErLPLT];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				if (vrQFSzLyOXwdAHbWCHVqEBTUBJNj < 0)
				{
					return null;
				}
				return base.buttons[vrQFSzLyOXwdAHbWCHVqEBTUBJNj];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0f;
				}
				return bdgjRdBsyIhDHfRYGDrUZlIgQxB;
			}
			set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				bdgjRdBsyIhDHfRYGDrUZlIgQxB = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return griBBuygpJHCzYHNxaNjmbNNGit;
			}
			set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return;
				}
				griBBuygpJHCzYHNxaNjmbNNGit = value;
				if (!value)
				{
					qrFDPnxBHrwPZdObwtOFBAHAfkt();
				}
			}
		}

		bool IMouseInputSource.enabled => base.enabled;

		Vector2 IMouseInputSource.screenPosition => ctCEBnclQdYIFKzGOHbQUiuiWZfF;

		Vector2 IMouseInputSource.screenPositionDelta => hyJMMrGplBkUWbpJEhSxtaQVnqF;

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
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					QbGbuVpvOLMDInIWNSsPjKasOcA = (Action<Vector2>)Delegate.Combine(QbGbuVpvOLMDInIWNSsPjKasOcA, value);
				}
			}
			remove
			{
				QbGbuVpvOLMDInIWNSsPjKasOcA = (Action<Vector2>)Delegate.Remove(QbGbuVpvOLMDInIWNSsPjKasOcA, value);
			}
		}

		private PlayerMouse(Definition definition)
			: base(definition)
		{
			XxJQiVcNDeipDiYiNMHqSOEuvYUB = definition.defaultToCenter;
			KuClogCPGxokMSeImgRjDxONioHF = definition.clampToMovementArea;
			CrThZHCyLlakodEBANFarmiXBcA = definition.movementArea;
			zVzWtMJHMCyazIinygcNCUNWfFBN = definition.movementAreaUnit;
			bdgjRdBsyIhDHfRYGDrUZlIgQxB = definition.pointerSpeed;
			griBBuygpJHCzYHNxaNjmbNNGit = definition.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && object.ReferenceEquals(base.elements[i].GetType(), typeof(MouseAxis)))
				{
					if (num2 == 0)
					{
						qHtlLMGkCJMWaJeByUnHRArSgtu = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						KkAoWkPKttiOrCpGeGZZHgxyPHWE = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (OnTzInojThQYFSFrQnAfCELwZtC < 0 && base.elements[i] is MouseWheel)
				{
					OnTzInojThQYFSFrQnAfCELwZtC = i;
				}
				else if (num3 < 3 && object.ReferenceEquals(base.elements[i].GetType(), typeof(Button)))
				{
					switch (num3)
					{
					case 0:
						YCFhOxWtmPXnKqcbtGthKxhJBaeU = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						eUyyAPfkgiFQYFWQKvaiQMErLPLT = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						vrQFSzLyOXwdAHbWCHVqEBTUBJNj = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (OnTzInojThQYFSFrQnAfCELwZtC < 0)
			{
				int num4 = PlayerController.csxuKUIFFDGmHdlmOknQRXQYDjW(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 1);
				int num5 = PlayerController.csxuKUIFFDGmHdlmOknQRXQYDjW(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					sPDBUryojEPTZhjXiDvYbSylxsi(mouseWheel);
					OnTzInojThQYFSFrQnAfCELwZtC = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						sPDBUryojEPTZhjXiDvYbSylxsi(element);
						mouseWheel.sPDBUryojEPTZhjXiDvYbSylxsi(element);
						mouseWheel.sPDBUryojEPTZhjXiDvYbSylxsi((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.sPDBUryojEPTZhjXiDvYbSylxsi(base.axes[num4]);
						mouseWheel.sPDBUryojEPTZhjXiDvYbSylxsi(base.axes[num5]);
					}
				}
			}
			if (XxJQiVcNDeipDiYiNMHqSOEuvYUB)
			{
				ScreenRect screenRect = eNvVdJuIKZFghEUxwYVbGyQjdBGw();
				ctCEBnclQdYIFKzGOHbQUiuiWZfF = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				ctCEBnclQdYIFKzGOHbQUiuiWZfF = Vector2.zero;
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
			if (griBBuygpJHCzYHNxaNjmbNNGit && (player = base.player) != null)
			{
				if (!player.controllers.hasMouse)
				{
					qrFDPnxBHrwPZdObwtOFBAHAfkt();
				}
				else
				{
					JWAFEMdMnfvPaQmXCJmmlWybRXOb = ReInput.controllers.Mouse.screenPosition;
					if (JWAFEMdMnfvPaQmXCJmmlWybRXOb.x != SgGxuinWZiReQFkUkVYMNVCQQZo.x || JWAFEMdMnfvPaQmXCJmmlWybRXOb.y != SgGxuinWZiReQFkUkVYMNVCQQZo.y)
					{
						ctCEBnclQdYIFKzGOHbQUiuiWZfF.x = JWAFEMdMnfvPaQmXCJmmlWybRXOb.x;
						ctCEBnclQdYIFKzGOHbQUiuiWZfF.y = JWAFEMdMnfvPaQmXCJmmlWybRXOb.y;
					}
					SgGxuinWZiReQFkUkVYMNVCQQZo.x = JWAFEMdMnfvPaQmXCJmmlWybRXOb.x;
					SgGxuinWZiReQFkUkVYMNVCQQZo.y = JWAFEMdMnfvPaQmXCJmmlWybRXOb.y;
				}
			}
			if (qHtlLMGkCJMWaJeByUnHRArSgtu >= 0)
			{
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.x = XOFvbmRbixdbTIHZBNhcizyGbJrt(base.axes[qHtlLMGkCJMWaJeByUnHRArSgtu], ctCEBnclQdYIFKzGOHbQUiuiWZfF.x, bdgjRdBsyIhDHfRYGDrUZlIgQxB);
			}
			if (KkAoWkPKttiOrCpGeGZZHgxyPHWE >= 0)
			{
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.y = XOFvbmRbixdbTIHZBNhcizyGbJrt(base.axes[KkAoWkPKttiOrCpGeGZZHgxyPHWE], ctCEBnclQdYIFKzGOHbQUiuiWZfF.y, bdgjRdBsyIhDHfRYGDrUZlIgQxB);
			}
			KPGoqyNToDqKyiUOdHexBWVqMLA(ctCEBnclQdYIFKzGOHbQUiuiWZfF);
			hyJMMrGplBkUWbpJEhSxtaQVnqF.x = ctCEBnclQdYIFKzGOHbQUiuiWZfF.x - eXXUQvfvptsScDkRpeCjEAKIyECE.x;
			hyJMMrGplBkUWbpJEhSxtaQVnqF.y = ctCEBnclQdYIFKzGOHbQUiuiWZfF.y - eXXUQvfvptsScDkRpeCjEAKIyECE.y;
			UgwLiUJOIxftKkZoywoAcLfKXjwp = ctCEBnclQdYIFKzGOHbQUiuiWZfF.x != eXXUQvfvptsScDkRpeCjEAKIyECE.x || ctCEBnclQdYIFKzGOHbQUiuiWZfF.y != eXXUQvfvptsScDkRpeCjEAKIyECE.y;
			eXXUQvfvptsScDkRpeCjEAKIyECE.x = ctCEBnclQdYIFKzGOHbQUiuiWZfF.x;
			eXXUQvfvptsScDkRpeCjEAKIyECE.y = ctCEBnclQdYIFKzGOHbQUiuiWZfF.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (UgwLiUJOIxftKkZoywoAcLfKXjwp && QbGbuVpvOLMDInIWNSsPjKasOcA != null)
			{
				try
				{
					QbGbuVpvOLMDInIWNSsPjKasOcA(ctCEBnclQdYIFKzGOHbQUiuiWZfF);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				UgwLiUJOIxftKkZoywoAcLfKXjwp = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			eXXUQvfvptsScDkRpeCjEAKIyECE = ctCEBnclQdYIFKzGOHbQUiuiWZfF;
			hyJMMrGplBkUWbpJEhSxtaQVnqF = Vector2.zero;
			qrFDPnxBHrwPZdObwtOFBAHAfkt();
			UgwLiUJOIxftKkZoywoAcLfKXjwp = false;
		}

		private void KPGoqyNToDqKyiUOdHexBWVqMLA(Vector2 P_0)
		{
			if (!KuClogCPGxokMSeImgRjDxONioHF)
			{
				ctCEBnclQdYIFKzGOHbQUiuiWZfF = P_0;
				return;
			}
			if (zVzWtMJHMCyazIinygcNCUNWfFBN == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.x = Mathf.Clamp(P_0.x, CrThZHCyLlakodEBANFarmiXBcA.xMin * num, CrThZHCyLlakodEBANFarmiXBcA.xMax * num);
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.y = Mathf.Clamp(P_0.y, CrThZHCyLlakodEBANFarmiXBcA.yMin * num2, CrThZHCyLlakodEBANFarmiXBcA.yMax * num2);
				return;
			}
			if (zVzWtMJHMCyazIinygcNCUNWfFBN == MovementAreaUnit.Pixel)
			{
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.x = Mathf.Clamp(P_0.x, CrThZHCyLlakodEBANFarmiXBcA.xMin, CrThZHCyLlakodEBANFarmiXBcA.xMax);
				ctCEBnclQdYIFKzGOHbQUiuiWZfF.y = Mathf.Clamp(P_0.y, CrThZHCyLlakodEBANFarmiXBcA.yMin, CrThZHCyLlakodEBANFarmiXBcA.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect eNvVdJuIKZFghEUxwYVbGyQjdBGw()
		{
			if (zVzWtMJHMCyazIinygcNCUNWfFBN == MovementAreaUnit.Screen)
			{
				return new ScreenRect(CrThZHCyLlakodEBANFarmiXBcA.xMin * (float)Screen.width, CrThZHCyLlakodEBANFarmiXBcA.yMin * (float)Screen.height, CrThZHCyLlakodEBANFarmiXBcA.width * (float)Screen.width, CrThZHCyLlakodEBANFarmiXBcA.height * (float)Screen.height);
			}
			if (zVzWtMJHMCyazIinygcNCUNWfFBN == MovementAreaUnit.Pixel)
			{
				return CrThZHCyLlakodEBANFarmiXBcA;
			}
			throw new NotImplementedException();
		}

		private void qrFDPnxBHrwPZdObwtOFBAHAfkt()
		{
			JWAFEMdMnfvPaQmXCJmmlWybRXOb = Vector2.zero;
			SgGxuinWZiReQFkUkVYMNVCQQZo = Vector2.zero;
		}

		private static float XOFvbmRbixdbTIHZBNhcizyGbJrt(Axis P_0, float P_1, float P_2)
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

		private bool mFxIDcZiPwHIGgddTVNcaGZeBMd(int P_0)
		{
			return GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mFxIDcZiPwHIGgddTVNcaGZeBMd
			return this.mFxIDcZiPwHIGgddTVNcaGZeBMd(P_0);
		}

		private bool TJBwAaPFQpSgbgIPbITOSwRYyeN(int P_0)
		{
			return GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TJBwAaPFQpSgbgIPbITOSwRYyeN
			return this.TJBwAaPFQpSgbgIPbITOSwRYyeN(P_0);
		}

		private bool jwznFzyhIYSBDlFZAmqDHBdoMIH(int P_0)
		{
			return GetButton(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jwznFzyhIYSBDlFZAmqDHBdoMIH
			return this.jwznFzyhIYSBDlFZAmqDHBdoMIH(P_0);
		}

		[CompilerGenerated]
		private static bool GVnqNLNJumCigNUfxLKlLJWjhoO(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}

		[CompilerGenerated]
		private static bool zNxksABFhJnoBRTGjiDxpmVwYch(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}
	}
}

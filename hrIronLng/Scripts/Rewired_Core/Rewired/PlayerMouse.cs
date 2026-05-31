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

			public ScreenRect movementArea = cgIjUfqLGpVqPqngnzFeqDgOnOX;

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
				return ikoBGVHHLVNnLaVaWGffMETVhTJw(3, 3);
			}

			private static PlayerMouse ikoBGVHHLVNnLaVaWGffMETVhTJw(int P_0, int P_1)
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

		internal const bool zWaSTbpiWutZtNmVdZcNIEBbeAw = true;

		internal const float PhBYtNCPaKAfQFdkyoFrnONhCAo = 1f;

		internal const bool AmfiMslzUGqfRiJrCiJwQrigDhv = true;

		internal const bool NrvzOWjhJNgyPhsixIXpCNuIEdll = true;

		internal const MovementAreaUnit weKqtzaimoKRjlItkEwDJEbGYgZ = MovementAreaUnit.Screen;

		private const int TKlQjmGlvPDkHfAPSfrfLzhNUxC = 3;

		private const int HVYytBgGDSSjINiaZjxmJcOfERw = 3;

		internal const string FUTkinxIWDikNGhJJkMGeEeENyx = "Movement";

		internal const string qdiRZrlssqsIYwUIulboDpDVJPH = "Horizontal";

		internal const string VRHujglEYfrxtteRoyoEXsEvrZt = "Vertical";

		internal const string XjEZxeJpgdwJClVEmvdvUTPbNGu = "Wheel";

		internal const string saAVUGkXfshBdxFmekXHgNJoJDh = "Wheel Horizontal";

		internal const string dPFHQNuyBWnyNGyCSnJEtgwPALVK = "Wheel Vertical";

		internal const string uiTWhlheofiaSkLChMzWPRvJFfXG = "Left Button";

		internal const string dtZjRcghueqBTYeZOAyOzPiYPia = "Right Button";

		internal const string VtIEAYhqztBrYYIXBnCCmltJtLB = "Middle Button";

		internal static readonly ScreenRect cgIjUfqLGpVqPqngnzFeqDgOnOX = new ScreenRect(0f, 0f, 1f, 1f);

		private readonly int sthcWTDKqoPrLFQJDgxiAoaAEHa = -1;

		private readonly int CuVUUynxzIvCuEEbtGsKNQEuhSK = -1;

		private readonly int mGcCzCCuIkufdIDkzqVENaIUEPcw = -1;

		private readonly int omtQhXtQFUmEMnUZySfqfWEbJuK = -1;

		private readonly int CyKKphURJrRlWTHuFnudCbtZXFd = -1;

		private readonly int NeasPNuklWVJCEucRHtzSpasZRf = -1;

		private bool exKZNcuyhksMCUJYbZiXLnQiybA;

		private Vector2 hqsqlelmYqupangbJBwhMsNZPNi;

		private Vector2 wasOYNQyNtgMvKMApVHGRoUoEUc;

		private Vector2 SgmruLUfjiptJwhePdtLduLQWPZa;

		private Vector2 ABhJzHOuOswluSMhiiSiHGxulSiJ;

		private Vector2 VNpedBBlIIoxSXijDtEakvppEyng;

		private float JmIRyFXdTNawBEAsDqdHhObEjlpe;

		private bool YNCcVGPoRIiwbNdzscDquqkhWHX;

		private Action<Vector2> sHgMQMMnAArUNuuiQQvvfOrCKAc;

		private bool pulfLdgBqzrUVSJUEtZnKCdGQIej;

		private ScreenRect qGxzynjpmiBRuqYzTJqrhDPrsoa;

		private bool uGiAZGhhpuYPWWTmzQTofLffawnW;

		private MovementAreaUnit PjRJCckBdFZTbJDDjFsEJIqqCTdS;

		[CompilerGenerated]
		private static Predicate<Axis> ZyemrtlocPgopITzwWGmeAtLePxI;

		[CompilerGenerated]
		private static Predicate<Axis> fqbZuOCzaGEtjRCXGpKkmkLnbRtb;

		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return pulfLdgBqzrUVSJUEtZnKCdGQIej;
			}
			set
			{
				pulfLdgBqzrUVSJUEtZnKCdGQIej = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return uGiAZGhhpuYPWWTmzQTofLffawnW;
			}
			set
			{
				uGiAZGhhpuYPWWTmzQTofLffawnW = value;
			}
		}

		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return default(ScreenRect);
				}
				return qGxzynjpmiBRuqYzTJqrhDPrsoa;
			}
			set
			{
				qGxzynjpmiBRuqYzTJqrhDPrsoa = value;
			}
		}

		public MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return MovementAreaUnit.Screen;
				}
				return PjRJCckBdFZTbJDDjFsEJIqqCTdS;
			}
			set
			{
				PjRJCckBdFZTbJDDjFsEJIqqCTdS = value;
			}
		}

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return SgmruLUfjiptJwhePdtLduLQWPZa;
			}
			set
			{
				ucaCXKfkZKqraDfwaZesmVaELRmY(value);
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return ABhJzHOuOswluSMhiiSiHGxulSiJ;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return VNpedBBlIIoxSXijDtEakvppEyng;
			}
		}

		public MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (CuVUUynxzIvCuEEbtGsKNQEuhSK < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[CuVUUynxzIvCuEEbtGsKNQEuhSK];
			}
		}

		public MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (mGcCzCCuIkufdIDkzqVENaIUEPcw < 0)
				{
					return null;
				}
				return (MouseAxis)base.axes[mGcCzCCuIkufdIDkzqVENaIUEPcw];
			}
		}

		public MouseWheel wheel
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (sthcWTDKqoPrLFQJDgxiAoaAEHa < 0)
				{
					return null;
				}
				return (MouseWheel)base.elements[sthcWTDKqoPrLFQJDgxiAoaAEHa];
			}
		}

		public Button leftButton
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (omtQhXtQFUmEMnUZySfqfWEbJuK < 0)
				{
					return null;
				}
				return base.buttons[omtQhXtQFUmEMnUZySfqfWEbJuK];
			}
		}

		public Button rightButton
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (CyKKphURJrRlWTHuFnudCbtZXFd < 0)
				{
					return null;
				}
				return base.buttons[CyKKphURJrRlWTHuFnudCbtZXFd];
			}
		}

		public Button middleButton
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				if (NeasPNuklWVJCEucRHtzSpasZRf < 0)
				{
					return null;
				}
				return base.buttons[NeasPNuklWVJCEucRHtzSpasZRf];
			}
		}

		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0f;
				}
				return JmIRyFXdTNawBEAsDqdHhObEjlpe;
			}
			set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				JmIRyFXdTNawBEAsDqdHhObEjlpe = value;
			}
		}

		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return YNCcVGPoRIiwbNdzscDquqkhWHX;
			}
			set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				YNCcVGPoRIiwbNdzscDquqkhWHX = value;
				if (!value)
				{
					SXtduBMVemcBNeBXzqrEVMasYuV();
				}
			}
		}

		bool IMouseInputSource.enabled => base.enabled;

		Vector2 IMouseInputSource.screenPosition => SgmruLUfjiptJwhePdtLduLQWPZa;

		Vector2 IMouseInputSource.screenPositionDelta => VNpedBBlIIoxSXijDtEakvppEyng;

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
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					sHgMQMMnAArUNuuiQQvvfOrCKAc = (Action<Vector2>)Delegate.Combine(sHgMQMMnAArUNuuiQQvvfOrCKAc, value);
				}
			}
			remove
			{
				sHgMQMMnAArUNuuiQQvvfOrCKAc = (Action<Vector2>)Delegate.Remove(sHgMQMMnAArUNuuiQQvvfOrCKAc, value);
			}
		}

		private PlayerMouse(Definition definition)
			: base(definition)
		{
			pulfLdgBqzrUVSJUEtZnKCdGQIej = definition.defaultToCenter;
			uGiAZGhhpuYPWWTmzQTofLffawnW = definition.clampToMovementArea;
			qGxzynjpmiBRuqYzTJqrhDPrsoa = definition.movementArea;
			PjRJCckBdFZTbJDDjFsEJIqqCTdS = definition.movementAreaUnit;
			JmIRyFXdTNawBEAsDqdHhObEjlpe = definition.pointerSpeed;
			YNCcVGPoRIiwbNdzscDquqkhWHX = definition.useHardwarePointerPosition;
			int num = base.elementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && object.ReferenceEquals(base.elements[i].GetType(), typeof(MouseAxis)))
				{
					if (num2 == 0)
					{
						CuVUUynxzIvCuEEbtGsKNQEuhSK = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					else
					{
						mGcCzCCuIkufdIDkzqVENaIUEPcw = base.axes.IndexOf((MouseAxis)base.elements[i]);
					}
					num2++;
				}
				else if (sthcWTDKqoPrLFQJDgxiAoaAEHa < 0 && base.elements[i] is MouseWheel)
				{
					sthcWTDKqoPrLFQJDgxiAoaAEHa = i;
				}
				else if (num3 < 3 && object.ReferenceEquals(base.elements[i].GetType(), typeof(Button)))
				{
					switch (num3)
					{
					case 0:
						omtQhXtQFUmEMnUZySfqfWEbJuK = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 1:
						CyKKphURJrRlWTHuFnudCbtZXFd = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					case 2:
						NeasPNuklWVJCEucRHtzSpasZRf = base.buttons.IndexOf((Button)base.elements[i]);
						break;
					}
					num3++;
				}
			}
			if (sthcWTDKqoPrLFQJDgxiAoaAEHa < 0)
			{
				int num4 = PlayerController.IBJFxwhgESZPVuIABbZHTfQgjyg(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 1);
				int num5 = PlayerController.IBJFxwhgESZPVuIABbZHTfQgjyg(base.axes, (Axis P_0) => object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)) && !P_0.isMemberElement, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					SSjwBZRYcJqbFyjnlHATtvRHxFM(mouseWheel);
					sthcWTDKqoPrLFQJDgxiAoaAEHa = base.elements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						SSjwBZRYcJqbFyjnlHATtvRHxFM(element);
						mouseWheel.SSjwBZRYcJqbFyjnlHATtvRHxFM(element);
						mouseWheel.SSjwBZRYcJqbFyjnlHATtvRHxFM((num4 < 0) ? base.axes[num5] : base.axes[num4]);
					}
					else
					{
						mouseWheel.SSjwBZRYcJqbFyjnlHATtvRHxFM(base.axes[num4]);
						mouseWheel.SSjwBZRYcJqbFyjnlHATtvRHxFM(base.axes[num5]);
					}
				}
			}
			if (pulfLdgBqzrUVSJUEtZnKCdGQIej)
			{
				ScreenRect screenRect = UWRDMbJorKvBlRNBlnDagStNuRm();
				SgmruLUfjiptJwhePdtLduLQWPZa = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				SgmruLUfjiptJwhePdtLduLQWPZa = Vector2.zero;
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
			if (YNCcVGPoRIiwbNdzscDquqkhWHX && (player = base.player) != null)
			{
				if (!player.controllers.hasMouse)
				{
					SXtduBMVemcBNeBXzqrEVMasYuV();
				}
				else
				{
					hqsqlelmYqupangbJBwhMsNZPNi = ReInput.controllers.Mouse.screenPosition;
					if (hqsqlelmYqupangbJBwhMsNZPNi.x != wasOYNQyNtgMvKMApVHGRoUoEUc.x || hqsqlelmYqupangbJBwhMsNZPNi.y != wasOYNQyNtgMvKMApVHGRoUoEUc.y)
					{
						SgmruLUfjiptJwhePdtLduLQWPZa.x = hqsqlelmYqupangbJBwhMsNZPNi.x;
						SgmruLUfjiptJwhePdtLduLQWPZa.y = hqsqlelmYqupangbJBwhMsNZPNi.y;
					}
					wasOYNQyNtgMvKMApVHGRoUoEUc.x = hqsqlelmYqupangbJBwhMsNZPNi.x;
					wasOYNQyNtgMvKMApVHGRoUoEUc.y = hqsqlelmYqupangbJBwhMsNZPNi.y;
				}
			}
			if (CuVUUynxzIvCuEEbtGsKNQEuhSK >= 0)
			{
				SgmruLUfjiptJwhePdtLduLQWPZa.x = jzneUQofFyESTHWhAchbBtDITXRZ(base.axes[CuVUUynxzIvCuEEbtGsKNQEuhSK], SgmruLUfjiptJwhePdtLduLQWPZa.x, JmIRyFXdTNawBEAsDqdHhObEjlpe);
			}
			if (mGcCzCCuIkufdIDkzqVENaIUEPcw >= 0)
			{
				SgmruLUfjiptJwhePdtLduLQWPZa.y = jzneUQofFyESTHWhAchbBtDITXRZ(base.axes[mGcCzCCuIkufdIDkzqVENaIUEPcw], SgmruLUfjiptJwhePdtLduLQWPZa.y, JmIRyFXdTNawBEAsDqdHhObEjlpe);
			}
			ucaCXKfkZKqraDfwaZesmVaELRmY(SgmruLUfjiptJwhePdtLduLQWPZa);
			VNpedBBlIIoxSXijDtEakvppEyng.x = SgmruLUfjiptJwhePdtLduLQWPZa.x - ABhJzHOuOswluSMhiiSiHGxulSiJ.x;
			VNpedBBlIIoxSXijDtEakvppEyng.y = SgmruLUfjiptJwhePdtLduLQWPZa.y - ABhJzHOuOswluSMhiiSiHGxulSiJ.y;
			exKZNcuyhksMCUJYbZiXLnQiybA = SgmruLUfjiptJwhePdtLduLQWPZa.x != ABhJzHOuOswluSMhiiSiHGxulSiJ.x || SgmruLUfjiptJwhePdtLduLQWPZa.y != ABhJzHOuOswluSMhiiSiHGxulSiJ.y;
			ABhJzHOuOswluSMhiiSiHGxulSiJ.x = SgmruLUfjiptJwhePdtLduLQWPZa.x;
			ABhJzHOuOswluSMhiiSiHGxulSiJ.y = SgmruLUfjiptJwhePdtLduLQWPZa.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (exKZNcuyhksMCUJYbZiXLnQiybA && sHgMQMMnAArUNuuiQQvvfOrCKAc != null)
			{
				try
				{
					sHgMQMMnAArUNuuiQQvvfOrCKAc(SgmruLUfjiptJwhePdtLduLQWPZa);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				exKZNcuyhksMCUJYbZiXLnQiybA = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			ABhJzHOuOswluSMhiiSiHGxulSiJ = SgmruLUfjiptJwhePdtLduLQWPZa;
			VNpedBBlIIoxSXijDtEakvppEyng = Vector2.zero;
			SXtduBMVemcBNeBXzqrEVMasYuV();
			exKZNcuyhksMCUJYbZiXLnQiybA = false;
		}

		private void ucaCXKfkZKqraDfwaZesmVaELRmY(Vector2 P_0)
		{
			if (!uGiAZGhhpuYPWWTmzQTofLffawnW)
			{
				SgmruLUfjiptJwhePdtLduLQWPZa = P_0;
				return;
			}
			if (PjRJCckBdFZTbJDDjFsEJIqqCTdS == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				SgmruLUfjiptJwhePdtLduLQWPZa.x = Mathf.Clamp(P_0.x, qGxzynjpmiBRuqYzTJqrhDPrsoa.xMin * num, qGxzynjpmiBRuqYzTJqrhDPrsoa.xMax * num);
				SgmruLUfjiptJwhePdtLduLQWPZa.y = Mathf.Clamp(P_0.y, qGxzynjpmiBRuqYzTJqrhDPrsoa.yMin * num2, qGxzynjpmiBRuqYzTJqrhDPrsoa.yMax * num2);
				return;
			}
			if (PjRJCckBdFZTbJDDjFsEJIqqCTdS == MovementAreaUnit.Pixel)
			{
				SgmruLUfjiptJwhePdtLduLQWPZa.x = Mathf.Clamp(P_0.x, qGxzynjpmiBRuqYzTJqrhDPrsoa.xMin, qGxzynjpmiBRuqYzTJqrhDPrsoa.xMax);
				SgmruLUfjiptJwhePdtLduLQWPZa.y = Mathf.Clamp(P_0.y, qGxzynjpmiBRuqYzTJqrhDPrsoa.yMin, qGxzynjpmiBRuqYzTJqrhDPrsoa.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect UWRDMbJorKvBlRNBlnDagStNuRm()
		{
			if (PjRJCckBdFZTbJDDjFsEJIqqCTdS == MovementAreaUnit.Screen)
			{
				return new ScreenRect(qGxzynjpmiBRuqYzTJqrhDPrsoa.xMin * (float)Screen.width, qGxzynjpmiBRuqYzTJqrhDPrsoa.yMin * (float)Screen.height, qGxzynjpmiBRuqYzTJqrhDPrsoa.width * (float)Screen.width, qGxzynjpmiBRuqYzTJqrhDPrsoa.height * (float)Screen.height);
			}
			if (PjRJCckBdFZTbJDDjFsEJIqqCTdS == MovementAreaUnit.Pixel)
			{
				return qGxzynjpmiBRuqYzTJqrhDPrsoa;
			}
			throw new NotImplementedException();
		}

		private void SXtduBMVemcBNeBXzqrEVMasYuV()
		{
			hqsqlelmYqupangbJBwhMsNZPNi = Vector2.zero;
			wasOYNQyNtgMvKMApVHGRoUoEUc = Vector2.zero;
		}

		private static float jzneUQofFyESTHWhAchbBtDITXRZ(Axis P_0, float P_1, float P_2)
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

		private bool GBbtFxkuJIaqEfGZcHRWirtdFKs(int P_0)
		{
			return GetButtonDown(P_0);
		}

		bool IMouseInputSource.GetButtonDown(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GBbtFxkuJIaqEfGZcHRWirtdFKs
			return this.GBbtFxkuJIaqEfGZcHRWirtdFKs(P_0);
		}

		private bool bdnixGuZpsJPhxqjkCRFfIgqmmjN(int P_0)
		{
			return GetButtonUp(P_0);
		}

		bool IMouseInputSource.GetButtonUp(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in bdnixGuZpsJPhxqjkCRFfIgqmmjN
			return this.bdnixGuZpsJPhxqjkCRFfIgqmmjN(P_0);
		}

		private bool JdRCSDRtSBKpJiNzNzaOHOIEhIx(int P_0)
		{
			return GetButton(P_0);
		}

		bool IMouseInputSource.GetButton(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JdRCSDRtSBKpJiNzNzaOHOIEhIx
			return this.JdRCSDRtSBKpJiNzNzaOHOIEhIx(P_0);
		}

		[CompilerGenerated]
		private static bool qsNfcdCmDdxXmRWNuNAqiBfXDuaT(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}

		[CompilerGenerated]
		private static bool HCjRgMcOseABsInvaqUAhgLrSMI(Axis P_0)
		{
			if (object.ReferenceEquals(P_0.GetType(), typeof(MouseWheelAxis)))
			{
				return !P_0.isMemberElement;
			}
			return false;
		}
	}
}

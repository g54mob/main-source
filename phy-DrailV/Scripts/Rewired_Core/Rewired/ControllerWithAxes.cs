using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class RgscfvvcMEijEPLIOaORJrIVfXIH : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public RgscfvvcMEijEPLIOaORJrIVfXIH(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				ControllerWithAxes controllerWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00a8;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				controllerWithAxes.UpdatePollingFrameTracking();
				controllerWithAxes.CdMgAxDFVECTcfStINeXinkHUclkB();
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00ba;
				IL_00ba:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < controllerWithAxes._axisCount)
				{
					if (controllerWithAxes.IsPolledAxisActive(XFqmAWzGaybkkIOLbVBNhzaWDOgGA, out var pole, out var elementIdentifierId))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ControllerPollingInfo(true, -1, controllerWithAxes.id, controllerWithAxes._name, controllerWithAxes._type, ControllerElementType.Axis, XFqmAWzGaybkkIOLbVBNhzaWDOgGA, pole, controllerWithAxes.AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
				goto IL_00ba;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				RgscfvvcMEijEPLIOaORJrIVfXIH rgscfvvcMEijEPLIOaORJrIVfXIH;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					rgscfvvcMEijEPLIOaORJrIVfXIH = this;
				}
				else
				{
					rgscfvvcMEijEPLIOaORJrIVfXIH = new RgscfvvcMEijEPLIOaORJrIVfXIH(0);
					rgscfvvcMEijEPLIOaORJrIVfXIH.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return rgscfvvcMEijEPLIOaORJrIVfXIH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class XxawRcAJdXuUmwHcJCeKErOZzPaKA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public XxawRcAJdXuUmwHcJCeKErOZzPaKA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						DZNbUKmveIqGkvckqgFZbMBdZwyW();
					}
				case -2:
				case -1:
				case 0:
					break;
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					ControllerWithAxes controllerWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_0092;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_0092;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
							break;
						}
						IL_0092:
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
						{
							ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = controllerWithAxes.PollForAllAxes().GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						vjnbYLtrPMftzpjohNfommerCnGo = current2;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
						return true;
					}
					DZNbUKmveIqGkvckqgFZbMBdZwyW();
					XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
				}
			}

			private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				XxawRcAJdXuUmwHcJCeKErOZzPaKA xxawRcAJdXuUmwHcJCeKErOZzPaKA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					xxawRcAJdXuUmwHcJCeKErOZzPaKA = this;
				}
				else
				{
					xxawRcAJdXuUmwHcJCeKErOZzPaKA = new XxawRcAJdXuUmwHcJCeKErOZzPaKA(0);
					xxawRcAJdXuUmwHcJCeKErOZzPaKA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return xxawRcAJdXuUmwHcJCeKErOZzPaKA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class vQjXShybWoIzTBCHhPSvifcYCxWk : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public ControllerWithAxes zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public vQjXShybWoIzTBCHhPSvifcYCxWk(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						DZNbUKmveIqGkvckqgFZbMBdZwyW();
					}
				case -2:
				case -1:
				case 0:
					break;
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					ControllerWithAxes controllerWithAxes = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (ReInput._id != controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs)
						{
							ReInput.CheckInitialized(controllerWithAxes.oLUDKIBSDOGsiswKzVsPEXOleBcs);
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = ((Controller)controllerWithAxes).PollForAllElementsDown().GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_0092;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_0092;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
							break;
						}
						IL_0092:
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
						{
							ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
							vjnbYLtrPMftzpjohNfommerCnGo = current;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = controllerWithAxes.PollForAllAxes().GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
						break;
					}
					if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						vjnbYLtrPMftzpjohNfommerCnGo = current2;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
						return true;
					}
					DZNbUKmveIqGkvckqgFZbMBdZwyW();
					XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
				}
			}

			private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				vQjXShybWoIzTBCHhPSvifcYCxWk vQjXShybWoIzTBCHhPSvifcYCxWk2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					vQjXShybWoIzTBCHhPSvifcYCxWk2 = this;
				}
				else
				{
					vQjXShybWoIzTBCHhPSvifcYCxWk2 = new vQjXShybWoIzTBCHhPSvifcYCxWk(0);
					vQjXShybWoIzTBCHhPSvifcYCxWk2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return vQjXShybWoIzTBCHhPSvifcYCxWk2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected readonly CalibrationMap _calibrationMap;

		private float[] feCedpVriqqzAOLqUyIwUnMFsVXD;

		private uint IjuRRkaDFAcJjhVhXRNciqgFpJHm = uint.MaxValue;

		private Func<int, int> LhxrBpdwPNeguhTeHuWFDuAawjgD;

		public int axisCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return AWCbIECppuLDtCThiwONsElGeIEub.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, int P_8, bool[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
			: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_8, P_9, P_10, P_11, P_12)
		{
			_axisCount = P_7;
			axes = new Axis[P_7];
			for (int i = 0; i < P_7; i++)
			{
				axes[i] = new Axis(this, P_10.axisElementIdentifierIds[i], "Axis " + i, P_10.hwAxisRanges[i], P_10.hwAxisInfo[i]);
				noRZOaiqNhQVUigJbcItGViYdGAm(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			Func<int, int> func = null;
			if (base.extension is IAxisCalibrationIndexMap)
			{
				func = (int num2) => (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap) ? axisCalibrationIndexMap.GetMappedAxisIndex(num2) : num2;
			}
			_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData, func);
			_axis2DCount = P_10.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int num = 0; num < _axis2DCount; num++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = P_10.GetAxis2DData(num);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, null);
					}
					else
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[num] = new Axis2D(this, -1, "Axis 2D " + num, null, null, 0, 0, null);
				}
				finally
				{
					YyaDpuFfMbbFmjWsPsiaQKFYXYeIA(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			wtMcLWGCHHbPAvJejDUwNBxSiRKk();
			LhxrBpdwPNeguhTeHuWFDuAawjgD = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (AWCbIECppuLDtCThiwONsElGeIEub == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return -1;
			}
			return AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].value;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valuePrev;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRaw;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRawPrev;
		}

		public double GetAxisTimeActive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActive;
		}

		public double GetAxisTimeInactive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactive;
		}

		public double GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActive;
		}

		public double GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactive;
		}

		public double GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActiveRaw;
		}

		public double GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactiveRaw;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int axisIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].value;
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valuePrev;
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRaw;
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRawPrev;
		}

		public override double GetLastTimeActive()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override double GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public double GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(useRawValues: false);
		}

		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeActiveRaw : axes[i].lastTimeActive);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public double GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(useRawValues: false);
		}

		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeValueChangedRaw : axes[i].lastTimeValueChanged);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			UpdatePollingFrameTracking();
			CdMgAxDFVECTcfStINeXinkHUclkB();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new XxawRcAJdXuUmwHcJCeKErOZzPaKA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new vQjXShybWoIzTBCHhPSvifcYCxWk(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new RgscfvvcMEijEPLIOaORJrIVfXIH(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		private void CdMgAxDFVECTcfStINeXinkHUclkB()
		{
			if (feCedpVriqqzAOLqUyIwUnMFsVXD == null)
			{
				feCedpVriqqzAOLqUyIwUnMFsVXD = new float[_axisCount];
			}
			if (KBOiXIHMwaZReSHtGzdvSSUAqTYf != IjuRRkaDFAcJjhVhXRNciqgFpJHm)
			{
				IjuRRkaDFAcJjhVhXRNciqgFpJHm = KBOiXIHMwaZReSHtGzdvSSUAqTYf;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					feCedpVriqqzAOLqUyIwUnMFsVXD[i] = axes[i].BjASuoyPygZcuHpmMKpNHUOtpLWB(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].wzuKsMAQzNUDQMPTfMKsvinBDhokA != null)
			{
				if (axes[index].wzuKsMAQzNUDQMPTfMKsvinBDhokA._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].wzuKsMAQzNUDQMPTfMKsvinBDhokA._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].BjASuoyPygZcuHpmMKpNHUOtpLWB(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - feCedpVriqqzAOLqUyIwUnMFsVXD[index];
			if (MathTools.Abs(value) <= axes[index].ZgDzvulGLNTUslBWphultbDIfPTbA)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = AWCbIECppuLDtCThiwONsElGeIEub.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void tglbagDKhFNyJrooYNWfohsJFQmi(UpdateLoopType P_0)
		{
			base.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !fcpRkkeLOqieJylVwWSUEEJhOXpJ.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].qhCNQUlMGLLIPgePBqkGedEPhGYg(P_0);
				if (!flag || flag4 || (flag3 && !fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].mEsbEDfKPyrMtUZcuvMivoDicsiT();
					continue;
				}
				axes[i].valueRaw = fcpRkkeLOqieJylVwWSUEEJhOXpJ.axisValues[i];
				if (flag2)
				{
					axes[i].VtpmdwnYAwpChSOfbMtqwuzMOhPk(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].VtpmdwnYAwpChSOfbMtqwuzMOhPk();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].sboEOQazNCgVCSWpNHHosMaWIvev();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].sIOGygNROCkClWBkbMftmCyTcClfA();
			}
		}

		internal bool AagpSncLUJqzNNHIlFoNYYQgJOuo(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int nAznauVeWTEKclGKxeRUvILhqOtm = P_0.nAznauVeWTEKclGKxeRUvILhqOtm;
			if (nAznauVeWTEKclGKxeRUvILhqOtm < 0 || nAznauVeWTEKclGKxeRUvILhqOtm >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[nAznauVeWTEKclGKxeRUvILhqOtm].valueRaw : axes[nAznauVeWTEKclGKxeRUvILhqOtm].value) : (P_2 ? axes[nAznauVeWTEKclGKxeRUvILhqOtm].valueRawPrev : axes[nAznauVeWTEKclGKxeRUvILhqOtm].valuePrev));
			if (MathTools.Approximately(num, 0f))
			{
				return true;
			}
			switch (elementType)
			{
			case ControllerElementType.Axis:
			{
				if (P_0._axisRange == AxisRange.Full)
				{
					if (P_0._invert)
					{
						num *= -1f;
					}
					break;
				}
				bool flag = ((MathTools.Sign(num) > 0f) ? true : false);
				if (flag && P_0._axisRange == AxisRange.Positive)
				{
					num = ((num >= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (!flag && P_0._axisRange == AxisRange.Negative)
				{
					num = ((num <= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Positive)
					{
						num *= -1f;
					}
				}
				else
				{
					num = 0f;
				}
				break;
			}
			case ControllerElementType.Button:
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				break;
			}
			P_4 = num;
			return true;
		}

		internal override void LJxUfrjqRngGjfLkARGJwZXpwXAOA(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				return;
			}
			base.LJxUfrjqRngGjfLkARGJwZXpwXAOA(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				vnEKgLVSpFebRqVrxBMjTwuUqPef(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].kqvbpTxWGdGtrNRdxLepeZkwTJDn);
				}
			}
		}

		internal override void vnEKgLVSpFebRqVrxBMjTwuUqPef(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.vnEKgLVSpFebRqVrxBMjTwuUqPef(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.XxnQtsdeMuILfHyfAVjirqwliWOgA(P_0);
				}
			}
		}

		internal void wtMcLWGCHHbPAvJejDUwNBxSiRKk()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].wzuKsMAQzNUDQMPTfMKsvinBDhokA._specialAxisType)
				{
				case SpecialAxisType.None:
					_calibrationMap.Axes[i].calibrationMode = AlternateAxisCalibrationType.Default;
					break;
				case SpecialAxisType.Throttle:
					_calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal override void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			base.wJjPIIRJfHhEbGedUconecGfiwzgB();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private int pdXHCrJUTndRsfAkyuMTKmWIlNol(int P_0)
		{
			if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
			}
			return P_0;
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> BEzeKUXzVpUjDeZFXdRUUpvVVdaK()
		{
			return base.PollForAllElements();
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> UvjGLRfVzLTkZOhqeiczFUWPVZpZ()
		{
			return base.PollForAllElementsDown();
		}
	}
}

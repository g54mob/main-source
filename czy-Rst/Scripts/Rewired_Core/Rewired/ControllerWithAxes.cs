using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class XfbFjHZVAgulPczTXalKnAFMpKms : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int bkBhIpOfmiIWiJaciRsVyZULCiaE;

			private ControllerPollingInfo NZDcfvDRiaMtdVPkJhVXLFdUxJRQ;

			private int QWJgBysBUnaQSgERuxYkpOzLFUQqA;

			public ControllerWithAxes dSIEPEBSmbSHDLzQlUWWZizvMGoi;

			private int YsuGfxxrdfwyjLWxPOJnRAbRjIJDA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return NZDcfvDRiaMtdVPkJhVXLFdUxJRQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return NZDcfvDRiaMtdVPkJhVXLFdUxJRQ;
				}
			}

			[DebuggerHidden]
			public XfbFjHZVAgulPczTXalKnAFMpKms(int P_0)
			{
				bkBhIpOfmiIWiJaciRsVyZULCiaE = P_0;
				QWJgBysBUnaQSgERuxYkpOzLFUQqA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = bkBhIpOfmiIWiJaciRsVyZULCiaE;
				ControllerWithAxes controllerWithAxes = dSIEPEBSmbSHDLzQlUWWZizvMGoi;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					bkBhIpOfmiIWiJaciRsVyZULCiaE = -1;
					goto IL_00a8;
				}
				bkBhIpOfmiIWiJaciRsVyZULCiaE = -1;
				if (ReInput._id != controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				controllerWithAxes.UpdatePollingFrameTracking();
				controllerWithAxes.DhiXrZIdUVvrMfhrQjuXCdrfeACf();
				YsuGfxxrdfwyjLWxPOJnRAbRjIJDA = 0;
				goto IL_00ba;
				IL_00ba:
				if (YsuGfxxrdfwyjLWxPOJnRAbRjIJDA < controllerWithAxes._axisCount)
				{
					if (controllerWithAxes.IsPolledAxisActive(YsuGfxxrdfwyjLWxPOJnRAbRjIJDA, out var pole, out var elementIdentifierId))
					{
						NZDcfvDRiaMtdVPkJhVXLFdUxJRQ = new ControllerPollingInfo(true, -1, controllerWithAxes.id, controllerWithAxes._name, controllerWithAxes._type, ControllerElementType.Axis, YsuGfxxrdfwyjLWxPOJnRAbRjIJDA, pole, controllerWithAxes.UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						bkBhIpOfmiIWiJaciRsVyZULCiaE = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				YsuGfxxrdfwyjLWxPOJnRAbRjIJDA++;
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
				XfbFjHZVAgulPczTXalKnAFMpKms xfbFjHZVAgulPczTXalKnAFMpKms;
				if (bkBhIpOfmiIWiJaciRsVyZULCiaE == -2 && QWJgBysBUnaQSgERuxYkpOzLFUQqA == Environment.CurrentManagedThreadId)
				{
					bkBhIpOfmiIWiJaciRsVyZULCiaE = 0;
					xfbFjHZVAgulPczTXalKnAFMpKms = this;
				}
				else
				{
					xfbFjHZVAgulPczTXalKnAFMpKms = new XfbFjHZVAgulPczTXalKnAFMpKms(0);
					xfbFjHZVAgulPczTXalKnAFMpKms.dSIEPEBSmbSHDLzQlUWWZizvMGoi = dSIEPEBSmbSHDLzQlUWWZizvMGoi;
				}
				return xfbFjHZVAgulPczTXalKnAFMpKms;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class RyfCGQynjleDpRHpGXbDRZPMRwSN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int rinPWvTKNvOBtBicTdYHOmRmuVzd;

			private ControllerPollingInfo hvqwFYVlkpzeIFEmvtCkrJBIgOey;

			private int xDChiQTCZqajYodgXcbtnPbgjQIH;

			public ControllerWithAxes myvTJWVFwXBwVibnbYCCplXSqjTbb;

			private IEnumerator<ControllerPollingInfo> wiGdoYtuqnoDvFiXCcZCMdrYMpAA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return hvqwFYVlkpzeIFEmvtCkrJBIgOey;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hvqwFYVlkpzeIFEmvtCkrJBIgOey;
				}
			}

			[DebuggerHidden]
			public RyfCGQynjleDpRHpGXbDRZPMRwSN(int P_0)
			{
				rinPWvTKNvOBtBicTdYHOmRmuVzd = P_0;
				xDChiQTCZqajYodgXcbtnPbgjQIH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (rinPWvTKNvOBtBicTdYHOmRmuVzd)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						EpSVjrwnuelWzoGWCKTjSnvOCtZd();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						khvfEmwyJROZchwiNKCIBlEWRjSK();
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
					int num = rinPWvTKNvOBtBicTdYHOmRmuVzd;
					ControllerWithAxes controllerWithAxes = myvTJWVFwXBwVibnbYCCplXSqjTbb;
					switch (num)
					{
					default:
						return false;
					case 0:
						rinPWvTKNvOBtBicTdYHOmRmuVzd = -1;
						if (ReInput._id != controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
						{
							ReInput.CheckInitialized(controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
							return false;
						}
						wiGdoYtuqnoDvFiXCcZCMdrYMpAA = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						rinPWvTKNvOBtBicTdYHOmRmuVzd = -3;
						goto IL_0092;
					case 1:
						rinPWvTKNvOBtBicTdYHOmRmuVzd = -3;
						goto IL_0092;
					case 2:
						{
							rinPWvTKNvOBtBicTdYHOmRmuVzd = -4;
							break;
						}
						IL_0092:
						if (wiGdoYtuqnoDvFiXCcZCMdrYMpAA.MoveNext())
						{
							ControllerPollingInfo current = wiGdoYtuqnoDvFiXCcZCMdrYMpAA.Current;
							hvqwFYVlkpzeIFEmvtCkrJBIgOey = current;
							rinPWvTKNvOBtBicTdYHOmRmuVzd = 1;
							return true;
						}
						EpSVjrwnuelWzoGWCKTjSnvOCtZd();
						wiGdoYtuqnoDvFiXCcZCMdrYMpAA = null;
						wiGdoYtuqnoDvFiXCcZCMdrYMpAA = controllerWithAxes.PollForAllAxes().GetEnumerator();
						rinPWvTKNvOBtBicTdYHOmRmuVzd = -4;
						break;
					}
					if (wiGdoYtuqnoDvFiXCcZCMdrYMpAA.MoveNext())
					{
						ControllerPollingInfo current2 = wiGdoYtuqnoDvFiXCcZCMdrYMpAA.Current;
						hvqwFYVlkpzeIFEmvtCkrJBIgOey = current2;
						rinPWvTKNvOBtBicTdYHOmRmuVzd = 2;
						return true;
					}
					khvfEmwyJROZchwiNKCIBlEWRjSK();
					wiGdoYtuqnoDvFiXCcZCMdrYMpAA = null;
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

			private void EpSVjrwnuelWzoGWCKTjSnvOCtZd()
			{
				rinPWvTKNvOBtBicTdYHOmRmuVzd = -1;
				if (wiGdoYtuqnoDvFiXCcZCMdrYMpAA != null)
				{
					wiGdoYtuqnoDvFiXCcZCMdrYMpAA.Dispose();
				}
			}

			private void khvfEmwyJROZchwiNKCIBlEWRjSK()
			{
				rinPWvTKNvOBtBicTdYHOmRmuVzd = -1;
				if (wiGdoYtuqnoDvFiXCcZCMdrYMpAA != null)
				{
					wiGdoYtuqnoDvFiXCcZCMdrYMpAA.Dispose();
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
				RyfCGQynjleDpRHpGXbDRZPMRwSN ryfCGQynjleDpRHpGXbDRZPMRwSN;
				if (rinPWvTKNvOBtBicTdYHOmRmuVzd == -2 && xDChiQTCZqajYodgXcbtnPbgjQIH == Environment.CurrentManagedThreadId)
				{
					rinPWvTKNvOBtBicTdYHOmRmuVzd = 0;
					ryfCGQynjleDpRHpGXbDRZPMRwSN = this;
				}
				else
				{
					ryfCGQynjleDpRHpGXbDRZPMRwSN = new RyfCGQynjleDpRHpGXbDRZPMRwSN(0);
					ryfCGQynjleDpRHpGXbDRZPMRwSN.myvTJWVFwXBwVibnbYCCplXSqjTbb = myvTJWVFwXBwVibnbYCCplXSqjTbb;
				}
				return ryfCGQynjleDpRHpGXbDRZPMRwSN;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class bfcBRFMCMAzqYurEsbAeEWpXIryp : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int DHqGKUTztRThCIasSwTnOnQWbMKW;

			private ControllerPollingInfo AvHrSkgcsdalhbvLdJtRuYRuGDrL;

			private int mAyNMtVWRdUPAtMPVgEBkTPrqfkP;

			public ControllerWithAxes bVxWGpHgYwwLvTnUxuuJElAPzOxA;

			private IEnumerator<ControllerPollingInfo> tdKUVcDEbREYlWfwrkXDVPzXJKeC;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return AvHrSkgcsdalhbvLdJtRuYRuGDrL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AvHrSkgcsdalhbvLdJtRuYRuGDrL;
				}
			}

			[DebuggerHidden]
			public bfcBRFMCMAzqYurEsbAeEWpXIryp(int P_0)
			{
				DHqGKUTztRThCIasSwTnOnQWbMKW = P_0;
				mAyNMtVWRdUPAtMPVgEBkTPrqfkP = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (DHqGKUTztRThCIasSwTnOnQWbMKW)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						AEmpMeLNKFSzTFezlFOisZytTqld();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						yAETupHljzHtedhSAQKsfAUPzPGW();
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
					int dHqGKUTztRThCIasSwTnOnQWbMKW = DHqGKUTztRThCIasSwTnOnQWbMKW;
					ControllerWithAxes controllerWithAxes = bVxWGpHgYwwLvTnUxuuJElAPzOxA;
					switch (dHqGKUTztRThCIasSwTnOnQWbMKW)
					{
					default:
						return false;
					case 0:
						DHqGKUTztRThCIasSwTnOnQWbMKW = -1;
						if (ReInput._id != controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
						{
							ReInput.CheckInitialized(controllerWithAxes.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
							return false;
						}
						tdKUVcDEbREYlWfwrkXDVPzXJKeC = ((Controller)controllerWithAxes).PollForAllElementsDown().GetEnumerator();
						DHqGKUTztRThCIasSwTnOnQWbMKW = -3;
						goto IL_0092;
					case 1:
						DHqGKUTztRThCIasSwTnOnQWbMKW = -3;
						goto IL_0092;
					case 2:
						{
							DHqGKUTztRThCIasSwTnOnQWbMKW = -4;
							break;
						}
						IL_0092:
						if (tdKUVcDEbREYlWfwrkXDVPzXJKeC.MoveNext())
						{
							ControllerPollingInfo current = tdKUVcDEbREYlWfwrkXDVPzXJKeC.Current;
							AvHrSkgcsdalhbvLdJtRuYRuGDrL = current;
							DHqGKUTztRThCIasSwTnOnQWbMKW = 1;
							return true;
						}
						AEmpMeLNKFSzTFezlFOisZytTqld();
						tdKUVcDEbREYlWfwrkXDVPzXJKeC = null;
						tdKUVcDEbREYlWfwrkXDVPzXJKeC = controllerWithAxes.PollForAllAxes().GetEnumerator();
						DHqGKUTztRThCIasSwTnOnQWbMKW = -4;
						break;
					}
					if (tdKUVcDEbREYlWfwrkXDVPzXJKeC.MoveNext())
					{
						ControllerPollingInfo current2 = tdKUVcDEbREYlWfwrkXDVPzXJKeC.Current;
						AvHrSkgcsdalhbvLdJtRuYRuGDrL = current2;
						DHqGKUTztRThCIasSwTnOnQWbMKW = 2;
						return true;
					}
					yAETupHljzHtedhSAQKsfAUPzPGW();
					tdKUVcDEbREYlWfwrkXDVPzXJKeC = null;
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

			private void AEmpMeLNKFSzTFezlFOisZytTqld()
			{
				DHqGKUTztRThCIasSwTnOnQWbMKW = -1;
				if (tdKUVcDEbREYlWfwrkXDVPzXJKeC != null)
				{
					tdKUVcDEbREYlWfwrkXDVPzXJKeC.Dispose();
				}
			}

			private void yAETupHljzHtedhSAQKsfAUPzPGW()
			{
				DHqGKUTztRThCIasSwTnOnQWbMKW = -1;
				if (tdKUVcDEbREYlWfwrkXDVPzXJKeC != null)
				{
					tdKUVcDEbREYlWfwrkXDVPzXJKeC.Dispose();
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
				bfcBRFMCMAzqYurEsbAeEWpXIryp bfcBRFMCMAzqYurEsbAeEWpXIryp2;
				if (DHqGKUTztRThCIasSwTnOnQWbMKW == -2 && mAyNMtVWRdUPAtMPVgEBkTPrqfkP == Environment.CurrentManagedThreadId)
				{
					DHqGKUTztRThCIasSwTnOnQWbMKW = 0;
					bfcBRFMCMAzqYurEsbAeEWpXIryp2 = this;
				}
				else
				{
					bfcBRFMCMAzqYurEsbAeEWpXIryp2 = new bfcBRFMCMAzqYurEsbAeEWpXIryp(0);
					bfcBRFMCMAzqYurEsbAeEWpXIryp2.bVxWGpHgYwwLvTnUxuuJElAPzOxA = bVxWGpHgYwwLvTnUxuuJElAPzOxA;
				}
				return bfcBRFMCMAzqYurEsbAeEWpXIryp2;
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

		private float[] QtDjpGIFlBcprDOjdvLEaorgROVrA;

		private uint FPzxPMdrrApfdAXFGJtPNtopmcQT = uint.MaxValue;

		private Func<int, int> XVVcykHfnMNRwqnZaqskwGhDdPTt;

		public int axisCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return UzVdrXbKoYScsNhLYrSoTUeynXDBb.axisElementIdentifiers_readOnly;
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
				DUFHWeGImWnELqobFlRGBIbQIJIp(axes[i]);
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
					oKeADPnZuMDqfiFDYZDUysjhzVIH(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			yrcfMdjHxIlUuKbazqPmfFsboolXA();
			XVVcykHfnMNRwqnZaqskwGhDdPTt = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			if (UzVdrXbKoYScsNhLYrSoTUeynXDBb == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return -1;
			}
			return UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0f;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0f;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0f;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0f;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int axisIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
			}
			UpdatePollingFrameTracking();
			DhiXrZIdUVvrMfhrQjuXCdrfeACf();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
		}

		[IteratorStateMachine(typeof(RyfCGQynjleDpRHpGXbDRZPMRwSN))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new RyfCGQynjleDpRHpGXbDRZPMRwSN(-2)
			{
				myvTJWVFwXBwVibnbYCCplXSqjTbb = this
			};
		}

		[IteratorStateMachine(typeof(bfcBRFMCMAzqYurEsbAeEWpXIryp))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new bfcBRFMCMAzqYurEsbAeEWpXIryp(-2)
			{
				bVxWGpHgYwwLvTnUxuuJElAPzOxA = this
			};
		}

		[IteratorStateMachine(typeof(XfbFjHZVAgulPczTXalKnAFMpKms))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new XfbFjHZVAgulPczTXalKnAFMpKms(-2)
			{
				dSIEPEBSmbSHDLzQlUWWZizvMGoi = this
			};
		}

		private void DhiXrZIdUVvrMfhrQjuXCdrfeACf()
		{
			if (QtDjpGIFlBcprDOjdvLEaorgROVrA == null)
			{
				QtDjpGIFlBcprDOjdvLEaorgROVrA = new float[_axisCount];
			}
			if (GeiOfNRnWNcHtBrYaaUFiXYntovY != FPzxPMdrrApfdAXFGJtPNtopmcQT)
			{
				FPzxPMdrrApfdAXFGJtPNtopmcQT = GeiOfNRnWNcHtBrYaaUFiXYntovY;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					QtDjpGIFlBcprDOjdvLEaorgROVrA[i] = axes[i].WrQNkgvPSzdiZlgWPqODPhhgICoL(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].hGVuzmiWOAnhEmGFXjTzQspEcSPiA != null)
			{
				if (axes[index].hGVuzmiWOAnhEmGFXjTzQspEcSPiA._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].hGVuzmiWOAnhEmGFXjTzQspEcSPiA._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].WrQNkgvPSzdiZlgWPqODPhhgICoL(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - QtDjpGIFlBcprDOjdvLEaorgROVrA[index];
			if (MathTools.Abs(value) <= axes[index].XpSsNXWTRdqOFZzqKORsXwzttbRs)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = UzVdrXbKoYScsNhLYrSoTUeynXDBb.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void TSIxZIyTztOcgIdRmpQWGcNoDGCV(UpdateLoopType P_0)
		{
			base.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !ucqtfsuOTseRsybfPGjEFawPmfNK.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].btDxpVkziGaudWoyiggQGtlcabyZ(P_0);
				if (!flag || flag4 || (flag3 && !ucqtfsuOTseRsybfPGjEFawPmfNK.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].OYbzcmZKLozkOLJYcetOJBdWwUnpA();
					continue;
				}
				axes[i].valueRaw = ucqtfsuOTseRsybfPGjEFawPmfNK.axisValues[i];
				if (flag2)
				{
					axes[i].TbXHKBfIRnoJwjoMRKnmWJOqUhxT(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].AFzZNTfEwYaqsWZAqHOjkADExKSs();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].pkjqqBFPgSKScLobcXPLJUtWaEGy();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].rkXcsejOnlNzjRXzKvySDceUuDmw();
			}
		}

		internal bool doeoSlOqRUDmnfjUcrCbKfGtIzkl(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int coqXdmPghseNBOvihWdoifSiCjzh = P_0.coqXdmPghseNBOvihWdoifSiCjzh;
			if (coqXdmPghseNBOvihWdoifSiCjzh < 0 || coqXdmPghseNBOvihWdoifSiCjzh >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[coqXdmPghseNBOvihWdoifSiCjzh].valueRaw : axes[coqXdmPghseNBOvihWdoifSiCjzh].value) : (P_2 ? axes[coqXdmPghseNBOvihWdoifSiCjzh].valueRawPrev : axes[coqXdmPghseNBOvihWdoifSiCjzh].valuePrev));
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
				bool flag = MathTools.Sign(num) > 0f;
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

		internal virtual void kPdabnevgAfXBEnolOhEfykeyggC(ControllerMap P_0)
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
			base.FeQHluiWzbggXquWcpGEIuFssFTaA(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				XxMvlVzqErvGSYjarMeZYpjHprtT(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].xYazCGhLJSNpewHjYMCgVGmvJCJk);
				}
			}
		}

		internal virtual void UODznOGmNwNdfdmkRSAoJTJnVIGL(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.XxMvlVzqErvGSYjarMeZYpjHprtT(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.STLLClZycMGvQuJnbJckqZikooUE(P_0);
				}
			}
		}

		internal void yrcfMdjHxIlUuKbazqPmfFsboolXA()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].hGVuzmiWOAnhEmGFXjTzQspEcSPiA._specialAxisType)
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

		internal virtual void pMAKFseXyurQXsyyUSZmzSuwdMXR()
		{
			base.xbzMqJvVogJAviEMRocpklZVZryW();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private int WnZJUOFHlXwNWQJDpthDMHzcFjXfA(int P_0)
		{
			if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
			}
			return P_0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> HasyUymhYOuNYHFGMtVIPcevApDO()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> qyQvbMUTsPtLLhrVheAFahYHeWmx()
		{
			return base.PollForAllElementsDown();
		}
	}
}

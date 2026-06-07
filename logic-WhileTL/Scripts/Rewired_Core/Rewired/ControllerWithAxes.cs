using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class qPqLhaPOaGMPeqZqxWOvErjCebAW : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public qPqLhaPOaGMPeqZqxWOvErjCebAW(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ControllerWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00a8;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				gZXxEqHwrHYIyUJtInpLwgTukJaY.UpdatePollingFrameTracking();
				gZXxEqHwrHYIyUJtInpLwgTukJaY.jYELipTpKMeAlxVzWwlyEJJFizV();
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00ba;
				IL_00ba:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY._axisCount)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.IsPolledAxisActive(aWiJmJHWwqZlYdpLUbqxiFaJSHeg, out var pole, out var elementIdentifierId))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(true, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY.id, gZXxEqHwrHYIyUJtInpLwgTukJaY._name, gZXxEqHwrHYIyUJtInpLwgTukJaY._type, ControllerElementType.Axis, aWiJmJHWwqZlYdpLUbqxiFaJSHeg, pole, gZXxEqHwrHYIyUJtInpLwgTukJaY.jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				qPqLhaPOaGMPeqZqxWOvErjCebAW qPqLhaPOaGMPeqZqxWOvErjCebAW2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					qPqLhaPOaGMPeqZqxWOvErjCebAW2 = this;
				}
				else
				{
					qPqLhaPOaGMPeqZqxWOvErjCebAW2 = new qPqLhaPOaGMPeqZqxWOvErjCebAW(0);
					qPqLhaPOaGMPeqZqxWOvErjCebAW2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return qPqLhaPOaGMPeqZqxWOvErjCebAW2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class eoqEuncuRBvmKHgUoKlsezrMRWkh : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public eoqEuncuRBvmKHgUoKlsezrMRWkh(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						cjHgXFFYGWhdIQKUJynxjVusYouQA();
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
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = ((Controller)gZXxEqHwrHYIyUJtInpLwgTukJaY).PollForAllElements().GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_0092;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_0092;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
							break;
						}
						IL_0092:
						if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
						{
							ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						otVuTclWHkLrdVIElDnnPoApusjv = null;
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.PollForAllAxes().GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
						return true;
					}
					cjHgXFFYGWhdIQKUJynxjVusYouQA();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
				}
			}

			private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				eoqEuncuRBvmKHgUoKlsezrMRWkh eoqEuncuRBvmKHgUoKlsezrMRWkh2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					eoqEuncuRBvmKHgUoKlsezrMRWkh2 = this;
				}
				else
				{
					eoqEuncuRBvmKHgUoKlsezrMRWkh2 = new eoqEuncuRBvmKHgUoKlsezrMRWkh(0);
					eoqEuncuRBvmKHgUoKlsezrMRWkh2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return eoqEuncuRBvmKHgUoKlsezrMRWkh2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class AupJnwYoqyGphkLvSzITvrDJSdWh : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public ControllerWithAxes GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public AupJnwYoqyGphkLvSzITvrDJSdWh(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						cjHgXFFYGWhdIQKUJynxjVusYouQA();
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
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					ControllerWithAxes gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
						{
							ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = ((Controller)gZXxEqHwrHYIyUJtInpLwgTukJaY).PollForAllElementsDown().GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_0092;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_0092;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
							break;
						}
						IL_0092:
						if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
						{
							ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						otVuTclWHkLrdVIElDnnPoApusjv = null;
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.PollForAllAxes().GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
						break;
					}
					if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
						return true;
					}
					cjHgXFFYGWhdIQKUJynxjVusYouQA();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
				}
			}

			private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				AupJnwYoqyGphkLvSzITvrDJSdWh aupJnwYoqyGphkLvSzITvrDJSdWh;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					aupJnwYoqyGphkLvSzITvrDJSdWh = this;
				}
				else
				{
					aupJnwYoqyGphkLvSzITvrDJSdWh = new AupJnwYoqyGphkLvSzITvrDJSdWh(0);
					aupJnwYoqyGphkLvSzITvrDJSdWh.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return aupJnwYoqyGphkLvSzITvrDJSdWh;
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

		protected CalibrationMap _calibrationMap;

		private float[] QAUMnurGPaMFcxUrhGKOLRIWwgLX;

		private uint bSkoCbQStOJHPMYRoKtIdITAfdDiA = uint.MaxValue;

		private Func<int, int> yqnDoCVhEZdZCACtysEkiYXtVmuvA;

		public int axisCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return jnGTQDFeNsixRwgRJcghDqCbQWSP.axisElementIdentifiers_readOnly;
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
				EXLSSjQnrrQtaZMvCcEDTNZBhhQt(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData);
			_axis2DCount = P_10.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = P_10.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
					}
					else
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[j] = new Axis2D(this, -1, "Axis 2D " + j, null, null, 0, 0, null);
				}
				finally
				{
					zHkFavizqbDuYMnEoaQQxVsTmUceA(axes2D[j]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			NqEEbJGcjRsosJMIWBrALKQJusMIA();
			yqnDoCVhEZdZCACtysEkiYXtVmuvA = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return -1;
			}
			return jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int axisIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
			}
			UpdatePollingFrameTracking();
			jYELipTpKMeAlxVzWwlyEJJFizV();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new eoqEuncuRBvmKHgUoKlsezrMRWkh(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new AupJnwYoqyGphkLvSzITvrDJSdWh(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new qPqLhaPOaGMPeqZqxWOvErjCebAW(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		private void jYELipTpKMeAlxVzWwlyEJJFizV()
		{
			if (QAUMnurGPaMFcxUrhGKOLRIWwgLX == null)
			{
				QAUMnurGPaMFcxUrhGKOLRIWwgLX = new float[_axisCount];
			}
			if (fYIZlNlUKsgmElwBbwHLXAhVYoKT != bSkoCbQStOJHPMYRoKtIdITAfdDiA)
			{
				bSkoCbQStOJHPMYRoKtIdITAfdDiA = fYIZlNlUKsgmElwBbwHLXAhVYoKT;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					QAUMnurGPaMFcxUrhGKOLRIWwgLX[i] = axes[i].ssUeJfYfdgHsOGaTfHqZKArcnbHGb(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].LCaxfXkPMXiCslbaIiVAoElQhhmD != null)
			{
				if (axes[index].LCaxfXkPMXiCslbaIiVAoElQhhmD._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].LCaxfXkPMXiCslbaIiVAoElQhhmD._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].ssUeJfYfdgHsOGaTfHqZKArcnbHGb(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - QAUMnurGPaMFcxUrhGKOLRIWwgLX[index];
			if (MathTools.Abs(value) <= axes[index].yPNbebGHfNNuYBAoGSUXYkgODJVPB)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = jnGTQDFeNsixRwgRJcghDqCbQWSP.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			base.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !WlduKdCdymfJzhLxPcswpRugJOzgb.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].JQMhIHVomNcwpRBKcICkFvIExdCCA(P_0);
				if (!flag || flag4 || (flag3 && !WlduKdCdymfJzhLxPcswpRugJOzgb.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].VbyiNYaTxeSxPNfKRycKgustYwcy();
					continue;
				}
				axes[i].valueRaw = WlduKdCdymfJzhLxPcswpRugJOzgb.axisValues[i];
				if (flag2)
				{
					axes[i].gktexvDkCazOJpTsGLKIhKgBWrJC(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].gktexvDkCazOJpTsGLKIhKgBWrJC();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].HKmEXBOMtGYkijZBmPdErwHXVruq();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].DKjtzBbwElhXUfSIQLPatJOaCbIb();
			}
		}

		internal bool tdwRMoEqKHSujkiiWAstXtSvQagE(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int uxnXexdLmPFrOAXyWtEwqWmaGYzH = P_0.UxnXexdLmPFrOAXyWtEwqWmaGYzH;
			if (uxnXexdLmPFrOAXyWtEwqWmaGYzH < 0 || uxnXexdLmPFrOAXyWtEwqWmaGYzH >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[uxnXexdLmPFrOAXyWtEwqWmaGYzH].valueRaw : axes[uxnXexdLmPFrOAXyWtEwqWmaGYzH].value) : (P_2 ? axes[uxnXexdLmPFrOAXyWtEwqWmaGYzH].valueRawPrev : axes[uxnXexdLmPFrOAXyWtEwqWmaGYzH].valuePrev));
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

		internal override void cnpecuLKhtzxTyAKhiBbYvieXuGi(ControllerMap P_0)
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
			base.cnpecuLKhtzxTyAKhiBbYvieXuGi(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				OkYVVItyDNIRrZjZSvdPINJLnmkM(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
				}
			}
		}

		internal override void OkYVVItyDNIRrZjZSvdPINJLnmkM(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.OkYVVItyDNIRrZjZSvdPINJLnmkM(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.kArqsxPmpmoyPVFqtFYUjLfaKBQC(P_0);
				}
			}
		}

		internal void NqEEbJGcjRsosJMIWBrALKQJusMIA()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].LCaxfXkPMXiCslbaIiVAoElQhhmD._specialAxisType)
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

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			base.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> qblcbDKfpvlnbgJvFcJoxFOPGJiVB()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> nYzEvKbcTVDLdGjGNqQVPBjWYFru()
		{
			return base.PollForAllElementsDown();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class SGEstiWMDRBGCeSJzHMnFXBuYAIN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int knoviSTJcBjjzZssGszcGeVlWOQk;

			private ControllerPollingInfo QvuhySYDrZCiaXxwnicynklyPatH;

			private int NowlBNldJORzBGDBQunXaqdhcKso;

			public ControllerWithAxes eVxIPnSGzKpqGVCKJAtvfgpBTKWX;

			private int RTFmnCmmwWVJoFofvteUbNhvFYvy;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return QvuhySYDrZCiaXxwnicynklyPatH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return QvuhySYDrZCiaXxwnicynklyPatH;
				}
			}

			[DebuggerHidden]
			public SGEstiWMDRBGCeSJzHMnFXBuYAIN(int P_0)
			{
				knoviSTJcBjjzZssGszcGeVlWOQk = P_0;
				NowlBNldJORzBGDBQunXaqdhcKso = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = knoviSTJcBjjzZssGszcGeVlWOQk;
				ControllerWithAxes controllerWithAxes = eVxIPnSGzKpqGVCKJAtvfgpBTKWX;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					knoviSTJcBjjzZssGszcGeVlWOQk = -1;
					goto IL_00a8;
				}
				knoviSTJcBjjzZssGszcGeVlWOQk = -1;
				if (ReInput._id != controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				controllerWithAxes.UpdatePollingFrameTracking();
				controllerWithAxes.YDNIiZBSmMYVhjUgCjiqdsNkAkE();
				RTFmnCmmwWVJoFofvteUbNhvFYvy = 0;
				goto IL_00ba;
				IL_00ba:
				if (RTFmnCmmwWVJoFofvteUbNhvFYvy < controllerWithAxes._axisCount)
				{
					if (controllerWithAxes.IsPolledAxisActive(RTFmnCmmwWVJoFofvteUbNhvFYvy, out var pole, out var elementIdentifierId))
					{
						QvuhySYDrZCiaXxwnicynklyPatH = new ControllerPollingInfo(true, -1, controllerWithAxes.id, controllerWithAxes._name, controllerWithAxes._type, ControllerElementType.Axis, RTFmnCmmwWVJoFofvteUbNhvFYvy, pole, controllerWithAxes.NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						knoviSTJcBjjzZssGszcGeVlWOQk = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				RTFmnCmmwWVJoFofvteUbNhvFYvy++;
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
				SGEstiWMDRBGCeSJzHMnFXBuYAIN sGEstiWMDRBGCeSJzHMnFXBuYAIN;
				if (knoviSTJcBjjzZssGszcGeVlWOQk == -2 && NowlBNldJORzBGDBQunXaqdhcKso == Environment.CurrentManagedThreadId)
				{
					knoviSTJcBjjzZssGszcGeVlWOQk = 0;
					sGEstiWMDRBGCeSJzHMnFXBuYAIN = this;
				}
				else
				{
					sGEstiWMDRBGCeSJzHMnFXBuYAIN = new SGEstiWMDRBGCeSJzHMnFXBuYAIN(0);
					sGEstiWMDRBGCeSJzHMnFXBuYAIN.eVxIPnSGzKpqGVCKJAtvfgpBTKWX = eVxIPnSGzKpqGVCKJAtvfgpBTKWX;
				}
				return sGEstiWMDRBGCeSJzHMnFXBuYAIN;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class CxCCEjvLyAseuFUpeGqqlcTgHksu : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int aBWLGQIHBQdsoToyzKiaiqTSisRD;

			private ControllerPollingInfo sYZAFbDMpOrLPjFeXKvJBZNeUCYDA;

			private int aUptitYILNXjVgkKfPAAJFzWpQqh;

			public ControllerWithAxes dwUdHdEQnabFSQpbFRrvaRXkAtrfb;

			private IEnumerator<ControllerPollingInfo> lzPpaHBEfNZeQdampCVqesbZIUVJ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return sYZAFbDMpOrLPjFeXKvJBZNeUCYDA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return sYZAFbDMpOrLPjFeXKvJBZNeUCYDA;
				}
			}

			[DebuggerHidden]
			public CxCCEjvLyAseuFUpeGqqlcTgHksu(int P_0)
			{
				aBWLGQIHBQdsoToyzKiaiqTSisRD = P_0;
				aUptitYILNXjVgkKfPAAJFzWpQqh = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (aBWLGQIHBQdsoToyzKiaiqTSisRD)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						DjxBhIliyDKyeeQDgrPCmbxaMurD();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						xGOnVPhOQgfZbjDuvlmzpIMyVQmI();
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
					int num = aBWLGQIHBQdsoToyzKiaiqTSisRD;
					ControllerWithAxes controllerWithAxes = dwUdHdEQnabFSQpbFRrvaRXkAtrfb;
					switch (num)
					{
					default:
						return false;
					case 0:
						aBWLGQIHBQdsoToyzKiaiqTSisRD = -1;
						if (ReInput._id != controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
						{
							ReInput.CheckInitialized(controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
							return false;
						}
						lzPpaHBEfNZeQdampCVqesbZIUVJ = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						aBWLGQIHBQdsoToyzKiaiqTSisRD = -3;
						goto IL_0092;
					case 1:
						aBWLGQIHBQdsoToyzKiaiqTSisRD = -3;
						goto IL_0092;
					case 2:
						{
							aBWLGQIHBQdsoToyzKiaiqTSisRD = -4;
							break;
						}
						IL_0092:
						if (lzPpaHBEfNZeQdampCVqesbZIUVJ.MoveNext())
						{
							ControllerPollingInfo current = lzPpaHBEfNZeQdampCVqesbZIUVJ.Current;
							sYZAFbDMpOrLPjFeXKvJBZNeUCYDA = current;
							aBWLGQIHBQdsoToyzKiaiqTSisRD = 1;
							return true;
						}
						DjxBhIliyDKyeeQDgrPCmbxaMurD();
						lzPpaHBEfNZeQdampCVqesbZIUVJ = null;
						lzPpaHBEfNZeQdampCVqesbZIUVJ = controllerWithAxes.PollForAllAxes().GetEnumerator();
						aBWLGQIHBQdsoToyzKiaiqTSisRD = -4;
						break;
					}
					if (lzPpaHBEfNZeQdampCVqesbZIUVJ.MoveNext())
					{
						ControllerPollingInfo current2 = lzPpaHBEfNZeQdampCVqesbZIUVJ.Current;
						sYZAFbDMpOrLPjFeXKvJBZNeUCYDA = current2;
						aBWLGQIHBQdsoToyzKiaiqTSisRD = 2;
						return true;
					}
					xGOnVPhOQgfZbjDuvlmzpIMyVQmI();
					lzPpaHBEfNZeQdampCVqesbZIUVJ = null;
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

			private void DjxBhIliyDKyeeQDgrPCmbxaMurD()
			{
				aBWLGQIHBQdsoToyzKiaiqTSisRD = -1;
				if (lzPpaHBEfNZeQdampCVqesbZIUVJ != null)
				{
					lzPpaHBEfNZeQdampCVqesbZIUVJ.Dispose();
				}
			}

			private void xGOnVPhOQgfZbjDuvlmzpIMyVQmI()
			{
				aBWLGQIHBQdsoToyzKiaiqTSisRD = -1;
				if (lzPpaHBEfNZeQdampCVqesbZIUVJ != null)
				{
					lzPpaHBEfNZeQdampCVqesbZIUVJ.Dispose();
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
				CxCCEjvLyAseuFUpeGqqlcTgHksu cxCCEjvLyAseuFUpeGqqlcTgHksu;
				if (aBWLGQIHBQdsoToyzKiaiqTSisRD == -2 && aUptitYILNXjVgkKfPAAJFzWpQqh == Environment.CurrentManagedThreadId)
				{
					aBWLGQIHBQdsoToyzKiaiqTSisRD = 0;
					cxCCEjvLyAseuFUpeGqqlcTgHksu = this;
				}
				else
				{
					cxCCEjvLyAseuFUpeGqqlcTgHksu = new CxCCEjvLyAseuFUpeGqqlcTgHksu(0);
					cxCCEjvLyAseuFUpeGqqlcTgHksu.dwUdHdEQnabFSQpbFRrvaRXkAtrfb = dwUdHdEQnabFSQpbFRrvaRXkAtrfb;
				}
				return cxCCEjvLyAseuFUpeGqqlcTgHksu;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class yCZNugDHRvPVZepWIrSVuLhfdzCj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int QRXQUvEhoiCVHMzeqwhYsbYsOHyL;

			private ControllerPollingInfo JMgdxThbSQWbszbRJqCkAYXCINPH;

			private int dDJlOOCJMSyRXlGLdAlkSUTVGtYU;

			public ControllerWithAxes mpEUlxChUrHfOTjwuTtLettcjWgE;

			private IEnumerator<ControllerPollingInfo> gEjbYNGhuqTjcYzfPWTyfBDrtVAr;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JMgdxThbSQWbszbRJqCkAYXCINPH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JMgdxThbSQWbszbRJqCkAYXCINPH;
				}
			}

			[DebuggerHidden]
			public yCZNugDHRvPVZepWIrSVuLhfdzCj(int P_0)
			{
				QRXQUvEhoiCVHMzeqwhYsbYsOHyL = P_0;
				dDJlOOCJMSyRXlGLdAlkSUTVGtYU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (QRXQUvEhoiCVHMzeqwhYsbYsOHyL)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						BfXbTKMOdidJOVqDHysDYTWNZwFe();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						jxffkSQvoYNOftjAobbNkPKfaBuRA();
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
					int qRXQUvEhoiCVHMzeqwhYsbYsOHyL = QRXQUvEhoiCVHMzeqwhYsbYsOHyL;
					ControllerWithAxes controllerWithAxes = mpEUlxChUrHfOTjwuTtLettcjWgE;
					switch (qRXQUvEhoiCVHMzeqwhYsbYsOHyL)
					{
					default:
						return false;
					case 0:
						QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -1;
						if (ReInput._id != controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
						{
							ReInput.CheckInitialized(controllerWithAxes.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
							return false;
						}
						gEjbYNGhuqTjcYzfPWTyfBDrtVAr = ((Controller)controllerWithAxes).PollForAllElementsDown().GetEnumerator();
						QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -3;
						goto IL_0092;
					case 1:
						QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -3;
						goto IL_0092;
					case 2:
						{
							QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -4;
							break;
						}
						IL_0092:
						if (gEjbYNGhuqTjcYzfPWTyfBDrtVAr.MoveNext())
						{
							ControllerPollingInfo current = gEjbYNGhuqTjcYzfPWTyfBDrtVAr.Current;
							JMgdxThbSQWbszbRJqCkAYXCINPH = current;
							QRXQUvEhoiCVHMzeqwhYsbYsOHyL = 1;
							return true;
						}
						BfXbTKMOdidJOVqDHysDYTWNZwFe();
						gEjbYNGhuqTjcYzfPWTyfBDrtVAr = null;
						gEjbYNGhuqTjcYzfPWTyfBDrtVAr = controllerWithAxes.PollForAllAxes().GetEnumerator();
						QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -4;
						break;
					}
					if (gEjbYNGhuqTjcYzfPWTyfBDrtVAr.MoveNext())
					{
						ControllerPollingInfo current2 = gEjbYNGhuqTjcYzfPWTyfBDrtVAr.Current;
						JMgdxThbSQWbszbRJqCkAYXCINPH = current2;
						QRXQUvEhoiCVHMzeqwhYsbYsOHyL = 2;
						return true;
					}
					jxffkSQvoYNOftjAobbNkPKfaBuRA();
					gEjbYNGhuqTjcYzfPWTyfBDrtVAr = null;
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

			private void BfXbTKMOdidJOVqDHysDYTWNZwFe()
			{
				QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -1;
				if (gEjbYNGhuqTjcYzfPWTyfBDrtVAr != null)
				{
					gEjbYNGhuqTjcYzfPWTyfBDrtVAr.Dispose();
				}
			}

			private void jxffkSQvoYNOftjAobbNkPKfaBuRA()
			{
				QRXQUvEhoiCVHMzeqwhYsbYsOHyL = -1;
				if (gEjbYNGhuqTjcYzfPWTyfBDrtVAr != null)
				{
					gEjbYNGhuqTjcYzfPWTyfBDrtVAr.Dispose();
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
				yCZNugDHRvPVZepWIrSVuLhfdzCj yCZNugDHRvPVZepWIrSVuLhfdzCj2;
				if (QRXQUvEhoiCVHMzeqwhYsbYsOHyL == -2 && dDJlOOCJMSyRXlGLdAlkSUTVGtYU == Environment.CurrentManagedThreadId)
				{
					QRXQUvEhoiCVHMzeqwhYsbYsOHyL = 0;
					yCZNugDHRvPVZepWIrSVuLhfdzCj2 = this;
				}
				else
				{
					yCZNugDHRvPVZepWIrSVuLhfdzCj2 = new yCZNugDHRvPVZepWIrSVuLhfdzCj(0);
					yCZNugDHRvPVZepWIrSVuLhfdzCj2.mpEUlxChUrHfOTjwuTtLettcjWgE = mpEUlxChUrHfOTjwuTtLettcjWgE;
				}
				return yCZNugDHRvPVZepWIrSVuLhfdzCj2;
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

		private float[] DkgNrhDPgagOiAqrTiulKDjOfIzM;

		private uint SQMCFlauehBIgwUValCogfoFzkinA = uint.MaxValue;

		private Func<int, int> SeuupLSSiniddihBIIFLMqbpYFtM;

		public int axisCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.axisElementIdentifiers_readOnly;
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
				SsiDSPXeljgWKetbvUQnvIjmeXiV(axes[i]);
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
					bLPAYawLrzGccouFaIolYrjFjlkO(axes2D[j]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			nJTUYYGxszfhnlywRqgNdoeFIcDiA();
			SeuupLSSiniddihBIIFLMqbpYFtM = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			if (NOuTtyJvdlwLlfoBgXbDwbqIGPrIA == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return -1;
			}
			return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0f;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0f;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0f;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0f;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int axisIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
			}
			UpdatePollingFrameTracking();
			YDNIiZBSmMYVhjUgCjiqdsNkAkE();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
		}

		[IteratorStateMachine(typeof(CxCCEjvLyAseuFUpeGqqlcTgHksu))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new CxCCEjvLyAseuFUpeGqqlcTgHksu(-2)
			{
				dwUdHdEQnabFSQpbFRrvaRXkAtrfb = this
			};
		}

		[IteratorStateMachine(typeof(yCZNugDHRvPVZepWIrSVuLhfdzCj))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new yCZNugDHRvPVZepWIrSVuLhfdzCj(-2)
			{
				mpEUlxChUrHfOTjwuTtLettcjWgE = this
			};
		}

		[IteratorStateMachine(typeof(SGEstiWMDRBGCeSJzHMnFXBuYAIN))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new SGEstiWMDRBGCeSJzHMnFXBuYAIN(-2)
			{
				eVxIPnSGzKpqGVCKJAtvfgpBTKWX = this
			};
		}

		private void YDNIiZBSmMYVhjUgCjiqdsNkAkE()
		{
			if (DkgNrhDPgagOiAqrTiulKDjOfIzM == null)
			{
				DkgNrhDPgagOiAqrTiulKDjOfIzM = new float[_axisCount];
			}
			if (BuBkhoCeHoPmaBbYAezaFlEXsyXFA != SQMCFlauehBIgwUValCogfoFzkinA)
			{
				SQMCFlauehBIgwUValCogfoFzkinA = BuBkhoCeHoPmaBbYAezaFlEXsyXFA;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					DkgNrhDPgagOiAqrTiulKDjOfIzM[i] = axes[i].JvvXELyjPIiUSvVIxVJevEnSwYGu(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].mIchhRBlJrrWJwkTxxeMqxzcaKtO != null)
			{
				if (axes[index].mIchhRBlJrrWJwkTxxeMqxzcaKtO._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].mIchhRBlJrrWJwkTxxeMqxzcaKtO._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].JvvXELyjPIiUSvVIxVJevEnSwYGu(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - DkgNrhDPgagOiAqrTiulKDjOfIzM[index];
			if (MathTools.Abs(value) <= axes[index].GZzcNiDwCSefGXRigFePGjvNjfbIb)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void KcxabjhCuUxlxWHNCxIliMVWtSiM(UpdateLoopType P_0)
		{
			base.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !rGVdhXruOTgLzoPtrwxfhKmroixX.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].cwgBvagbbtfHaAWcDEXlzshQrlIdb(P_0);
				if (!flag || flag4 || (flag3 && !rGVdhXruOTgLzoPtrwxfhKmroixX.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].VIIDcHbIMFDDFPJQOxOtrpximIHvA();
					continue;
				}
				axes[i].valueRaw = rGVdhXruOTgLzoPtrwxfhKmroixX.axisValues[i];
				if (flag2)
				{
					axes[i].MdeUKqaoMIfmvpCOxxKZkFUIdrDbA(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].RiIBAeehdxIRrCOACdzQEvHggYcX();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].kFEDooQtbblpfFZvSHkcthbsRQip();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].kroXwPZXmIeUiDtvouBbfSikkTCr();
			}
		}

		internal bool wLFduGRgQtFcwGrUQsYMkiGFRlCEA(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int zfBLdNSKjJTOCMpfLtMTErUQCWJJ = P_0.zfBLdNSKjJTOCMpfLtMTErUQCWJJ;
			if (zfBLdNSKjJTOCMpfLtMTErUQCWJJ < 0 || zfBLdNSKjJTOCMpfLtMTErUQCWJJ >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].valueRaw : axes[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].value) : (P_2 ? axes[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].valueRawPrev : axes[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].valuePrev));
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

		internal virtual void lhMiyWnysdEwUMdqNhPlRekOmHQE(ControllerMap P_0)
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
			base.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				KQvZlmyPDCAbJMosZEJiaypfudNPA(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].kzHrLfsGRteEloHDejoDrezLTRte);
				}
			}
		}

		internal virtual void HMmCjfJyIZsgypzozqxPrELFtRiP(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.KQvZlmyPDCAbJMosZEJiaypfudNPA(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.TdyJaYSxTvfwLaVFZuETMDHOmkgH(P_0);
				}
			}
		}

		internal void nJTUYYGxszfhnlywRqgNdoeFIcDiA()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].mIchhRBlJrrWJwkTxxeMqxzcaKtO._specialAxisType)
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

		internal virtual void eQlPXXtIjTBbUuFweKqVJFyUmYbL()
		{
			base.gBKPqeqzjNmvysiIfrLGGzRfmdWS();
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
		private IEnumerable<ControllerPollingInfo> STZaIZGnXbpDXaJUkuYjJngLLrlnB()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> rPzZbtTYpcakAtyDBPnmWUKrwMIS()
		{
			return base.PollForAllElementsDown();
		}
	}
}

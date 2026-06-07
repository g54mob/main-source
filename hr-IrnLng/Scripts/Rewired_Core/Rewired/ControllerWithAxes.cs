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
		private sealed class INyFUInkvOFahWrOOgueggPBdXSx : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ControllerPollingInfo EjwdzwXEmkohZoSiEVDDLRvfIVQ;

			public ControllerPollingInfo EpKJsGtRWDlThwephHXKQVnhEbL;

			public IEnumerator<ControllerPollingInfo> moNpLwJFUZEtpagZJTJiHFdEbsJd;

			public IEnumerator<ControllerPollingInfo> NVefGbDQHDhtXFZiGAeJciXVcJqW;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				INyFUInkvOFahWrOOgueggPBdXSx nyFUInkvOFahWrOOgueggPBdXSx;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					nyFUInkvOFahWrOOgueggPBdXSx = this;
				}
				else
				{
					nyFUInkvOFahWrOOgueggPBdXSx = new INyFUInkvOFahWrOOgueggPBdXSx(0);
					nyFUInkvOFahWrOOgueggPBdXSx.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return nyFUInkvOFahWrOOgueggPBdXSx;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						moNpLwJFUZEtpagZJTJiHFdEbsJd = ((Controller)GxphHAMqMhNBLjnlhXuBQmXaALiE).PollForAllElements().GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00a6;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00a6;
					case 4:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							goto IL_0107;
						}
						IL_00a6:
						if (moNpLwJFUZEtpagZJTJiHFdEbsJd.MoveNext())
						{
							EjwdzwXEmkohZoSiEVDDLRvfIVQ = moNpLwJFUZEtpagZJTJiHFdEbsJd.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = EjwdzwXEmkohZoSiEVDDLRvfIVQ;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						wGPCfkIxppuMncbIvCfWcwLxxeGe();
						NVefGbDQHDhtXFZiGAeJciXVcJqW = GxphHAMqMhNBLjnlhXuBQmXaALiE.PollForAllAxes().GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
						goto IL_0107;
						IL_0107:
						if (NVefGbDQHDhtXFZiGAeJciXVcJqW.MoveNext())
						{
							EpKJsGtRWDlThwephHXKQVnhEbL = NVefGbDQHDhtXFZiGAeJciXVcJqW.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = EpKJsGtRWDlThwephHXKQVnhEbL;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
							return true;
						}
						yxdcGzBoDgGHCkZwWeYBGnvXcxcx();
						break;
					}
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						wGPCfkIxppuMncbIvCfWcwLxxeGe();
					}
					break;
				}
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						yxdcGzBoDgGHCkZwWeYBGnvXcxcx();
					}
				}
			}

			[DebuggerHidden]
			public INyFUInkvOFahWrOOgueggPBdXSx(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void wGPCfkIxppuMncbIvCfWcwLxxeGe()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (moNpLwJFUZEtpagZJTJiHFdEbsJd != null)
				{
					moNpLwJFUZEtpagZJTJiHFdEbsJd.Dispose();
				}
			}

			private void yxdcGzBoDgGHCkZwWeYBGnvXcxcx()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (NVefGbDQHDhtXFZiGAeJciXVcJqW != null)
				{
					NVefGbDQHDhtXFZiGAeJciXVcJqW.Dispose();
				}
			}
		}

		private sealed class xSfKsAPRqsOgyqanusoQCJlTkpD : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ControllerPollingInfo utuISWGewGruhazfMMzUzVtyjUs;

			public ControllerPollingInfo FheoGdAqvGnESnRcOTPrYXizLmn;

			public IEnumerator<ControllerPollingInfo> BDZjCWhWMfFLcgbzHllazwSPWtC;

			public IEnumerator<ControllerPollingInfo> KaEfmXsndxbkMawYqOndCLZNcHFj;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				xSfKsAPRqsOgyqanusoQCJlTkpD xSfKsAPRqsOgyqanusoQCJlTkpD2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					xSfKsAPRqsOgyqanusoQCJlTkpD2 = this;
				}
				else
				{
					xSfKsAPRqsOgyqanusoQCJlTkpD2 = new xSfKsAPRqsOgyqanusoQCJlTkpD(0);
					xSfKsAPRqsOgyqanusoQCJlTkpD2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return xSfKsAPRqsOgyqanusoQCJlTkpD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						BDZjCWhWMfFLcgbzHllazwSPWtC = ((Controller)GxphHAMqMhNBLjnlhXuBQmXaALiE).PollForAllElementsDown().GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00a6;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00a6;
					case 4:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							goto IL_0107;
						}
						IL_00a6:
						if (BDZjCWhWMfFLcgbzHllazwSPWtC.MoveNext())
						{
							utuISWGewGruhazfMMzUzVtyjUs = BDZjCWhWMfFLcgbzHllazwSPWtC.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = utuISWGewGruhazfMMzUzVtyjUs;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						VOydVmjnhSAnyIgNxEEuFtSGmcqF();
						KaEfmXsndxbkMawYqOndCLZNcHFj = GxphHAMqMhNBLjnlhXuBQmXaALiE.PollForAllAxes().GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
						goto IL_0107;
						IL_0107:
						if (KaEfmXsndxbkMawYqOndCLZNcHFj.MoveNext())
						{
							FheoGdAqvGnESnRcOTPrYXizLmn = KaEfmXsndxbkMawYqOndCLZNcHFj.Current;
							WCNlIsEdYuVTqbNYvICUPcTebLU = FheoGdAqvGnESnRcOTPrYXizLmn;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
							return true;
						}
						xJmOHvAruQrlprcjjyHyofaoiNQC();
						break;
					}
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						VOydVmjnhSAnyIgNxEEuFtSGmcqF();
					}
					break;
				}
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						xJmOHvAruQrlprcjjyHyofaoiNQC();
					}
				}
			}

			[DebuggerHidden]
			public xSfKsAPRqsOgyqanusoQCJlTkpD(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void VOydVmjnhSAnyIgNxEEuFtSGmcqF()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (BDZjCWhWMfFLcgbzHllazwSPWtC != null)
				{
					BDZjCWhWMfFLcgbzHllazwSPWtC.Dispose();
				}
			}

			private void xJmOHvAruQrlprcjjyHyofaoiNQC()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (KaEfmXsndxbkMawYqOndCLZNcHFj != null)
				{
					KaEfmXsndxbkMawYqOndCLZNcHFj.Dispose();
				}
			}
		}

		private sealed class wMJRzMdfiBdRNqSpOeizEjVifDaC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerWithAxes GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int gXUFAEIDTpjuofoshBSLRbPTOZJ;

			public Pole bCkWDvtRFCuDSDleQihXBgPfLSl;

			public int hnswtpGcxoJeoZTucnAiVfcEUoi;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				wMJRzMdfiBdRNqSpOeizEjVifDaC wMJRzMdfiBdRNqSpOeizEjVifDaC2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					wMJRzMdfiBdRNqSpOeizEjVifDaC2 = this;
				}
				else
				{
					wMJRzMdfiBdRNqSpOeizEjVifDaC2 = new wMJRzMdfiBdRNqSpOeizEjVifDaC(0);
					wMJRzMdfiBdRNqSpOeizEjVifDaC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return wMJRzMdfiBdRNqSpOeizEjVifDaC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					GxphHAMqMhNBLjnlhXuBQmXaALiE.UpdatePollingFrameTracking();
					GxphHAMqMhNBLjnlhXuBQmXaALiE.fQcZjCweQewrvGAHKiXthCPXEsjF();
					gXUFAEIDTpjuofoshBSLRbPTOZJ = 0;
					goto IL_0100;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00f2;
					}
					IL_0100:
					if (gXUFAEIDTpjuofoshBSLRbPTOZJ >= GxphHAMqMhNBLjnlhXuBQmXaALiE._axisCount)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.IsPolledAxisActive(gXUFAEIDTpjuofoshBSLRbPTOZJ, out bCkWDvtRFCuDSDleQihXBgPfLSl, out hnswtpGcxoJeoZTucnAiVfcEUoi))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ControllerPollingInfo(success: true, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE.id, GxphHAMqMhNBLjnlhXuBQmXaALiE._name, GxphHAMqMhNBLjnlhXuBQmXaALiE._type, ControllerElementType.Axis, gXUFAEIDTpjuofoshBSLRbPTOZJ, bCkWDvtRFCuDSDleQihXBgPfLSl, GxphHAMqMhNBLjnlhXuBQmXaALiE.rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(hnswtpGcxoJeoZTucnAiVfcEUoi), hnswtpGcxoJeoZTucnAiVfcEUoi, KeyCode.None);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_00f2;
					IL_00f2:
					gXUFAEIDTpjuofoshBSLRbPTOZJ++;
					goto IL_0100;
				}
				return false;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public wMJRzMdfiBdRNqSpOeizEjVifDaC(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] GPuBBKepuECnZUYlEDrUrDUMexN;

		private uint pFEwULFhQuaScjcLRxeUPlPGpvB = uint.MaxValue;

		private Func<int, int> aXPYxwIOpdAfrxndJRmcwgRrwtm;

		public int axisCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return rEqQznEUmYwtoLNJsErzjlKjjYY.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, type, hardwareTypeGuid, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			_axisCount = axisCount;
			axes = new Axis[axisCount];
			for (int i = 0; i < axisCount; i++)
			{
				axes[i] = new Axis(this, hardwareMap.axisElementIdentifierIds[i], "Axis " + i, hardwareMap.hwAxisRanges[i], hardwareMap.hwAxisInfo[i]);
				SSjwBZRYcJqbFyjnlHATtvRHxFM(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(hardwareMap.hwAxisCalibrationData);
			_axis2DCount = hardwareMap.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = hardwareMap.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
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
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			NBoBPxhSovpdZbOwfkDAmfOLcrU();
			aXPYxwIOpdAfrxndJRmcwgRrwtm = hardwareMap.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return -1;
			}
			return rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int axisIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
			}
			UpdatePollingFrameTracking();
			fQcZjCweQewrvGAHKiXthCPXEsjF();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			INyFUInkvOFahWrOOgueggPBdXSx nyFUInkvOFahWrOOgueggPBdXSx = new INyFUInkvOFahWrOOgueggPBdXSx(-2);
			nyFUInkvOFahWrOOgueggPBdXSx.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return nyFUInkvOFahWrOOgueggPBdXSx;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			xSfKsAPRqsOgyqanusoQCJlTkpD xSfKsAPRqsOgyqanusoQCJlTkpD2 = new xSfKsAPRqsOgyqanusoQCJlTkpD(-2);
			xSfKsAPRqsOgyqanusoQCJlTkpD2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return xSfKsAPRqsOgyqanusoQCJlTkpD2;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			wMJRzMdfiBdRNqSpOeizEjVifDaC wMJRzMdfiBdRNqSpOeizEjVifDaC2 = new wMJRzMdfiBdRNqSpOeizEjVifDaC(-2);
			wMJRzMdfiBdRNqSpOeizEjVifDaC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return wMJRzMdfiBdRNqSpOeizEjVifDaC2;
		}

		private void fQcZjCweQewrvGAHKiXthCPXEsjF()
		{
			if (GPuBBKepuECnZUYlEDrUrDUMexN == null)
			{
				GPuBBKepuECnZUYlEDrUrDUMexN = new float[_axisCount];
			}
			if (vqxXpHkrAYztQxTWVORrRrBeeU != pFEwULFhQuaScjcLRxeUPlPGpvB)
			{
				pFEwULFhQuaScjcLRxeUPlPGpvB = vqxXpHkrAYztQxTWVORrRrBeeU;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					GPuBBKepuECnZUYlEDrUrDUMexN[i] = axes[i].gVohVLHuWUpHrVjZObwFoNpydjL(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].PlYUFxznkverJWuzpbzUWwQOLjs != null)
			{
				if (axes[index].PlYUFxznkverJWuzpbzUWwQOLjs._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].PlYUFxznkverJWuzpbzUWwQOLjs._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float num = axes[index].gVohVLHuWUpHrVjZObwFoNpydjL(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index));
			float value = num - GPuBBKepuECnZUYlEDrUrDUMexN[index];
			if (MathTools.Abs(value) <= axes[index].effectivePollingDeadZone)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = rEqQznEUmYwtoLNJsErzjlKjjYY.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			base.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !QlXkhNBHPYUNWwhKurdwrqFgWTf.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].HDwiRdALLxvIAmnSNVoeBHCYrsG(P_0);
				if (!flag || flag4 || (flag3 && !QlXkhNBHPYUNWwhKurdwrqFgWTf.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].HoMbxmMIHAknkYYJohvQOkdzoQg();
					continue;
				}
				axes[i].valueRaw = QlXkhNBHPYUNWwhKurdwrqFgWTf.axisValues[i];
				if (flag2)
				{
					axes[i].ufFFYZMrHQyqgOSHtbWQZtKNiSH(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].ufFFYZMrHQyqgOSHtbWQZtKNiSH();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].VEShBtNHGklmRUxZTegSZNXZpDo();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].VeybDNgeRuzuipYCxcQLFBZMvKnD();
			}
		}

		internal bool zsAFdEAZFrQLWpDufeXtopzllWwG(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int cRqOTsiLfoazJbodeeofQgavSxg = P_0.CRqOTsiLfoazJbodeeofQgavSxg;
			if (cRqOTsiLfoazJbodeeofQgavSxg < 0 || cRqOTsiLfoazJbodeeofQgavSxg >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[cRqOTsiLfoazJbodeeofQgavSxg].valueRaw : axes[cRqOTsiLfoazJbodeeofQgavSxg].value) : (P_2 ? axes[cRqOTsiLfoazJbodeeofQgavSxg].valueRawPrev : axes[cRqOTsiLfoazJbodeeofQgavSxg].valuePrev));
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

		internal override void udRnEWOwQJDseTQQIEzfgbieiXAF(ControllerMap P_0)
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
			base.udRnEWOwQJDseTQQIEzfgbieiXAF(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				IginakiartMCXcNztgFGkBgBmEe(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].JYRMuwETpVNRqJXmtBgBFhZdTeP);
				}
			}
		}

		internal override void IginakiartMCXcNztgFGkBgBmEe(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.IginakiartMCXcNztgFGkBgBmEe(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.qOVDONBKVKOloJeRYYKGTFZqcKAM(P_0);
				}
			}
		}

		internal void NBoBPxhSovpdZbOwfkDAmfOLcrU()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].PlYUFxznkverJWuzpbzUWwQOLjs._specialAxisType)
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

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			base.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> TSPfxirrvmZZfDqMWwIhXCsWwki()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> IpzGIEirJtNikfXZAVwCmIiczniW()
		{
			return base.PollForAllElementsDown();
		}
	}
}

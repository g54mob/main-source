using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class tCEgHfusewDTMgYILdabIsGpXTABb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int tjivLHVNFPuJXWITrhwJAtCgNhOk;

			private ControllerPollingInfo JDJcNaBeRHNumjhlpDeORLlTEKhvA;

			private int ahubyvbnxSlUqDeIBppaSFrPXrIhB;

			public ControllerWithAxes DLdcHWXDfQjHspUjLKLPXMREUsMq;

			private int GeehifWaFCbfSjCsEIpXsdeIqsvsA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JDJcNaBeRHNumjhlpDeORLlTEKhvA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JDJcNaBeRHNumjhlpDeORLlTEKhvA;
				}
			}

			[DebuggerHidden]
			public tCEgHfusewDTMgYILdabIsGpXTABb(int P_0)
			{
				tjivLHVNFPuJXWITrhwJAtCgNhOk = P_0;
				ahubyvbnxSlUqDeIBppaSFrPXrIhB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				tjivLHVNFPuJXWITrhwJAtCgNhOk = -2;
			}

			private bool MoveNext()
			{
				int num = tjivLHVNFPuJXWITrhwJAtCgNhOk;
				ControllerWithAxes dLdcHWXDfQjHspUjLKLPXMREUsMq = DLdcHWXDfQjHspUjLKLPXMREUsMq;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					tjivLHVNFPuJXWITrhwJAtCgNhOk = -1;
					goto IL_00a8;
				}
				tjivLHVNFPuJXWITrhwJAtCgNhOk = -1;
				if (ReInput._id != dLdcHWXDfQjHspUjLKLPXMREUsMq.BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(dLdcHWXDfQjHspUjLKLPXMREUsMq.BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				dLdcHWXDfQjHspUjLKLPXMREUsMq.UpdatePollingFrameTracking();
				dLdcHWXDfQjHspUjLKLPXMREUsMq.EcPcBUFXVJXHbaFxzLGBbfyGtQrvA();
				GeehifWaFCbfSjCsEIpXsdeIqsvsA = 0;
				goto IL_00ba;
				IL_00ba:
				if (GeehifWaFCbfSjCsEIpXsdeIqsvsA < dLdcHWXDfQjHspUjLKLPXMREUsMq._axisCount)
				{
					if (dLdcHWXDfQjHspUjLKLPXMREUsMq.IsPolledAxisActive(GeehifWaFCbfSjCsEIpXsdeIqsvsA, out var pole, out var elementIdentifierId))
					{
						JDJcNaBeRHNumjhlpDeORLlTEKhvA = new ControllerPollingInfo(true, -1, dLdcHWXDfQjHspUjLKLPXMREUsMq.id, dLdcHWXDfQjHspUjLKLPXMREUsMq._name, dLdcHWXDfQjHspUjLKLPXMREUsMq._type, ControllerElementType.Axis, GeehifWaFCbfSjCsEIpXsdeIqsvsA, pole, dLdcHWXDfQjHspUjLKLPXMREUsMq.JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						tjivLHVNFPuJXWITrhwJAtCgNhOk = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				GeehifWaFCbfSjCsEIpXsdeIqsvsA++;
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
				tCEgHfusewDTMgYILdabIsGpXTABb tCEgHfusewDTMgYILdabIsGpXTABb2;
				if (tjivLHVNFPuJXWITrhwJAtCgNhOk == -2 && ahubyvbnxSlUqDeIBppaSFrPXrIhB == Environment.CurrentManagedThreadId)
				{
					tjivLHVNFPuJXWITrhwJAtCgNhOk = 0;
					tCEgHfusewDTMgYILdabIsGpXTABb2 = this;
				}
				else
				{
					tCEgHfusewDTMgYILdabIsGpXTABb2 = new tCEgHfusewDTMgYILdabIsGpXTABb(0);
					tCEgHfusewDTMgYILdabIsGpXTABb2.DLdcHWXDfQjHspUjLKLPXMREUsMq = DLdcHWXDfQjHspUjLKLPXMREUsMq;
				}
				return tCEgHfusewDTMgYILdabIsGpXTABb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class VywNbhNWQJYqonNuzoiWoJUJHcYf : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int NnbhwsHyvGoitbOlkKKJDJLlmDleb;

			private ControllerPollingInfo RJPFByCKFRLBfTGkwHIYGcUKGzETA;

			private int xDKOHzqBHfEffBwFGHzmEPaeADwKA;

			public ControllerWithAxes bdigYWCkckjxIgbfcvZRiLUoRrQh;

			private IEnumerator<ControllerPollingInfo> YxbdNLzNctBeShBwUaenKXeKnMci;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RJPFByCKFRLBfTGkwHIYGcUKGzETA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RJPFByCKFRLBfTGkwHIYGcUKGzETA;
				}
			}

			[DebuggerHidden]
			public VywNbhNWQJYqonNuzoiWoJUJHcYf(int P_0)
			{
				NnbhwsHyvGoitbOlkKKJDJLlmDleb = P_0;
				xDKOHzqBHfEffBwFGHzmEPaeADwKA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (NnbhwsHyvGoitbOlkKKJDJLlmDleb)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						SsvGppqJxYepMCULbpLmhqVgfWUzb();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						dXtuRxKJHTSfhPPayHIJfuHLXDzCA();
					}
					break;
				}
				YxbdNLzNctBeShBwUaenKXeKnMci = null;
				NnbhwsHyvGoitbOlkKKJDJLlmDleb = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int nnbhwsHyvGoitbOlkKKJDJLlmDleb = NnbhwsHyvGoitbOlkKKJDJLlmDleb;
					ControllerWithAxes controllerWithAxes = bdigYWCkckjxIgbfcvZRiLUoRrQh;
					switch (nnbhwsHyvGoitbOlkKKJDJLlmDleb)
					{
					default:
						return false;
					case 0:
						NnbhwsHyvGoitbOlkKKJDJLlmDleb = -1;
						if (ReInput._id != controllerWithAxes.BLBdTaBAlamAEELtUyjiaIPfgySPA)
						{
							ReInput.CheckInitialized(controllerWithAxes.BLBdTaBAlamAEELtUyjiaIPfgySPA);
							return false;
						}
						YxbdNLzNctBeShBwUaenKXeKnMci = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						NnbhwsHyvGoitbOlkKKJDJLlmDleb = -3;
						goto IL_0092;
					case 1:
						NnbhwsHyvGoitbOlkKKJDJLlmDleb = -3;
						goto IL_0092;
					case 2:
						{
							NnbhwsHyvGoitbOlkKKJDJLlmDleb = -4;
							break;
						}
						IL_0092:
						if (YxbdNLzNctBeShBwUaenKXeKnMci.MoveNext())
						{
							ControllerPollingInfo current = YxbdNLzNctBeShBwUaenKXeKnMci.Current;
							RJPFByCKFRLBfTGkwHIYGcUKGzETA = current;
							NnbhwsHyvGoitbOlkKKJDJLlmDleb = 1;
							return true;
						}
						SsvGppqJxYepMCULbpLmhqVgfWUzb();
						YxbdNLzNctBeShBwUaenKXeKnMci = null;
						YxbdNLzNctBeShBwUaenKXeKnMci = controllerWithAxes.PollForAllAxes().GetEnumerator();
						NnbhwsHyvGoitbOlkKKJDJLlmDleb = -4;
						break;
					}
					if (YxbdNLzNctBeShBwUaenKXeKnMci.MoveNext())
					{
						ControllerPollingInfo current2 = YxbdNLzNctBeShBwUaenKXeKnMci.Current;
						RJPFByCKFRLBfTGkwHIYGcUKGzETA = current2;
						NnbhwsHyvGoitbOlkKKJDJLlmDleb = 2;
						return true;
					}
					dXtuRxKJHTSfhPPayHIJfuHLXDzCA();
					YxbdNLzNctBeShBwUaenKXeKnMci = null;
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

			private void SsvGppqJxYepMCULbpLmhqVgfWUzb()
			{
				NnbhwsHyvGoitbOlkKKJDJLlmDleb = -1;
				if (YxbdNLzNctBeShBwUaenKXeKnMci != null)
				{
					YxbdNLzNctBeShBwUaenKXeKnMci.Dispose();
				}
			}

			private void dXtuRxKJHTSfhPPayHIJfuHLXDzCA()
			{
				NnbhwsHyvGoitbOlkKKJDJLlmDleb = -1;
				if (YxbdNLzNctBeShBwUaenKXeKnMci != null)
				{
					YxbdNLzNctBeShBwUaenKXeKnMci.Dispose();
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
				VywNbhNWQJYqonNuzoiWoJUJHcYf vywNbhNWQJYqonNuzoiWoJUJHcYf;
				if (NnbhwsHyvGoitbOlkKKJDJLlmDleb == -2 && xDKOHzqBHfEffBwFGHzmEPaeADwKA == Environment.CurrentManagedThreadId)
				{
					NnbhwsHyvGoitbOlkKKJDJLlmDleb = 0;
					vywNbhNWQJYqonNuzoiWoJUJHcYf = this;
				}
				else
				{
					vywNbhNWQJYqonNuzoiWoJUJHcYf = new VywNbhNWQJYqonNuzoiWoJUJHcYf(0);
					vywNbhNWQJYqonNuzoiWoJUJHcYf.bdigYWCkckjxIgbfcvZRiLUoRrQh = bdigYWCkckjxIgbfcvZRiLUoRrQh;
				}
				return vywNbhNWQJYqonNuzoiWoJUJHcYf;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class TjUmAdDPUIMmXbboJXbchqOerXMQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int DyduoSXYVmIOMFMVKXmsOiTjjaIh;

			private ControllerPollingInfo cAyFBEoDQVfJyHOZEUlSmUfgvYtb;

			private int yVTDhxsDlYfwihrQJADkeTEgnOguB;

			public ControllerWithAxes XThzFuReLYTQVuEKBDHDPldxyYjB;

			private IEnumerator<ControllerPollingInfo> EhFbHJQOhzGKtLdUcQqosXmXNudF;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return cAyFBEoDQVfJyHOZEUlSmUfgvYtb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cAyFBEoDQVfJyHOZEUlSmUfgvYtb;
				}
			}

			[DebuggerHidden]
			public TjUmAdDPUIMmXbboJXbchqOerXMQ(int P_0)
			{
				DyduoSXYVmIOMFMVKXmsOiTjjaIh = P_0;
				yVTDhxsDlYfwihrQJADkeTEgnOguB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (DyduoSXYVmIOMFMVKXmsOiTjjaIh)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						awyHclpwPEmMbfiWhehQdwUkrslF();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						fFBhxEFexRmpjsXPACgacLQDHpEPc();
					}
					break;
				}
				EhFbHJQOhzGKtLdUcQqosXmXNudF = null;
				DyduoSXYVmIOMFMVKXmsOiTjjaIh = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int dyduoSXYVmIOMFMVKXmsOiTjjaIh = DyduoSXYVmIOMFMVKXmsOiTjjaIh;
					ControllerWithAxes xThzFuReLYTQVuEKBDHDPldxyYjB = XThzFuReLYTQVuEKBDHDPldxyYjB;
					switch (dyduoSXYVmIOMFMVKXmsOiTjjaIh)
					{
					default:
						return false;
					case 0:
						DyduoSXYVmIOMFMVKXmsOiTjjaIh = -1;
						if (ReInput._id != xThzFuReLYTQVuEKBDHDPldxyYjB.BLBdTaBAlamAEELtUyjiaIPfgySPA)
						{
							ReInput.CheckInitialized(xThzFuReLYTQVuEKBDHDPldxyYjB.BLBdTaBAlamAEELtUyjiaIPfgySPA);
							return false;
						}
						EhFbHJQOhzGKtLdUcQqosXmXNudF = ((Controller)xThzFuReLYTQVuEKBDHDPldxyYjB).PollForAllElementsDown().GetEnumerator();
						DyduoSXYVmIOMFMVKXmsOiTjjaIh = -3;
						goto IL_0092;
					case 1:
						DyduoSXYVmIOMFMVKXmsOiTjjaIh = -3;
						goto IL_0092;
					case 2:
						{
							DyduoSXYVmIOMFMVKXmsOiTjjaIh = -4;
							break;
						}
						IL_0092:
						if (EhFbHJQOhzGKtLdUcQqosXmXNudF.MoveNext())
						{
							ControllerPollingInfo current = EhFbHJQOhzGKtLdUcQqosXmXNudF.Current;
							cAyFBEoDQVfJyHOZEUlSmUfgvYtb = current;
							DyduoSXYVmIOMFMVKXmsOiTjjaIh = 1;
							return true;
						}
						awyHclpwPEmMbfiWhehQdwUkrslF();
						EhFbHJQOhzGKtLdUcQqosXmXNudF = null;
						EhFbHJQOhzGKtLdUcQqosXmXNudF = xThzFuReLYTQVuEKBDHDPldxyYjB.PollForAllAxes().GetEnumerator();
						DyduoSXYVmIOMFMVKXmsOiTjjaIh = -4;
						break;
					}
					if (EhFbHJQOhzGKtLdUcQqosXmXNudF.MoveNext())
					{
						ControllerPollingInfo current2 = EhFbHJQOhzGKtLdUcQqosXmXNudF.Current;
						cAyFBEoDQVfJyHOZEUlSmUfgvYtb = current2;
						DyduoSXYVmIOMFMVKXmsOiTjjaIh = 2;
						return true;
					}
					fFBhxEFexRmpjsXPACgacLQDHpEPc();
					EhFbHJQOhzGKtLdUcQqosXmXNudF = null;
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

			private void awyHclpwPEmMbfiWhehQdwUkrslF()
			{
				DyduoSXYVmIOMFMVKXmsOiTjjaIh = -1;
				if (EhFbHJQOhzGKtLdUcQqosXmXNudF != null)
				{
					EhFbHJQOhzGKtLdUcQqosXmXNudF.Dispose();
				}
			}

			private void fFBhxEFexRmpjsXPACgacLQDHpEPc()
			{
				DyduoSXYVmIOMFMVKXmsOiTjjaIh = -1;
				if (EhFbHJQOhzGKtLdUcQqosXmXNudF != null)
				{
					EhFbHJQOhzGKtLdUcQqosXmXNudF.Dispose();
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
				TjUmAdDPUIMmXbboJXbchqOerXMQ tjUmAdDPUIMmXbboJXbchqOerXMQ;
				if (DyduoSXYVmIOMFMVKXmsOiTjjaIh == -2 && yVTDhxsDlYfwihrQJADkeTEgnOguB == Environment.CurrentManagedThreadId)
				{
					DyduoSXYVmIOMFMVKXmsOiTjjaIh = 0;
					tjUmAdDPUIMmXbboJXbchqOerXMQ = this;
				}
				else
				{
					tjUmAdDPUIMmXbboJXbchqOerXMQ = new TjUmAdDPUIMmXbboJXbchqOerXMQ(0);
					tjUmAdDPUIMmXbboJXbchqOerXMQ.XThzFuReLYTQVuEKBDHDPldxyYjB = XThzFuReLYTQVuEKBDHDPldxyYjB;
				}
				return tjUmAdDPUIMmXbboJXbchqOerXMQ;
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

		private float[] PoefiTTNyNFqUarXIcASJdkRgOol;

		private uint MMHTBtowCjVCByFdFEZewngKMdSB = uint.MaxValue;

		private TimerAbs YOHEZfcZyCBsXdriDxkSCksCOAkQE;

		private float[] mZJztDhDMhsXjDiaERHCYsnNRmDB;

		private Func<int, int> EMeLufInwMftLCcLNZSuPYgevsgJ;

		public int axisCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return JEexZOPzSUUjNTHjvxywblgJdFqE.axisElementIdentifiers_readOnly;
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
				CnmKJzJNbScNsKxtssYAwlinIlxw(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			Func<int, int> func = null;
			if (base.extension is IAxisCalibrationIndexMap)
			{
				func = (int num2) => (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap) ? axisCalibrationIndexMap.GetMappedAxisIndex(num2) : num2;
			}
			_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData, P_10.hwAxis2DCalibrationData, func);
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
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, 0, null);
						continue;
					}
					int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, num, null);
					}
					else
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, num, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[num] = new Axis2D(this, -1, "Axis 2D " + num, null, null, 0, 0, 0, null);
				}
				finally
				{
					zSHDKCuszCZlCImNllcKJkiMDDjp(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			hmDAWcEacMcaXJhwIoXgwclIUQWh();
			EMeLufInwMftLCcLNZSuPYgevsgJ = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			if (JEexZOPzSUUjNTHjvxywblgJdFqE == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return -1;
			}
			return JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0f;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0f;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0f;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0f;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int axisIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
			}
			UpdatePollingFrameTracking();
			EcPcBUFXVJXHbaFxzLGBbfyGtQrvA();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
		}

		[IteratorStateMachine(typeof(VywNbhNWQJYqonNuzoiWoJUJHcYf))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new VywNbhNWQJYqonNuzoiWoJUJHcYf(-2)
			{
				bdigYWCkckjxIgbfcvZRiLUoRrQh = this
			};
		}

		[IteratorStateMachine(typeof(TjUmAdDPUIMmXbboJXbchqOerXMQ))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new TjUmAdDPUIMmXbboJXbchqOerXMQ(-2)
			{
				XThzFuReLYTQVuEKBDHDPldxyYjB = this
			};
		}

		[IteratorStateMachine(typeof(tCEgHfusewDTMgYILdabIsGpXTABb))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new tCEgHfusewDTMgYILdabIsGpXTABb(-2)
			{
				DLdcHWXDfQjHspUjLKLPXMREUsMq = this
			};
		}

		private void EcPcBUFXVJXHbaFxzLGBbfyGtQrvA()
		{
			if (PoefiTTNyNFqUarXIcASJdkRgOol == null)
			{
				PoefiTTNyNFqUarXIcASJdkRgOol = new float[_axisCount];
			}
			if (FaPBxQSiRTtxQtkYJdpDejVMuMGR != MMHTBtowCjVCByFdFEZewngKMdSB)
			{
				MMHTBtowCjVCByFdFEZewngKMdSB = FaPBxQSiRTtxQtkYJdpDejVMuMGR;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					PoefiTTNyNFqUarXIcASJdkRgOol[i] = axes[i].VpriZzyhDbOFiLGOsLVDsauJsqFY(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].excludeFromPolling)
			{
				return false;
			}
			float value;
			switch (axes[index].axisCoordinateMode)
			{
			case AxisCoordinateMode.Absolute:
				value = axes[index].VpriZzyhDbOFiLGOsLVDsauJsqFY(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - PoefiTTNyNFqUarXIcASJdkRgOol[index];
				break;
			case AxisCoordinateMode.Relative:
				if (mZJztDhDMhsXjDiaERHCYsnNRmDB == null)
				{
					mZJztDhDMhsXjDiaERHCYsnNRmDB = new float[_axisCount];
				}
				if (YOHEZfcZyCBsXdriDxkSCksCOAkQE == null)
				{
					YOHEZfcZyCBsXdriDxkSCksCOAkQE = new TimerAbs(1.0);
				}
				if (YOHEZfcZyCBsXdriDxkSCksCOAkQE.Update() || !YOHEZfcZyCBsXdriDxkSCksCOAkQE.running)
				{
					YOHEZfcZyCBsXdriDxkSCksCOAkQE.Start();
					Array.Clear(mZJztDhDMhsXjDiaERHCYsnNRmDB, 0, mZJztDhDMhsXjDiaERHCYsnNRmDB.Length);
				}
				mZJztDhDMhsXjDiaERHCYsnNRmDB[index] += axes[index].valueRaw;
				value = mZJztDhDMhsXjDiaERHCYsnNRmDB[index];
				break;
			default:
				throw new NotImplementedException();
			}
			if (MathTools.Abs(value) <= axes[index].QotXiKTAnzsOoreyziOokgBIJBeF)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = JEexZOPzSUUjNTHjvxywblgJdFqE.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void QJtejDrikfTcXiOVZAOExcIHSejO(UpdateLoopType P_0)
		{
			base.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !vAJlxjrsCepUBGzroHjWcArmXQkU.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].uKozSjffJSMUqoeBPTBIbwXJDMNe(P_0);
				if (!flag || flag4 || (flag3 && !vAJlxjrsCepUBGzroHjWcArmXQkU.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].PWtyzGPEepWdjXEVSMOmzepnuCw();
					continue;
				}
				axes[i].valueRaw = vAJlxjrsCepUBGzroHjWcArmXQkU.axisValues[i];
				if (flag2)
				{
					axes[i].SGmUTImrEvbkPFCKoIgqtGTFGFMM(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].NeUtFMgSnYOIHiMKZShvFqWxHoxM();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].sYWepCAjnCfeVrpxTWwPwvkvmWnm();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].gtsugbZJetLrCzcjtTrQgdlvlQZH();
			}
		}

		internal bool utDGiyZiGObpWBRWDGOhdnZIgBZv(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int fpLTJzOTpoUWkyThKhrqRzXDquMW = P_0.fpLTJzOTpoUWkyThKhrqRzXDquMW;
			if (fpLTJzOTpoUWkyThKhrqRzXDquMW < 0 || fpLTJzOTpoUWkyThKhrqRzXDquMW >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[fpLTJzOTpoUWkyThKhrqRzXDquMW].valueRaw : axes[fpLTJzOTpoUWkyThKhrqRzXDquMW].value) : (P_2 ? axes[fpLTJzOTpoUWkyThKhrqRzXDquMW].valueRawPrev : axes[fpLTJzOTpoUWkyThKhrqRzXDquMW].valuePrev));
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

		internal virtual void hrIuoahvgWtZmiXpOhIKQHlBCSFR(ControllerMap P_0)
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
			try
			{
				ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
				base.CfhpsvHyWfICgEKNRdHQTCKBrgig(P_0);
				IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
				for (int i = 0; i < axisMaps.Count; i++)
				{
					EfvdQpyXFryBbeksYVlLvkBmPQQC(P_0, axisMaps[i]);
				}
				for (int num = axisMaps.Count - 1; num >= 0; num--)
				{
					if (axisMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(axisMaps[num].gjHUlVyQSQsjZEOHtHfmeehEQpiIA);
					}
				}
			}
			finally
			{
				ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}

		internal virtual void XTiGbXXOYkmrSHJmwBlsyXYCgjfS(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.EfvdQpyXFryBbeksYVlLvkBmPQQC(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.FNqTNkOozAgwnWePEBwoFWAPyUfy(P_0);
				}
			}
		}

		internal void hmDAWcEacMcaXJhwIoXgwclIUQWh()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].aWgdabdFXKHTbUDLyoVfrwOlgFah._specialAxisType)
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

		internal virtual void cubHyftKveceaSGovHckWjlTpqaN()
		{
			base.ufAgwGoHxawiKAxEmPcnTrGkJWTF();
			if (YOHEZfcZyCBsXdriDxkSCksCOAkQE != null)
			{
				YOHEZfcZyCBsXdriDxkSCksCOAkQE.Clear();
			}
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private int hECADljYHTdmfiKOfHCvCUNiklhx(int P_0)
		{
			if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
			}
			return P_0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> EiNKnydRtWCjedSxrKKLolNAVslc()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> fDrtJPBlDXnajTXAQvhBTNikgIFF()
		{
			return base.PollForAllElementsDown();
		}
	}
}

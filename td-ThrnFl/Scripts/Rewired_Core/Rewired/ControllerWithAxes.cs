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
		private sealed class lnwKwkSfIqKoxffAUkNpOrpTeKIl : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int JzAyMCVInylbCMQnxTEkJPlIkSSk;

			private ControllerPollingInfo hsGsGSEjumdIJEGhAtKcxsRTnblab;

			private int qFIuZDlNYzvCsPfWxRRFtBZSfsmt;

			public ControllerWithAxes NdFjtzKgilPdrYoFaCNrKyHaXsUCA;

			private int manAeEuBrzBHHEPqImOYuWNKoqbT;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return hsGsGSEjumdIJEGhAtKcxsRTnblab;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hsGsGSEjumdIJEGhAtKcxsRTnblab;
				}
			}

			[DebuggerHidden]
			public lnwKwkSfIqKoxffAUkNpOrpTeKIl(int P_0)
			{
				JzAyMCVInylbCMQnxTEkJPlIkSSk = P_0;
				qFIuZDlNYzvCsPfWxRRFtBZSfsmt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int jzAyMCVInylbCMQnxTEkJPlIkSSk = JzAyMCVInylbCMQnxTEkJPlIkSSk;
				ControllerWithAxes ndFjtzKgilPdrYoFaCNrKyHaXsUCA = NdFjtzKgilPdrYoFaCNrKyHaXsUCA;
				if (jzAyMCVInylbCMQnxTEkJPlIkSSk != 0)
				{
					if (jzAyMCVInylbCMQnxTEkJPlIkSSk != 1)
					{
						return false;
					}
					JzAyMCVInylbCMQnxTEkJPlIkSSk = -1;
					goto IL_00a8;
				}
				JzAyMCVInylbCMQnxTEkJPlIkSSk = -1;
				if (ReInput._id != ndFjtzKgilPdrYoFaCNrKyHaXsUCA.amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(ndFjtzKgilPdrYoFaCNrKyHaXsUCA.amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				ndFjtzKgilPdrYoFaCNrKyHaXsUCA.UpdatePollingFrameTracking();
				ndFjtzKgilPdrYoFaCNrKyHaXsUCA.tcrfywfTCRLQsCwoDJkqorZEoWcjc();
				manAeEuBrzBHHEPqImOYuWNKoqbT = 0;
				goto IL_00ba;
				IL_00ba:
				if (manAeEuBrzBHHEPqImOYuWNKoqbT < ndFjtzKgilPdrYoFaCNrKyHaXsUCA._axisCount)
				{
					if (ndFjtzKgilPdrYoFaCNrKyHaXsUCA.IsPolledAxisActive(manAeEuBrzBHHEPqImOYuWNKoqbT, out var pole, out var elementIdentifierId))
					{
						hsGsGSEjumdIJEGhAtKcxsRTnblab = new ControllerPollingInfo(true, -1, ndFjtzKgilPdrYoFaCNrKyHaXsUCA.id, ndFjtzKgilPdrYoFaCNrKyHaXsUCA._name, ndFjtzKgilPdrYoFaCNrKyHaXsUCA._type, ControllerElementType.Axis, manAeEuBrzBHHEPqImOYuWNKoqbT, pole, ndFjtzKgilPdrYoFaCNrKyHaXsUCA.qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						JzAyMCVInylbCMQnxTEkJPlIkSSk = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				manAeEuBrzBHHEPqImOYuWNKoqbT++;
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
				lnwKwkSfIqKoxffAUkNpOrpTeKIl lnwKwkSfIqKoxffAUkNpOrpTeKIl2;
				if (JzAyMCVInylbCMQnxTEkJPlIkSSk == -2 && qFIuZDlNYzvCsPfWxRRFtBZSfsmt == Environment.CurrentManagedThreadId)
				{
					JzAyMCVInylbCMQnxTEkJPlIkSSk = 0;
					lnwKwkSfIqKoxffAUkNpOrpTeKIl2 = this;
				}
				else
				{
					lnwKwkSfIqKoxffAUkNpOrpTeKIl2 = new lnwKwkSfIqKoxffAUkNpOrpTeKIl(0);
					lnwKwkSfIqKoxffAUkNpOrpTeKIl2.NdFjtzKgilPdrYoFaCNrKyHaXsUCA = NdFjtzKgilPdrYoFaCNrKyHaXsUCA;
				}
				return lnwKwkSfIqKoxffAUkNpOrpTeKIl2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class lQcqnfrrzrmcZQowXNgueXpFmCup : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int ZxuAeScKUfvfXIMlIYksEpEhXCJrA;

			private ControllerPollingInfo RZtarmOyhzFcHSrcuRZvCrDHgKEc;

			private int LRLdQrKWDgpRsOdtUIfCaYPlQDosA;

			public ControllerWithAxes EmSczSosVSHtwgqiMJjCZnXBRbP;

			private IEnumerator<ControllerPollingInfo> SUpuWTNqmyDJroHtGGlovwJoJuRm;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RZtarmOyhzFcHSrcuRZvCrDHgKEc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RZtarmOyhzFcHSrcuRZvCrDHgKEc;
				}
			}

			[DebuggerHidden]
			public lQcqnfrrzrmcZQowXNgueXpFmCup(int P_0)
			{
				ZxuAeScKUfvfXIMlIYksEpEhXCJrA = P_0;
				LRLdQrKWDgpRsOdtUIfCaYPlQDosA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (ZxuAeScKUfvfXIMlIYksEpEhXCJrA)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						adRAoYjbfoYSXbzNLbTOCtTAHszjB();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						URqmOZbLBHmlWgGzOJTzoCqNazyx();
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
					int zxuAeScKUfvfXIMlIYksEpEhXCJrA = ZxuAeScKUfvfXIMlIYksEpEhXCJrA;
					ControllerWithAxes emSczSosVSHtwgqiMJjCZnXBRbP = EmSczSosVSHtwgqiMJjCZnXBRbP;
					switch (zxuAeScKUfvfXIMlIYksEpEhXCJrA)
					{
					default:
						return false;
					case 0:
						ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -1;
						if (ReInput._id != emSczSosVSHtwgqiMJjCZnXBRbP.amvEgOgWeoORBWecwIHRbEwcHoDuB)
						{
							ReInput.CheckInitialized(emSczSosVSHtwgqiMJjCZnXBRbP.amvEgOgWeoORBWecwIHRbEwcHoDuB);
							return false;
						}
						SUpuWTNqmyDJroHtGGlovwJoJuRm = ((Controller)emSczSosVSHtwgqiMJjCZnXBRbP).PollForAllElements().GetEnumerator();
						ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -3;
						goto IL_0092;
					case 1:
						ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -3;
						goto IL_0092;
					case 2:
						{
							ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -4;
							break;
						}
						IL_0092:
						if (SUpuWTNqmyDJroHtGGlovwJoJuRm.MoveNext())
						{
							ControllerPollingInfo current = SUpuWTNqmyDJroHtGGlovwJoJuRm.Current;
							RZtarmOyhzFcHSrcuRZvCrDHgKEc = current;
							ZxuAeScKUfvfXIMlIYksEpEhXCJrA = 1;
							return true;
						}
						adRAoYjbfoYSXbzNLbTOCtTAHszjB();
						SUpuWTNqmyDJroHtGGlovwJoJuRm = null;
						SUpuWTNqmyDJroHtGGlovwJoJuRm = emSczSosVSHtwgqiMJjCZnXBRbP.PollForAllAxes().GetEnumerator();
						ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -4;
						break;
					}
					if (SUpuWTNqmyDJroHtGGlovwJoJuRm.MoveNext())
					{
						ControllerPollingInfo current2 = SUpuWTNqmyDJroHtGGlovwJoJuRm.Current;
						RZtarmOyhzFcHSrcuRZvCrDHgKEc = current2;
						ZxuAeScKUfvfXIMlIYksEpEhXCJrA = 2;
						return true;
					}
					URqmOZbLBHmlWgGzOJTzoCqNazyx();
					SUpuWTNqmyDJroHtGGlovwJoJuRm = null;
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

			private void adRAoYjbfoYSXbzNLbTOCtTAHszjB()
			{
				ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -1;
				if (SUpuWTNqmyDJroHtGGlovwJoJuRm != null)
				{
					SUpuWTNqmyDJroHtGGlovwJoJuRm.Dispose();
				}
			}

			private void URqmOZbLBHmlWgGzOJTzoCqNazyx()
			{
				ZxuAeScKUfvfXIMlIYksEpEhXCJrA = -1;
				if (SUpuWTNqmyDJroHtGGlovwJoJuRm != null)
				{
					SUpuWTNqmyDJroHtGGlovwJoJuRm.Dispose();
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
				lQcqnfrrzrmcZQowXNgueXpFmCup lQcqnfrrzrmcZQowXNgueXpFmCup2;
				if (ZxuAeScKUfvfXIMlIYksEpEhXCJrA == -2 && LRLdQrKWDgpRsOdtUIfCaYPlQDosA == Environment.CurrentManagedThreadId)
				{
					ZxuAeScKUfvfXIMlIYksEpEhXCJrA = 0;
					lQcqnfrrzrmcZQowXNgueXpFmCup2 = this;
				}
				else
				{
					lQcqnfrrzrmcZQowXNgueXpFmCup2 = new lQcqnfrrzrmcZQowXNgueXpFmCup(0);
					lQcqnfrrzrmcZQowXNgueXpFmCup2.EmSczSosVSHtwgqiMJjCZnXBRbP = EmSczSosVSHtwgqiMJjCZnXBRbP;
				}
				return lQcqnfrrzrmcZQowXNgueXpFmCup2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class NxjpoqBZSEERwrHXfIZRprJWcPUq : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int hVvdDxWudXKicJRfBEDOhsiHsNwL;

			private ControllerPollingInfo wGIrCDhuozqINiSOyNAiRSfvekHu;

			private int SitavEAVDheocorGUqHaNkpomLAq;

			public ControllerWithAxes PjazddKgwCuBpMcoDXfPnNZDBLyQ;

			private IEnumerator<ControllerPollingInfo> PpHftTMqjHRlXRCaycbuBidONjMKA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return wGIrCDhuozqINiSOyNAiRSfvekHu;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wGIrCDhuozqINiSOyNAiRSfvekHu;
				}
			}

			[DebuggerHidden]
			public NxjpoqBZSEERwrHXfIZRprJWcPUq(int P_0)
			{
				hVvdDxWudXKicJRfBEDOhsiHsNwL = P_0;
				SitavEAVDheocorGUqHaNkpomLAq = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (hVvdDxWudXKicJRfBEDOhsiHsNwL)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						iTtbMLcKFRXdbeIncaWRaFtyQvVYA();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						OqLbNIIAxbvQKmfXXfLVGIcYptykA();
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
					int num = hVvdDxWudXKicJRfBEDOhsiHsNwL;
					ControllerWithAxes pjazddKgwCuBpMcoDXfPnNZDBLyQ = PjazddKgwCuBpMcoDXfPnNZDBLyQ;
					switch (num)
					{
					default:
						return false;
					case 0:
						hVvdDxWudXKicJRfBEDOhsiHsNwL = -1;
						if (ReInput._id != pjazddKgwCuBpMcoDXfPnNZDBLyQ.amvEgOgWeoORBWecwIHRbEwcHoDuB)
						{
							ReInput.CheckInitialized(pjazddKgwCuBpMcoDXfPnNZDBLyQ.amvEgOgWeoORBWecwIHRbEwcHoDuB);
							return false;
						}
						PpHftTMqjHRlXRCaycbuBidONjMKA = ((Controller)pjazddKgwCuBpMcoDXfPnNZDBLyQ).PollForAllElementsDown().GetEnumerator();
						hVvdDxWudXKicJRfBEDOhsiHsNwL = -3;
						goto IL_0092;
					case 1:
						hVvdDxWudXKicJRfBEDOhsiHsNwL = -3;
						goto IL_0092;
					case 2:
						{
							hVvdDxWudXKicJRfBEDOhsiHsNwL = -4;
							break;
						}
						IL_0092:
						if (PpHftTMqjHRlXRCaycbuBidONjMKA.MoveNext())
						{
							ControllerPollingInfo current = PpHftTMqjHRlXRCaycbuBidONjMKA.Current;
							wGIrCDhuozqINiSOyNAiRSfvekHu = current;
							hVvdDxWudXKicJRfBEDOhsiHsNwL = 1;
							return true;
						}
						iTtbMLcKFRXdbeIncaWRaFtyQvVYA();
						PpHftTMqjHRlXRCaycbuBidONjMKA = null;
						PpHftTMqjHRlXRCaycbuBidONjMKA = pjazddKgwCuBpMcoDXfPnNZDBLyQ.PollForAllAxes().GetEnumerator();
						hVvdDxWudXKicJRfBEDOhsiHsNwL = -4;
						break;
					}
					if (PpHftTMqjHRlXRCaycbuBidONjMKA.MoveNext())
					{
						ControllerPollingInfo current2 = PpHftTMqjHRlXRCaycbuBidONjMKA.Current;
						wGIrCDhuozqINiSOyNAiRSfvekHu = current2;
						hVvdDxWudXKicJRfBEDOhsiHsNwL = 2;
						return true;
					}
					OqLbNIIAxbvQKmfXXfLVGIcYptykA();
					PpHftTMqjHRlXRCaycbuBidONjMKA = null;
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

			private void iTtbMLcKFRXdbeIncaWRaFtyQvVYA()
			{
				hVvdDxWudXKicJRfBEDOhsiHsNwL = -1;
				if (PpHftTMqjHRlXRCaycbuBidONjMKA != null)
				{
					PpHftTMqjHRlXRCaycbuBidONjMKA.Dispose();
				}
			}

			private void OqLbNIIAxbvQKmfXXfLVGIcYptykA()
			{
				hVvdDxWudXKicJRfBEDOhsiHsNwL = -1;
				if (PpHftTMqjHRlXRCaycbuBidONjMKA != null)
				{
					PpHftTMqjHRlXRCaycbuBidONjMKA.Dispose();
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
				NxjpoqBZSEERwrHXfIZRprJWcPUq nxjpoqBZSEERwrHXfIZRprJWcPUq;
				if (hVvdDxWudXKicJRfBEDOhsiHsNwL == -2 && SitavEAVDheocorGUqHaNkpomLAq == Environment.CurrentManagedThreadId)
				{
					hVvdDxWudXKicJRfBEDOhsiHsNwL = 0;
					nxjpoqBZSEERwrHXfIZRprJWcPUq = this;
				}
				else
				{
					nxjpoqBZSEERwrHXfIZRprJWcPUq = new NxjpoqBZSEERwrHXfIZRprJWcPUq(0);
					nxjpoqBZSEERwrHXfIZRprJWcPUq.PjazddKgwCuBpMcoDXfPnNZDBLyQ = PjazddKgwCuBpMcoDXfPnNZDBLyQ;
				}
				return nxjpoqBZSEERwrHXfIZRprJWcPUq;
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

		private float[] icUEmjTbhRIQDTviqHGrJoTdcytR;

		private uint bVqqDhcjREEsLPQiTgBqkKSkOJiJ = uint.MaxValue;

		private Func<int, int> joSPVFWldUjoOExWdynZgXDEtjxqA;

		public int axisCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.axisElementIdentifiers_readOnly;
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
				pMIfsVXUiOvYtrPsQFibeKRTOhkQ(axes[i]);
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
					GVljbkeDoYqeJxOGVFEfBxBaaTiT(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			MxvxpSUerYzdWaxdgYeBgpCcQmXG();
			joSPVFWldUjoOExWdynZgXDEtjxqA = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			if (qfUAjoZEkUJBMcgOHFRLtyQzKjdR == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return -1;
			}
			return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0f;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0f;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0f;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0f;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int axisIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
			}
			UpdatePollingFrameTracking();
			tcrfywfTCRLQsCwoDJkqorZEoWcjc();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
		}

		[IteratorStateMachine(typeof(lQcqnfrrzrmcZQowXNgueXpFmCup))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new lQcqnfrrzrmcZQowXNgueXpFmCup(-2)
			{
				EmSczSosVSHtwgqiMJjCZnXBRbP = this
			};
		}

		[IteratorStateMachine(typeof(NxjpoqBZSEERwrHXfIZRprJWcPUq))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new NxjpoqBZSEERwrHXfIZRprJWcPUq(-2)
			{
				PjazddKgwCuBpMcoDXfPnNZDBLyQ = this
			};
		}

		[IteratorStateMachine(typeof(lnwKwkSfIqKoxffAUkNpOrpTeKIl))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new lnwKwkSfIqKoxffAUkNpOrpTeKIl(-2)
			{
				NdFjtzKgilPdrYoFaCNrKyHaXsUCA = this
			};
		}

		private void tcrfywfTCRLQsCwoDJkqorZEoWcjc()
		{
			if (icUEmjTbhRIQDTviqHGrJoTdcytR == null)
			{
				icUEmjTbhRIQDTviqHGrJoTdcytR = new float[_axisCount];
			}
			if (yMnQryEwKXmSLSkZpVlqywTeEaTh != bVqqDhcjREEsLPQiTgBqkKSkOJiJ)
			{
				bVqqDhcjREEsLPQiTgBqkKSkOJiJ = yMnQryEwKXmSLSkZpVlqywTeEaTh;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					icUEmjTbhRIQDTviqHGrJoTdcytR[i] = axes[i].aDLkkJkwSxfWbsWZKOtiooHnuwMk(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].RWCEZctGAZWeIhWIQMIAdNROmnEb != null)
			{
				if (axes[index].RWCEZctGAZWeIhWIQMIAdNROmnEb._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].RWCEZctGAZWeIhWIQMIAdNROmnEb._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].aDLkkJkwSxfWbsWZKOtiooHnuwMk(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - icUEmjTbhRIQDTviqHGrJoTdcytR[index];
			if (MathTools.Abs(value) <= axes[index].FKowYLDhIdlyIzPFQTgaXGyHryB)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void flHIGtttxvNnQVLUjNmdvPvlaaau(UpdateLoopType P_0)
		{
			base.hdccNRifKnNeMIMmCYJkjUCelZGPA(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !EnxeINdfRsPNEfNsWCRpkeCWEWlpA.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].DXWGsffwrIFPYNzJjxpTxDPxPMGB(P_0);
				if (!flag || flag4 || (flag3 && !EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].oJuTJvOHDwPaiYTGzqihiDrZsoPC();
					continue;
				}
				axes[i].valueRaw = EnxeINdfRsPNEfNsWCRpkeCWEWlpA.axisValues[i];
				if (flag2)
				{
					axes[i].zIStigwsFbaNEocHKioHdRajpBFw(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].kqwlgmokkCqPWVJDnIPMCTfTlmorA();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].XzmaJmICkGalCBKwnhOqxmFLLscfb();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].DWQTQLJxgrEbVCDkTrWnsdCPdoIh();
			}
		}

		internal bool XglhTAFUTWrgNiTLtRyIhzqaCFSn(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int yBnBsBBQkmlNrgHwodJTdPugtaTMB = P_0.YBnBsBBQkmlNrgHwodJTdPugtaTMB;
			if (yBnBsBBQkmlNrgHwodJTdPugtaTMB < 0 || yBnBsBBQkmlNrgHwodJTdPugtaTMB >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[yBnBsBBQkmlNrgHwodJTdPugtaTMB].valueRaw : axes[yBnBsBBQkmlNrgHwodJTdPugtaTMB].value) : (P_2 ? axes[yBnBsBBQkmlNrgHwodJTdPugtaTMB].valueRawPrev : axes[yBnBsBBQkmlNrgHwodJTdPugtaTMB].valuePrev));
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

		internal virtual void SEyAZMbdhGlKzeNgHeBrBYOBfKUvc(ControllerMap P_0)
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
			base.jqLSrLTCddLEpzgJvILfPrtjvnhn(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				tdLKgiuKWlzkkJjXwztgjBdYXkPE(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].JtzYMpqdJGMyIjXIPHXXckWafklL);
				}
			}
		}

		internal virtual void uFAgOxRXJoveTqdzYwBRmLrqczcU(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.tdLKgiuKWlzkkJjXwztgjBdYXkPE(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.qpQzcYGEaMlrmdrWslIRXltfsMcp(P_0);
				}
			}
		}

		internal void MxvxpSUerYzdWaxdgYeBgpCcQmXG()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].RWCEZctGAZWeIhWIQMIAdNROmnEb._specialAxisType)
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

		internal virtual void PVFaXVptkwbndlExJKIXMMEteizl()
		{
			base.NQeVYgkqiwjcPfmLUdoKHfxQPBEL();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private int kvUbsdAUlXmYmHGMoaLwnEVldRfR(int P_0)
		{
			if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
			}
			return P_0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> jEtnkNjMwEFQsEPpVaBhkMmiRNdC()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> MeHAGhVwCDqgvabCeTIyLFeKiVMl()
		{
			return base.PollForAllElementsDown();
		}
	}
}

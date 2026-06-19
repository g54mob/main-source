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
		private sealed class jBYiVuFCUqAFyGpadOzSmzEASChKC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int dMkrVEzbhZqvjnkrooWuDNMRQEIl;

			private ControllerPollingInfo PXXJVjCKtNDiCARTySpdMJtoJRvx;

			private int mCsIikTLJQiEONIuezoZUdreueUM;

			public ControllerWithAxes DghugHpVbYNaGKINEQNiMgTxkrSp;

			private int SCqjsyhcxImvcRtQDHqoeqyAvlvEB;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return PXXJVjCKtNDiCARTySpdMJtoJRvx;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PXXJVjCKtNDiCARTySpdMJtoJRvx;
				}
			}

			[DebuggerHidden]
			public jBYiVuFCUqAFyGpadOzSmzEASChKC(int P_0)
			{
				dMkrVEzbhZqvjnkrooWuDNMRQEIl = P_0;
				mCsIikTLJQiEONIuezoZUdreueUM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				dMkrVEzbhZqvjnkrooWuDNMRQEIl = -2;
			}

			private bool MoveNext()
			{
				int num = dMkrVEzbhZqvjnkrooWuDNMRQEIl;
				ControllerWithAxes dghugHpVbYNaGKINEQNiMgTxkrSp = DghugHpVbYNaGKINEQNiMgTxkrSp;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					dMkrVEzbhZqvjnkrooWuDNMRQEIl = -1;
					goto IL_00a8;
				}
				dMkrVEzbhZqvjnkrooWuDNMRQEIl = -1;
				if (ReInput._id != dghugHpVbYNaGKINEQNiMgTxkrSp.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(dghugHpVbYNaGKINEQNiMgTxkrSp.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				dghugHpVbYNaGKINEQNiMgTxkrSp.UpdatePollingFrameTracking();
				dghugHpVbYNaGKINEQNiMgTxkrSp.AXVJDNdUbXEZZeZFqcJiiyqxZvtl();
				SCqjsyhcxImvcRtQDHqoeqyAvlvEB = 0;
				goto IL_00ba;
				IL_00ba:
				if (SCqjsyhcxImvcRtQDHqoeqyAvlvEB < dghugHpVbYNaGKINEQNiMgTxkrSp._axisCount)
				{
					if (dghugHpVbYNaGKINEQNiMgTxkrSp.IsPolledAxisActive(SCqjsyhcxImvcRtQDHqoeqyAvlvEB, out var pole, out var elementIdentifierId))
					{
						PXXJVjCKtNDiCARTySpdMJtoJRvx = new ControllerPollingInfo(true, -1, dghugHpVbYNaGKINEQNiMgTxkrSp.id, dghugHpVbYNaGKINEQNiMgTxkrSp._name, dghugHpVbYNaGKINEQNiMgTxkrSp._type, ControllerElementType.Axis, SCqjsyhcxImvcRtQDHqoeqyAvlvEB, pole, dghugHpVbYNaGKINEQNiMgTxkrSp.LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						dMkrVEzbhZqvjnkrooWuDNMRQEIl = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				SCqjsyhcxImvcRtQDHqoeqyAvlvEB++;
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
				jBYiVuFCUqAFyGpadOzSmzEASChKC jBYiVuFCUqAFyGpadOzSmzEASChKC2;
				if (dMkrVEzbhZqvjnkrooWuDNMRQEIl == -2 && mCsIikTLJQiEONIuezoZUdreueUM == Environment.CurrentManagedThreadId)
				{
					dMkrVEzbhZqvjnkrooWuDNMRQEIl = 0;
					jBYiVuFCUqAFyGpadOzSmzEASChKC2 = this;
				}
				else
				{
					jBYiVuFCUqAFyGpadOzSmzEASChKC2 = new jBYiVuFCUqAFyGpadOzSmzEASChKC(0);
					jBYiVuFCUqAFyGpadOzSmzEASChKC2.DghugHpVbYNaGKINEQNiMgTxkrSp = DghugHpVbYNaGKINEQNiMgTxkrSp;
				}
				return jBYiVuFCUqAFyGpadOzSmzEASChKC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class XuqNkezkoVGcCOgQitVdthRiESIX : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int JGxGehMcZCZwHbvTjLSyWgTMDGrs;

			private ControllerPollingInfo PJLFHpovlRyFDedIxhJlktInkcOIA;

			private int xcSZBsSNfhGzVcmzBCoNICoBXCqYA;

			public ControllerWithAxes bFqkWFeCrwbisLRDnyjutCEHAHQF;

			private IEnumerator<ControllerPollingInfo> YVptCIXGjraPcEbOFgnUiZubWagKA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return PJLFHpovlRyFDedIxhJlktInkcOIA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PJLFHpovlRyFDedIxhJlktInkcOIA;
				}
			}

			[DebuggerHidden]
			public XuqNkezkoVGcCOgQitVdthRiESIX(int P_0)
			{
				JGxGehMcZCZwHbvTjLSyWgTMDGrs = P_0;
				xcSZBsSNfhGzVcmzBCoNICoBXCqYA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (JGxGehMcZCZwHbvTjLSyWgTMDGrs)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						GQfBnmEONEQpmlutyECTHzBEjFURA();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						rAfQRoeIhTczTDoAlTDgJbXcVEbcA();
					}
					break;
				}
				YVptCIXGjraPcEbOFgnUiZubWagKA = null;
				JGxGehMcZCZwHbvTjLSyWgTMDGrs = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int jGxGehMcZCZwHbvTjLSyWgTMDGrs = JGxGehMcZCZwHbvTjLSyWgTMDGrs;
					ControllerWithAxes controllerWithAxes = bFqkWFeCrwbisLRDnyjutCEHAHQF;
					switch (jGxGehMcZCZwHbvTjLSyWgTMDGrs)
					{
					default:
						return false;
					case 0:
						JGxGehMcZCZwHbvTjLSyWgTMDGrs = -1;
						if (ReInput._id != controllerWithAxes.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
						{
							ReInput.CheckInitialized(controllerWithAxes.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
							return false;
						}
						YVptCIXGjraPcEbOFgnUiZubWagKA = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						JGxGehMcZCZwHbvTjLSyWgTMDGrs = -3;
						goto IL_0092;
					case 1:
						JGxGehMcZCZwHbvTjLSyWgTMDGrs = -3;
						goto IL_0092;
					case 2:
						{
							JGxGehMcZCZwHbvTjLSyWgTMDGrs = -4;
							break;
						}
						IL_0092:
						if (YVptCIXGjraPcEbOFgnUiZubWagKA.MoveNext())
						{
							ControllerPollingInfo current = YVptCIXGjraPcEbOFgnUiZubWagKA.Current;
							PJLFHpovlRyFDedIxhJlktInkcOIA = current;
							JGxGehMcZCZwHbvTjLSyWgTMDGrs = 1;
							return true;
						}
						GQfBnmEONEQpmlutyECTHzBEjFURA();
						YVptCIXGjraPcEbOFgnUiZubWagKA = null;
						YVptCIXGjraPcEbOFgnUiZubWagKA = controllerWithAxes.PollForAllAxes().GetEnumerator();
						JGxGehMcZCZwHbvTjLSyWgTMDGrs = -4;
						break;
					}
					if (YVptCIXGjraPcEbOFgnUiZubWagKA.MoveNext())
					{
						ControllerPollingInfo current2 = YVptCIXGjraPcEbOFgnUiZubWagKA.Current;
						PJLFHpovlRyFDedIxhJlktInkcOIA = current2;
						JGxGehMcZCZwHbvTjLSyWgTMDGrs = 2;
						return true;
					}
					rAfQRoeIhTczTDoAlTDgJbXcVEbcA();
					YVptCIXGjraPcEbOFgnUiZubWagKA = null;
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

			private void GQfBnmEONEQpmlutyECTHzBEjFURA()
			{
				JGxGehMcZCZwHbvTjLSyWgTMDGrs = -1;
				if (YVptCIXGjraPcEbOFgnUiZubWagKA != null)
				{
					YVptCIXGjraPcEbOFgnUiZubWagKA.Dispose();
				}
			}

			private void rAfQRoeIhTczTDoAlTDgJbXcVEbcA()
			{
				JGxGehMcZCZwHbvTjLSyWgTMDGrs = -1;
				if (YVptCIXGjraPcEbOFgnUiZubWagKA != null)
				{
					YVptCIXGjraPcEbOFgnUiZubWagKA.Dispose();
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
				XuqNkezkoVGcCOgQitVdthRiESIX xuqNkezkoVGcCOgQitVdthRiESIX;
				if (JGxGehMcZCZwHbvTjLSyWgTMDGrs == -2 && xcSZBsSNfhGzVcmzBCoNICoBXCqYA == Environment.CurrentManagedThreadId)
				{
					JGxGehMcZCZwHbvTjLSyWgTMDGrs = 0;
					xuqNkezkoVGcCOgQitVdthRiESIX = this;
				}
				else
				{
					xuqNkezkoVGcCOgQitVdthRiESIX = new XuqNkezkoVGcCOgQitVdthRiESIX(0);
					xuqNkezkoVGcCOgQitVdthRiESIX.bFqkWFeCrwbisLRDnyjutCEHAHQF = bFqkWFeCrwbisLRDnyjutCEHAHQF;
				}
				return xuqNkezkoVGcCOgQitVdthRiESIX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class PHMxIclryGeNlAaQUcTViAADHUOP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int JsracDxtceUuuctULAmVXueYkaIF;

			private ControllerPollingInfo uEaTrDEepBBdEyvcLRWSlBOXjcYN;

			private int cCVgziiWBWfaCgGmCSYTeMMCUJDgD;

			public ControllerWithAxes BTjnHSffCYDJyNlqLrOaAmjMkjKp;

			private IEnumerator<ControllerPollingInfo> GdRvNOucPrGmPsesxBNPrhucBSzQ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return uEaTrDEepBBdEyvcLRWSlBOXjcYN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uEaTrDEepBBdEyvcLRWSlBOXjcYN;
				}
			}

			[DebuggerHidden]
			public PHMxIclryGeNlAaQUcTViAADHUOP(int P_0)
			{
				JsracDxtceUuuctULAmVXueYkaIF = P_0;
				cCVgziiWBWfaCgGmCSYTeMMCUJDgD = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (JsracDxtceUuuctULAmVXueYkaIF)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						mRkVLqLJhAwOHSBuenCrcnKBqUph();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						zgZejPIpFLblNIgvPDbNlECgIwEfb();
					}
					break;
				}
				GdRvNOucPrGmPsesxBNPrhucBSzQ = null;
				JsracDxtceUuuctULAmVXueYkaIF = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int jsracDxtceUuuctULAmVXueYkaIF = JsracDxtceUuuctULAmVXueYkaIF;
					ControllerWithAxes bTjnHSffCYDJyNlqLrOaAmjMkjKp = BTjnHSffCYDJyNlqLrOaAmjMkjKp;
					switch (jsracDxtceUuuctULAmVXueYkaIF)
					{
					default:
						return false;
					case 0:
						JsracDxtceUuuctULAmVXueYkaIF = -1;
						if (ReInput._id != bTjnHSffCYDJyNlqLrOaAmjMkjKp.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
						{
							ReInput.CheckInitialized(bTjnHSffCYDJyNlqLrOaAmjMkjKp.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
							return false;
						}
						GdRvNOucPrGmPsesxBNPrhucBSzQ = ((Controller)bTjnHSffCYDJyNlqLrOaAmjMkjKp).PollForAllElementsDown().GetEnumerator();
						JsracDxtceUuuctULAmVXueYkaIF = -3;
						goto IL_0092;
					case 1:
						JsracDxtceUuuctULAmVXueYkaIF = -3;
						goto IL_0092;
					case 2:
						{
							JsracDxtceUuuctULAmVXueYkaIF = -4;
							break;
						}
						IL_0092:
						if (GdRvNOucPrGmPsesxBNPrhucBSzQ.MoveNext())
						{
							ControllerPollingInfo current = GdRvNOucPrGmPsesxBNPrhucBSzQ.Current;
							uEaTrDEepBBdEyvcLRWSlBOXjcYN = current;
							JsracDxtceUuuctULAmVXueYkaIF = 1;
							return true;
						}
						mRkVLqLJhAwOHSBuenCrcnKBqUph();
						GdRvNOucPrGmPsesxBNPrhucBSzQ = null;
						GdRvNOucPrGmPsesxBNPrhucBSzQ = bTjnHSffCYDJyNlqLrOaAmjMkjKp.PollForAllAxes().GetEnumerator();
						JsracDxtceUuuctULAmVXueYkaIF = -4;
						break;
					}
					if (GdRvNOucPrGmPsesxBNPrhucBSzQ.MoveNext())
					{
						ControllerPollingInfo current2 = GdRvNOucPrGmPsesxBNPrhucBSzQ.Current;
						uEaTrDEepBBdEyvcLRWSlBOXjcYN = current2;
						JsracDxtceUuuctULAmVXueYkaIF = 2;
						return true;
					}
					zgZejPIpFLblNIgvPDbNlECgIwEfb();
					GdRvNOucPrGmPsesxBNPrhucBSzQ = null;
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

			private void mRkVLqLJhAwOHSBuenCrcnKBqUph()
			{
				JsracDxtceUuuctULAmVXueYkaIF = -1;
				if (GdRvNOucPrGmPsesxBNPrhucBSzQ != null)
				{
					GdRvNOucPrGmPsesxBNPrhucBSzQ.Dispose();
				}
			}

			private void zgZejPIpFLblNIgvPDbNlECgIwEfb()
			{
				JsracDxtceUuuctULAmVXueYkaIF = -1;
				if (GdRvNOucPrGmPsesxBNPrhucBSzQ != null)
				{
					GdRvNOucPrGmPsesxBNPrhucBSzQ.Dispose();
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
				PHMxIclryGeNlAaQUcTViAADHUOP pHMxIclryGeNlAaQUcTViAADHUOP;
				if (JsracDxtceUuuctULAmVXueYkaIF == -2 && cCVgziiWBWfaCgGmCSYTeMMCUJDgD == Environment.CurrentManagedThreadId)
				{
					JsracDxtceUuuctULAmVXueYkaIF = 0;
					pHMxIclryGeNlAaQUcTViAADHUOP = this;
				}
				else
				{
					pHMxIclryGeNlAaQUcTViAADHUOP = new PHMxIclryGeNlAaQUcTViAADHUOP(0);
					pHMxIclryGeNlAaQUcTViAADHUOP.BTjnHSffCYDJyNlqLrOaAmjMkjKp = BTjnHSffCYDJyNlqLrOaAmjMkjKp;
				}
				return pHMxIclryGeNlAaQUcTViAADHUOP;
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

		private float[] PRsxAYbBAFZScBKLDrGdSFcqkzoM;

		private uint UXSRUYQXCWZdaHVveNSidYvnZoxg = uint.MaxValue;

		private TimerAbs SJZhJmzNMAFgjYjWywrbfRevRDYu;

		private float[] cFJjPcNZxrqjhkmCPUWcVLuoWYoI;

		private Func<int, int> QlszogozYKxkfrFjKIxFYjiHducn;

		public int axisCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return LJmpCFrENABMhmUxmGaTconkDyoGA.axisElementIdentifiers_readOnly;
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
				CModZicjRGTPMTvJlQVppzsGqidWA(axes[i]);
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
					byDDQTFCPCzrcWthyknzdKcxrYzZ(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			tQVEMduuOUsMbudUFnZVfFlxJdUl();
			QlszogozYKxkfrFjKIxFYjiHducn = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			if (LJmpCFrENABMhmUxmGaTconkDyoGA == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return -1;
			}
			return LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0f;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0f;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0f;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0f;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int axisIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
			}
			UpdatePollingFrameTracking();
			AXVJDNdUbXEZZeZFqcJiiyqxZvtl();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
		}

		[IteratorStateMachine(typeof(XuqNkezkoVGcCOgQitVdthRiESIX))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new XuqNkezkoVGcCOgQitVdthRiESIX(-2)
			{
				bFqkWFeCrwbisLRDnyjutCEHAHQF = this
			};
		}

		[IteratorStateMachine(typeof(PHMxIclryGeNlAaQUcTViAADHUOP))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new PHMxIclryGeNlAaQUcTViAADHUOP(-2)
			{
				BTjnHSffCYDJyNlqLrOaAmjMkjKp = this
			};
		}

		[IteratorStateMachine(typeof(jBYiVuFCUqAFyGpadOzSmzEASChKC))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new jBYiVuFCUqAFyGpadOzSmzEASChKC(-2)
			{
				DghugHpVbYNaGKINEQNiMgTxkrSp = this
			};
		}

		private void AXVJDNdUbXEZZeZFqcJiiyqxZvtl()
		{
			if (PRsxAYbBAFZScBKLDrGdSFcqkzoM == null)
			{
				PRsxAYbBAFZScBKLDrGdSFcqkzoM = new float[_axisCount];
			}
			if (DXjiZuzjDrBcOipWkembjJvVpKl != UXSRUYQXCWZdaHVveNSidYvnZoxg)
			{
				UXSRUYQXCWZdaHVveNSidYvnZoxg = DXjiZuzjDrBcOipWkembjJvVpKl;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					PRsxAYbBAFZScBKLDrGdSFcqkzoM[i] = axes[i].NVhFHgICrpXZGlgedhWyyrseplHVA(currentUpdateLoop, _calibrationMap.GetAxis(i));
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
				value = axes[index].NVhFHgICrpXZGlgedhWyyrseplHVA(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - PRsxAYbBAFZScBKLDrGdSFcqkzoM[index];
				break;
			case AxisCoordinateMode.Relative:
				if (cFJjPcNZxrqjhkmCPUWcVLuoWYoI == null)
				{
					cFJjPcNZxrqjhkmCPUWcVLuoWYoI = new float[_axisCount];
				}
				if (SJZhJmzNMAFgjYjWywrbfRevRDYu == null)
				{
					SJZhJmzNMAFgjYjWywrbfRevRDYu = new TimerAbs(1.0);
				}
				if (SJZhJmzNMAFgjYjWywrbfRevRDYu.Update() || !SJZhJmzNMAFgjYjWywrbfRevRDYu.running)
				{
					SJZhJmzNMAFgjYjWywrbfRevRDYu.Start();
					Array.Clear(cFJjPcNZxrqjhkmCPUWcVLuoWYoI, 0, cFJjPcNZxrqjhkmCPUWcVLuoWYoI.Length);
				}
				cFJjPcNZxrqjhkmCPUWcVLuoWYoI[index] += axes[index].valueRaw;
				value = cFJjPcNZxrqjhkmCPUWcVLuoWYoI[index];
				break;
			default:
				throw new NotImplementedException();
			}
			if (MathTools.Abs(value) <= axes[index].SmvTuJjdsvGiWKjCocbBJtqzCOoGb)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = LJmpCFrENABMhmUxmGaTconkDyoGA.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void OJfGzCVGKpDcleZnYjZrjqAkLxdVA(UpdateLoopType P_0)
		{
			base.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !zfVdfqKDuqZKjafBdqgdinjRQNeGb.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].wPsCzZJFDWpCmNuMISEngmqiBGZT(P_0);
				if (!flag || flag4 || (flag3 && !zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].RiSdiqsoaiDGNHSwAaDhIdqgAhWOc();
					continue;
				}
				axes[i].valueRaw = zfVdfqKDuqZKjafBdqgdinjRQNeGb.axisValues[i];
				if (flag2)
				{
					axes[i].WiuIRREiNdjLluouzVONaTtkKWRc(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].DhAxZRUSVKOYdBFkCGkUGAEAxrbO();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].eUCoDNkXPCigzYPoWlCwthsUhPrF();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].erykXwnhCjHGcCSHwCPpvElCcdRl();
			}
		}

		internal bool iSNbyrbruIlpsNkmACDWdwPAxUNOb(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int xrZnVueTRmSKYHvJBgyRGORsqtGX = P_0.xrZnVueTRmSKYHvJBgyRGORsqtGX;
			if (xrZnVueTRmSKYHvJBgyRGORsqtGX < 0 || xrZnVueTRmSKYHvJBgyRGORsqtGX >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[xrZnVueTRmSKYHvJBgyRGORsqtGX].valueRaw : axes[xrZnVueTRmSKYHvJBgyRGORsqtGX].value) : (P_2 ? axes[xrZnVueTRmSKYHvJBgyRGORsqtGX].valueRawPrev : axes[xrZnVueTRmSKYHvJBgyRGORsqtGX].valuePrev));
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

		internal virtual void ruMosfRvIKQJGHrNTvyfTitgpVZs(ControllerMap P_0)
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
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				base.YdxptuxNGpUaQtWkYqBlEXOcgbkk(P_0);
				IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
				for (int i = 0; i < axisMaps.Count; i++)
				{
					MLdcpPOYjvtoDJPENGusyemNCWAq(P_0, axisMaps[i]);
				}
				for (int num = axisMaps.Count - 1; num >= 0; num--)
				{
					if (axisMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(axisMaps[num].oETQtUYpoAHvrDdxockLYpfjFkywA);
					}
				}
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		internal virtual void PsqBhUafowFlmBiQeryTjlKFryvmb(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.MLdcpPOYjvtoDJPENGusyemNCWAq(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.PKuPVtkPJEWiXrQtJpzVObMiLTlx(P_0);
				}
			}
		}

		internal void tQVEMduuOUsMbudUFnZVfFlxJdUl()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].ebyrXyRCdWERLtGljixMusqSBzocA._specialAxisType)
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

		internal virtual void cXfFDiJKTugPYjySyrZDVWvcbgyj()
		{
			base.scCwpLEHFiuvitLgzEfOOpCTYgPj();
			if (SJZhJmzNMAFgjYjWywrbfRevRDYu != null)
			{
				SJZhJmzNMAFgjYjWywrbfRevRDYu.Clear();
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
		private int taIDoyRbxPwGPFaSwDFCPITFiBlL(int P_0)
		{
			if (base.extension is IAxisCalibrationIndexMap axisCalibrationIndexMap)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(P_0);
			}
			return P_0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> KnVbGcJqpMdOZATyoKBrrAfpnMus()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> jkhczIdoPPqfQcVlRfwmIsDTudTV()
		{
			return base.PollForAllElementsDown();
		}
	}
}

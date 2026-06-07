using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public jBYiVuFCUqAFyGpadOzSmzEASChKC(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public XuqNkezkoVGcCOgQitVdthRiESIX(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void GQfBnmEONEQpmlutyECTHzBEjFURA()
			{
			}

			private void rAfQRoeIhTczTDoAlTDgJbXcVEbcA()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return default(ControllerPollingInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public PHMxIclryGeNlAaQUcTViAADHUOP(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void mRkVLqLJhAwOHSBuenCrcnKBqUph()
			{
			}

			private void zgZejPIpFLblNIgvPDbNlECgIwEfb()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

		private uint UXSRUYQXCWZdaHVveNSidYvnZoxg;

		private TimerAbs SJZhJmzNMAFgjYjWywrbfRevRDYu;

		private float[] cFJjPcNZxrqjhkmCPUWcVLuoWYoI;

		private Func<int, int> QlszogozYKxkfrFjKIxFYjiHducn;

		public int axisCount => 0;

		public int axis2DCount => 0;

		public IList<Axis> Axes => null;

		public IList<Axis2D> Axes2D => null;

		public CalibrationMap calibrationMap => null;

		public IList<ControllerElementIdentifier> AxisElementIdentifiers => null;

		internal ControllerWithAxes(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, int P_8, bool[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, null, null, null, null)
		{
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			return null;
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			return 0;
		}

		public float GetAxis(int index)
		{
			return 0f;
		}

		public float GetAxisPrev(int index)
		{
			return 0f;
		}

		public float GetAxisRaw(int index)
		{
			return 0f;
		}

		public float GetAxisRawPrev(int index)
		{
			return 0f;
		}

		public double GetAxisTimeActive(int index)
		{
			return 0.0;
		}

		public double GetAxisTimeInactive(int index)
		{
			return 0.0;
		}

		public double GetAxisLastTimeActive(int index)
		{
			return 0.0;
		}

		public double GetAxisLastTimeInactive(int index)
		{
			return 0.0;
		}

		public double GetAxisRawTimeActive(int index)
		{
			return 0.0;
		}

		public double GetAxisRawTimeInactive(int index)
		{
			return 0.0;
		}

		public double GetAxisRawLastTimeActive(int index)
		{
			return 0.0;
		}

		public double GetAxisRawLastTimeInactive(int index)
		{
			return 0.0;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			return 0f;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			return 0f;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			return 0f;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			return 0f;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			return 0.0;
		}

		public Vector2 GetAxis2D(int index)
		{
			return default(Vector2);
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			return default(Vector2);
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			return default(Vector2);
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			return default(Vector2);
		}

		public override double GetLastTimeActive()
		{
			return 0.0;
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			return 0.0;
		}

		public override double GetLastTimeAnyElementChanged()
		{
			return 0.0;
		}

		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			return 0.0;
		}

		public double GetLastTimeAnyAxisActive()
		{
			return 0.0;
		}

		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			return 0.0;
		}

		public double GetLastTimeAnyAxisChanged()
		{
			return 0.0;
		}

		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			return 0.0;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			return default(ControllerPollingInfo);
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			return default(ControllerPollingInfo);
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			return default(ControllerPollingInfo);
		}

		[IteratorStateMachine(typeof(XuqNkezkoVGcCOgQitVdthRiESIX))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return null;
		}

		[IteratorStateMachine(typeof(PHMxIclryGeNlAaQUcTViAADHUOP))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return null;
		}

		[IteratorStateMachine(typeof(jBYiVuFCUqAFyGpadOzSmzEASChKC))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return null;
		}

		private void AXVJDNdUbXEZZeZFqcJiiyqxZvtl()
		{
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = default(Pole);
			elementIdentifierId = default(int);
			return false;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			return false;
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			return false;
		}

		internal override void KvONimPsnvghlMkZzyXoBEjvJCHX(UpdateLoopType P_0)
		{
		}

		internal bool iSNbyrbruIlpsNkmACDWdwPAxUNOb(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = default(float);
			return false;
		}

		internal override void YdxptuxNGpUaQtWkYqBlEXOcgbkk(ControllerMap P_0)
		{
		}

		internal override void MLdcpPOYjvtoDJPENGusyemNCWAq(ControllerMap P_0, ActionElementMap P_1)
		{
		}

		internal void tQVEMduuOUsMbudUFnZVfFlxJdUl()
		{
		}

		internal override void scCwpLEHFiuvitLgzEfOOpCTYgPj()
		{
		}

		[CompilerGenerated]
		private int taIDoyRbxPwGPFaSwDFCPITFiBlL(int P_0)
		{
			return 0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> KnVbGcJqpMdOZATyoKBrrAfpnMus()
		{
			return null;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> jkhczIdoPPqfQcVlRfwmIsDTudTV()
		{
			return null;
		}
	}
}

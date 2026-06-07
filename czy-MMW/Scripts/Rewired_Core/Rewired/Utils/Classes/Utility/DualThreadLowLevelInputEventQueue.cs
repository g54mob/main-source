using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class TaCfqctHobDiaqwrpNMaaEvXEuFi : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			LowLevelInputEvent INewEventWrapper.Event
			{
				get
				{
					return item;
				}
				set
				{
					item = value;
				}
			}

			public TaCfqctHobDiaqwrpNMaaEvXEuFi(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue oGiZAIRGGYCheCTkWgcSdEpkqvDRb;

		private readonly LowLevelInputEventQueue OyWBclCatJdbbGDbSSWLOnTmlJXJ;

		private readonly object exKKoGWfXOfnPcKzclgVHTjrZpWV;

		private uint AhDtdXsFRvzAegmXmAjIAPNrvegN;

		private bool UQspvOjRgyrlJrPnHoXadatDjQGG;

		private int JprAwsLqROqXCeyUbUOrVqGBmqXh;

		private int XqkOXIhEqeFsnYPeezLUHnjSxCIL;

		private TaCfqctHobDiaqwrpNMaaEvXEuFi FBLFhwgNsxSZuEaTMJZIpuPMjjUj;

		public LowLevelInputEvent currentEvent;

		private bool fyFjOrdoJtiJpgJIDygekdmVbpvgA;

		public uint lastProcessedEventId => AhDtdXsFRvzAegmXmAjIAPNrvegN;

		public int count
		{
			get
			{
				lock (exKKoGWfXOfnPcKzclgVHTjrZpWV)
				{
					return oGiZAIRGGYCheCTkWgcSdEpkqvDRb.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			oGiZAIRGGYCheCTkWgcSdEpkqvDRb = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			OyWBclCatJdbbGDbSSWLOnTmlJXJ = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			exKKoGWfXOfnPcKzclgVHTjrZpWV = new object();
			FBLFhwgNsxSZuEaTMJZIpuPMjjUj = new TaCfqctHobDiaqwrpNMaaEvXEuFi(exKKoGWfXOfnPcKzclgVHTjrZpWV);
		}

		public INewEventWrapper T_CreateEvent()
		{
			FBLFhwgNsxSZuEaTMJZIpuPMjjUj.Lock();
			FBLFhwgNsxSZuEaTMJZIpuPMjjUj.item = OyWBclCatJdbbGDbSSWLOnTmlJXJ.CreateEvent();
			return FBLFhwgNsxSZuEaTMJZIpuPMjjUj;
		}

		public void Update()
		{
			lock (exKKoGWfXOfnPcKzclgVHTjrZpWV)
			{
				oGiZAIRGGYCheCTkWgcSdEpkqvDRb.CopyNewEventsFrom(OyWBclCatJdbbGDbSSWLOnTmlJXJ);
			}
		}

		public void Clear()
		{
			lock (exKKoGWfXOfnPcKzclgVHTjrZpWV)
			{
				StopProcessingEvents();
				oGiZAIRGGYCheCTkWgcSdEpkqvDRb.Clear();
				OyWBclCatJdbbGDbSSWLOnTmlJXJ.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (XqkOXIhEqeFsnYPeezLUHnjSxCIL == 0)
			{
				Update();
				int num = oGiZAIRGGYCheCTkWgcSdEpkqvDRb.FindNextIndex(AhDtdXsFRvzAegmXmAjIAPNrvegN);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				XqkOXIhEqeFsnYPeezLUHnjSxCIL = num;
				UQspvOjRgyrlJrPnHoXadatDjQGG = true;
				JprAwsLqROqXCeyUbUOrVqGBmqXh = oGiZAIRGGYCheCTkWgcSdEpkqvDRb.Count;
			}
			if (XqkOXIhEqeFsnYPeezLUHnjSxCIL >= JprAwsLqROqXCeyUbUOrVqGBmqXh)
			{
				currentEvent = default(LowLevelInputEvent);
				UQspvOjRgyrlJrPnHoXadatDjQGG = false;
				XqkOXIhEqeFsnYPeezLUHnjSxCIL = 0;
				return false;
			}
			if (oGiZAIRGGYCheCTkWgcSdEpkqvDRb.TryGetNext(XqkOXIhEqeFsnYPeezLUHnjSxCIL, out currentEvent))
			{
				AhDtdXsFRvzAegmXmAjIAPNrvegN = currentEvent.GetId();
				XqkOXIhEqeFsnYPeezLUHnjSxCIL++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			UQspvOjRgyrlJrPnHoXadatDjQGG = false;
			XqkOXIhEqeFsnYPeezLUHnjSxCIL = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			UQspvOjRgyrlJrPnHoXadatDjQGG = false;
			XqkOXIhEqeFsnYPeezLUHnjSxCIL = 0;
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other == this)
			{
				return;
			}
			lock (exKKoGWfXOfnPcKzclgVHTjrZpWV)
			{
				lock (other.exKKoGWfXOfnPcKzclgVHTjrZpWV)
				{
					oGiZAIRGGYCheCTkWgcSdEpkqvDRb.CopyAllFrom(other.oGiZAIRGGYCheCTkWgcSdEpkqvDRb);
					OyWBclCatJdbbGDbSSWLOnTmlJXJ.CopyAllFrom(other.OyWBclCatJdbbGDbSSWLOnTmlJXJ);
					AhDtdXsFRvzAegmXmAjIAPNrvegN = other.AhDtdXsFRvzAegmXmAjIAPNrvegN;
					UQspvOjRgyrlJrPnHoXadatDjQGG = other.UQspvOjRgyrlJrPnHoXadatDjQGG;
					JprAwsLqROqXCeyUbUOrVqGBmqXh = other.JprAwsLqROqXCeyUbUOrVqGBmqXh;
					XqkOXIhEqeFsnYPeezLUHnjSxCIL = other.XqkOXIhEqeFsnYPeezLUHnjSxCIL;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (fyFjOrdoJtiJpgJIDygekdmVbpvgA)
			{
				return;
			}
			if (disposing)
			{
				lock (exKKoGWfXOfnPcKzclgVHTjrZpWV)
				{
					oGiZAIRGGYCheCTkWgcSdEpkqvDRb.Dispose();
					OyWBclCatJdbbGDbSSWLOnTmlJXJ.Dispose();
				}
			}
			fyFjOrdoJtiJpgJIDygekdmVbpvgA = true;
		}
	}
}

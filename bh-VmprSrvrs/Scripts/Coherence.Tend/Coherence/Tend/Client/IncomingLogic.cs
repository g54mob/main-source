using Coherence.Brook;
using Coherence.Log;
using Coherence.Tend.Models;

namespace Coherence.Tend.Client
{
	public class IncomingLogic : IIncomingLogic
	{
		private SequenceId lastReceivedToUs;

		private uint receiveMask;

		private Logger logger;

		public SequenceId LastReceivedToUs => default(SequenceId);

		public ReceiveMask ReceiveMask => default(ReceiveMask);

		public IncomingLogic(Logger logger)
		{
		}

		public bool ReceivedToUs(SequenceId nextId)
		{
			return false;
		}

		private void Append(bool bit)
		{
		}
	}
}

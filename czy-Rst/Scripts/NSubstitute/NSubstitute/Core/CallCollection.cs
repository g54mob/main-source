using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class CallCollection : ICallCollection
	{
		internal interface IReceivedCallEntry
		{
			ICall? Call { get; }

			[MemberNotNullWhen(false, "Call")]
			bool IsSkipped
			{
				[MemberNotNullWhen(false, "Call")]
				get;
			}

			void Skip();

			bool TryTakeEntryOwnership();
		}

		private class ReceivedCallEntry : IReceivedCallEntry
		{
			public ICall? Call { get; private set; }

			[MemberNotNullWhen(false, "Call")]
			public bool IsSkipped
			{
				[MemberNotNullWhen(false, "Call")]
				get
				{
					return Call == null;
				}
			}

			public ReceivedCallEntry(ICall call)
			{
				Call = call;
				base._002Ector();
			}

			public void Skip()
			{
				Call = null;
			}

			public bool TryTakeEntryOwnership()
			{
				throw new SubstituteInternalException("Ownership is never expected to be obtained for this entry.");
			}
		}

		private ConcurrentQueue<IReceivedCallEntry> _callEntries = new ConcurrentQueue<IReceivedCallEntry>();

		public void Add(ICall call)
		{
			IReceivedCallEntry item = ((!(call is IReceivedCallEntry receivedCallEntry) || !receivedCallEntry.TryTakeEntryOwnership()) ? new ReceivedCallEntry(call) : receivedCallEntry);
			_callEntries.Enqueue(item);
		}

		public void Delete(ICall call)
		{
			(_callEntries.FirstOrDefault((IReceivedCallEntry e) => !e.IsSkipped && call.Equals(e.Call)) ?? throw new SubstituteInternalException("CallCollection.Delete - collection doesn't contain the call")).Skip();
		}

		public IEnumerable<ICall> AllCalls()
		{
			return (from e in _callEntries
				where !e.IsSkipped
				select e.Call).ToArray();
		}

		public void Clear()
		{
			_callEntries = new ConcurrentQueue<IReceivedCallEntry>();
		}
	}
}

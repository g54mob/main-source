using System.Collections.Generic;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Execution
{
	internal class CyclicReferenceDetector : ICloneable2
	{
		private HashSet<ObjectReference> observedReferences = new HashSet<ObjectReference>();

		public bool IsCyclicReference(ObjectReference reference)
		{
			bool result = false;
			if (reference.CompareByMembers)
			{
				result = !observedReferences.Add(reference);
			}
			return result;
		}

		public object Clone()
		{
			return new CyclicReferenceDetector
			{
				observedReferences = new HashSet<ObjectReference>(observedReferences)
			};
		}
	}
}

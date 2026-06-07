using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class Sequence : Object
	{
		private class SequenceDivertToResolve
		{
			public Ink.Runtime.Divert divert;

			public Ink.Runtime.Object targetContent;
		}

		public List<Object> sequenceElements;

		public SequenceType sequenceType;

		private List<SequenceDivertToResolve> _sequenceDivertsToResove;

		public Sequence(List<ContentList> elementContentLists, SequenceType sequenceType)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		private void AddDivertToResolve(Ink.Runtime.Divert divert, Ink.Runtime.Object targetContent)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}

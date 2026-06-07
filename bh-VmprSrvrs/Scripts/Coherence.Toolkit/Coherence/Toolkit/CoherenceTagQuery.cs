using UnityEngine;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Queries/Coherence Tag Query")]
	[DefaultExecutionOrder(900)]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/components/coherence-tag-query")]
	public sealed class CoherenceTagQuery : CoherenceQuery
	{
		[CoherenceTag]
		public string coherenceTag;

		private string lastTag;

		private bool tagIsSet;

		protected override bool NeedsUpdate => false;

		private CoherenceTagQuery()
		{
		}

		protected override void CreateQuery()
		{
		}

		private void CreateQueryImpl()
		{
		}

		protected override void UpdateQuery(bool queryActive = true)
		{
		}
	}
}

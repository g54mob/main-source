using UnityEngine;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Queries/Coherence Global Query")]
	[DefaultExecutionOrder(900)]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/components/coherenceglobalquery")]
	public sealed class CoherenceGlobalQuery : CoherenceQuery
	{
		private bool createdEntityID;

		protected override bool NeedsUpdate => false;

		private CoherenceGlobalQuery()
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

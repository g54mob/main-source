using UnityEngine;

namespace LVA.Puppeteers
{
	public abstract class PuppeteerCoreReferences : qd
	{
		[field: SerializeField]
		public Transform Root { get; private set; }

		[field: SerializeField]
		public Transform COM { get; private set; }
	}
}

using Coherence.Toolkit;
using UnityEngine;

namespace VampireSurvivors
{
	[DefaultExecutionOrder(-10000000)]
	public class DummyBridgeActivator : MonoBehaviour
	{
		[SerializeField]
		private CoherenceBridge _bridge;

		[SerializeField]
		private CoherenceLiveQuery _liveQuery;

		private void Awake()
		{
		}
	}
}

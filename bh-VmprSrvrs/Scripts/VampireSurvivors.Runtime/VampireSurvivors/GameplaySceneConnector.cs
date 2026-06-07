using Coherence.Toolkit;
using UnityEngine;

namespace VampireSurvivors
{
	[DefaultExecutionOrder(-100000)]
	public class GameplaySceneConnector : MonoBehaviour
	{
		[SerializeField]
		private CoherenceSyncConfig _onlineStageManager;

		[SerializeField]
		private CoherenceSyncConfig _hostPlayerOptions;
	}
}

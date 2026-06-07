using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Races
{
	public class RaceCheckpointDataScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The position/orientation to restart at when respawning at this checkpoint")]
		private Transform _restartPosition;

		public Transform RestartPosition => _restartPosition;
	}
}

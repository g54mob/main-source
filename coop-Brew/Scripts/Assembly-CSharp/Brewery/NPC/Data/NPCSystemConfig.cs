using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "NPC_SystemConfig", menuName = "Brewery/NPC/System Config", order = 130)]
	public class NPCSystemConfig : ScriptableObject
	{
		[Header("Profiles")]
		[SerializeField]
		private NPCRoster roster;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject walkingNpcPrefab;

		[SerializeField]
		private GameObject drivingNpcPrefab;

		[Header("Timing")]
		[SerializeField]
		private float spawnTickSeconds;

		[SerializeField]
		private int maxActiveNpcs;

		public NPCRoster Roster => null;

		public GameObject WalkingNpcPrefab => null;

		public GameObject DrivingNpcPrefab => null;

		public float SpawnTickSeconds => 0f;

		public int MaxActiveNpcs => 0;
	}
}

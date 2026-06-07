using UnityEngine;

namespace EpicToonFX
{
	public class ETFXFireProjectile : MonoBehaviour
	{
		[SerializeField]
		public GameObject[] projectiles;

		[Header("Missile spawns at attached game object")]
		public Transform spawnPosition;

		[HideInInspector]
		public int currentProjectile;

		public float speed;

		private ETFXButtonScript selectedProjectileButton;

		private RaycastHit hit;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void nextEffect()
		{
		}

		public void previousEffect()
		{
		}

		public void AdjustSpeed(float newSpeed)
		{
		}
	}
}

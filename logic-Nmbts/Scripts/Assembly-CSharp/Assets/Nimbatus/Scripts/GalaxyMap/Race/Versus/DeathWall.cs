using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus
{
	public class DeathWall : MonoBehaviour
	{
		public RaceSpline MasterSpline;

		public BoxCollider Collider;

		public LineRenderer LineRenderer;

		public float PositionAlongSpline;

		private DeathWallManager _manager;

		public void Init(DeathWallManager manager)
		{
			_manager = manager;
		}

		public void OnTriggerEnter(Collider other)
		{
			if ((int)_manager.KillLayers == ((int)_manager.KillLayers | (1 << other.gameObject.layer)))
			{
				other.gameObject.SendMessage("TakeDamage", new DamageInformation(2.1474836E+09f, EDamageReason.Environment), SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}

using UnityEngine;

namespace Enemy
{
	public class EnemyWaterColliderLogic : MonoBehaviour
	{
		[SerializeField]
		private GameObject _flySoundObject;

		[SerializeField]
		private ParticleSystem _fireParticles;

		[SerializeField]
		private AudioSource _waterExplosion;

		[SerializeField]
		private AudioSource _distantExplosion;

		[SerializeField]
		private LayerMask _groundLayerMask;

		private void OnCollisionEnter(Collision collision)
		{
			if (IsLayerInMask(collision.gameObject.layer, _groundLayerMask))
			{
				_flySoundObject.SetActive(value: false);
				_fireParticles.Stop();
				_waterExplosion.Play();
				_distantExplosion.Play();
			}
		}

		private bool IsLayerInMask(int layer, LayerMask layerMask)
		{
			return (layerMask.value & (1 << layer)) != 0;
		}
	}
}

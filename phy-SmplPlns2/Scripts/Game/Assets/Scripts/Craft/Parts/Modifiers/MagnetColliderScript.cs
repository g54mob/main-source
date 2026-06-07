using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class MagnetColliderScript : MonoBehaviour, ICollisionIgnoreConfiguration
	{
		private MagnetScript _magnet;

		public bool Enabled => false;

		public void Initialize(MagnetScript magnet)
		{
			_magnet = magnet;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (!other.isTrigger)
			{
				_magnet.OnColliderEnterMagneticField(other);
			}
		}
	}
}

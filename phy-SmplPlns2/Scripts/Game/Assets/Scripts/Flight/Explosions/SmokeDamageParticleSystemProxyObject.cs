using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class SmokeDamageParticleSystemProxyObject : MonoBehaviour
	{
		public SmokeDamageParticleSystemPosition Position { get; private set; }

		public SmokeDamageParticleSystem System { get; private set; }

		protected SmokeDamageParticleSystemProxyObject()
		{
		}

		public static SmokeDamageParticleSystemProxyObject Create(SmokeDamageParticleSystem system, SmokeDamageParticleSystemPosition position)
		{
			SmokeDamageParticleSystemProxyObject smokeDamageParticleSystemProxyObject = new GameObject("SmokeDamageProxy").AddComponent<SmokeDamageParticleSystemProxyObject>();
			Transform obj = smokeDamageParticleSystemProxyObject.gameObject.transform;
			obj.parent = system.gameObject.transform;
			obj.localPosition = position.Position;
			smokeDamageParticleSystemProxyObject.System = system;
			smokeDamageParticleSystemProxyObject.Position = position;
			return smokeDamageParticleSystemProxyObject;
		}

		protected virtual void Update()
		{
			GameWorld instance = GameWorld.Instance;
			if (instance.FloatingOriginSeaLevel.HasValue)
			{
				float num = instance.FloatingOriginSeaLevel.Value - 1f;
				if (base.transform.position.y <= num)
				{
					Position.Enabled = false;
					System.UpdateSystem();
				}
			}
		}
	}
}

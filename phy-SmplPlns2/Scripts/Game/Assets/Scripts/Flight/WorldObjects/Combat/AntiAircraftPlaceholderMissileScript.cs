using Assets.Scripts.Flight.Combat;
using FishNet;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class AntiAircraftPlaceholderMissileScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _prefab;

		public AntiAircraftMissileScript Fire(TrackedTarget target, Transform orphanedParticleEffectsParent, bool deactivatePlaceholder = true)
		{
			GameObject gameObject = Object.Instantiate(_prefab);
			AntiAircraftMissileScript component = gameObject.GetComponent<AntiAircraftMissileScript>();
			component.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			component.Fire(target, orphanedParticleEffectsParent);
			InstanceFinder.ServerManager.Spawn(gameObject, InstanceFinder.ClientManager.Connection);
			if (deactivatePlaceholder)
			{
				base.gameObject.SetActive(value: false);
			}
			return component;
		}
	}
}

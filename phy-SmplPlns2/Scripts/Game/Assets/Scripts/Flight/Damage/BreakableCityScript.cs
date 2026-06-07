using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class BreakableCityScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _particleSystemPrefab;

		protected virtual void Start()
		{
			AttachScriptToBuildings(base.transform);
		}

		private void AttachScriptToBuildings(Transform t)
		{
			if (t.gameObject.name.StartsWith("building_"))
			{
				BreakableBuildingScript breakableBuildingScript = t.gameObject.AddComponent<BreakableBuildingScript>();
				breakableBuildingScript.DestructionParticleSystemPrefab = _particleSystemPrefab;
				Collider[] componentsInChildren = breakableBuildingScript.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.AddComponent<BreakableObjectDamageHandlerScript>();
				}
				return;
			}
			foreach (Transform item in t)
			{
				AttachScriptToBuildings(item);
			}
		}
	}
}

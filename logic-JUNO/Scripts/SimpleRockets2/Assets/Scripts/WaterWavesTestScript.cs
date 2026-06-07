using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts
{
	public class WaterWavesTestScript : MonoBehaviour
	{
		[SerializeField]
		private CraftScript _craftScript;

		private GameObject _marker;

		public void Awake()
		{
			_marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			_marker.GetComponent<Collider>().enabled = false;
		}

		public void Update()
		{
		}
	}
}

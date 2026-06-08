using UnityEngine;

namespace Kitchen
{
	public class TestSnapshot : MonoBehaviour
	{
		public GameObject Target;

		public GameObject Display;

		private void Start()
		{
			Display.GetComponent<MeshRenderer>().material.SetTexture("_Image", PrefabSnapshot.GetSnapshot(Target));
		}
	}
}

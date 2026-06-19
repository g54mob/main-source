using UnityEngine;

namespace WorldEnvironment.FunctionalObjects
{
	public class IndicatorLamp : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _mesh;

		private void Start()
		{
			_mesh.material.DisableKeyword("_EMISSION");
		}

		public void EnableLamp()
		{
			_mesh.material.EnableKeyword("_EMISSION");
		}

		public void DisableLamp()
		{
			_mesh.material.DisableKeyword("_EMISSION");
		}
	}
}

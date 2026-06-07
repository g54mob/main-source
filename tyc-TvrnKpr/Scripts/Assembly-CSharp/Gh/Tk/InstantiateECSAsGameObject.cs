using UnityEngine;

namespace Gh.Tk
{
	public class InstantiateECSAsGameObject : MonoBehaviour
	{
		[SerializeField]
		private string _id;

		private GameObject _instantiatedObject;

		[SerializeField]
		private string _swatchMaterialIdOverride;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void CleanUp()
		{
		}
	}
}

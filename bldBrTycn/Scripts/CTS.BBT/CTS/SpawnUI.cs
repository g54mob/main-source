using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-10000)]
	public class SpawnUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject _prefab;

		private void Awake()
		{
			Object.Instantiate(_prefab);
		}
	}
}

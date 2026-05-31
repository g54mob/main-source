using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CameraSpawner : MonoBehaviour
	{
		[SerializeField]
		private MainCamera _cameraPrefab;

		private void Awake()
		{
			if (!_cameraPrefab || MonoSingleton<MainCamera>.InstanceExists())
			{
				MonoSingleton<MainCamera>.Instance.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
				Object.Destroy(base.gameObject);
			}
			else
			{
				Object.Instantiate(_cameraPrefab, base.transform.position, base.transform.rotation);
				Object.Destroy(base.gameObject);
			}
		}
	}
}

using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Sound
{
	public class AudioListenerManager : MonoBehaviour
	{
		[SerializeField]
		private float yOffset = 0.2f;

		private void OnCameraUpdate()
		{
			base.transform.position = new Vector3(MonoSingleton<RtsCamera>.Instance.CurrentPosition.x, MonoSingleton<RtsCamera>.Instance.transform.position.y + yOffset, MonoSingleton<RtsCamera>.Instance.CurrentPosition.z);
			Quaternion rotation = MonoSingleton<RtsCamera>.Instance.transform.rotation;
			base.transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
		}

		private void Start()
		{
			MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent += OnCameraUpdate;
		}
	}
}

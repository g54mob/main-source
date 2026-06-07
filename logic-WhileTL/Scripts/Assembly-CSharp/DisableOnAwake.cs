using UnityEngine;

public class DisableOnAwake : MonoBehaviour
{
	private void Update()
	{
		if (base.gameObject.GetComponent<PlatformDependendSelfDestroy>() == null)
		{
			base.gameObject.SetActive(value: false);
			Object.Destroy(this);
		}
	}
}

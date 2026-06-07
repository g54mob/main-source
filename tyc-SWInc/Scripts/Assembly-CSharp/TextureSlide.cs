using UnityEngine;

public class TextureSlide : MonoBehaviour
{
	private void Update()
	{
		base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, Time.deltaTime, 0f);
	}
}

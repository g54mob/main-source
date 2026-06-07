using UnityEngine;

public class CamShakeEvent : MonoBehaviour
{
	public void Shake(float intensity)
	{
		ClientPlayer.Instance.camShake.intensity = intensity;
	}
}

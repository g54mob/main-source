using UnityEngine;

public class GE_Heal_VFX : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem ps_spiral;

	[SerializeField]
	private ParticleSystem ps_arrows;

	[SerializeField]
	private GameObject decal;

	public void PlayVFX(GameObject owner)
	{
		if ((bool)decal)
		{
			decal.transform.localScale = new Vector3(1f, 1f, 0f) * (FunctionLibrary.GetObjectRadius(owner) + 2f) + Vector3.forward;
		}
		float objectHeight = FunctionLibrary.GetObjectHeight(owner);
		ps_arrows.transform.position = ps_arrows.transform.position + Vector3.up * objectHeight + Vector3.down * 1f;
		ParticleSystem.MainModule main = ps_spiral.main;
		main.startSpeed = objectHeight * 1f;
	}
}

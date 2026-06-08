using UnityEngine;

public class GenericSfxOnEnable : MonoBehaviour
{
	public string sfxId;

	private void OnEnable()
	{
		if ((bool)SfxController.singleton)
		{
			SfxController.singleton.Play(sfxId);
		}
	}
}

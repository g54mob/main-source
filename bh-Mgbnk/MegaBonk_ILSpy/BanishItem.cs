using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.UI;

public class BanishItem : MonoBehaviour
{
	public RawImage icon;

	public AudioSource audioSource;

	public void Set(UnlockableBase unlockable)
	{
		Texture texture = unlockable.GetIcon();
		icon.texture = texture;
		audioSource.Play();
	}
}

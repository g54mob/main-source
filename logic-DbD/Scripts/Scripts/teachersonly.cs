using UnityEngine;
using UnityEngine.EventSystems;

public class teachersonly : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	protected AudioClip creak;

	private AudioSource audioSource;

	private Website website;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		website = GetComponentInParent<Website>();
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		audioSource.PlayOneShot(creak);
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		website.PlayDoorClose();
	}

	public void Exit()
	{
		website.PlayDoorClose();
		website.LaunchInnerSite("lzu.edu", playSound: false);
	}
}

using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	private AudioClip hoverClip;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!PlayerManager.Instance.Players[0].IsGamepad)
		{
			EventSystem.current.SetSelectedGameObject(base.gameObject);
			if (audioSource != null)
			{
				audioSource.clip = hoverClip;
				audioSource.Play();
			}
		}
	}
}

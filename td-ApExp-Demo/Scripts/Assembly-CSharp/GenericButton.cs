using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	private AudioClip hoverClip;

	[SerializeField]
	private AudioClip clickClip;

	private AudioSource audioSource;

	private Button button;

	private TextMeshProUGUI text;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		button = GetComponent<Button>();
		text = GetComponentInChildren<TextMeshProUGUI>();
		button.onClick.AddListener(delegate
		{
			OnClick();
		});
	}

	private void OnClick()
	{
		AudioManager.Instance.PlayClipWithMixer(clickClip, AMG.SFX);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		audioSource.clip = hoverClip;
		audioSource.Play();
	}
}

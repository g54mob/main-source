using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class ButtonSfxSupport : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IMoveHandler, IPointerClickHandler, ISubmitHandler, IDeselectHandler
{
	[SerializeField]
	[Range(0f, 1f)]
	private float clickSfxVolume = 1f;

	[SerializeField]
	[Range(-3f, 3f)]
	private float clickSfxMinPitch = 0.9f;

	[SerializeField]
	[Range(-3f, 3f)]
	private float clickSfxMaxPitch = 1.1f;

	[SerializeField]
	[Range(0f, 1f)]
	private float hoverSfxVolume = 0.3f;

	[SerializeField]
	[Range(-3f, 3f)]
	private float hoverSfxMinPitch = 0.9f;

	[SerializeField]
	[Range(-3f, 3f)]
	private float hoverSfxMaxPitch = 1.1f;

	private AudioSource audioSource;

	private Selectable selectable;

	private bool isSelected;

	[field: SerializeField]
	public AudioClip ClickSfx { get; private set; }

	[field: SerializeField]
	public AudioClip HoverSfx { get; private set; }

	private void Start()
	{
		Setup();
	}

	private void Setup()
	{
		selectable = GetComponent<Selectable>();
		audioSource = null;
		if (HoverSfx != null)
		{
			audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.outputAudioMixerGroup = AudioManager.Instance.SfxGroup;
		}
	}

	public void OnMove(AxisEventData eventData)
	{
		if (!isSelected)
		{
			if (audioSource != null && selectable.interactable)
			{
				audioSource.volume = hoverSfxVolume;
				audioSource.clip = HoverSfx;
				audioSource.pitch = Random.Range(hoverSfxMinPitch, hoverSfxMaxPitch);
				audioSource.Play();
			}
			isSelected = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (audioSource != null && selectable.interactable)
		{
			audioSource.volume = hoverSfxVolume;
			audioSource.clip = HoverSfx;
			audioSource.pitch = Random.Range(hoverSfxMinPitch, hoverSfxMaxPitch);
			audioSource.Play();
		}
		isSelected = true;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (selectable.interactable)
		{
			AudioManager.Instance.SfxHelper.PlaySoundEffect(ClickSfx, clickSfxVolume, Random.Range(clickSfxMinPitch, clickSfxMaxPitch));
		}
	}

	public void OnSubmit(BaseEventData eventData)
	{
		if (selectable.interactable)
		{
			AudioManager.Instance.SfxHelper.PlaySoundEffect(ClickSfx, clickSfxVolume, Random.Range(clickSfxMinPitch, clickSfxMaxPitch));
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		isSelected = false;
	}
}

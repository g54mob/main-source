using Unity.Components.SoundsManager;
using Unity.Components.SoundsManager.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Image Image;

	public AudioClip ClipRegular;

	public AudioClip ClipRare;

	private int _counter;

	private IAudioSourceController _sound;

	private float _enableTime;

	private void Start()
	{
		if (GetComponent<Selectable>() == null)
		{
			Object.Destroy(this);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_counter++;
		if (_sound == null || !_sound.Player.isPlaying)
		{
			if (_counter >= 100)
			{
				_counter = 0;
				_sound = Sound.PlayUI(ClipRare);
			}
			else
			{
				_sound = Sound.PlayUI(ClipRegular);
				_enableTime = Time.time + 1f + Random.value * 5f;
				Image.CrossFadeAlpha(0f, 0.5f, ignoreTimeScale: false);
			}
		}
	}

	private void Update()
	{
		if (_enableTime != 0f && Time.time > _enableTime)
		{
			Image.CrossFadeAlpha(1f, 1f, ignoreTimeScale: false);
			_enableTime = 0f;
		}
	}
}

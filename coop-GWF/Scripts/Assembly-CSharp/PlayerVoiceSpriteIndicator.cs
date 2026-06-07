using System.Collections;
using Dissonance;
using Dissonance.Integrations.MirrorIgnorance;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerVoiceSpriteIndicator : MonoBehaviour
{
	[SerializeField]
	private MirrorIgnorancePlayer targetPlayer;

	[SerializeField]
	private Sprite speakingSprite;

	[SerializeField]
	private Sprite silentSprite;

	private Image _image;

	private DissonanceComms _dissonanceComms;

	private VoicePlayerState _voicePlayerState;

	private Sprite _currentSprite;

	private void Awake()
	{
		_image = GetComponent<Image>();
		if (!targetPlayer)
		{
			targetPlayer = GetComponentInParent<MirrorIgnorancePlayer>();
		}
	}

	private void Start()
	{
		StartCoroutine(Initialize());
	}

	private IEnumerator Initialize()
	{
		while (!_dissonanceComms)
		{
			_dissonanceComms = DissonanceComms.GetSingleton();
			yield return null;
		}
		while (!targetPlayer || string.IsNullOrEmpty(targetPlayer.PlayerId))
		{
			yield return null;
		}
		while (_voicePlayerState == null)
		{
			_voicePlayerState = _dissonanceComms.FindPlayer(targetPlayer.PlayerId);
			yield return null;
		}
	}

	private void Update()
	{
		Sprite sprite = ((_voicePlayerState != null && _voicePlayerState.IsSpeaking) ? speakingSprite : silentSprite);
		if ((bool)sprite && sprite != _currentSprite)
		{
			_currentSprite = sprite;
			_image.sprite = sprite;
		}
	}
}

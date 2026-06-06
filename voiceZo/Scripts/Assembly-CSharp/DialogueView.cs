using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _dialogueText;

	[SerializeField]
	private GameObject arrow;

	[SerializeField]
	private Image characterImage;

	[SerializeField]
	private Sprite happyImage;

	[SerializeField]
	private Sprite sadImage;

	private string[] _sentenceLocaleKeys = new string[3];

	private float _typingSpeed = 0.03f;

	private float _skipUnlockDelay = 1f;

	private int _currentIndex;

	private bool _canSkip;

	private Coroutine typingCoroutine;

	private Coroutine unlockCoroutine;

	public event Action OnEndDialogue;

	public void Open(Action onEndDialogue)
	{
		OnEndDialogue += onEndDialogue;
		_sentenceLocaleKeys[0] = "DIALOGUE_TALK_01";
		_sentenceLocaleKeys[1] = "DIALOGUE_TALK_02";
		_sentenceLocaleKeys[2] = "DIALOGUE_TALK_03";
		base.gameObject.SetActive(value: true);
		ShowSentence();
	}

	public void Close()
	{
		this.OnEndDialogue?.Invoke();
		this.OnEndDialogue = null;
		StopTypingCoroutine();
		StopUnlockCoroutine();
		base.gameObject.SetActive(value: false);
	}

	private void ShowSentence()
	{
		if (_currentIndex < _sentenceLocaleKeys.Length)
		{
			StopTypingCoroutine();
			StopUnlockCoroutine();
			_canSkip = false;
			arrow.SetActive(value: false);
			UpdateCharacterImage(_currentIndex);
			typingCoroutine = StartCoroutine(Co_TypeSentence(LocaleHelper.Get(_sentenceLocaleKeys[_currentIndex])));
			unlockCoroutine = StartCoroutine(Co_UnlockSkipAfterDelay(_skipUnlockDelay));
		}
	}

	private void NextSentence()
	{
		_currentIndex++;
		if (_currentIndex < _sentenceLocaleKeys.Length)
		{
			ShowSentence();
			return;
		}
		_dialogueText.text = "";
		Debug.Log("대화 끝!");
		Close();
	}

	private IEnumerator Co_TypeSentence(string sentence)
	{
		_dialogueText.text = "";
		foreach (char c in sentence)
		{
			_dialogueText.text += c;
			yield return new WaitForSeconds(_typingSpeed);
		}
		typingCoroutine = null;
	}

	private IEnumerator Co_UnlockSkipAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		_canSkip = true;
		arrow.SetActive(value: true);
		unlockCoroutine = null;
	}

	public void OnClickSkipButton()
	{
		if (_canSkip)
		{
			MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Up);
			if (typingCoroutine != null)
			{
				StopCoroutine(typingCoroutine);
				typingCoroutine = null;
				_dialogueText.text = LocaleHelper.Get(_sentenceLocaleKeys[_currentIndex]);
			}
			else
			{
				NextSentence();
			}
		}
	}

	private void UpdateCharacterImage(int index)
	{
		switch (index)
		{
		case 0:
			characterImage.sprite = happyImage;
			break;
		case 1:
			characterImage.sprite = sadImage;
			break;
		case 2:
			characterImage.sprite = happyImage;
			break;
		}
	}

	private void StopTypingCoroutine()
	{
		if (typingCoroutine != null)
		{
			StopCoroutine(typingCoroutine);
			typingCoroutine = null;
		}
	}

	private void StopUnlockCoroutine()
	{
		if (unlockCoroutine != null)
		{
			StopCoroutine(unlockCoroutine);
			unlockCoroutine = null;
		}
	}
}

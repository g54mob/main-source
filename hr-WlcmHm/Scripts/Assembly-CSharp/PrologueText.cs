using System.Collections;
using FMOD.Studio;
using FMODUnity;
using Febucci.UI;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(TypewriterCore))]
public class PrologueText : MonoBehaviour
{
	[Header("Typewriter")]
	private TypewriterCore typewriter;

	private TextAnimator_TMP textanim;

	[SerializeField]
	[TextArea]
	private string[] sentences;

	[SerializeField]
	private KeyCode inputKey = KeyCode.E;

	[SerializeField]
	private float waitTime = 1f;

	public EventReference soundToPlayOnInteract;

	[Header("Scene Objects")]
	[SerializeField]
	private PlayableDirector playableDirector;

	[SerializeField]
	private PlayableAsset openLetter;

	private void Awake()
	{
		typewriter = GetComponent<TypewriterCore>();
		textanim = GetComponent<TextAnimator_TMP>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SkipText();
		}
	}

	private void OnEnable()
	{
		StartCoroutine(ShowDialogues());
	}

	private void OnDisable()
	{
		typewriter.ShowText(string.Empty);
	}

	private IEnumerator ShowDialogues()
	{
		for (int i = 0; i < sentences.Length; i++)
		{
			if (i == sentences.Length - 1)
			{
				yield return ShowLastSentence(sentences[i]);
			}
			else
			{
				yield return ShowTextAndWait(sentences[i]);
			}
		}
		typewriter.StartDisappearingText();
		yield return new WaitForSeconds(2f);
		typewriter.transform.gameObject.SetActive(value: false);
	}

	private IEnumerator ShowTextAndWait(string text)
	{
		typewriter.ShowText(string.Empty);
		typewriter.ShowText(text);
		yield return new WaitUntil(() => !typewriter.isShowingText);
		yield return new WaitForSeconds(waitTime);
	}

	private IEnumerator ShowLastSentence(string text)
	{
		typewriter.ShowText(string.Empty);
		typewriter.ShowText(text);
		yield return new WaitUntil(() => !typewriter.isShowingText);
		yield return new WaitUntil(() => Input.GetKeyDown(inputKey));
		PlayInteractSound();
		playableDirector.Play(openLetter);
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnInteract);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void ChangeText(string newText)
	{
		textanim.SetText(newText);
	}

	public void SkipText()
	{
		StopAllCoroutines();
		StartCoroutine(ShowLastSentence2());
	}

	private IEnumerator ShowLastSentence2()
	{
		typewriter.ShowText(string.Empty);
		typewriter.ShowText(sentences[sentences.Length - 1]);
		typewriter.SkipTypewriter();
		yield return new WaitUntil(() => Input.GetKeyDown(inputKey));
		playableDirector.Play(openLetter);
	}
}

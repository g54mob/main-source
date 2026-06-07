using System.Collections;
using FMOD.Studio;
using FMODUnity;
using Febucci.UI;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TypewriterCore))]
public class LetterText : MonoBehaviour
{
	private TypewriterCore typewriter;

	private TextAnimator_TMP textanim;

	[Header("Typewriter")]
	[SerializeField]
	private GameObject acceptInvitation;

	[SerializeField]
	private KeyCode inputKey = KeyCode.E;

	[Header("Scene Objects")]
	[SerializeField]
	private Animator transition;

	[SerializeField]
	private PlayableDirector playableDirector;

	[SerializeField]
	private PlayableAsset bus;

	public EventReference letterAcceptSound;

	public EventReference busSoundvroomvroom;

	public GameObject beginningMusic;

	public GameObject beginningMusic2;

	private void Start()
	{
		typewriter = GetComponent<TypewriterCore>();
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
	}

	public void ShowAccept()
	{
		StartCoroutine(FadeTextIn(acceptInvitation));
		StartCoroutine(StartGame());
	}

	public void SkipText()
	{
		typewriter.SkipTypewriter();
		StartCoroutine(FadeTextIn(acceptInvitation));
		StartCoroutine(StartGame());
	}

	private IEnumerator StartGame()
	{
		yield return new WaitUntil(() => Input.GetKeyDown(inputKey));
		PlayLetterSound();
		transition.transform.gameObject.SetActive(value: true);
		transition.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		playableDirector.Stop();
		playableDirector.playableAsset = null;
		playableDirector.Play(bus);
		PlayBusSound();
		Object.Destroy(beginningMusic);
		Object.Destroy(beginningMusic2);
		yield return new WaitForSeconds((float)bus.duration);
		FinishPrologue();
	}

	private IEnumerator FadeTextIn(GameObject obj)
	{
		CanvasGroup alpha = obj.GetComponent<CanvasGroup>();
		float step = Time.deltaTime / 1f;
		while (alpha.alpha < 1f)
		{
			alpha.alpha += step;
			yield return null;
		}
	}

	public void FinishPrologue()
	{
		SceneManager.LoadScene("Day0_Outside");
	}

	public void PlayLetterSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(letterAcceptSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void PlayBusSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(busSoundvroomvroom);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}

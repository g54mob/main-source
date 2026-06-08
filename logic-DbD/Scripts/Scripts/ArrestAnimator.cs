using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestAnimator : MonoBehaviour
{
	[SerializeField]
	private GameObject confetti;

	[SerializeField]
	private Animator icons;

	[SerializeField]
	private Animator dancingMole;

	[SerializeField]
	private Transform cheeringMole;

	[SerializeField]
	private Transform thumbsMoles;

	[SerializeField]
	private GameObject arrestTextPrefab;

	[SerializeField]
	private GameObject postArrestPopup;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private LevelManager levelManager;

	[SerializeField]
	private Transform balloonSpawner;

	[SerializeField]
	private GameObject balloonPrefab;

	[SerializeField]
	private AudioClip cheers;

	[SerializeField]
	private AudioClip airhorn;

	[SerializeField]
	private AssistantSpawner peeker;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private Settings settings;

	[SerializeField]
	private AudioSource fadeInAudio;

	[SerializeField]
	private GameObject sliderPrefab;

	[SerializeField]
	private AudioClip loadingMusic;

	[SerializeField]
	private GameObject demoEndPanelPrefab;

	[SerializeField]
	private AudioClip confettiPoof;

	[SerializeField]
	private Animator taskbarAnimator;

	[SerializeField]
	private AudioClip jailSounds;

	public static readonly System.Random RANDY = new System.Random();

	private static readonly int BALLOONS = 4;

	private static readonly float ANIMATION_LENGTH = 4.5f;

	private static readonly float LOADING_DURATION = 30f;

	public void PlayAnimations(bool isCorrectArrest, string arrestName)
	{
		if (!settings.IsAssistantDisabled())
		{
			assistant.DespawnAssistants();
		}
		AudioSource component = GetComponent<AudioSource>();
		UIUtils.CloseAllPanels(canvas);
		CursorManager.StopCursorLoading();
		GameObject gameObject = SpawnArrestPopup(isCorrectArrest, arrestName);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(arrestTextPrefab, base.transform.position, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(gameObject2);
		component.PlayOneShot(airhorn);
		component.PlayOneShot(cheers);
		StartCoroutine(PlayPoof(component));
		confetti.SetActive(value: true);
		dancingMole.Play("fade in dance");
		PlayAllChildAnimations(cheeringMole, "fade in cheer", 0f);
		PlayAllChildAnimations(thumbsMoles, "fade in thumbs", 0.5f);
		icons.Play("Move Out Icons");
		taskbarAnimator.Play("Despawn Taskbar");
		AnimateBalloons();
		gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -70f);
		Animator component2 = gameObject.GetComponent<Animator>();
		component2.SetFloat("Speed Mult", 0.5f);
		component2.Play("Open Panel");
		StartCoroutine(CloseBars(component, gameObject.transform.Find("Jail Bars").GetComponentInChildren<Animator>(), component2));
		StartCoroutine(RetractArrestAnimations(ANIMATION_LENGTH, gameObject2, gameObject, confetti, isCorrectArrest));
	}

	public GameObject SpawnArrestPopup(bool isCorrectArrest, string arrestName)
	{
		GameObject obj = UnityEngine.Object.Instantiate(postArrestPopup, base.transform.position, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(obj);
		obj.GetComponent<ArrestPanel>().SetSuspectPhoto(isCorrectArrest, arrestName);
		return obj;
	}

	private IEnumerator CloseBars(AudioSource audioPlayer, Animator animator, Animator popupAnimator)
	{
		yield return new WaitForSeconds(1.7f);
		animator.Play("Jail Bars Animator");
		audioPlayer.PlayOneShot(jailSounds);
		yield return new WaitForSeconds(1.2f);
		popupAnimator.Play("Shake");
	}

	private IEnumerator PlayPoof(AudioSource audioPlayer)
	{
		yield return new WaitForSeconds(1f);
		audioPlayer.PlayOneShot(confettiPoof);
	}

	public void OpenLoadingPanel(Action afterLoadingAction)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(sliderPrefab, canvas.transform.position, Quaternion.identity, canvas.transform);
		SoundEffectUtils.GetOpenClosePanelPlayer().PlayOpen();
		AudioSource component = gameObject.GetComponent<AudioSource>();
		component.clip = loadingMusic;
		component.Play();
		SliderPanel component2 = gameObject.GetComponent<SliderPanel>();
		component2.SetToolbarName("Temporary Leave");
		component2.StartLoading(LOADING_DURATION, new string[3] { "Enjoying time off", "Relaxing in the pool", "Thinking about nothing" }, afterLoadingAction);
		PanelManager.OpenWindow(gameObject);
	}

	private IEnumerator RetractArrestAnimations(float waitTime, GameObject arrestText, GameObject arrestPanel, GameObject confetti, bool isCorrectArrest)
	{
		yield return new WaitForSeconds(waitTime);
		RetractMolemanArrestAnimations(arrestText, arrestPanel, confetti);
		if (!levelManager.LevelUp(isCorrectArrest))
		{
			levelManager.OnFail(delegate
			{
				OpenLoadingPanel(delegate
				{
					FadeIn();
					fadeInAudio.Play();
				});
			});
		}
		else if (LevelManager.GetCurrLevel() > 3)
		{
			levelManager.OnDemoEnd(delegate
			{
				GameObject window = UnityEngine.Object.Instantiate(demoEndPanelPrefab, base.transform.position, Quaternion.identity, canvas.transform);
				SoundEffectUtils.GetOpenClosePanelPlayer().PlayOpen();
				PanelManager.OpenWindow(window);
				assistant.ForceWave();
				icons.Play("Move In Icons");
				taskbarAnimator.Play("Hold Taskbar");
				levelManager.OnNewLevel();
			}, isCorrectArrest);
		}
		else
		{
			FadeIn();
			levelManager.OnNewLevel();
		}
	}

	private void FadeIn()
	{
		canvas.GetComponent<MusicFadeOuterizer>().FadeIn();
		icons.Play("Move In Icons");
		taskbarAnimator.Play("Hold Taskbar");
		StartCoroutine(peeker.PeekRoutine());
	}

	private void RetractMolemanArrestAnimations(GameObject arrestText, GameObject arrestPanel, GameObject confetti)
	{
		arrestText.GetComponent<Animator>().Play("RETRACT TEXT");
		UnityEngine.Object.Destroy(arrestText, 2f);
		arrestPanel.GetComponent<Panel>().ClosePanel();
		confetti.SetActive(value: false);
		dancingMole.Play("fade out dance");
		PlayAllChildAnimations(cheeringMole, "fade out cheer", 0f);
		PlayAllChildAnimations(thumbsMoles, "fade out thumbs", 0.2f);
		Animator component = postArrestPopup.GetComponent<Animator>();
		component.SetFloat("Speed Mult", 0.4f);
		component.Play("Close Panel");
	}

	private void AnimateBalloons()
	{
		int num = (int)(GetWidth(balloonSpawner) - GetWidth(balloonPrefab.transform));
		HashSet<Color32> activeColors = new HashSet<Color32>
		{
			Balloon.BLUE,
			Balloon.GREEN,
			Balloon.YELLOW,
			Balloon.RED
		};
		List<int> list = new List<int>();
		for (int i = 0; i < BALLOONS; i++)
		{
			list.Add(i);
		}
		int num2 = num / BALLOONS;
		int num3 = 0;
		int num4 = num2;
		for (int j = 0; j < BALLOONS; j++)
		{
			int xPos = RANDY.Next(num3, num4);
			int randomValue = CreateTablesHelpers.GetRandomValue(list);
			StartCoroutine(InstantiateBalloon(xPos, (double)RANDY.Next(20, 40) / 100.0 * (double)randomValue, activeColors));
			list.Remove(randomValue);
			num3 += num2;
			num4 += num2;
		}
		UIUtils.SetPenultimateLayer(balloonSpawner);
	}

	private IEnumerator InstantiateBalloon(int xPos, double delayTime, HashSet<Color32> activeColors)
	{
		yield return new WaitForSeconds((float)delayTime);
		GameObject obj = UnityEngine.Object.Instantiate(balloonPrefab, balloonSpawner.position, Quaternion.identity, balloonSpawner.transform);
		obj.transform.localPosition = new Vector3(xPos, balloonSpawner.position.y);
		Color32 randomValue = CreateTablesHelpers.GetRandomValue(activeColors);
		obj.GetComponent<Balloon>().SetColor(randomValue);
		activeColors.Remove(randomValue);
	}

	private float GetWidth(Transform gameObject)
	{
		return gameObject.GetComponent<RectTransform>().rect.width;
	}

	private void PlayAllChildAnimations(Transform parent, string animation, float delayTime)
	{
		float num = 0f;
		foreach (Transform item in parent)
		{
			StartCoroutine(PlayDelayedAnimation(item.GetComponent<Animator>(), animation, num));
			num += delayTime;
		}
	}

	private IEnumerator PlayDelayedAnimation(Animator animator, string animation, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		animator.Play(animation);
	}
}

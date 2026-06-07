using System.Collections.Generic;
using UnityEngine;

public class Tally : MonoBehaviour, PageTemplateHost
{
	private enum State
	{
		Boot = 0,
		Intro = 1,
		Insurance = 2,
		Watch = 3,
		Book = 4,
		Package = 5,
		Mail = 6
	}

	public Transform sceneModelTransform;

	public Camera mainCamera;

	public Camera uiCamera;

	public AudioClip endMusicAudioClip;

	public MouseCursor mouseCursor;

	public Dialog dialog;

	[Readonly]
	public Transform sceneModelCameraTransform;

	[Readonly]
	public Animator sceneModelAnimator;

	[Readonly]
	public TallyInsurance tallyInsurance;

	[Readonly]
	public List<PageTemplate> pageTemplates;

	private Stater<State> stater;

	private AudioOneShot endMusicAudioOneShot;

	private float endMusicTime;

	private const int kEndMusicBpm = 120;

	private const float kEndMusicSecondsPerBeat = 0.5f;

	private const float kEndMusicSecondsPerBar = 2f;

	private void Start()
	{
		stater = new Stater<State>("Tally");
		stater.AddState(State.Boot).SetDurations(0f, 0.01f, State.Intro);
		stater.AddState(State.Intro).AddFunc(StaterFunc.ENTER(delegate
		{
			sceneModelAnimator.Play("Insurance");
			SetPageTemplate(null);
			uiCamera.enabled = false;
			dialog.Play("tally-intro");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialog.isPlaying)
			{
				stater.Go(State.Insurance);
			}
			if (DebugMenu.WantSkip())
			{
				dialog.Stop();
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				uiCamera.enabled = true;
			}));
		stater.AddState(State.Insurance).AddFunc(StaterFunc.ENTER(delegate
		{
			sceneModelAnimator.Play("Insurance");
			tallyInsurance.GoIdle();
			SetPageTemplate("TallyInsurance");
			mouseCursor.gameObject.SetActive(true);
		})).AddFunc(StaterFunc.EXIT(delegate
		{
			mouseCursor.gameObject.SetActive(false);
			SetPageTemplate(null);
		}));
		stater.AddState(State.Watch).SetDurations(0f, 8f, State.Book).AddFunc(StaterFunc.ENTER(delegate
		{
			sceneModelAnimator.Play("Watch");
			endMusicTime = 0f;
		}))
			.AddFunc(StaterFunc.AT_STEP(0.5f, delegate
			{
				endMusicAudioOneShot = AudioOneShot.Play(endMusicAudioClip);
			}))
			.AddFunc(StaterFunc.AT_STEP(2.5f, delegate
			{
				SetPageTemplate("TallyMessage", Lang.Get("tally_parting_watch"), -320f);
			}));
		stater.AddState(State.Book).SetDurations(0f, 8.5f, State.Package).AddFunc(StaterFunc.ENTER(delegate
		{
			sceneModelAnimator.Play("Book");
			SetPageTemplate(null);
		}))
			.AddFunc(StaterFunc.AT_STEP(2.5f, delegate
			{
				SetPageTemplate("TallyMessage", Lang.Get("tally_parting_book"), -360f);
			}));
		stater.AddState(State.Package).SetDurations(0f, 4f, State.Mail).AddFunc(StaterFunc.ENTER(delegate
		{
			SetPageTemplate(null);
			sceneModelAnimator.Play("Wrap");
		}))
			.AddFunc(StaterFunc.AT_STEP(1f, delegate
			{
				sceneModelAnimator.Play("Label0");
			}))
			.AddFunc(StaterFunc.AT_STEP(2f, delegate
			{
				sceneModelAnimator.Play("Label1");
			}))
			.AddFunc(StaterFunc.AT_STEP(3f, delegate
			{
				sceneModelAnimator.Play("Label2");
			}));
		stater.AddState(State.Mail).AddFunc(StaterFunc.ENTER(delegate
		{
			sceneModelAnimator.Play("Mail");
			SetPageTemplate(null);
		})).AddFunc(StaterFunc.AT_STEP(7f, delegate
		{
			SaveData.it.general.era = 3;
			Game.SaveActive();
			Game.LoadExploringScene();
		}));
		stater.Go(State.Boot);
	}

	private void Update()
	{
		float dt = Clock.play.deltaTime;
		if (endMusicAudioOneShot != null && !endMusicAudioOneShot.done)
		{
			dt = endMusicAudioOneShot.time - endMusicTime;
			endMusicTime = endMusicAudioOneShot.time;
		}
		stater.Step(dt);
		OneBit.ShowOverlayForFrames();
	}

	private void LateUpdate()
	{
		mainCamera.transform.position = sceneModelCameraTransform.position;
		mainCamera.transform.rotation = sceneModelCameraTransform.rotation;
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		if (tallyInsurance.isActiveAndEnabled)
		{
			tallyInsurance.OnPageButtonClick(pageItem);
		}
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
		if (tallyInsurance.isActiveAndEnabled)
		{
			tallyInsurance.MoveOffPage(dir, sourcePageItem);
		}
	}

	public void OnInsuranceDone()
	{
		stater.Go(State.Watch);
	}

	private void SetPageTemplate(string name, string message = null, float messageY = 0f)
	{
		foreach (PageTemplate pageTemplate in pageTemplates)
		{
			if (pageTemplate.name == name)
			{
				pageTemplate.gameObject.SetActive(true);
				if (pageTemplate.name == "TallyMessage" && message.HasValue())
				{
					Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
					pageTemplate.BeginRefresh();
					pageItemDict["message"].text = message;
					pageItemDict["message"].position = new Vector2(pageItemDict["message"].cache.rt.anchoredPosition.x, messageY);
					pageTemplate.EndRefresh();
				}
			}
			else
			{
				pageTemplate.gameObject.SetActive(false);
			}
		}
	}
}

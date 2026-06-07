using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour, PageTemplateHost
{
	private enum State
	{
		None = 0,
		WaitingToStart = 1,
		Plate0 = 2,
		Plate1 = 3,
		Done = 4
	}

	public AudioClip audioClip;

	public RectTransform plate0Rt;

	public RectTransform plate1Rt;

	public CreditList creditList;

	public FaceLib faceLib;

	private Stater<State> stater;

	private PageTemplate pageTemplate;

	private AudioOneShot audioOneShot;

	private const float kSecondsPerBeat = 0.75f;

	private const float kInterpDuration = 0.1875f;

	private int cur;

	private CreditList.Entry[] plateEntries = new CreditList.Entry[2];

	private CanvasGroup plateGroup0;

	private CanvasGroup plateGroup1;

	private const float kTopY = 400f;

	private const float kMidY = 0f;

	private const float kBotY = -400f;

	private float plate0Y
	{
		set
		{
			plate0Rt.anchoredPosition = new Vector2(plate0Rt.anchoredPosition.x, value);
		}
	}

	private float plate1Y
	{
		set
		{
			plate1Rt.anchoredPosition = new Vector2(plate1Rt.anchoredPosition.x, value);
		}
	}

	private void Start()
	{
		pageTemplate = GetComponent<PageTemplate>();
		plateGroup0 = plate0Rt.GetComponent<CanvasGroup>();
		plateGroup1 = plate1Rt.GetComponent<CanvasGroup>();
		plateEntries[0] = null;
		plateEntries[1] = null;
		cur = -1;
		stater = new Stater<State>("Credits");
		stater.AddState(State.None);
		stater.AddState(State.WaitingToStart).SetDurations(0f, 0.1f, State.Plate0).AddFunc(StaterFunc.STEP(delegate
		{
			Monitor.BlackOut(1);
			plate0Rt.gameObject.SetActive(true);
			plate1Rt.gameObject.SetActive(true);
		}));
		stater.AddState(State.Plate0).SetDurations(0.1875f).AddFunc(StaterFunc.ENTER(delegate
		{
			AdvancePlates();
		}))
			.AddFunc(StaterFunc.AT_INTERP(0.5f, delegate
			{
				if (cur == 0 && audioOneShot == null)
				{
					audioOneShot = AudioOneShot.Play(audioClip, true);
				}
			}))
			.AddFunc(StaterFunc.INTERP(delegate(float t)
			{
				float t2 = Util.SmoothStepEdges(0f, 1f, t);
				plate0Y = Mathf.Lerp(-400f, 0f, t2);
				plate1Y = Mathf.Lerp(0f, 400f, t2);
				plateGroup0.alpha = Mathf.Lerp(0f, 1f, t);
				plateGroup1.alpha = Mathf.Lerp(1f, 0f, t);
			}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				Step(State.Plate1);
			}));
		stater.AddState(State.Plate1).SetDurations(0.1875f).AddFunc(StaterFunc.ENTER(delegate
		{
			AdvancePlates();
		}))
			.AddFunc(StaterFunc.AT_INTERP(0.5f, delegate
			{
			}))
			.AddFunc(StaterFunc.INTERP(delegate(float t)
			{
				float t2 = Util.SmoothStepEdges(0f, 1f, t);
				plate1Y = Mathf.Lerp(-400f, 0f, t2);
				plate0Y = Mathf.Lerp(0f, 400f, t2);
				plateGroup1.alpha = Mathf.Lerp(0f, 1f, t);
				plateGroup0.alpha = Mathf.Lerp(1f, 0f, t);
			}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				Step(State.Plate0);
			}));
		stater.AddState(State.Done).AddFunc(StaterFunc.ENTER(delegate
		{
			audioOneShot.Stop(2f);
		})).AddFunc(StaterFunc.AT_STEP(2f, delegate
		{
			Step(State.Plate0);
			Game.LoadTitle();
		}));
		stater.Go(State.WaitingToStart, true);
	}

	private void OnDisable()
	{
		if (audioOneShot != null)
		{
			audioOneShot.Stop(2f);
			audioOneShot = null;
		}
	}

	private void Step(State nextState)
	{
		if (audioOneShot != null)
		{
			float num;
			for (num = (float)((cur + 1) * 4) * 0.75f - 0.1875f; num > audioClip.length; num -= audioClip.length)
			{
			}
			if (audioOneShot.time > num)
			{
				stater.Go(nextState);
			}
		}
		else if (stater.stateTime > 2.8125f)
		{
			stater.Go(nextState);
		}
		if (cur > creditList.entries.Count)
		{
			stater.Go(State.Done);
		}
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
		if (RInput.GetButtonDown(10))
		{
			Game.LoadTitle();
		}
	}

	private void AdvancePlates()
	{
		cur++;
		if (cur >= 0)
		{
			plateEntries[((cur & 1) != 0) ? 1 : 0] = ((cur >= creditList.entries.Count) ? null : creditList.entries[cur]);
		}
		RefreshPlates();
	}

	private void RefreshPlates()
	{
		pageTemplate.BeginRefresh();
		Dictionary<string, PageItem> pageItemDict = pageTemplate.pageItemDict;
		if (plateEntries[0] != null)
		{
			SetPlate(pageItemDict, "plate0-", plateEntries[0]);
		}
		if (plateEntries[1] != null)
		{
			SetPlate(pageItemDict, "plate1-", plateEntries[1]);
		}
		pageTemplate.EndRefresh();
	}

	private void SetPlate(Dictionary<string, PageItem> items, string idPrefix, CreditList.Entry entry)
	{
		int num = 0;
		if (entry.names.Length > 0)
		{
			items[idPrefix + "heading"].text = Lang.ExpandReferences(entry.headingId);
			if (entry.hasTitles)
			{
				items[idPrefix + "names-split"].visible = true;
				items[idPrefix + "split-l"].text = Lang.ExpandReferences(entry.titles);
				items[idPrefix + "split-r"].text = entry.names;
			}
			else
			{
				items[idPrefix + "names"].text = entry.names;
			}
			int num2 = 1;
			string names = entry.names;
			foreach (char c in names)
			{
				if (c == '\n')
				{
					num2++;
				}
			}
			num = 26 * num2 + 18;
		}
		else
		{
			items[idPrefix + "names"].text = Lang.ExpandReferences(entry.headingId);
			num = 18;
		}
		if (entry.faceIds.Length > 0)
		{
			items[idPrefix + "faces"].visible = true;
			for (int j = 0; j < entry.faceIds.Length; j++)
			{
				items[string.Format("{0}face{1}", idPrefix, j)].sprite = faceLib.Find(entry.faceIds[j]).spriteHi;
			}
			num += 214;
		}
		items[idPrefix + "holder"].visible = true;
		items[idPrefix + "holder"].rt.anchoredPosition = (float)(num - 360) * 0.5f * Vector2.up;
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
	}
}

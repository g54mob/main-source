using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class RadicalCreditsMenu : RadicalMenu, IScrollable
{
	[Serializable]
	public struct TitleGraphics
	{
		public CreditTitle title;

		public GameObject graphicsObject;
	}

	public GameObject background;

	public Transform offsetTransform;

	public Transform container;

	public Dictionary<int, RadicalCreditsTextEntry> entries = new Dictionary<int, RadicalCreditsTextEntry>();

	public UIScrollWindow scrollWindow;

	public PugText thanksForPlayingText;

	public LocalizedString thanksForPlayingString;

	private TimerSimple thanksForPlayingTextTimer;

	private float entriesLocalBottomPos;

	private float entriesLocalTopPos;

	private Vector3 m_offsetPosition;

	private TimerSimple scrollDelayTimer = new TimerSimple(2f, unscaled: true);

	[Header("Sprites")]
	[SerializeField]
	[ArrayElementTitle("title")]
	private TitleGraphics[] m_titleSprites;

	private Dictionary<CreditTitle, TitleGraphics> m_titleSpriteLookup;

	private bool isOutroScene
	{
		get
		{
			if (Manager.sceneHandler != null)
			{
				return Manager.sceneHandler.isOutro;
			}
			return false;
		}
	}

	public override bool UseCustomHelpButtons => true;

	protected override void Awake()
	{
		base.Awake();
		InitializeTitleSpriteLookup();
	}

	public void AddEntry(int index, RadicalCreditsTextEntry entry)
	{
		if (entries.ContainsKey(index))
		{
			entries[index] = entry;
			Debug.LogError("Added entry to already existing index, should not happen.");
		}
		else
		{
			entries.Add(index, entry);
		}
		if (entry.botLocalPosition.y < entriesLocalBottomPos)
		{
			entriesLocalBottomPos = entry.botLocalPosition.y;
		}
		if (entry.topLocalPosition.y > entriesLocalTopPos)
		{
			entriesLocalTopPos = entry.topLocalPosition.y;
		}
	}

	public void RemoveEntry(int index)
	{
		if (entries.ContainsKey(index))
		{
			entries.Remove(index);
		}
		else
		{
			Debug.LogError("Tried to remove entry with index that didnt exist, should not happen.");
		}
	}

	private RadicalCreditsTextEntry FindTopEntry()
	{
		int num = int.MaxValue;
		foreach (KeyValuePair<int, RadicalCreditsTextEntry> entry in entries)
		{
			if (entry.Key < num)
			{
				num = entry.Key;
			}
		}
		if (entries.ContainsKey(num))
		{
			return entries[num];
		}
		return null;
	}

	private RadicalCreditsTextEntry FindBottomEntry()
	{
		int num = int.MinValue;
		foreach (KeyValuePair<int, RadicalCreditsTextEntry> entry in entries)
		{
			if (entry.Key > num)
			{
				num = entry.Key;
			}
		}
		if (entries.ContainsKey(num))
		{
			return entries[num];
		}
		return null;
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		if (isOutroScene)
		{
			return new List<MenuHelperButtons.HelpButtonTypes>();
		}
		return new List<MenuHelperButtons.HelpButtonTypes>
		{
			MenuHelperButtons.HelpButtonTypes.NAVIGATE,
			MenuHelperButtons.HelpButtonTypes.BACK
		};
	}

	public override void Activate()
	{
		base.Activate();
		scrollWindow.enabled = true;
		thanksForPlayingTextTimer.Stop();
		thanksForPlayingText.Render("");
		Manager.camera.creditsCamera.enabled = true;
		entriesLocalBottomPos = 2.1474836E+09f;
		entriesLocalTopPos = -2.1474836E+09f;
		scrollWindow.ResetScroll();
		scrollDelayTimer.Start(isOutroScene ? 3f : 2f);
		RadicalCreditsTextEntry.SpawnTextEntry(spawnBeneathPosition: true, Vector3.zero, 0, this);
		background.SetActive(!isOutroScene);
		if (isOutroScene)
		{
			m_offsetPosition = new Vector3(0f, -5f, 0f);
		}
		else
		{
			m_offsetPosition = new Vector3(0f, 9f, 0f);
		}
		offsetTransform.localPosition = m_offsetPosition;
	}

	public override void Deactivate(bool pop)
	{
		Manager.camera.creditsCamera.enabled = false;
		RadicalCreditsTextEntry[] componentsInChildren = container.GetComponentsInChildren<RadicalCreditsTextEntry>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Free();
		}
		entries.Clear();
		base.Deactivate(pop);
		if (isOutroScene)
		{
			Manager.load.QueueScene("Title", 1f, 0.5f, FadePresets.blackToBlack, setFadeValueTo1: false, 1);
		}
	}

	public override bool SelectNextIndex()
	{
		return false;
	}

	public override bool SelectPrevIndex()
	{
		return false;
	}

	private float frac(float x)
	{
		return x - Mathf.Floor(x);
	}

	private void InitializeTitleSpriteLookup()
	{
		m_titleSpriteLookup = new Dictionary<CreditTitle, TitleGraphics>(m_titleSprites.Length);
		TitleGraphics[] titleSprites = m_titleSprites;
		for (int i = 0; i < titleSprites.Length; i++)
		{
			TitleGraphics value = titleSprites[i];
			m_titleSpriteLookup.Add(value.title, value);
			value.graphicsObject.SetActive(value: false);
		}
	}

	public void SpawnTitleSprite(CreditTitle title, Vector3 position)
	{
		if (m_titleSpriteLookup.TryGetValue(title, out var value))
		{
			value.graphicsObject.SetActive(value: true);
			value.graphicsObject.transform.localPosition = position;
		}
	}

	private void Update()
	{
		if (entries.Count == 0 && RadicalCreditsTextEntry.EntryShouldExistAtHeight(container.transform.localPosition.y))
		{
			RadicalCreditsTextEntry.SpawnTextEntry(spawnBeneathPosition: true, Vector3.zero, 0, this);
		}
		if (scrollDelayTimer.isTimerElapsed && !Manager.input.system.GetButton(61) && !Manager.input.system.GetButton(4) && !Manager.input.IsMenuUpButtonPressed() && !Manager.input.IsMenuDownButtonPressed() && (Manager.input.SystemPrefersKeyboardAndMouse() || (double)math.abs(Manager.input.singleplayerInputModule.GetRawAxisInput().y) <= 0.1))
		{
			scrollWindow.MoveScroll(0.0625f * Time.unscaledDeltaTime * 16f);
		}
		float y = container.transform.localPosition.y;
		float num = frac(y * 16f);
		Camera creditsCamera = Manager.camera.creditsCamera;
		Vector3 position = creditsCamera.transform.position;
		position.y = (0f - num) * 0.0625f;
		creditsCamera.transform.position = position;
		Vector3 offsetPosition = m_offsetPosition;
		offsetPosition.y -= num * 0.0625f;
		offsetTransform.localPosition = offsetPosition;
		if (!scrollWindow.IsAtBottom())
		{
			return;
		}
		if (isOutroScene)
		{
			if (!thanksForPlayingTextTimer.isRunning)
			{
				scrollWindow.enabled = false;
				thanksForPlayingTextTimer.Start(3f);
				thanksForPlayingText.Render(thanksForPlayingString.mTerm, rewindEffectAnims: true);
				UnityEngine.Object.FindObjectOfType<IntroHandler>().FadeOutCreditsMusic();
			}
			if (thanksForPlayingTextTimer.isRunning && thanksForPlayingTextTimer.isTimerElapsed)
			{
				Manager.load.QueueScene("Title", 1f, 0.5f, FadePresets.blackToBlack, setFadeValueTo1: false, 1);
			}
		}
		else
		{
			Manager.menu.PopMenu();
		}
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		return false;
	}

	public bool IsTopElementSelected()
	{
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return entriesLocalTopPos - entriesLocalBottomPos + 1.875f + 27f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}
}

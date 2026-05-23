using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	public class Extra
	{
		public AudioClip audioClip;

		public float audioClipVolume = 1f;

		public AudioSource audioSource;

		public bool wantBlackFramesAfter;

		public Extra()
		{
		}

		public Extra(AudioClip audioClip_, AudioSource audioSource_ = null)
		{
			audioClip = audioClip_;
			audioSource = audioSource_;
		}

		public Extra SetAudioClipVolume(float audioClipVolume_)
		{
			audioClipVolume = audioClipVolume_;
			return this;
		}

		public Extra SetWantBlackFramesAfter(bool wantBlackFramesAfter_)
		{
			wantBlackFramesAfter = wantBlackFramesAfter_;
			return this;
		}
	}

	[Serializable]
	public class AssetInfos
	{
		public List<AssetInfo> infos;

		public void Show(string dialogId, Extra extra)
		{
			foreach (AssetInfo info in infos)
			{
				if (info.dialogId == dialogId)
				{
					info.Show(extra);
					return;
				}
			}
			Debug.LogWarning("No DialogInfo found: \"" + dialogId + "\"");
		}
	}

	[Serializable]
	public class AssetInfo
	{
		public string dialogId;

		public AudioClip audioClip;

		public void Show()
		{
			Game.instance.ShowDialog(dialogId, new Extra(audioClip));
		}

		public void Show(AudioSource audioSource)
		{
			Game.instance.ShowDialog(dialogId, new Extra(audioClip, audioSource));
		}

		public void Show(Extra extra)
		{
			extra.audioClip = audioClip;
			Game.instance.ShowDialog(dialogId, extra);
		}
	}

	[Serializable]
	public class Panel
	{
		public GameObject root;

		public GameObject container;

		public Text uiText;

		public GameObject nextGo;

		public Text nextText;

		public float wiggleRot = 0.75f;

		public float wigglePos = 5f;

		public bool wantWiggle = true;

		private string text_;

		public string text
		{
			get
			{
				return text_;
			}
			set
			{
				text_ = value;
				uiText.text = ((!(value == "_")) ? value : string.Empty);
				Wiggle();
			}
		}

		public bool showNext
		{
			get
			{
				return nextGo != null && nextGo.activeSelf;
			}
			set
			{
				if (nextGo != null)
				{
					nextGo.SetActive(value);
				}
			}
		}

		public bool visible
		{
			get
			{
				return root.activeInHierarchy;
			}
			set
			{
				root.SetActive(value);
			}
		}

		public TextAnchor alignment
		{
			get
			{
				return uiText.alignment;
			}
			set
			{
				uiText.alignment = value;
			}
		}

		public void Reset()
		{
			text = string.Empty;
			alignment = TextAnchor.MiddleCenter;
			showNext = false;
			wantWiggle = true;
			nextText.text = Lang.Get("dialog_next");
		}

		private void Wiggle()
		{
			RectTransform component = container.GetComponent<RectTransform>();
			if (wantWiggle)
			{
				component.localRotation = Quaternion.Euler(new Vector3(0f, 0f, UnityEngine.Random.Range(0f - wiggleRot, wiggleRot)));
				component.localPosition = new Vector3(UnityEngine.Random.Range(0f - wigglePos, wigglePos), UnityEngine.Random.Range(0f - wigglePos, wigglePos), 0f);
			}
			else
			{
				component.localRotation = Quaternion.identity;
				component.localPosition = Vector3.zero;
			}
		}
	}

	public DialogLib lib;

	public Camera renderCamera;

	public Panel fullscreenPanel;

	[HideInInspector]
	public bool showSkip;

	private DialogLib.Spec spec;

	private DialogLib.Page curPage;

	private AudioOneShot audioOneShot;

	private float playStartTime = -1f;

	private float lastPageNextTime;

	private bool wantBlackFramesAfter;

	private bool audioOnly;

	public string customString;

	[HideInInspector]
	public bool useMenuClock;

	public bool isPlaying
	{
		get
		{
			return spec != null && ((playStartTime >= 0f && time < spec.duration) || fullscreenPanel.visible);
		}
	}

	public bool isPlayingFullscreen
	{
		get
		{
			return isPlaying && !audioOnly;
		}
	}

	public float time
	{
		get
		{
			return (!(audioOneShot != null)) ? (clock.time - playStartTime) : audioOneShot.time;
		}
	}

	private Clock clock
	{
		get
		{
			return (!useMenuClock) ? Clock.play : Clock.menu;
		}
	}

	private void Awake()
	{
		renderCamera.enabled = false;
	}

	private void Start()
	{
		Util.ClearRenderTexture(renderCamera.targetTexture, Settings.colorBlack);
		playStartTime = -1f;
		DebugMenu.Add("Skip Dialog", KeyCode.None, delegate
		{
			if (isPlaying)
			{
				Stop();
			}
		});
	}

	public void Play(string dialogId, Extra extra = null)
	{
		spec = lib.Find(dialogId);
		if (spec == null)
		{
			Clear();
			return;
		}
		audioOnly = false;
		wantBlackFramesAfter = spec.wantBlackFramesAfter || (extra != null && extra.wantBlackFramesAfter);
		curPage = null;
		playStartTime = clock.time;
		lastPageNextTime = clock.time;
		fullscreenPanel.Reset();
		fullscreenPanel.visible = true;
		fullscreenPanel.alignment = (spec.alignTop ? TextAnchor.UpperCenter : TextAnchor.MiddleCenter);
		fullscreenPanel.wantWiggle = spec.wantWiggle;
		Monitor.BlackOut(1);
		OneBit.ShowOverlayForFrames();
		Util.ClearRenderTexture(renderCamera.targetTexture, Settings.colorBlack);
		if (useMenuClock)
		{
			Clock.menu.running = true;
			Clock.play.running = false;
		}
		Debug.Log("[Dialog] " + spec.id);
		SaveData.it.IncStat("#dia-" + spec.id);
		if (extra != null && extra.audioSource != null)
		{
			if (extra.audioClip != null)
			{
				extra.audioSource.clip = extra.audioClip;
			}
			extra.audioSource.Play();
		}
		else if (extra != null && extra.audioClip != null)
		{
			audioOneShot = AudioOneShot.Play(extra.audioClip, false, extra.audioClipVolume);
			if (!useMenuClock)
			{
				audioOneShot.gameObject.AddComponent<AudioPauseEcho>();
			}
		}
		else
		{
			if (string.IsNullOrEmpty(spec.audioFilename))
			{
				return;
			}
			AudioClip audioClip = Resources.Load<AudioClip>(spec.audioFilename);
			if (audioClip != null)
			{
				audioOneShot = AudioOneShot.Play(audioClip);
				if (!useMenuClock)
				{
					audioOneShot.gameObject.AddComponent<AudioPauseEcho>();
				}
			}
			else
			{
				Debug.LogError("Failed to load audioClip resource: " + spec.audioFilename);
			}
		}
	}

	private void Update()
	{
		if (spec == null || audioOnly)
		{
			return;
		}
		DialogLib.Page page = curPage;
		if (spec.manualPaging)
		{
			if (curPage == null)
			{
				curPage = spec.pages[0];
			}
			else if (clock.time - lastPageNextTime < 1f)
			{
				fullscreenPanel.showNext = false;
			}
			else if (RInput.GetButtonDown(4))
			{
				lastPageNextTime = clock.time;
				int num = spec.pages.IndexOf(curPage) + 1;
				if (num >= spec.pages.Count)
				{
					Stop();
					return;
				}
				curPage = spec.pages[num];
				fullscreenPanel.showNext = false;
			}
			else
			{
				fullscreenPanel.showNext = true;
			}
		}
		else
		{
			curPage = null;
			foreach (DialogLib.Page page2 in spec.pages)
			{
				if (time >= page2.startTime && time < page2.endTime)
				{
					curPage = page2;
					break;
				}
			}
			fullscreenPanel.showNext = showSkip;
			if (time > spec.duration)
			{
				audioOneShot = null;
				Stop();
				return;
			}
		}
		if (curPage != page)
		{
			if (curPage != null)
			{
				fullscreenPanel.text = curPage.GetCardText(SaveData.it.generalRo.playerGender, customString);
			}
			else
			{
				fullscreenPanel.text = string.Empty;
				fullscreenPanel.showNext = showSkip || spec.manualPaging;
			}
		}
		renderCamera.Render();
		if (Player.instance != null)
		{
			Player.instance.DisableInputForOneFrame();
		}
		if (Impatient.WantSkip("dialog"))
		{
			if (spec.id.StartsWith("d0"))
			{
				SwitchToAudioOnly();
			}
			else
			{
				Stop();
			}
		}
		OneBit.ShowOverlayForFrames(2);
	}

	public void SwitchToAudioOnly()
	{
		audioOnly = true;
		fullscreenPanel.visible = false;
		Util.ClearRenderTexture(renderCamera.targetTexture, Color.black);
	}

	public void Stop(bool quickFade = false)
	{
		if (audioOneShot != null && !audioOneShot.done)
		{
			audioOneShot.Stop((!quickFade) ? 1f : 0.1f);
			audioOneShot = null;
		}
		Clear();
		if (!audioOnly)
		{
			Util.ClearRenderTexture(renderCamera.targetTexture, Color.black);
			if (wantBlackFramesAfter)
			{
				Monitor.BlackOut(2);
			}
		}
		if (useMenuClock)
		{
			Clock.menu.running = false;
			Clock.play.running = true;
		}
	}

	private void Clear()
	{
		spec = null;
		curPage = null;
		audioOneShot = null;
		fullscreenPanel.Reset();
		fullscreenPanel.visible = false;
		playStartTime = -1f;
	}
}

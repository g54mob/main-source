using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Book))]
public class BookAnim : MonoBehaviour
{
	public delegate void Func();

	public delegate void Interp(float t);

	public enum Kind
	{
		None = 0,
		TurnPageR = 1,
		TurnPageL = 2,
		RollPageIn = 3,
		RollPageOut = 4,
		OpenPopup = 5,
		ClosePopup = 6,
		BleedIn = 7,
		PlayAudio = 8,
		StopAudio = 9,
		Open = 10,
		Close = 11,
		Drop = 12,
		Lift = 13,
		Func = 14,
		Help = 15,
		WaitForInputDuringHelp = 16
	}

	public enum PanMode
	{
		None = 0,
		LeftToRight = 1,
		RightToLeft = 2
	}

	[Serializable]
	public class Transitions
	{
		public BookTransition turnL;

		public BookTransition turnR;

		public BookTransition roll;

		public BookTransition fadeIn;

		public BookTransition bleed;

		public BookTransition open;

		public BookTransition drop;

		public BookTransition lift;
	}

	public class Atom
	{
		public Kind kind;

		public BookSpec.PageSpec pageSpec;

		public Popup popup;

		public float duration;

		public float audioFadeDuration;

		public AudioClip audioClip;

		public float volume;

		public PageItem pageItem;

		public string audioEffectId;

		public Func startFunc;

		public Func endFunc;

		public Interp interpFunc;

		public string helpMessage;

		public BookHelp.Side helpMessageSide;

		public string helpRectName;

		public float helpRectExpand;

		public Atom SetStartFunc(Func startFunc_)
		{
			startFunc = startFunc_;
			return this;
		}

		public Atom SetEndFunc(Func endFunc_)
		{
			endFunc = endFunc_;
			return this;
		}

		public Atom SetInterpFunc(Interp interpFunc_)
		{
			interpFunc = interpFunc_;
			return this;
		}
	}

	public OneBit oneBit;

	public Transitions transitions;

	public RectTransform pagesRootTransform;

	public AudioKit audioKit;

	private Book book;

	private BookTransition transition;

	private float startTime = -1f;

	private Atom atom;

	private bool reverse;

	private RenderTarget aTarget;

	private RenderTarget bTarget;

	private AudioSource audioSource;

	private PanMode panMode;

	private AudioOneShot lastAudioOneShot;

	private bool playedSingleSoundEffect;

	private int skipEverythingUntilFrame;

	public bool isPlaying
	{
		get
		{
			return startTime >= 0f;
		}
	}

	public bool skippingEverything
	{
		get
		{
			return Time.frameCount <= skipEverythingUntilFrame;
		}
	}

	public void SkipEverythingForOneFrame()
	{
		skipEverythingUntilFrame = Time.frameCount + 1;
	}

	private void Awake()
	{
		book = GetComponent<Book>();
		float num = 1f;
		aTarget = new RenderTarget(new RenderTarget.Spec(Mathf.FloorToInt(num * (float)Resolution.bufferW), Mathf.FloorToInt(num * (float)Resolution.bufferH)).InitFilterModeBilinear());
		bTarget = new RenderTarget(new RenderTarget.Spec(Mathf.FloorToInt(num * (float)Resolution.bufferW), Mathf.FloorToInt(num * (float)Resolution.bufferH)).InitFilterModeBilinear());
	}

	private void OnEnable()
	{
		aTarget.Alloc();
		bTarget.Alloc();
	}

	private void OnDisable()
	{
		aTarget.Free();
		bTarget.Free();
	}

	public void Play(Atom atom_)
	{
		atom = atom_;
		reverse = false;
		panMode = PanMode.None;
		audioSource = null;
		playedSingleSoundEffect = false;
		transition = null;
		if (atom.kind == Kind.TurnPageL)
		{
			audioSource = audioKit.Play((!(atom.duration < 0.3f)) ? "flipslow" : "flipfast");
			panMode = PanMode.LeftToRight;
			transition = transitions.turnL;
		}
		else if (atom.kind == Kind.TurnPageR)
		{
			audioSource = audioKit.Play((!(atom.duration < 0.3f)) ? "flipslow" : "flipfast");
			panMode = PanMode.RightToLeft;
			transition = transitions.turnR;
		}
		else if (atom.kind == Kind.RollPageIn)
		{
			audioSource = audioKit.Play("unroll");
			panMode = PanMode.RightToLeft;
			transition = transitions.roll;
		}
		else if (atom.kind == Kind.RollPageOut)
		{
			audioSource = audioKit.Play("roll");
			panMode = PanMode.LeftToRight;
			transition = transitions.roll;
			reverse = true;
		}
		else if (atom.kind == Kind.BleedIn)
		{
			transition = transitions.bleed;
		}
		else if (atom.kind == Kind.OpenPopup)
		{
			audioKit.Play(atom.popup.openSoundId);
		}
		else if (atom.kind == Kind.ClosePopup)
		{
			audioKit.Play(atom.popup.closeSoundId);
			reverse = true;
		}
		else
		{
			if (atom.kind == Kind.PlayAudio)
			{
				if (!skippingEverything)
				{
					if (atom.audioClip == null)
					{
						audioKit.Play(atom.audioEffectId);
					}
					else
					{
						lastAudioOneShot = AudioOneShot.Play(atom.audioClip, false, atom.volume);
					}
				}
				return;
			}
			if (atom.kind == Kind.StopAudio)
			{
				if (!(lastAudioOneShot != null))
				{
					return;
				}
				lastAudioOneShot.Stop(atom.audioFadeDuration + 0.1f);
				lastAudioOneShot = null;
			}
			else if (atom.kind == Kind.Open)
			{
				audioSource = audioKit.Play("bookopen");
				transition = transitions.open;
			}
			else if (atom.kind == Kind.Close)
			{
				transition = transitions.open;
				reverse = true;
			}
			else if (atom.kind == Kind.Drop)
			{
				transition = transitions.drop;
			}
			else if (atom.kind == Kind.Lift)
			{
				transition = transitions.lift;
			}
			else if (atom.kind != Kind.Func)
			{
				if (atom.kind == Kind.Help)
				{
					if (!skippingEverything)
					{
						book.help.PlayNextAudioClip();
						book.help.StartSegment(book.topActivePageTemplate, atom.helpMessage, atom.helpMessageSide, atom.helpRectName, atom.helpRectExpand);
					}
				}
				else if (atom.kind != Kind.WaitForInputDuringHelp)
				{
					return;
				}
			}
		}
		if (transition != null)
		{
			Vector2 anchoredPosition = pagesRootTransform.anchoredPosition;
			CaptureTransitionTexture((!reverse) ? aTarget : bTarget);
			book.OnAnimBegin(atom);
			Vector2 anchoredPosition2 = pagesRootTransform.anchoredPosition;
			CaptureTransitionTexture((!reverse) ? bTarget : aTarget);
			transition.Begin((RenderTexture)aTarget, (RenderTexture)bTarget, (!reverse) ? anchoredPosition2 : anchoredPosition);
			transition.t = (reverse ? 1 : 0);
			pagesRootTransform.gameObject.SetActive(false);
		}
		else
		{
			book.OnAnimBegin(atom);
			if (atom.popup != null)
			{
				atom.popup.revealT = (reverse ? 1 : 0);
			}
		}
		startTime = Clock.menu.time;
	}

	private void Update()
	{
		if (!isPlaying)
		{
			return;
		}
		float num = (Clock.menu.time - startTime) / atom.duration;
		if (atom.kind == Kind.WaitForInputDuringHelp && RInput.GetAnyButtonWhileMuted())
		{
			num = 1f;
		}
		if (skippingEverything)
		{
			num = 1f;
		}
		if (num < 1f)
		{
			float num2 = ((!reverse) ? num : (1f - num));
			if (transition != null)
			{
				transition.t = num2;
			}
			else if (atom.popup != null)
			{
				atom.popup.revealT = num2;
			}
			else if (atom.kind == Kind.Help)
			{
				book.help.segmentT = num;
			}
			if (atom.interpFunc != null)
			{
				atom.interpFunc(num2);
			}
			if (audioSource != null)
			{
				if (panMode == PanMode.LeftToRight)
				{
					audioSource.panStereo = 0.5f * Mathf.Lerp(-1f, 1f, num);
				}
				else if (panMode == PanMode.RightToLeft)
				{
					audioSource.panStereo = 0.5f * Mathf.Lerp(1f, -1f, num);
				}
			}
			if (atom.kind == Kind.Drop && !playedSingleSoundEffect && Util.LerpScale(num, 0f, 1f, 1f, 10f) > 1.2f)
			{
				playedSingleSoundEffect = true;
				audioKit.Play("bookdrop");
			}
		}
		else
		{
			if (transition != null)
			{
				transition.Finish();
				pagesRootTransform.gameObject.SetActive(true);
			}
			else if (atom.popup != null)
			{
				atom.popup.revealT = ((!reverse) ? 1 : 0);
			}
			else if (atom.kind == Kind.Help)
			{
				book.help.segmentT = 1f;
			}
			startTime = -1f;
			book.OnAnimEnd(atom);
		}
	}

	public bool isClosingPopup(Popup popup)
	{
		return isPlaying && atom != null && atom.kind == Kind.ClosePopup && atom.popup == popup;
	}

	public void EndInstantly()
	{
		if (isPlaying)
		{
			startTime = (0f - Clock.menu.time) * atom.duration - 1f;
			Update();
		}
	}

	private void CaptureTransitionTexture(RenderTarget target)
	{
		bool flag = book.help.isActiveAndEnabled;
		if (flag)
		{
			book.help.gameObject.SetActive(false);
			FolioNav.HideForOneFrame();
		}
		MouseCursor.HideForOneFrame();
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		Canvas.ForceUpdateCanvases();
		oneBit.RenderForTarget(target);
		if (flag)
		{
			book.help.gameObject.SetActive(flag);
		}
	}

	public void DisableAllTransitions()
	{
		transitions.turnL.Finish();
		transitions.turnR.Finish();
		transitions.roll.Finish();
		transitions.fadeIn.Finish();
		transitions.bleed.Finish();
		transitions.open.Finish();
		transitions.drop.Finish();
		transitions.lift.Finish();
	}

	public static Atom MakeClosePopup(Popup fromPopup, BookSpec.PageSpec toPageSpec)
	{
		Atom atom = new Atom();
		atom.kind = Kind.ClosePopup;
		atom.pageSpec = toPageSpec;
		atom.popup = fromPopup;
		atom.duration = fromPopup.closeDuration;
		return atom;
	}

	public static Atom MakeOpenPopup(BookSpec.PageSpec fromPageSpec, Popup toPopup)
	{
		Atom atom = new Atom();
		atom.kind = Kind.OpenPopup;
		atom.popup = toPopup;
		atom.duration = toPopup.openDuration;
		return atom;
	}

	public static Atom MakeOpenPopup(Popup fromPopup, Popup toPopup, float forceDuration = -1f)
	{
		Atom atom = new Atom();
		atom.kind = Kind.OpenPopup;
		atom.popup = toPopup;
		atom.duration = ((!(forceDuration >= 0f)) ? toPopup.openDuration : forceDuration);
		return atom;
	}

	public static Atom MakeClosePopup(Popup fromPopup, Popup toPopup, float forceDuration = -1f)
	{
		Atom atom = new Atom();
		atom.kind = Kind.ClosePopup;
		atom.popup = fromPopup;
		atom.duration = ((!(forceDuration >= 0f)) ? fromPopup.closeDuration : forceDuration);
		return atom;
	}

	public static Atom MakePlayAudio(AudioClip audioClip, float volume = 1f)
	{
		Atom atom = new Atom();
		atom.kind = Kind.PlayAudio;
		atom.audioClip = audioClip;
		atom.volume = volume;
		return atom;
	}

	public static Atom MakePlayAudio(string audioEffectId)
	{
		Atom atom = new Atom();
		atom.kind = Kind.PlayAudio;
		atom.audioEffectId = audioEffectId;
		return atom;
	}

	public static Atom MakeStopAudio(float fadeDuration, float duration = -1f)
	{
		if (duration < 0f)
		{
			duration = fadeDuration;
		}
		Atom atom = new Atom();
		atom.kind = Kind.StopAudio;
		atom.duration = duration;
		atom.audioFadeDuration = fadeDuration;
		return atom;
	}

	public static Atom MakeBleedIn(BookSpec.PageSpec pageSpec, float duration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.BleedIn;
		atom.pageSpec = pageSpec;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeFunc(Func startFunc, float duration = 0f, Func endFunc = null)
	{
		Atom atom = new Atom();
		atom.kind = Kind.Func;
		atom.startFunc = startFunc;
		atom.endFunc = endFunc;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeWait(float waitDuration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.Func;
		atom.duration = waitDuration;
		return atom;
	}

	public static Atom MakeHelp(string rectName, float rectExpand, float duration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.Help;
		atom.helpRectName = rectName;
		atom.helpRectExpand = rectExpand;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeHelp(string messageId, Manifest.Gender gender, BookHelp.Side messageSide, float duration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.Help;
		atom.helpMessage = Manifest.ApplyGender(Lang.Get(messageId), gender);
		atom.helpMessageSide = messageSide;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeHelp(string messageId, Manifest.Gender gender, BookHelp.Side messageSide, string rectName, float rectExpand, float duration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.Help;
		atom.helpMessage = Manifest.ApplyGender(Lang.Get(messageId), gender);
		atom.helpMessageSide = messageSide;
		atom.helpRectName = rectName;
		atom.helpRectExpand = rectExpand;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeWaitForInputDuringHelp(float duration)
	{
		Atom atom = new Atom();
		atom.kind = Kind.WaitForInputDuringHelp;
		atom.duration = duration;
		return atom;
	}

	public static Atom MakeChangePage(BookSpec.PageSpec fromPageSpec, BookSpec.PageSpec toPageSpec, float duration = 1f)
	{
		Kind kind = Kind.None;
		if (toPageSpec.transitionType == BookSpec.TransitionType.Instant || fromPageSpec.transitionType == BookSpec.TransitionType.Instant)
		{
			kind = Kind.Func;
		}
		else if (fromPageSpec.transitionType == BookSpec.TransitionType.Drop)
		{
			kind = Kind.Drop;
			duration = 2f;
		}
		else if (fromPageSpec.transitionType == BookSpec.TransitionType.Lift)
		{
			kind = Kind.Lift;
			duration = 0.25f;
		}
		else if (toPageSpec.transitionType == BookSpec.TransitionType.Open)
		{
			kind = Kind.Close;
			duration = 1.5f;
		}
		else if (fromPageSpec.transitionType == BookSpec.TransitionType.Turn)
		{
			kind = ((toPageSpec.transitionType != BookSpec.TransitionType.Turn) ? Kind.RollPageIn : ((fromPageSpec.index < toPageSpec.index) ? Kind.TurnPageR : Kind.TurnPageL));
		}
		else if (fromPageSpec.transitionType == BookSpec.TransitionType.Open)
		{
			kind = Kind.Open;
			duration = 1.5f;
		}
		else
		{
			kind = Kind.RollPageOut;
		}
		Atom atom = new Atom();
		atom.kind = kind;
		atom.pageSpec = toPageSpec;
		atom.duration = duration;
		return atom;
	}
}

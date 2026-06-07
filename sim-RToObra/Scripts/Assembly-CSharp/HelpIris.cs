using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpIris : MonoBehaviour
{
	public enum Kind
	{
		None = 0,
		Zoom = 1,
		ZoomBook = 2,
		WatchBook = 3,
		StartHunt = 4
	}

	private class Timer
	{
		public Kind kind;

		public string actionId;

		public int actionIndex;

		public string actionTextId;

		public float duration;

		public float charge;

		public Timer(Kind kind_, string actionId_, string actionTextId_, float duration_)
		{
			kind = kind_;
			actionId = actionId_;
			actionIndex = RInput.GetActionIndex(actionId);
			actionTextId = actionTextId_;
			duration = duration_;
		}
	}

	public OneBit oneBit;

	public Canvas canvas;

	public ActionGlyph actionGlyph;

	public Text actionText;

	public Camera canvasCamera;

	public ShuffleAudioClips audioClips;

	private Kind showingKind;

	private int showingFrame;

	private int allowChargingUntilFrame;

	private List<Timer> timers = new List<Timer>();

	private bool inLateGame;

	private bool allowCharging
	{
		get
		{
			return Time.frameCount < allowChargingUntilFrame;
		}
	}

	private void Start()
	{
		timers.Add(new Timer(Kind.Zoom, "Zoom", "control_zoom", 3f));
		timers.Add(new Timer(Kind.ZoomBook, "Manifest", "control_book_open", 5f));
		timers.Add(new Timer(Kind.WatchBook, "Manifest", "control_book_open", 3f));
		timers.Add(new Timer(Kind.StartHunt, "Action", "control_action", 20f));
		inLateGame = SaveData.it.HaveVisitedThisManyMoments(40);
	}

	private void OnDisable()
	{
		oneBit.linedSettings.preOverlayCamera = null;
	}

	private void Update()
	{
		if (showingKind != Kind.None && showingFrame < Time.frameCount - 1)
		{
			showingKind = Kind.None;
		}
		if (!inLateGame && showingKind != Kind.None)
		{
			canvas.gameObject.SetActive(true);
			canvasCamera.gameObject.SetActive(true);
			oneBit.linedSettings.preOverlayCamera = canvasCamera;
		}
		else
		{
			canvas.gameObject.SetActive(false);
			canvasCamera.gameObject.SetActive(false);
			oneBit.linedSettings.preOverlayCamera = null;
		}
	}

	private void Show(Kind kind)
	{
		Timer timer = FindTimer(kind);
		if (timer != null && (showingKind == Kind.None || showingKind <= kind))
		{
			showingKind = kind;
			showingFrame = Time.frameCount;
			actionGlyph.actionId = timer.actionId;
			actionText.text = Lang.Get(timer.actionTextId);
			actionGlyph.Refresh();
		}
	}

	private Timer FindTimer(Kind kind)
	{
		int num = (int)(kind - 1);
		return (num < 0 || num >= timers.Count) ? null : timers[num];
	}

	public void AllowChargingForOneFrame()
	{
		allowChargingUntilFrame = Time.frameCount + 2;
	}

	public bool Charge(Kind kind)
	{
		if (!allowCharging || GetSave(kind))
		{
			return false;
		}
		Timer timer = FindTimer(kind);
		if (timer == null)
		{
			return false;
		}
		if (RInput.GetButton(timer.actionIndex))
		{
			SetSave(kind, true);
			return false;
		}
		timer.charge += Clock.play.deltaTime / timer.duration;
		if (timer.charge > 1f)
		{
			Show(kind);
			return true;
		}
		return false;
	}

	public void Zero(Kind kind)
	{
		Timer timer = FindTimer(kind);
		if (timer != null)
		{
			timer.charge = 0f;
		}
	}

	public void ZeroAll()
	{
		foreach (Timer timer in timers)
		{
			timer.charge = 0f;
		}
	}

	private bool GetSave(Kind kind)
	{
		SaveData.GeneralDataRo generalRo = SaveData.it.generalRo;
		switch (kind)
		{
		case Kind.Zoom:
			return generalRo.helpedZoom;
		case Kind.ZoomBook:
			return generalRo.helpedZoomBook;
		case Kind.WatchBook:
			return generalRo.helpedWatchBook;
		case Kind.StartHunt:
			return generalRo.helpedStartHunt;
		default:
			return false;
		}
	}

	private void SetSave(Kind kind, bool v)
	{
		SaveData.GeneralData general = SaveData.it.general;
		if (kind == Kind.Zoom)
		{
			general.helpedZoom = v;
		}
	}
}

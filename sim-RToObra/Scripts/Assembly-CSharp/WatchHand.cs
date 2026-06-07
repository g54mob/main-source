using System;
using UnityEngine;
using UnityEngine.Rendering;

public class WatchHand : MonoBehaviour, AnimEventHandler.IHost
{
	public enum Mode
	{
		Exploring = 0,
		InMoment = 1
	}

	private enum State
	{
		DontHave = 0,
		JustPickedUp = 1,
		Exploring = 2,
		ExploringChargingFast = 3,
		ExploringChargingSlow = 4,
		InMoment = 5,
		InMomentCanHunt = 6,
		InMomentIncepting = 7,
		InHunt = 8,
		InHuntPulling = 9
	}

	public enum ExploringForce
	{
		None = 0,
		Up = 1,
		Down = 2
	}

	private enum Anim
	{
		Lowered = 0,
		RaisedOpen = 1,
		RaisedClosed = 2,
		ShakingOpen = 3,
		ShakingClosed = 4
	}

	public class Dial
	{
		public float hourT;

		public float minuteT;

		public float dialT
		{
			get
			{
				return hourT;
			}
			set
			{
				hourT = value;
				minuteT = value * 12f;
			}
		}

		public void SetForMoment(string momentId)
		{
			float deltaTime = Clock.play.deltaTime;
			float x = Clock.play.time % 0.5f / 0.5f;
			float num = 0.00069444446f * (Util.SmoothStepEdges(0f, 0.1f, x) - Util.SmoothStepEdges(0.5f, 0.6f, x));
			Story.Moment moment = Story.it.GetMoment(momentId);
			float num2 = moment.dialT + num;
			dialT = num2;
		}
	}

	private class DialHand
	{
		public Transform transform;

		private Quaternion originalLocalRotation;

		public DialHand(Transform root, string name)
		{
			transform = root.FindDescendant(name);
			originalLocalRotation = transform.localRotation;
		}

		public void SetT(float t)
		{
			transform.localRotation = originalLocalRotation * Quaternion.Euler(0f, t * 360f, 0f);
		}
	}

	public Mode mode;

	public GameObject hostGo;

	public Camera playerCamera;

	public AudioClip openAudioClip;

	public AudioClip closeAudioClip;

	[HideInInspector]
	public ExploringForce exploringForce;

	[HideInInspector]
	public Dial dial = new Dial();

	[Readonly]
	public HelpIris helpIris;

	[Readonly]
	public CorpseBoxFinder corpseBoxFinder;

	[NonSerialized]
	public WatchHost host;

	private Quaternion laggedRotation;

	private float laggedLocalPositionT;

	private Vector3 prevPlayerPosition;

	private AnimationCurve movingDropCurve;

	private Animator animator;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	private AudioSource openAudioSource;

	private AudioSource closeAudioSource;

	private Transform watchRootTransform;

	private DialHand hourDialHand;

	private DialHand minuteDialHand;

	private float shakeT;

	private bool forceVisible;

	private float startTime;

	private bool exploringChargingOpened;

	private bool playerJustRestoredFromMoment;

	private Stater<State> stater;

	private Transform dialTransform_;

	private bool visible_ = true;

	private static bool showDebugInGame;

	private State state
	{
		get
		{
			return stater.curStateId;
		}
	}

	public Vector3 curtainCenterWorldPos
	{
		get
		{
			return watchRootTransform.position;
		}
	}

	public bool isNearCorpse
	{
		get
		{
			return corpseBoxFinder.found != null;
		}
	}

	public Transform dialTransform
	{
		get
		{
			if (dialTransform_ == null)
			{
				dialTransform_ = base.transform.FindDescendant("watch_hour");
			}
			return dialTransform_;
		}
	}

	public string nearbyCorpseMomentId
	{
		get
		{
			return (!(corpseBoxFinder.found != null)) ? null : corpseBoxFinder.found.visitMomentId;
		}
	}

	public bool inHunt
	{
		get
		{
			return host != null && host.inHunt;
		}
	}

	public bool visible
	{
		get
		{
			return visible_;
		}
		set
		{
			visible_ = value;
			skinnedMeshRenderer.enabled = value;
		}
	}

	private Anim anim
	{
		get
		{
			bool flag = animator.GetBool("Raised");
			bool flag2 = animator.GetBool("Open");
			bool flag3 = animator.GetBool("Shaking");
			if (flag)
			{
				if (flag3)
				{
					return (!flag2) ? Anim.ShakingClosed : Anim.ShakingOpen;
				}
				return flag2 ? Anim.RaisedOpen : Anim.RaisedClosed;
			}
			return Anim.Lowered;
		}
		set
		{
			bool value2 = false;
			bool value3 = false;
			bool value4 = false;
			switch (value)
			{
			case Anim.RaisedClosed:
				value2 = true;
				break;
			case Anim.RaisedOpen:
				value2 = true;
				value3 = true;
				break;
			case Anim.ShakingClosed:
				value2 = true;
				value4 = true;
				break;
			case Anim.ShakingOpen:
				value2 = true;
				value4 = true;
				value3 = true;
				break;
			}
			animator.SetBool("Raised", value2);
			animator.SetBool("Open", value3);
			animator.SetBool("Shaking", value4);
		}
	}

	private void OnEnable()
	{
		if (!SaveData.it.HaveWatchAndBook())
		{
			SaveData.it.onInventoryReceived.AddListener(OnInventoryReceived);
		}
	}

	private void OnDisable()
	{
		SaveData.it.onInventoryReceived.RemoveListener(OnInventoryReceived);
	}

	private void Start()
	{
		host = hostGo.GetComponent<WatchHost>();
		laggedRotation = playerCamera.transform.rotation;
		prevPlayerPosition = base.transform.parent.position;
		laggedLocalPositionT = 0f;
		float num = 1f;
		float num2 = 10f;
		movingDropCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.2f, 0f - num), new Keyframe(0.8f, num2 + num), new Keyframe(1f, num2));
		SkinnedMeshRenderer[] componentsInChildren = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			this.skinnedMeshRenderer = skinnedMeshRenderer;
			this.skinnedMeshRenderer.updateWhenOffscreen = true;
			this.skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
		Collider[] componentsInChildren2 = GetComponentsInChildren<Collider>();
		foreach (Collider obj in componentsInChildren2)
		{
			UnityEngine.Object.Destroy(obj);
		}
		Zoomer component = playerCamera.GetComponent<Zoomer>();
		if ((bool)component)
		{
			component.watchHand = this;
		}
		animator = GetComponentInChildren<Animator>();
		animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		AnimEventHandler.Attach(animator.gameObject, this);
		openAudioSource = base.gameObject.AddComponent<AudioSource>();
		openAudioSource.volume = 0.25f;
		closeAudioSource = base.gameObject.AddComponent<AudioSource>();
		closeAudioSource.volume = 0.25f;
		watchRootTransform = base.transform.FindDescendant("watch_root");
		hourDialHand = new DialHand(watchRootTransform, "watch_hour");
		minuteDialHand = new DialHand(watchRootTransform, "watch_minute");
		startTime = Clock.play.time;
		CreateStater();
		if (mode == Mode.Exploring)
		{
			if (SaveData.it.HaveWatchAndBook())
			{
				if (SaveData.it.generalRo.justFinishedMoment)
				{
					playerJustRestoredFromMoment = true;
					anim = Anim.RaisedOpen;
					animator.Play("OpenRaised");
					dial.SetForMoment(SaveData.it.generalRo.lastVisitedMomentId);
				}
				else
				{
					anim = Anim.Lowered;
					animator.Play("ClosedLowered");
				}
				stater.Go(State.Exploring);
			}
			else
			{
				stater.Go(State.DontHave);
			}
		}
		else if (mode == Mode.InMoment)
		{
			anim = Anim.Lowered;
			stater.Go(State.InMoment);
		}
		DebugMenu.Add("Show/CorpseBoxes", KeyCode.None, delegate
		{
			showDebugInGame = !showDebugInGame;
		});
	}

	private void CreateStater()
	{
		stater = new Stater<State>("WatchHand");
		stater.AddState(State.DontHave);
		stater.AddState(State.JustPickedUp).SetDurations(0f, 3f, State.Exploring).AddFunc(StaterFunc.ENTER(delegate
		{
			anim = Anim.RaisedClosed;
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				anim = Anim.Lowered;
				startTime = Clock.play.time;
			}));
		stater.AddState(State.Exploring).AddFunc(StaterFunc.ENTER(delegate
		{
			exploringChargingOpened = false;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (exploringForce == ExploringForce.Up)
			{
				anim = Anim.RaisedClosed;
			}
			else if (exploringForce == ExploringForce.Down)
			{
				anim = Anim.Lowered;
			}
			else if (corpseBoxFinder.Search())
			{
				Book.bootRequest.watchNearMomentId = corpseBoxFinder.found.visitMomentId;
				bool flag = SaveData.it.HaveVisitedMoment(corpseBoxFinder.found.visitMomentId);
				if (flag)
				{
					bool momentHasLockedPullableCorpseInside = SaveData.it.GetMomentHasLockedPullableCorpseInside(corpseBoxFinder.found.visitMomentId);
					dial.SetForMoment(corpseBoxFinder.found.visitMomentId);
					anim = ((!momentHasLockedPullableCorpseInside) ? Anim.RaisedOpen : Anim.ShakingOpen);
					if (helpIris != null && SaveData.it.HaveVisitedThisManyMoments(2))
					{
						helpIris.Charge(HelpIris.Kind.WatchBook);
					}
				}
				else
				{
					anim = Anim.RaisedClosed;
				}
				if ((!playerJustRestoredFromMoment || (!(Clock.play.time - startTime < 2f) && !Monitor.blackingOut && Clock.play.running)) && RInput.GetButtonDown(4))
				{
					stater.Go((!flag) ? State.ExploringChargingSlow : State.ExploringChargingFast);
				}
			}
			else
			{
				anim = Anim.Lowered;
				if (helpIris != null)
				{
					helpIris.Zero(HelpIris.Kind.WatchBook);
				}
			}
		}))
			.AddFunc(StaterFunc.ON_TRIGGER("event-opened", delegate
			{
				exploringChargingOpened = true;
			}))
			.AddFunc(StaterFunc.ON_TRIGGER("event-closed", delegate
			{
				exploringChargingOpened = false;
			}));
		stater.AddState(State.ExploringChargingFast).AddFunc(StaterFunc.ENTER(delegate
		{
			exploringChargingOpened = false;
			anim = Anim.RaisedOpen;
			host.StartEnterMoment(corpseBoxFinder.found.visitMomentId, true);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Player.instance.DisableMovementForOneFrame();
		}));
		stater.AddState(State.ExploringChargingSlow).AddFunc(StaterFunc.ENTER(delegate
		{
			exploringChargingOpened = false;
			anim = Anim.RaisedOpen;
			dial.dialT = 0f;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Player.instance.DisableMovementForOneFrame();
			if (exploringChargingOpened && anim == Anim.RaisedOpen && RInput.GetButtonDown(4))
			{
				anim = Anim.RaisedClosed;
			}
		}))
			.AddFunc(StaterFunc.ON_TRIGGER("event-opened", delegate
			{
				exploringChargingOpened = true;
				if (corpseBoxFinder.found != null)
				{
					host.StartEnterMoment(corpseBoxFinder.found.visitMomentId, false);
				}
			}))
			.AddFunc(StaterFunc.ON_TRIGGER("event-closed", delegate
			{
				host.CancelEnterMoment();
				stater.Go(State.Exploring);
			}));
		stater.AddState(State.InMoment).AddFunc(StaterFunc.STEP(delegate
		{
			if (host.canHunt)
			{
				stater.Go(State.InMomentCanHunt);
			}
			else if (corpseBoxFinder.Search(CorpseBoxFinder.Filter.OnlyCanVisit))
			{
				bool momentHasLockedPullableCorpseInside = SaveData.it.GetMomentHasLockedPullableCorpseInside(corpseBoxFinder.found.visitMomentId);
				anim = ((!momentHasLockedPullableCorpseInside) ? Anim.RaisedOpen : Anim.ShakingOpen);
				Book.bootRequest.watchNearMomentId = corpseBoxFinder.found.visitMomentId;
				dial.SetForMoment(corpseBoxFinder.found.visitMomentId);
				if (RInput.GetButtonDown(4))
				{
					stater.Go(State.InMomentIncepting);
				}
			}
			else
			{
				anim = Anim.Lowered;
			}
		}));
		stater.AddState(State.InMomentCanHunt).AddFunc(StaterFunc.STEP(delegate
		{
			if (host.inHunt)
			{
				stater.Go(State.InHunt);
			}
			else
			{
				anim = Anim.ShakingClosed;
				if (stater.stateTime > 1f)
				{
					if (RInput.GetButtonDown(4))
					{
						SaveData.it.general.helpedStartHunt = true;
						host.StartHunt();
					}
					else if (helpIris != null)
					{
						helpIris.Charge(HelpIris.Kind.StartHunt);
					}
				}
			}
		}));
		stater.AddState(State.InMomentIncepting).AddFunc(StaterFunc.ENTER(delegate
		{
			anim = Anim.ShakingOpen;
			host.StartInception(corpseBoxFinder.found);
		}));
		stater.AddState(State.InHunt).AddFunc(StaterFunc.STEP(delegate
		{
			if (host.inHunt && corpseBoxFinder.Search(CorpseBoxFinder.Filter.OnlyLocked))
			{
				anim = Anim.RaisedOpen;
				if (RInput.GetButtonDown(4) || stater.stateTime < 0.5f)
				{
					stater.Go(State.InHuntPulling);
				}
			}
			else
			{
				anim = Anim.Lowered;
			}
		}));
		stater.AddState(State.InHuntPulling).AddFunc(StaterFunc.ENTER(delegate
		{
			anim = Anim.ShakingOpen;
			host.StartPullCorpse(corpseBoxFinder.found);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (corpseBoxFinder.found.alreadyUnlocked)
			{
				anim = Anim.Lowered;
			}
			if (host.inHunt)
			{
				stater.Go(State.InHunt);
			}
		}));
	}

	private void OnInventoryReceived(string inventoryId)
	{
		if (inventoryId == "watch")
		{
			stater.Go(State.JustPickedUp);
		}
	}

	private void Update()
	{
		Book.bootRequest.watchNearMomentId = null;
		if (visible)
		{
			stater.Step(Clock.play.deltaTime);
			if (showDebugInGame)
			{
				corpseBoxFinder.DrawDebug();
			}
		}
	}

	public void OnAnimEvent(string id)
	{
		if (!visible)
		{
			return;
		}
		if (id == "open")
		{
			if (Clock.play.time - startTime > 1f)
			{
				openAudioSource.PlayOneShot(openAudioClip);
			}
			stater.Trigger("event-opened");
		}
		else if (id == "close")
		{
			if (Clock.play.time - startTime > 1f && exploringForce == ExploringForce.None)
			{
				closeAudioSource.PlayOneShot(closeAudioClip);
			}
			stater.Trigger("event-closed");
		}
	}

	private void LateUpdate()
	{
		if (visible)
		{
			float num = playerCamera.transform.rotation.eulerAngles.x;
			if (num > 180f)
			{
				num -= 360f;
			}
			float t = Util.LerpScale(num, 60f, -60f, 0.75f, 1.25f);
			Quaternion b = Util.LerpNoClamp(base.transform.parent.rotation, playerCamera.transform.rotation, t);
			float input = Quaternion.Angle(laggedRotation, b);
			if (Clock.play.time - startTime < 1f)
			{
				laggedRotation = b;
			}
			else
			{
				laggedRotation = Quaternion.Lerp(laggedRotation, b, Util.LerpScale(input, 20f, 90f, 0.15f, 1f));
			}
			base.transform.rotation = laggedRotation;
			bool flag = Vector3.Distance(prevPlayerPosition, base.transform.parent.position) > 0.0001f;
			prevPlayerPosition = base.transform.parent.position;
			float b2 = (flag ? 1 : 0);
			laggedLocalPositionT = Mathf.Lerp(laggedLocalPositionT, b2, (!flag) ? 0.025f : 0.05f);
			Anim anim = this.anim;
			if ((anim == Anim.ShakingClosed || anim == Anim.ShakingOpen) && mode == Mode.InMoment)
			{
				shakeT = Mathf.Min(1f, shakeT + Clock.play.deltaTime);
			}
			else
			{
				shakeT = Mathf.Max(0f, shakeT - Clock.play.deltaTime);
			}
			Vector3 vector = shakeT * 0.25f * new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1));
			base.transform.localRotation = base.transform.localRotation * Quaternion.Euler(vector + new Vector3(movingDropCurve.Evaluate(laggedLocalPositionT), (0f - movingDropCurve.Evaluate(laggedLocalPositionT)) * 0.5f, (0f - movingDropCurve.Evaluate(laggedLocalPositionT)) * 0.5f));
			bool flag2 = !animator.GetCurrentAnimatorStateInfo(0).IsName("ClosedHidden") && !animator.GetCurrentAnimatorStateInfo(0).IsName("OpenHidden");
			skinnedMeshRenderer.enabled = flag2;
			hourDialHand.SetT(dial.hourT);
			minuteDialHand.SetT(dial.minuteT);
		}
	}

	public void Hide()
	{
		base.enabled = false;
		skinnedMeshRenderer.gameObject.SetActive(false);
	}

	public void UnHide()
	{
		base.enabled = true;
		skinnedMeshRenderer.gameObject.SetActive(true);
	}
}

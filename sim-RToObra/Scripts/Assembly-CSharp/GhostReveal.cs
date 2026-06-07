using System.Collections.Generic;
using UnityEngine;

public class GhostReveal : MonoBehaviour
{
	private enum State
	{
		Off = 0,
		WaitingToLaunchTrail = 1,
		TrailInFlight = 2,
		MeshInFlight = 3,
		Done = 4
	}

	private class InitResult
	{
		public bool ok;

		public bool turnOn;

		public string message;

		public static InitResult Error(string m)
		{
			InitResult initResult = new InitResult();
			initResult.ok = false;
			initResult.message = m;
			return initResult;
		}

		public static InitResult OkOn()
		{
			InitResult initResult = new InitResult();
			initResult.ok = true;
			initResult.turnOn = true;
			return initResult;
		}

		public static InitResult OkOff()
		{
			InitResult initResult = new InitResult();
			initResult.ok = true;
			return initResult;
		}
	}

	public VaporEmit vaporEmit;

	public VaporTrail vaporTrail;

	public VaporMesh[] vaporMeshes;

	public GameObject pathsRoot;

	public SoundEnviron soundEnviron;

	public AudioClip pulseAudioClip;

	[Readonly]
	public List<Corpse> allCorpsesInLevel;

	[Readonly]
	public Player player;

	private AudioSource pulseAudioSource0;

	private AudioSource pulseAudioSource1;

	private int pulseAudioIndex;

	private float pulseCountdown;

	private float kPulseDuration = 2f;

	private float startTime;

	private List<Corpse> corpses;

	private string revealingMomentId;

	private Stater<State> stater;

	private void Start()
	{
		InitResult initResult = Init();
		if (initResult.ok)
		{
			base.enabled = initResult.turnOn;
			Monitor.BlackOut(20);
		}
		else
		{
			Debug.Log("GhostReveal init failed: " + initResult.message);
			base.enabled = false;
		}
	}

	private InitResult Init()
	{
		string lastVisitedMomentId = SaveData.it.general.lastVisitedMomentId;
		VaporTrailPath vaporTrailPath = FindPath(pathsRoot, lastVisitedMomentId);
		if (vaporTrailPath == null)
		{
			return InitResult.OkOff();
		}
		SaveData.MomentDataRo momentDataRo = SaveData.it.momentRo[lastVisitedMomentId];
		if (momentDataRo.revealedGhosts)
		{
			return InitResult.OkOff();
		}
		revealingMomentId = lastVisitedMomentId;
		corpses = new List<Corpse>();
		for (int i = 0; i < vaporTrailPath.stops.Count; i++)
		{
			string crewId = vaporTrailPath.stops[i].crewId;
			Corpse corpse = FindCorpse("body_" + crewId);
			if (corpse == null)
			{
				return InitResult.Error("Corpse not found: body_" + crewId);
			}
			vaporMeshes[i].CreateMesh(corpse.gameObject, vaporTrailPath.points[vaporTrailPath.stops[i].pointIndex]);
			corpses.Add(corpse);
			if (!vaporTrailPath.stops[i].inceptiveHost)
			{
				corpse.gameObject.SetActive(false);
			}
		}
		vaporTrail.SetPath(vaporTrailPath);
		vaporEmit.source = player.watchDialTransform;
		vaporEmit.driftTarget = vaporTrail.launchTriggerPos;
		vaporEmit.emitting = true;
		pulseAudioSource0 = base.gameObject.AddComponent<AudioSource>();
		pulseAudioSource0.clip = pulseAudioClip;
		pulseAudioSource0.volume = 0.25f;
		pulseAudioSource1 = base.gameObject.AddComponent<AudioSource>();
		pulseAudioSource1.clip = pulseAudioClip;
		pulseAudioSource1.volume = 0.25f;
		pulseAudioIndex = 0;
		pulseCountdown = 0.5f;
		startTime = Clock.play.time;
		soundEnviron.DuckForOneFrame(true);
		Player.instance.DisableMovementForOneFrame();
		Debug.Log("GhostReveal revealing " + revealingMomentId);
		CreateStater();
		stater.Go(State.WaitingToLaunchTrail);
		return InitResult.OkOn();
	}

	private string ExtractTail(string str, string separator)
	{
		if (str == null)
		{
			return null;
		}
		int num = str.LastIndexOf(separator);
		if (num >= 0)
		{
			return str.Substring(num + 1);
		}
		return null;
	}

	private Corpse FindCorpse(string name)
	{
		foreach (Corpse item in allCorpsesInLevel)
		{
			if (item.isActiveAndEnabled && item.name == name)
			{
				return item;
			}
		}
		return null;
	}

	private static VaporTrailPath FindPath(GameObject pathsRoot, string pathName)
	{
		if (pathsRoot == null)
		{
			return null;
		}
		Transform transform = pathsRoot.transform.Find(pathName);
		if (transform == null)
		{
			return null;
		}
		return transform.GetComponent<VaporTrailPath>();
	}

	private void CreateStater()
	{
		stater = new Stater<State>("GhostReveal");
		stater.AddState(State.Off);
		stater.AddState(State.WaitingToLaunchTrail).AddFunc(StaterFunc.STEP(delegate
		{
			player.DisableMovementForOneFrame();
			player.SetGhostReveal(WatchHand.ExploringForce.Up);
			UpdatePulseAudio();
			soundEnviron.DuckForOneFrame();
			if (Clock.play.time - startTime > 1f && RInput.GetButtonDown(4))
			{
				vaporEmit.emitting = false;
				vaporTrail.Launch(vaporEmit.source.position);
				stater.Go(State.TrailInFlight);
			}
		}));
		stater.AddState(State.TrailInFlight).AddFunc(StaterFunc.ENTER(delegate
		{
			player.SetGhostReveal(WatchHand.ExploringForce.Down);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			soundEnviron.DuckForOneFrame();
			int num = 0;
			for (int i = 0; i < corpses.Count; i++)
			{
				Corpse corpse = corpses[i];
				VaporMesh vaporMesh = vaporMeshes[i];
				if (vaporTrail.reachedBodyIndex >= i)
				{
					if (!vaporMesh.launched)
					{
						vaporMesh.Launch();
					}
					else if (vaporMesh.completelyCoveringBody)
					{
						corpse.gameObject.SetActive(true);
					}
				}
				if (vaporMesh.launched && !vaporMesh.inFlight)
				{
					num++;
				}
			}
			if (num == corpses.Count)
			{
				stater.Go(State.Done);
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				player.SetGhostReveal(WatchHand.ExploringForce.None);
				SaveData.it.moment[revealingMomentId].revealedGhosts = true;
				Game.SaveActive();
			}));
		stater.AddState(State.Done);
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
	}

	private void UpdatePulseAudio()
	{
		if (!(revealingMomentId == "d040-merm-m00-pass8") || SaveData.it.disaster["d040"].revealedDisappearancesInBook)
		{
			pulseCountdown -= Clock.play.deltaTime;
			if (pulseCountdown <= 0f)
			{
				pulseCountdown = kPulseDuration;
				AudioSource audioSource = ((pulseAudioIndex != 0) ? pulseAudioSource1 : pulseAudioSource0);
				audioSource.Stop();
				audioSource.Play();
				pulseAudioIndex = 1 - pulseAudioIndex;
			}
		}
	}
}

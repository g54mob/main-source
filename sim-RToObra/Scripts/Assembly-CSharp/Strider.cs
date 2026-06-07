using System;
using System.Collections.Generic;
using UnityEngine;

public class Strider : MonoBehaviour
{
	[Serializable]
	public class SurfaceSpec
	{
		public string id;

		public List<AudioClip> stepClips = new List<AudioClip>();

		public List<AudioClip> creakClips = new List<AudioClip>();

		private ShuffledSequence stepShuffled;

		private ShuffledSequence creakShuffled;

		public float defaultVolume
		{
			get
			{
				return (!(id == "default")) ? 0.9f : 0.65f;
			}
		}

		public bool hasStep
		{
			get
			{
				return stepClips.Count != 0;
			}
		}

		public bool hasCreak
		{
			get
			{
				return creakClips.Count != 0;
			}
		}

		public AudioClip nextStepClip
		{
			get
			{
				return stepClips[stepShuffled.next];
			}
		}

		public AudioClip nextCreakClip
		{
			get
			{
				return creakClips[creakShuffled.next];
			}
		}

		public void Start()
		{
			stepShuffled = new ShuffledSequence(stepClips.Count);
			creakShuffled = new ShuffledSequence(creakClips.Count);
		}
	}

	private class Params
	{
		public Vector2 centerL;

		public Vector2 centerR;

		public Vector2 leanL;

		public Vector2 leanR;

		public Vector2 intercept;

		public Params()
		{
		}

		public Params(Foot footL, Foot footR, bool useRadiusMax = false)
		{
			Set(footL, footR, useRadiusMax);
		}

		public void Set(Foot footL, Foot footR, bool useRadiusMax = false)
		{
			float num = 2f;
			centerL = new Vector2((0f - num) * 0.5f, 0f);
			centerR = new Vector2(num * 0.5f, 0f);
			float num2 = ((!useRadiusMax) ? footL.radius : footL.radiusMax);
			float num3 = ((!useRadiusMax) ? footR.radius : footR.radiusMax);
			leanL = centerL + num2 * footL.lean;
			leanR = centerR + num3 * footR.lean;
			intercept = new Vector2(0f, Mathf.Min(leanL.y - footL.leanRestY, leanR.y - footR.leanRestY));
		}
	}

	public GameObject footstepZonesRoot;

	public List<SurfaceSpec> surfaceSpecs;

	[NonSerialized]
	public float volume = 1f;

	private AudioSource footAudioSourceL;

	private AudioSource footAudioSourceR;

	private AudioSource creakAudioSource;

	private float nextCreakPlayTime;

	private Foot footL = new Foot(true);

	private Foot footR = new Foot(false);

	private Vector3 position = default(Vector3);

	private SurfaceSpec surfaceSpec;

	private Vector3 footOffset;

	private Zone[] footstepZones;

	private Dictionary<string, SurfaceSpec> surfaceSpecDict;

	private Util.History debugOffsetHistory;

	private int silenceCountdown;

	private Params headMotionParams = new Params();

	private Vector3 characterPos
	{
		get
		{
			Vector3 vector = base.transform.position;
			return new Vector3(vector.x, 3f * vector.y, vector.z);
		}
	}

	private void Start()
	{
		footL = new Foot(true);
		footR = new Foot(false);
		position = characterPos;
		surfaceSpecDict = new Dictionary<string, SurfaceSpec>();
		foreach (SurfaceSpec surfaceSpec in surfaceSpecs)
		{
			surfaceSpec.Start();
			surfaceSpecDict.Add(surfaceSpec.id, surfaceSpec);
		}
		if (!surfaceSpecDict.TryGetValue("default", out this.surfaceSpec))
		{
			this.surfaceSpec = new SurfaceSpec();
			this.surfaceSpec.id = "default";
			surfaceSpecDict.Add("default", this.surfaceSpec);
		}
		footAudioSourceL = base.gameObject.AddComponent<AudioSource>();
		footAudioSourceL.panStereo = -0.1f;
		footAudioSourceR = base.gameObject.AddComponent<AudioSource>();
		footAudioSourceR.panStereo = 0.1f;
		creakAudioSource = base.gameObject.AddComponent<AudioSource>();
		footOffset = new Vector3(0f, -0.5f * GetComponent<WalkwayMotor>().height, 0f);
		footstepZones = ((!(footstepZonesRoot != null)) ? null : footstepZonesRoot.GetComponentsInChildren<Zone>());
		nextCreakPlayTime = Clock.play.time + (float)UnityEngine.Random.Range(2, 6);
		silenceCountdown = 4;
	}

	public void SilenceForOneFrame()
	{
		silenceCountdown = 2;
	}

	private void Update()
	{
		if (HeadMotion.instance != null)
		{
			headMotionParams.Set(footL, footR);
			float num = headMotionParams.intercept.y * 0.1f;
			if (num < 0.0005f)
			{
				num = 0f;
			}
			HeadMotion.instance.SetOffset(HeadMotion.Id.FromWalk, new Vector3(0f, num, 0f));
		}
		if (footstepZones == null)
		{
			return;
		}
		surfaceSpec = null;
		Vector3 footPos = GetFootPos();
		Zone[] array = footstepZones;
		foreach (Zone zone in array)
		{
			if (zone.Contains(footPos) && surfaceSpecDict.ContainsKey(zone.id))
			{
				surfaceSpec = surfaceSpecDict[zone.id];
				break;
			}
		}
		if (surfaceSpec == null)
		{
			surfaceSpec = surfaceSpecDict["default"];
		}
	}

	private void FixedUpdate()
	{
		if (silenceCountdown != 0)
		{
			silenceCountdown--;
			position = characterPos;
		}
		float distanceTraveled = Vector3.Distance(position, characterPos);
		position = characterPos;
		footL.UpdateMaster(distanceTraveled);
		footR.UpdateSlave(footL, distanceTraveled);
		if (footL.footJustDown)
		{
			OnFootDown(true);
		}
		if (footR.footJustDown)
		{
			OnFootDown(false);
		}
	}

	private Vector3 GetFootPos()
	{
		return base.transform.position + footOffset;
	}

	private void OnFootDown(bool left)
	{
		if (silenceCountdown != 0 || volume < 0.0001f)
		{
			return;
		}
		if (left)
		{
			footAudioSourceL.volume = footL.soundVolume * surfaceSpec.defaultVolume * volume;
			if (surfaceSpec.hasStep)
			{
				footAudioSourceL.PlayOneShot(surfaceSpec.nextStepClip);
			}
		}
		else
		{
			footAudioSourceR.volume = footR.soundVolume * surfaceSpec.defaultVolume * volume;
			if (surfaceSpec.hasStep)
			{
				footAudioSourceR.PlayOneShot(surfaceSpec.nextStepClip);
			}
		}
		if (Clock.play.time > nextCreakPlayTime)
		{
			if (surfaceSpec.hasCreak)
			{
				creakAudioSource.PlayOneShot(surfaceSpec.nextCreakClip, volume);
			}
			nextCreakPlayTime = Clock.play.time + (float)UnityEngine.Random.Range(2, 6);
		}
	}

	public void Play(bool left, float volumeScale)
	{
		if (left)
		{
			footAudioSourceL.PlayOneShot(surfaceSpec.nextStepClip, volumeScale);
		}
		else
		{
			footAudioSourceR.PlayOneShot(surfaceSpec.nextStepClip, volumeScale);
		}
	}

	public void DrawDebug(DebugDrawer dd, Rect spaceRect)
	{
		dd.FillRect(Color.black, spaceRect);
		Params obj = new Params(footL, footR, true);
		dd.DrawCircle(Color.white, obj.centerL, footL.radiusMax + dd.ToSpace(2f));
		dd.DrawCircle((!footL.footDown) ? Color.white : Color.red, obj.centerL, footL.radiusMax, footL.plantedAngle0, footL.plantedAngle1);
		dd.DrawCircle(Color.white, obj.centerR, footR.radiusMax + dd.ToSpace(2f));
		dd.DrawCircle((!footR.footDown) ? Color.white : Color.red, obj.centerR, footR.radiusMax, footR.plantedAngle0, footR.plantedAngle1);
		dd.DrawLine(Color.white, obj.leanL, obj.leanR);
		dd.DrawCircle(Color.white, obj.intercept, 0.1f);
		dd.DrawLine(Color.white, new Vector2(obj.centerL.x - footL.radiusMax, obj.centerL.y + Mathf.Lerp(0f - footL.radiusMax, footL.radiusMax, footL.soundVolume)), new Vector2(obj.centerL.x + footL.radiusMax, obj.centerL.y + Mathf.Lerp(0f - footL.radiusMax, footL.radiusMax, footL.soundVolume)));
		dd.DrawLine(Color.white, new Vector2(obj.centerR.x - footR.radiusMax, obj.centerR.y + Mathf.Lerp(0f - footR.radiusMax, footR.radiusMax, footR.soundVolume)), new Vector2(obj.centerR.x + footR.radiusMax, obj.centerR.y + Mathf.Lerp(0f - footR.radiusMax, footR.radiusMax, footR.soundVolume)));
	}
}

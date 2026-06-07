using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class AkTimelineRtpcPlayableBehaviour : PlayableBehaviour
{
	[SerializeField]
	private float value;

	public RTPC RTPC { get; set; }

	public bool setGlobally { get; set; }

	public GameObject gameObject { get; set; }

	public override void ProcessFrame(Playable playable, FrameData frameData, object playerData)
	{
	}
}

using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UMA.Timeline
{
	[Serializable]
	public class UmaRaceBehaviour : PlayableBehaviour
	{
		public string raceToChangeTo;

		[HideInInspector]
		public bool isAdded;

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}
	}
}

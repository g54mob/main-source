using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Audio
{
	[RequireComponent(typeof(PlaySEElement))]
	public class PlaySEByTiming : MonoBehaviour
	{
		public enum Timing
		{
			Awake = 0,
			Start = 1,
			Enable = 2,
			Disable = 3,
			Destroy = 4
		}

		[Serializable]
		public class SeTimingInfo
		{
			public Timing timing;

			public UnityEvent action;
		}

		public List<SeTimingInfo> timingInfoList;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}

		private void PlayTimigSE(Timing timing)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using AK.Wwise;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class MultiPositionSound : MonoBehaviour
	{
		public class MultiPositionSource
		{
			public uint EventId;

			public uint PlayingId;

			public GameObject Source;

			public List<MultiPositionSound> Emitters;

			public void FinishedPlaying(object in_cookie, AkCallbackType in_type, object in_info)
			{
			}
		}

		private static Dictionary<uint, MultiPositionSource> _multiPositionSources;

		public AK.Wwise.Event EventData;

		private Buildable _attachedBuildable;

		private static AkPositionArray BuildMultiDirectionArray(MultiPositionSource eventPosList)
		{
			return null;
		}

		public static void RefreshPositions(uint id)
		{
		}

		public void RefreshPositions()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void PlaySound()
		{
		}

		private void StopSound()
		{
		}

		private void OnEnable()
		{
		}

		private void OnRepositioned(object sender, EventArgs e)
		{
		}

		private void OnEditing(object sender, EventArgs e)
		{
		}

		private void OnDisable()
		{
		}
	}
}

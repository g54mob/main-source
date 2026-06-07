using System;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using UnityEngine;

namespace ModApi.Automation
{
	public interface IAutoPilot : IDisposable
	{
		int MaxPitchPidRange { get; set; }

		int MaxRollPidRange { get; set; }

		Vector3 PidGainsGrav { get; set; }

		Vector3 PidGainsPitch { get; set; }

		Vector3 PidGainsRoll { get; set; }

		void Initialize(ICommandPodScript commandPod);

		void Initialize(ICommandPodScript commandPod, IAutoPilot source);

		void Update(bool enabled, FlightFrameData frame);
	}
}

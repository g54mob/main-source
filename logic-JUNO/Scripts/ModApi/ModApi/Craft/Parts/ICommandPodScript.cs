using System;
using System.Collections.Generic;
using ModApi.Automation;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface ICommandPodScript
	{
		List<string> ActivationGroupNames { get; }

		IAutoPilot AutoPilot { get; }

		IFuelSource BatteryFuelSource { get; set; }

		CraftControls Controls { get; }

		ICraftConfiguration CraftConfiguration { get; }

		int CurrentStage { get; }

		Func<int, bool> GetStageActivationPermission { get; set; }

		IFuelSource JetFuelSource { get; set; }

		IFuelSource MonoFuelSource { get; set; }

		int NumStages { get; }

		PartData Part { get; }

		Transform PilotSeatOrientation { get; }

		event ActivationGroupChangedHandler ActivationGroupChanged;

		event ControlsChangedHandler ControlsChanged;
	}
}

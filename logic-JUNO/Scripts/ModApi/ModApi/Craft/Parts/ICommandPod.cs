using System.Collections.Generic;
using ModApi.Automation;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface ICommandPod
	{
		List<string> ActivationGroupNames { get; }

		IAutoPilot AutoPilot { get; }

		bool AutoRecalculateStages { get; set; }

		IFuelSource BatteryFuelSource { get; }

		CraftControls Controls { get; }

		ICraftConfiguration CraftConfiguration { get; }

		int CurrentStage { get; }

		IEvaScript EvaScript { get; }

		bool IsEva { get; }

		bool IsPlayerControlled { get; }

		IFuelSource JetFuelSource { get; }

		IFuelSource MonoFuelSource { get; }

		int NumStages { get; }

		PartData Part { get; }

		Transform PilotSeatOrientation { get; }

		ActivationGroupReplicationMode ReplicateActivationGroups { get; set; }

		bool ReplicateControls { get; set; }

		bool ReplicateStageActivations { get; set; }

		int StageCalculationVersion { get; set; }

		bool SupressSwitchedToCraftMessage { get; set; }

		event ActivationGroupChangedHandler ActivationGroupChanged;

		event ControlsChangedHandler ControlsChanged;

		event CommandPodIsPlayerControlledHandler IsPlayerControlledChanged;

		event StageActivatedHandler StageActivated;

		void ActivateStage();

		bool GetActivationGroupState(int activationGroup);

		void SetActivationGroupState(int activationGroup, bool state);

		void SetAutopilotEmulation(ICommandPod commandPodToEmulate);

		void SetPilotSeatRotation(Vector3 eulerAngles, bool updatePartData);
	}
}

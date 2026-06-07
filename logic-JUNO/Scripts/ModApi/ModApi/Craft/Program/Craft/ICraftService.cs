using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface ICraftService
	{
		ICraftScript CraftScript { get; }

		ICraftFlightData Data { get; }

		PartData ExecutingPart { get; }

		double FrameDeltaTime { get; }

		ICraftInputs Inputs { get; }

		INavSphere NavSphere { get; }

		TimeModeType TimeMode { get; set; }

		double TimeSinceLaunch { get; }

		double TotalTime { get; }

		Vector3d PidGainsPitch { get; }

		Vector3d PidGainsRoll { get; }

		void ActivateNextStage();

		void BroadcastMessage(BroadcastScope scope, string messageName, ExpressionResult data);

		Vector3d ConvertLatLongAglToPlanetPosition(Vector3d latLongAgl);

		Vector3d ConvertLatLongAslToPlanetPosition(Vector3d latLongAsl);

		Vector3d ConvertLocalToPCI(IPartScript part, Vector3 local);

		Vector3 ConvertPCIToLocal(IPartScript part, Vector3d pci);

		Vector3d ConvertPlanetPositionToLatLongAgl(Vector3d position);

		Vector3d ConvertPlanetPositionToLatLongAsl(Vector3d position);

		IMfdWidget CreateMfdWidget(MfdWidgetType widgetType, string name, string icon);

		void DisplayMessage(string message, float duration);

		bool GetActivationGroupState(int activationGroup);

		ICraftNode GetCraftNode(int craftNodeId);

		ICraftNode GetCraftNodeByName(string craftName);

		Delegate GetInputExpression(string text);

		IEnumerable<IMfdWidget> GetMfdChildWidgets(string parentName);

		IMfdWidget GetMfdWidget(string widgetName);

		IPlanetNode GetPlanet(string planetName);

		Vector3d GetTerrainColor(Vector3d latLong);

		double GetTerrainHeight(Vector3d latLong);

		void PlayBeepSound(float pitch, float volume, float duration);

		void ReleaseInputExpression(Delegate func);

		UserInputRequest RequestUserInput(string message, string content = null);

		void SetActivationGroupState(int activationGroup, bool state);

		void SetCameraProperty(CameraProperty cameraProperty, ExpressionResult value);

		void SetPartFuelTransfer(IPartScript part, FuelTransferMode fuelTransfer);

		void SetPidGainsPitch(Vector3 pid);

		void SetPidGainsRoll(Vector3 pid);

		void SetTargetNode(string name);

		void SetTargetVector(Vector3d position);

		void StopSound();

		void SwitchToCraftNode(ICraftNode craftNode);
	}
}

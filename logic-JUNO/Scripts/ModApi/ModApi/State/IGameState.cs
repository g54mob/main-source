using System;
using System.Collections.Generic;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State.Validation;

namespace ModApi.State
{
	public interface IGameState
	{
		long AvailableFunds { get; }

		ICareerState Career { get; }

		string CompanyName { get; set; }

		DateTime CreatedDateTime { get; set; }

		string Id { get; }

		DateTime LastModifiedDateTime { get; set; }

		List<LaunchLocation> LaunchLocations { get; }

		GameStateMode Mode { get; set; }

		string Parent { get; set; }

		FlightSceneLoadParameters PreflightLoadParameters { get; set; }

		string SelectedCraftDesignId { get; set; }

		int? SelectedCraftNodeId { get; set; }

		LaunchLocation SelectedLaunchLocation { get; set; }

		GameStateType Type { get; }

		IGameStateValidator Validator { get; }
	}
}

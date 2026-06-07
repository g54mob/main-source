using Motorways;
using Motorways.Models;
using UnityEngine;

public class MotorwaysGameStatistics : IGameStatistics
{
	private const int InvalidTripCount = -1;

	public string CityId { get; private set; }

	public int TotalTrips { get; private set; }

	public int NewTrips { get; private set; }

	public int PeakAverageTrips { get; private set; }

	public int TotalDuration { get; private set; }

	public int NewDuration { get; private set; }

	public int TotalPlayTime { get; private set; }

	public int NewPlayTime { get; private set; }

	public GameMode Mode { get; private set; }

	public ActiveChallengesModel Challenge { get; private set; }

	public GameEndReason? GameEndReason { get; private set; }

	public void InitFromGame(MotorwaysGame fromGame)
	{
		if (fromGame.MapDefinition != null)
		{
			CityId = fromGame.MapDefinition.cityName;
			Mode = fromGame.Scope.Get<CityModel>().Mode;
			Challenge = fromGame.Scope.Get<ActiveChallengesModel>();
		}
		else
		{
			CityId = "Error";
			Mode = GameMode.Normal;
		}
		ScoreModel scoreModel = fromGame.Scope.Get<ScoreModel>();
		TotalTrips = scoreModel.Score;
		NewTrips = scoreModel.Score;
		TotalDuration = Mathf.FloorToInt((float)scoreModel.Clock.Time);
		NewDuration = TotalDuration;
		TotalPlayTime = Mathf.FloorToInt((float)scoreModel.Clock.Time);
		NewPlayTime = TotalPlayTime;
	}

	public void InitFromGameIncrementally(MotorwaysGame fromGame, MotorwaysGameStatistics initialGameStatistics, GameEndReason? fromGameEndReason)
	{
		InitFromGame(fromGame);
		NewTrips -= initialGameStatistics.TotalTrips;
		NewDuration -= initialGameStatistics.TotalDuration;
		NewPlayTime -= initialGameStatistics.TotalPlayTime;
		GameEndReason = fromGameEndReason;
	}
}

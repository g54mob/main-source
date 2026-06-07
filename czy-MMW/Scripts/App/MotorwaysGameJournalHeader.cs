using System;
using Factory;
using FixMath;
using Motorways;
using Motorways.Models;
using Server;
using UnityEngine;

[Factory.Serializable(1)]
internal class MotorwaysGameJournalHeader : IMotorwaysGameJournalHeader
{
	[Serialize(true, null)]
	public GameJournalMotive Motive { get; private set; }

	[Serialize(true, null)]
	public string DeviceModel { get; private set; }

	[Serialize(true, null)]
	public string DeviceName { get; private set; }

	[Serialize(true, null)]
	public DateTime UtcTimestamp { get; private set; }

	[Serialize(true, null)]
	public int GameAssemblerSerializerHashCode { get; private set; }

	[Serialize(true, null)]
	public string CityId { get; private set; }

	[Serialize(true, null)]
	public GameMode Mode { get; private set; }

	[Serialize(true, null)]
	public int TripCount { get; private set; }

	[Serialize(true, null)]
	public Fix64 TimeElapsed { get; private set; }

	[Serialize(true, null)]
	public MapChallenge.ChallengeType ChallengeType { get; private set; }

	[Serialize(true, null)]
	public int ChallengeEndTime { get; private set; }

	[Serialize(true, null)]
	public int ChallengeIndex { get; private set; }

	public bool Initialize(ISimulation simulation, GameJournalMotive motive)
	{
		CityModel model = simulation.GetModel<CityModel>();
		ScoreModel model2 = simulation.GetModel<ScoreModel>();
		ClockModel model3 = simulation.GetModel<ClockModel>();
		ActiveChallengesModel model4 = simulation.GetModel<ActiveChallengesModel>();
		if (model == null || model2 == null || model3 == null)
		{
			return false;
		}
		Motive = motive;
		DeviceModel = SystemInfo.deviceModel;
		DeviceName = SystemInfo.deviceName;
		UtcTimestamp = DateTime.UtcNow;
		GameAssemblerSerializerHashCode = simulation.Scope.Assembler.GlobalTypeSerializerHashCode;
		CityId = model.cityName;
		Mode = model.Mode;
		TripCount = model2.Score;
		TimeElapsed = model3.Time;
		ChallengeType = model4.challengeType;
		ChallengeEndTime = model4.timeEnd;
		ChallengeIndex = model4.cityChallengeIndex;
		return true;
	}
}

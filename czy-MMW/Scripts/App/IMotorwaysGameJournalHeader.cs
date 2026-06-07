using System;
using FixMath;
using Motorways;

internal interface IMotorwaysGameJournalHeader
{
	GameJournalMotive Motive { get; }

	string DeviceModel { get; }

	string DeviceName { get; }

	DateTime UtcTimestamp { get; }

	int GameAssemblerSerializerHashCode { get; }

	string CityId { get; }

	GameMode Mode { get; }

	int TripCount { get; }

	Fix64 TimeElapsed { get; }
}

using System;

namespace ModApi.CelestialData
{
	public interface ICelestialObjectFileData
	{
		string Author { get; }

		string Description { get; }

		Guid FileId { get; }

		bool IsLatestVersion { get; set; }

		string Name { get; }

		ICelestialObjectFileData UpgradeVersion { get; set; }

		Version Version { get; }

		string VersionTag { get; }
	}
}

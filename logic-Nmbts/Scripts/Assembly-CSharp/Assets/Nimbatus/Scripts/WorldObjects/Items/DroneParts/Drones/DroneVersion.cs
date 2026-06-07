using System;
using System.IO;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones
{
	public class DroneVersion
	{
		public Version LoadedVersion;

		public Version CurrentVersion;

		public DroneVersion()
		{
			CurrentVersion = new Version("3.2.0");
			LoadedVersion = CurrentVersion;
		}

		public void Save(BinaryWriter writer)
		{
			writer.Write(CurrentVersion.ToString());
		}

		public void Load(BinaryReader reader)
		{
			LoadedVersion = new Version(reader.ReadString());
		}
	}
}

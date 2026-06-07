using System;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PrefabPathAttribute : Attribute
	{
		public string PrefabPath { get; }

		public PrefabPathAttribute(string prefabPath)
		{
			PrefabPath = prefabPath;
		}
	}
}

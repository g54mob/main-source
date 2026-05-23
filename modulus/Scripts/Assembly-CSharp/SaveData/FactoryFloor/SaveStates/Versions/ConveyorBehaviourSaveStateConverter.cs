using System;
using Data.SaveData;
using UnityEngine;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class ConveyorBehaviourSaveStateConverter : SaveDataConverter<ConveyorBehaviourSaveStateDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public bool HasResource;

			public int ResourceDataID;

			public string Hash;

			public Color Color;

			public ISaveVersion ToNextVersion()
			{
				if (!HasResource)
				{
					return null;
				}
				return new ConveyorBehaviourSaveStateDto
				{
					ResourceDataID = ResourceDataID,
					Hash = Hash,
					Color = Color
				};
			}
		}

		public ConveyorBehaviourSaveStateConverter()
			: base(1)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(Version0);
			}
			return null;
		}
	}
}

using System;

namespace NSMedieval.Model
{
	[Serializable]
	public class BoneEquipmentPair : SerializablePair<BoneType, string>
	{
		public BoneEquipmentPair()
		{
		}

		public BoneEquipmentPair(BoneType bone, string value)
			: base(bone, value)
		{
		}
	}
}

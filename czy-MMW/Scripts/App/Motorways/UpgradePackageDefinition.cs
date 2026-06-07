using System;
using Factory;

namespace Motorways
{
	[System.Serializable]
	public struct UpgradePackageDefinition
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is UpgradePackageDefinition upgradePackageDefinition)
				{
					context.Writer.Write((int)upgradePackageDefinition.type);
					context.Writer.Write(upgradePackageDefinition.amount);
					context.Writer.Write(upgradePackageDefinition.additionalConcrete);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return new UpgradePackageDefinition
				{
					type = (UpgradeType)context.Reader.ReadInt32(),
					amount = context.Reader.ReadInt32(),
					additionalConcrete = context.Reader.ReadInt32()
				};
			}
		}

		public UpgradeType type;

		public int amount;

		public int additionalConcrete;
	}
}

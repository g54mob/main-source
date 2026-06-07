using System;

namespace FractureField.Upgrades
{
	[Serializable]
	public class UpgradeState : IConvertableSaveData
	{
		public string Id { get; set; }

		public int Level { get; set; }

		public bool ForemanEnabled { get; set; }

		protected UpgradeState Save(UpgradeState data)
		{
			return null;
		}
	}
}

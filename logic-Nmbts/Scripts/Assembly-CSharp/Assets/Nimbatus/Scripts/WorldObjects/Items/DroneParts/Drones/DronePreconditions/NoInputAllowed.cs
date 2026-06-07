using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class NoInputAllowed : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			return true;
		}

		public override bool Check(DroneData drone)
		{
			return true;
		}

		protected override string GetStatus(bool check)
		{
			return LocalizationManager.GetTermTranslation("Preconditions/Autonomous");
		}
	}
}

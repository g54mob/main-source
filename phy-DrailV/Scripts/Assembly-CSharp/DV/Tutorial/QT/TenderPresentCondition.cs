using DV.ThingTypes;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class TenderPresentCondition : AQuickTutorialCondition
	{
		private TrainCar loco;

		private string message;

		public TenderPresentCondition(TrainCar loco, string message = null)
		{
			this.loco = loco;
			if (string.IsNullOrEmpty(message))
			{
				this.message = "You need to have a tender coupled";
			}
			else
			{
				this.message = message;
			}
		}

		public override string Check()
		{
			if (loco == null)
			{
				return message;
			}
			if (loco.GetComponent<SteamTenderAutoCoupleMechanism>() != null)
			{
				if (loco.rearCoupler.coupledTo != null && CarTypes.IsTender(loco.rearCoupler.coupledTo.train.carLivery))
				{
					return string.Empty;
				}
				Debug.Log("Needs tender coupled at rear");
				return message;
			}
			return string.Empty;
		}
	}
}

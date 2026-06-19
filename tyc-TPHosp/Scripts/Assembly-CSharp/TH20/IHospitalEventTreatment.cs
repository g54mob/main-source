using UnityEngine;

namespace TH20
{
	public interface IHospitalEventTreatment
	{
		Sprite GetTreatmentSprite();

		TreatmentCalculationBreakdown GetTreatmenBreakdown();
	}
}

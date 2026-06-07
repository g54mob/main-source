using Data.Objectives.Validators;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Validators/AlwaysTrue", fileName = "AlwaysTrueObjectiveValidatorSO")]
public class AlwaysTrueObjectiveValidatorSO : AbstractObjectiveValidator
{
	public override bool IsValid()
	{
		return true;
	}
}

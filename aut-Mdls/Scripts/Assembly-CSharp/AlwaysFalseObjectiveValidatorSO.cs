using Data.Objectives.Validators;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Validators/AlwaysFalse", fileName = "AlwaysFalseObjectiveValidatorSO")]
public class AlwaysFalseObjectiveValidatorSO : AbstractObjectiveValidator
{
	public override bool IsValid()
	{
		return false;
	}
}

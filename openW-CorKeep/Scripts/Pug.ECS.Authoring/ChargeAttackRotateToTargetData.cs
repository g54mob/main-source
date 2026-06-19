using System;
using NaughtyAttributes;

[Serializable]
public class ChargeAttackRotateToTargetData
{
	public ChargeAttackRotateToTargetType chargeAttackRotateToTargetType;

	[ShowIf("rotateToTargetType", ChargeAttackRotateToTargetType.DegreesPerSecond)]
	public float degreesPerSecond;
}

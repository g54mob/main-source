using System;

[Serializable]
public struct ContractCompletionResult
{
	public ActiveContractData contract;

	public int[] finalDeliveredCounts;

	public int basePrice;

	public int earlyDeliveryBonus;

	public int missingDeliveryPenalty;

	public int totalEarnings;

	public int earnedXP;

	public bool isFullDelivery;

	public bool isEarlyDelivery;

	public int remainingDays;

	public int totalDays;

	public float deliveryCompletionRatio;
}

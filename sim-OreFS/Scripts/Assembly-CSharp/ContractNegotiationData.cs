using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public struct ContractNegotiationData : IEquatable<ContractNegotiationData>
{
	public const int PriceStep = 10;

	public string listingId;

	public uint negotiatorNetId;

	public int basePrice;

	public int rejectThreshold;

	public int acceptCeiling;

	public int npcCurrentTarget;

	public int npcInitialTarget;

	public int finalOfferThreshold;

	public int offerCount;

	public int lastOfferAmount;

	public int bestOfferSoFar;

	public NegotiationState state;

	public double startTime;

	public string buyerMessage;

	private static readonly string[] InitialKeys = new string[5] { "ChatMessage_Contract_Initial1", "ChatMessage_Contract_Initial2", "ChatMessage_Contract_Initial3", "ChatMessage_Contract_Initial4", "ChatMessage_Contract_Initial5" };

	private static readonly string[] AcceptKeys = new string[5] { "ChatMessage_Contract_Accept1", "ChatMessage_Contract_Accept2", "ChatMessage_Contract_Accept3", "ChatMessage_Contract_Accept4", "ChatMessage_Contract_Accept5" };

	private static readonly string[] RejectKeys = new string[5] { "ChatMessage_Contract_Reject1", "ChatMessage_Contract_Reject2", "ChatMessage_Contract_Reject3", "ChatMessage_Contract_Reject4", "ChatMessage_Contract_Reject5" };

	private static readonly string[] CounterKeys = new string[5] { "ChatMessage_Contract_Counter1", "ChatMessage_Contract_Counter2", "ChatMessage_Contract_Counter3", "ChatMessage_Contract_Counter4", "ChatMessage_Contract_Counter5" };

	private static readonly string[] FinalOfferKeys = new string[5] { "ChatMessage_Contract_FinalOffer1", "ChatMessage_Contract_FinalOffer2", "ChatMessage_Contract_FinalOffer3", "ChatMessage_Contract_FinalOffer4", "ChatMessage_Contract_FinalOffer5" };

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(listingId))
			{
				return state != NegotiationState.None;
			}
			return false;
		}
	}

	public bool IsActive
	{
		get
		{
			if (state != NegotiationState.InProgress)
			{
				return state == NegotiationState.FinalOffer;
			}
			return true;
		}
	}

	public bool IsFinalOfferPhase
	{
		get
		{
			if (offerCount < finalOfferThreshold)
			{
				return state == NegotiationState.FinalOffer;
			}
			return true;
		}
	}

	public static ContractNegotiationData Create(ContractListingData listing, uint playerNetId, int priceVarianceMin = 200, int priceVarianceMax = 500)
	{
		int num = RoundToStep(Mathf.RoundToInt((float)listing.price * 1.5f));
		int num2 = RoundToStep(Mathf.RoundToInt((float)listing.price * 1.35f));
		float num3 = UnityEngine.Random.Range(1.1f, 1.25f);
		int num4 = RoundToStep(Mathf.RoundToInt((float)listing.price * num3));
		if (num4 >= num2)
		{
			num4 = num2 - 10;
		}
		int num5 = UnityEngine.Random.Range(3, 6);
		return new ContractNegotiationData
		{
			listingId = listing.listingId,
			negotiatorNetId = playerNetId,
			basePrice = listing.price,
			rejectThreshold = num,
			acceptCeiling = num2,
			npcCurrentTarget = num4,
			npcInitialTarget = num4,
			finalOfferThreshold = num5,
			offerCount = 0,
			lastOfferAmount = 0,
			bestOfferSoFar = 0,
			state = NegotiationState.InProgress,
			startTime = NetworkTimeHelper.GetNetworkTime(),
			buyerMessage = GetInitialBuyerMessage(listing.price)
		};
	}

	public ContractNegotiationData ProcessOffer(int offerAmount, int currentOfferCount)
	{
		ContractNegotiationData result = this;
		result.offerCount = currentOfferCount;
		result.lastOfferAmount = offerAmount;
		int num = result.bestOfferSoFar;
		bool flag = result.bestOfferSoFar == 0 || offerAmount < result.bestOfferSoFar;
		if (flag)
		{
			result.bestOfferSoFar = offerAmount;
		}
		Debug.Log($"[ContractNegotiationData] ProcessOffer - Oyuncu İstediği: ${offerAmount:N0}, Baz: ${basePrice:N0}, Red Sınırı: ${rejectThreshold:N0}, NPC Hedef: ${result.npcCurrentTarget:N0}, OfferCount: {result.offerCount}, Threshold: {finalOfferThreshold}, BestOffer: ${result.bestOfferSoFar:N0}");
		if (flag && num > 0)
		{
			result.ShrinkNpcTarget();
		}
		Debug.Log($"[ContractNegotiationData] NPC hedef güncellendi: ${result.npcCurrentTarget:N0}");
		if (result.offerCount >= finalOfferThreshold)
		{
			int num2 = RoundToStep(Mathf.RoundToInt((float)basePrice * 1.1f));
			if (num2 <= basePrice)
			{
				num2 = basePrice + 10;
			}
			if (result.npcCurrentTarget < num2)
			{
				Debug.Log($"[ContractNegotiationData] Final aşaması - npcCurrentTarget({result.npcCurrentTarget}) < minFinalTarget({num2}), yükseltiliyor.");
				result.npcCurrentTarget = num2;
			}
			Debug.Log($"[ContractNegotiationData] Final aşaması - offerAmount({offerAmount}) <= npcCurrentTarget({result.npcCurrentTarget}) = {offerAmount <= result.npcCurrentTarget}");
			if (offerAmount <= result.npcCurrentTarget)
			{
				result.state = NegotiationState.Accepted;
				result.buyerMessage = GetBuyerAcceptMessage(offerAmount);
				Debug.Log("[ContractNegotiationData] -> KABUL (final aşaması)");
			}
			else
			{
				result.state = NegotiationState.FinalOffer;
				result.buyerMessage = GetBuyerFinalOfferMessage(result.npcCurrentTarget);
				Debug.Log($"[ContractNegotiationData] -> FINAL TEKLİF: ${result.npcCurrentTarget:N0}");
			}
		}
		else if (offerAmount <= result.npcCurrentTarget)
		{
			result.state = NegotiationState.Accepted;
			result.buyerMessage = GetBuyerAcceptMessage(offerAmount);
			Debug.Log("[ContractNegotiationData] -> KABUL (Zone A - hedefi karşılıyor)");
		}
		else if (offerAmount <= acceptCeiling)
		{
			float num3 = result.CalculateAcceptChance(offerAmount);
			float value = UnityEngine.Random.value;
			Debug.Log($"[ContractNegotiationData] Zone B1 - acceptChance: {num3:F2}, random: {value:F2}");
			if (value < num3)
			{
				result.state = NegotiationState.Accepted;
				result.buyerMessage = GetBuyerAcceptMessage(offerAmount);
				Debug.Log("[ContractNegotiationData] -> KABUL (Zone B1 - şansla)");
			}
			else
			{
				result.state = NegotiationState.InProgress;
				float normalizedProximity = result.GetNormalizedProximity(offerAmount);
				result.buyerMessage = GetBuyerCounterMessage(offerAmount, normalizedProximity);
				Debug.Log($"[ContractNegotiationData] -> COUNTER (Zone B1, proximity: {normalizedProximity:F2})");
			}
		}
		else if (offerAmount <= rejectThreshold)
		{
			result.state = NegotiationState.InProgress;
			float normalizedProximity2 = result.GetNormalizedProximity(offerAmount);
			result.buyerMessage = GetBuyerCounterMessage(offerAmount, normalizedProximity2);
			Debug.Log($"[ContractNegotiationData] -> COUNTER (Zone B2 - acceptCeiling üstü, proximity: {normalizedProximity2:F2})");
		}
		else
		{
			result.state = NegotiationState.InProgress;
			result.buyerMessage = GetBuyerRejectMessage(offerAmount);
			Debug.Log("[ContractNegotiationData] -> RED (Zone C - kesin red sınırı üstü)");
		}
		Debug.Log($"[ContractNegotiationData] Sonuç - State: {result.state}, Mesaj: {result.buyerMessage}");
		return result;
	}

	public ContractNegotiationData AcceptFinalOffer()
	{
		ContractNegotiationData result = this;
		result.lastOfferAmount = npcCurrentTarget;
		result.state = NegotiationState.Accepted;
		result.buyerMessage = GetBuyerAcceptMessage(npcCurrentTarget);
		return result;
	}

	private void ShrinkNpcTarget()
	{
		if (bestOfferSoFar == 0 || bestOfferSoFar >= rejectThreshold)
		{
			return;
		}
		float num = rejectThreshold - npcCurrentTarget;
		if (!(num <= 10f))
		{
			float num2 = Mathf.Clamp01((float)(rejectThreshold - bestOfferSoFar) / num) * UnityEngine.Random.Range(0.05f, 0.15f);
			int num3 = Mathf.RoundToInt(num * num2);
			npcCurrentTarget += num3;
			npcCurrentTarget = RoundToStep(npcCurrentTarget);
			if (npcCurrentTarget > acceptCeiling - 10)
			{
				npcCurrentTarget = acceptCeiling - 10;
			}
		}
	}

	private float CalculateAcceptChance(int offerAmount)
	{
		float normalizedProximity = GetNormalizedProximity(offerAmount);
		float num = normalizedProximity * normalizedProximity * normalizedProximity * 0.35f;
		float num2 = 0f;
		bool flag = bestOfferSoFar > 0 && offerAmount < bestOfferSoFar;
		if (flag)
		{
			num2 = 0.2f * (1f - Mathf.Pow(0.7f, offerCount - 1));
		}
		float num3 = 0f;
		if (IsOfferImprovement(offerAmount))
		{
			num3 = GetImprovementRatio(offerAmount) * 0.1f;
		}
		float num4 = 0f;
		if (offerCount > finalOfferThreshold)
		{
			int num5 = offerCount - finalOfferThreshold;
			num4 = 1f - Mathf.Pow(0.85f, num5);
		}
		float num6 = Mathf.Clamp01((num + num2 + num3) * (1f - num4));
		Debug.Log($"[ContractNegotiationData] AcceptChance - proximity: {normalizedProximity:F2}, baseChance: {num:F2}, fatigue: {num2:F2}, goodFaith: {num3:F2}, hasImproved: {flag}, patiencePenalty: {num4:F2}, total: {num6:F2}");
		return num6;
	}

	private float GetNormalizedProximity(int offerAmount)
	{
		float num = rejectThreshold - npcCurrentTarget;
		if (num <= 0f)
		{
			return 1f;
		}
		return Mathf.Clamp01((float)(rejectThreshold - offerAmount) / num);
	}

	private bool IsOfferImprovement(int offer)
	{
		if (bestOfferSoFar == 0)
		{
			return false;
		}
		return offer < bestOfferSoFar;
	}

	private float GetImprovementRatio(int offer)
	{
		float num = rejectThreshold - npcCurrentTarget;
		if (num <= 0f)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)Mathf.Abs(offer - bestOfferSoFar) / num);
	}

	private static int RoundToStep(int value)
	{
		return value / 10 * 10;
	}

	private static string GetInitialBuyerMessage(int basePrice)
	{
		return string.Format(LocalizationManager.GetTranslation(InitialKeys[UnityEngine.Random.Range(0, InitialKeys.Length)]), $"${basePrice:N0}");
	}

	private static string GetBuyerAcceptMessage(int amount)
	{
		return string.Format(LocalizationManager.GetTranslation(AcceptKeys[UnityEngine.Random.Range(0, AcceptKeys.Length)]), $"${amount:N0}");
	}

	private static string GetBuyerRejectMessage(int offerAmount)
	{
		return string.Format(LocalizationManager.GetTranslation(RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)]), $"${offerAmount:N0}");
	}

	private static string GetBuyerCounterMessage(int offerAmount, float proximity)
	{
		string term = ((proximity < 0.15f) ? RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)] : ((!(proximity < 0.5f)) ? CounterKeys[UnityEngine.Random.Range(0, CounterKeys.Length)] : ((UnityEngine.Random.value > 0.5f) ? CounterKeys[UnityEngine.Random.Range(0, CounterKeys.Length)] : RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)])));
		return string.Format(LocalizationManager.GetTranslation(term), $"${offerAmount:N0}");
	}

	private static string GetBuyerFinalOfferMessage(int finalPrice)
	{
		return string.Format(LocalizationManager.GetTranslation(FinalOfferKeys[UnityEngine.Random.Range(0, FinalOfferKeys.Length)]), $"${finalPrice:N0}");
	}

	public bool Equals(ContractNegotiationData other)
	{
		if (listingId == other.listingId)
		{
			return negotiatorNetId == other.negotiatorNetId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ContractNegotiationData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(listingId, negotiatorNetId);
	}
}

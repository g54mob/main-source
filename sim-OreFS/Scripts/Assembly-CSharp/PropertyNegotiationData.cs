using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public struct PropertyNegotiationData : IEquatable<PropertyNegotiationData>
{
	public const int PriceStep = 10;

	public string listingId;

	public uint negotiatorNetId;

	public int basePrice;

	public int rejectThreshold;

	public int acceptFloor;

	public int npcCurrentTarget;

	public int npcInitialTarget;

	public int finalOfferThreshold;

	public int offerCount;

	public int lastOfferAmount;

	public int bestOfferSoFar;

	public NegotiationState state;

	public double startTime;

	public string sellerMessage;

	private static readonly string[] InitialKeys = new string[5] { "ChatMessage_Property_Initial1", "ChatMessage_Property_Initial2", "ChatMessage_Property_Initial3", "ChatMessage_Property_Initial4", "ChatMessage_Property_Initial5" };

	private static readonly string[] AcceptKeys = new string[5] { "ChatMessage_Property_Accept1", "ChatMessage_Property_Accept2", "ChatMessage_Property_Accept3", "ChatMessage_Property_Accept4", "ChatMessage_Property_Accept5" };

	private static readonly string[] RejectKeys = new string[5] { "ChatMessage_Property_Reject1", "ChatMessage_Property_Reject2", "ChatMessage_Property_Reject3", "ChatMessage_Property_Reject4", "ChatMessage_Property_Reject5" };

	private static readonly string[] CounterKeys = new string[5] { "ChatMessage_Property_Counter1", "ChatMessage_Property_Counter2", "ChatMessage_Property_Counter3", "ChatMessage_Property_Counter4", "ChatMessage_Property_Counter5" };

	private static readonly string[] FinalOfferKeys = new string[5] { "ChatMessage_Property_FinalOffer1", "ChatMessage_Property_FinalOffer2", "ChatMessage_Property_FinalOffer3", "ChatMessage_Property_FinalOffer4", "ChatMessage_Property_FinalOffer5" };

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

	public static PropertyNegotiationData Create(PropertyListingData listing, uint playerNetId, int priceVarianceMin = 500, int priceVarianceMax = 1500)
	{
		int num = RoundToStep(Mathf.RoundToInt((float)listing.basePrice * 0.5f));
		int num2 = RoundToStep(Mathf.RoundToInt((float)listing.basePrice * 0.65f));
		float num3 = UnityEngine.Random.Range(0.75f, 0.9f);
		int num4 = RoundToStep(Mathf.RoundToInt((float)listing.basePrice * num3));
		if (num4 <= num2)
		{
			num4 = num2 + 10;
		}
		int num5 = UnityEngine.Random.Range(3, 6);
		return new PropertyNegotiationData
		{
			listingId = listing.listingId,
			negotiatorNetId = playerNetId,
			basePrice = listing.basePrice,
			rejectThreshold = num,
			acceptFloor = num2,
			npcCurrentTarget = num4,
			npcInitialTarget = num4,
			finalOfferThreshold = num5,
			offerCount = 0,
			lastOfferAmount = 0,
			bestOfferSoFar = 0,
			state = NegotiationState.InProgress,
			startTime = NetworkTimeHelper.GetNetworkTime(),
			sellerMessage = GetInitialSellerMessage(listing.basePrice)
		};
	}

	public PropertyNegotiationData ProcessOffer(int offerAmount, int currentOfferCount)
	{
		PropertyNegotiationData result = this;
		result.offerCount = currentOfferCount;
		result.lastOfferAmount = offerAmount;
		int num = result.bestOfferSoFar;
		bool flag = result.bestOfferSoFar == 0 || offerAmount > result.bestOfferSoFar;
		if (flag)
		{
			result.bestOfferSoFar = offerAmount;
		}
		Debug.Log($"[PropertyNegotiationData] ProcessOffer - Oyuncu Teklifi: ${offerAmount:N0}, Baz: ${basePrice:N0}, Red Sınırı: ${rejectThreshold:N0}, NPC Hedef: ${result.npcCurrentTarget:N0}, OfferCount: {result.offerCount}, Threshold: {finalOfferThreshold}, BestOffer: ${result.bestOfferSoFar:N0}");
		if (flag && num > 0)
		{
			result.ShrinkNpcTarget();
		}
		Debug.Log($"[PropertyNegotiationData] NPC hedef güncellendi: ${result.npcCurrentTarget:N0}");
		if (result.offerCount >= finalOfferThreshold)
		{
			int num2 = RoundToStep(Mathf.RoundToInt((float)basePrice * 0.9f));
			if (num2 >= basePrice)
			{
				num2 = basePrice - 10;
			}
			if (result.npcCurrentTarget > num2)
			{
				Debug.Log($"[PropertyNegotiationData] Final aşaması - npcCurrentTarget({result.npcCurrentTarget}) > maxFinalTarget({num2}), düşürülüyor.");
				result.npcCurrentTarget = num2;
			}
			Debug.Log($"[PropertyNegotiationData] Final aşaması - offerAmount({offerAmount}) >= npcCurrentTarget({result.npcCurrentTarget}) = {offerAmount >= result.npcCurrentTarget}");
			if (offerAmount >= result.npcCurrentTarget)
			{
				result.state = NegotiationState.Accepted;
				result.sellerMessage = GetAcceptMessage(offerAmount);
				Debug.Log("[PropertyNegotiationData] -> KABUL (final aşaması)");
			}
			else
			{
				result.state = NegotiationState.FinalOffer;
				result.sellerMessage = GetFinalOfferMessage(result.npcCurrentTarget);
				Debug.Log($"[PropertyNegotiationData] -> FINAL TEKLİF: ${result.npcCurrentTarget:N0}");
			}
		}
		else if (offerAmount >= result.npcCurrentTarget)
		{
			result.state = NegotiationState.Accepted;
			result.sellerMessage = GetAcceptMessage(offerAmount);
			Debug.Log("[PropertyNegotiationData] -> KABUL (Zone A - hedefi karşılıyor)");
		}
		else if (offerAmount >= acceptFloor)
		{
			float num3 = result.CalculateAcceptChance(offerAmount);
			float value = UnityEngine.Random.value;
			Debug.Log($"[PropertyNegotiationData] Zone B1 - acceptChance: {num3:F2}, random: {value:F2}");
			if (value < num3)
			{
				result.state = NegotiationState.Accepted;
				result.sellerMessage = GetAcceptMessage(offerAmount);
				Debug.Log("[PropertyNegotiationData] -> KABUL (Zone B1 - şansla)");
			}
			else
			{
				result.state = NegotiationState.InProgress;
				float normalizedProximity = result.GetNormalizedProximity(offerAmount);
				result.sellerMessage = GetCounterMessage(offerAmount, normalizedProximity);
				Debug.Log($"[PropertyNegotiationData] -> COUNTER (Zone B1, proximity: {normalizedProximity:F2})");
			}
		}
		else if (offerAmount >= rejectThreshold)
		{
			result.state = NegotiationState.InProgress;
			float normalizedProximity2 = result.GetNormalizedProximity(offerAmount);
			result.sellerMessage = GetCounterMessage(offerAmount, normalizedProximity2);
			Debug.Log($"[PropertyNegotiationData] -> COUNTER (Zone B2 - acceptFloor altı, proximity: {normalizedProximity2:F2})");
		}
		else
		{
			result.state = NegotiationState.InProgress;
			result.sellerMessage = GetRejectMessage(offerAmount);
			Debug.Log("[PropertyNegotiationData] -> RED (Zone C - kesin red sınırı altı)");
		}
		Debug.Log($"[PropertyNegotiationData] Sonuç - State: {result.state}, Mesaj: {result.sellerMessage}");
		return result;
	}

	public PropertyNegotiationData AcceptFinalOffer()
	{
		PropertyNegotiationData result = this;
		result.lastOfferAmount = npcCurrentTarget;
		result.state = NegotiationState.Accepted;
		result.sellerMessage = GetAcceptMessage(npcCurrentTarget);
		return result;
	}

	private void ShrinkNpcTarget()
	{
		if (bestOfferSoFar <= rejectThreshold)
		{
			return;
		}
		float num = npcCurrentTarget - rejectThreshold;
		if (!(num <= 10f))
		{
			float num2 = Mathf.Clamp01((float)(bestOfferSoFar - rejectThreshold) / num) * UnityEngine.Random.Range(0.05f, 0.15f);
			int num3 = Mathf.RoundToInt(num * num2);
			npcCurrentTarget -= num3;
			npcCurrentTarget = RoundToStep(npcCurrentTarget);
			if (npcCurrentTarget < acceptFloor + 10)
			{
				npcCurrentTarget = acceptFloor + 10;
			}
		}
	}

	private float CalculateAcceptChance(int offerAmount)
	{
		float normalizedProximity = GetNormalizedProximity(offerAmount);
		float num = normalizedProximity * normalizedProximity * normalizedProximity * 0.35f;
		float num2 = 0f;
		bool flag = bestOfferSoFar > 0 && offerAmount > bestOfferSoFar;
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
		Debug.Log($"[PropertyNegotiationData] AcceptChance - proximity: {normalizedProximity:F2}, baseChance: {num:F2}, fatigue: {num2:F2}, goodFaith: {num3:F2}, hasImproved: {flag}, patiencePenalty: {num4:F2}, total: {num6:F2}");
		return num6;
	}

	private float GetNormalizedProximity(int offerAmount)
	{
		float num = npcCurrentTarget - rejectThreshold;
		if (num <= 0f)
		{
			return 1f;
		}
		return Mathf.Clamp01((float)(offerAmount - rejectThreshold) / num);
	}

	private bool IsOfferImprovement(int offer)
	{
		if (bestOfferSoFar == 0)
		{
			return false;
		}
		return offer > bestOfferSoFar;
	}

	private float GetImprovementRatio(int offer)
	{
		float num = npcCurrentTarget - rejectThreshold;
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

	private static string GetInitialSellerMessage(int basePrice)
	{
		return string.Format(LocalizationManager.GetTranslation(InitialKeys[UnityEngine.Random.Range(0, InitialKeys.Length)]), $"${basePrice:N0}");
	}

	public static string GetAcceptMessagePublic(int amount)
	{
		return GetAcceptMessage(amount);
	}

	private static string GetAcceptMessage(int amount)
	{
		return string.Format(LocalizationManager.GetTranslation(AcceptKeys[UnityEngine.Random.Range(0, AcceptKeys.Length)]), $"${amount:N0}");
	}

	private static string GetRejectMessage(int offerAmount)
	{
		return string.Format(LocalizationManager.GetTranslation(RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)]), $"${offerAmount:N0}");
	}

	private static string GetCounterMessage(int offerAmount, float proximity)
	{
		string term = ((proximity < 0.15f) ? RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)] : ((!(proximity < 0.5f)) ? CounterKeys[UnityEngine.Random.Range(0, CounterKeys.Length)] : ((UnityEngine.Random.value > 0.5f) ? CounterKeys[UnityEngine.Random.Range(0, CounterKeys.Length)] : RejectKeys[UnityEngine.Random.Range(0, RejectKeys.Length)])));
		return string.Format(LocalizationManager.GetTranslation(term), $"${offerAmount:N0}");
	}

	private static string GetFinalOfferMessage(int finalPrice)
	{
		return string.Format(LocalizationManager.GetTranslation(FinalOfferKeys[UnityEngine.Random.Range(0, FinalOfferKeys.Length)]), $"${finalPrice:N0}");
	}

	public bool Equals(PropertyNegotiationData other)
	{
		if (listingId == other.listingId)
		{
			return negotiatorNetId == other.negotiatorNetId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyNegotiationData other)
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

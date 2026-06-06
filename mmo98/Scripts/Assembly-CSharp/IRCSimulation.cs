using System;
using System.Collections.Generic;
using ObservableCollections;
using UnityEngine;
using UnityEngine.Localization;
using ZLinq;
using ZLinq.Linq;

[CreateAssetMenu(menuName = "Data/Simulation/IRC", fileName = "IRCSimulation")]
public class IRCSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	private enum IRCSentiment
	{
		Negative = 0,
		Neutral = 1,
		Positive = 2
	}

	private readonly struct Snapshot
	{
		public float Hype { get; }

		public float HypeMin { get; }

		public float HypeMax { get; }

		public float HypeBaseline { get; }

		public float Ping { get; }

		public float PingMinimum { get; }

		public float PingMinorTolerance { get; }

		public float PingMajorTolerance { get; }

		public float Bugs { get; }

		public float BugSoftCap { get; }

		public float BugHardCap { get; }

		public bool IsDegraded { get; }

		public bool IsCritical { get; }

		public Datacenter BadDatacenter { get; }

		public bool AuctionUnlocked { get; }

		public float AuctionAlignment { get; }

		public AuctionSentimentState AuctionState { get; }

		public float DramaScore { get; }

		public Snapshot(float hype, float hypeMin, float hypeMax, float hypeBaseline, float ping, float pingMinimum, float pingMinorTolerance, float pingMajorTolerance, float bugs, float bugSoftCap, float bugHardCap, bool isDegraded, bool isCritical, Datacenter badDatacenter, bool auctionUnlocked, float auctionAlignment, AuctionSentimentState auctionState, float dramaScore)
		{
			Hype = hype;
			HypeMin = hypeMin;
			HypeMax = hypeMax;
			HypeBaseline = hypeBaseline;
			Ping = ping;
			PingMinimum = pingMinimum;
			PingMinorTolerance = pingMinorTolerance;
			PingMajorTolerance = pingMajorTolerance;
			Bugs = bugs;
			BugSoftCap = bugSoftCap;
			BugHardCap = bugHardCap;
			IsDegraded = isDegraded;
			IsCritical = isCritical;
			BadDatacenter = badDatacenter;
			AuctionUnlocked = auctionUnlocked;
			AuctionAlignment = auctionAlignment;
			AuctionState = auctionState;
			DramaScore = dramaScore;
		}
	}

	[SerializeField]
	private float chance = 0.0001f;

	[SerializeField]
	private float maxTriggerChancePerTick = 0.2f;

	[SerializeField]
	private float fluffBaseWeight = 1f;

	[SerializeField]
	[Tooltip("As drama increases, fluff becomes less likely. 0 = no effect.")]
	private float fluffDramaSuppression = 1.25f;

	[SerializeField]
	private int recentNoRepeatFluffCapacity = 6;

	[SerializeField]
	[Tooltip("Base multiplier for meaningful weights.")]
	private float meaningfulBaseWeight = 1f;

	[SerializeField]
	private int recentNoRepeatTopicSentimentCapacity = 3;

	[SerializeField]
	[Tooltip("Hype band around baseline that counts as 'neutral'.")]
	private float hypeNeutralBand = 0.2f;

	[SerializeField]
	private float bugsVeryLowRatioOfSoftCap = 0.2f;

	private ObservableFixedSizeRingBuffer<long> _messageRepeatBuffer;

	[field: SerializeField]
	public float UpdateInterval { get; private set; } = 0.5f;

	public void Registered(UIRegistry? registry)
	{
		_messageRepeatBuffer = new ObservableFixedSizeRingBuffer<long>(recentNoRepeatFluffCapacity);
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		if (Database.State.Game.Launched.Value)
		{
			double currentValue = Database.State.Resources.Players.CurrentValue;
			if (!(currentValue <= 0.0) && !((double)BiteRandom.NextFloat() > Math.Min((double)chance * currentValue, maxTriggerChancePerTick)))
			{
				TriggerIRCMessage();
			}
		}
	}

	private void TriggerIRCMessage()
	{
		Snapshot s = ReadSnapshot();
		float dramaScore = s.DramaScore;
		float b = fluffBaseWeight / (1f + dramaScore * fluffDramaSuppression);
		b = Mathf.Max(0.001f, b);
		float hypeWeight = GetHypeWeight(s);
		float bugsWeight = GetBugsWeight(s);
		float pingWeight = GetPingWeight(s);
		float datacenterWeight = GetDatacenterWeight(s);
		float auctionWeight = GetAuctionWeight(s);
		hypeWeight *= meaningfulBaseWeight;
		bugsWeight *= meaningfulBaseWeight;
		pingWeight *= meaningfulBaseWeight;
		datacenterWeight *= meaningfulBaseWeight;
		auctionWeight *= meaningfulBaseWeight;
		float num = b + hypeWeight + bugsWeight + pingWeight + datacenterWeight + auctionWeight;
		if (num <= 0f)
		{
			return;
		}
		float num2 = BiteRandom.NextFloat() * num;
		if (num2 < b)
		{
			TriggerFluff();
			return;
		}
		num2 -= b;
		if (num2 < hypeWeight)
		{
			TriggerHype(s);
			return;
		}
		num2 -= hypeWeight;
		if (num2 < bugsWeight)
		{
			TriggerBugs(s);
			return;
		}
		num2 -= bugsWeight;
		if (num2 < pingWeight)
		{
			TriggerPing(s);
			return;
		}
		num2 -= pingWeight;
		if (num2 < datacenterWeight)
		{
			TriggerDatacenters(s);
		}
		else
		{
			TriggerAuction(s);
		}
	}

	private Snapshot ReadSnapshot()
	{
		float currentValue = Database.State.Resources.Hype.CurrentValue;
		float currentValue2 = Database.State.Resources.Bugs.CurrentValue;
		float currentValue3 = Database.Derived.BugSoftCapacity.CurrentValue;
		float currentValue4 = Database.Derived.BugHardCapacity.CurrentValue;
		float currentValue5 = Database.State.Resources.Ping.CurrentValue;
		float num = ModifierType.HypePingMajorTolerance.Float();
		float num2 = ModifierType.HypeMinimum.Float();
		float num3 = ModifierType.HypeMaximum.Float();
		float num4 = ModifierType.Hype.Float();
		Datacenter datacenter = Datacenter.None;
		bool isDegraded = false;
		bool isCritical = false;
		ValueEnumerable<Where<FromEnumerable<KeyValuePair<Datacenter, DatacenterDetails>>, KeyValuePair<Datacenter, DatacenterDetails>>, KeyValuePair<Datacenter, DatacenterDetails>> source = Database.State.Datacenters.Details.AsValueEnumerable().Where(delegate(KeyValuePair<Datacenter, DatacenterDetails> x)
		{
			DatacenterState currentValue6 = x.Value.State.CurrentValue;
			return currentValue6 == DatacenterState.Degraded || currentValue6 == DatacenterState.Critical;
		});
		if (source.Count() > 0)
		{
			KeyValuePair<Datacenter, DatacenterDetails> keyValuePair = source.Random();
			datacenter = keyValuePair.Key;
			isDegraded = keyValuePair.Value.State.CurrentValue == DatacenterState.Degraded;
			isCritical = keyValuePair.Value.State.CurrentValue == DatacenterState.Critical;
		}
		float num5 = ((currentValue3 <= 0f) ? 0f : Mathf.Clamp01((currentValue2 - currentValue3) / Mathf.Max(1f, currentValue4 - currentValue3)));
		float num6 = ((currentValue5 <= num) ? 0f : Mathf.Clamp01((currentValue5 - num) / (999f - num)));
		float num7 = ((datacenter != Datacenter.None) ? 1f : 0f);
		float num8 = Mathf.Max(0.001f, num3 - num2);
		float num9 = Mathf.Abs(currentValue - num4) / num8;
		float hiddenSentimentScore = AuctionUtility.GetHiddenSentimentScore(Database.State.Auction);
		AuctionSentimentState sentimentState = AuctionUtility.GetSentimentState(Database.State.Auction);
		float dramaScore = num5 + num6 + num7 + num9;
		return new Snapshot(currentValue, num2, num3, num4, currentValue5, ModifierType.PingMinimum.Float(), ModifierType.HypePingMinorTolerance.Float(), num, currentValue2, currentValue3, currentValue4, isDegraded, isCritical, datacenter, Database.State.Research.IsUnlocked(ResearchNode.AuctionHouse), hiddenSentimentScore, sentimentState, dramaScore);
	}

	private float GetHypeWeight(Snapshot s)
	{
		float num = Mathf.Max(0.001f, s.HypeMax - s.HypeMin);
		return Mathf.Clamp01(Mathf.Abs(s.Hype - s.HypeBaseline) / num * 2f);
	}

	private float GetBugsWeight(Snapshot s)
	{
		if (s.BugSoftCap <= 0f)
		{
			return 0f;
		}
		float num = s.BugSoftCap * bugsVeryLowRatioOfSoftCap;
		if (s.Bugs <= num)
		{
			float num2 = ((num <= 0f) ? 1f : Mathf.Clamp01((num - s.Bugs) / Mathf.Max(0.001f, num)));
			return 0.5f + num2 * 0.5f;
		}
		if (s.Bugs >= s.BugSoftCap)
		{
			float num3 = Mathf.Max(1f, s.BugHardCap - s.BugSoftCap);
			float num4 = Mathf.Clamp01((s.Bugs - s.BugSoftCap) / num3);
			return 0.5f + num4 * 0.5f;
		}
		return 0f;
	}

	private float GetPingWeight(Snapshot s)
	{
		if (s.Ping <= s.PingMinorTolerance)
		{
			float num = Mathf.Clamp01((s.PingMinorTolerance - s.Ping) / Mathf.Max(0.001f, s.PingMinorTolerance - s.PingMinimum));
			return 0.5f + num * 0.5f;
		}
		if (s.Ping >= s.PingMajorTolerance)
		{
			float num2 = Mathf.Clamp01((s.Ping - s.PingMajorTolerance) / (999f - s.PingMajorTolerance));
			return 0.5f + num2 * 0.5f;
		}
		return 0f;
	}

	private float GetDatacenterWeight(Snapshot s)
	{
		if (s.IsCritical)
		{
			return 1.25f;
		}
		if (s.IsDegraded)
		{
			return 0.85f;
		}
		return 0f;
	}

	private float GetAuctionWeight(Snapshot s)
	{
		if (!s.AuctionUnlocked)
		{
			return 0f;
		}
		if (s.AuctionState != AuctionSentimentState.Neutral)
		{
			return AuctionUtility.GetSentimentIntensity(s.AuctionAlignment);
		}
		return 0f;
	}

	private void TriggerFluff()
	{
		TriggerMessage(LocTable.Fluff);
	}

	private void TriggerHype(Snapshot s)
	{
		switch (GetHypeSentiment(s))
		{
		case IRCSentiment.Positive:
			TriggerMessage(LocTable.HypePositive);
			break;
		case IRCSentiment.Negative:
			TriggerMessage(LocTable.HypeNegative);
			break;
		default:
			TriggerMessage(LocTable.HypeNeutral);
			break;
		}
	}

	private void TriggerBugs(Snapshot s)
	{
		switch (GetBugsSentiment(s))
		{
		case IRCSentiment.Neutral:
			TriggerFluff();
			break;
		case IRCSentiment.Positive:
			TriggerMessage(LocTable.BugsPositive);
			break;
		case IRCSentiment.Negative:
			TriggerMessage(LocTable.BugsNegative);
			break;
		}
	}

	private void TriggerPing(Snapshot s)
	{
		switch (GetPingSentiment(s))
		{
		case IRCSentiment.Neutral:
			TriggerFluff();
			break;
		case IRCSentiment.Positive:
			TriggerMessage(LocTable.PingPositive);
			break;
		case IRCSentiment.Negative:
			TriggerMessage(LocTable.PingNegative);
			break;
		}
	}

	private void TriggerDatacenters(Snapshot s)
	{
		if ((!s.IsDegraded && !s.IsCritical) || s.BadDatacenter == Datacenter.None)
		{
			TriggerFluff();
			return;
		}
		TriggerMessage(LocTable.DatacentersNegative, delegate(LocalizedString message)
		{
			message["datacenter"] = s.BadDatacenter.Data().TitleLocalized;
		});
	}

	private void TriggerAuction(Snapshot s)
	{
		switch (GetAuctionSentiment(s))
		{
		case IRCSentiment.Positive:
			TriggerMessage(LocTable.AuctionPositive);
			break;
		case IRCSentiment.Negative:
			TriggerMessage(LocTable.AuctionNegative);
			break;
		}
	}

	private IRCSentiment GetHypeSentiment(Snapshot s)
	{
		if (s.Hype >= s.HypeBaseline + hypeNeutralBand)
		{
			return IRCSentiment.Positive;
		}
		if (s.Hype <= s.HypeBaseline - hypeNeutralBand)
		{
			return IRCSentiment.Negative;
		}
		return IRCSentiment.Neutral;
	}

	private IRCSentiment GetBugsSentiment(Snapshot s)
	{
		if (s.BugSoftCap <= 0f)
		{
			return IRCSentiment.Neutral;
		}
		float num = s.BugSoftCap * bugsVeryLowRatioOfSoftCap;
		if (s.Bugs <= num)
		{
			return IRCSentiment.Positive;
		}
		if (s.Bugs >= s.BugSoftCap)
		{
			return IRCSentiment.Negative;
		}
		return IRCSentiment.Neutral;
	}

	private IRCSentiment GetPingSentiment(Snapshot s)
	{
		float pingMinorTolerance = s.PingMinorTolerance;
		if (s.Ping <= pingMinorTolerance)
		{
			return IRCSentiment.Positive;
		}
		if (s.Ping >= s.PingMajorTolerance)
		{
			return IRCSentiment.Negative;
		}
		return IRCSentiment.Neutral;
	}

	private IRCSentiment GetAuctionSentiment(Snapshot s)
	{
		return s.AuctionState switch
		{
			AuctionSentimentState.Positive => IRCSentiment.Positive, 
			AuctionSentimentState.Negative => IRCSentiment.Negative, 
			_ => IRCSentiment.Neutral, 
		};
	}

	private void TriggerMessage(LocTable table, Action<LocalizedString> configureMessage = null)
	{
		LocalizedString noRepeatMessage = GetNoRepeatMessage(table);
		LocalizedString username = LocalizationUtility.Random(LocTable.Names);
		Color color = EnumUtility.GetRandom<IRCColor>().Value();
		configureMessage?.Invoke(noRepeatMessage);
		Database.Commands.IRC.Print(IRCChannel.Default, username, noRepeatMessage, color);
	}

	private LocalizedString GetNoRepeatMessage(LocTable table)
	{
		LocalizedString localizedString = LocalizationUtility.Random(table);
		for (int i = 0; i < 5; i++)
		{
			if (!_messageRepeatBuffer.Contains(localizedString.TableEntryReference.KeyId))
			{
				break;
			}
			localizedString = LocalizationUtility.Random(table);
		}
		_messageRepeatBuffer.AddLast(localizedString.TableEntryReference.KeyId);
		return localizedString;
	}
}

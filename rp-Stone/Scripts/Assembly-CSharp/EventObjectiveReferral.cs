using System;

public class EventObjectiveReferral : EventObjectiveBase
{
	private int lastRedemptionCount = -1;

	public EventObjectiveReferral(int goal)
		: base("referral", goal)
	{
		description = Te.xt("tid_q_basic_give_ref_code");
	}

	public override bool CheckConditions()
	{
		if (ReferralController.singleton.data != null)
		{
			return ReferralController.singleton.data.referralKey != null;
		}
		return false;
	}

	public override void Init()
	{
		ReferralController singleton = ReferralController.singleton;
		singleton.OnReferralDataChanged = (Action<ReferralDataModel>)Delegate.Combine(singleton.OnReferralDataChanged, new Action<ReferralDataModel>(HandleReferralDataChanged));
		if (ReferralController.singleton.data != null)
		{
			HandleReferralDataChanged(ReferralController.singleton.data);
		}
	}

	public override void End()
	{
		ReferralController singleton = ReferralController.singleton;
		singleton.OnReferralDataChanged = (Action<ReferralDataModel>)Delegate.Remove(singleton.OnReferralDataChanged, new Action<ReferralDataModel>(HandleReferralDataChanged));
	}

	private void HandleReferralDataChanged(ReferralDataModel data)
	{
		if (data == null)
		{
			return;
		}
		description = Te.xt("Give your Scotty referral code to a friend:") + " " + data.referralKey;
		base.hasChangedDescription = true;
		int value = data.redemptionCount.GetValue();
		if (value > lastRedemptionCount)
		{
			if (lastRedemptionCount >= 0)
			{
				AddProgress(value - lastRedemptionCount);
			}
			lastRedemptionCount = value;
		}
	}

	public override void ClearProgress()
	{
		base.ClearProgress();
		lastRedemptionCount = -1;
	}

	protected override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		lastRedemptionCount = SlimJson.ParseInt(sjson, "refs", -1);
	}

	protected override void SerializeMore()
	{
		base.SerializeMore();
		if (lastRedemptionCount >= 0)
		{
			SlimJson.AddProperty("refs", lastRedemptionCount);
		}
	}
}

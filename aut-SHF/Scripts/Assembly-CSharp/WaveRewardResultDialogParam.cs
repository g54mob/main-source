using System.Collections.Generic;
using UnityEngine.Events;

public class WaveRewardResultDialogParam
{
	public List<eUpgradePack> rewardList;

	public UnityAction callback;

	public WaveRewardResultDialogParam(List<eUpgradePack> rewardList, UnityAction callback = null)
	{
	}
}

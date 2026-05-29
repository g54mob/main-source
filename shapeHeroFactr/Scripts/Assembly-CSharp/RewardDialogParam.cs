using System.Collections.Generic;
using UnityEngine.Events;

public class RewardDialogParam : BaseDialogParam
{
	public List<eUpgradePack> rewardPack;

	public UnityAction callback;

	public int designatedChoice;

	public List<int> designatedRewards;

	public bool enableReload;

	public RewardDialogParam(List<eUpgradePack> rewardPack, UnityAction callback = null, int designatedChoice = -1, List<int> designatedRewards = null, bool enableReload = true, bool enableCloseButton = true, bool enableEscape = true)
		: base(enableCloseButton: false, enableEscape: false)
	{
	}
}

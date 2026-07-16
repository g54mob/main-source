using UnityEngine;

[CreateAssetMenu(fileName = "FireTrain", menuName = "Trains/NewFireTrain")]
public class FireTrain : NewTrainBase
{
	[field: SerializeField]
	public float BurnStacksGain { get; private set; }

	protected override void ApplyPassive()
	{
		base.ApplyPassive();
		GlobalFields.Instance.PlayerBurnStackAdd += BurnStacksGain;
		Train.Instance.fireTrainAnimator.gameObject.SetActive(value: true);
	}

	protected override void RemovePassive(bool isRemoveAll = false)
	{
		base.RemovePassive();
		Train.Instance.fireTrainAnimator.gameObject.SetActive(value: false);
		if (!isRemoveAll)
		{
			GlobalFields.Instance.PlayerBurnStackAdd -= BurnStacksGain;
		}
	}

	public override bool CheckUnlockRequirements()
	{
		if (Train.Instance.GetTrainByType(TrainType.Regular).WorldBeaten >= 3 && Train.Instance.GetTrainByType(TrainType.Warp).WorldBeaten >= 3 && Train.Instance.GetTrainByType(TrainType.Cannon).WorldBeaten >= 3 && Train.Instance.GetTrainByType(TrainType.Armored).WorldBeaten >= 3)
		{
			return true;
		}
		return false;
	}
}

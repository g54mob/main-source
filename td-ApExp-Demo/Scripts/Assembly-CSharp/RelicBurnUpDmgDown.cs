using UnityEngine;

[CreateAssetMenu(fileName = "RelicBurnUpDmgDown", menuName = "Upgrade/Relic/BurnUpDmgDown")]
public class RelicBurnUpDmgDown : EnhancementUpgrade
{
	[SerializeField]
	[Range(0f, 1f)]
	private float newDmgMult = 0.3f;

	[SerializeField]
	private float newBurnAdd = 1f;

	private float preBuffBurnDmgMult = 1f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.ModifyPlayerDamageMultiplier(newDmgMult);
		GlobalFields.Instance.PlayerBurnStackAdd += newBurnAdd;
		preBuffBurnDmgMult = GlobalFields.Instance.PlayerBurnDmgMult;
		GlobalFields.Instance.PlayerBurnDmgMult = preBuffBurnDmgMult * ((GlobalFields.Instance.AllPlayerDmgMult + newDmgMult) / GlobalFields.Instance.AllPlayerDmgMult);
	}

	public override void OnRemove()
	{
		base.OnRemove();
		GlobalFields.Instance.ModifyPlayerDamageMultiplier(0f - newDmgMult);
		GlobalFields.Instance.PlayerBurnStackAdd -= newBurnAdd;
		GlobalFields.Instance.PlayerBurnDmgMult = preBuffBurnDmgMult;
	}
}

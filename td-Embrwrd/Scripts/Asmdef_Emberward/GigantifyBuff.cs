using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/巨大化", order = 1)]
public class GigantifyBuff : ABaseBuffSettingData
{
	protected override void ApplyEffect()
	{
	}

	private void Gigantify(TetrisCardData tetrisCardData, int index)
	{
	}

	protected override void RemoveEffect()
	{
	}

	public override void PreRegisterProc(ABaseTower tower)
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}

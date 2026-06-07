using UnityEngine;

[CreateAssetMenu(fileName = "EventStageSettingData_", menuName = "設定檔/關卡/EventStageSettingData", order = 1)]
public class EventStageSettingData : ABaseStageSettingData
{
	[SerializeField]
	protected eEventStageType eventType;

	[SerializeField]
	[Header("屬於哪個世界的事件")]
	protected eWorldType worldType;

	[SerializeField]
	protected Sprite sprite_BGTexture;

	private void OnValidate()
	{
	}

	public override string GetLocalization_Description()
	{
		return null;
	}

	public override string GetLocalization_Title()
	{
		return null;
	}
}

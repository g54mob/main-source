using UnityEngine;

public abstract class ABaseStageSettingData : ScriptableObject
{
	[SerializeField]
	[TextArea]
	private string Note;

	[SerializeField]
	protected eStageType stageType;

	public abstract string GetLocalization_Title();

	public abstract string GetLocalization_Description();
}

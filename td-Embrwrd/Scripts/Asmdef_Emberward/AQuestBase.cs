using UnityEngine;

public abstract class AQuestBase : MonoBehaviour
{
	protected QuestManager manager;

	protected eQuestType challengeType;

	protected QuestData questData;

	protected eQuestStatus status;

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	public void Setup(QuestManager manager, eQuestType challengeType, QuestData data)
	{
	}

	public void SwitchStatus(eQuestStatus status)
	{
	}

	protected virtual void OnSetupProc()
	{
	}

	public abstract bool IsQuestSuccess();
}

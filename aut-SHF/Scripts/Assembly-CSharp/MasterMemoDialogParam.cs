using UnityEngine.Events;

public class MasterMemoDialogParam
{
	public UnityAction callback;

	public eMasterMemo[] masterMemoIds;

	public MasterMemoDialogParam(eMasterMemo[] masterMemoIds, UnityAction postProcess = null)
	{
	}
}

using UnityEngine;

public class StepPageSlot : MonoBehaviour
{
	[SerializeField]
	private string pageId;

	[SerializeField]
	private int pageNumber;

	[SerializeField]
	private int pageTotal;

	public (string pageId, int pageNumber, int pageTotal) GetStepPageInfos()
	{
		return (pageId: pageId, pageNumber: pageNumber, pageTotal: pageTotal);
	}
}

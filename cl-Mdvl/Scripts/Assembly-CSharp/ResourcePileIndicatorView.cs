using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

public class ResourcePileIndicatorView : MonoBehaviour
{
	private MeshRenderer meshRenderer;

	[SerializeField]
	private Material forbiddenMaterial;

	[SerializeField]
	private Material urgentHaulMaterial;

	private ResourcePileIndicatorStatus currentStatus;

	public void SetIndicator(ResourcePileIndicatorStatus indicatorStatus)
	{
		if (currentStatus != indicatorStatus)
		{
			currentStatus = indicatorStatus;
			MonoSingleton<ResourcePileManager>.Instance.IndicatorsToUpdate.Add(this);
		}
	}

	public void UpdateMeshRenderer()
	{
		meshRenderer = (meshRenderer ? meshRenderer : GetComponent<MeshRenderer>());
		meshRenderer.enabled = true;
		switch (currentStatus)
		{
		case ResourcePileIndicatorStatus.Forbidden:
			meshRenderer.sharedMaterial = forbiddenMaterial;
			break;
		case ResourcePileIndicatorStatus.UrgentHaul:
			meshRenderer.sharedMaterial = urgentHaulMaterial;
			break;
		default:
			meshRenderer.enabled = false;
			break;
		}
	}

	public ResourcePileIndicatorStatus GetIndicator()
	{
		return currentStatus;
	}
}

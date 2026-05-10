using UnityEngine;

public class ReachableSourceIndicator : MonoBehaviour
{
	[SerializeField]
	private LineRenderer lineRenderer;

	private Source source;

	private PlacementComponent placementComponent;

	public Source Source => source;

	public void Setup(PlacementComponent placementComponent, Source source)
	{
		this.placementComponent = placementComponent;
		this.source = source;
		lineRenderer.useWorldSpace = true;
		lineRenderer.SetPosition(0, placementComponent.GetCenter());
		lineRenderer.SetPosition(1, source.PlacementComponent.GetCenter());
	}

	private void Update()
	{
		lineRenderer.SetPosition(0, placementComponent.GetCenter());
	}
}

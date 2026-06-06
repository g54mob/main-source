using UnityEngine;

public class TargetActivator : MonoBehaviour
{
	public Target Target;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[ContextMenu("Activate target")]
	private void ActivateTarget()
	{
		Target.PrimaryMarker.AddToConstructionGraph();
	}
}

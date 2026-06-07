using UnityEngine;

public class ItemIconRendererOffsetReset : MonoBehaviour
{
	[SerializeField]
	private ItemsConfig itemsConfig;

	[InspectorButton("ResetOffsets", true, true)]
	public bool resetOffsets;

	private void ResetOffsets()
	{
	}
}

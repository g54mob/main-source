using UnityEngine;

public class StorageVisual : VisualPrefab, IOutlineRenderControllerProvider
{
	[SerializeField]
	private bool _addOutlineRendererController;

	public ItemProperties ItemProperties { get; private set; }

	public OutlineRenderController OutlineController { get; private set; }

	public void Initialize(ItemProperties properties)
	{
		ItemProperties = properties;
		base.gameObject.name = "StorageVisual" + properties.name;
		if (_addOutlineRendererController)
		{
			OutlineController = base.gameObject.AddComponent<OutlineRenderController>();
		}
	}
}

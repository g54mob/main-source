using System.Collections.Generic;
using UnityEngine;

public class PlaceholderBlockBody : MonoBehaviour
{
	private struct ChildRenderer
	{
		public Renderer renderer;

		public CustomBlockMaterial customBlockMaterial;
	}

	private GlobalMaterialManager materialManager;

	private Renderer thisRenderer;

	private List<ChildRenderer> childrenRenderer;

	public ObjectsInCollision BlocksInCollision { get; set; }

	public bool IsColliding { get; private set; }

	public bool IsBlockColliding => BlocksInCollision.BlockObjectsCounter > 0;

	public bool IsLevelObjectColliding => BlocksInCollision.LevelObjectsCounter > 0;

	public bool IsDelimitationZoneColliding => !BlocksInCollision.IsInsideConstructionZone;

	public bool ShouldCheckForBlocks { get; set; } = true;

	public bool ShouldCheckForLevelObject { get; set; } = true;

	public bool ShouldCheckForDelimitationZone { get; set; } = true;

	private void Awake()
	{
		materialManager = GlobalMaterialManager.Instance;
		thisRenderer = GetComponent<Renderer>();
		thisRenderer.sharedMaterial = materialManager.PlaceholderGreenMaterial;
		childrenRenderer = new List<ChildRenderer>();
		Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!(renderer is SpriteRenderer) && !(renderer.transform == base.transform))
			{
				CustomBlockMaterial component = renderer.gameObject.GetComponent<CustomBlockMaterial>();
				renderer.sharedMaterial = ((component != null) ? component.Green : materialManager.PlaceholderGreenMaterial);
				childrenRenderer.Add(new ChildRenderer
				{
					renderer = renderer,
					customBlockMaterial = component
				});
			}
		}
	}

	private void Update()
	{
		if ((BlocksInCollision.BlockObjectsCounter > 0 && ShouldCheckForBlocks) || (BlocksInCollision.LevelObjectsCounter > 0 && ShouldCheckForLevelObject) || (!BlocksInCollision.IsInsideConstructionZone && ShouldCheckForDelimitationZone))
		{
			IsColliding = true;
			if (!(thisRenderer.sharedMaterial != materialManager.PlaceholderRedMaterial))
			{
				return;
			}
			thisRenderer.sharedMaterial = materialManager.PlaceholderRedMaterial;
			childrenRenderer.ForEach(delegate(ChildRenderer childRenderer)
			{
				if (childRenderer.customBlockMaterial == null)
				{
					childRenderer.renderer.sharedMaterial = materialManager.PlaceholderRedMaterial;
				}
				else
				{
					childRenderer.renderer.sharedMaterial = childRenderer.customBlockMaterial.Red;
				}
			});
			return;
		}
		IsColliding = false;
		if (!(thisRenderer.sharedMaterial != materialManager.PlaceholderGreenMaterial))
		{
			return;
		}
		thisRenderer.sharedMaterial = materialManager.PlaceholderGreenMaterial;
		childrenRenderer.ForEach(delegate(ChildRenderer childRenderer)
		{
			if (childRenderer.customBlockMaterial == null)
			{
				childRenderer.renderer.sharedMaterial = materialManager.PlaceholderGreenMaterial;
			}
			else
			{
				childRenderer.renderer.sharedMaterial = childRenderer.customBlockMaterial.Green;
			}
		});
	}
}

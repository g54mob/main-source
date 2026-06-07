using UnityEngine;

public class DrawerContentGadget : DrawerContent, ArchiveController.IGadgetPreviewListener
{
	private SerializedGadgetMetaData gadgetMetadata;

	private Gadget gadget;

	private PrintedGadgetCard printedGadgetCard;

	private SpriteRenderer spriteRenderer;

	private Material material;

	private PolygonCollider2D spriteCollider;

	private SpriteShadow spriteShadow;

	private Interactable spriteInteractable;

	private Vector2 size;

	private Vector2 pivot;

	private ArchiveController.GadgetPreview preview;

	public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public void SetGadgetMetadata(SerializedGadgetMetaData gadgetMetadata, Mask mask)
	{
	}

	public override float GetSize(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMin(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMax(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	private void InitSpriteRenderer(Mask mask)
	{
	}

	public Gadget SpawnGadget()
	{
		return null;
	}

	public SerializedGadgetMetaData GetGadgetMetadata()
	{
		return null;
	}

	private void LateUpdate()
	{
	}

	public void OnPreviewUpdate(ArchiveController.GadgetPreview preview)
	{
	}

	private void OnDestroy()
	{
	}
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class PrintedGadgetCard : MonoBehaviour
{
	public SortingGroup sortingGroup;

	public Holder.TransitionDurations transitionDuration;

	public Ease ease;

	public SpriteRenderer[] spriteRenderers;

	public TextLabel[] textRenderers;

	private Gadget gadget;

	private DrawerContentGadget drawerGadget;

	private Transform tablePosition;

	private Motherboard.Position position;

	private Sequence tween;

	private static GameObject prefab;

	public bool isMoving => false;

	private static PrintedGadgetCard Create()
	{
		return null;
	}

	public static PrintedGadgetCard Create(Gadget gadget)
	{
		return null;
	}

	public static PrintedGadgetCard Create(DrawerContentGadget drawerGadget)
	{
		return null;
	}

	private void SetGadget(Gadget gadget)
	{
	}

	private void SetDrawerGadget(DrawerContentGadget drawerGadget)
	{
	}

	public void SetPosition(Motherboard.Position position, bool immediate)
	{
	}

	private void SetMaskInteraction(SpriteMaskInteraction maskInteraction)
	{
	}

	private void OnDestroy()
	{
	}
}

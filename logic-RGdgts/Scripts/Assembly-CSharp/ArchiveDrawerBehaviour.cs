using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArchiveDrawerBehaviour : ScrollableDrawerBehaviour
{
	public interface IListener
	{
		void OnArchiveDrawerShowGadget(SerializedGadgetMetaData metadata);
	}

	public class Slot
	{
		public uint gadgetGuid;

		public DrawerContentGadget gadgetContent;

		public DrawerContentTextLabel labelContent;

		public float GetCenter(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public Vector3 GetGadgetScenePosition(Gadget gadget)
		{
			return default(Vector3);
		}
	}

	public GameObject labelPrefab;

	public GameObject separatorPrefab;

	public Material blitCameraMaterial;

	public float additionalEndSpace;

	public const float layoutSepatatorHalfSize = 2.8541667f;

	public const float layoutSeparatorTopSpace = 0.8333334f;

	public const float layoutSeparatorBottomSpace = 0.625f;

	public const float layoutTextSpace = 0.4166667f;

	private bool needRefresh;

	private int layer;

	private List<Slot> slots;

	private List<DrawerContentSprite> separators;

	private Slot currentSlot;

	private Tween scrollTween;

	private List<IListener> listeners;

	private Dictionary<SerializedGadgetMetaData, DrawerContentGadget> reusableGadgetContents;

	private float GetSlotHeight()
	{
		return 0f;
	}

	public override void Init(Drawer drawer)
	{
	}

	public void RegisterListener(IListener listener)
	{
	}

	public void UnregisterListener(IListener listener)
	{
	}

	public override void ClearContents()
	{
	}

	private void ClearReusable()
	{
	}

	public void RefreshContents()
	{
	}

	public float AddGadget(SerializedGadgetMetaData gadgetMeta, float position, ref Slot slot, float offset = 0f, bool bottomPivot = false)
	{
		return 0f;
	}

	public float AddLabel(string text, float position, ref Slot slot, bool bottomPivot = true)
	{
		return 0f;
	}

	public float AddSeparator(float position, out DrawerContentSprite separator, bool bottomPivot = true)
	{
		separator = null;
		return 0f;
	}

	protected override void Update()
	{
	}

	protected override float GetSnappedPosition()
	{
		return 0f;
	}

	private float GetSnappedPosition(out Slot slot)
	{
		slot = null;
		return 0f;
	}

	public void CenterOnGadget(Gadget gadget, bool fast = false, bool immediate = false)
	{
	}

	public bool CenterOnGadget(uint gadgetGuid, bool fast = false, bool immediate = false)
	{
		return false;
	}

	protected override float GetMinPosition()
	{
		return 0f;
	}

	protected override float GetMaxPosition()
	{
		return 0f;
	}

	public void AutoScrollToTop(float time, AnimationCurve animationCurve)
	{
	}

	public Slot GetGadgetSlot(uint gadgetGuid)
	{
		return null;
	}

	public Vector3 GetGadgetDestination(Gadget gadget)
	{
		return default(Vector3);
	}

	public override void OnDrawerOpen()
	{
	}

	public override void OnDrawerClose()
	{
	}
}

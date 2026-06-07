using System.Collections.Generic;
using IntervalTree;
using SE.EvilLib.AudioManager;
using UnityEngine;

public class ScrollableDrawerBehaviour : DrawerBehaviour
{
	public float scrollSpeed;

	public float smoothTime;

	public SpriteRenderer background;

	public BoxCollider2D backgroundCollider;

	public Mask mask;

	public Transform scrollableRoot;

	public bool playScroolForwardSound;

	public AudioTypeSfx scrollForwardSound;

	public bool playScroolBackwardSound;

	public AudioTypeSfx scrollBackwardSound;

	[SortingLayer]
	public int contentSortingLayerID;

	public int contentSortingOrder;

	protected float endSpace;

	protected float viewLength;

	private float totalLength;

	protected bool fastPositionMovement;

	protected float fastPositionMovementTime;

	protected float position;

	protected float _position;

	private bool needRefreshTree;

	protected IntervalTree<float, DrawerContent> tree;

	protected List<DrawerContent> visibleContents;

	private float positionVel;

	protected float lastUserScrollTime;

	private float lastSnappedPosition;

	private float lastScrollTime;

	public override void Init(Drawer drawer)
	{
	}

	public void RefreshBackground()
	{
	}

	public void AddContent(DrawerContent content, float position, float offset = 0f, int sortingOrderOffset = 0, DrawerContentSubpanel subpanel = null)
	{
	}

	public virtual void ClearContents()
	{
	}

	public void RemoveContent(DrawerContent content)
	{
	}

	public void SetDirty()
	{
	}

	private void RefreshTree()
	{
	}

	protected float SnapPixel(float value)
	{
		return 0f;
	}

	protected void Refresh()
	{
	}

	protected virtual float GetSnappedPosition()
	{
		return 0f;
	}

	protected virtual float GetMinPosition()
	{
		return 0f;
	}

	protected virtual float GetMaxPosition()
	{
		return 0f;
	}

	protected virtual void Update()
	{
	}

	public bool IsMoving()
	{
		return false;
	}

	protected void SetSubpanelLength(DrawerContentSubpanel subpanel, float length, float extraLength)
	{
	}

	protected void RefreshSubpanel(DrawerContentSubpanel subpanel)
	{
	}
}

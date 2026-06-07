using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WireBaseMobileTool : ToolBase
{
	[Header("Creation")]
	public Image methodImage;

	public Text methodText;

	public Text cancelText;

	public Sprite methodP2p;

	public Sprite methodFreehand;

	public string stringP2p;

	public string stringFreehand;

	protected bool freehand;

	[Header("Viewport")]
	public EventTrigger viewportTrigger;

	[Header("Vars")]
	public float wireDepth;

	public float wireHeight;

	protected List<Vector3> wirePoints;

	protected readonly int compMask;

	protected Ray ray;

	protected RaycastHit hit;

	protected TiePoint curPoint;

	protected BaseComponent hitComp;

	protected int c;

	private int undoCounter;

	private bool cancelCurrentClicked;

	private float clickT;

	private bool frameDelay;

	private bool viewportDown;

	private TiePoint startPoint;

	protected Vector3 prevPoint;

	public void AddEventTriggerListener(EventTriggerType eventType, Action<BaseEventData> callback)
	{
	}

	public virtual void SwitchMethod()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void CancelEdit()
	{
	}

	public virtual void Initialise()
	{
	}

	public override void BeginCreate()
	{
	}

	public virtual void ProcessVarDataBegin()
	{
	}

	public override void CompleteCreate()
	{
	}

	public virtual void ProcessVarDataComplete()
	{
	}

	public virtual void EndCreation()
	{
	}

	public override void ResetMobile()
	{
	}

	public virtual void CancelCurrent()
	{
	}

	public override void CancelCreation()
	{
	}

	public override void Delete()
	{
	}

	public void ViewportClicked(BaseEventData e)
	{
	}

	private void IPC_ViewPortClicked()
	{
	}

	public void ViewportDown(BaseEventData e)
	{
	}

	public override void Update()
	{
	}

	public void ViewportUp(BaseEventData e)
	{
	}

	public virtual void ProcessVarDataDrag()
	{
	}
}

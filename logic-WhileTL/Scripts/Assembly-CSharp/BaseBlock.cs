using System;
using System.Collections.Generic;
using Aux;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseBlock : ActiveComponent, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
	[SceneBind("Speed")]
	protected Text Speed;

	[SceneBind("ZoomLayer")]
	protected RectTransform ZoomLayer;

	private bool boundsCheck;

	private List<Construction.BlockInScheme> drags;

	public static Rect constructionBounds;

	public float error;

	public float minError;

	protected System.Random BlockRandom;

	protected BlockData bd;

	public bool hasDropdown;

	private Vector2 screenCenter = new Vector2(Screen.width, Screen.height) / 2f;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	protected float timer;

	protected float delayTimer;

	protected float lastActiveTime;

	protected string keyName = string.Empty;

	protected float value;

	protected static readonly int maxSockets = 5;

	public bool tutorial;

	public bool enteredToScheme;

	public static Rect AlgoBlockBounds => Helper.ExpandRect(Helper.GetWorldRect(ActiveComponent.Model.construction.algoBlockRectTransform), -5f);

	public virtual bool IsTrained()
	{
		return true;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
	}

	public static void InitBounds()
	{
		constructionBounds = Helper.ExpandRect(Helper.GetWorldRect(ActiveComponent.Model.construction.constrBlock), -2f);
	}

	public void ResetRandom()
	{
		BlockRandom = new System.Random(1234);
	}

	protected override void OnInit()
	{
		base.OnInit();
		hasDropdown = false;
		bd = base.gameObject.GetComponent<BlockData>();
		ResetRandom();
		screenCenter = new Vector2(Screen.width, Screen.height) / 2f;
		SceneBindContainer.BindObjects(this, base.transform);
		if (ZoomLayer != null)
		{
			ZoomLayer.gameObject.SetActive(value: false);
		}
		socketsIn.Clear();
		socketsOut.Clear();
		for (int i = 0; i < maxSockets; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		timer = 0f;
		lastActiveTime = 0f;
	}

	public void SetZoom(float zoom)
	{
		if (!(ZoomLayer != null) || !ActiveComponent.Model.globalSaves.enableLockZoom)
		{
			return;
		}
		bool flag = zoom < ActiveComponent.Model.globalSaves.maxLockedZoom;
		ZoomLayer.gameObject.SetActive(flag);
		foreach (Socket item in socketsIn)
		{
			if (item != null)
			{
				item.SetLocked(flag);
			}
		}
		foreach (Socket item2 in socketsOut)
		{
			if (item2 != null)
			{
				item2.SetLocked(flag);
			}
		}
	}

	public void SetDrags(List<Construction.BlockInScheme> dragList)
	{
		drags = dragList;
	}

	public void SetBoundsCheck(bool state)
	{
		boundsCheck = state;
	}

	public Socket GetSocketId(bool incoming, int id)
	{
		if (id > maxSockets)
		{
			return null;
		}
		if (incoming)
		{
			return socketsIn[id];
		}
		return socketsOut[id];
	}

	public void ClearSockets(List<Socket> sockets)
	{
		foreach (Socket socket in sockets)
		{
			if (socket != null)
			{
				socket.Clear();
			}
		}
	}

	public void ClearSockets()
	{
		ClearSockets(socketsIn);
		ClearSockets(socketsOut);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!base.enabled)
		{
			return;
		}
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			eventData.pointerDrag = null;
			return;
		}
		ActiveComponent.Model.construction.interactState = Construction.DragInteraction.Block;
		base.gameObject.GetComponent<BlockData>().dragged = true;
		Logic.GetMouseInWorld();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_BlockFromList");
		if (ActiveComponent.Model.construction.selectedBlocks.Count <= 1)
		{
			base.transform.SetParent(ActiveComponent.Model.construction.algoBlockDrag);
		}
		else
		{
			if (!ActiveComponent.Program.cursor.Visible())
			{
				return;
			}
			base.transform.SetParent(ActiveComponent.Model.construction.GetAlgoTransform());
			foreach (Construction.BlockInScheme selectedBlock in ActiveComponent.Model.construction.selectedBlocks)
			{
				if (selectedBlock.go != base.gameObject)
				{
					selectedBlock.SetParent(base.transform);
					selectedBlock.go.transform.SetAsFirstSibling();
				}
			}
			ActiveComponent.Model.construction.draggingParent = base.gameObject;
			BaseBlock component = base.gameObject.GetComponent<BaseBlock>();
			component.SetBoundsCheck(ActiveComponent.Model.construction.selectedBlocks.Count > 1);
			component.SetDrags(ActiveComponent.Model.construction.selectedBlocks);
			ActiveComponent.Model.construction.draggingParent.transform.SetParent(ActiveComponent.Model.construction.algoBlockDrag, worldPositionStays: true);
		}
	}

	private void PreventCursorDeleteWithDropdownCanvas()
	{
		if (!hasDropdown || ActiveComponent.Model.construction.testMode || Input.touchCount <= 0 || ActiveComponent.Program.cursor.OnDefaultCanvas())
		{
			return;
		}
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began)
			{
				Vector3 point = Helper.TouchToWorldPoint(touch, Program.mainCam);
				if (!ActiveComponent.Program.cursor.curWorldRect.Contains(point))
				{
					ActiveComponent.Program.cursor.SetCanvas(null);
					break;
				}
			}
		}
	}

	private void Update()
	{
		PreventCursorDeleteWithDropdownCanvas();
	}

	private void LateUpdate()
	{
		PreventCursorDeleteWithDropdownCanvas();
	}

	public void Record()
	{
		if (ActiveComponent.Model.construction.recordingAllowed && base.gameObject.activeSelf)
		{
			ActiveComponent.Model.construction.GetCurCathub().RecordHistory();
			ActiveComponent.Model.construction.RedoUndoButtonsStatesUpdate();
		}
	}

	public void AddRecordToEvent(Dropdown.DropdownEvent ev)
	{
		ev.RemoveAllListeners();
		ev.AddListener(delegate
		{
			Record();
		});
	}

	public void ListenCloseDropdown(Dropdown dr, int normalChildCount)
	{
		dr.onValueChanged.AddListener(delegate
		{
			ActiveComponent.Program.cursor.SetCanvas(null);
		});
	}

	public virtual void Redraw()
	{
	}

	public virtual void Clear()
	{
		ClearSockets();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!base.enabled || ActiveComponent.Model.construction.interactState == Construction.DragInteraction.ConstrArea)
		{
			return;
		}
		if ((!ActiveComponent.Model.construction.IsInDeleteZone(base.gameObject) || ActiveComponent.Model.construction.attached == null) && ActiveComponent.Model.construction.CanPlaceInConstrBlock())
		{
			if (ActiveComponent.Model.construction.PlaceNodeTutorial.gameObject.activeInHierarchy)
			{
				base.transform.position = ActiveComponent.Model.construction.PlaceNodeTutorial.transform.position;
			}
			Rect rect = Helper.GetWorldRect(base.gameObject.GetComponent<RectTransform>());
			if (drags != null)
			{
				rect = Construction.GetMultipleBlocksRect(drags);
			}
			Rect algoBlockBounds = AlgoBlockBounds;
			Vector3 position = base.transform.position;
			if (rect.max.x > algoBlockBounds.max.x)
			{
				position.x -= rect.max.x - algoBlockBounds.max.x;
			}
			else if (rect.min.x < algoBlockBounds.min.x)
			{
				position.x += algoBlockBounds.min.x - rect.min.x;
			}
			if (rect.max.y > algoBlockBounds.max.y)
			{
				position.y -= rect.max.y - algoBlockBounds.max.y;
			}
			else if (rect.min.y < algoBlockBounds.min.y)
			{
				position.y += algoBlockBounds.min.y - rect.min.y;
			}
			base.transform.position = position;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Install");
			base.transform.SetParent(ActiveComponent.Model.construction.GetAlgoTransform());
			ActiveComponent.Model.construction.GetCurCathub().RecordHistory();
			ActiveComponent.Model.construction.RedoUndoButtonsStatesUpdate();
		}
		else
		{
			if (ActiveComponent.Model.construction.IsInDeleteZone(base.gameObject))
			{
				ActiveComponent.Model.construction.isPenNow = false;
				ActiveComponent.Model.construction.interactState = Construction.DragInteraction.None;
				ActiveComponent.Model.construction.CheckDelete(base.gameObject);
				return;
			}
			base.transform.SetParent(ActiveComponent.Model.construction.GetAlgoTransform());
		}
		ActiveComponent.Model.construction.SetAllParentsToDefault();
		base.gameObject.GetComponent<BlockData>().dragged = false;
		ActiveComponent.Model.construction.isPenNow = false;
		ActiveComponent.Model.construction.interactState = Construction.DragInteraction.None;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!base.enabled || ActiveComponent.Model.construction.interactState == Construction.DragInteraction.ConstrArea)
		{
			return;
		}
		if (ActiveComponent.Model.construction.testMode)
		{
			OnEndDrag(null);
			return;
		}
		ActiveComponent.Model.construction.isPenNow = false;
		Vector3 vector = Camera.main.ScreenToWorldPoint(eventData.delta + screenCenter);
		vector.z = 0f;
		Vector3 position = base.transform.position + vector;
		Rect innerRect = Helper.GetWorldRect(base.gameObject.GetComponent<RectTransform>());
		if (drags != null)
		{
			innerRect = Construction.GetMultipleBlocksRect(drags);
		}
		innerRect.center += (Vector2)vector;
		Vector3 zero = Vector3.zero;
		if (innerRect.xMax > constructionBounds.xMax)
		{
			zero.x = 1f;
		}
		else if (innerRect.xMin < constructionBounds.xMin)
		{
			zero.x = -1f;
		}
		if (innerRect.yMax > constructionBounds.yMax)
		{
			zero.y = 1f;
		}
		else if (innerRect.yMin < constructionBounds.yMin)
		{
			zero.y = -1f;
		}
		ActiveComponent.Model.construction.penDelta = zero * ActiveComponent._staticData.Settings.PenSpeed;
		ActiveComponent.Model.construction.draggingParentBlock = base.transform;
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && !Helper.RectContainsRect(constructionBounds, innerRect))
		{
			ActiveComponent.Model.construction.isPenNow = true;
		}
		else
		{
			base.transform.position = position;
		}
	}

	protected abstract bool TryActive();

	protected abstract void Active();

	public override void Init()
	{
		base.Init();
	}

	private void Awake()
	{
	}

	protected virtual void FixedUpdate()
	{
		if (((bd.dummy || !base.gameObject.activeInHierarchy) && !tutorial) || (!ActiveComponent.Model.construction.testMode && !tutorial))
		{
			return;
		}
		foreach (Socket item in socketsIn)
		{
			if (item != null && item.queue.Count == 0)
			{
				lastActiveTime = Time.fixedTime;
			}
		}
		if (Mathf.Abs(Time.fixedTime - lastActiveTime - delayTimer) <= 0.01f || Time.fixedTime - lastActiveTime >= delayTimer)
		{
			Active();
			lastActiveTime = Time.fixedTime;
		}
	}
}

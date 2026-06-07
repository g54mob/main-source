using System;
using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Socket : ActiveComponent, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public class Connections
	{
		public struct Flags
		{
			public int src;

			public int dest;
		}

		public MultiDictionary<int, Flags> In = new MultiDictionary<int, Flags>();

		public MultiDictionary<int, Flags> Out = new MultiDictionary<int, Flags>();

		public void AddConnection(bool incoming, int srcFlags, int destHash, int destFlags)
		{
			MultiDictionary<int, Flags> obj = (incoming ? In : Out);
			Flags value = default(Flags);
			value.src = srcFlags;
			value.dest = destFlags;
			obj.Add(destHash, value);
		}
	}

	[SceneBind("IconSocketOk")]
	public Image iconOk;

	[SceneBind("IconSocketNo")]
	public Image iconCross;

	private Color locked;

	private Color active;

	private Color deactive;

	public bool dummy;

	public Action onBeginDragAction;

	public Action onEndDragAction;

	public bool constrSocket;

	public bool hover;

	public List<Element> queue = new List<Element>();

	public List<Element> backQueue = new List<Element>();

	public List<Chain> inChains = new List<Chain>();

	public Chain chain;

	public string type;

	public float sumElementsInSocket;

	public float emptyTime;

	private float emptyBufTime;

	public float overloadTime;

	private float overloadBufTime;

	public bool inSocket;

	public int dataNum = -1;

	public int resultNum = -1;

	public int num;

	public int blockNumParent;

	public bool catcherSocket;

	private Button selfBtn;

	private CustomProgressBar bar;

	private GameObject glowObj;

	private bool lockedZoom;

	private float timer = -1f;

	public bool inGame;

	private int couElems;

	public int BlockNumParent
	{
		get
		{
			return blockNumParent;
		}
		set
		{
			blockNumParent = value;
		}
	}

	public Chain GetFirstInChain()
	{
		foreach (Chain inChain in inChains)
		{
			if (inChain != null)
			{
				return inChain;
			}
		}
		return null;
	}

	public Chain GetFirstOutChain()
	{
		return chain;
	}

	public Chain GetChain(bool createOnDemand = false)
	{
		Chain chain = (inSocket ? GetFirstInChain() : GetFirstOutChain());
		if (chain == null && createOnDemand)
		{
			chain = ActiveComponent.Model.construction.CreateChain();
		}
		return chain;
	}

	public Chain GetOrCreateChain()
	{
		return GetChain(createOnDemand: true);
	}

	public GameObject GetOwningObject()
	{
		return base.transform.parent.gameObject;
	}

	public BlockData GetOwningBlock()
	{
		return GetOwningObject().GetComponent<BlockData>();
	}

	public GameObject GetChainInObject()
	{
		Chain firstInChain = GetFirstInChain();
		if (!(firstInChain != null))
		{
			return null;
		}
		return firstInChain.GetInObject();
	}

	public GameObject GetChainOutObject()
	{
		Chain firstOutChain = GetFirstOutChain();
		if (!(firstOutChain != null))
		{
			return null;
		}
		return firstOutChain.GetOutObject();
	}

	private void DeleteCurrentChain()
	{
		if (!inSocket)
		{
			DropOutChain();
		}
		else
		{
			DropInChains();
		}
		InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
	}

	public void UpdateColors()
	{
		active = Logic.GetColor(type + "ACTIVE");
		locked = Logic.GetColor("RED");
		deactive = Logic.GetColor(type + "DEACTIVE");
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Right)
		{
			DeleteCurrentChain();
		}
		UpdateColors();
		RedrawSocketColor();
	}

	private void Update()
	{
		if (hover && (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)))
		{
			DeleteCurrentChain();
		}
	}

	private void DrawLine(Socket socket)
	{
		if (ActiveComponent.Model.currentChain != null)
		{
			Chain component = ActiveComponent.Model.currentChain.GetComponent<Chain>();
			if (component.socketIn != null && !socket.inSocket)
			{
				component.DestroyGameObject();
				InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
				return;
			}
			if (component.socketOut != null && socket.inSocket)
			{
				component.DestroyGameObject();
				InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
				return;
			}
			if (socket.inSocket)
			{
				component.SetOutSocket(socket);
			}
			else
			{
				if (socket.chain != null)
				{
					socket.DeleteChains();
					InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
				}
				component.SetInSocket(socket);
			}
			ActiveComponent.Model.currentChain = null;
			InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
		}
		else
		{
			if (!socket.inSocket && chain != null)
			{
				chain.DestroyGameObject();
				chain = null;
			}
			Chain chainObjectFromPool = ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, base.transform.position, base.transform.rotation, ActiveComponent.Model.linesContainer.transform);
			chainObjectFromPool.transform.SetParent(ActiveComponent.Model.linesContainer.transform);
			ActiveComponent.Model.currentChain = chainObjectFromPool.gameObject;
			if (socket.inSocket)
			{
				chainObjectFromPool.SetOutSocket(socket);
			}
			else
			{
				if (socket.chain != null)
				{
					socket.DeleteChains();
					InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
				}
				chainObjectFromPool.SetInSocket(socket);
			}
			InvokeEvent(ActiveComponent.Model.construction.startDrawLineEvent);
			chainObjectFromPool.InitDraw();
			chainObjectFromPool.ImgState(state: false);
		}
		if (ActiveComponent.Model.currentChain != null)
		{
			ActiveComponent.Model.currentChain.GetComponent<Button>().enabled = false;
		}
	}

	private void InvokeEvent(UnityEvent e)
	{
		e?.Invoke();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if ((ActiveComponent.Model.construction.interactState != Construction.DragInteraction.ConstrArea || constrSocket) && !lockedZoom)
		{
			CheckBtn();
			if (selfBtn != null)
			{
				selfBtn.enabled = false;
			}
			DrawLine(this);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketStart");
			if (onBeginDragAction != null)
			{
				onBeginDragAction();
			}
			if (ActiveComponent.Model.construction.selectionMode)
			{
				ActiveComponent.Model.construction.DropSelection(ignoreConditions: true);
				ActiveComponent.Model.construction.selectedBlocks.Clear();
				ActiveComponent.Model.construction.selectionMode = false;
			}
		}
	}

	private void CheckBtn()
	{
		if (selfBtn == null)
		{
			selfBtn = base.gameObject.GetComponent<Button>();
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		CheckBtn();
		if (ActiveComponent.Model.currentChain != null)
		{
			ActiveComponent.Model.currentChain.GetComponent<Chain>().InitFromBuffer();
			ActiveComponent.Model.currentChain = null;
			InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
		}
		if (onEndDragAction != null)
		{
			onEndDragAction();
		}
		if (selfBtn != null)
		{
			selfBtn.enabled = true;
		}
	}

	public void GlowLines()
	{
		OffLines(state: false);
	}

	private void ClearEmptyChains()
	{
		for (int i = 0; i < inChains.Count; i++)
		{
			if (inChains[i] == null || !inChains[i].gameObject.activeSelf)
			{
				inChains.RemoveAt(i);
				i--;
			}
		}
		if (chain != null && !chain.gameObject.activeSelf)
		{
			chain = null;
		}
		RedrawSocketColor();
	}

	public void OffLines(bool state = true)
	{
		ClearEmptyChains();
		if (inSocket)
		{
			foreach (Chain inChain in inChains)
			{
				inChain.parentSocketHover = !state;
				inChain.RedrawChooseChain();
			}
			return;
		}
		foreach (Chain inChain2 in inChains)
		{
			inChain2.parentSocketHover = !state;
			inChain2.RedrawChooseChain();
		}
		if (chain != null)
		{
			chain.parentSocketHover = !state;
			chain.RedrawChooseChain();
		}
	}

	public void SetBufferSocket(Socket socket)
	{
		if (ActiveComponent.Model.currentChain != null)
		{
			ActiveComponent.Model.currentChain.GetComponent<Chain>().BufferSocket = socket;
		}
		hover = socket != null;
		OffLines(!hover);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetBufferSocket(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		SetBufferSocket(null);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void DisableSocket()
	{
		if (bar != null)
		{
			bar.gameObject.SetActive(value: false);
			bar.enabled = false;
		}
		Redraw();
		base.gameObject.GetComponent<ZoomOnMouse>().enabled = false;
		base.gameObject.SetActive(value: false);
		base.enabled = false;
	}

	public void MakeActive(bool state)
	{
		base.enabled = state;
	}

	public bool IsActive()
	{
		return base.enabled;
	}

	public void SetInChain(Chain chain, int i)
	{
		inChains[i] = chain;
	}

	public void AddInChain(Chain chain)
	{
		inChains.Add(chain);
	}

	public void SetOutChain(Chain chain)
	{
		DropOutChain();
		this.chain = chain;
	}

	private void DestroyChain(Chain ch)
	{
		if (ch != null)
		{
			ch.DestroyGameObject();
			ch = null;
		}
		RedrawSocketColor();
	}

	public void DropInChain(int i, bool destroyChain = true)
	{
		if (inChains[i] == null)
		{
			inChains.RemoveAt(i);
			RedrawSocketColor();
		}
		else if (i < inChains.Count && inChains[i] != null)
		{
			Chain ch = inChains[i];
			inChains.RemoveAt(i);
			if (destroyChain)
			{
				DestroyChain(ch);
			}
			RedrawSocketColor();
		}
		else
		{
			CheckBtn();
			if (selfBtn != null)
			{
				selfBtn.enabled = true;
			}
		}
	}

	public void DropInChains()
	{
		int num;
		for (num = 0; num < inChains.Count; num++)
		{
			DropInChain(num);
			num--;
		}
		inChains.Clear();
		RedrawSocketColor();
		if (inChains.Count == 0)
		{
			CheckBtn();
			if (selfBtn != null)
			{
				selfBtn.enabled = true;
			}
		}
	}

	public void DropOutChain(bool destroyChain = true)
	{
		Chain ch = chain;
		chain = null;
		if (destroyChain)
		{
			DestroyChain(ch);
		}
		RedrawSocketColor();
	}

	public int GetMaxSocketDepth()
	{
		if (ActiveComponent.Model.P == null)
		{
			return ActiveComponent._staticData.Settings.SocketDepth;
		}
		return ActiveComponent._staticData.Settings.SocketDepth + ActiveComponent.Model.P.upgradeStats.SocketDepthBonus;
	}

	public bool isFull()
	{
		return queue.Count >= GetMaxSocketDepth();
	}

	public bool isEmpty()
	{
		return queue.Count == 0;
	}

	public void SetChain(Chain ch)
	{
		if (glowObj != null)
		{
			glowObj.SetActive(value: false);
		}
		if (inSocket)
		{
			AddInChain(ch);
		}
		else
		{
			SetOutChain(ch);
		}
		UpdateColors();
		RedrawSocketColor();
		Redraw();
	}

	public bool IsChainSocketOut()
	{
		if (chain == null)
		{
			return false;
		}
		if (chain.socketOut == null)
		{
			return false;
		}
		return !chain.IsDummy();
	}

	public int GetNextGameObject()
	{
		if (!IsChainSocketOut())
		{
			return -1;
		}
		return chain.socketOut.blockNumParent;
	}

	public bool GetNextCatcherSocket()
	{
		if (!IsChainSocketOut())
		{
			return false;
		}
		return chain.socketOut.catcherSocket;
	}

	public string GetNextTypeSocket()
	{
		if (!IsChainSocketOut())
		{
			return string.Empty;
		}
		return chain.socketOut.type;
	}

	public int GetNextResult()
	{
		if (!IsChainSocketOut())
		{
			return -1;
		}
		return chain.socketOut.resultNum;
	}

	public int GetIdSocketInNextBlock()
	{
		if (!IsChainSocketOut())
		{
			return -1;
		}
		return chain.socketOut.num;
	}

	public void Clear()
	{
		queue.Clear();
		inGame = false;
		timer = -1f;
		sumElementsInSocket = 0f;
		couElems = 0;
		emptyTime = 0f;
		overloadTime = 0f;
		overloadBufTime = 0f;
		emptyBufTime = 0f;
		Redraw();
	}

	public void SetElement(Element elem, bool calcStats = true)
	{
		if (!isFull())
		{
			queue.Add(elem);
			if (chain != null && queue.Count == 1)
			{
				chain.GainElement();
			}
			inGame = true;
			Redraw();
		}
	}

	public void SetBackElement(Element elem)
	{
		backQueue.Add(elem);
	}

	public void RemoveChain(Chain ch)
	{
		CheckBtn();
		if (selfBtn != null)
		{
			selfBtn.enabled = true;
		}
		if (ch == null)
		{
			return;
		}
		if (chain == ch)
		{
			DropOutChain(destroyChain: false);
			if (glowObj != null)
			{
				glowObj.SetActive(value: true);
			}
			return;
		}
		for (int i = 0; i < inChains.Count; i++)
		{
			if (inChains[i] == ch)
			{
				DropInChain(i, destroyChain: false);
				return;
			}
		}
		if (glowObj != null)
		{
			glowObj.SetActive(inChains.Count == 0);
		}
	}

	public void DeleteChains(bool invoke = true)
	{
		queue.Clear();
		bool flag = chain != null || inChains.Count > 0;
		DropInChains();
		DropOutChain();
		if (invoke && flag)
		{
			InvokeEvent(ActiveComponent.Model.construction.endDrawLineEvent);
		}
		UpdateColors();
		RedrawSocketColor();
		Redraw();
	}

	public void HideChains(bool state = true)
	{
		if (chain != null)
		{
			chain.SetCopyHolder(state);
		}
		foreach (Chain inChain in inChains)
		{
			if (inChain != null)
			{
				inChain.SetCopyHolder(state);
			}
		}
	}

	public bool HasChains(bool useDummy = false)
	{
		if (chain != null)
		{
			return !chain.IsDummy() || useDummy;
		}
		int num = 0;
		foreach (Chain inChain in inChains)
		{
			if (inChain.socketOut != null && (!inChain.isDummy() || useDummy))
			{
				num++;
			}
		}
		return num > 0;
	}

	public void Redraw()
	{
		if (bar != null)
		{
			bar.SetPercantage((float)queue.Count / (float)GetMaxSocketDepth(), inSocket);
		}
		if (!HasChains() && ActiveComponent.Model != null && ActiveComponent.Model.construction != null && ActiveComponent.Model.construction.BasicTutorials != null && ActiveComponent.Model.construction.BasicTutorials.gameObject.activeSelf)
		{
			float num = 0.7f + 0.3f * Mathf.Sin(4f * Time.time);
			if (iconOk != null)
			{
				iconOk.color = deactive * (1f - num) + Logic.GetColor(Logic.KeyColor.WARNING) * num;
			}
		}
		if (ActiveComponent._staticData != null)
		{
			bool flag = isFull();
			if (iconOk != null)
			{
				iconOk.gameObject.SetActive(!flag);
			}
			if (iconCross != null)
			{
				iconCross.gameObject.SetActive(flag);
			}
		}
	}

	public Element GetBackElement()
	{
		if (backQueue.Count == 0)
		{
			return null;
		}
		Element result = backQueue[0];
		backQueue.RemoveAt(0);
		return result;
	}

	public Element GetElement()
	{
		if (queue.Count == 0)
		{
			return null;
		}
		Element result = queue[0];
		queue.RemoveAt(0);
		Redraw();
		return result;
	}

	private void Awake()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		bar = base.gameObject.GetComponentInChildren<CustomProgressBar>();
		if (bar != null)
		{
			bar.transform.SetParent(base.gameObject.transform.parent);
			base.transform.SetParent(bar.transform.parent);
			bar.transform.SetSiblingIndex(base.transform.GetSiblingIndex() - 1);
			bar.SetPercantage(0f);
		}
		OpacitySin componentInChildren = base.gameObject.GetComponentInChildren<OpacitySin>();
		if (componentInChildren != null)
		{
			glowObj = componentInChildren.gameObject;
		}
	}

	private void Start()
	{
		UpdateColors();
	}

	public void InitDraw()
	{
		UpdateColors();
		if (iconOk != null)
		{
			iconOk.color = Logic.GetColor(type + "DEACTIVE");
		}
	}

	public void SetLocked(bool state)
	{
		lockedZoom = state;
		RedrawSocketColor();
	}

	public void RedrawSocketColor()
	{
		if (!(ActiveComponent.Model.construction != null))
		{
			return;
		}
		if (!ActiveComponent.Model.construction.testMode && lockedZoom)
		{
			if (iconOk != null)
			{
				iconOk.color = locked;
			}
		}
		else if (iconOk != null)
		{
			iconOk.color = (HasChains(!ActiveComponent.Model.construction.gameObject.activeInHierarchy) ? active : deactive);
		}
	}

	private void FixedUpdate()
	{
		if (ActiveComponent.Model != null)
		{
			Redraw();
			RedrawSocketColor();
		}
	}
}

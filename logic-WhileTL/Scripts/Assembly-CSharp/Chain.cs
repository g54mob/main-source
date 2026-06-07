using System.Collections.Generic;
using App.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chain : ActiveComponent, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public bool parentSocketHover;

	public bool dummy;

	public bool hoverChain;

	[SceneBind("Hover")]
	public Image hover;

	[SceneBind("MobileInputCatcher")]
	public RectTransform mobileInputCatcher;

	private List<Element> queue = new List<Element>();

	private List<float> timerElements = new List<float>();

	private List<GameObject> elementsGO = new List<GameObject>();

	public Socket socketIn;

	public Socket socketOut;

	private GameObject chainElem;

	private Vector3 defaultScale;

	private bool move;

	public string inTag = "";

	public string outTag = "";

	private float timer;

	private float lastGainTimer;

	public float sendTimer;

	public float speed = 1f;

	public float gainDelay;

	private float arrowTimer;

	private GameObject elem;

	private List<GameObject> chainArrows = new List<GameObject>();

	public bool copyHolder;

	public bool inGame;

	public float sumElementsInSocket;

	public int couElems;

	private Vector3 shift;

	private float spdCoef = 1f;

	private bool recalcLinePosAtStart;

	private float len;

	private bool setImgStateToTruInRedraw;

	private Color colorGood;

	private Color overfitted;

	public List<Image> imagesGlow;

	private bool wasDraw;

	public float stopTimer;

	public float delayCouTimer;

	public Socket BufferSocket;

	public GameObject BufferObject;

	private bool isMemory;

	private bool stopDraw;

	private Vector3 start = Vector3.zero;

	private Vector3 end = Vector3.zero;

	private Vector3 dir = Vector3.zero;

	private bool startMoveInit;

	private Vector3 chainForward = Vector3.zero;

	private float sendTimerRCP;

	private int elemIterVisual;

	private int maxElementsAllMove;

	private float moveDropCoef;

	public bool tutorial;

	private float delay;

	private float t;

	public GameObject GetInObject()
	{
		if (!(socketIn != null))
		{
			return null;
		}
		return socketIn.GetOwningObject();
	}

	public GameObject GetOutObject()
	{
		if (!(socketOut != null))
		{
			return null;
		}
		return socketOut.GetOwningObject();
	}

	public void SetDummy(bool state)
	{
		if (base.gameObject.activeSelf != !state)
		{
			base.gameObject.SetActive(!state);
		}
		if (state)
		{
			ImgState(!state);
		}
		dummy = state;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (!dummy && !ActiveComponent._controller.computerBuildingController.gameObject.activeSelf && Input.touchCount == 0)
		{
			DestroyGameObject();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!dummy)
		{
			hoverChain = true;
			RedrawChooseChain();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!dummy)
		{
			hoverChain = false;
			RedrawChooseChain();
		}
	}

	public bool isMoving()
	{
		TryMove();
		return !move;
	}

	public void DropValues()
	{
		timer = 0f;
		lastGainTimer = 0f;
		ElemsClear();
		queue.Clear();
		timerElements.Clear();
		elementsGO.Clear();
		chainArrows.Clear();
		shift = Vector3.zero;
		if (ActiveComponent.Model.P != null)
		{
			sendTimer = ActiveComponent._staticData.Settings.TimeOnLine / (1f + ActiveComponent.Model.P.upgradeStats.ChainSpeedBonus);
		}
	}

	public void SetCopyHolder(bool state)
	{
		copyHolder = state;
		if (state)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void ElemsClear()
	{
		for (int i = 0; i < elementsGO.Count; i++)
		{
			ActiveComponent.Model.DisableElemObj(elementsGO[i].GetComponent<ElementControl>());
		}
		sumElementsInSocket = 0f;
		couElems = 0;
		stopTimer = 0f;
		delayCouTimer = 0f;
		elementsGO.Clear();
		queue.Clear();
		timerElements.Clear();
	}

	public void Clear()
	{
		ElemsClear();
		copyHolder = false;
		if (socketIn != null)
		{
			socketIn.RedrawSocketColor();
		}
		if (socketOut != null)
		{
			socketOut.RedrawSocketColor();
		}
		socketIn = null;
		socketOut = null;
		DropValues();
	}

	public bool isDummy()
	{
		if (socketIn != null && socketIn.dummy)
		{
			return true;
		}
		if (socketOut != null && socketOut.dummy)
		{
			return true;
		}
		return false;
	}

	public void ClearBeforeDelete()
	{
		ElemsClear();
		if (socketIn != null)
		{
			socketIn.RemoveChain(this);
		}
		if (socketOut != null)
		{
			socketOut.RemoveChain(this);
		}
		BufferObject = null;
		BufferSocket = null;
		socketIn = null;
		socketOut = null;
		recalcLinePosAtStart = false;
	}

	public void SetSocket(Socket s, bool incoming)
	{
		if ((incoming ? socketIn : socketOut) != null)
		{
			DestroyGameObject();
		}
		if (incoming)
		{
			socketIn = s;
		}
		else
		{
			socketOut = s;
		}
		s.SetChain(this);
	}

	public bool IsConnectedWith(BlockData bd, int index, bool incoming)
	{
		if (bd == null)
		{
			return true;
		}
		Socket socket = socketIn;
		if (!incoming)
		{
			socket = socketOut;
		}
		if (socket != null && socket.gameObject.transform.parent.GetComponent<BlockData>() == bd && socket.num == index)
		{
			return true;
		}
		return false;
	}

	public void SetSockets(Socket chainInSocket, Socket chainOutSocket)
	{
		SetInSocket(chainInSocket);
		SetOutSocket(chainOutSocket);
	}

	public void SetInSocket(Socket s)
	{
		SetSocket(s, incoming: true);
	}

	public void SetOutSocket(Socket s)
	{
		SetSocket(s, incoming: false);
	}

	public void GainElement()
	{
		if (!(socketIn == null) && !IsFull())
		{
			Element element = socketIn.GetElement();
			if (element != null)
			{
				ActiveComponent.Model.construction.elementsOnLines++;
				queue.Add(element);
				timerElements.Add(timer);
				Vector3 position = socketIn.transform.position;
				position.z = 0f;
				ElementControl elementObjectFromPool = ActiveComponent.Model.GetElementObjectFromPool(elem, position, Quaternion.identity, base.gameObject.transform.parent);
				elementObjectFromPool.Init(element);
				elementsGO.Add(elementObjectFromPool.gameObject);
			}
		}
	}

	private void Start()
	{
		OnInit();
	}

	public void SetSendTimer(float val)
	{
		sendTimer = val;
	}

	public void ImgState(bool state)
	{
		if (imagesGlow[0].gameObject.activeSelf == state)
		{
			return;
		}
		if (!state)
		{
			hover.gameObject.SetActive(value: false);
		}
		base.gameObject.GetComponent<Image>().enabled = state;
		foreach (Image item in imagesGlow)
		{
			item.enabled = true;
			item.gameObject.SetActive(state);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		colorGood = Logic.GetColor("GOOD");
		overfitted = Logic.GetColor("RED");
		colorGood.a = (overfitted.a = 0.3f);
		RedrawChooseChain();
		base.transform.localScale = Vector3.one;
		defaultScale = Vector3.one / Model.sizeMultCoef;
		elem = Logic.LoadPrefab("Element", block: false);
		DropValues();
		maxElementsAllMove = 200;
		moveDropCoef = 0.75f;
	}

	public void RedrawChooseChain()
	{
		if (hover == null)
		{
			OnInit();
		}
		if (ActiveComponent.Model.currentChain != base.gameObject)
		{
			hover.gameObject.SetActive(hoverChain || parentSocketHover);
		}
		else
		{
			hover.gameObject.SetActive(value: false);
		}
	}

	private void Draw(Vector3 left, Vector3 right, bool redraw = false)
	{
		if (base.gameObject.activeInHierarchy)
		{
			if ((!recalcLinePosAtStart || (start - left).sqrMagnitude > 0.01f || (end - right).sqrMagnitude > 0.01f) && redraw)
			{
				start = left;
				end = right;
				chainForward = start - end;
				Vector3 position = base.transform.position;
				position.Set((right.x + left.x) / 2f, (right.y + left.y) / 2f, 1f);
				base.transform.position = position;
				base.transform.rotation = Quaternion.identity;
				base.transform.Rotate(0f, 0f, -57.29578f * Mathf.Atan2(right.x - left.x, right.y - left.y));
				left.z = (right.z = 0f);
				len = (left - right).magnitude;
				position.Set(1f, defaultScale.y * len * 0.01f, 1f);
				base.transform.localScale = position;
				recalcLinePosAtStart = true;
			}
			if (!wasDraw)
			{
				GlowLineScale(len, (right.x - left.x) / len, (right.y - left.y) / len, left);
			}
		}
	}

	private void GlowLineScale(float len, float sin, float cos, Vector3 right)
	{
		wasDraw = true;
		Vector3 localScale = base.transform.localScale;
		localScale.Set(2.3f * (0.6f + 0.4f * Mathf.Abs(Mathf.Sin(Time.unscaledTime))), base.transform.localScale.y, defaultScale.z);
		base.transform.localScale = localScale;
		int num = 0;
		foreach (Image item in imagesGlow)
		{
			if (item != hover)
			{
				if (num != 0)
				{
					localScale.Set(1f, 0.9f * (0.5f + 0.5f * Mathf.Abs(Mathf.Sin(Time.unscaledTime * (float)num))), 1f);
					item.gameObject.transform.localScale = localScale;
				}
				if ((!IsFull() && move) || socketIn == null || socketOut == null)
				{
					item.color = colorGood;
				}
				else
				{
					item.color = overfitted;
				}
				num++;
			}
		}
	}

	private bool IsFull()
	{
		return queue.Count >= Logic.GetMaxElementsOnLine();
	}

	public bool IsDummy()
	{
		return dummy;
	}

	public void DestroyGameObject()
	{
		ClearBeforeDelete();
		if (ActiveComponent.Model.construction.endDrawLineEvent != null)
		{
			ActiveComponent.Model.construction.endDrawLineEvent.Invoke();
		}
		ImgState(state: false);
		ActiveComponent.Model.DisableChainObj(this);
	}

	public void InitFromBuffer()
	{
		base.gameObject.GetComponent<Button>().enabled = true;
		if (BufferSocket != null && BufferSocket.gameObject.activeInHierarchy)
		{
			if ((BufferSocket.inSocket ? socketOut : socketIn) != null)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
			SetSocket(BufferSocket, !BufferSocket.inSocket);
			if (socketIn == null || socketOut == null || socketIn.type != socketOut.type)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
		}
		else
		{
			if (BufferObject == null)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
			Socket[] componentsInChildren = BufferObject.GetComponentsInChildren<Socket>();
			float num = float.MaxValue;
			Socket socket = null;
			bool flag = ((socketOut == null) ? true : false);
			string text = ((socketOut == null) ? socketIn.type : socketOut.type);
			Vector3 mouseInWorld = Logic.GetMouseInWorld();
			Socket[] array = componentsInChildren;
			foreach (Socket socket2 in array)
			{
				if (socket2.inSocket == flag && socket2.type == text)
				{
					float sqrMagnitude = (socket2.gameObject.transform.position - mouseInWorld).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						socket = socket2;
					}
				}
			}
			if (socket == null)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
			BufferSocket = socket;
			if ((BufferSocket.inSocket ? socketOut : socketIn) != null)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
			SetSocket(BufferSocket, !BufferSocket.inSocket);
			if (socketIn.type != socketOut.type)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
		}
		isMemory = false;
		if (socketIn != null && socketOut != null)
		{
			if (socketIn.type != socketOut.type)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
				DestroyGameObject();
				return;
			}
			if (socketIn.type.Contains("MEMORY"))
			{
				if (socketIn.transform.parent != socketOut.transform.parent)
				{
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_SocketDelete");
					DestroyGameObject();
					return;
				}
				isMemory = true;
				sendTimer = ActiveComponent._staticData.Settings.TimeOnMemoryLine / (1f + ActiveComponent.Model.P.upgradeStats.ChainSpeedBonus);
				sendTimerRCP = 1f / sendTimer;
			}
		}
		if (ActiveComponent.Model.construction.endDrawLineEvent != null)
		{
			ActiveComponent.Model.construction.endDrawLineEvent.Invoke();
			if (ActiveComponent.Model.recordHistory)
			{
				ActiveComponent.Model.construction.GetCurCathub().RecordHistory();
				ActiveComponent.Model.construction.RedoUndoButtonsStatesUpdate();
			}
		}
		ActiveComponent.Sound.Play("MonokanalWhileTrueLearn_SocketEnd");
	}

	public void SetStopDraw(bool flag)
	{
		stopDraw = flag;
	}

	public void TryMove(bool redraw = false)
	{
		if (socketIn != null)
		{
			if (socketOut != null)
			{
				Draw(socketIn.gameObject.transform.position, socketOut.gameObject.transform.position, redraw);
				SetMove(!socketOut.isFull());
			}
			else
			{
				SetMove(state: false);
				Draw(socketIn.gameObject.transform.position, Logic.GetMouseInWorld(), redraw);
			}
		}
		else if (socketOut != null)
		{
			Logic.GetMouseInWorld();
			Draw(socketOut.gameObject.transform.position, Logic.GetMouseInWorld(), redraw);
		}
		else
		{
			SetMove(state: false);
		}
	}

	public void SetMove(bool state)
	{
		move = state;
	}

	private void Update()
	{
		if (dummy)
		{
			return;
		}
		if (ActiveComponent.Model.construction.pause && socketIn != null && socketOut != null)
		{
			Draw(socketIn.gameObject.transform.position, socketOut.gameObject.transform.position, redraw: true);
		}
		if (hoverChain && ActiveComponent.Model.construction.gameObject.activeSelf && (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)))
		{
			DestroyGameObject();
		}
		else
		{
			if (!move && !tutorial)
			{
				return;
			}
			if (!startMoveInit)
			{
				start = socketIn.gameObject.transform.position;
				end = socketOut.gameObject.transform.position;
				chainForward = start - end;
				sendTimerRCP = 1f / sendTimer;
				startMoveInit = true;
			}
			if (ActiveComponent.Model.construction.elementsOnLines > maxElementsAllMove && ActiveComponent.Model.globalSaves.video == 1)
			{
				if (elementsGO.Count > 0)
				{
					elemIterVisual = Mathf.Min(elemIterVisual, elementsGO.Count) % elementsGO.Count;
					int num = elemIterVisual;
					int num2 = Mathf.Max(15, (int)((float)elementsGO.Count * moveDropCoef));
					while (num2 > 0)
					{
						num2--;
						MoveElement(elementsGO[num], timerElements[num]);
						num++;
						num %= elementsGO.Count;
					}
					elemIterVisual = num;
				}
			}
			else
			{
				for (int i = 0; i < elementsGO.Count; i++)
				{
					MoveElement(elementsGO[i], timerElements[i]);
				}
			}
		}
	}

	private void LateUpdate()
	{
		wasDraw = false;
	}

	private void MoveElement(GameObject go, float elemtTime)
	{
		float num = Mathf.Min(1f, (elemtTime - timer) * sendTimerRCP);
		dir.x = start.x + chainForward.x * num;
		dir.y = start.y + chainForward.y * num;
		float sqrMagnitude = (end - go.transform.position).sqrMagnitude;
		if ((end - dir).sqrMagnitude < sqrMagnitude)
		{
			go.transform.position = dir;
		}
	}

	private void FixedUpdate()
	{
		if (dummy)
		{
			return;
		}
		isMemory = false;
		TryMove(redraw: true);
		if (move || tutorial)
		{
			t = Time.deltaTime * ActiveComponent.Model.curSpeed;
			timer += t;
			GainElement();
			if (queue.Count > 0)
			{
				lastGainTimer = timer;
				if (socketIn != null && socketOut != null && socketIn.type.Contains("MEMORY") && socketOut.type.Contains("MEMORY"))
				{
					sendTimer = ActiveComponent._staticData.Settings.TimeOnMemoryLine / (1f + ActiveComponent.Model.P.upgradeStats.ChainSpeedBonus);
					sendTimerRCP = 1f / sendTimer;
				}
				if (timerElements.Count > 0)
				{
					delay = timer - timerElements[0];
					if (Mathf.Abs(delay - sendTimer) < 0.01f || delay > sendTimer)
					{
						if (socketIn.dataNum != -1)
						{
							_ = socketOut;
						}
						else
						{
							_ = socketIn;
						}
						couElems = 0;
						inGame = true;
						if (!socketOut.isFull())
						{
							socketOut.SetElement(queue[0], calcStats: false);
							ActiveComponent.Model.construction.elementsOnLines--;
							queue.RemoveAt(0);
							timerElements.RemoveAt(0);
							ActiveComponent.Model.DisableElemObj(elementsGO[0].GetComponent<ElementControl>());
							elementsGO.RemoveAt(0);
						}
					}
				}
			}
		}
		if (recalcLinePosAtStart)
		{
			ImgState(state: true);
		}
	}

	public void InitDraw()
	{
		recalcLinePosAtStart = false;
		startMoveInit = false;
	}
}

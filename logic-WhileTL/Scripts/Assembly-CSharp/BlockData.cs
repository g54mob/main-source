using System.Collections.Generic;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockData : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	public BaseBlock bb;

	public bool hover;

	public bool dummy;

	private bool selected;

	private Vector3[] cornerScale = new Vector3[4];

	private string questName = string.Empty;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private static int maxSockets = 5;

	private bool notHover;

	public SchemeBlock sh;

	[SceneBind("Hover")]
	public RectTransform Hover;

	[SceneBind("InfoBtn")]
	private Button InfoBtn;

	public bool dragged;

	public Construction construction;

	public bool deactive;

	private Socket scaleSocket;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.clickCount >= 2)
		{
			eventData.clickCount = 0;
		}
	}

	public void ResetCornerScales()
	{
		for (int i = 0; i < cornerScale.Length; i++)
		{
			Vector3 vector = cornerScale[i];
			vector.x = Mathf.Sign(vector.x);
			vector.y = Mathf.Sign(vector.y);
			cornerScale[i] = vector;
		}
		int num = 0;
		if (!(Hover != null))
		{
			return;
		}
		for (int j = 0; j < Hover.transform.childCount; j++)
		{
			Transform child = Hover.transform.GetChild(j);
			if (child.name.ToLower().StartsWith("corner"))
			{
				child.transform.localScale = cornerScale[j];
			}
			num++;
		}
	}

	public Socket GetSocket(bool incoming, int index, BlockData connectedIn = null, BlockData connectedOut = null, int connectedIndex = 0)
	{
		List<Socket> list = (incoming ? connectedIn.socketsIn : connectedIn.socketsOut);
		List<Socket> list2 = (incoming ? socketsIn : socketsOut);
		if (list[index].chain == null)
		{
			return null;
		}
		if (list[index].chain.IsConnectedWith(connectedOut, connectedIndex, incoming))
		{
			return list2[index];
		}
		return null;
	}

	public List<Socket> GetSocketsFromFlags(bool incoming, int flag)
	{
		List<Socket> list = (incoming ? socketsIn : socketsOut);
		List<Socket> list2 = new List<Socket>();
		for (int i = 0; i < 6; i++)
		{
			if ((flag & (1 << i)) != 0)
			{
				list2.Add(list[i]);
			}
		}
		return list2;
	}

	public Socket GetFirstValidSocket(bool incoming)
	{
		return (incoming ? socketsIn : socketsOut).Find((Socket s) => s != null);
	}

	public void ConnectTo(int srcFlags, BlockData destBlock, int destFlags, BlockData realIn, BlockData realOut)
	{
		List<Socket> socketsFromFlags = destBlock.GetSocketsFromFlags(incoming: true, destFlags);
		foreach (Socket item in socketsFromFlags)
		{
			if (!(item != null))
			{
				continue;
			}
			for (int i = 0; i <= maxSockets; i++)
			{
				if ((srcFlags & (1 << i)) != 0)
				{
					Socket socket = GetSocket(incoming: false, i, realIn, realOut, item.num);
					if (socketsFromFlags != null && socket != null)
					{
						ActiveComponent.Model.construction.CreateChain().SetSockets(socket, item);
						socket.RedrawSocketColor();
						item.RedrawSocketColor();
					}
				}
			}
		}
	}

	public string GetQuestName()
	{
		return questName;
	}

	public float RoundFloat(float f, int commaDigits = 3)
	{
		string text = f.ToString("0.00000000");
		int num = text.IndexOf('.');
		return float.Parse(text.Substring(0, num + commaDigits + 1));
	}

	public Vector3 GetPosition()
	{
		return base.transform.position;
	}

	public int GetUniqueHash()
	{
		float num = RoundFloat(base.transform.position.x, 2);
		float num2 = RoundFloat(base.transform.position.y, 2);
		int hashCode = base.transform.gameObject.name.GetHashCode();
		return num.GetHashCode() ^ num2.GetHashCode() ^ hashCode;
	}

	public int GetSocketsFlags(bool incoming)
	{
		List<Socket> list = (incoming ? socketsIn : socketsOut);
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null && list[i].HasChains(useDummy: true))
			{
				num |= 1 << i;
			}
		}
		return num;
	}

	public Socket.Connections GetSocketConnections(bool incoming)
	{
		Socket.Connections connections = new Socket.Connections();
		List<Socket> obj = (incoming ? socketsIn : socketsOut);
		int socketsFlags = GetSocketsFlags(incoming);
		foreach (Socket item in obj)
		{
			if (item != null)
			{
				GameObject gameObject = (incoming ? item.GetChainInObject() : item.GetChainOutObject());
				if (gameObject != null)
				{
					BlockData component = gameObject.GetComponent<BlockData>();
					int socketsFlags2 = component.GetSocketsFlags(!incoming);
					int uniqueHash = component.GetUniqueHash();
					connections.AddConnection(incoming, socketsFlags, uniqueHash, socketsFlags2);
				}
			}
		}
		return connections;
	}

	public Socket.Connections GetSocketConnections()
	{
		Socket.Connections socketConnections = GetSocketConnections(incoming: true);
		Socket.Connections socketConnections2 = GetSocketConnections(incoming: false);
		socketConnections.Out = socketConnections2.Out;
		return socketConnections;
	}

	public void ClearBeforeDelete()
	{
		Dropdown[] componentsInChildren = base.gameObject.GetComponentsInChildren<Dropdown>();
		RemoveCustomBlockListenerBeforeDelete();
		Dropdown[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Hide();
		}
		List<Socket>[] array2 = new List<Socket>[2] { socketsIn, socketsOut };
		for (int i = 0; i < array2.Length; i++)
		{
			foreach (Socket item in array2[i])
			{
				if (item != null)
				{
					item.DeleteChains(invoke: false);
				}
			}
		}
	}

	public bool IsCustomBlock()
	{
		return GetComponent<CustomBlock>() != null;
	}

	private GameObject GetFirstBlockBottomUp(GameObject go)
	{
		if (go == null)
		{
			return null;
		}
		if (go.GetComponent<BlockData>() != null)
		{
			return go;
		}
		return GetFirstBlockBottomUp(go.transform.parent.gameObject);
	}

	public string GetShowName()
	{
		if (Logic.IsBaseBlock(base.gameObject.name))
		{
			return TextResources.GetString(base.gameObject.name);
		}
		return base.transform.GetComponent<CustomBlock>().nameText.text;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		BlockData blockData = this;
		if (eventData != null)
		{
			GameObject firstBlockBottomUp = GetFirstBlockBottomUp(eventData.pointerEnter);
			if ((bool)firstBlockBottomUp)
			{
				blockData = firstBlockBottomUp.GetComponent<BlockData>();
			}
		}
		if (IsCustomBlock())
		{
			InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
			InputSystem.AddListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
		}
		if (!blockData.deactive)
		{
			if (selected)
			{
				blockData.SetCornerStyleSelected(scaleUp: true);
			}
			else
			{
				blockData.SetCornerStyleHovering(scaleUp: true);
			}
			if (Hover != null)
			{
				Hover.gameObject.SetActive(!notHover);
			}
			hover = true;
			if (ActiveComponent.Model.currentChain != null && !dummy)
			{
				ActiveComponent.Model.currentChain.GetComponent<Chain>().BufferObject = base.gameObject;
			}
		}
	}

	public void RemoveCustomBlockListenerBeforeDelete()
	{
		if (IsCustomBlock())
		{
			InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (deactive)
		{
			return;
		}
		if (Hover != null)
		{
			if (selected)
			{
				SetCornerStyleSelected();
			}
			else
			{
				SetCornerStyleHovering();
				Hover.gameObject.SetActive(value: false);
			}
		}
		if (ActiveComponent.Model.currentChain != null)
		{
			ActiveComponent.Model.currentChain.GetComponent<Chain>().BufferObject = null;
		}
		hover = false;
		if (scaleSocket != null)
		{
			scaleSocket.gameObject.GetComponent<ZoomOnMouse>().DownScale();
			scaleSocket.OffLines();
		}
		scaleSocket = null;
		if (IsCustomBlock())
		{
			InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
		}
	}

	private void OpenSandbox()
	{
		if (!base.gameObject.name.Contains("RESULT") && !base.gameObject.name.Contains("DATA") && !Logic.IsBaseBlock(GetQuestName()) && Helper.GetWorldRect(base.gameObject.GetComponent<RectTransform>()).Contains(Logic.GetMouseInWorld()))
		{
			BaseBlock component = base.gameObject.GetComponent<BaseBlock>();
			if (!component.enteredToScheme)
			{
				component.enteredToScheme = true;
				QuestLine.Quest quest = QuestLine.GetQuest(GetQuestName());
				ActiveComponent.Model.SandboxOpen = base.gameObject.name;
				ActiveComponent.Model.construction.AutoSave(Construction.Info.ShowNothing);
				Logic.SaveCurCathub();
				ActiveComponent.Model.construction.OpenWindowInit(quest, replay: false, customBlockOpened: true, ActiveComponent.Model.SandboxOpen);
			}
		}
	}

	private void OnRightMouseButton(bool pressed, int count)
	{
		if (pressed && count > 1 && ActiveComponent.Model.construction.IsInConstructionGameMode())
		{
			if (this == null)
			{
				InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
			}
			else if (base.gameObject == null)
			{
				InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
			}
			else
			{
				OpenSandbox();
			}
		}
	}

	public void SetSelected(bool state, bool ignoreConditions = false)
	{
		if (ActiveComponent.Model.construction.testMode || (!ignoreConditions && ActiveComponent.Model.construction.interactState == Construction.DragInteraction.ConstrArea && ActiveComponent.Model.construction.longTap != Construction.OneTouchState.Long))
		{
			return;
		}
		selected = state;
		if (Hover != null)
		{
			if (state)
			{
				SetCornerStyleSelected();
			}
			else
			{
				SetCornerStyleHovering();
			}
			Hover.gameObject.SetActive(state);
		}
	}

	public void SetHovered(bool state)
	{
		if (state)
		{
			OnPointerEnter(null);
		}
		else
		{
			OnPointerExit(null);
		}
	}

	public void SetCornerStyleHovering(bool scaleUp = false)
	{
		SetCornerStyle(Logic.KeyColor.WARNING, scaleUp);
	}

	public void SetCornerStyleSelected(bool scaleUp = false)
	{
		SetCornerStyle(Logic.KeyColor.GREEN, scaleUp);
	}

	public void SetCornerStyle(Logic.KeyColor kcolor, bool scaleUp = false)
	{
		if (Hover != null)
		{
			Color color = Logic.GetColor(kcolor);
			for (int i = 0; i < Hover.transform.childCount; i++)
			{
				Transform child = Hover.transform.GetChild(i);
				child.gameObject.GetComponent<Image>().color = color;
				child.transform.localScale = (scaleUp ? (cornerScale[i] * 1.5f) : cornerScale[i]);
			}
		}
	}

	public bool IsSelected()
	{
		return selected;
	}

	public bool ToggleSelection()
	{
		SetSelected(!selected);
		return selected;
	}

	public bool CanBeSelected()
	{
		return !dummy;
	}

	public bool CanBeCopied()
	{
		if (selected)
		{
			return !dummy;
		}
		return false;
	}

	public bool CanBeDeleted()
	{
		return !dummy;
	}

	private void MakeActive(bool state)
	{
		List<Socket>[] array = new List<Socket>[2] { socketsIn, socketsOut };
		for (int i = 0; i < array.Length; i++)
		{
			foreach (Socket item in array[i])
			{
				if (item != null)
				{
					item.MakeActive(state);
				}
			}
		}
	}

	private void InitCorners()
	{
		int num = 0;
		for (int i = 0; i < Hover.transform.childCount; i++)
		{
			Transform child = Hover.transform.GetChild(i);
			if (child.name.ToLower().StartsWith("corner"))
			{
				cornerScale[num++] = child.transform.localScale;
			}
		}
	}

	public void Init(BlockData bd, bool dummyBlock = false)
	{
		base.Init();
		SceneBindContainer.BindObjects(this, base.transform);
		if (Hover != null)
		{
			InitCorners();
		}
		InitSockets();
		dummy = dummyBlock;
		if (dummyBlock)
		{
			base.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < maxSockets; i++)
		{
			if (bd.socketsOut[i] != null && !bd.socketsOut[i].type.Contains("MEMORY") && bd.socketsOut[i].chain != null && socketsOut[i].chain == null)
			{
				Chain chain = ActiveComponent.Model.construction.CreateChainWithTransform(base.transform);
				chain.SetInSocket(socketsOut[i]);
				chain.SetOutSocket(bd.socketsOut[i].chain.socketOut);
			}
		}
		bb = base.gameObject.GetComponent<BaseBlock>();
		bb.Init();
		switch (base.gameObject.name)
		{
		case "DSTREE":
		{
			DesicionTree component2 = base.gameObject.GetComponent<DesicionTree>();
			DesicionTree component3 = bd.gameObject.GetComponent<DesicionTree>();
			component2.top.value = component3.top.value;
			component2.bot.value = component3.bot.value;
			component2.ChangeColors();
			break;
		}
		case "ISOFOREST":
		{
			IsolationForest component15 = base.gameObject.GetComponent<IsolationForest>();
			IsolationForest component16 = bd.gameObject.GetComponent<IsolationForest>();
			component15.top.value = component16.top.value;
			component15.mid.value = component16.mid.value;
			component15.ChangeColors();
			component15.ChangeSprites();
			break;
		}
		case "RANDOMFOREST":
		{
			RandomForest component13 = base.gameObject.GetComponent<RandomForest>();
			RandomForest component14 = bd.gameObject.GetComponent<RandomForest>();
			component13.top.value = component14.top.value;
			component13.bot.value = component14.bot.value;
			component13.mid.value = component14.mid.value;
			component13.ChangeColors();
			component13.ChangeSprites();
			break;
		}
		case "IFSHAPE":
			base.gameObject.GetComponent<IfShape>().top.value = bd.gameObject.GetComponent<IfShape>().top.value;
			break;
		case "DSSHAPE":
		{
			DsShape component11 = base.gameObject.GetComponent<DsShape>();
			DsShape component12 = bd.gameObject.GetComponent<DsShape>();
			component11.top.value = component12.top.value;
			component11.bot.value = component12.bot.value;
			component11.ChangeSprites();
			break;
		}
		case "IFCOLOR":
			base.gameObject.GetComponent<IfColor>().top.value = bd.gameObject.GetComponent<IfColor>().top.value;
			break;
		case "PERCEPTRONCOLOR":
		{
			PerceptronColor component10 = base.gameObject.GetComponent<PerceptronColor>();
			component10.error = bd.gameObject.GetComponent<PerceptronColor>().error;
			component10.Redraw();
			break;
		}
		case "PERCEPTRONSHAPE":
		{
			PerceptronShape component9 = base.gameObject.GetComponent<PerceptronShape>();
			component9.error = bd.gameObject.GetComponent<PerceptronShape>().error;
			component9.Redraw();
			break;
		}
		case "ROSENBLATT":
		{
			Rosenblat component8 = base.gameObject.GetComponent<Rosenblat>();
			component8.error = bd.gameObject.GetComponent<Rosenblat>().error;
			component8.Redraw();
			break;
		}
		case "RNNCELL":
		{
			RNNCELL component7 = base.gameObject.GetComponent<RNNCELL>();
			component7.error = bd.gameObject.GetComponent<RNNCELL>().error;
			component7.Redraw();
			UpdateSocketInRecursiveBlock(component7.socketsIn, component7.socketsOut);
			break;
		}
		case "ARMA":
		{
			ARMA component6 = base.gameObject.GetComponent<ARMA>();
			component6.error = bd.gameObject.GetComponent<ARMA>().error;
			component6.Redraw();
			UpdateSocketInRecursiveBlock(component6.socketsIn, component6.socketsOut);
			break;
		}
		case "GENCOPYBLOCKCOLOR":
		{
			GeneticCopyBlockColor component4 = base.gameObject.GetComponent<GeneticCopyBlockColor>();
			GeneticCopyBlockColor component5 = bd.gameObject.GetComponent<GeneticCopyBlockColor>();
			component4.error = component5.error;
			component4.showError = component5.showError;
			component4.hide = component5.hide;
			component4.Redraw();
			break;
		}
		default:
		{
			CustomBlock component = base.gameObject.GetComponent<CustomBlock>();
			if (component != null)
			{
				component.Init();
				component.Init(bd.gameObject.GetComponent<CustomBlock>().scheme, flag: true);
				component.Redraw();
			}
			break;
		}
		}
		foreach (Socket item in bb.socketsIn)
		{
			if (item != null)
			{
				item.dummy = dummyBlock;
			}
		}
		foreach (Socket item2 in bb.socketsOut)
		{
			if (item2 != null)
			{
				item2.dummy = dummyBlock;
			}
		}
		ResetCornerScales();
	}

	private void UpdateSocketInRecursiveBlock(List<Socket> listIn, List<Socket> listOut)
	{
		foreach (Socket item in listIn)
		{
			if (!(item != null) || !item.type.Contains("MEMORY"))
			{
				continue;
			}
			int hashCode = item.type.GetHashCode();
			foreach (Socket item2 in listOut)
			{
				if (item2 != null && item2.chain != null && item2.type.GetHashCode() == hashCode)
				{
					item2.chain.socketOut = item;
				}
			}
		}
	}

	public void StopHover(bool state = true)
	{
		notHover = state;
	}

	public void InfoClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		construction.BlockTutuorial.gameObject.SetActive(value: true);
		construction.NewBlockTutorialIndicator.gameObject.SetActive(value: false);
		construction.BlockTutuorial.Redraw(base.gameObject.name);
		Logic.SendAnalytics("CONSTRUCTION_TUTNODE_OPEN", new Dictionary<string, object> { 
		{
			"keyName",
			base.gameObject.name
		} });
	}

	public void Clear()
	{
		bb.Clear();
	}

	public void Active(SchemeBlock scheme, Construction construction)
	{
		this.construction = construction;
		sh = scheme;
		SceneBindContainer.BindObjects(this, base.transform);
		if (InfoBtn != null)
		{
			InfoBtn.onClick.AddListener(InfoClick);
		}
		InitSockets();
		bb = base.gameObject.GetComponent<BaseBlock>();
		deactive = false;
		if (Hover != null)
		{
			Hover.gameObject.SetActive(value: false);
			InitCorners();
		}
	}

	public void InitSockets()
	{
		questName = base.gameObject.name;
		BaseBlock component = base.gameObject.GetComponent<BaseBlock>();
		if (component != null)
		{
			component.Init();
			socketsIn = component.socketsIn;
			socketsOut = component.socketsOut;
		}
	}

	public void DeActive(bool disableSockets = false)
	{
		deactive = true;
		dummy = true;
		SceneBindContainer.BindObjects(this, base.transform);
		InitSockets();
		bb = base.gameObject.GetComponent<BaseBlock>();
		if (bb != null)
		{
			bb.enabled = false;
		}
		Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>();
		foreach (Selectable selectable in componentsInChildren)
		{
			if (selectable.gameObject.name != "InfoBtn" && selectable.gameObject.name != "GoInside")
			{
				selectable.enabled = false;
			}
		}
		IfColor component = base.gameObject.GetComponent<IfColor>();
		Rosenblat component2 = base.gameObject.GetComponent<Rosenblat>();
		if (component != null)
		{
			component.glow.gameObject.SetActive(value: false);
		}
		if (component2 != null)
		{
			component2.ErrorGlow.gameObject.SetActive(value: false);
		}
		List<Socket>[] array = new List<Socket>[2] { socketsIn, socketsOut };
		for (int i = 0; i < array.Length; i++)
		{
			foreach (Socket item in array[i])
			{
				if (item != null)
				{
					item.Redraw();
					item.InitDraw();
					if (disableSockets)
					{
						item.gameObject.GetComponent<Button>().enabled = false;
						item.gameObject.GetComponent<Socket>().enabled = false;
					}
					item.gameObject.GetComponent<ZoomOnMouse>().enabled = false;
				}
			}
		}
		Dropdown[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Dropdown>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].enabled = false;
		}
		if (Hover != null)
		{
			Hover.gameObject.SetActive(value: false);
		}
	}

	public void Start()
	{
		questName = base.gameObject.name;
		SceneBindContainer.BindObjects(this, base.transform);
	}

	private void Update()
	{
		if (ActiveComponent.Program != null && ActiveComponent.Program.joyInput.cursorDoubleClickUp && ActiveComponent.Model.construction.IsInConstructionGameMode())
		{
			OpenSandbox();
		}
		else
		{
			if (!hover || dummy || ActiveComponent.Model.currentChain == null)
			{
				return;
			}
			Socket[] componentsInChildren = GetComponentsInChildren<Socket>();
			float num = float.MaxValue;
			Socket socket = null;
			bool flag = false;
			string empty = string.Empty;
			Chain component = ActiveComponent.Model.currentChain.GetComponent<Chain>();
			if (component.socketOut == null)
			{
				flag = true;
				empty = component.socketIn.type;
			}
			else
			{
				empty = component.socketOut.type;
			}
			Vector3 mouseInWorld = Logic.GetMouseInWorld();
			Socket[] array = componentsInChildren;
			foreach (Socket socket2 in array)
			{
				float sqrMagnitude = (socket2.gameObject.transform.position - mouseInWorld).sqrMagnitude;
				if (sqrMagnitude < num && socket2.inSocket == flag && socket2.type == empty)
				{
					num = sqrMagnitude;
					socket = socket2;
				}
			}
			if (socket != null && !(socket == scaleSocket))
			{
				socket.gameObject.GetComponent<ZoomOnMouse>().UpScale();
				if (scaleSocket != null)
				{
					scaleSocket.gameObject.GetComponent<ZoomOnMouse>().DownScale();
					scaleSocket.OffLines();
				}
				socket.GlowLines();
				scaleSocket = socket;
			}
		}
	}
}

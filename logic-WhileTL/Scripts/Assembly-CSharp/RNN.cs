using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RNN : ActiveComponent, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
{
	private int maxSockets = 5;

	private Socket socketIn;

	private Socket socketOut;

	[SceneBind("Speed")]
	private Text Speed;

	[SceneBind("Error")]
	private Text Error;

	[SceneBind("RUnder")]
	private Image RUnder;

	[SceneBind("GUnder")]
	private Image GUnder;

	[SceneBind("BUnder")]
	private Image BUnder;

	[SceneBind("BufferObj")]
	private Image BufferObj;

	[SceneBind("OutputColor")]
	private Image outColor;

	private GameObject bufferElemObj;

	private Element bufElem;

	public List<Socket> socketsIn = new List<Socket>();

	public List<Socket> socketsOut = new List<Socket>();

	private float timer;

	private float delayTimer;

	private float lastActiveTime;

	private Element workElem;

	private int lastColor;

	private GameObject elemPref;

	public float error;

	private float value;

	public int outputColor;

	private List<Image> underList = new List<Image>();

	private bool init;

	public void OnBeginDrag(PointerEventData eventData)
	{
		base.gameObject.GetComponent<BlockData>().dragged = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		base.gameObject.GetComponent<BlockData>().dragged = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		base.gameObject.transform.position = Input.mousePosition;
	}

	private bool TryActive()
	{
		if (socketIn.queue.Count == 0)
		{
			return false;
		}
		bool result = true;
		for (int i = 0; i < maxSockets; i++)
		{
			if (socketsOut[i] != null && socketsOut[i].isFull())
			{
				result = false;
			}
		}
		return result;
	}

	private void Active()
	{
		Random.InitState(1234);
		if (!TryActive())
		{
			return;
		}
		if (workElem == null)
		{
			Element element = socketIn.GetElement();
			if (element == null)
			{
				Redraw();
				return;
			}
			workElem = element;
			if (bufElem != null)
			{
				socketIn.SetElement(bufElem);
				bufElem = null;
			}
		}
		workElem.ColorId++;
		workElem.ColorId %= 3;
		lastColor = workElem.ColorId;
		if (workElem.ColorId == outputColor)
		{
			if (Mathf.Abs(error - 0.1f) > 0.005f)
			{
				error = Mathf.Max(0.1f, Mathf.Min(1f, error + workElem.error));
			}
			else
			{
				error = 0.1f;
			}
			workElem.error /= 2f;
			socketsOut[2].SetElement(workElem);
			workElem = null;
		}
		else if (Random.Range(0f, 1f) <= error)
		{
			if (Mathf.Abs(error - 0.1f) > 0.005f)
			{
				error = Mathf.Max(0.1f, Mathf.Min(1f, error + workElem.error));
			}
			else
			{
				error = 0.1f;
			}
			socketsOut[2].SetElement(workElem);
			workElem = null;
		}
		else
		{
			bufElem = workElem;
			workElem.error /= 2f;
			workElem = null;
		}
		Redraw();
	}

	private void Redraw()
	{
		Error.text = "ERROR " + (int)(100f * error) + "%";
		outColor.color = Logic.GetColor(outputColor);
		foreach (Image under in underList)
		{
			under.enabled = false;
		}
		if (socketIn.queue.Count != 0)
		{
			underList[lastColor].enabled = true;
		}
		if (bufferElemObj != null)
		{
			Object.Destroy(bufferElemObj);
		}
		if (bufElem != null)
		{
			GameObject gameObject = Object.Instantiate(elemPref, base.transform.position, base.transform.rotation, BufferObj.gameObject.transform);
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.GetComponent<ElementControl>().Init(bufElem);
			bufferElemObj = gameObject;
		}
	}

	private void OutputClick()
	{
		outputColor++;
		outputColor %= 3;
		Redraw();
	}

	public override void Init()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		elemPref = Resources.Load("Prefabs/Element") as GameObject;
		outColor.gameObject.GetComponent<Button>().onClick.AddListener(OutputClick);
		underList.Add(RUnder);
		underList.Add(GUnder);
		underList.Add(BUnder);
		socketIn = base.transform.Find("SocketIn").GetComponent<Socket>();
		socketOut = base.transform.Find("SocketOut").GetComponent<Socket>();
		Speed.text = (TextResources.GetString("delay") + " " + (int)(Logic.GetWorkTimeByKeyName("RNN") / 0.05f)).ToString() + " / STEP";
		value = Logic.GetValueByKeyName("RNN");
		for (int i = 0; i < maxSockets; i++)
		{
			socketsIn.Add(null);
			socketsOut.Add(null);
		}
		socketsIn[2] = socketIn;
		socketsOut[2] = socketOut;
		for (int j = 0; j < maxSockets; j++)
		{
			if (socketsIn[j] != null)
			{
				socketsIn[j].num = j;
			}
			if (socketsOut[j] != null)
			{
				socketsOut[j].num = j;
			}
		}
		error = 0.75f;
		if (base.gameObject.GetComponent<BlockData>().sh != null)
		{
			SchemeBlock sh = base.gameObject.GetComponent<BlockData>().sh;
			error = sh.error;
			outputColor = sh.outputRNNColor;
		}
		delayTimer = Logic.GetWorkTimeByKeyName("RNN");
		Redraw();
	}

	private void Awake()
	{
		Init();
	}

	private void Update()
	{
		if (socketIn.queue.Count == 0)
		{
			lastActiveTime = timer;
		}
		timer += Time.deltaTime;
		if (timer - lastActiveTime >= delayTimer)
		{
			Active();
			lastActiveTime = timer;
		}
	}
}

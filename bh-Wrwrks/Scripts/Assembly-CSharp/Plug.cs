using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plug : MonoBehaviour
{
	public enum Type
	{
		input = 0,
		output = 1
	}

	public enum Color
	{
		red = 0,
		green = 1,
		blue = 2
	}

	public GameObject lineObj;

	public Module owner;

	public Plug connectedPlug;

	public Sprite filledSprite;

	public Sprite normalSprite;

	public SpriteRenderer highlight;

	public SpriteRenderer cover;

	public Type type;

	public Color color;

	public Line activeLine;

	private Coroutine anim;

	private Coroutine connectedAnim;

	public bool dragging;

	public Dungeon dungeon => Dungeon.Instance;

	public Module target
	{
		get
		{
			if (!(connectedPlug == null))
			{
				return connectedPlug.owner;
			}
			return null;
		}
	}

	public bool connected => connectedPlug != null;

	public void Start()
	{
		if (owner == null && GetComponentsInParent<Module>().Length != 0)
		{
			owner = GetComponentInParent<Module>();
		}
	}

	private void OnDestroy()
	{
	}

	public void StartConnection()
	{
		if (connected)
		{
			Plug p = connectedPlug;
			Disconnect();
			dungeon.EndTargeting();
			dungeon.ClickPlug(p);
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = filledSprite;
			anim = StartCoroutine(connectionAnim());
		}
	}

	public void Disconnect()
	{
		if (!connected)
		{
			return;
		}
		if (connectedAnim != null)
		{
			StopCoroutine(connectedAnim);
		}
		if (connectedPlug.activeLine != null)
		{
			UnityEngine.Object.Destroy(connectedPlug.activeLine.gameObject);
		}
		if (activeLine != null)
		{
			UnityEngine.Object.Destroy(connectedPlug.activeLine.gameObject);
		}
		connectedPlug.activeLine = null;
		connectedPlug.connectedPlug = null;
		UnhighlightAll();
		List<Module> list = new List<Module>();
		List<Module> list2 = new List<Module>();
		if (type == Type.output)
		{
			list = GetInputs(owner);
			list2 = GetOutputs(target);
		}
		else
		{
			list = GetInputs(target);
			list2 = GetOutputs(owner);
		}
		foreach (Module item in list)
		{
			foreach (Module item2 in list2)
			{
				if (!item.WIREMOD && !item2.WIREMOD)
				{
					item2.EndConnection(item);
					item.EndConnection(item2);
				}
			}
		}
		foreach (Module item3 in list)
		{
			foreach (Module item4 in list2)
			{
				item4.inputs.Remove(item3);
				item3.outputs.Remove(item4);
			}
		}
		GetComponent<SpriteRenderer>().sprite = normalSprite;
		connectedPlug.GetComponent<SpriteRenderer>().sprite = normalSprite;
		connectedPlug = null;
		dungeon.board.CheckAuras();
	}

	public void CancelConnection()
	{
		if (connected)
		{
			Disconnect();
		}
		if (activeLine != null)
		{
			UnityEngine.Object.Destroy(activeLine.gameObject);
		}
		dungeon.EndTargeting();
		GetComponent<SpriteRenderer>().sprite = normalSprite;
		if (connectedPlug != null)
		{
			connectedPlug.GetComponent<SpriteRenderer>().sprite = normalSprite;
		}
		connectedPlug = null;
		if (anim != null)
		{
			StopCoroutine(anim);
		}
		UnhighlightAll();
	}

	public bool CheckSafeDuplication(Plug p)
	{
		if (p.owner.inputs.Contains(owner))
		{
			return false;
		}
		if (p.owner.outputs.Contains(owner))
		{
			return false;
		}
		List<Module> list = new List<Module> { p.owner };
		if (p.owner.WIREMOD)
		{
			if (p.type == Type.output)
			{
				list.AddRange(GetInputs(p.owner));
			}
			if (p.type == Type.input)
			{
				list.AddRange(GetOutputs(p.owner));
			}
		}
		foreach (Module item in list)
		{
			if (owner.WIREMOD)
			{
				List<Module> inputs = GetInputs(owner);
				List<Module> outputs = GetOutputs(owner);
				foreach (Module item2 in inputs)
				{
					if (item.inputs.Contains(item2))
					{
						return false;
					}
				}
				foreach (Module item3 in outputs)
				{
					if (item.outputs.Contains(item3))
					{
						return false;
					}
				}
			}
			if (!item.WIREMOD)
			{
				continue;
			}
			List<Module> inputs2 = GetInputs(item);
			List<Module> outputs2 = GetOutputs(item);
			foreach (Module item4 in inputs2)
			{
				if (owner.inputs.Contains(item4))
				{
					return false;
				}
			}
			foreach (Module item5 in outputs2)
			{
				if (owner.outputs.Contains(item5))
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool ConnectTo(Plug p, bool manual)
	{
		if (p == this)
		{
			CancelConnection();
			return false;
		}
		if (owner == p.owner)
		{
			return false;
		}
		if (p.type == type)
		{
			return false;
		}
		if (p.color != color)
		{
			return false;
		}
		if (p.connected)
		{
			if (owner.outputs.Contains(p.owner) && p.connectedPlug.owner != owner)
			{
				dungeon.board.ShowDupeError(p.owner);
				return false;
			}
			p.Disconnect();
		}
		if (!CheckSafeDuplication(p))
		{
			dungeon.board.ShowDupeError(p.owner);
			return false;
		}
		if (manual)
		{
			UnhighlightAll();
		}
		if (anim != null)
		{
			StopCoroutine(anim);
		}
		dungeon.board.wireCount++;
		ConnectPreview(p.transform.position);
		p.activeLine = activeLine;
		if (manual)
		{
			activeLine.Highlight();
		}
		connectedPlug = p;
		connectedPlug.connectedPlug = this;
		activeLine.hitbox.enabled = true;
		if (manual)
		{
			activeLine.Highlight();
			Highlight();
			connectedPlug.Highlight();
		}
		GetComponent<SpriteRenderer>().sprite = filledSprite;
		connectedPlug.GetComponent<SpriteRenderer>().sprite = filledSprite;
		Module m = p.owner;
		List<Module> list = new List<Module>();
		List<Module> list2 = new List<Module>();
		if (type == Type.output)
		{
			list = GetInputs(owner);
			list2 = GetOutputs(m);
		}
		else if (type == Type.input)
		{
			list = GetInputs(m);
			list2 = GetOutputs(owner);
		}
		foreach (Module item in list)
		{
			foreach (Module item2 in list2)
			{
				item2.inputs.Add(item);
				item.outputs.Add(item2);
			}
		}
		foreach (Module item3 in list)
		{
			foreach (Module item4 in list2)
			{
				if (!item3.WIREMOD && !item4.WIREMOD)
				{
					item4.InitConnection(item3);
					item3.InitConnection(item4);
				}
			}
		}
		dungeon.board.CheckAuras();
		return true;
	}

	public void StartDrag()
	{
		if (!dragging)
		{
			dragging = true;
			if (connected)
			{
				activeLine.line.sortingOrder = activeLine.orderUp;
				activeLine.shadow.sortingOrder = activeLine.orderShadowUp;
				activeLine.highlight.sortingOrder = activeLine.orderHighUp;
				connectedAnim = StartCoroutine(PersistentConnection(connectedPlug));
			}
		}
	}

	public void EndDrag()
	{
		dragging = false;
		if (connectedAnim != null)
		{
			StartCoroutine(endDragger());
		}
	}

	private IEnumerator endDragger()
	{
		if (connected)
		{
			activeLine.line.sortingOrder = activeLine.order;
			activeLine.shadow.sortingOrder = activeLine.orderShadow;
			activeLine.highlight.sortingOrder = activeLine.orderHigh;
		}
		Coroutine m = connectedAnim;
		yield return null;
		if (m != null)
		{
			StopCoroutine(m);
		}
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		if (connected)
		{
			DrawLine(activeLine, connectedPlug.transform.position);
		}
	}

	private IEnumerator PersistentConnection(Plug p)
	{
		while (activeLine != null)
		{
			DrawLine(activeLine, p.transform.position);
			yield return null;
		}
	}

	public void ConnectPreview(Vector2 target)
	{
		if (activeLine != null)
		{
			UnityEngine.Object.Destroy(activeLine.gameObject);
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(lineObj);
		activeLine = gameObject.GetComponent<Line>();
		activeLine.line.sortingOrder = (int)(dungeon.board.wireCount + 1) * 5;
		activeLine.order = activeLine.line.sortingOrder;
		activeLine.line.sortingLayerName = "WidgetElevated";
		activeLine.plug = this;
		LineRenderer line = activeLine.line;
		float startWidth = (activeLine.line.endWidth = 0.35f);
		line.startWidth = startWidth;
		activeLine.line.numCapVertices = 5;
		activeLine.line.numCornerVertices = 5;
		activeLine.hitbox.enabled = false;
		DrawLine(activeLine, target);
	}

	private void DrawLine(Line line, Vector2 target)
	{
		line.Clear();
		foreach (Vector2 item in GetCable(target))
		{
			line.UpdateLine(item);
		}
	}

	private List<Vector2> GetCable(Vector2 target)
	{
		Vector3 position = base.transform.position;
		List<Vector2> list = new List<Vector2>();
		if (position.x == target.x)
		{
			list.Add(position);
			list.Add(Vector2.Lerp(position, target, 0.25f));
			list.Add(Vector2.Lerp(position, target, 0.75f));
			list.Add(target);
			return list;
		}
		float num = Mathf.Abs(position.y - target.y) / 2f;
		float num2 = Mathf.Abs(position.x - target.x);
		float num3 = Mathf.Sign(target.x - position.x);
		float num4 = Mathf.Sign(target.y - position.y);
		Vector2 vector = base.transform.position;
		Vector2 vector2 = target;
		bool flag = false;
		if ((num3 < 0f && num4 > 0f) || (num3 > 0f && num4 < 0f))
		{
			flag = false;
			if (num3 < 0f)
			{
				vector = target;
				vector2 = base.transform.position;
			}
		}
		else
		{
			flag = true;
			if (num3 > 0f)
			{
				vector = target;
				vector2 = base.transform.position;
			}
		}
		float num5 = 40f;
		for (int i = 0; (float)i < num5; i++)
		{
			Vector2 item = default(Vector2);
			float num6 = Mathf.Lerp(0f, num2, (float)i / (num5 - 1f));
			float f = MathF.PI * (1f / num2 * num6 + 0.5f);
			float num7 = num * Mathf.Sin(f);
			item = new Vector2(num6 * (float)((!flag) ? 1 : (-1)) + vector.x, (vector.y + vector2.y) / 2f + num7);
			list.Add(item);
		}
		return list;
	}

	public IEnumerator connectionAnim()
	{
		dungeon.board.wireCount++;
		List<Plug> plugs = new List<Plug>();
		List<Plug> covPlugs = new List<Plug>();
		foreach (Module module in Dungeon.Instance.board.modules)
		{
			if (module == null)
			{
				continue;
			}
			Plug[] componentsInChildren = module.GetComponentsInChildren<Plug>();
			foreach (Plug plug in componentsInChildren)
			{
				if (!plug.connected)
				{
					if (!CheckSafeDuplication(plug))
					{
						covPlugs.Add(plug);
					}
					else if (plug.type != type && plug.owner != owner)
					{
						plugs.Add(plug);
					}
					else if (plug != this)
					{
						covPlugs.Add(plug);
					}
				}
			}
		}
		foreach (Plug item in covPlugs)
		{
			plugs.Remove(item);
		}
		int i2 = 0;
		bool h = true;
		bool canClickCancel = false;
		while (true)
		{
			ConnectPreview(GetMousePos());
			foreach (Plug item2 in plugs)
			{
				if (h)
				{
					item2.Highlight();
				}
				else
				{
					item2.Unhighlight();
				}
			}
			foreach (Plug item3 in covPlugs)
			{
				item3.Highlight(cover: true);
			}
			h = i2 < 20;
			if (i2 == 30)
			{
				i2 = 0;
			}
			i2++;
			if (Input.GetMouseButtonUp(0))
			{
				canClickCancel = true;
			}
			if (Input.GetMouseButtonDown(1))
			{
				dungeon.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f);
				CancelConnection();
				yield break;
			}
			if (Input.GetMouseButtonDown(0) && dungeon.hoveredModule == null && canClickCancel)
			{
				break;
			}
			yield return null;
		}
		dungeon.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f);
		CancelConnection();
	}

	public static List<Module> GetInputs(Module m, List<Module> prev = null)
	{
		List<Module> list = new List<Module>();
		if (prev != null)
		{
			list.AddRange(prev);
		}
		if (!m.WIREMOD)
		{
			list.Add(m);
			return list;
		}
		list.Add(m);
		foreach (Module input in m.inputs)
		{
			if (prev == null || !prev.Contains(m))
			{
				list.AddRange(GetInputs(input, list));
			}
		}
		return new List<Module>(list.Distinct());
	}

	public static List<Module> GetOutputs(Module m, List<Module> prev = null)
	{
		List<Module> list = new List<Module>();
		if (prev != null)
		{
			list.AddRange(prev);
		}
		if (!m.WIREMOD)
		{
			list.Add(m);
			return list;
		}
		list.Add(m);
		foreach (Module output in m.outputs)
		{
			if (prev == null || !prev.Contains(m))
			{
				list.AddRange(GetOutputs(output, list));
			}
		}
		return new List<Module>(list.Distinct());
	}

	public void Highlight(bool cover = false)
	{
		if (!this.cover.enabled)
		{
			if (cover)
			{
				this.cover.enabled = true;
			}
			else
			{
				highlight.enabled = true;
			}
		}
	}

	public void Unhighlight()
	{
		highlight.enabled = false;
		cover.enabled = false;
	}

	public void UnhighlightAll()
	{
		foreach (Module module in Dungeon.Instance.board.modules)
		{
			if (!(module == null))
			{
				Plug[] componentsInChildren = module.GetComponentsInChildren<Plug>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].Unhighlight();
				}
			}
		}
	}

	private void OnMouseEnter()
	{
		dungeon.hoveredModule = owner;
		if (owner.shopItem || owner.bankItem)
		{
			owner.dungeon.tooltip.Set(owner);
			return;
		}
		if (activeLine != null)
		{
			activeLine.Highlight();
		}
		Highlight();
		if (connectedPlug != null)
		{
			connectedPlug.Highlight();
		}
	}

	private void OnMouseExit()
	{
		dungeon.hoveredModule = null;
		if (owner.shopItem || owner.bankItem)
		{
			owner.dungeon.tooltip.Hide();
			return;
		}
		if (activeLine != null)
		{
			activeLine.Unhighlight();
		}
		Unhighlight();
		if (connectedPlug != null)
		{
			connectedPlug.Unhighlight();
		}
	}

	private void OnMouseDown()
	{
		if (!owner.shopItem && !owner.bankItem)
		{
			dungeon.ClickPlug(this);
		}
	}

	private void OnMouseDrag()
	{
	}

	private void OnMouseUp()
	{
		StartCoroutine(jj());
	}

	private IEnumerator jj()
	{
		yield return null;
	}

	private void OnMouseOver()
	{
		if (activeLine != null)
		{
			activeLine.Highlight();
		}
		if (Input.GetKeyDown(KeyCode.Mouse1) && connected)
		{
			if (dungeon.state == Dungeon.State.Combat)
			{
				owner.board.CombatError(owner);
				return;
			}
			dungeon.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f);
			Disconnect();
		}
	}

	public static Vector3 GetMousePos()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, 0f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
	}
}

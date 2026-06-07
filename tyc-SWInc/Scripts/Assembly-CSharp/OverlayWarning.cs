using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayWarning : Graphic
{
	public Texture tex;

	public GameObject LabelPrefab;

	public RectTransform LabelPanel;

	public AnimationCurve DistanceFactor;

	public List<Text> Pool = new List<Text>();

	private List<Vector3> Warnings = new List<Vector3>();

	private int WarningCount;

	private bool MouseOver;

	private float ColorT;

	public override Texture mainTexture
	{
		get
		{
			return tex;
		}
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		if (WarningCount != 0 || h.currentVertCount != 0)
		{
			h.Clear();
			for (int i = 0; i < WarningCount; i++)
			{
				Vector2 vector = new Vector2(Warnings[i].x, Warnings[i].y) / Options.UISize - HUD.Instance.MainContentPanel.offsetMin;
				int num = Mathf.RoundToInt(16f * DistanceFactor.Evaluate(Mathf.Abs(Warnings[i].z)));
				h.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector3(vector.x - (float)num, vector.y - (float)num),
						uv0 = new Vector2(0f, 0f),
						color = color
					},
					new UIVertex
					{
						position = new Vector3(vector.x + (float)num, vector.y - (float)num),
						uv0 = new Vector2(1f, 0f),
						color = color
					},
					new UIVertex
					{
						position = new Vector3(vector.x + (float)num, vector.y + (float)num),
						uv0 = new Vector2(1f, 1f),
						color = color
					},
					new UIVertex
					{
						position = new Vector3(vector.x - (float)num, vector.y + (float)num),
						uv0 = new Vector2(0f, 1f),
						color = color
					}
				});
			}
		}
	}

	private void Update()
	{
		if (Application.isPlaying)
		{
			ColorT = (ColorT + Time.deltaTime) % 2f;
			float t = ((ColorT < 1f) ? ColorT : (2f - ColorT));
			color = Color.Lerp(Color.white, Color.red, t);
		}
	}

	public void BeginMessageUpdate()
	{
		WarningCount = 0;
		MouseOver = false;
	}

	public bool AddMessages(Vector3 pos, Vector2 mp, string message)
	{
		if (WarningCount > 128)
		{
			return false;
		}
		if (Outside(pos))
		{
			return true;
		}
		Vector3 vector = new Vector3(pos.x, 0f - ((float)Screen.height - pos.y), pos.z);
		if (!MouseOver && Within(mp, pos))
		{
			ShowMessages(message, vector);
			MouseOver = true;
			return true;
		}
		if (WarningCount == Warnings.Count)
		{
			Warnings.Add(Vector3.zero);
		}
		Warnings[WarningCount] = vector;
		WarningCount++;
		return true;
	}

	public bool AddMessages(Vector3 pos, Vector2 mp, List<string> messages)
	{
		if (WarningCount > 64)
		{
			return false;
		}
		if (Outside(pos))
		{
			return true;
		}
		Vector3 vector = new Vector3(pos.x, 0f - ((float)Screen.height - pos.y), pos.z);
		if (!MouseOver && Within(mp, pos))
		{
			ShowMessages(messages, vector);
			MouseOver = true;
			return true;
		}
		if (WarningCount == Warnings.Count)
		{
			Warnings.Add(Vector3.zero);
		}
		Warnings[WarningCount] = vector;
		WarningCount++;
		return true;
	}

	private bool Outside(Vector2 p)
	{
		if (!(p.x < -16f) && !(p.x > (float)(Screen.width + 16)) && !(p.y < -16f))
		{
			return p.y > (float)(Screen.height + 16);
		}
		return true;
	}

	private bool Within(Vector2 p, Vector2 t)
	{
		if (p.x >= t.x - 16f && p.x <= t.x + 16f && p.y >= t.y - 16f)
		{
			return p.y <= t.y + 16f;
		}
		return false;
	}

	private void ShowMessages(List<string> messages, Vector2 pos)
	{
		LabelPanel.anchoredPosition = (pos + Vector2.down * 16f) / Options.UISize - HUD.Instance.MainContentPanel.offsetMin;
		int i = 0;
		for (int num = Mathf.Min(Pool.Count, messages.Count); i < num; i++)
		{
			Pool[i].text = messages[i];
			Transform parent = Pool[i].transform.parent;
			parent.gameObject.SetActive(true);
			parent.GetComponent<Image>().sprite = ObjectDatabase.Instance.GetSprite(i == 0, i == num - 1, i == num - 1, i == 0);
		}
		if (i < messages.Count)
		{
			for (; i < messages.Count; i++)
			{
				GameObject obj = Object.Instantiate(LabelPrefab);
				Text componentInChildren = obj.GetComponentInChildren<Text>();
				componentInChildren.text = messages[i];
				obj.transform.SetParent(LabelPanel, false);
				Pool.Add(componentInChildren);
			}
		}
		if (i < Pool.Count)
		{
			for (; i < Pool.Count; i++)
			{
				Pool[i].transform.parent.gameObject.SetActive(false);
			}
		}
	}

	private void ShowMessages(string message, Vector2 pos)
	{
		LabelPanel.anchoredPosition = (pos + Vector2.down * 16f) / Options.UISize - HUD.Instance.MainContentPanel.offsetMin;
		if (Pool.Count == 0)
		{
			GameObject gameObject = Object.Instantiate(LabelPrefab);
			gameObject.transform.SetParent(LabelPanel, false);
			Pool.Add(gameObject.GetComponentInChildren<Text>());
		}
		Pool[0].text = message;
		Transform parent = Pool[0].transform.parent;
		parent.gameObject.SetActive(true);
		parent.GetComponent<Image>().sprite = ObjectDatabase.Instance.GetSprite(true, true, true, true);
		for (int i = 1; i < Pool.Count; i++)
		{
			Pool[i].transform.parent.gameObject.SetActive(false);
		}
	}

	public void EndMessageUpdate()
	{
		if (!MouseOver)
		{
			for (int i = 0; i < Pool.Count; i++)
			{
				Pool[i].transform.parent.gameObject.SetActive(false);
			}
		}
		SetVerticesDirty();
	}
}

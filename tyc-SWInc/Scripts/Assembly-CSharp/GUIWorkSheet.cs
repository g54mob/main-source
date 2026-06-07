using UnityEngine;
using UnityEngine.UI;

public class GUIWorkSheet : MonoBehaviour
{
	public int Width;

	public int Height;

	public GameObject CellPrefab;

	public Text[,] CellText;

	public Image[,] CellImage;

	public bool ManualInit;

	private GridLayoutGroup layout;

	private RectTransform rect;

	public Text this[int i, int j]
	{
		get
		{
			return CellText[i, j];
		}
	}

	private void Start()
	{
		rect = GetComponent<RectTransform>();
		layout = GetComponent<GridLayoutGroup>();
		if (!ManualInit)
		{
			Init();
		}
	}

	public void Initialize()
	{
		if (ManualInit)
		{
			Init();
		}
	}

	public void MarkRow(int r, Color color)
	{
		for (int i = 0; i < Width; i++)
		{
			CellImage[i, r].color = color;
			CellText[i, r].fontSize = 16;
		}
	}

	public void IndentCell(int x, int y, float amount)
	{
		RectTransform component = CellText[x, y].GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(amount, component.anchoredPosition.y);
	}

	private void Init()
	{
		CellText = new Text[Width, Height];
		CellImage = new Image[Width, Height];
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				GameObject obj = Object.Instantiate(CellPrefab);
				Text componentInChildren = obj.GetComponentInChildren<Text>();
				Image component = obj.GetComponent<Image>();
				if (i % 2 == 1)
				{
					component.color = new Color(1f, 1f, 1f, 0.5f);
				}
				componentInChildren.text = "";
				obj.transform.SetParent(base.transform, false);
				CellText[j, i] = componentInChildren;
				CellImage[j, i] = component;
			}
		}
	}

	private void Update()
	{
		layout.cellSize = new Vector2(rect.rect.width / (float)Width, rect.rect.height / (float)Height);
	}
}

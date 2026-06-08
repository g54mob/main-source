using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class ForeignLanguageRenderer : MonoBehaviour
{
	public ForeignLanguageCell cellPrototype;

	private Canvas myCanvas;

	private RectTransform myRectTransform;

	private Stack<ForeignLanguageCell> cellPool = new Stack<ForeignLanguageCell>();

	private const int MAX_COLUMNS = 92;

	private const int MAX_ROWS = 27;

	private ForeignLanguageCell[,] cellBuffer = new ForeignLanguageCell[92, 27];

	public static ForeignLanguageRenderer singleton { get; private set; }

	public void Draw(AsciiRenderProcedural r)
	{
		float x = r.transform.localScale.x;
		float y = r.transform.localScale.y;
		myRectTransform.sizeDelta = new Vector2(x * (float)r.width, y * (float)r.height);
		int num = Mathf.Min(92, r.width);
		int num2 = Mathf.Min(27, r.height);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				ForeignLanguageCell foreignLanguageCell = cellBuffer[i, j];
				AsciiCellProcedural cell = r.GetCell(i, j, skipSafety: true);
				if (cell == null || cell.GetUnicodeValue() == '\0')
				{
					if (foreignLanguageCell != null)
					{
						cellBuffer[i, j] = null;
						Recycle(foreignLanguageCell);
					}
					continue;
				}
				if (foreignLanguageCell == null)
				{
					foreignLanguageCell = NewCell();
					cellBuffer[i, j] = foreignLanguageCell;
				}
				foreignLanguageCell.unicodeValue = cell.GetUnicodeValue();
				foreignLanguageCell.SetPosition(new Vector2((float)i * x, (float)j * (0f - y)));
				foreignLanguageCell.SetFontSize(x);
				foreignLanguageCell.SetHeight(y);
				foreignLanguageCell.SetColor(cell.GetForeground());
			}
		}
	}

	public ForeignLanguageCell GetCellAt(int i, int j)
	{
		if (i >= 0 && i < 92 && j >= 0 && j < 27)
		{
			return cellBuffer[i, j];
		}
		return null;
	}

	private ForeignLanguageCell NewCell()
	{
		ForeignLanguageCell foreignLanguageCell;
		if (cellPool.Count > 0)
		{
			foreignLanguageCell = cellPool.Pop();
		}
		else
		{
			foreignLanguageCell = Object.Instantiate(cellPrototype, myCanvas.transform, worldPositionStays: true);
			foreignLanguageCell.Init();
		}
		foreignLanguageCell.gameObject.SetActive(value: true);
		return foreignLanguageCell;
	}

	private void Recycle(ForeignLanguageCell cell)
	{
		cell.gameObject.SetActive(value: false);
		cellPool.Push(cell);
	}

	private void Awake()
	{
		singleton = this;
		myCanvas = GetComponent<Canvas>();
		myRectTransform = GetComponent<RectTransform>();
	}
}

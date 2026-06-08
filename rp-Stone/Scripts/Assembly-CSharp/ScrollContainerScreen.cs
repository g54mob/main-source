using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrollContainerScreen : AsciiObject, IActivatable
{
	public CommonHeader header;

	public ScrollContainer scrollContainer;

	private bool needsRefresh;

	[NonSerialized]
	public List<AsciiObject> rows = new List<AsciiObject>();

	private Dictionary<AsciiObject, Stack<AsciiObject>> rowPoolDict = new Dictionary<AsciiObject, Stack<AsciiObject>>();

	public abstract void UpdateContents();

	protected virtual void OnDestroy()
	{
		rows.Clear();
		rowPoolDict.Clear();
	}

	protected void RecycleAllRows()
	{
		scrollContainer.Clear();
		for (int num = rows.Count - 1; num >= 0; num--)
		{
			AsciiObject key = rows[num].sourcePrefab;
			Stack<AsciiObject> stack;
			if (rowPoolDict.ContainsKey(key))
			{
				stack = rowPoolDict[key];
			}
			else
			{
				stack = new Stack<AsciiObject>();
				rowPoolDict.Add(key, stack);
			}
			stack.Push(rows[num]);
		}
		rows.Clear();
	}

	protected AsciiObject AddRowFromPrefab(AsciiObject rowPrefab, bool top = false)
	{
		AsciiObject asciiObject;
		if (rowPoolDict.ContainsKey(rowPrefab) && rowPoolDict[rowPrefab].Count > 0)
		{
			asciiObject = rowPoolDict[rowPrefab].Pop();
		}
		else
		{
			asciiObject = UnityEngine.Object.Instantiate(rowPrefab);
			asciiObject.sourcePrefab = rowPrefab;
			asciiObject.transform.parent = base.transform;
		}
		return AddRowInstance(asciiObject, top);
	}

	protected AsciiObject AddRowInstance(AsciiObject row, bool top = false)
	{
		row.Width = scrollContainer.Width;
		rows.Add(row);
		scrollContainer.AddRow(row, top);
		return row;
	}

	protected void RemoveRow(AsciiObject row)
	{
		rows.Remove(row);
		scrollContainer.RemoveRow(row);
	}

	public virtual void Activate()
	{
		needsRefresh = true;
	}

	public void NeedsRefresh()
	{
		needsRefresh = true;
	}

	public virtual void Deactivate()
	{
	}

	private void TryRefresh()
	{
		if (needsRefresh)
		{
			needsRefresh = false;
			UpdateContents();
		}
	}

	public override void UpdateTic()
	{
		TryRefresh();
		if (header != null)
		{
			header.UpdateTic();
		}
		scrollContainer.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		TryRefresh();
		if (header != null)
		{
			header.Draw(r, offsetX, offsetY);
		}
		scrollContainer.Draw(r, offsetX, offsetY);
	}
}

using UnityEngine;
using VRTK;

public class ExhibitionHighlighter : MonoBehaviour
{
	public KeyCode next = KeyCode.RightArrow;

	public KeyCode previous = KeyCode.LeftArrow;

	public KeyCode toggle = KeyCode.DownArrow;

	public GameObject[] objectsToHighlight;

	private int cur = -1;

	private Color highlightColor = new Color(0f, 255f, 181f, 1f);

	private void Update()
	{
		if (Input.GetKeyDown(toggle))
		{
			if (IsHighlighted(cur))
			{
				Unhighlight(cur);
			}
			else
			{
				Highlight(cur);
			}
			return;
		}
		int num = (Input.GetKeyDown(previous) ? (-1) : (Input.GetKeyDown(next) ? 1 : 0));
		if (num != 0)
		{
			Unhighlight(cur);
			cur = (cur + num) % objectsToHighlight.Length;
			if (cur < 0)
			{
				cur += objectsToHighlight.Length;
			}
			Highlight(cur);
		}
	}

	private void Unhighlight(int n)
	{
		if (IsValidIndex(n))
		{
			VRTK_ObjectAppearance.UnhighlightObject(objectsToHighlight[n]);
		}
	}

	private void Highlight(int n)
	{
		if (IsValidIndex(n))
		{
			VRTK_ObjectAppearance.HighlightObject(objectsToHighlight[n], highlightColor);
		}
	}

	private bool IsValidIndex(int i)
	{
		if (objectsToHighlight != null && i >= 0)
		{
			return i < objectsToHighlight.Length;
		}
		return false;
	}

	private bool IsHighlighted(int n)
	{
		if (!IsValidIndex(n))
		{
			return false;
		}
		VRTK_PlayerObject componentInChildren = objectsToHighlight[n].GetComponentInChildren<VRTK_PlayerObject>(includeInactive: true);
		if (componentInChildren == null || componentInChildren.objectType != VRTK_PlayerObject.ObjectTypes.Highlighter)
		{
			return false;
		}
		return componentInChildren.gameObject.activeSelf;
	}
}

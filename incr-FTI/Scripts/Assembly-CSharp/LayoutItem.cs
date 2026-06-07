using System;
using System.Diagnostics;
using UnityEngine;

[Serializable]
public class LayoutItem
{
	public object linkedObject;

	public float y;

	public float max;

	public float heightOfSelf;

	public bool isValid;

	[NonSerialized]
	public LayoutManager parentManager;

	public string debugString;

	public string debugInvalidReason;

	public string debugMinimization;

	public float leftAnchor;

	public float rightAnchor;

	[SerializeField]
	private bool isSuppressedFromRoot;

	[SerializeField]
	private bool isSuppressedFromSearch;

	public bool isSuppressed { get; private set; }

	public void SetSuppressedFromRoot(bool nextState)
	{
		isSuppressedFromRoot = nextState;
		isSuppressed = isSuppressedFromRoot || isSuppressedFromSearch;
	}

	public void SetSuppressedFromSearch(bool nextState)
	{
		isSuppressedFromSearch = nextState;
		isSuppressed = isSuppressedFromRoot || isSuppressedFromSearch;
	}

	public string PrintDebug()
	{
		if (debugString == null)
		{
			if (linkedObject != null)
			{
				return linkedObject.ToString();
			}
			return "null";
		}
		return debugString;
	}

	[Conditional("UNITY_EDITOR")]
	public void SetDebugString(string s)
	{
		debugString = s;
	}

	[Conditional("UNITY_EDITOR")]
	public void SetDebugInvalidReason(string s)
	{
		debugInvalidReason = s;
	}

	[Conditional("UNITY_EDITORx")]
	public void SetMinimizationDebug(string s)
	{
		debugMinimization = s;
	}

	public bool IsChildOf(LayoutManager lm)
	{
		if (parentManager == null)
		{
			return false;
		}
		if (lm == parentManager)
		{
			return true;
		}
		return parentManager.IsChildOf(lm);
	}
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class HeaderCollapseManager
{
	private readonly HashSet<int> minimizedHeaders = new HashSet<int>();

	public string debugString;

	public void Reset()
	{
		minimizedHeaders.Clear();
	}

	public void SetMinimized(int t, bool next = true)
	{
		if (next)
		{
			minimizedHeaders.Add(t);
		}
		else
		{
			minimizedHeaders.Remove(t);
		}
	}

	public void ToggleMinimized(int t)
	{
		if (minimizedHeaders.Contains(t))
		{
			minimizedHeaders.Remove(t);
		}
		else
		{
			minimizedHeaders.Add(t);
		}
	}

	public bool IsMinimized(int key)
	{
		if (key == 0)
		{
			return false;
		}
		return minimizedHeaders.Contains(key);
	}

	public void LoadMinimizedHeaders(List<int> targetList)
	{
		foreach (int minimizedHeader in minimizedHeaders)
		{
			targetList.Add(minimizedHeader);
		}
	}

	public string PrintDebug()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append("Minimized: ");
		foreach (int minimizedHeader in minimizedHeaders)
		{
			pooledStringBuilder.Append(minimizedHeader + ",");
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	[Conditional("UNITY_EDITOR")]
	public void SetDebugString(string s)
	{
		debugString = s;
	}
}

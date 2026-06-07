using System;
using System.Collections.Generic;
using StatementParser;
using UnityEngine;

public class FurnLoadScript : MonoBehaviour
{
	public class FurnScope : ScriptSystem.TaskScope
	{
		private static FurnScope _tempScope = new FurnScope();

		public Furniture Furn;

		public DateTime Date
		{
			get
			{
				return DateTime.Now;
			}
		}

		public static FurnScope GetScope(Furniture furn)
		{
			_tempScope.Furn = furn;
			return _tempScope;
		}

		public void DestroyObject(UnityEngine.Object o)
		{
			UnityEngine.Object.Destroy(o);
		}
	}

	private static Dictionary<int, LineParse.TreeNode> _cachedScripts = new Dictionary<int, LineParse.TreeNode>();

	[TextArea(3, 10)]
	public string Script;

	public Furniture Furn;

	private void Start()
	{
		if (Furn != null)
		{
			if (Furn.isTemporary)
			{
				return;
			}
			int hashCode = Script.GetHashCode();
			LineParse.TreeNode value = null;
			if (!_cachedScripts.TryGetValue(hashCode, out value))
			{
				try
				{
					value = LineParse.Parse(Script);
				}
				catch (Exception)
				{
					value = null;
				}
				_cachedScripts[hashCode] = value;
			}
			if (value != null)
			{
				try
				{
					LineParse.Execute(value, FurnScope.GetScope(Furn));
				}
				catch (Exception)
				{
				}
			}
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}

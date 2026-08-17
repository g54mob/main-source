using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class NodeTree
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<NodeTree, string> _003C_003E9__15_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CToString_003Eb__15_0(NodeTree c)
		{
			if (c != null)
			{
				return c.ToString();
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private Vector2Int _003Cposition_003Ek__BackingField;

	private NodeTree _003Cparent_003Ek__BackingField;

	private List<NodeTree> _003Cchildren_003Ek__BackingField;

	public int height;

	public int yDir;

	public Vector2Int position
	{
		get
		{
			return _003Cposition_003Ek__BackingField;
		}
		private set
		{
			_003Cposition_003Ek__BackingField = value;
		}
	}

	public NodeTree parent
	{
		get
		{
			return _003Cparent_003Ek__BackingField;
		}
		private set
		{
			_003Cparent_003Ek__BackingField = value;
		}
	}

	public List<NodeTree> children
	{
		get
		{
			return _003Cchildren_003Ek__BackingField;
		}
		private set
		{
			_003Cchildren_003Ek__BackingField = value;
		}
	}

	public NodeTree(Vector2Int position, NodeTree parent)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		_003Cposition_003Ek__BackingField = position;
		_003Cparent_003Ek__BackingField = parent;
		List<NodeTree> list = new List<NodeTree>();
		list._002Ector();
		_003Cchildren_003Ek__BackingField = list;
	}

	public override string ToString()
	{
		//IL_00a5: Expected I, but got O
		//IL_011a: Expected I, but got O
		//IL_012a: Expected O, but got I
		string[] array = new string[5];
		if (array.Length > 0)
		{
			array[0] = "{\"pos\": \"";
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			NumberFormatInfo numberFormat = invariantCulture.NumberFormat;
			object[] array2 = new object[2];
			int num = default(int);
			string text = num.ToString(null, numberFormat);
			if (text != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj = default(object);
				if (obj == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					string text2 = default(string);
					throw text2;
				}
			}
			array2[0] = text;
			string text3 = num.ToString(null, numberFormat);
			if (text3 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rdx_v29 (Il2CppClass<System.Object[]>)+40]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj3 = default(object);
				bool flag = obj3 == null;
				string text4 = text3;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					object obj4 = default(object);
					throw obj4;
				}
			}
			array2[1] = text3;
			string text5 = UnityEngine.UnityString.Format("({0}, {1})", array2);
			if (array.Length > 1)
			{
				array[1] = text5;
				if (array.Length > 2)
				{
					array[2] = "\",\"children\":[";
					Func<NodeTree, string> selector = _003C_003Ec._003C_003E9__15_0;
					if (_003C_003Ec._003C_003E9__15_0 == null)
					{
						selector = (_003C_003Ec._003C_003E9__15_0 = (NodeTree c) => (string)((c != null) ? ((object)c.ToString()) : ((object)new NullReferenceException())));
					}
					IEnumerable<string> values = Enumerable.Select(_003Cchildren_003Ek__BackingField, selector);
					string text6 = string.Join(",", values);
					if (array.Length > 3)
					{
						array[3] = text6;
						if (array.Length > 4)
						{
							array[4] = "]}";
							return string.Concat(array);
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}
}

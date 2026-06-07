using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("At Index")]
	[Category("At Index")]
	[Description("Replaces the list element at a specific position")]
	[Image(typeof(IconListIndex), ColorTheme.Type.Yellow)]
	public class SetPickIndex : TListSetPick
	{
		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		public override int GetIndex(ListVariableRuntime list, int count, Args args)
		{
			return (int)m_Index.Get(args);
		}

		public override int GetIndex(int count, Args args)
		{
			return (int)m_Index.Get(args);
		}

		public override string ToString()
		{
			return m_Index.ToString();
		}
	}
}

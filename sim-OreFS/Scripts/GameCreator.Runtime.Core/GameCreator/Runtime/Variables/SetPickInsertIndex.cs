using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Insert at Index")]
	[Category("Insert at Index")]
	[Description("Inserts a new element at the specified list position")]
	[Image(typeof(IconListIndex), ColorTheme.Type.Blue)]
	public class SetPickInsertIndex : TListSetPick
	{
		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		public override int GetIndex(ListVariableRuntime list, int count, Args args)
		{
			int num = (int)m_Index.Get(args);
			list.Insert(num, null);
			return num;
		}

		public override int GetIndex(int count, Args args)
		{
			return -1;
		}

		public override string ToString()
		{
			return m_Index.ToString();
		}
	}
}

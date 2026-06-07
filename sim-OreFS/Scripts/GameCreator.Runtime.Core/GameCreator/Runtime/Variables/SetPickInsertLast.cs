using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Insert Last Element")]
	[Category("Insert Last Element")]
	[Description("Inserts a new element at the end on the list")]
	[Image(typeof(IconListLast), ColorTheme.Type.Blue)]
	public class SetPickInsertLast : TListSetPick
	{
		public override int GetIndex(ListVariableRuntime list, int count, Args args)
		{
			list.Insert(count, null);
			return count;
		}

		public override int GetIndex(int count, Args args)
		{
			return -1;
		}

		public override string ToString()
		{
			return "Insert Last";
		}
	}
}

using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Insert First Element")]
	[Category("Insert First Element")]
	[Description("Inserts a new element as the first one on the list")]
	[Image(typeof(IconListFirst), ColorTheme.Type.Blue)]
	public class SetPickInsertFirst : TListSetPick
	{
		public override int GetIndex(ListVariableRuntime list, int count, Args args)
		{
			list.Insert(0, null);
			return 0;
		}

		public override int GetIndex(int count, Args args)
		{
			return -1;
		}

		public override string ToString()
		{
			return "Insert First";
		}
	}
}

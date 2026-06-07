using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("First Element")]
	[Category("First Element")]
	[Description("Replaces the element that appears first on the list")]
	[Image(typeof(IconListFirst), ColorTheme.Type.Yellow)]
	public class SetPickFirst : TListSetPick
	{
		public override int GetIndex(ListVariableRuntime list, int count, Args args)
		{
			return 0;
		}

		public override int GetIndex(int count, Args args)
		{
			return 0;
		}

		public override string ToString()
		{
			return "First";
		}
	}
}

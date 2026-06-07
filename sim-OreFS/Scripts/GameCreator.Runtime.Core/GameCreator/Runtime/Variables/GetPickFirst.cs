using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("First Element")]
	[Category("First Element")]
	[Description("Selects the element that appears first on the list")]
	[Image(typeof(IconListFirst), ColorTheme.Type.Yellow)]
	public class GetPickFirst : TListGetPick
	{
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

using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Last Element")]
	[Category("Last Element")]
	[Description("Selects the element that's at the bottom of the list")]
	[Image(typeof(IconListLast), ColorTheme.Type.Yellow)]
	public class GetPickLast : TListGetPick
	{
		public override int GetIndex(int count, Args args)
		{
			return count - 1;
		}

		public override string ToString()
		{
			return "Last";
		}
	}
}

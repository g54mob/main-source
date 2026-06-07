using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("From List")]
	public abstract class TListGetPick : IListGetPick
	{
		public abstract int GetIndex(int count, Args args);
	}
}

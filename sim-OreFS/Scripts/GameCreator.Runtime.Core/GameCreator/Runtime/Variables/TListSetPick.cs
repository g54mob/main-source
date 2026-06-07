using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("From List")]
	public abstract class TListSetPick : IListSetPick
	{
		public abstract int GetIndex(ListVariableRuntime list, int count, Args args);

		public abstract int GetIndex(int count, Args args);
	}
}

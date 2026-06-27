using System;
using Restory.Data.Base;

namespace Restory.Data.Tables.Parameters
{
	[Serializable]
	public class GameEntityTableEntry<T> where T : GameEntityParameters
	{
		public RestoryEntityInfoBase ItemObject;

		public T Parameters;
	}
}

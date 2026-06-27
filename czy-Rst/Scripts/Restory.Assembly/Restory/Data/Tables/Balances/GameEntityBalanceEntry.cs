using System;
using Restory.Data.Base;

namespace Restory.Data.Tables.Balances
{
	[Serializable]
	public class GameEntityBalanceEntry<T> where T : BalanceParametersBase
	{
		public RestoryEntityInfoBase ItemObject;

		public T Parameters;
	}
}

using System;
using Restory.Data.Expenses;

namespace Restory.Gameplay.Statistics
{
	[Serializable]
	public class Expense
	{
		public ExpenseInfo Info;

		public int Sum;
	}
}

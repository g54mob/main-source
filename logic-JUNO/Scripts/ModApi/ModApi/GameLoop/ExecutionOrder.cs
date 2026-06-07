using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ModApi.GameLoop
{
	public static class ExecutionOrder
	{
		public const int BodyScript = -4900;

		public const int CraftScript = -5000;

		public const int PartGroupScript = -4800;

		public const int PartModifierScript = -4600;

		public const int PartScript = -4700;

		private static Dictionary<int, string> _orderNameLookup;

		static ExecutionOrder()
		{
			_orderNameLookup = (from x in typeof(ExecutionOrder).GetFields(BindingFlags.Static | BindingFlags.Public)
				where x.FieldType == typeof(int) && x.IsLiteral && !x.IsInitOnly
				select x).ToDictionary((FieldInfo x) => (int)x.GetRawConstantValue(), (FieldInfo x) => x.Name);
		}

		public static string FindName(int order)
		{
			_orderNameLookup.TryGetValue(order, out var value);
			return value;
		}
	}
}

using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class CyclesProvider : ITestProvider
	{
		public interface ICycle
		{
			int A { get; set; }

			ICycle Cycle { get; set; }

			int B { get; set; }
		}

		public class CycleDerivedA : ICycle
		{
			public int A { get; set; }

			public ICycle Cycle { get; set; }

			public int B { get; set; }
		}

		public class CycleDerivedB : ICycle
		{
			public int A { get; set; }

			public ICycle Cycle { get; set; }

			public int B { get; set; }
		}

		public class Cyclic
		{
		}

		public IEnumerable<TestItem> GetValues()
		{
			CycleDerivedA cycleDerivedA = new CycleDerivedA
			{
				A = 1,
				B = 2
			};
			cycleDerivedA.Cycle = cycleDerivedA;
			yield return new TestItem
			{
				Item = cycleDerivedA,
				ItemStorageType = cycleDerivedA.GetType(),
				Comparer = delegate(object a, object b)
				{
					CycleDerivedA cycleDerivedA2 = (CycleDerivedA)b;
					return cycleDerivedA2.A == 1 && cycleDerivedA2.B == 2 && cycleDerivedA2.Cycle == cycleDerivedA2;
				}
			};
			ICycle cycle = new CycleDerivedA
			{
				A = 1,
				B = 2
			};
			cycle.Cycle = cycle;
			yield return new TestItem
			{
				Item = new ValueHolder<ICycle>(cycle),
				ItemStorageType = typeof(ValueHolder<ICycle>),
				Comparer = delegate(object a, object b)
				{
					ValueHolder<ICycle> valueHolder = (ValueHolder<ICycle>)b;
					return valueHolder.Value.GetType() == typeof(CycleDerivedA) && valueHolder.Value.A == 1 && valueHolder.Value.B == 2 && valueHolder.Value.Cycle == valueHolder.Value;
				}
			};
			ICycle cycle2 = new CycleDerivedA
			{
				A = 1,
				B = 2
			};
			cycle2.Cycle = new CycleDerivedB
			{
				A = 3,
				B = 4
			};
			cycle2.Cycle.Cycle = cycle2;
			yield return new TestItem
			{
				Item = new ValueHolder<ICycle>(cycle2),
				ItemStorageType = typeof(ValueHolder<ICycle>),
				Comparer = delegate(object a, object b)
				{
					ValueHolder<ICycle> valueHolder = (ValueHolder<ICycle>)b;
					return valueHolder.Value.GetType() == typeof(CycleDerivedA) && valueHolder.Value.Cycle.GetType() == typeof(CycleDerivedB) && valueHolder.Value.A == 1 && valueHolder.Value.B == 2 && valueHolder.Value.Cycle.A == 3 && valueHolder.Value.Cycle.B == 4 && valueHolder.Value.Cycle.Cycle == valueHolder.Value;
				}
			};
			Cyclic item = new Cyclic();
			Cyclic item2 = new Cyclic();
			Cyclic item3 = new Cyclic();
			yield return new TestItem
			{
				Item = new List<object> { item, item2, item3, item2, item3, item, item, item, item },
				ItemStorageType = typeof(List<object>),
				Comparer = delegate(object a, object b)
				{
					List<object> list = (List<object>)b;
					object obj = list[0];
					object obj2 = list[1];
					object obj3 = list[2];
					return list[3] == obj2 && list[4] == obj3 && list[5] == obj && list[6] == obj && list[7] == obj && list[8] == obj;
				}
			};
		}
	}
}

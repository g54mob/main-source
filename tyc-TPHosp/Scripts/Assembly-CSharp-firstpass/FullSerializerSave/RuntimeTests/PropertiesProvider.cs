using System;
using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class PropertiesProvider : TestProvider<object>
	{
		public struct PublicGetPublicSet
		{
			public int Value { get; set; }

			public PublicGetPublicSet(int value)
			{
				this = default(PublicGetPublicSet);
				Value = value;
			}
		}

		public struct PrivateGetPublicSet
		{
			[fsProperty]
			public int Value { private get; set; }

			public PrivateGetPublicSet(int value)
			{
				this = default(PrivateGetPublicSet);
				Value = value;
			}

			public static bool Compare(PrivateGetPublicSet a, PrivateGetPublicSet b)
			{
				return a.Value == b.Value;
			}
		}

		public struct PublicGetPrivateSet
		{
			public int Value { get; private set; }

			public PublicGetPrivateSet(int value)
			{
				this = default(PublicGetPrivateSet);
				Value = value;
			}
		}

		public struct PrivateGetPrivateSet
		{
			private int Value { get; set; }

			public PrivateGetPrivateSet(int value)
			{
				this = default(PrivateGetPrivateSet);
				Value = value;
			}

			public bool Verify()
			{
				if (Value != 0)
				{
					throw new Exception("Private autoproperty was deserialized");
				}
				return true;
			}
		}

		public override bool Compare(object before, object after)
		{
			if (before is PublicGetPublicSet publicGetPublicSet)
			{
				PublicGetPublicSet publicGetPublicSet2 = (PublicGetPublicSet)after;
				return publicGetPublicSet.Value == publicGetPublicSet2.Value;
			}
			if (before is object a)
			{
				PrivateGetPublicSet b = (PrivateGetPublicSet)after;
				return PrivateGetPublicSet.Compare((PrivateGetPublicSet)a, b);
			}
			if (before is PublicGetPrivateSet publicGetPrivateSet)
			{
				PublicGetPrivateSet publicGetPrivateSet2 = (PublicGetPrivateSet)after;
				return publicGetPrivateSet.Value == publicGetPrivateSet2.Value;
			}
			if (after is PrivateGetPrivateSet privateGetPrivateSet)
			{
				return privateGetPrivateSet.Verify();
			}
			throw new Exception("Unknown type");
		}

		public override IEnumerable<object> GetValues()
		{
			int i = -1;
			while (i <= 1)
			{
				yield return new PublicGetPublicSet(i);
				yield return new PrivateGetPublicSet(i);
				yield return new PublicGetPrivateSet(i);
				yield return new PrivateGetPrivateSet(i);
				int num = i + 1;
				i = num;
			}
		}
	}
}

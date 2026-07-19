using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace UniHumanoid
{
	public class BvhNode
	{
		public string Name { get; private set; }

		public Single3 Offset { get; private set; }

		public Channel[] Channels { get; private set; }

		public List<BvhNode> Children { get; private set; }

		public BvhNode(string name)
		{
			Name = name;
			Children = new List<BvhNode>();
		}

		public virtual void Parse(StringReader r)
		{
			Offset = ParseOffset(r.ReadLine());
			Channels = ParseChannel(r.ReadLine());
		}

		private static Single3 ParseOffset(string line)
		{
			string[] array = line.Trim().Split();
			if (array[0] != "OFFSET")
			{
				throw new BvhException("OFFSET is not found");
			}
			float[] array2 = (from x in array.Skip(1)
				where !string.IsNullOrEmpty(x)
				select float.Parse(x, CultureInfo.InvariantCulture)).ToArray();
			return new Single3(array2[0], array2[1], array2[2]);
		}

		private static Channel[] ParseChannel(string line)
		{
			string[] array = line.Trim().Split();
			if (array[0] != "CHANNELS")
			{
				throw new BvhException("CHANNELS is not found");
			}
			if (int.Parse(array[1]) + 2 != array.Length)
			{
				throw new BvhException("channel count is not match with split count");
			}
			return (from x in array.Skip(2)
				select (Channel)Enum.Parse(typeof(Channel), x)).ToArray();
		}

		public IEnumerable<BvhNode> Traverse()
		{
			yield return this;
			foreach (BvhNode child in Children)
			{
				foreach (BvhNode item in child.Traverse())
				{
					yield return item;
				}
			}
		}
	}
}

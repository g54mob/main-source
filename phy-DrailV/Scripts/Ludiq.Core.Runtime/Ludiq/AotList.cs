using System.Collections;
using UnityEngine.Scripting;

namespace Ludiq
{
	public sealed class AotList : ArrayList
	{
		public AotList()
		{
		}

		public AotList(int capacity)
			: base(capacity)
		{
		}

		public AotList(ICollection c)
			: base(c)
		{
		}

		[Preserve]
		public static void AotStubs()
		{
			AotList aotList = new AotList();
			aotList.Add(null);
			aotList.Remove(null);
			object obj = aotList[0];
			aotList[0] = null;
			aotList.Contains(null);
			aotList.Clear();
			int count = aotList.Count;
		}
	}
}

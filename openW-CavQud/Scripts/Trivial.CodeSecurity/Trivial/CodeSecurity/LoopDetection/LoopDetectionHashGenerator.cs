using System;
using System.Collections.Generic;

namespace Trivial.CodeSecurity.LoopDetection
{
	public class LoopDetectionHashGenerator
	{
		private Random rand = new Random();

		private HashSet<int> usedHashes = new HashSet<int>();

		public int GetNextHash()
		{
			int num = -1;
			while (num == -1 || usedHashes.Contains(num))
			{
				num = rand.Next();
			}
			return num;
		}
	}
}

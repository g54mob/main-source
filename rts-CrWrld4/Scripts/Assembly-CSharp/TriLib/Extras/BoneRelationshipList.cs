using System;
using System.Collections;
using System.Collections.Generic;

namespace TriLib.Extras
{
	[Serializable]
	public class BoneRelationshipList : IEnumerable<BoneRelationship>, IEnumerable
	{
		private readonly List<BoneRelationship> _relationships;

		public void Add(string humanBone, string boneName, bool optional)
		{
		}

		public IEnumerator<BoneRelationship> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}

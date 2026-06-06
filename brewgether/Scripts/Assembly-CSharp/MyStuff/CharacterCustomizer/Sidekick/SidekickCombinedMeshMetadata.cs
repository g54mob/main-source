using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyStuff.CharacterCustomizer.Sidekick
{
	[DisallowMultipleComponent]
	public class SidekickCombinedMeshMetadata : MonoBehaviour
	{
		[Serializable]
		public struct Range
		{
			public string sourceName;

			public string meshName;

			public string rootName;

			public int startVertex;

			public int vertexCount;
		}

		public List<Range> ranges;

		public SkinnedMeshRenderer combinedRenderer;

		public bool TryGetRange(string sourceNameSubstring, out int start, out int count)
		{
			start = default(int);
			count = default(int);
			return false;
		}

		public string DescribeRanges()
		{
			return null;
		}

		public void Record(List<SkinnedMeshRenderer> partsInCombineOrder)
		{
		}
	}
}

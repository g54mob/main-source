using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace UMA.Timeline
{
	[Serializable]
	public class UmaDnaBehaviour : PlayableBehaviour
	{
		[Serializable]
		public struct DnaTuple
		{
			public string Name;

			[Range(0f, 1f)]
			public float Value;
		}

		public bool rebuildImmediately;

		public List<DnaTuple> dnaValues;
	}
}

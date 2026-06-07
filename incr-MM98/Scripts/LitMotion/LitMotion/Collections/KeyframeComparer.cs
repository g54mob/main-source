using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LitMotion.Collections
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct KeyframeComparer : IComparer<Keyframe>
	{
		public int Compare(Keyframe keyframe1, Keyframe keyframe2)
		{
			return keyframe1.time.CompareTo(keyframe2.time);
		}
	}
}

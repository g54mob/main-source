using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PugColorCyclingData : ScriptableObject
{
	[Flags]
	public enum GeneralFlags
	{
		smoothColorTransitions = 1
	}

	[Flags]
	public enum PatternFlags
	{
		loop = 1
	}

	[Serializable]
	public class Pattern
	{
		public string name;

		public PatternFlags flags = PatternFlags.loop;

		public uint groupMask = 1u;

		public int fps = 10;

		public int frameCount;

		public int[] groupOffsets;

		public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public bool loop => (flags & PatternFlags.loop) != 0;
	}

	public const int MAX_GROUPS = 4;

	public Texture2D masterTexture;

	public uint masterImageCRC32;

	public Texture2D indexedTexture;

	public Texture2D patternTexture;

	public GeneralFlags flags;

	public int groupCount = 4;

	public List<Pattern> patterns = new List<Pattern>();

	public bool smooth => (flags & GeneralFlags.smoothColorTransitions) != 0;
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class FolioSpec : ScriptableObject
{
	public enum Kind
	{
		Deck = 0,
		Chart = 1,
		Sketch = 2
	}

	[Serializable]
	public class PinSpec
	{
		public string id;

		public Rect rect;

		public Sprite sprite;

		public Sprite focusedSprite;

		public Material material;

		public Mesh mesh;

		public bool selectable;
	}

	public Kind kind;

	public Vector2 size;

	public string backSpriteId;

	public List<PinSpec> pinSpecs = new List<PinSpec>();

	public PinSpec FindPinSpec(string id)
	{
		foreach (PinSpec pinSpec in pinSpecs)
		{
			if (pinSpec.id == id)
			{
				return pinSpec;
			}
		}
		return null;
	}
}

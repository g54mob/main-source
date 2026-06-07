using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimClip", menuName = "Anim/SpriteAnimClip")]
public class SpriteAnimClip : SerializedScriptableObject
{
	public ClipType Type;

	public int LoopPoint;

	public float LoopDelay;

	public float FrameRate;

	public Sprite[] Sprites;

	public Sprite this[int i]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int Length => 0;

	public bool DoesLoop()
	{
		return false;
	}

	public float GetLength()
	{
		return 0f;
	}

	public int GetFrameIdxAtPct(float pct)
	{
		return 0;
	}

	public Sprite GetFrameAtPct(float pct)
	{
		return null;
	}
}

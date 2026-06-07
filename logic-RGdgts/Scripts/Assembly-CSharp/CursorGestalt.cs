using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CursorGestalt : ScriptableObject
{
	[HideInInspector]
	public CursorGestaltEnum id;

	public Texture2D atlas;

	public int frameCount;

	public float framesPerSecond;

	public bool loop;

	public Vector2 hotspot;

	private static Dictionary<CursorGestaltEnum, Texture2D[]> cursorsTextures;

	private void SetAsInvalid()
	{
	}

	private Texture2D[] InstantiateTextures()
	{
		return null;
	}

	public Texture2D[] GetTextures()
	{
		return null;
	}
}

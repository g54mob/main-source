using System;
using UnityEngine;

[Serializable]
public class CursorData
{
	public CursorType type;

	public Texture2D texture;

	[Tooltip("Leave at 0,0 for top-left alignment. Set to texture dimensions/2 for center alignment")]
	public Vector2 hotspot = Vector2.zero;

	[Tooltip("If true, hotspot will be set to center of texture")]
	public bool useCenterAlignment;
}

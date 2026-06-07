using MessagePack;
using UnityEngine;

[MessagePackObject(false)]
public class SequelProgressStateDto
{
	[Key(0)]
	public float GameDesign;

	[Key(1)]
	public float Art;

	[Key(2)]
	public float Netcode;

	[Key(3)]
	public float Marketing;

	[Key(4)]
	public float Qa;

	[Key(5)]
	public Vector2 FactorRange;
}

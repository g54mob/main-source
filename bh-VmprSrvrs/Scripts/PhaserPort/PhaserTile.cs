using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaserTile : ArcadeColliderType
{
	public int2 position;

	public int _data;

	private const int cFaceTop = 1;

	private const int cFaceBottom = 2;

	private const int cFaceLeft = 4;

	private const int cFaceRight = 8;

	public const int All = 15;

	public const int None = 0;

	public bool faceLeft
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool faceRight
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool faceTop
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool faceBottom
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool collideLeft
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
	}

	public bool collideRight
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
	}

	public bool collideUp
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
	}

	public bool collideDown
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
	}

	public bool isParent => false;

	public BaseBody body => null;

	public bool isTilemap => false;

	public GameObject gameObject => null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public PhaserTile(int x, int y)
	{
	}

	private bool isTileEmpty(Tilemap tiles, int x, int y, BoundsInt bounds)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool isPhaserTileEmpty(PhaserTile[] tiles, int x, int y, BoundsInt layerBounds, BoundsInt mapBounds)
	{
		return false;
	}

	public void updateTileFaces(PhaserTile[] tiles, BoundsInt layerBounds, BoundsInt mapBounds, bool isInverse)
	{
	}

	public void drawDebug(PhaserTilemap layer)
	{
	}
}

using System.Runtime.CompilerServices;

public struct ArcadeBodyCollision
{
	private const int cup = 1;

	private const int cdown = 2;

	private const int cleft = 4;

	private const int cright = 8;

	public const int All = 15;

	public const int None = 0;

	private int _data;

	public bool none
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

	public bool up
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

	public bool down
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

	public bool left
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

	public bool right
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

	public ArcadeBodyCollision(bool none, bool up, bool down, bool left, bool right)
	{
		_data = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ArcadeBodyCollision(int data = 0)
	{
		_data = 0;
	}
}

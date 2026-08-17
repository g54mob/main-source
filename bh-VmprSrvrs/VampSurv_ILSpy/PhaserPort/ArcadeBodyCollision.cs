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
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return _data == 0;
		}
		set
		{
			int data = 0;
			if (!value)
			{
				data = 15;
			}
			_data = data;
		}
	}

	public bool up
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 1;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 1;
			int num = _data & -2;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool down
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 2;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 2;
			int num = _data & -3;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool left
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 4;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 4;
			int num = _data & -5;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool right
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 8;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 8;
			int num = _data & -9;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public ArcadeBodyCollision(bool none, bool up, bool down, bool left, bool right)
	{
		//IL_000e: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected I4, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected I4, but got Unknown
		object obj = (up ? 1 : 0) | 2;
		object obj2 = (up ? 1 : 0) & -3;
		if (!down)
		{
			obj = obj2;
		}
		object obj3 = obj | 4;
		object obj4 = obj & -5;
		object obj5 = default(object);
		if (obj5 == null)
		{
			obj3 = obj4;
		}
		int data = obj3 | 8;
		int num = obj3 & -9;
		object obj6 = default(object);
		if (obj6 == null)
		{
			data = num;
		}
		_data = data;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void Clear()
	{
		_data = 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public ArcadeBodyCollision(int data = 0)
	{
		_data = data;
	}
}

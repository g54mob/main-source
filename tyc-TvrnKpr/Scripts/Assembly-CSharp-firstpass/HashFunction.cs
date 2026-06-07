public abstract class HashFunction
{
	public abstract uint GetHash(params int[] data);

	public virtual uint GetHash(int data)
	{
		return 0u;
	}

	public virtual uint GetHash(int x, int y)
	{
		return 0u;
	}

	public virtual uint GetHash(int x, int y, int z)
	{
		return 0u;
	}

	public float Value(params int[] data)
	{
		return 0f;
	}

	public float Value(int data)
	{
		return 0f;
	}

	public float Value(int x, int y)
	{
		return 0f;
	}

	public float Value(int x, int y, int z)
	{
		return 0f;
	}

	public int Range(int min, int max, params int[] data)
	{
		return 0;
	}

	public int Range(int min, int max, int data)
	{
		return 0;
	}

	public int Range(int min, int max, int x, int y)
	{
		return 0;
	}

	public int Range(int min, int max, int x, int y, int z)
	{
		return 0;
	}

	public float Range(float min, float max, params int[] data)
	{
		return 0f;
	}

	public float Range(float min, float max, int data)
	{
		return 0f;
	}

	public float Range(float min, float max, int x, int y)
	{
		return 0f;
	}

	public float Range(float min, float max, int x, int y, int z)
	{
		return 0f;
	}
}

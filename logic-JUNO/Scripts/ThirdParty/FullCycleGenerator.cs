using System;
using UnityEngine;

[Serializable]
public class FullCycleGenerator
{
	public int seed;

	public int n;

	public int prime;

	public int curr;

	public bool _bIsSetup;

	public void Setup(int seed, int n)
	{
		this.seed = seed;
		this.n = n;
		prime = GetPrime((int)((float)n * 0.1f));
		if (prime != -1)
		{
			curr = seed % n;
			_bIsSetup = true;
		}
	}

	private static int GetPrime(int n)
	{
		for (int i = n / 3 + 1; i < n; i++)
		{
			if (IsPrime(i) && n % i != 0)
			{
				return i;
			}
		}
		return -1;
	}

	private static bool IsPrime(int n)
	{
		int i = 2;
		for (int num = (int)(Math.Sqrt(n) + 1.0); i < num; i++)
		{
			if (n % i == 0)
			{
				return false;
			}
		}
		return true;
	}

	public int NextInt()
	{
		if (!_bIsSetup)
		{
			Debug.Log("Not Set Up");
			return 0;
		}
		curr = ModuloOfSum(curr, prime, n);
		return curr;
	}

	private static int ModuloOfSum(int a, int b, int m)
	{
		int num = a % m;
		int num2 = b % m;
		return (num + num2) % m;
	}
}

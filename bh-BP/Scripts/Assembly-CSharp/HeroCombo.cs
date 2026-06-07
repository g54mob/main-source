using System;

[Serializable]
public struct HeroCombo
{
	public int Idx1;

	public HeroType H1;

	public int Idx2;

	public HeroType H2;

	public HeroCombo(int idx1, HeroType h1, int idx2, HeroType h2)
	{
		Idx1 = 0;
		H1 = default(HeroType);
		Idx2 = 0;
		H2 = default(HeroType);
	}

	public static bool operator ==(HeroCombo h1, HeroCombo h2)
	{
		return false;
	}

	public static bool operator !=(HeroCombo h1, HeroCombo h2)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override string ToString()
	{
		return null;
	}
}

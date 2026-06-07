using System.Collections.Generic;

public class PhaserGameObjectComparer : IEqualityComparer<PhaserGameObject>
{
	public static PhaserGameObjectComparer Default;

	public bool Equals(PhaserGameObject x, PhaserGameObject y)
	{
		return false;
	}

	public int GetHashCode(PhaserGameObject obj)
	{
		return 0;
	}
}

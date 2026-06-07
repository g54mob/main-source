using UnityEngine;

public struct ScreenRaycastData
{
	public bool Is2D;

	public RaycastHit Hit3D;

	public RaycastHit2D Hit2D;

	public GameObject GameObject
	{
		get
		{
			if (Is2D)
			{
				if (!Hit2D.collider)
				{
					return null;
				}
				return Hit2D.collider.gameObject;
			}
			if (!Hit3D.collider)
			{
				return null;
			}
			return Hit3D.collider.gameObject;
		}
	}
}

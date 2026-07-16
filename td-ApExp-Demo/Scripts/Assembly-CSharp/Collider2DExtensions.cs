using UnityEngine;

public static class Collider2DExtensions
{
	public static float SizeX(this Collider2D collider)
	{
		if (!(collider is BoxCollider2D boxCollider2D))
		{
			if (!(collider is CircleCollider2D circleCollider2D))
			{
				if (!(collider is CapsuleCollider2D capsuleCollider2D))
				{
					if (collider is PolygonCollider2D { bounds: var bounds })
					{
						return bounds.size.x;
					}
					return collider.bounds.size.x;
				}
				return capsuleCollider2D.size.x * Mathf.Abs(capsuleCollider2D.transform.lossyScale.x);
			}
			return circleCollider2D.radius * 2f * Mathf.Abs(circleCollider2D.transform.lossyScale.x);
		}
		return boxCollider2D.size.x * Mathf.Abs(boxCollider2D.transform.lossyScale.x);
	}

	public static float SizeY(this Collider2D collider)
	{
		if (!(collider is BoxCollider2D boxCollider2D))
		{
			if (!(collider is CircleCollider2D circleCollider2D))
			{
				if (!(collider is CapsuleCollider2D capsuleCollider2D))
				{
					if (collider is PolygonCollider2D { bounds: var bounds })
					{
						return bounds.size.y;
					}
					return collider.bounds.size.y;
				}
				return capsuleCollider2D.size.y * Mathf.Abs(capsuleCollider2D.transform.lossyScale.y);
			}
			return circleCollider2D.radius * 2f * Mathf.Abs(circleCollider2D.transform.lossyScale.y);
		}
		return boxCollider2D.size.y * Mathf.Abs(boxCollider2D.transform.lossyScale.y);
	}

	public static void SetSizeX(this Collider2D collider, float sizeX)
	{
		if (!(collider is BoxCollider2D boxCollider2D))
		{
			if (!(collider is CircleCollider2D circleCollider2D))
			{
				if (collider is CapsuleCollider2D capsuleCollider2D)
				{
					capsuleCollider2D.size = new Vector2(sizeX, capsuleCollider2D.size.y);
				}
			}
			else
			{
				circleCollider2D.radius = sizeX;
			}
		}
		else
		{
			boxCollider2D.size = new Vector2(sizeX, boxCollider2D.size.y);
		}
	}

	public static void SetSizeY(this Collider2D collider, float sizeY)
	{
		if (!(collider is BoxCollider2D boxCollider2D))
		{
			if (!(collider is CircleCollider2D circleCollider2D))
			{
				if (collider is CapsuleCollider2D capsuleCollider2D)
				{
					capsuleCollider2D.size = new Vector2(capsuleCollider2D.size.x, sizeY);
				}
			}
			else
			{
				circleCollider2D.radius = sizeY;
			}
		}
		else
		{
			boxCollider2D.size = new Vector2(boxCollider2D.size.x, sizeY);
		}
	}

	public static void SetSize(this Collider2D collider, float sizeX, float sizeY)
	{
		if (!(collider is BoxCollider2D boxCollider2D))
		{
			if (!(collider is CircleCollider2D circleCollider2D))
			{
				if (collider is CapsuleCollider2D capsuleCollider2D)
				{
					capsuleCollider2D.size = new Vector2(sizeX, sizeY);
				}
			}
			else
			{
				circleCollider2D.radius = sizeX;
			}
		}
		else
		{
			boxCollider2D.size = new Vector2(sizeX, sizeY);
		}
	}
}

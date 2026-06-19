using UnityEngine;

public class FollowCursor : MonoBehaviour
{
	[SerializeField]
	public Vector2 _localOffset;

	public bool WorldPosition;

	public virtual void Start()
	{
	}

	public virtual void OnDestroy()
	{
	}

	private void UpdatePosition(Vector2 position)
	{
	}
}

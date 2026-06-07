using System;
using NBT.Tags;
using UnityEngine;

public class Vine : MonoBehaviour
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1
	}

	public int releaseCreeperInterval;

	public int releaseCreeperTimeOff;

	[NonSerialized]
	public VineRoot root;

	public TubeRenderer tubeRenderer;

	private Vector3[] positions;

	private float[] radiuses;

	private float[] health;

	private int updateCount;

	[NonSerialized]
	public Vector2 destination;

	private TARGET_BEHAVIOR _targetBehavior;

	private int growCounter;

	private int DONE_DIST;

	private float RADIUS_SCALE;

	private Vector2 chosenMove;

	private bool doneGrowing;

	private Vector2[] TOP_RIGHT;

	private Vector2[] BOTTOM_RIGHT;

	private Vector2[] BOTTOM_LEFT;

	private Vector2[] TOP_LEFT;

	public TARGET_BEHAVIOR targetBehavior
	{
		get
		{
			return default(TARGET_BEHAVIOR);
		}
		set
		{
		}
	}

	public static Vine CreateVine(Transform parent)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void CalculateDestination()
	{
	}

	private void AddPosition(Vector3 point, float radius)
	{
	}

	private void SetCreeperFlow(int cx, int cy, bool val)
	{
	}

	private void UpdateRadiuses()
	{
	}

	private float GetRadius(int pos, int len)
	{
		return 0f;
	}

	public void GameUpdate()
	{
	}

	private bool CreateNewHeadPoint()
	{
		return false;
	}

	public void Damage(int cx, int cy, float amt)
	{
	}

	private void DeployFootprint(int x, int y, bool deploy)
	{
	}

	private void DestroyPosition(int pos)
	{
	}

	private void DeployPosition(int pos)
	{
	}

	private void RemovePositionsToEnd(int pos)
	{
	}

	public int GetDistanceToRoot(int cx, int cy)
	{
		return 0;
	}

	public void DestroyVine()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}

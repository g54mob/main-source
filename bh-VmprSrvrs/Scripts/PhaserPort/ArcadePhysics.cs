using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArcadePhysics : GameMonoBehaviour
{
	[SerializeField]
	private ArcadeWorldConfig _config;

	private static ArcadePhysics s_instance;

	private static ArcadeWorldConfig s_currentConfig;

	private static PhaserScene s_scene;

	public static World s_world;

	public Factory add;

	private List<BaseBody> _overlapCache;

	private List<BaseBody> _overlapCache2;

	private RBush.RectangularBox searchRect;

	private List<BaseBody> _overlapCircBodyCache;

	private List<BaseBody> _overlapLineBodyCache;

	public static ArcadePhysics Instance => null;

	public static ArcadeWorldConfig Config => null;

	public static PhaserScene scene => null;

	public World world => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Cleanup()
	{
	}

	public List<BaseBody> OverlapRect(float x, float y, float width, float height, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		return null;
	}

	public List<BaseBody> OverlapCirc(float x, float y, float radius, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		return null;
	}

	private bool CircleToCircle(ArcadeCircle a, ArcadeCircle b)
	{
		return false;
	}

	private bool CircleToRectangle(ArcadeCircle circle, ArcadeRect rect)
	{
		return false;
	}

	public List<BaseBody> OverlapLine(float2 lineStart, float2 lineEnd, float lineWidth, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		return null;
	}

	private bool LineToCircle(float2 lineStart, float2 lineEnd, float2 circlePos, float circleRadius)
	{
		return false;
	}

	private bool LineToRectangle(float2 lineStart, float2 lineEnd, ArcadeRect rect)
	{
		return false;
	}

	private int CohenSutherlandCode(ArcadeRect rect, float2 position)
	{
		return 0;
	}

	public PhaserGameObject closest(ArcadeSprite source, ICollection<PhaserGameObject> targets)
	{
		return null;
	}

	public float2 velocityFromAngle(float angle, float speed, ref float2 vec2)
	{
		return default(float2);
	}

	public float2 velocityFromRotation(float rotation, float speed, ref float2 vec2)
	{
		return default(float2);
	}
}

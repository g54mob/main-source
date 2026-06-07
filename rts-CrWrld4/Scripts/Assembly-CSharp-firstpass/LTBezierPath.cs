using UnityEngine;

public class LTBezierPath
{
	public Vector3[] pts;

	public float length;

	public bool orientToPath;

	public bool orientToPath2d;

	private LTBezier[] beziers;

	private float[] lengthRatio;

	private int currentBezier;

	private int previousBezier;

	public float distance => 0f;

	public LTBezierPath()
	{
	}

	public LTBezierPath(Vector3[] pts_)
	{
	}

	public void setPoints(Vector3[] pts_)
	{
	}

	public Vector3 point(float ratio)
	{
		return default(Vector3);
	}

	public void place2d(Transform transform, float ratio)
	{
	}

	public void placeLocal2d(Transform transform, float ratio)
	{
	}

	public void place(Transform transform, float ratio)
	{
	}

	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	public void placeLocal(Transform transform, float ratio)
	{
	}

	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
	}

	public float getRationInOneRange(float ratio)
	{
		return 0f;
	}

	public void gizmoDraw(float t = -1f)
	{
	}
}

using Unity.Mathematics;

public struct ArcadeCircle
{
	public float2 pos;

	public float radius;

	public float x => 0f;

	public float y => 0f;

	public ArcadeCircle(float x, float y, float radius)
	{
		pos = default(float2);
		this.radius = 0f;
	}

	public void setTo(float x, float y, float radius)
	{
	}
}

using Aggro.Core;
using UnityEngine;

public class TestSpring : MonoBehaviour
{
	public float frequency;

	public float ratio;

	public float distance;

	private void Print()
	{
		Spring spring = Spring.Create(frequency, ratio, 1f / 60f);
		float pPos = distance;
		float pVel = 0f;
		spring.Update(0f, ref pPos, ref pVel);
		Debug.Log($"Distance: {pPos:F2} Velocity: {pVel:F2}");
	}
}

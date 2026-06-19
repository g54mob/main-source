using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class RandomOffsetBasedOnWorldPosition : MonoBehaviour
{
	public Vector3 min;

	public Vector3 max;

	private Vector3 _defaultPos;

	private void Awake()
	{
		_defaultPos = base.transform.localPosition;
	}

	private void OnEnable()
	{
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(PugRandom.GetSeedFromVector(EntityMonoBehaviour.ToWorldFromRender(base.transform.position)));
		float3 float5 = new float3(random.NextFloat(min.x, max.x), random.NextFloat(min.y, max.y), random.NextFloat(min.z, max.z));
		base.transform.localPosition = _defaultPos + (Vector3)float5;
	}
}

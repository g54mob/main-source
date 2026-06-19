using Aggro.Core;
using UnityEngine;

public class VFX : EntityBehaviourBase
{
	public bool destroySelf = true;

	public float destroyAfterSeconds = 5f;

	private float _startTime;

	private PoolableEntityReference _me;

	public Transform[] floorTransforms;

	public bool debug { get; set; }

	protected override void OnEntityCreated()
	{
		_startTime = Time.time;
	}

	protected override void OnUpdatePresentation()
	{
		Transform[] array = floorTransforms;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].position = new Vector3(base.transform.position.x, 0.02f, base.transform.position.z);
		}
		if (Time.time - _startTime > destroyAfterSeconds && destroySelf && base.entity.TryGetStruct<PoolableEntityReference>(out var comp))
		{
			comp.Release();
		}
	}
}

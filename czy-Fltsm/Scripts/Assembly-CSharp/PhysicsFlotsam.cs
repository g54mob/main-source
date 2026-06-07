using System.Collections;
using UnityEngine;

public class PhysicsFlotsam : Flotsam
{
	[SerializeField]
	private PhysicsController _physicsController;

	public override bool Initialize(FlotsamProperties properties, int visualPrefabIndex)
	{
		if (!base.Initialize(properties, visualPrefabIndex))
		{
			return false;
		}
		_physicsController.Initialize(base.VisualPrefab.gameObject, base.Properties.PhysicsProperties);
		return true;
	}

	protected override IEnumerator ThrowCoroutine(ThrowProperties throwProperties)
	{
		_physicsController.enabled = false;
		yield return base.ThrowCoroutine(throwProperties);
		_physicsController.enabled = true;
	}

	public override void Activate(Vector3 position)
	{
		base.Activate(position);
		_physicsController.enabled = true;
	}

	public override void Deactivate()
	{
		base.Deactivate();
		_physicsController.enabled = false;
	}
}

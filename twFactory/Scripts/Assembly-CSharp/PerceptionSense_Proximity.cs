using UnityEngine;

public class PerceptionSense_Proximity : PerceptionSense
{
	private SphereCollider proximityCollider;

	public override void InitSense(PerceptionAI perceptionAI)
	{
		base.InitSense(perceptionAI);
		proximityCollider = base.gameObject.AddComponent<SphereCollider>();
		proximityCollider.radius = perceptionAI.ProximityRadius;
		proximityCollider.isTrigger = true;
		perceptionAI.onProximityRadiusChanged += OnProximityRadiusChanged;
	}

	private bool ShouldDetectGameObject(GameObject go)
	{
		TeamComponent component = go.GetComponent<TeamComponent>();
		_ = base.gameObject;
		TeamComponent component2 = perceptionAI.Controller.ControlledCharacter.GetComponent<TeamComponent>();
		if ((bool)component && (bool)component2 && (!perceptionAI.DetectAllies || !component.IsAlly(component2)))
		{
			if (perceptionAI.DetectEnemies)
			{
				return component.IsEnemy(component2);
			}
			return false;
		}
		return true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (ShouldDetectGameObject(other.gameObject))
		{
			CallOnEnterSense(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (ShouldDetectGameObject(other.gameObject))
		{
			CallOnExitSense(other.gameObject);
		}
	}

	private void OnProximityRadiusChanged(float radius)
	{
		proximityCollider.radius = radius;
	}
}

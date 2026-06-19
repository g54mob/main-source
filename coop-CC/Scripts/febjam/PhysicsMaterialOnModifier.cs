using Aggro.Core;
using UnityEngine;

public class PhysicsMaterialOnModifier : EntityBehaviourBase, IModifierAdded
{
	public PhysicMaterial icyMaterial;

	private PhysicMaterial _defaultMaterial;

	protected override void OnEntityCreated()
	{
		if (TryGetComponent<Collider>(out var component))
		{
			_defaultMaterial = component.sharedMaterial;
		}
	}

	public void OnModifierAdded(ModifierBase modifier)
	{
		if ((modifier.flags & ModifierFlags.Icy) != ModifierFlags.None)
		{
			SetPhysicsMaterial(icyMaterial);
		}
		else
		{
			SetPhysicsMaterial(_defaultMaterial);
		}
	}

	private void SetPhysicsMaterial(PhysicMaterial mat)
	{
		if (TryGetComponent<Collider>(out var component))
		{
			component.sharedMaterial = mat;
		}
		else
		{
			Debug.LogWarning("Could not find a collider to put the physics material one!");
		}
	}
}

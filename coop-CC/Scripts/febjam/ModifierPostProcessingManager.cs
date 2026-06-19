using Aggro.Core;
using UnityEngine.Rendering;

public class ModifierPostProcessingManager : EntityBehaviourBase, IModifierAdded
{
	private Volume _volume;

	protected override void OnEntityCreated()
	{
		_volume = GetComponent<Volume>();
		_volume.weight = 0f;
	}

	public void OnModifierAdded(ModifierBase modifier)
	{
		_volume.weight = 1f;
	}
}

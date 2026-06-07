using UnityEngine;

public interface IEffect
{
	void Initialize();

	bool Activate(EffectTrigger trigger, Transform parent, Vector3 localPosition);
}

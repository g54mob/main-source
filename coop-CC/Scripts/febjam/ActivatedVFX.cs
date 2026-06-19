using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class ActivatedVFX : EntityBehaviourBase, IBoxActivated
{
	public GameObject prefab;

	public void ServerBoxActivated(ActivationContext context)
	{
		NetworkAggroManagerBase<VFXManager>.instance.Play(prefab, base.entity.transform.position);
	}
}

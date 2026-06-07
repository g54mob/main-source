using DV;
using DV.Items;
using DV.Utils;
using UnityEngine;

public class CommsJunctionSwitcher : JunctionSwitcher
{
	private int JUNCTION_MAP_LAYER;

	public override bool IgnoreInteractables => true;

	protected override void Awake()
	{
		base.Awake();
		JUNCTION_MAP_LAYER = LayerMask.NameToLayer("Inventory");
	}

	public override void PlayClickAudio(AudioClip clip)
	{
		CommsRadioController.PlayAudioFromRadio(clip, base.transform);
	}

	public override void PlayHoverAudio(AudioClip clip)
	{
		CommsRadioController.PlayAudioFromRadio(clip, base.transform);
	}

	public override bool CheckSpecialHit(RaycastHit hit, int hitLayer, JunctionSwitcherManager.UpdateJunctionControlDelegate callback)
	{
		if (hitLayer != JUNCTION_MAP_LAYER)
		{
			return false;
		}
		JunctionMap componentInParent = hit.collider.GetComponentInParent<JunctionMap>();
		if (componentInParent == null || !componentInParent.JunctionMapUsageAllowed)
		{
			return false;
		}
		Junction junction = componentInParent.JunctionFromPoint(hit.point);
		if (junction != null && SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction))
		{
			return callback(this, junction.RemoteControllable(), indirectlyPointing: true);
		}
		return false;
	}
}

using Pug.Sprite;
using UnityEngine;

public class CookingPot : CraftingBuilding
{
	public ParticleSystem smoke;

	public SpriteRenderer lighEmitter;

	private bool _isActive;

	private static int _fire = SpriteAsset.StringToHash("idle");

	protected override void OnActive()
	{
		base.OnActive();
		smoke.Play();
		lighEmitter.gameObject.SetActive(value: true);
		optionalLightOptimizer.gameObject.SetActive(value: true);
		spriteObjects[1].gameObject.SetActive(value: true);
		spriteObjects[2].gameObject.SetActive(value: true);
		spriteObjects[2].PlayAnimation(_fire);
		optionalLightOptimizer.gameObject.SetActive(value: true);
		_isActive = true;
	}

	protected override void OnInactive()
	{
		base.OnInactive();
		smoke.Stop();
		lighEmitter.gameObject.SetActive(value: false);
		optionalLightOptimizer.gameObject.SetActive(value: false);
		spriteObjects[1].gameObject.SetActive(value: false);
		spriteObjects[2].gameObject.SetActive(value: false);
		optionalLightOptimizer.gameObject.SetActive(value: true);
		_isActive = false;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool active = craftingHandler.GetOutputSlot().objectID != ObjectID.None || _isActive;
		if ((bool)spriteObjects[1])
		{
			spriteObjects[1].gameObject.SetActive(active);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 5);
	}
}

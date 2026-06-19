using Pug.Sprite;
using UnityEngine;

public class CrystalMerchant : NPC
{
	private readonly int m_scanStart = SpriteAsset.StringToHash("scanStart");

	private readonly int m_scanEnd = SpriteAsset.StringToHash("scanEnd");

	private readonly int m_idleEmote = SpriteAsset.StringToHash("putSpearAway");

	public SpriteObject scanner;

	public SpriteObject indirectLight;

	public SpriteObject indirectLightScanner;

	private bool _scannerWasEnabled;

	private bool _scannerShouldBeEnabled;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationStart += OnAnimationStart;
		spriteObjects[0].onAnimationEvent += OnAnimationEvent;
		scanner.onAnimationEnd += OnScannerAnimationEnd;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		SetScannerEnabled(value: false);
	}

	private void OnAnimationStart(int obj)
	{
		MarkScannerShouldBeEnabled(value: false);
	}

	public override void Interact()
	{
		PlayerController player = Manager.main.player;
		if (player != null && EntityUtility.GetComponentData<MerchantCD>(base.entity, base.world).hasNewItems)
		{
			player.playerCommandSystem.ResetMerchantHasNewItems(base.entity);
		}
		base.Interact();
	}

	public override void PlayInteractSound()
	{
		base.PlayInteractSound();
		AudioManager.Sfx(SfxTableID.crystalMerchantInteract, base.transform.position);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		bool flag = lastAnim == m_idleEmote && animID == -601574123;
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return !flag;
		}
		return false;
	}

	private void OnAnimationEvent(int hash)
	{
		if (hash == m_scanStart)
		{
			MarkScannerShouldBeEnabled(value: true);
			scanner.PlayAnimation(m_scanStart, m_spriteObjectOrientationHash);
			PositionScanIndirectLight();
		}
		if (hash == m_scanEnd)
		{
			scanner.PlayAnimation(m_scanEnd, m_spriteObjectOrientationHash);
		}
	}

	private void PositionScanIndirectLight()
	{
		Vector3 vector = ((m_spriteObjectOrientationHash == 595663797) ? Vector3.right : ((m_spriteObjectOrientationHash != 1133833840) ? Vector3.left : Vector3.right));
		indirectLightScanner.transform.localPosition = vector * 0.5f;
	}

	private void OnScannerAnimationEnd(int hash)
	{
		if (hash == m_scanEnd)
		{
			MarkScannerShouldBeEnabled(value: false);
		}
	}

	private void MarkScannerShouldBeEnabled(bool value)
	{
		_scannerShouldBeEnabled = value;
	}

	private void SetScannerEnabled(bool value)
	{
		scanner.enabled = value;
		indirectLightScanner.enabled = value;
		_scannerWasEnabled = value;
		_scannerShouldBeEnabled = value;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (_scannerWasEnabled != _scannerShouldBeEnabled)
		{
			SetScannerEnabled(_scannerShouldBeEnabled);
		}
	}
}

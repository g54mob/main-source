using System;
using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class RobotBossActivatorConsole : Chest
{
	[Serializable]
	public struct CableEntry
	{
		public SpriteObject SO;

		public ParticleSystem smokeFx;
	}

	public Transform bossBody;

	public ParticleSystem BossRevealFx;

	public SpriteObject RobotBossMonitorSO;

	public float smokeDelay = 5f;

	private TimerSimple _cablePopTimer;

	public List<CableEntry> cables;

	[SerializeField]
	private float[] cableTiming = new float[5] { 0.5f, 0.9f, 1.2f, 1.55f, 1.8f };

	private int _cableIndex;

	private static readonly int particlePosition = SpriteAsset.StringToHash("particlePos");

	private bool _wasActivated;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (base.variation != 0)
		{
			return;
		}
		_wasActivated = false;
		RobotBossMonitorSO.StopAnimation();
		spriteObjects[0].StopAnimation();
		bossBody.gameObject.SetActive(value: true);
		_cableIndex = 0;
		_cablePopTimer = new TimerSimple(cableTiming[^1] + 0.5f);
		foreach (CableEntry cable in cables)
		{
			cable.SO.StopAnimation();
			cable.smokeFx.Stop();
			cable.smokeFx.transform.localPosition = new Vector3(0f, 0f, cable.smokeFx.transform.localPosition.z);
		}
	}

	public void OpenInventory()
	{
		if (hasInteractable && base.inventoryHandler != null)
		{
			Manager.main.player.SetActiveInventoryHandler(base.inventoryHandler);
			Manager.ui.OnChestInventoryOpen();
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool num = base.variation == 1;
		if (num && !_wasActivated)
		{
			_wasActivated = true;
			CloseInventory();
			BossRevealFx.Play();
			StartCoroutine(WaitBeforeHide());
			RobotBossMonitorSO.PlayAnimation(238408899);
			_cablePopTimer.Start();
		}
		if (num && _cableIndex < cableTiming.Length && _cablePopTimer.elapsedTime >= cableTiming[_cableIndex])
		{
			CableEntry cableEntry = cables[_cableIndex];
			cableEntry.SO.PlayAnimation(238408899);
			cableEntry.smokeFx.Play();
			_cableIndex++;
		}
		if (!num)
		{
			return;
		}
		int num2 = Mathf.Min(_cableIndex, cables.Count);
		for (int i = 0; i < num2; i++)
		{
			CableEntry cableEntry2 = cables[i];
			SpriteObject sO = cableEntry2.SO;
			ParticleSystem smokeFx = cableEntry2.smokeFx;
			if (!(sO == null) && !(smokeFx == null))
			{
				Vector3 positionalData = sO.GetPositionalData(particlePosition, Space.Self);
				positionalData.z = smokeFx.transform.localPosition.z;
				smokeFx.transform.localPosition = positionalData;
			}
		}
	}

	public void CloseInventory()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && hasInteractable && player.activeInventoryHandler == base.inventoryHandler)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
		}
	}

	private IEnumerator WaitBeforeHide()
	{
		yield return new WaitForSeconds(smokeDelay);
		bossBody.gameObject.SetActive(value: false);
	}
}

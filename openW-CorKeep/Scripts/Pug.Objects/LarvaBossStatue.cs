using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class LarvaBossStatue : CraftingBuilding
{
	public List<SpriteObject> emissiveSOs;

	public Light pointLight;

	public List<Transform> ancientCircuitPlateConnections;

	private bool hasSavedCrystalActivation;

	private bool hasPlayedCrystalActivation;

	[ColorUsage(false, true)]
	public Color emissiveColor = Color.white;

	public override void OnOccupied()
	{
		base.OnOccupied();
		hasSavedCrystalActivation = false;
		int2 int5 = Manager.camera.RenderOrigo.ToInt2();
		foreach (Transform ancientCircuitPlateConnection in ancientCircuitPlateConnections)
		{
			int2 worldPosition = int5 + ancientCircuitPlateConnection.position.RoundToInt2();
			Manager.multiMap.SetHiddenTile(worldPosition, 4, TileType.ancientCircuitPlate, 0);
		}
		bool flag = (hasPlayedCrystalActivation = craftingHandler.inventoryHandler.HasObject(0));
		foreach (SpriteObject emissiveSO in emissiveSOs)
		{
			if (flag)
			{
				emissiveSO.emissiveColor = emissiveColor;
			}
			else
			{
				emissiveSO.emissiveColor = Color.black;
			}
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool flag = craftingHandler.inventoryHandler.HasObject(0);
		pointLight.gameObject.SetActive(flag);
		if (flag && !hasPlayedCrystalActivation)
		{
			StartCoroutine(GlowChange_Coroutine(0f, 1f, 3f));
			hasPlayedCrystalActivation = true;
		}
		if (Manager.ecs.ServerWorld != null && flag && !hasSavedCrystalActivation)
		{
			Manager.saves.SetCrystalActivated(craftingHandler.inventoryHandler.GetObjectData(0).objectID);
			Manager.saves.WriteWorldInfo();
			hasSavedCrystalActivation = true;
		}
	}

	public IEnumerator GlowChange_Coroutine(float StartStrength, float EndStrength, float Duration)
	{
		TimerSimple timer = new TimerSimple(Duration);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			foreach (SpriteObject emissiveSO in emissiveSOs)
			{
				emissiveSO.emissiveColor = Color.Lerp(Color.black, emissiveColor, timer.elapsedRatio);
			}
			yield return null;
		}
	}

	public override void Use()
	{
		Manager.main.player.SetActiveCraftingHandler(craftingHandler);
		Manager.ui.OnPlayerInventoryOpen();
	}
}

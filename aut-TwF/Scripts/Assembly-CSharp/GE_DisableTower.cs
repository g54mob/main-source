using System.Collections.Generic;
using UnityEngine;

public class GE_DisableTower : GameplayEffect
{
	private GE_DisableTowerData disabledTowerData;

	private Tower tower;

	private GameObject disabledVFX;

	protected override void OnInitEffect()
	{
		base.OnInitEffect();
		disabledTowerData = base.EffectData as GE_DisableTowerData;
		tower = base.Owner.GetComponent<Tower>();
		tower.IsEnabled = false;
		if ((bool)disabledTowerData.DisabledVFXPrefab)
		{
			float num = tower.Height + 0.33f;
			Vector3 vector = base.Owner.GetComponent<PlacementComponent>()?.GetCenter() ?? base.Owner.transform.position;
			disabledVFX = Object.Instantiate(disabledTowerData.DisabledVFXPrefab, vector + Vector3.up * num, Quaternion.identity);
		}
		if (!disabledTowerData.DisabledVFXMaterial)
		{
			return;
		}
		foreach (Renderer meshRenderer in FunctionLibrary.GetMeshRenderers(base.Owner.gameObject))
		{
			meshRenderer.sharedMaterials = new List<Material>(meshRenderer.sharedMaterials) { disabledTowerData.DisabledVFXMaterial }.ToArray();
		}
	}

	protected override void OnEndEffect()
	{
		tower.IsEnabled = true;
		Object.Destroy(disabledVFX);
		if (!disabledTowerData.DisabledVFXMaterial)
		{
			return;
		}
		foreach (Renderer meshRenderer in FunctionLibrary.GetMeshRenderers(base.Owner.gameObject))
		{
			List<Material> list = new List<Material>(meshRenderer.sharedMaterials);
			list.Remove(disabledTowerData.DisabledVFXMaterial);
			meshRenderer.sharedMaterials = list.ToArray();
		}
	}
}

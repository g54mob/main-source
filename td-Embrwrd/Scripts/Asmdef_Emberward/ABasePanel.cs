using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public abstract class ABasePanel : MonoBehaviour
{
	[SerializeField]
	[Header("設定資料")]
	protected PanelSettingData settingData;

	[SerializeField]
	[Header("放置砲台的節點")]
	protected Transform node_CannonPlacementPosition;

	[SerializeField]
	[Header("Collider")]
	protected List<Collider> list_Colliders;

	[SerializeField]
	private bool isInitialized;

	protected ABaseCannon connectedCannon;

	private void Reset()
	{
	}

	private void FetchCollider()
	{
	}

	public void Spawn(ABaseTower tower)
	{
	}

	public virtual void SpawnProc()
	{
	}

	public void SetCannon(ABaseCannon cannon)
	{
	}

	public void Despawn()
	{
	}

	protected virtual void DespawnProc()
	{
	}

	public Transform GetCannonPlacementNode()
	{
		return null;
	}

	public List<Collider> GetColliders()
	{
		return null;
	}

	public int GetCost(float multiplier = 1f)
	{
		return 0;
	}
}

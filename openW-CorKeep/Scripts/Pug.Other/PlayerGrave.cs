using System.Collections;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerGrave : EntityMonoBehaviour
{
	public ManagedLight pugLight;

	public SpriteObject shadowSO;

	private Vector3 _srPivotDefaultPosition;

	private int _querySystemTypeIndex;

	protected override void Awake()
	{
		_srPivotDefaultPosition = spriteObjects[0].transform.localPosition;
		_querySystemTypeIndex = TypeManager.GetSystemTypeIndex<PugQuerySystem>();
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (!TryUpdateClaimedByPlayer())
		{
			StartCoroutine(UpdateClaimedByPlayer_Coroutine());
		}
		PugQuerySystem systemBase = (PugQuerySystem)base.world.GetExistingSystemManaged(_querySystemTypeIndex);
		TileAccessor tileAccessor = new TileAccessor(systemBase);
		int2 worldPosition = base.world.EntityManager.GetComponentData<LocalTransform>(base.entity).Position.RoundToInt2();
		if (tileAccessor.GetTop(worldPosition).tileType == TileType.water)
		{
			spriteObjects[0].transform.localPosition = _srPivotDefaultPosition + Vector3.down * 0.3125f;
			shadowSO.enabled = false;
		}
		else
		{
			spriteObjects[0].transform.localPosition = _srPivotDefaultPosition;
			shadowSO.enabled = true;
		}
	}

	private IEnumerator UpdateClaimedByPlayer_Coroutine()
	{
		while (!TryUpdateClaimedByPlayer())
		{
			yield return new WaitForSeconds(0.5f);
		}
	}

	private bool TryUpdateClaimedByPlayer()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		bool flag = IsClaimedByPlayer(player);
		pugLight.gameObject.SetActive(flag);
		spriteObjects[0].emissiveColor = (flag ? Color.white : Color.black);
		return true;
	}
}

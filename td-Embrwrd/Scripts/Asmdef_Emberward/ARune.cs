using UnityEngine;

public abstract class ARune : MonoBehaviour
{
	[SerializeField]
	protected int runeIndex;

	[SerializeField]
	protected Obj_TetrisBlock tetrisBlock;

	private eItemType itemType;

	public int RuneIndex => 0;

	public static ARune AddRuneToBlock(Obj_TetrisBlock block, eItemType itemType)
	{
		return null;
	}

	public void Setup(Obj_TetrisBlock block, int index)
	{
	}

	public void Spawn()
	{
	}

	protected abstract void SpawnProc();

	public void Despawn()
	{
	}

	protected abstract void DespawnProc();

	public void PlacementPreview()
	{
	}

	protected virtual void PlacementPreviewProc()
	{
	}

	protected Vector3 GetRuneBlockLocalPosition(int indexOffset = 0)
	{
		return default(Vector3);
	}

	protected Vector3 GetRuneBlockWorldPosition(int indexOffset = 0)
	{
		return default(Vector3);
	}

	public virtual int GetBlockIndexOnTetris()
	{
		return 0;
	}
}

using MEC;
using UnityEngine;

public class PetObj : MonoBehaviour
{
	public GridSpriteObj SprObj;

	public SpriteRenderer RendShadow;

	protected bool _isMoving;

	protected Vector2 _lastMoveDir;

	public PetBattleInst Inst;

	protected PetInst _metaInst;

	protected CoroutineHandle _updateAnim;

	public virtual void Init(int idx, PetBattleInst p)
	{
	}

	public virtual void RefreshProperties()
	{
	}

	public virtual void InitPlacement(int idx)
	{
	}

	public virtual void Reset()
	{
	}

	protected virtual void MyUpdate()
	{
	}

	public virtual bool IsValidTgt(GridPieceInst p)
	{
		return false;
	}

	public void SetPos(Vector3 pos)
	{
	}

	public virtual void OnGridExpanded()
	{
	}

	public virtual bool ShouldScrollWithBoard()
	{
		return false;
	}
}

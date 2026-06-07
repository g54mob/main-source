using UnityEngine;

public class PlayerCharController : MonoBehaviour
{
	public Animator AnimController;

	public SkinnedMeshRenderer SkinnedMesh;

	public Transform ShootXfm;

	public MeshRenderer MeshColliderViz;

	public Vector2 AnimAimDir;

	private Vector2 _animMoveDir;

	public Transform XfmColBot;

	public Transform XfmColTop;

	public virtual void Init()
	{
	}

	public void RefreshMeshColliderViz()
	{
	}

	public virtual void InitEnding(Material mat)
	{
	}

	public virtual void SetAimDir(Vector2 dir)
	{
	}

	public virtual void SetAnimSpeed(float speed)
	{
	}

	public void SetAimRot(Vector2 dir)
	{
	}

	public void SetMoveDir(Vector2 dir)
	{
	}

	public void LerpToMoveDir(Vector2 dir)
	{
	}

	public void TriggerSpecialAnim(string animName)
	{
	}

	public void SetLobPct(float pct)
	{
	}
}

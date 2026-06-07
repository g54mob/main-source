using System.Collections.Generic;
using FSG.MeshAnimator.ShaderAnimated;
using UnityEngine;

public class EnemyMeshController : MonoBehaviour
{
	public GridPieceType PieceType;

	public LevelType MaterialLvl;

	public MeshRenderer RendPlatform;

	public SkinnedMeshRenderer RendChar;

	public Transform WrapperChar;

	public MeshRenderer SimplifiedChar;

	public Animator AnimController;

	public ShaderMeshAnimator GPUAnimator;

	public bool GPUAnimatorHasSeparatePlatform;

	public int GPUAnimatorCustomIdx;

	public MeshRenderer[] ExtraRends;

	public SkinnedMeshRenderer[] ExtraChars;

	public MeshRenderer[] SimplifiedExtraChars;

	public Animator[] ExtraAnimators;

	public ShaderMeshAnimator[] ExtraGPUAnimators;

	public Vector3 DefaultScale;

	public Transform[] TaggedXfmList;

	public Dictionary<string, Transform> TaggedXfms;

	public Vector3 CustomRot;

	public Vector3 CustomPlacement;

	private bool _isInited;

	private GridPieceType _type;

	private bool _disableMatBlock;

	public void Init(GridPieceInfo pInf)
	{
	}

	public bool ShouldSimplify()
	{
		return false;
	}

	public void SetSharedMat(Material mat)
	{
	}

	public void SetMatBlockDisabled(bool isDisabled)
	{
	}

	public void ApplyMatBlock(MaterialPropertyBlock block)
	{
	}

	public void CopyMatProps(Material copyFrom)
	{
	}

	public void SetAnimSpeed(float speed)
	{
	}

	public void SetCharVisible(bool isVis)
	{
	}
}

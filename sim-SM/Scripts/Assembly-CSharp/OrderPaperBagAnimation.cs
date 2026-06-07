using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class OrderPaperBagAnimation : MonoBehaviour, IPoolable
{
	[SerializeField]
	private SkinnedMeshRenderer m_SkinnedMeshRenderer;

	[SerializeField]
	private MeshRenderer m_OpenStaticMesh;

	[SerializeField]
	private MeshRenderer m_ClosedStaticMesh;

	private Tween m_OpenTween;

	private float m_OpenAnimationTime;

	private Tween m_ScaleTween;

	public void SetIsOpen(bool isOpen)
	{
	}

	private void DisableStaticMesh(bool value)
	{
	}

	private void ToggleStaticMeshValue(bool value)
	{
	}

	private void SetBlendShapeValue(float pNewValue)
	{
	}

	private float GetBlendShapeValue()
	{
		return 0f;
	}

	public void PlayProductMove(Transform item)
	{
	}

	public YieldInstruction WaitForToggleCompletion()
	{
		return null;
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void Scale(float scale)
	{
	}
}

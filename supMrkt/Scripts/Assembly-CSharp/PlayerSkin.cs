using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
	[SerializeField]
	private Transform m_CarryingTransform;

	private Animator m_Animator;

	private PlayerAnimation m_PlayerAnimation;

	private SkinnedMeshRenderer[] m_Renderers;

	[SerializeField]
	private List<IAttachment> m_Attachments;

	public Transform CarryingTransform => null;

	public PlayerAnimation PlayerAnimation => null;

	public IReadOnlyCollection<SkinnedMeshRenderer> Renderers => null;

	private void Awake()
	{
	}

	public void Toggle(bool value)
	{
	}

	public bool TryGetAttachment<T>(uint id, out T attachment) where T : class, IAttachment
	{
		attachment = null;
		return false;
	}

	public bool TryGetAttachment(uint id, out IAttachment attachment)
	{
		attachment = null;
		return false;
	}

	public void ToggleAttachment(uint id, bool value)
	{
	}

	public bool TryGetAttachment(string goName, out IAttachment attachment)
	{
		attachment = null;
		return false;
	}

	public bool TryGetAttachment<T>(out T attachment) where T : class, IAttachment
	{
		attachment = null;
		return false;
	}

	public void ResetWorldY()
	{
	}

	public void ResetLocalY()
	{
	}
}

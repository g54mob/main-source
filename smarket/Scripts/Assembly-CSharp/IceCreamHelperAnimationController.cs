using Photon.Pun;
using UnityEngine;
using Workbench.Wolfsbane.Multiplayer;

public class IceCreamHelperAnimationController : MonoBehaviour
{
	private static readonly int HasConeHash;

	private static readonly int ScoopHash;

	private static readonly int Speed;

	[SerializeField]
	private NetworkedAnimation m_NetworkedAnimation;

	[SerializeField]
	private Animator m_Animator;

	private PhotonView m_PhotonView;

	private void Awake()
	{
	}

	public void SetHasCone(bool value)
	{
	}

	public void PlayScoopAnimation()
	{
	}

	public void SetAnimationSpeed(float value)
	{
	}
}

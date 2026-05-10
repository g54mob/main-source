using System;
using MyBox;
using Photon.Pun;
using UnityEngine;
using Workbench.Wolfsbane.Multiplayer;

public class BaseballBat : MonoBehaviourPun
{
	[SerializeField]
	private NetworkedAnimation networkedAnimation;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private Transform m_BaseballBat;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	private bool m_IsEnabled;

	public Action onBatBought;

	public Action onBatEnabled;

	private PlayerInstance m_OwnerPlayerInstance;

	public bool IsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public PlayerInstance OwnerPlayerInstance => null;

	public void EnableBat()
	{
	}

	public void FakeEnableBat()
	{
	}

	public void DisableBat()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void DisableBatInstant()
	{
	}

	public void FakeDisableBatInstant()
	{
	}

	public void Swing()
	{
	}
}

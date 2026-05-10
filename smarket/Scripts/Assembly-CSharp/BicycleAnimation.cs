using PG;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(BikeController))]
public class BicycleAnimation : MonoBehaviour, IPunObservable
{
	private BikeController m_Bike;

	[SerializeField]
	private float m_AngularSpeed;

	private PhotonView m_PhotonView;

	private NetworkVehicle m_NetworkVehicle;

	[SerializeField]
	private float m_ValueSmoothness;

	private float m_CurrentSmoothnessVelocity;

	[SerializeField]
	private Transform m_PedalContainer;

	private float m_CurSpeed;

	private float m_SmoothSpeed;

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}
}

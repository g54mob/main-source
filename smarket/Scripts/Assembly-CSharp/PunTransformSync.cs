using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PhotonView))]
public class PunTransformSync : MonoBehaviour, IPunObservable
{
	private struct State
	{
		public double time;

		public Vector3 pos;

		public Quaternion rot;

		public Vector3 scl;

		public float animSpeed;
	}

	public bool syncPosition;

	public bool syncRotation;

	public bool syncScale;

	[Range(0.05f, 0.3f)]
	public float interpolationBackTime;

	public float maxTeleportDist;

	public int maxBufferSize;

	private PhotonView _pv;

	private NavMeshAgent _agent;

	private CustomerAnimator _customerAnimator;

	private readonly List<State> _buffer;

	private Vector3 _renderPos;

	private Quaternion _renderRot;

	private Vector3 _renderScl;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}

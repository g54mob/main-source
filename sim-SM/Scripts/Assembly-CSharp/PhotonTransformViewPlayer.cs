using Photon.Pun;
using UnityEngine;

public class PhotonTransformViewPlayer : MonoBehaviourPun, IPunObservable
{
	private float m_Distance;

	private float m_Angle;

	[SerializeField]
	private bool m_SyncEnabled;

	private Vector3 m_Direction;

	private Vector3 m_NetworkPosition;

	private Vector3 m_StoredPosition;

	private Quaternion m_NetworkRotation;

	public bool m_SynchronizePosition;

	public bool m_SynchronizeRotation;

	public bool m_SynchronizeScale;

	[Tooltip("Indicates if localPosition and localRotation should be used. Scale ignores this setting, and always uses localScale to avoid issues with lossyScale.")]
	public bool m_UseLocal;

	private bool m_firstTake;

	public bool SyncEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	private void Reset()
	{
	}

	private void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}

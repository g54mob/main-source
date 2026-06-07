using MyBox;
using Photon.Pun;
using UnityEngine;

public class PhotonTransformViewOptimized : MonoBehaviourPun, IPunObservable
{
	private float m_Distance;

	private float m_Angle;

	private Vector3 m_Direction;

	private Vector3 m_NetworkPosition;

	private Vector3 m_StoredPosition;

	private Quaternion m_NetworkRotation;

	[SerializeField]
	private bool m_SyncEnabled;

	public bool m_SynchronizePosition;

	public bool m_SynchronizeRotation;

	[Tooltip("Indicates if localPosition and localRotation should be used. Scale ignores this setting, and always uses localScale to avoid issues with lossyScale.")]
	public bool m_UseLocal;

	private bool m_firstTake;

	[Range(0f, 0.1f)]
	[SerializeField]
	private float m_SendDelta;

	private Vector3 m_LastPosition;

	private float multiplier;

	private Quaternion lastSentRotation;

	private Coroutine m_ForceCoroutine;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private bool m_IsSendData;

	private bool m_ForceSend;

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

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSyncRequest(string userID)
	{
	}

	[PunRPC]
	public void SyncTransform(Vector3 position, Quaternion rotation)
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

	public void ChangeSendDelta(float newDelta)
	{
	}

	public void ForceSend(float time = 2f)
	{
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}

	private short QuantizeFloatToShort(float value, float multiplier)
	{
		return 0;
	}

	private float DequantizeShortToFloat(short q, float multiplier)
	{
		return 0f;
	}
}

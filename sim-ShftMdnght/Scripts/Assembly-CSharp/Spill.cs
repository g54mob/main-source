using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spill : NetworkBehaviour
{
	public GameObject spillParticle;

	public GameObject spillDecal;

	public Collider col;

	public DecalProjector decalProj;

	private float targScale;

	private bool firstTimeStart = true;

	public float minScale = 1f;

	public float maxScale = 3.5f;

	public bool cantClean;

	private void OnEnable()
	{
		if (!cantClean)
		{
			ReviewsManager.Instance.UpdateHygienePenalty(1);
		}
	}

	private void Start()
	{
		spillDecal.transform.localEulerAngles = new Vector3(-180f, 0f, Random.Range(0, 360));
		float num = Random.Range(minScale, maxScale);
		targScale = num * 0.6f;
		StartCoroutine(GrowBlood());
		base.transform.localScale = new Vector3(num, num, num);
	}

	[Command(requiresAuthority = false)]
	public void Clean()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Spill::Clean()", 1661089412, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActuallyClean()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Spill::ActuallyClean()", -1293220869, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDisable()
	{
		if (!cantClean)
		{
			ReviewsManager.Instance.UpdateHygienePenalty(-1);
		}
	}

	private void ServerActuallyClean()
	{
		Object.Destroy(col);
		spillParticle.SetActive(value: true);
		StartCoroutine(ShrinkBlood());
	}

	private IEnumerator GrowBlood()
	{
		while (true)
		{
			Vector3 size = decalProj.size;
			size.x = Mathf.Lerp(size.x, targScale, Time.deltaTime * 15f);
			size.y = Mathf.Lerp(size.y, targScale, Time.deltaTime * 15f);
			decalProj.size = size;
			if (size.x > targScale - 0.01f)
			{
				break;
			}
			yield return null;
		}
	}

	private IEnumerator ShrinkBlood()
	{
		while (true)
		{
			Vector3 size = decalProj.size;
			size.x = Mathf.Lerp(size.x, 0f, Time.deltaTime * 15f);
			size.y = Mathf.Lerp(size.y, 0f, Time.deltaTime * 15f);
			decalProj.size = size;
			if (size.x < 0.01f && base.isServer)
			{
				break;
			}
			yield return null;
		}
		NetworkServer.Destroy(base.gameObject);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_Clean()
	{
		ActuallyClean();
		ServerActuallyClean();
	}

	protected static void InvokeUserCode_Clean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command Clean called on client.");
		}
		else
		{
			((Spill)obj).UserCode_Clean();
		}
	}

	protected void UserCode_ActuallyClean()
	{
		Object.Destroy(col);
		if (!cantClean && base.isServer)
		{
			StoreManager.Instance.ChangeRevenue("Mopped", 0.2f);
		}
		spillParticle.SetActive(value: true);
		StartCoroutine(ShrinkBlood());
	}

	protected static void InvokeUserCode_ActuallyClean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyClean called on server.");
		}
		else
		{
			((Spill)obj).UserCode_ActuallyClean();
		}
	}

	static Spill()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Spill), "System.Void Spill::Clean()", InvokeUserCode_Clean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Spill), "System.Void Spill::ActuallyClean()", InvokeUserCode_ActuallyClean);
	}
}

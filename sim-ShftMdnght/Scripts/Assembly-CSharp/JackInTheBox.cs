using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class JackInTheBox : Interactable
{
	public Transform box;

	public AudioSource jackInTheBoxAudio;

	public Animator jackInTheBoxAnim;

	public Transform[] jackInTheBoxPositions;

	private float timeRunning;

	public bool paused;

	public bool opened;

	public GameObject marionette;

	public static JackInTheBox Instance { get; private set; }

	private void FixedUpdate()
	{
		if (opened)
		{
			return;
		}
		if (!paused)
		{
			timeRunning += Time.deltaTime;
		}
		if (timeRunning > 37f)
		{
			opened = true;
			jackInTheBoxAnim.SetBool("Open", value: true);
			timeRunning = 37f;
			if (base.isServer)
			{
				NetworkServer.Spawn(Object.Instantiate(marionette, new Vector3(box.transform.position.x, 0f, box.transform.position.z), box.transform.rotation));
			}
		}
		jackInTheBoxAudio.maxDistance = timeRunning * 0.8f;
		if (timeRunning > 29.5f)
		{
			jackInTheBoxAudio.volume = 0.7f;
		}
		else
		{
			jackInTheBoxAudio.volume = 0.001f + timeRunning / 150f;
		}
	}

	[ClientRpc]
	public void FullyUnwindJackInTheBoxRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void JackInTheBox::FullyUnwindJackInTheBoxRpc()", -173532405, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void TeleportBoxRpc(Vector3 newPos, float yEuler, float timeBeforeReappear)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(newPos);
		writer.WriteFloat(yEuler);
		writer.WriteFloat(timeBeforeReappear);
		SendRPCInternal("System.Void JackInTheBox::TeleportBoxRpc(UnityEngine.Vector3,System.Single,System.Single)", 1913972509, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void BoxReappear()
	{
		jackInTheBoxAudio.Stop();
		jackInTheBoxAudio.maxDistance = 0f;
		jackInTheBoxAudio.volume = 0f;
		ChangeInteractableStatus(change: true);
		timeRunning = 0f;
		jackInTheBoxAudio.Play();
		jackInTheBoxAudio.maxDistance = 0f;
		jackInTheBoxAudio.volume = 0f;
		paused = false;
		jackInTheBoxAnim.SetBool("Appear", value: true);
	}

	[ClientRpc]
	public void PauseJackInTheBoxRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void JackInTheBox::PauseJackInTheBoxRpc()", -1684721398, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void UnpauseJackInTheBoxRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void JackInTheBox::UnpauseJackInTheBoxRpc()", 222271137, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Invoke("ResetBox", 3f);
		Instance = this;
	}

	private void ResetBox()
	{
		jackInTheBoxAudio.maxDistance = 0f;
		jackInTheBoxAudio.volume = 0f;
		if (base.isServer)
		{
			int num = Random.Range(0, jackInTheBoxPositions.Length);
			TeleportBoxRpc(jackInTheBoxPositions[num].position, Random.Range(0, 360), Random.Range(10, 20));
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_FullyUnwindJackInTheBoxRpc()
	{
		if (!opened)
		{
			jackInTheBoxAudio.Stop();
			jackInTheBoxAudio.maxDistance = 0f;
			jackInTheBoxAudio.volume = 0f;
			ChangeInteractableStatus(change: false);
			StopLookAt();
			jackInTheBoxAnim.SetBool("Appear", value: false);
			if (base.isServer)
			{
				Invoke("ResetBox", 0.5f);
			}
		}
	}

	protected static void InvokeUserCode_FullyUnwindJackInTheBoxRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FullyUnwindJackInTheBoxRpc called on server.");
		}
		else
		{
			((JackInTheBox)obj).UserCode_FullyUnwindJackInTheBoxRpc();
		}
	}

	protected void UserCode_TeleportBoxRpc__Vector3__Single__Single(Vector3 newPos, float yEuler, float timeBeforeReappear)
	{
		jackInTheBoxAudio.Stop();
		jackInTheBoxAudio.maxDistance = 0f;
		jackInTheBoxAudio.volume = 0f;
		jackInTheBoxAudio.Stop();
		jackInTheBoxAnim.SetBool("Appear", value: false);
		timeRunning = 0f;
		box.position = newPos;
		box.localEulerAngles = new Vector3(0f, yEuler, 0f);
		Invoke("BoxReappear", timeBeforeReappear);
		paused = true;
	}

	protected static void InvokeUserCode_TeleportBoxRpc__Vector3__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TeleportBoxRpc called on server.");
		}
		else
		{
			((JackInTheBox)obj).UserCode_TeleportBoxRpc__Vector3__Single__Single(reader.ReadVector3(), reader.ReadFloat(), reader.ReadFloat());
		}
	}

	protected void UserCode_PauseJackInTheBoxRpc()
	{
		jackInTheBoxAnim.SetBool("Paused", value: true);
		paused = true;
		jackInTheBoxAudio.Pause();
	}

	protected static void InvokeUserCode_PauseJackInTheBoxRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PauseJackInTheBoxRpc called on server.");
		}
		else
		{
			((JackInTheBox)obj).UserCode_PauseJackInTheBoxRpc();
		}
	}

	protected void UserCode_UnpauseJackInTheBoxRpc()
	{
		jackInTheBoxAnim.SetBool("Paused", value: false);
		paused = false;
		jackInTheBoxAudio.UnPause();
	}

	protected static void InvokeUserCode_UnpauseJackInTheBoxRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UnpauseJackInTheBoxRpc called on server.");
		}
		else
		{
			((JackInTheBox)obj).UserCode_UnpauseJackInTheBoxRpc();
		}
	}

	static JackInTheBox()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(JackInTheBox), "System.Void JackInTheBox::FullyUnwindJackInTheBoxRpc()", InvokeUserCode_FullyUnwindJackInTheBoxRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(JackInTheBox), "System.Void JackInTheBox::TeleportBoxRpc(UnityEngine.Vector3,System.Single,System.Single)", InvokeUserCode_TeleportBoxRpc__Vector3__Single__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(JackInTheBox), "System.Void JackInTheBox::PauseJackInTheBoxRpc()", InvokeUserCode_PauseJackInTheBoxRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(JackInTheBox), "System.Void JackInTheBox::UnpauseJackInTheBoxRpc()", InvokeUserCode_UnpauseJackInTheBoxRpc);
	}
}

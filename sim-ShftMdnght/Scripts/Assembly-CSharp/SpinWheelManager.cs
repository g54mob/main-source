using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelManager : NetworkBehaviour
{
	[Header("Spin Settings")]
	public float spinDuration = 4f;

	public float minRotations = 3f;

	public float maxRotations = 6f;

	private bool spinning;

	private float timer;

	private float startY;

	private float targetY;

	public Transform wheel;

	public Transform arrowTip;

	public Transform[] wheelObjects;

	public Animator[] wheelWinIndicator;

	public ParticleSystem winParticle;

	public AudioSource winSfx;

	public GameObject nothingEarnedObj;

	public GameObject coinRigidbody;

	[SerializeField]
	private float maxAngleOffsetDeg = 20f;

	[SerializeField]
	private float minForwardVelocity = 10f;

	[SerializeField]
	private float maxForwardVelocity = 20f;

	public GameObject hatEarnedHint;

	public TextMeshProUGUI hatEarnedText;

	public Image hatEarnedIcon;

	public Sprite[] hatSprites;

	public PlayAudioArray spinSfx;

	private float timeSpinning;

	private float tickTimer;

	public void PressButton()
	{
		if (SaveManager.Instance.tokens >= 5)
		{
			if (base.isServer)
			{
				SpinRpc();
			}
			else
			{
				SpinCmd();
			}
		}
		else
		{
			StoreManager.Instance.SetAlert("Not enough funds.", "red");
		}
	}

	[Command(requiresAuthority = false)]
	private void SpinCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SpinWheelManager::SpinCmd()", -2105469763, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SpinRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SpinWheelManager::SpinRpc()", -2065122514, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SpinRpc(float targY)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(targY);
		SendRPCInternal("System.Void SpinWheelManager::SpinRpc(System.Single)", 1301519603, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CompleteSpin()
	{
		float num = 10000f;
		int num2 = -1;
		for (int i = 0; i < wheelObjects.Length; i++)
		{
			if (Vector3.Distance(arrowTip.position, wheelObjects[i].position) < num)
			{
				num2 = i;
				num = Vector3.Distance(arrowTip.position, wheelObjects[i].position);
			}
		}
		wheelWinIndicator[num2].SetTrigger("Play");
		switch (num2)
		{
		case 0:
		{
			for (int k = 0; k < 10; k++)
			{
				Invoke("SpawnTokenRpc", 0.13f * (float)k);
			}
			winParticle.Play();
			winSfx.Play();
			break;
		}
		case 1:
			nothingEarnedObj.SetActive(value: false);
			nothingEarnedObj.SetActive(value: true);
			break;
		case 2:
			UnlockRandomHat();
			winParticle.Play();
			winSfx.Play();
			break;
		case 3:
			if (base.isServer)
			{
				StoreManager.Instance.ChangeRevenue("Wheel Spin", 10f);
			}
			winParticle.Play();
			winSfx.Play();
			break;
		case 4:
		{
			for (int j = 0; j < 2; j++)
			{
				Invoke("SpawnTokenRpc", 0.13f * (float)j);
			}
			winParticle.Play();
			winSfx.Play();
			break;
		}
		case 5:
			UnlockRandomHat();
			winParticle.Play();
			winSfx.Play();
			break;
		}
	}

	private void UnlockRandomHat()
	{
		if (!base.isServer)
		{
			return;
		}
		List<int> list = new List<int>();
		for (int i = 1; i < 9; i++)
		{
			if (!SaveManager.Instance.customizablesUnlocked.Contains(i))
			{
				list.Add(i);
			}
		}
		if (list.Count < 1)
		{
			NoMoreHatsRpc();
		}
		else
		{
			UnlockRandomHatRpc(list[Random.Range(0, list.Count)]);
		}
	}

	[ClientRpc]
	private void UnlockRandomHatRpc(int hat)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(hat);
		SendRPCInternal("System.Void SpinWheelManager::UnlockRandomHatRpc(System.Int32)", -1945224177, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void NoMoreHatsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SpinWheelManager::NoMoreHatsRpc()", -653452606, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SpawnTokenRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SpinWheelManager::SpawnTokenRpc()", 2115362042, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (!spinning)
		{
			return;
		}
		timer += Time.deltaTime;
		float num = Mathf.Clamp01(timer / spinDuration);
		float t = 1f - Mathf.Pow(1f - num, 4f);
		float y = Mathf.Lerp(startY, targetY, t);
		wheel.localRotation = Quaternion.Euler(0f, y, 0f);
		timeSpinning += Time.deltaTime;
		tickTimer -= Time.deltaTime;
		if (tickTimer <= 0f)
		{
			spinSfx.PlayAudio();
			if (timeSpinning < 0.5f)
			{
				tickTimer = 0.05f;
			}
			else if (timeSpinning < 1f)
			{
				tickTimer = 0.12f;
			}
			else if (timeSpinning < 1.5f)
			{
				tickTimer = 0.21f;
			}
			else if (timeSpinning < 2f)
			{
				tickTimer = 0.35f;
			}
			else if (timeSpinning < 2.5f)
			{
				tickTimer = 0.6f;
			}
			else if (timeSpinning < 3f)
			{
				tickTimer = 0.8f;
			}
			else if (timeSpinning < 3.5f)
			{
				tickTimer = 1f;
			}
			else
			{
				tickTimer = 10f;
			}
		}
		if (num >= 1f)
		{
			spinning = false;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SpinCmd()
	{
		SpinRpc();
	}

	protected static void InvokeUserCode_SpinCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpinCmd called on client.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_SpinCmd();
		}
	}

	protected void UserCode_SpinRpc()
	{
		if (base.isServer && !spinning)
		{
			StoreManager.Instance.ChangeTokenBalance(-5);
			startY = wheel.localEulerAngles.y;
			float num = Random.Range(minRotations, maxRotations);
			float num2 = Random.Range(0f, 360f);
			targetY = startY + num * 360f + num2;
			SpinRpc(targetY);
		}
	}

	protected static void InvokeUserCode_SpinRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpinRpc called on server.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_SpinRpc();
		}
	}

	protected void UserCode_SpinRpc__Single(float targY)
	{
		spinSfx.PlayAudio();
		tickTimer = 0.04f;
		timeSpinning = 0f;
		targetY = targY;
		spinning = true;
		timer = 0f;
		Invoke("CompleteSpin", spinDuration);
	}

	protected static void InvokeUserCode_SpinRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpinRpc called on server.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_SpinRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_UnlockRandomHatRpc__Int32(int hat)
	{
		SaveManager.Instance.customizablesUnlocked.Add(hat);
		hatEarnedText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		hatEarnedText.text = JSONAccess.Instance.GetMiscText("Customizables", hat.ToString());
		hatEarnedIcon.sprite = hatSprites[hat];
		hatEarnedHint.SetActive(value: false);
		hatEarnedHint.SetActive(value: true);
	}

	protected static void InvokeUserCode_UnlockRandomHatRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UnlockRandomHatRpc called on server.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_UnlockRandomHatRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_NoMoreHatsRpc()
	{
		StoreManager.Instance.SetAlert("No more hats to unlock", "red");
	}

	protected static void InvokeUserCode_NoMoreHatsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC NoMoreHatsRpc called on server.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_NoMoreHatsRpc();
		}
	}

	protected void UserCode_SpawnTokenRpc()
	{
		if (ClientPlayer.Instance.isServer)
		{
			Quaternion rotation = winParticle.transform.rotation;
			float angle = Random.Range(0f, maxAngleOffsetDeg);
			Vector3 onUnitSphere = Random.onUnitSphere;
			Quaternion rotation2 = Quaternion.AngleAxis(angle, onUnitSphere) * rotation;
			GameObject gameObject = Object.Instantiate(coinRigidbody, winParticle.transform.position, rotation2);
			NetworkServer.Spawn(gameObject);
			if (gameObject.TryGetComponent<Rigidbody>(out var component))
			{
				component.isKinematic = false;
				float num = Random.Range(minForwardVelocity, maxForwardVelocity);
				component.velocity = gameObject.transform.forward * num;
			}
		}
	}

	protected static void InvokeUserCode_SpawnTokenRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnTokenRpc called on server.");
		}
		else
		{
			((SpinWheelManager)obj).UserCode_SpawnTokenRpc();
		}
	}

	static SpinWheelManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(SpinWheelManager), "System.Void SpinWheelManager::SpinCmd()", InvokeUserCode_SpinCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(SpinWheelManager), "System.Void SpinWheelManager::SpinRpc()", InvokeUserCode_SpinRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(SpinWheelManager), "System.Void SpinWheelManager::SpinRpc(System.Single)", InvokeUserCode_SpinRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(SpinWheelManager), "System.Void SpinWheelManager::UnlockRandomHatRpc(System.Int32)", InvokeUserCode_UnlockRandomHatRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(SpinWheelManager), "System.Void SpinWheelManager::NoMoreHatsRpc()", InvokeUserCode_NoMoreHatsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(SpinWheelManager), "System.Void SpinWheelManager::SpawnTokenRpc()", InvokeUserCode_SpawnTokenRpc);
	}
}

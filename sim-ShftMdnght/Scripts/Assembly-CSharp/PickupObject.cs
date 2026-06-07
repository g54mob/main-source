using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using TMPro;
using UnityEngine;

public class PickupObject : Interactable
{
	public Animator collectAnimator;

	public int objectIndex;

	public Collider col;

	public bool destroyAfterPickup = true;

	public bool turnOffPickup;

	public PlayAudioArray hitSFXArray;

	public LayerMask hitSFXLayers;

	public int amountOfItems;

	public TextMeshProUGUI amountText;

	public TextMeshProUGUI amountText2;

	public bool unableToPickupTwice;

	public float timeBeforeDestroy;

	public float forceThreshold = 2f;

	public float maxForce = 10f;

	public float minVolume = 0.02f;

	public float maxVolume = 0.05f;

	public float maxPitch;

	public float minPitch;

	public AudioSource[] hitAudios;

	private int index;

	public override void Start()
	{
		base.Start();
		if (amountText != null)
		{
			Invoke("LoadAmountText", 0.1f);
			Invoke("LoadAmountText", 0.2f);
			Invoke("LoadAmountText", 0.5f);
		}
	}

	public void ChangeAmountOfItems(int x)
	{
		if (base.isServer)
		{
			ChangeAmountOfItemsRpc(x);
		}
		else
		{
			ChangeAmountOfItemsCmd(x);
		}
	}

	[Command(requiresAuthority = false)]
	public void ChangeAmountOfItemsCmd(int x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(x);
		SendCommandInternal("System.Void PickupObject::ChangeAmountOfItemsCmd(System.Int32)", -1409079164, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ChangeAmountOfItemsRpc(int x)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(x);
		SendRPCInternal("System.Void PickupObject::ChangeAmountOfItemsRpc(System.Int32)", 981849339, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void LoadAmountText()
	{
		int num = amountOfItems;
		if (num == 0)
		{
			num = 15;
		}
		amountText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountText2.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		amountText.text = num.ToString();
		amountText2.text = num.ToString();
	}

	public override void Interact(PlayerManager playerMan)
	{
		if (playerMan.downed)
		{
			return;
		}
		if (objectIndex != -5)
		{
			bool flag = false;
			for (int i = 0; i < playerMan.inventoryMan.maxInventorySlots; i++)
			{
				if (playerMan.inventoryMan.inventoryIds[i] == -1)
				{
					flag = true;
					break;
				}
				if (playerMan.inventoryMan.inventoryAmounts[i] < playerMan.inventoryMan.maxStack[playerMan.inventoryMan.inventoryIds[i]] && playerMan.inventoryMan.inventoryIds[i] == objectIndex)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				StoreManager.Instance.SetAlert("Your inventory is full!", "red");
				return;
			}
		}
		if (base.isServer)
		{
			ActuallyInteract(playerMan);
		}
		else
		{
			InteractCmd(playerMan);
		}
	}

	[Command(requiresAuthority = false)]
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void PickupObject::InteractCmd(PlayerManager)", 1000037050, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void PickupObject::ActuallyInteract(PlayerManager)", 1059330971, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void DestroyAfterTime()
	{
		NetworkServer.Destroy(base.gameObject);
	}

	private void Delete()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (interactable && hitAudios != null && base.isServer && IsInLayerMask(collision.gameObject, hitSFXLayers))
		{
			float magnitude = collision.relativeVelocity.magnitude;
			if (magnitude >= forceThreshold)
			{
				float value = Mathf.Lerp(minVolume, maxVolume, (magnitude - forceThreshold) / (maxForce - forceThreshold));
				value = Mathf.Clamp(value, minVolume, maxVolume);
				PlayAudio(value);
			}
		}
	}

	private bool IsInLayerMask(GameObject obj, LayerMask mask)
	{
		return (mask.value & (1 << obj.layer)) != 0;
	}

	[ClientRpc]
	public void PlayAudio(float volume)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(volume);
		SendRPCInternal("System.Void PickupObject::PlayAudio(System.Single)", -197411009, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeAmountOfItemsCmd__Int32(int x)
	{
		ChangeAmountOfItemsRpc(x);
	}

	protected static void InvokeUserCode_ChangeAmountOfItemsCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeAmountOfItemsCmd called on client.");
		}
		else
		{
			((PickupObject)obj).UserCode_ChangeAmountOfItemsCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_ChangeAmountOfItemsRpc__Int32(int x)
	{
		amountOfItems = x;
	}

	protected static void InvokeUserCode_ChangeAmountOfItemsRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeAmountOfItemsRpc called on server.");
		}
		else
		{
			((PickupObject)obj).UserCode_ChangeAmountOfItemsRpc__Int32(reader.ReadVarInt());
		}
	}

	protected override void UserCode_InteractCmd__PlayerManager(PlayerManager playerMan)
	{
		ActuallyInteract(playerMan);
	}

	protected new static void InvokeUserCode_InteractCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractCmd called on client.");
		}
		else
		{
			((PickupObject)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		if (!interactable || (unableToPickupTwice && playerMan.inventoryMan.holdingIndex == objectIndex))
		{
			return;
		}
		if (interactSFX != null)
		{
			interactSFX.Play();
		}
		if (interactAnim != null)
		{
			interactAnim.SetTrigger("Interact");
		}
		interactEvent.Invoke();
		if (useInteractCooldown)
		{
			global::OutlineFx.OutlineFx[] array = outlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
			Invoke("CanInteract", interactCooldown);
		}
		playerMan.inventoryMan.PickupNewObj(objectIndex, amountOfItems);
		if (collectAnimator != null)
		{
			collectAnimator.enabled = true;
		}
		if (turnOffPickup)
		{
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
			Invoke("Delete", timeBeforeDestroy);
		}
		if (destroyAfterPickup)
		{
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
			Invoke("DestroyAfterTime", timeBeforeDestroy);
		}
		base.StopLookAt();
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((PickupObject)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_PlayAudio__Single(float volume)
	{
		hitAudios[index].pitch = Random.Range(minPitch, maxPitch);
		hitAudios[index].volume = volume;
		hitAudios[index].Play();
		index++;
		if (index >= hitAudios.Length)
		{
			index = 0;
		}
	}

	protected static void InvokeUserCode_PlayAudio__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PlayAudio called on server.");
		}
		else
		{
			((PickupObject)obj).UserCode_PlayAudio__Single(reader.ReadFloat());
		}
	}

	static PickupObject()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PickupObject), "System.Void PickupObject::ChangeAmountOfItemsCmd(System.Int32)", InvokeUserCode_ChangeAmountOfItemsCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PickupObject), "System.Void PickupObject::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PickupObject), "System.Void PickupObject::ChangeAmountOfItemsRpc(System.Int32)", InvokeUserCode_ChangeAmountOfItemsRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PickupObject), "System.Void PickupObject::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(PickupObject), "System.Void PickupObject::PlayAudio(System.Single)", InvokeUserCode_PlayAudio__Single);
	}
}

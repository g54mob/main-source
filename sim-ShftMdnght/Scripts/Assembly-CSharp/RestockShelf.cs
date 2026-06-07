using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.UI;

public class RestockShelf : ConstrictedInteractable
{
	public GameObject newCam;

	public Camera actualCamera;

	public new PlayerManager curPlayerMan;

	private bool interacting;

	public ShelfManager shelfMan;

	public Image exclamationMark;

	[SyncVar]
	public int productsOnShelf;

	public int maxProductsOnShelf;

	public int removeAtStartAmount;

	public bool tutorialShelf;

	public Transform playerPos;

	public int NetworkproductsOnShelf
	{
		get
		{
			return productsOnShelf;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref productsOnShelf, 1uL, null);
		}
	}

	public void Start_()
	{
		ShelfItemManager[] shelfItemManagers = shelfMan.shelfItemManagers;
		for (int i = 0; i < shelfItemManagers.Length; i++)
		{
			shelfItemManagers[i].Start_();
		}
		Invoke("RemoveAtStart", 3f);
		if (tutorialShelf)
		{
			Invoke("CheckIfFullTutorial", 5f);
		}
		Invoke("RecalculateProducts", 0.3f);
		maxProductsOnShelf = 4 * shelfMan.shelfItemManagers.Length;
		InvokeRepeating("AutoUpdateBar", 1f, 2f);
	}

	private void RemoveAtStart()
	{
		if (ClientPlayer.Instance.isServer && removeAtStartAmount != 0 && CurrentDayManager.Instance.curDay == 1)
		{
			Invoke("RemoveSome", 0.1f);
		}
	}

	private void RemoveSome()
	{
		shelfMan.RemoveRandomItems(removeAtStartAmount);
	}

	private void CheckIfFullTutorial()
	{
		if ((float)productsOnShelf / (float)maxProductsOnShelf >= 0.99f)
		{
			TutorialManager.Instance.FinishedShelf();
		}
		else
		{
			Invoke("CheckIfFullTutorial", 2f);
		}
	}

	public void FinishedStocking()
	{
		StoreManager.Instance.SetAlert("Shelf Stocked!", "green");
	}

	[Command(requiresAuthority = false)]
	public void RecalculateProducts()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void RestockShelf::RecalculateProducts()", -683267843, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void AutoUpdateBar()
	{
		if (!shelfMan.gameObject.activeInHierarchy)
		{
			float num = (float)productsOnShelf / (float)maxProductsOnShelf;
			if (num == 1f)
			{
				exclamationMark.gameObject.SetActive(value: false);
				return;
			}
			exclamationMark.gameObject.SetActive(value: true);
			exclamationMark.color = Color.Lerp(Color.red, Color.yellow, num);
		}
	}

	public override void Interact(PlayerManager playerMan)
	{
		ClientPlayer.Instance.playerMan.dontAllowLockCursor = true;
		if (interactable && constrictionAllows)
		{
			playerMan.lookingAtShelf = true;
			interactEvent.Invoke();
			if ((bool)StoreManager.Instance.dialogueTutorialCanv)
			{
				StoreManager.Instance.dialogueTutorialCanv.SetActive(value: false);
			}
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
			base.Interact(playerMan);
			playerMan.canPause = false;
			ClientPlayer.Instance.inventoryMan.PauseUseItem();
			playerMan.thirdPersonMan.ResetAnims();
			curPlayerMan = playerMan;
			base.StopLookAt();
			newCam.SetActive(value: true);
			playerMan.fpsScript.playerCamera.gameObject.SetActive(value: false);
			playerMan.fpsScript.lockMove = true;
			playerMan.fpsScript.lockCam = true;
			shelfMan.inventoryMan = playerMan.inventoryMan;
			curPlayerMan.fpsScript.UnlockCursor();
			CmdSetPosition(playerPos.position);
			actualCamera.transform.position = curPlayerMan.fpsScript.playerCamera.transform.position;
			actualCamera.transform.rotation = curPlayerMan.fpsScript.playerCamera.transform.rotation;
			interacting = true;
			if ((bool)TutorialManager.Instance)
			{
				TutorialManager.Instance.tutorialObjCanvasHolderAsWell.SetActive(value: false);
			}
		}
	}

	[Command]
	private void CmdSetPosition(Vector3 newPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(newPosition);
		SendCommandInternal("System.Void RestockShelf::CmdSetPosition(UnityEngine.Vector3)", 1023531620, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void StopInteract()
	{
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
		}
		if (!curPlayerMan)
		{
			return;
		}
		shelfMan.canvas.SetActive(value: true);
		ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: true);
		}
		else
		{
			ChangeInteractableStatusCmd(change: true);
		}
		if (!(curPlayerMan != ClientPlayer.Instance.playerMan))
		{
			ClientPlayer.Instance.playerMan.lookingAtShelf = false;
			curPlayerMan.Invoke("TurnPauseBackOn", 0.1f);
			ClientPlayer.Instance.inventoryMan.UnpauseUseItem();
			newCam.SetActive(value: false);
			curPlayerMan.fpsScript.playerCamera.gameObject.SetActive(value: true);
			if (!curPlayerMan.dontAllowLockCursor && !curPlayerMan.lookingAtShelf && !curPlayerMan.lookingAtComputer && !curPlayerMan.paused)
			{
				curPlayerMan.fpsScript.lockMove = false;
				curPlayerMan.fpsScript.lockCam = false;
				curPlayerMan.fpsScript.LockCursor();
			}
			interacting = false;
			LookAt();
			AutoUpdateBar();
			if ((bool)TutorialManager.Instance)
			{
				TutorialManager.Instance.tutorialObjCanvasHolderAsWell.SetActive(value: true);
			}
		}
	}

	private void Update()
	{
		if (interacting && Input.GetKeyDown(KeyCode.Escape))
		{
			StopInteract();
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RecalculateProducts()
	{
		NetworkproductsOnShelf = 0;
		ShelfItemManager[] shelfItemManagers = shelfMan.shelfItemManagers;
		foreach (ShelfItemManager shelfItemManager in shelfItemManagers)
		{
			NetworkproductsOnShelf = productsOnShelf + shelfItemManager.products.Count;
		}
		if (productsOnShelf > maxProductsOnShelf)
		{
			NetworkproductsOnShelf = maxProductsOnShelf;
		}
	}

	protected static void InvokeUserCode_RecalculateProducts(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RecalculateProducts called on client.");
		}
		else
		{
			((RestockShelf)obj).UserCode_RecalculateProducts();
		}
	}

	protected void UserCode_CmdSetPosition__Vector3(Vector3 newPosition)
	{
		curPlayerMan.transform.position = newPosition;
	}

	protected static void InvokeUserCode_CmdSetPosition__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPosition called on client.");
		}
		else
		{
			((RestockShelf)obj).UserCode_CmdSetPosition__Vector3(reader.ReadVector3());
		}
	}

	static RestockShelf()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(RestockShelf), "System.Void RestockShelf::RecalculateProducts()", InvokeUserCode_RecalculateProducts, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(RestockShelf), "System.Void RestockShelf::CmdSetPosition(UnityEngine.Vector3)", InvokeUserCode_CmdSetPosition__Vector3, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(productsOnShelf);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(productsOnShelf);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref productsOnShelf, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref productsOnShelf, null, reader.ReadVarInt());
		}
	}
}

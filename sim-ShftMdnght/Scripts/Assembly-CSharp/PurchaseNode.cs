using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseNode : NetworkBehaviour
{
	public float normalCost;

	public float costVariation;

	public GameObject purchased;

	public Button purchaseBTN;

	public float cost;

	public TextMeshProUGUI priceText;

	public bool isUpgradeNode;

	public bool isWeaponNode;

	public int nodeIndex = -1;

	public void Start()
	{
		AttachToFirstAvailableNode();
		base.transform.parent.transform.localPosition = Vector3.zero;
		if (base.isServer)
		{
			cost = (int)(normalCost + Random.Range(0f - costVariation, costVariation));
			SetCost(cost);
		}
		else
		{
			AskForCost();
		}
	}

	[ClientRpc]
	private void SetCost(float cost_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(cost_);
		SendRPCInternal("System.Void PurchaseNode::SetCost(System.Single)", -2051893812, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void AskForCost()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PurchaseNode::AskForCost()", -99364947, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void PurchaseItem(int index)
	{
		if (SaveManager.Instance.money > cost - 0.01f && PurchaseManager.Instance.purchaseQueue.Count <= 8 && !PurchaseManager.Instance.eodBus.activeInHierarchy)
		{
			purchaseBTN.interactable = false;
			purchased.SetActive(value: true);
			if (base.isServer)
			{
				PurchaseItemRpc();
			}
			else
			{
				PurchaseItemCmd();
			}
		}
		PurchaseManager.Instance.PurchaseItem(index, cost);
	}

	[Command(requiresAuthority = false)]
	private void PurchaseItemCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PurchaseNode::PurchaseItemCmd()", -1532439946, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PurchaseItemRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PurchaseNode::PurchaseItemRpc()", 703002857, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void HoverInfo(string item)
	{
		PurchaseManager.Instance.HoverInfo(item);
	}

	public void UnhoverInfo()
	{
		PurchaseManager.Instance.UnhoverInfo();
	}

	public static string ToDollarString(float value)
	{
		return $"${value:0.00}";
	}

	public void AttachToFirstAvailableNode()
	{
		Transform[] nodePositions = PurchaseManager.Instance.nodePositions;
		foreach (Transform transform in nodePositions)
		{
			if (transform.childCount == 0)
			{
				base.transform.parent.transform.SetParent(transform);
				base.transform.parent.transform.localPosition = Vector3.zero;
				base.transform.parent.transform.localRotation = Quaternion.identity;
				break;
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SetCost__Single(float cost_)
	{
		cost = cost_;
		priceText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		priceText.text = ToDollarString(cost);
	}

	protected static void InvokeUserCode_SetCost__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetCost called on server.");
		}
		else
		{
			((PurchaseNode)obj).UserCode_SetCost__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_AskForCost()
	{
		SetCost(cost);
	}

	protected static void InvokeUserCode_AskForCost(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AskForCost called on client.");
		}
		else
		{
			((PurchaseNode)obj).UserCode_AskForCost();
		}
	}

	protected void UserCode_PurchaseItemCmd()
	{
		PurchaseItemRpc();
	}

	protected static void InvokeUserCode_PurchaseItemCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PurchaseItemCmd called on client.");
		}
		else
		{
			((PurchaseNode)obj).UserCode_PurchaseItemCmd();
		}
	}

	protected void UserCode_PurchaseItemRpc()
	{
		if (base.isServer)
		{
			if (isUpgradeNode)
			{
				SaveManager.Instance.storeUpgradesPurchased.Add(nodeIndex);
			}
			else if (isWeaponNode)
			{
				SaveManager.Instance.weaponsPurchased.Add(nodeIndex);
			}
		}
		purchaseBTN.interactable = false;
		purchased.SetActive(value: true);
	}

	protected static void InvokeUserCode_PurchaseItemRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PurchaseItemRpc called on server.");
		}
		else
		{
			((PurchaseNode)obj).UserCode_PurchaseItemRpc();
		}
	}

	static PurchaseNode()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseNode), "System.Void PurchaseNode::AskForCost()", InvokeUserCode_AskForCost, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseNode), "System.Void PurchaseNode::PurchaseItemCmd()", InvokeUserCode_PurchaseItemCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseNode), "System.Void PurchaseNode::SetCost(System.Single)", InvokeUserCode_SetCost__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseNode), "System.Void PurchaseNode::PurchaseItemRpc()", InvokeUserCode_PurchaseItemRpc);
	}
}

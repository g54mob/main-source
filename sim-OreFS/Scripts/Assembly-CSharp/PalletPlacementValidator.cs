using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PalletPlacementValidator : NetworkBehaviour
{
	[Header("Raycast Settings - Köşe ve Kenar Ray'leri")]
	[Tooltip("Geçerli zemin olarak kabul edilecek layer'lar (bu layer'lara çarparsa geçerli)")]
	[SerializeField]
	private LayerMask groundLayers;

	[Tooltip("Raycast'in tamamen görmezden geleceği layer'lar (palet kendisi, oyuncu vb.)")]
	[SerializeField]
	private LayerMask ignoreLayers;

	[Header("Raycast Settings - Merkez Ray (Socket)")]
	[Tooltip("Merkez ray için geçerli zemin layer'ları")]
	[SerializeField]
	private LayerMask centerGroundLayers;

	[Tooltip("Merkez ray için görmezden gelinecek layer'lar")]
	[SerializeField]
	private LayerMask centerIgnoreLayers;

	[Tooltip("Socket layer'ı (socket snap için)")]
	[SerializeField]
	private LayerMask socketLayer;

	[Tooltip("Socket arama yarıçapı (OverlapSphere)")]
	[SerializeField]
	private float socketDetectionRadius = 1f;

	[Header("Raycast Settings - Genel")]
	[Tooltip("Köşe raycast noktalarının merkeze olan mesafesi")]
	[SerializeField]
	private float cornerOffset = 0.4f;

	[Tooltip("Trigger collider'ları nasıl işlenecek")]
	[SerializeField]
	private QueryTriggerInteraction triggerQuery = QueryTriggerInteraction.Ignore;

	[Tooltip("Maksimum ray uzunluğu (referans yükseklik yoksa kullanılır)")]
	[SerializeField]
	private float maxRayLength = 2f;

	[Tooltip("Köşe ray mesafeleri arasındaki maksimum fark (zemin düzlük toleransı)")]
	[SerializeField]
	private float levelTolerance = 0.15f;

	[Header("Reference Height")]
	[SyncVar]
	[SerializeField]
	private float referenceHeight;

	[SyncVar]
	[SerializeField]
	private bool hasReferenceHeight;

	[Header("Debug")]
	[SerializeField]
	private bool showDebugGizmos = true;

	public bool HasReferenceHeight => hasReferenceHeight;

	public float ReferenceHeight => referenceHeight;

	public float NetworkreferenceHeight
	{
		get
		{
			return referenceHeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref referenceHeight, 1uL, null);
		}
	}

	public bool NetworkhasReferenceHeight
	{
		get
		{
			return hasReferenceHeight;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref hasReferenceHeight, 2uL, null);
		}
	}

	public bool CanPlace(out string failReason)
	{
		failReason = string.Empty;
		float maxDistance = maxRayLength;
		Vector3[] raycastWorldPositions = GetRaycastWorldPositions();
		int num = -1 & ~ignoreLayers.value;
		int num2 = -1 & ~centerIgnoreLayers.value;
		float[] array = new float[4];
		for (int i = 0; i < raycastWorldPositions.Length; i++)
		{
			Vector3 origin = raycastWorldPositions[i];
			bool num3 = i == 0;
			bool flag = i >= 1 && i <= 4;
			int layerMask = (num3 ? num2 : num);
			LayerMask layerMask2 = (num3 ? centerGroundLayers : groundLayers);
			if (Physics.Raycast(origin, Vector3.down, out var hitInfo, maxDistance, layerMask, triggerQuery))
			{
				int num4 = 1 << hitInfo.collider.gameObject.layer;
				if ((layerMask2.value & num4) == 0)
				{
					string rayTypeName = GetRayTypeName(i);
					failReason = rayTypeName + " geçersiz zemine çarpıyor: " + LayerMask.LayerToName(hitInfo.collider.gameObject.layer);
					return false;
				}
				if (flag)
				{
					array[i - 1] = hitInfo.distance;
				}
				continue;
			}
			string rayTypeName2 = GetRayTypeName(i);
			failReason = rayTypeName2 + " için zemin bulunamadı";
			return false;
		}
		float num5 = Mathf.Min(array[0], array[1], array[2], array[3]);
		float num6 = Mathf.Max(array[0], array[1], array[2], array[3]) - num5;
		if (num6 > levelTolerance)
		{
			failReason = $"Zemin düz değil (fark: {num6:F2}m, tolerans: {levelTolerance:F2}m)";
			return false;
		}
		return true;
	}

	private string GetRayTypeName(int index)
	{
		return index switch
		{
			0 => "Merkez", 
			1 => "Köşe (Ön-Sol)", 
			2 => "Köşe (Ön-Sağ)", 
			3 => "Köşe (Arka-Sol)", 
			4 => "Köşe (Arka-Sağ)", 
			5 => "Kenar (Ön)", 
			6 => "Kenar (Arka)", 
			7 => "Kenar (Sol)", 
			8 => "Kenar (Sağ)", 
			_ => $"Ara Nokta {index - 8}", 
		};
	}

	[Server]
	public void SaveReferenceHeight()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PalletPlacementValidator::SaveReferenceHeight()' called when server was not active");
			return;
		}
		NetworkreferenceHeight = 0f;
		NetworkhasReferenceHeight = true;
		Debug.Log($"[PalletPlacementValidator] Referans yükseklik kaydedildi: {referenceHeight}");
	}

	[Server]
	public void SetReferenceHeight(float height)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PalletPlacementValidator::SetReferenceHeight(System.Single)' called when server was not active");
			return;
		}
		NetworkreferenceHeight = height;
		NetworkhasReferenceHeight = true;
		Debug.Log($"[PalletPlacementValidator] Referans yükseklik ayarlandı: {referenceHeight}");
	}

	[Server]
	public void ApplyPlacementCorrection()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PalletPlacementValidator::ApplyPlacementCorrection()' called when server was not active");
			return;
		}
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		Quaternion rotation2 = Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f);
		Vector3 position2 = base.transform.position;
		if (hasReferenceHeight)
		{
			position2.y = referenceHeight;
		}
		Debug.Log($"[PalletPlacementValidator] Düzeltme başlıyor - Eski: Pos={position}, Rot={rotation.eulerAngles} | Yeni: Pos={position2}, Rot={rotation2.eulerAngles}");
		base.transform.SetPositionAndRotation(position2, rotation2);
		RpcApplyTransform(position2, rotation2);
		Debug.Log($"[PalletPlacementValidator] Düzeltme uygulandı - Server transform: Pos={base.transform.position}, Rot={base.transform.eulerAngles}");
	}

	[ClientRpc]
	private void RpcApplyTransform(Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendRPCInternal("System.Void PalletPlacementValidator::RpcApplyTransform(UnityEngine.Vector3,UnityEngine.Quaternion)", 1919351751, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ApplySocketSnap(Vector3 position, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PalletPlacementValidator::ApplySocketSnap(UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		base.transform.SetPositionAndRotation(position, rotation);
		RpcApplyTransform(position, rotation);
		Debug.Log($"[PalletPlacementValidator] Socket snap uygulandı - Pos: {position}, Rot: {rotation.eulerAngles}");
	}

	public bool TryGetSocketSnap(out T_Socket socket)
	{
		socket = null;
		Debug.Log($"[PalletPlacementValidator] TryGetSocketSnap başladı - Pos: {base.transform.position}, Radius: {socketDetectionRadius}, SocketLayer: {socketLayer.value}");
		BuildingObject component = GetComponent<BuildingObject>();
		if (component == null)
		{
			Debug.Log("[PalletPlacementValidator] BuildingObject bulunamadı!");
			return false;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, socketDetectionRadius, socketLayer, QueryTriggerInteraction.Collide);
		if (array.Length == 0)
		{
			Debug.Log("[PalletPlacementValidator] OverlapSphere hiçbir socket bulamadı");
			return false;
		}
		Debug.Log($"[PalletPlacementValidator] OverlapSphere {array.Length} collider buldu");
		T_Socket t_Socket = null;
		float num = float.MaxValue;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			T_Socket t_Socket2 = collider.GetComponent<T_Socket>();
			if (t_Socket2 == null)
			{
				t_Socket2 = collider.GetComponentInParent<T_Socket>();
			}
			if (t_Socket2 == null)
			{
				Debug.Log("[PalletPlacementValidator] " + collider.gameObject.name + " üzerinde T_Socket component bulunamadı");
				continue;
			}
			if (t_Socket2.IsOccupied())
			{
				Debug.Log("[PalletPlacementValidator] Socket dolu: " + t_Socket2.gameObject.name);
				continue;
			}
			if (!t_Socket2.CanPlaceBuilding(component.buildingPrefab))
			{
				Debug.Log("[PalletPlacementValidator] Socket bu building türünü desteklemiyor: " + t_Socket2.gameObject.name);
				continue;
			}
			float num2 = Vector3.Distance(base.transform.position, t_Socket2.transform.position);
			if (num2 < num)
			{
				num = num2;
				t_Socket = t_Socket2;
			}
		}
		if (t_Socket != null)
		{
			socket = t_Socket;
			Debug.Log($"[PalletPlacementValidator] Socket bulundu ve uygun: {socket.gameObject.name}, Mesafe: {num:F2}m");
			return true;
		}
		Debug.Log("[PalletPlacementValidator] Uygun socket bulunamadı");
		return false;
	}

	private Vector3[] GetRaycastWorldPositions()
	{
		float num = cornerOffset * 0.5f;
		return new Vector3[17]
		{
			base.transform.position,
			base.transform.TransformPoint(new Vector3(0f - cornerOffset, 0f, cornerOffset)),
			base.transform.TransformPoint(new Vector3(cornerOffset, 0f, cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f - cornerOffset, 0f, 0f - cornerOffset)),
			base.transform.TransformPoint(new Vector3(cornerOffset, 0f, 0f - cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f, 0f, cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f, 0f, 0f - cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f - cornerOffset, 0f, 0f)),
			base.transform.TransformPoint(new Vector3(cornerOffset, 0f, 0f)),
			base.transform.TransformPoint(new Vector3(0f - num, 0f, cornerOffset)),
			base.transform.TransformPoint(new Vector3(num, 0f, cornerOffset)),
			base.transform.TransformPoint(new Vector3(cornerOffset, 0f, num)),
			base.transform.TransformPoint(new Vector3(cornerOffset, 0f, 0f - num)),
			base.transform.TransformPoint(new Vector3(num, 0f, 0f - cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f - num, 0f, 0f - cornerOffset)),
			base.transform.TransformPoint(new Vector3(0f - cornerOffset, 0f, 0f - num)),
			base.transform.TransformPoint(new Vector3(0f - cornerOffset, 0f, num))
		};
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcApplyTransform__Vector3__Quaternion(Vector3 position, Quaternion rotation)
	{
		if (!base.isServer)
		{
			base.transform.SetPositionAndRotation(position, rotation);
		}
		Debug.Log($"[PalletPlacementValidator] RpcApplyTransform - Pos: {position}, Rot: {rotation.eulerAngles}, isServer: {base.isServer}");
	}

	protected static void InvokeUserCode_RpcApplyTransform__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcApplyTransform called on server.");
		}
		else
		{
			((PalletPlacementValidator)obj).UserCode_RpcApplyTransform__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	static PalletPlacementValidator()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(PalletPlacementValidator), "System.Void PalletPlacementValidator::RpcApplyTransform(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcApplyTransform__Vector3__Quaternion);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(referenceHeight);
			writer.WriteBool(hasReferenceHeight);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(referenceHeight);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(hasReferenceHeight);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref referenceHeight, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref hasReferenceHeight, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref referenceHeight, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref hasReferenceHeight, null, reader.ReadBool());
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Generators;
using Digger.Modules.Runtime.Sources;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

[DisallowMultipleComponent]
public class DiggerController : NetworkBehaviour
{
	private struct DigOp
	{
		public Vector3 pos;

		public Vector3 vfxPos;

		public Vector3 vfxRot;

		public byte brush;

		public byte action;

		public float size;

		public float opacity;

		public sbyte textureIndex;

		public bool isFromNodeLayer;
	}

	private enum DigFailReason
	{
		None = 0,
		NotClientOrNoLocalPlayer = 1,
		RaycastMiss = 2,
		TooCloseToLastOp = 3,
		BlockVolumeHit = 4,
		NoEquipments = 5,
		NoActiveItem = 6,
		UnsupportedItemType = 7,
		DiggerMissing = 8,
		ServerRejected_RayInvalid = 9,
		ServerRejected_BlockVolume = 10,
		ServerRejected_OutsideBoundary = 11,
		PlayerOverlap = 12,
		Other = 13
	}

	public static DiggerController Instance;

	[Header("Refs")]
	[SerializeField]
	private Camera rayCamera;

	[SerializeField]
	private LayerMask terrainMask = -1;

	[SerializeField]
	private float rayMaxDistance = 40f;

	[Header("Depth Settings")]
	[Tooltip("How far below the raycast hit point to place the center of the brush.")]
	[Range(0f, 0.5f)]
	public float depth;

	[Tooltip("GameManager üzerinden otomatik çekilir; istersen Inspector'dan da atayabilirsin.")]
	[SerializeField]
	private DiggerMasterRuntime digger;

	[Tooltip("Local player'ın ekipmanı. Boş ise otomatik bulunur.")]
	[SerializeField]
	private T_Equipments localEquipments;

	[Header("Voxel Generator")]
	[Tooltip("DepthLayer VFX/SFX eşlemesi için AdvancedVoxelGenerator SO. DiggerMaster'daki ile aynı olmalı.")]
	[SerializeField]
	private AdvancedVoxelGenerator voxelGenerator;

	[Header("Brush Add Settings")]
	[SerializeField]
	private BrushType addBrush;

	[SerializeField]
	private float addSize;

	[SerializeField]
	private float addOpacity;

	[Header("Brush Dig Settings")]
	[SerializeField]
	private BrushType digBrush;

	[Header("Player Overlap Settings")]
	[Tooltip("Add işlemi sırasında bu layer'daki oyuncularla çakışma kontrolü yapılır.")]
	[SerializeField]
	private LayerMask playerMask;

	[Tooltip("Overlap kontrolü brush size'ının bu oranıyla yapılır (0.8 = %80).")]
	[Range(0.1f, 1f)]
	[SerializeField]
	private float overlapCheckRatio = 0.8f;

	[Header("Boundary Settings")]
	[Tooltip("Kazma işleminin yapılabileceği sınırları tanımlayan collider'lar. Boşsa sınır kontrolü yapılmaz.")]
	[SerializeField]
	private List<Collider> digBoundaries = new List<Collider>();

	[Tooltip("True ise sadece boundary içinde kazılabilir. False ise boundary dışında kazılabilir (ters mantık).")]
	[SerializeField]
	private bool mustBeInsideBoundary = true;

	[Header("Debug")]
	[SerializeField]
	private ActionType action;

	[SerializeField]
	private bool drawGizmos;

	[SerializeField]
	private Color gizmoColor = new Color(1f, 0.6f, 0.2f, 0.35f);

	[SerializeField]
	private bool verboseLogging = true;

	private Vector3 lastSentPos = new Vector3(99999f, 99999f, 99999f);

	private GameManager gameManager;

	private Dictionary<int, AdvancedVoxelGenerator.DepthLayer> _depthLayerCache;

	private void Reset()
	{
		if (!rayCamera)
		{
			rayCamera = Camera.main;
		}
	}

	private void Awake()
	{
		if (!rayCamera)
		{
			rayCamera = Camera.main;
		}
		Instance = this;
		gameManager = GameManager.Instance;
		digger = (digger ? digger : gameManager?.DiggerMasterRuntime);
		BuildDepthLayerCache();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		StartCoroutine(InitWhenReady());
	}

	private IEnumerator InitWhenReady()
	{
		while (!base.isClient || NetworkClient.connection == null || !NetworkClient.connection.isReady)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.15f);
		TryResolveLocalEquipments();
	}

	private void OnDrawGizmosSelected()
	{
		if (drawGizmos)
		{
			Gizmos.color = gizmoColor;
			Gizmos.DrawSphere(lastSentPos, 0.2f);
		}
	}

	private void BuildDepthLayerCache()
	{
		_depthLayerCache = new Dictionary<int, AdvancedVoxelGenerator.DepthLayer>();
		if (voxelGenerator == null || voxelGenerator.depthLayers == null)
		{
			return;
		}
		foreach (AdvancedVoxelGenerator.DepthLayer depthLayer in voxelGenerator.depthLayers)
		{
			if (!_depthLayerCache.ContainsKey(depthLayer.textureIndex))
			{
				_depthLayerCache[depthLayer.textureIndex] = depthLayer;
			}
		}
	}

	public void SetLocalEquipments(T_Equipments eq)
	{
		localEquipments = eq;
	}

	public void TryResolveLocalEquipments()
	{
		if ((bool)localEquipments)
		{
			return;
		}
		if (NetworkClient.active && NetworkClient.localPlayer != null)
		{
			GameObject gameObject = NetworkClient.localPlayer.gameObject;
			localEquipments = gameObject.GetComponent<T_Equipments>();
			if (!localEquipments)
			{
				localEquipments = gameObject.GetComponentInChildren<T_Equipments>(includeInactive: true);
			}
		}
		if (verboseLogging)
		{
			Debug.Log(localEquipments ? "[DiggerController] localEquipments resolved." : "[DiggerController] localEquipments NOT resolved.");
		}
	}

	public void DigAtRayOnce(bool isDig)
	{
		if (!base.isClient || NetworkClient.localPlayer == null)
		{
			LogWhyNotDig(DigFailReason.NotClientOrNoLocalPlayer, "DigAtRayOnce");
			return;
		}
		Ray ray = rayCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out var hitInfo, rayMaxDistance, terrainMask, QueryTriggerInteraction.Ignore))
		{
			int layer = hitInfo.transform.gameObject.layer;
			bool isFromNodeLayer = layer == 7;
			if (layer == 7 || layer == 18)
			{
				gameManager?.localEquipments?.interactionManager?.TryDamageCurrentNodePiece();
				Vector3 worldPos = hitInfo.point + ray.direction.normalized * depth;
				if (isDig)
				{
					action = ActionType.Dig;
				}
				else
				{
					action = ActionType.Add;
					worldPos = hitInfo.point;
					if (layer == 7)
					{
						T_Tool equippedItem = GetEquippedItem();
						if (equippedItem != null && equippedItem.itemType == ItemType.Shovel)
						{
							T_Equipments t_Equipments = GameManager.Instance.localEquipments;
							if (t_Equipments == null || !t_Equipments.HasDirt())
							{
								if (NotificationManager.Instance != null)
								{
									NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NoDirtAvailable"));
								}
								return;
							}
						}
					}
				}
				if (TryRequestDigAt(worldPos, hitInfo.point, -ray.direction, isFromNodeLayer, out var reason))
				{
					GameManager.Instance?.localEquipments?.onHitEvent?.Invoke();
					T_Equipments t_Equipments2 = GameManager.Instance.localEquipments;
					T_Tool equippedItem2 = GetEquippedItem();
					if (!(t_Equipments2 != null) || !(equippedItem2 != null) || (equippedItem2.itemType != ItemType.Shovel && equippedItem2.itemType != ItemType.Pickaxe && equippedItem2.itemType != ItemType.Jackhammer) || layer != 7)
					{
						return;
					}
					bool flag = false;
					if (isDig)
					{
						flag = t_Equipments2.TryAddDirt();
					}
					else if (equippedItem2.itemType == ItemType.Shovel)
					{
						flag = t_Equipments2.TryRemoveDirt();
					}
					if (flag)
					{
						UIManager uImanager = GameManager.Instance.UImanager;
						if (uImanager != null && uImanager.dirtInventoryUI != null)
						{
							uImanager.dirtInventoryUI.ShowTemporary();
						}
					}
				}
				else
				{
					LogWhyNotDig(reason, $"Hit@{hitInfo.point}");
				}
			}
			else
			{
				GameManager.Instance?.localEquipments?.DigableAreaCheck();
			}
		}
		else
		{
			LogWhyNotDig(DigFailReason.RaycastMiss, "Raycast miss");
		}
	}

	private bool TryRequestDigAt(Vector3 worldPos, Vector3 vfxPos, Vector3 vfxRot, bool isFromNodeLayer, out DigFailReason reason)
	{
		reason = DigFailReason.None;
		if (!GetCurrentToolParams(out var size, out var opacity, out var paramReason))
		{
			reason = paramReason;
			return false;
		}
		Vector3 vector = ((NetworkClient.active && NetworkClient.localPlayer != null) ? NetworkClient.localPlayer.transform.position : ((!(rayCamera != null)) ? (worldPos - Vector3.forward) : rayCamera.transform.position));
		Vector3 vector2 = worldPos - vector;
		if (vector2.magnitude > 0.0001f)
		{
			float num = Mathf.Max(0f, size * 0.25f);
			if (num > 0f)
			{
				Vector3 vector3 = worldPos + vector2.normalized * num;
				if (verboseLogging)
				{
					Debug.DrawLine(vector, worldPos, Color.yellow, 0.5f);
					Debug.DrawLine(worldPos, vector3, Color.green, 0.5f);
					Debug.Log($"[DiggerController] Advance dig pos by +{num:0.00}m AWAY from player. NewPos={vector3}");
				}
				worldPos = vector3;
			}
		}
		if (digger == null)
		{
			reason = DigFailReason.DiggerMissing;
			return false;
		}
		if (!ServerBoundaryValidate(worldPos))
		{
			reason = DigFailReason.ServerRejected_OutsideBoundary;
			return false;
		}
		AdvancedVoxelGenerator.DepthLayer depthLayerAtPosition = GetDepthLayerAtPosition(worldPos);
		if (action == ActionType.Dig && depthLayerAtPosition != null && !depthLayerAtPosition.destructible)
		{
			if (isFromNodeLayer && gameManager != null)
			{
				LayerVFX vfxType = (LayerVFX)depthLayerAtPosition.vfxType;
				GameObject pooledObjectByType = gameManager.poolingManager.GetPooledObjectByType(vfxType);
				if (pooledObjectByType != null)
				{
					pooledObjectByType.transform.position = vfxPos;
					Vector3 normalized = (-vfxRot).normalized;
					pooledObjectByType.transform.rotation = Quaternion.FromToRotation(pooledObjectByType.transform.up, normalized) * pooledObjectByType.transform.rotation;
					pooledObjectByType.SetActive(value: true);
				}
				LayerSFX sfxType = (LayerSFX)depthLayerAtPosition.sfxType;
				if (SoundManager.Instance != null)
				{
					SoundManager.Instance.PlaySFXAtPosition(sfxType, vfxPos);
				}
			}
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotDiggable"));
			}
			reason = DigFailReason.Other;
			return false;
		}
		lastSentPos = worldPos;
		sbyte textureIndex = (sbyte)((action != ActionType.Add || !(voxelGenerator != null) || voxelGenerator.depthLayers == null || voxelGenerator.depthLayers.Count <= 0) ? ((depthLayerAtPosition != null) ? ((sbyte)depthLayerAtPosition.textureIndex) : 0) : ((sbyte)voxelGenerator.depthLayers[0].textureIndex));
		DigOp digOp = new DigOp
		{
			pos = worldPos,
			vfxPos = vfxPos,
			vfxRot = vfxRot,
			brush = (byte)digBrush,
			action = (byte)action,
			size = size,
			opacity = Mathf.Clamp01(opacity),
			textureIndex = textureIndex,
			isFromNodeLayer = isFromNodeLayer
		};
		if (action == ActionType.Add)
		{
			digOp.brush = (byte)addBrush;
			digOp.size = addSize;
			digOp.opacity = addOpacity;
			float radius = addSize * overlapCheckRatio;
			if (Physics.OverlapSphere(worldPos, radius, playerMask).Length != 0)
			{
				if (NotificationManager.Instance != null)
				{
					NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_CannotAddDirtPlayerBlocking"));
				}
				reason = DigFailReason.PlayerOverlap;
				return false;
			}
		}
		if (verboseLogging)
		{
			Debug.Log($"[DiggerController] TextureIndex={digOp.textureIndex} for Y={worldPos.y:0.00}");
		}
		if (base.isServer)
		{
			if (verboseLogging)
			{
				Debug.Log($"[DiggerController] Server local apply request @ {worldPos} size={size:0.00} opac={opacity:0.00}");
			}
			Server_RequestDigSingle(digOp);
		}
		else
		{
			if (verboseLogging)
			{
				Debug.Log($"[DiggerController] Cmd RequestDig @ {worldPos} size={size:0.00} opac={opacity:0.00}");
			}
			Cmd_RequestDigSingle(digOp);
		}
		return true;
	}

	private sbyte GetDepthLayerTextureIndex(Vector3 worldPos)
	{
		if (voxelGenerator == null || voxelGenerator.depthLayers == null || voxelGenerator.depthLayers.Count == 0)
		{
			return 0;
		}
		float num = worldPos.y;
		Terrain activeTerrain = Terrain.activeTerrain;
		if (activeTerrain != null)
		{
			num = activeTerrain.SampleHeight(worldPos) + activeTerrain.transform.position.y;
		}
		float depthBelowSurface = Mathf.Max(0f, num - worldPos.y);
		return FindDepthLayerTextureIndex(depthBelowSurface);
	}

	private sbyte FindDepthLayerTextureIndex(float depthBelowSurface)
	{
		AdvancedVoxelGenerator.DepthLayer depthLayer = FindDepthLayer(depthBelowSurface);
		if (depthLayer == null)
		{
			return 0;
		}
		return (sbyte)depthLayer.textureIndex;
	}

	private AdvancedVoxelGenerator.DepthLayer FindDepthLayer(float depthBelowSurface)
	{
		if (voxelGenerator == null || voxelGenerator.depthLayers == null || voxelGenerator.depthLayers.Count == 0)
		{
			return null;
		}
		List<AdvancedVoxelGenerator.DepthLayer> depthLayers = voxelGenerator.depthLayers;
		AdvancedVoxelGenerator.DepthLayer result = depthLayers[0];
		float num = -1f;
		foreach (AdvancedVoxelGenerator.DepthLayer item in depthLayers)
		{
			if (depthBelowSurface >= item.minDepth && item.minDepth > num)
			{
				num = item.minDepth;
				result = item;
			}
		}
		return result;
	}

	private AdvancedVoxelGenerator.DepthLayer GetDepthLayerAtPosition(Vector3 worldPos)
	{
		if (voxelGenerator == null || voxelGenerator.depthLayers == null || voxelGenerator.depthLayers.Count == 0)
		{
			return null;
		}
		float num = worldPos.y;
		Terrain activeTerrain = Terrain.activeTerrain;
		if (activeTerrain != null)
		{
			num = activeTerrain.SampleHeight(worldPos) + activeTerrain.transform.position.y;
		}
		float depthBelowSurface = Mathf.Max(0f, num - worldPos.y);
		return FindDepthLayer(depthBelowSurface);
	}

	private bool GetCurrentToolParams(out float size, out float opacity, out DigFailReason paramReason)
	{
		paramReason = DigFailReason.None;
		size = 1.5f;
		opacity = 1f;
		T_Tool equippedItem = GetEquippedItem();
		if (equippedItem == null)
		{
			paramReason = (localEquipments ? DigFailReason.NoActiveItem : DigFailReason.NoEquipments);
			if (verboseLogging)
			{
				if (paramReason == DigFailReason.NoEquipments)
				{
					Debug.LogWarning("[DiggerController] No T_Equipments found for local player. Call TryResolveLocalEquipments() or SetLocalEquipments().");
				}
				else
				{
					Debug.LogWarning("[DiggerController] No active item on localEquipments.");
				}
			}
			return false;
		}
		ItemType itemType = equippedItem.itemType;
		int levelFromItem = GetLevelFromItem(itemType);
		if (UpgradeManager.Instance == null)
		{
			paramReason = DigFailReason.Other;
			if (verboseLogging)
			{
				Debug.LogWarning("[DiggerController] UpgradeManager not found.");
			}
			return false;
		}
		if (itemType != ItemType.Shovel && itemType != ItemType.Pickaxe && itemType != ItemType.Jackhammer)
		{
			paramReason = DigFailReason.UnsupportedItemType;
			if (verboseLogging)
			{
				Debug.LogWarning($"[DiggerController] Unsupported itemType for digging: {itemType}");
			}
			return false;
		}
		size = UpgradeManager.Instance.GetToolStats(itemType, levelFromItem).size;
		opacity = 1f;
		if (verboseLogging)
		{
			Debug.Log($"[DiggerController] Tool params resolved => type={itemType}, level={levelFromItem}, size={size:0.00}, opacity={opacity:0.00}");
		}
		return true;
	}

	private T_Tool GetEquippedItem()
	{
		if (!localEquipments)
		{
			return null;
		}
		int equippedIndex = localEquipments.equippedIndex;
		if (equippedIndex < 0 || equippedIndex >= localEquipments.localTools.Count)
		{
			return null;
		}
		return localEquipments.localTools[equippedIndex];
	}

	private int GetLevelFromItem(ItemType itemType)
	{
		if (PlayerProgressManager.Instance == null)
		{
			return 1;
		}
		if (action == ActionType.Add)
		{
			return 1;
		}
		return PlayerProgressManager.Instance.GetLevel(itemType);
	}

	private void ApplyOpLocally(DigOp o)
	{
		if (digger == null)
		{
			return;
		}
		bool paintWhileDigging = o.action == 1;
		ModificationParameters parameters = new ModificationParameters
		{
			Position = o.pos,
			Brush = (BrushType)o.brush,
			CustomBrush = null,
			Action = (ActionType)o.action,
			TextureIndex = o.textureIndex,
			Opacity = o.opacity,
			Size = o.size,
			StalagmiteUpsideDown = false,
			OpacityIsTarget = false,
			PaintWhileDigging = paintWhileDigging,
			Callback = null
		};
		digger.ModifyAsyncBuffured(parameters);
		if (o.isFromNodeLayer)
		{
			LayerVFX layerVFX = GetLayerVFX(o.textureIndex);
			GameObject pooledObjectByType = gameManager.poolingManager.GetPooledObjectByType(layerVFX);
			if (pooledObjectByType != null)
			{
				pooledObjectByType.transform.position = new Vector3(o.vfxPos.x, o.vfxPos.y, o.vfxPos.z);
				Vector3 normalized = o.vfxRot.normalized;
				pooledObjectByType.transform.rotation = Quaternion.FromToRotation(pooledObjectByType.transform.up, normalized) * pooledObjectByType.transform.rotation;
				pooledObjectByType.SetActive(value: true);
			}
			LayerSFX layerSFX = GetLayerSFX(o.textureIndex);
			if (SoundManager.Instance != null)
			{
				SoundManager.Instance.PlaySFXAtPosition(layerSFX, o.vfxPos);
			}
		}
	}

	public LayerVFX GetLayerVFX(int textureIndex)
	{
		if (_depthLayerCache != null && _depthLayerCache.TryGetValue(textureIndex, out var value))
		{
			return (LayerVFX)value.vfxType;
		}
		return LayerVFX.None;
	}

	public LayerSFX GetLayerSFX(int textureIndex)
	{
		if (_depthLayerCache != null && _depthLayerCache.TryGetValue(textureIndex, out var value))
		{
			return (LayerSFX)value.sfxType;
		}
		return LayerSFX.None;
	}

	private void LogWhyNotDig(DigFailReason reason, string context)
	{
		if (verboseLogging)
		{
			switch (reason)
			{
			case DigFailReason.NotClientOrNoLocalPlayer:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): Not a client or no local player.");
				break;
			case DigFailReason.RaycastMiss:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): Raycast didn't hit terrainMask.");
				break;
			case DigFailReason.BlockVolumeHit:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): Inside block volume (digBlockLayer).");
				break;
			case DigFailReason.NoEquipments:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): localEquipments is NULL (couldn't resolve from local player).");
				break;
			case DigFailReason.NoActiveItem:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): No active item on localEquipments.");
				break;
			case DigFailReason.UnsupportedItemType:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): Active item type not supported for digging.");
				break;
			case DigFailReason.DiggerMissing:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): digger (DiggerMasterRuntime) is NULL.");
				break;
			case DigFailReason.ServerRejected_RayInvalid:
				Debug.LogWarning("[DiggerController] SERVER REJECT (" + context + "): ServerRayValidate failed.");
				break;
			case DigFailReason.ServerRejected_BlockVolume:
				Debug.LogWarning("[DiggerController] SERVER REJECT (" + context + "): Block volume on server.");
				break;
			case DigFailReason.ServerRejected_OutsideBoundary:
				Debug.LogWarning("[DiggerController] SERVER REJECT (" + context + "): Position is outside dig boundary.");
				break;
			case DigFailReason.PlayerOverlap:
				Debug.LogWarning("[DiggerController] SKIP ADD (" + context + "): Player detected in add area.");
				break;
			default:
				Debug.LogWarning("[DiggerController] SKIP DIG (" + context + "): Other/Unknown.");
				break;
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void Cmd_RequestDigSingle(DigOp opFromClient)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_Cmd_RequestDigSingle__DigOp(opFromClient);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_DiggerController_002FDigOp(writer, opFromClient);
		SendCommandInternal("System.Void DiggerController::Cmd_RequestDigSingle(DiggerController/DigOp)", 1223362025, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void Server_RequestDigSingle(DigOp op)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DiggerController::Server_RequestDigSingle(DiggerController/DigOp)' called when server was not active");
			return;
		}
		float size = op.size;
		float opacity = op.opacity;
		op.size = Mathf.Clamp(op.size, 0.4f, 6f);
		op.opacity = Mathf.Clamp01(op.opacity);
		op.textureIndex = (sbyte)Mathf.Clamp(op.textureIndex, -1, 7);
		if (!ServerRayValidate(op.pos) && verboseLogging)
		{
			Debug.LogWarning($"[DiggerController][SERVER] Reject: ServerRayValidate failed @ {op.pos}");
		}
		if (!ServerBoundaryValidate(op.pos))
		{
			if (verboseLogging)
			{
				Debug.LogWarning($"[DiggerController][SERVER] Reject: Outside dig boundary @ {op.pos}");
			}
			return;
		}
		if (verboseLogging)
		{
			Debug.Log($"[DiggerController][SERVER] Accept dig @ {op.pos} size {size:0.00}->{op.size:0.00}, opacity {opacity:0.00}->{op.opacity:0.00}");
		}
		ApplyOpLocally(op);
		if (DiggerReplayMessenger.Instance != null)
		{
			DiggerReplayMessenger.Instance.ServerAppendOp(DigOpToReplayOp(op));
		}
		Rpc_ApplyOp(op);
	}

	private static DiggerReplayMessenger.ReplayOp DigOpToReplayOp(DigOp op)
	{
		return new DiggerReplayMessenger.ReplayOp
		{
			pos = op.pos,
			vfxPos = op.vfxPos,
			vfxRot = op.vfxRot,
			brush = op.brush,
			action = op.action,
			size = op.size,
			opacity = op.opacity,
			textureIndex = op.textureIndex
		};
	}

	private bool ServerRayValidate(Vector3 worldPos)
	{
		try
		{
			if (Physics.Raycast(worldPos + Vector3.up * 10f, Vector3.down, out var _, 20f, terrainMask, QueryTriggerInteraction.Ignore))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			Debug.LogError($"[DiggerController] ServerRayValidate exception @ {worldPos}: {ex.Message}");
			return false;
		}
	}

	public bool IsInsideDigBoundary(Vector3 worldPos)
	{
		if (digBoundaries == null || digBoundaries.Count == 0)
		{
			return true;
		}
		foreach (Collider digBoundary in digBoundaries)
		{
			if (!(digBoundary == null) && Vector3.SqrMagnitude(digBoundary.ClosestPoint(worldPos) - worldPos) < 0.0001f)
			{
				return true;
			}
		}
		return false;
	}

	private bool ServerBoundaryValidate(Vector3 worldPos)
	{
		bool flag = IsInsideDigBoundary(worldPos);
		if (!mustBeInsideBoundary)
		{
			return !flag;
		}
		return flag;
	}

	[ClientRpc]
	private void Rpc_ApplyOp(DigOp op)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_DiggerController_002FDigOp(writer, op);
		SendRPCInternal("System.Void DiggerController::Rpc_ApplyOp(DiggerController/DigOp)", -2050158488, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerDigAtPosition(Vector3 worldPos, float size, float opacity, bool uniformIntensity = false)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DiggerController::ServerDigAtPosition(UnityEngine.Vector3,System.Single,System.Single,System.Boolean)' called when server was not active");
			return;
		}
		if (digger == null)
		{
			Debug.LogWarning("[DiggerController] ServerDigAtPosition: digger is null!");
			return;
		}
		if (!ServerBoundaryValidate(worldPos))
		{
			if (verboseLogging)
			{
				Debug.LogWarning($"[DiggerController] ServerDigAtPosition rejected: Outside dig boundary @ {worldPos}");
			}
			return;
		}
		AdvancedVoxelGenerator.DepthLayer depthLayerAtPosition = GetDepthLayerAtPosition(worldPos);
		if (depthLayerAtPosition != null && !depthLayerAtPosition.destructible)
		{
			if (verboseLogging)
			{
				Debug.Log($"[DiggerController] ServerDigAtPosition rejected: Indestructible layer @ {worldPos}");
			}
			return;
		}
		DigOp digOp = new DigOp
		{
			pos = worldPos,
			vfxPos = worldPos,
			vfxRot = Vector3.up,
			brush = (byte)digBrush,
			action = 0,
			size = Mathf.Clamp(size, 0.4f, 6f),
			opacity = Mathf.Clamp01(opacity),
			textureIndex = (sbyte)((depthLayerAtPosition != null) ? ((sbyte)depthLayerAtPosition.textureIndex) : 0),
			isFromNodeLayer = false
		};
		if (verboseLogging)
		{
			Debug.Log($"[DiggerController] ServerDigAtPosition @ {worldPos} size={size:0.00} opacity={opacity:0.00}");
		}
		ApplyOpLocally(digOp);
		if (DiggerReplayMessenger.Instance != null)
		{
			DiggerReplayMessenger.Instance.ServerAppendOp(DigOpToReplayOp(digOp));
		}
		Rpc_ApplyOp(digOp);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_Cmd_RequestDigSingle__DigOp(DigOp opFromClient)
	{
		if (verboseLogging)
		{
			Debug.Log($"[DiggerController] Cmd_RequestDigSingle from client: pos={opFromClient.pos}, size={opFromClient.size:0.00}, opac={opFromClient.opacity:0.00}");
		}
		Server_RequestDigSingle(opFromClient);
	}

	protected static void InvokeUserCode_Cmd_RequestDigSingle__DigOp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command Cmd_RequestDigSingle called on client.");
		}
		else
		{
			((DiggerController)obj).UserCode_Cmd_RequestDigSingle__DigOp(GeneratedNetworkCode._Read_DiggerController_002FDigOp(reader));
		}
	}

	protected void UserCode_Rpc_ApplyOp__DigOp(DigOp op)
	{
		if (!base.isServer)
		{
			ApplyOpLocally(op);
		}
	}

	protected static void InvokeUserCode_Rpc_ApplyOp__DigOp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC Rpc_ApplyOp called on server.");
		}
		else
		{
			((DiggerController)obj).UserCode_Rpc_ApplyOp__DigOp(GeneratedNetworkCode._Read_DiggerController_002FDigOp(reader));
		}
	}

	static DiggerController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DiggerController), "System.Void DiggerController::Cmd_RequestDigSingle(DiggerController/DigOp)", InvokeUserCode_Cmd_RequestDigSingle__DigOp, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DiggerController), "System.Void DiggerController::Rpc_ApplyOp(DiggerController/DigOp)", InvokeUserCode_Rpc_ApplyOp__DigOp);
	}
}

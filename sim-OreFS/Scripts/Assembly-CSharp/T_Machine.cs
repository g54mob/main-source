using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class T_Machine : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class MachineSaveData
	{
		public List<ItemStackData> storedItems = new List<ItemStackData>();

		public int selectedRecipeIndex = -1;

		public bool isProductionPaused = true;

		public int productionAmount;

		public bool isInfiniteMode;
	}

	[Serializable]
	public class ItemStackData
	{
		public string itemId;

		public int count;

		public ItemStackData()
		{
		}

		public ItemStackData(string id, int c)
		{
			itemId = id;
			count = c;
		}
	}

	private BuildingObject _buildingObject;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	[Header("Machine Settings")]
	[Tooltip("Building ScriptableObject")]
	[SerializeField]
	private T_BuildingItemSO BuildingItemSO;

	[SerializeField]
	private List<T_ItemSO> acceptedRecipes = new List<T_ItemSO>();

	[Header("Storage")]
	[SyncVar(hook = "OnSelectedRecipeChanged")]
	public int selectedRecipeIndex = -1;

	[SyncVar(hook = "OnSelectedRecipeProductItemIdChanged")]
	private string selectedRecipeProductItemId = string.Empty;

	private SyncList<ItemStack> storedItems = new SyncList<ItemStack>();

	[Header("Storage Limits")]
	private int maxItemCount = 2000;

	[Header("Production")]
	[SyncVar(hook = "OnProductionStateChanged")]
	private bool isProducing;

	[SyncVar(hook = "OnProductionPausedChanged")]
	private bool isProductionPaused = true;

	[SyncVar]
	private float productionStartTime;

	[SyncVar]
	private float currentProductionTime;

	[SyncVar]
	private string producingItemId = string.Empty;

	[Header("Production Amount")]
	[SyncVar(hook = "OnProductionAmountChanged")]
	private int productionAmount;

	[SyncVar(hook = "OnInfiniteModeChanged")]
	private bool isInfiniteMode;

	[Header("References")]
	[SerializeField]
	private Transform itemSpawnPoint;

	[Header("Display Icons")]
	[SerializeField]
	private SpriteRenderer itemIconRenderer;

	[SerializeField]
	private SpriteRenderer pauseIconRenderer;

	[SerializeField]
	private Sprite startIconSprite;

	[SerializeField]
	private Sprite stopIconSprite;

	[Header("Amount Display")]
	[SerializeField]
	private TextMeshPro amountText;

	[Header("Audio Clips")]
	public AudioClip idleClip;

	public AudioClip workingClip;

	public AudioClip inputClip;

	public List<AudioClip> outputClips = new List<AudioClip>();

	[Header("Audio Sources")]
	public AudioSource idleSource;

	public AudioSource workingSource;

	public AudioSource inputSource;

	public AudioSource outputSource;

	[Header("Recipe & Working Visuals")]
	public GameObject workingLights;

	public GameObject recipeTrueObject;

	public GameObject recipeFalseObject;

	[Header("VFX")]
	public ParticleSystem workingVFX;

	public ParticleSystem inputVFX;

	[Header("Machine Animators")]
	public Animator machineInputAnimator;

	public Animator machineOutputAnimator;

	[Header("Animator Triggers")]
	public string machineStartTrigger = "Start";

	public string machineStopTrigger = "Stop";

	[Header("Machine Events")]
	public UnityEvent OnRecipeActive;

	public UnityEvent OnRecipeDeactive;

	public UnityEvent OnMachineWorking;

	public UnityEvent OnMachineStopped;

	public UnityEvent OnInfiniteModeEnabled;

	public UnityEvent OnInfiniteModeDisabled;

	public UnityEvent OnUIClosed;

	public UnityEvent OnItemReceived;

	public UnityEvent OnItemStopped;

	public UnityEvent OnItemProduced;

	private bool isReceivingItems;

	private Coroutine itemStoppedCoroutine;

	private Coroutine machineStoppedDelayCoroutine;

	private bool lastRecipeActiveState;

	private bool lastRecipeDeactiveState;

	private bool lastMachineWorkingState;

	private bool lastMachineStoppedState;

	private bool pendingStartAfterLoad;

	private const float FADE_IN_TIME = 0.15f;

	private const float FADE_OUT_TIME = 0.15f;

	private const float DEFAULT_TARGET_VOL = 1f;

	private Coroutine workingFadeCoroutine;

	private Coroutine inputFadeCoroutine;

	private Coroutine idleFadeCoroutine;

	private readonly Dictionary<AudioSource, float> baseSourceVolumes = new Dictionary<AudioSource, float>(8);

	public Action<int, int> _Mirror_SyncVarHookDelegate_selectedRecipeIndex;

	public Action<string, string> _Mirror_SyncVarHookDelegate_selectedRecipeProductItemId;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isProducing;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isProductionPaused;

	public Action<int, int> _Mirror_SyncVarHookDelegate_productionAmount;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isInfiniteMode;

	private BuildingObject BuildingObj
	{
		get
		{
			if (_buildingObject == null)
			{
				_buildingObject = GetComponent<BuildingObject>();
			}
			return _buildingObject;
		}
	}

	public string UniqueMachineId
	{
		get
		{
			if (!(BuildingObj != null))
			{
				return string.Empty;
			}
			return BuildingObj.UniqueBuildingId;
		}
	}

	public T_BuildingItemSO BuildingSO => BuildingItemSO;

	public List<T_ItemSO> AcceptedRecipes => acceptedRecipes;

	public int SelectedRecipeIndex => selectedRecipeIndex;

	public bool IsProducing => isProducing;

	public bool IsProductionPaused => isProductionPaused;

	public float ProductionProgress
	{
		get
		{
			if (!(currentProductionTime > 0f))
			{
				return 0f;
			}
			return ((float)NetworkTime.time - productionStartTime) / currentProductionTime;
		}
	}

	public float RemainingTime
	{
		get
		{
			if (!(currentProductionTime > 0f))
			{
				return 0f;
			}
			return Mathf.Max(0f, currentProductionTime - ((float)NetworkTime.time - productionStartTime));
		}
	}

	public int ProductionAmount => productionAmount;

	public bool IsInfiniteMode => isInfiniteMode;

	public string SelectedRecipeProductItemId => selectedRecipeProductItemId;

	public bool HasSelectedRecipe
	{
		get
		{
			if (selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
			{
				return !string.IsNullOrEmpty(selectedRecipeProductItemId);
			}
			return false;
		}
	}

	public string SaveID => "machine-" + UniqueMachineId;

	public bool IsShared => false;

	public Type SaveType => typeof(MachineSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public int NetworkselectedRecipeIndex
	{
		get
		{
			return selectedRecipeIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref selectedRecipeIndex, 1uL, _Mirror_SyncVarHookDelegate_selectedRecipeIndex);
		}
	}

	public string NetworkselectedRecipeProductItemId
	{
		get
		{
			return selectedRecipeProductItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref selectedRecipeProductItemId, 2uL, _Mirror_SyncVarHookDelegate_selectedRecipeProductItemId);
		}
	}

	public bool NetworkisProducing
	{
		get
		{
			return isProducing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isProducing, 4uL, _Mirror_SyncVarHookDelegate_isProducing);
		}
	}

	public bool NetworkisProductionPaused
	{
		get
		{
			return isProductionPaused;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isProductionPaused, 8uL, _Mirror_SyncVarHookDelegate_isProductionPaused);
		}
	}

	public float NetworkproductionStartTime
	{
		get
		{
			return productionStartTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref productionStartTime, 16uL, null);
		}
	}

	public float NetworkcurrentProductionTime
	{
		get
		{
			return currentProductionTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentProductionTime, 32uL, null);
		}
	}

	public string NetworkproducingItemId
	{
		get
		{
			return producingItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref producingItemId, 64uL, null);
		}
	}

	public int NetworkproductionAmount
	{
		get
		{
			return productionAmount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref productionAmount, 128uL, _Mirror_SyncVarHookDelegate_productionAmount);
		}
	}

	public bool NetworkisInfiniteMode
	{
		get
		{
			return isInfiniteMode;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isInfiniteMode, 256uL, _Mirror_SyncVarHookDelegate_isInfiniteMode);
		}
	}

	public event Action<int> OnRecipeSelected;

	public event Action<bool> OnProductionStateChangedEvent;

	public event Action OnStorageChanged;

	public event Action<int> OnProductionAmountChangedEvent;

	public event Action<bool> OnInfiniteModeChangedEvent;

	public event Action OnMachineDisplayInfoChanged;

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			Debug.Log("[T_Machine] " + message);
		}
	}

	private void Awake()
	{
		SyncList<ItemStack> syncList = storedItems;
		syncList.Callback = (Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>)Delegate.Combine(syncList.Callback, new Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>(OnStoredItemsChanged));
		CacheBaseVolumes();
	}

	private void CacheBaseVolumes()
	{
		CacheBaseVolume(idleSource);
		CacheBaseVolume(workingSource);
		CacheBaseVolume(inputSource);
		CacheBaseVolume(outputSource);
	}

	private void CacheBaseVolume(AudioSource src)
	{
		if (!(src == null) && !baseSourceVolumes.ContainsKey(src))
		{
			baseSourceVolumes[src] = Mathf.Max(0f, src.volume);
		}
	}

	private float GetBaseVolume(AudioSource src, float fallback = 1f)
	{
		if (src == null)
		{
			return fallback;
		}
		if (baseSourceVolumes.TryGetValue(src, out var value))
		{
			return Mathf.Max(0f, value);
		}
		float num = Mathf.Max(0f, src.volume);
		baseSourceVolumes[src] = num;
		return num;
	}

	private IEnumerator WaitAndFetchMaxItemCount()
	{
		while (GameManager.Instance == null)
		{
			yield return null;
		}
		maxItemCount = GameManager.Instance.machineMaxItemCount;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		StartCoroutine(WaitAndFetchMaxItemCount());
		StartCoroutine(UpdateClientStateOnJoin());
		UpdateDisplayIcons();
		UpdateAmountDisplay();
	}

	private IEnumerator UpdateClientStateOnJoin()
	{
		yield return new WaitForSeconds(0.1f);
		CmdRequestEventSync();
		UpdateDisplayIcons();
		UpdateAmountDisplay();
		this.OnMachineDisplayInfoChanged?.Invoke();
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestEventSync(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestEventSync__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdRequestEventSync(Mirror.NetworkConnectionToClient)", 647017494, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetSyncEventStates(NetworkConnection target, bool recipeActive, bool recipeDeactive, bool machineWorking, bool machineStopped)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(recipeActive);
		writer.WriteBool(recipeDeactive);
		writer.WriteBool(machineWorking);
		writer.WriteBool(machineStopped);
		SendTargetRPCInternal(target, "System.Void T_Machine::TargetSyncEventStates(Mirror.NetworkConnection,System.Boolean,System.Boolean,System.Boolean,System.Boolean)", -1437361972, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void UpdateRecipeEvents()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::UpdateRecipeEvents()' called when server was not active");
			return;
		}
		int num;
		int num2;
		if (selectedRecipeIndex >= 0)
		{
			num = ((selectedRecipeIndex < acceptedRecipes.Count) ? 1 : 0);
			if (num != 0)
			{
				num2 = ((acceptedRecipes[selectedRecipeIndex] != null) ? 1 : 0);
				goto IL_0051;
			}
		}
		else
		{
			num = 0;
		}
		num2 = 0;
		goto IL_0051;
		IL_0051:
		bool flag = (byte)num2 != 0;
		bool flag2 = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProductionPaused;
		if (flag2 != lastRecipeActiveState)
		{
			lastRecipeActiveState = flag2;
			if (flag2)
			{
				ApplyRecipeActiveVisuals(isActive: true);
				OnRecipeActive?.Invoke();
				RpcRecipeActive();
			}
		}
		bool flag3 = num == 0 || !flag || isProductionPaused;
		if (flag3 != lastRecipeDeactiveState)
		{
			lastRecipeDeactiveState = flag3;
			if (flag3)
			{
				ApplyRecipeActiveVisuals(isActive: false);
				OnRecipeDeactive?.Invoke();
				RpcRecipeDeactive();
			}
		}
	}

	private void Update()
	{
		if (base.isServer)
		{
			ServerUpdateProduction();
		}
	}

	[Server]
	private void ServerUpdateProduction()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerUpdateProduction()' called when server was not active");
		}
		else if (isProducing && currentProductionTime > 0f && (float)NetworkTime.time - productionStartTime >= currentProductionTime)
		{
			CompleteProduction();
		}
	}

	public void SelectRecipe(int recipeIndex)
	{
		if (base.isServer)
		{
			ServerSelectRecipe(recipeIndex);
		}
		else
		{
			CmdSelectRecipe(recipeIndex);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSelectRecipe(int recipeIndex)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSelectRecipe__Int32(recipeIndex);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(recipeIndex);
		SendCommandInternal("System.Void T_Machine::CmdSelectRecipe(System.Int32)", -1539512650, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSelectRecipe(int recipeIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerSelectRecipe(System.Int32)' called when server was not active");
		}
		else
		{
			if (recipeIndex < 0 || recipeIndex >= acceptedRecipes.Count)
			{
				return;
			}
			T_ItemSO t_ItemSO = acceptedRecipes[recipeIndex];
			if (t_ItemSO == null || (isProducing && HasEnoughResources() && (productionAmount > 0 || isInfiniteMode)))
			{
				return;
			}
			if (isProducing)
			{
				RefundIngredients();
				NetworkisProducing = false;
				NetworkproducingItemId = string.Empty;
				NetworkcurrentProductionTime = 0f;
				NetworkproductionStartTime = 0f;
			}
			NetworkselectedRecipeIndex = recipeIndex;
			DebugLog($"Recipe changed to index {recipeIndex} ({t_ItemSO.name})");
			NetworkisProductionPaused = true;
			NetworkproductionAmount = 0;
			NetworkisInfiniteMode = false;
			UpdateSelectedRecipeProductItemId();
			CheckAndUpdateRecipeState();
			if (!(TutorialManager.Instance != null))
			{
				return;
			}
			bool flag = true;
			string tutorialLockedItemId = TutorialManager.Instance.TutorialLockedItemId;
			if (!string.IsNullOrEmpty(tutorialLockedItemId))
			{
				if (t_ItemSO.Type == PickupType.Resource)
				{
					flag = t_ItemSO.ore != null && t_ItemSO.ore.GetItemID() == tutorialLockedItemId;
				}
				else if (t_ItemSO.Type == PickupType.Product)
				{
					flag = false;
					if (t_ItemSO.RecipeList != null)
					{
						foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
						{
							if (recipe.Item != null && recipe.Item.Type == PickupType.Resource && recipe.Item.ore != null && recipe.Item.ore.GetItemID() == tutorialLockedItemId)
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			if (flag)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.SelectRecipe);
			}
		}
	}

	public void TransferItemsFromSack(uint sackNetId)
	{
		if (base.isServer)
		{
			ServerTransferItemsFromSack(sackNetId, NetworkServer.localConnection);
		}
		else
		{
			CmdTransferItemsFromSack(sackNetId);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTransferItemsFromSack(uint sackNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(sackNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendCommandInternal("System.Void T_Machine::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", 213072369, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTransferItemsFromSack(uint sackNetId, NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (sackNetId == 0 || !NetworkServer.spawned.TryGetValue(sackNetId, out var value))
			{
				return;
			}
			T_Sack component = value.GetComponent<T_Sack>();
			if (component == null)
			{
				return;
			}
			Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
			if (storedItemCounts.Count == 0)
			{
				return;
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			foreach (KeyValuePair<string, int> item in storedItemCounts)
			{
				if (IsItemValidForAnyRecipe(item.Key))
				{
					int maxAddableCount = GetMaxAddableCount(item.Key, item.Value);
					if (maxAddableCount > 0)
					{
						dictionary[item.Key] = maxAddableCount;
						dictionary2[item.Key] = maxAddableCount;
					}
				}
			}
			if (dictionary.Count == 0)
			{
				return;
			}
			string[] array = new string[dictionary.Count];
			int[] array2 = new int[dictionary.Count];
			int num = 0;
			foreach (KeyValuePair<string, int> item2 in dictionary)
			{
				array[num] = item2.Key;
				array2[num] = item2.Value;
				num++;
			}
			AddItems(array, array2);
			NotifyItemReceived();
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PutOreInMachine, TutorialSubStepType.PutInMachine);
			}
			component.ServerRemoveItems(dictionary2);
			if (component.ItemCount <= 0)
			{
				if (sender != null)
				{
					RpcClearPlayerPickupItem(sender);
				}
				NetworkServer.Destroy(component.gameObject);
			}
		}
	}

	[TargetRpc]
	private void RpcClearPlayerPickupItem(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Machine::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", -3165818, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void TransferPartialItemsFromSack(uint sackNetId, string itemId, int amount)
	{
		if (base.isServer)
		{
			ServerTransferPartialItemsFromSack(sackNetId, itemId, amount, NetworkServer.localConnection);
		}
		else
		{
			CmdTransferPartialItemsFromSack(sackNetId, itemId, amount);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTransferPartialItemsFromSack(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTransferPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(sackNetId, itemId, amount, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		writer.WriteString(itemId);
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void T_Machine::CmdTransferPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", -1213030117, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTransferPartialItemsFromSack(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerTransferPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (sackNetId == 0 || string.IsNullOrEmpty(itemId) || amount <= 0 || !NetworkServer.spawned.TryGetValue(sackNetId, out var value))
			{
				return;
			}
			T_Sack component = value.GetComponent<T_Sack>();
			if (component == null)
			{
				return;
			}
			Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
			int num = (storedItemCounts.ContainsKey(itemId) ? storedItemCounts[itemId] : 0);
			if (num <= 0 || !IsItemValidForAnyRecipe(itemId))
			{
				return;
			}
			int num2 = Mathf.Min(amount, num);
			int maxAddableCount = GetMaxAddableCount(itemId, num2);
			if (maxAddableCount <= 0)
			{
				return;
			}
			int num3 = Mathf.Min(num2, maxAddableCount);
			string[] itemIds = new string[1] { itemId };
			int[] counts = new int[1] { num3 };
			ServerAddItems(itemIds, counts);
			NotifyItemReceived();
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PutOreInMachine, TutorialSubStepType.PutInMachine);
			}
			component.ServerRemoveItems(new Dictionary<string, int> { { itemId, num3 } });
			if (component.ItemCount <= 0)
			{
				if (sender != null)
				{
					RpcClearPlayerPickupItem(sender);
				}
				NetworkServer.Destroy(component.gameObject);
			}
		}
	}

	public void AddItems(string[] itemIds, int[] counts)
	{
		if (base.isServer)
		{
			ServerAddItems(itemIds, counts);
		}
		else
		{
			CmdAddItems(itemIds, counts);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddItems(string[] itemIds, int[] counts)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddItems__String_005B_005D__Int32_005B_005D(itemIds, counts);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002EString_005B_005D(writer, itemIds);
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, counts);
		SendCommandInternal("System.Void T_Machine::CmdAddItems(System.String[],System.Int32[])", -248890463, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddItems(string[] itemIds, int[] counts)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerAddItems(System.String[],System.Int32[])' called when server was not active");
		}
		else
		{
			if (itemIds == null || counts == null || itemIds.Length == 0 || counts.Length == 0 || itemIds.Length != counts.Length)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < itemIds.Length; i++)
			{
				string text = itemIds[i];
				int num2 = counts[i];
				if (string.IsNullOrEmpty(text) || num2 <= 0 || !IsItemValidForAnyRecipe(text))
				{
					continue;
				}
				int maxAddableCount = GetMaxAddableCount(text, num2);
				if (maxAddableCount <= 0)
				{
					continue;
				}
				int num3 = maxAddableCount;
				bool flag = false;
				for (int j = 0; j < storedItems.Count; j++)
				{
					if (storedItems[j].itemId == text)
					{
						storedItems[j] = new ItemStack(text, storedItems[j].count + num3);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					storedItems.Add(new ItemStack(text, num3));
				}
				num++;
			}
			if (num > 0)
			{
				DebugLog($"Added {num} item type(s) to machine storage");
				NotifyItemReceived();
			}
			if (num > 0 && !isProductionPaused && !isProducing && selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
			{
				T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
				if (t_ItemSO != null && CanStartProduction())
				{
					StartProduction(t_ItemSO);
				}
				else
				{
					CheckAndUpdateRecipeState();
				}
			}
			else if (num > 0)
			{
				CheckAndUpdateRecipeState();
			}
		}
	}

	private bool IsItemValidForRecipe(string itemId, T_ItemSO recipe)
	{
		if (recipe == null || string.IsNullOrEmpty(itemId))
		{
			return false;
		}
		if (recipe.Type == PickupType.Resource)
		{
			if (recipe.ore == null)
			{
				return false;
			}
			return recipe.ore.GetItemID() == itemId;
		}
		if (recipe.Type == PickupType.Product)
		{
			if (recipe.RecipeList == null || recipe.RecipeList.Count == 0)
			{
				return false;
			}
			foreach (T_ItemSO.RecipeIngredient recipe2 in recipe.RecipeList)
			{
				if (recipe2.Item != null && recipe2.Item.GetItemID() == itemId)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private bool IsItemValidForAnyRecipe(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return false;
		}
		foreach (T_ItemSO acceptedRecipe in acceptedRecipes)
		{
			if (acceptedRecipe != null && IsItemValidForRecipe(itemId, acceptedRecipe))
			{
				return true;
			}
		}
		return false;
	}

	private bool HasEnoughResources()
	{
		if (selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
		{
			return false;
		}
		T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
		if (t_ItemSO == null)
		{
			return false;
		}
		if (productionAmount <= 0 && !isInfiniteMode)
		{
			return false;
		}
		if (t_ItemSO.Type == PickupType.Resource)
		{
			if (t_ItemSO.ore == null)
			{
				return false;
			}
			return GetItemCount(t_ItemSO.ore.GetItemID()) >= t_ItemSO.oreCount;
		}
		if (t_ItemSO.Type == PickupType.Product)
		{
			if (t_ItemSO.RecipeList == null || t_ItemSO.RecipeList.Count == 0)
			{
				return false;
			}
			foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
			{
				if (!(recipe.Item == null))
				{
					string itemID = recipe.Item.GetItemID();
					if (GetItemCount(itemID) < recipe.Count)
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	[Server]
	private bool CanStartProduction()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Machine::CanStartProduction()' called when server was not active");
			return default(bool);
		}
		if (isProducing)
		{
			return false;
		}
		return HasEnoughResources();
	}

	[Server]
	private void StartProduction(T_ItemSO productItem)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::StartProduction(T_ItemSO)' called when server was not active");
		}
		else if (!isProducing && !isProductionPaused && (isInfiniteMode || productionAmount > 0) && !(productItem == null))
		{
			NetworkisProducing = true;
			NetworkproducingItemId = productItem.GetItemID();
			NetworkcurrentProductionTime = acceptedRecipes[selectedRecipeIndex].productionTime;
			NetworkproductionStartTime = (float)NetworkTime.time;
			DebugLog($"Production started: {productItem.name} (time: {currentProductionTime}s, amount: {productionAmount}, infinite: {isInfiniteMode})");
			ConsumeIngredients();
			CheckAndUpdateRecipeState();
		}
	}

	public void RequestStartProduction()
	{
		if (base.isServer)
		{
			ServerStartProduction();
		}
		else
		{
			CmdStartProduction();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdStartProduction()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdStartProduction();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdStartProduction()", 503359186, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStartProduction()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerStartProduction()' called when server was not active");
		}
		else
		{
			if (isProducing || selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
			{
				return;
			}
			T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
			if (!(t_ItemSO == null))
			{
				NetworkisProductionPaused = false;
				DebugLog("Production unpaused (start requested)");
				if (TutorialManager.Instance != null)
				{
					TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.StartProduction);
				}
				if (CanStartProduction())
				{
					StartProduction(t_ItemSO);
				}
				else
				{
					CheckAndUpdateRecipeState();
				}
			}
		}
	}

	public void RequestStopProduction()
	{
		if (base.isServer)
		{
			ServerStopProduction();
		}
		else
		{
			CmdStopProduction();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdStopProduction()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdStopProduction();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdStopProduction()", -992226406, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStopProduction()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerStopProduction()' called when server was not active");
			return;
		}
		DebugLog($"Production stopped (was producing: {isProducing})");
		NetworkisProductionPaused = true;
		if (isProducing)
		{
			RefundIngredients();
			NetworkisProducing = false;
			NetworkproducingItemId = string.Empty;
			NetworkcurrentProductionTime = 0f;
			NetworkproductionStartTime = 0f;
		}
	}

	[Server]
	private void RefundIngredients()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::RefundIngredients()' called when server was not active");
		}
		else
		{
			if (selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
			{
				return;
			}
			T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
			if (t_ItemSO == null)
			{
				return;
			}
			DebugLog("Refunding ingredients for recipe: " + t_ItemSO.name);
			if (t_ItemSO.Type == PickupType.Resource)
			{
				if (t_ItemSO.ore != null)
				{
					AddItemDirectly(t_ItemSO.ore.GetItemID(), t_ItemSO.oreCount);
				}
			}
			else if (t_ItemSO.Type == PickupType.Product && t_ItemSO.RecipeList != null)
			{
				foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
				{
					if (!(recipe.Item == null))
					{
						AddItemDirectly(recipe.Item.GetItemID(), recipe.Count);
					}
				}
			}
			this.OnStorageChanged?.Invoke();
			CheckAndUpdateRecipeState();
		}
	}

	[Server]
	private void AddItemDirectly(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::AddItemDirectly(System.String,System.Int32)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(itemId) || count <= 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < storedItems.Count; i++)
			{
				if (storedItems[i].itemId == itemId)
				{
					storedItems[i] = new ItemStack(itemId, storedItems[i].count + count);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				storedItems.Add(new ItemStack(itemId, count));
			}
		}
	}

	[Server]
	private void ConsumeIngredients()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ConsumeIngredients()' called when server was not active");
		}
		else
		{
			if (selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
			{
				return;
			}
			T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
			if (t_ItemSO == null)
			{
				return;
			}
			if (t_ItemSO.Type == PickupType.Resource)
			{
				if (t_ItemSO.ore != null)
				{
					RemoveItem(t_ItemSO.ore.GetItemID(), t_ItemSO.oreCount);
				}
			}
			else if (t_ItemSO.Type == PickupType.Product && t_ItemSO.RecipeList != null)
			{
				foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
				{
					if (!(recipe.Item == null))
					{
						RemoveItem(recipe.Item.GetItemID(), recipe.Count);
					}
				}
			}
			CheckAndUpdateRecipeState();
		}
	}

	[Server]
	private void CompleteProduction()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::CompleteProduction()' called when server was not active");
		}
		else
		{
			if (!isProducing)
			{
				return;
			}
			T_ItemSO itemSOById = GetItemSOById(producingItemId);
			DebugLog("Production completed: " + producingItemId + " (remaining: " + (isInfiniteMode ? "infinite" : (productionAmount - 1).ToString()) + ")");
			if (itemSOById != null)
			{
				SpawnProductItem(itemSOById);
			}
			NetworkisProducing = false;
			NetworkproducingItemId = string.Empty;
			NetworkcurrentProductionTime = 0f;
			NetworkproductionStartTime = 0f;
			if (!isInfiniteMode && productionAmount > 0)
			{
				NetworkproductionAmount = productionAmount - 1;
			}
			if (!isProductionPaused && (isInfiniteMode || productionAmount > 0))
			{
				if (selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
				{
					T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
					if (t_ItemSO != null && CanStartProduction())
					{
						StartProduction(t_ItemSO);
						return;
					}
					UpdateMachineEventState();
					UpdateRecipeEvents();
				}
			}
			else
			{
				UpdateMachineEventState();
				UpdateRecipeEvents();
			}
		}
	}

	[Server]
	private void SpawnProductItem(T_ItemSO itemSO)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::SpawnProductItem(T_ItemSO)' called when server was not active");
		}
		else
		{
			if (itemSO == null)
			{
				return;
			}
			GameObject spawnPrefab = itemSO.SpawnPrefab;
			if (!(spawnPrefab == null))
			{
				Vector3 vector = ((itemSpawnPoint != null) ? itemSpawnPoint.position : (base.transform.position + Vector3.up));
				GameObject gameObject = UnityEngine.Object.Instantiate(spawnPrefab, vector, Quaternion.identity);
				T_Item component = gameObject.GetComponent<T_Item>();
				if (component != null)
				{
					component.ServerPreAssignSO(itemSO);
					component.checkForBeltOnSpawn = true;
				}
				NetworkServer.Spawn(gameObject);
				Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
				if (rigidbody == null)
				{
					rigidbody = gameObject.AddComponent<Rigidbody>();
				}
				rigidbody.isKinematic = true;
				if (component != null)
				{
					component.ServerSnap(vector, Quaternion.identity);
				}
				NotifyItemProduced();
				if (TutorialManager.Instance != null)
				{
					TutorialManager.Instance.TryAddSubStepProgress(TutorialConfigType.Production, TutorialStepType.ProduceProductTarget, TutorialSubStepType.ProduceProductTargetSub);
				}
			}
		}
	}

	private T_ItemSO GetItemSOById(string itemId)
	{
		if (ItemSOManager.Instance == null)
		{
			return null;
		}
		return ItemSOManager.Instance.GetItemSOById(itemId);
	}

	public int GetItemCount(string itemId)
	{
		int num = 0;
		foreach (ItemStack storedItem in storedItems)
		{
			if (storedItem.itemId == itemId)
			{
				num += storedItem.count;
			}
		}
		return num;
	}

	[Server]
	private int GetMaxAddableCount(string itemId, int requestedCount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 T_Machine::GetMaxAddableCount(System.String,System.Int32)' called when server was not active");
			return default(int);
		}
		int itemCount = GetItemCount(itemId);
		int num = maxItemCount - itemCount;
		if (num <= 0)
		{
			return 0;
		}
		return Mathf.Min(requestedCount, num);
	}

	[Server]
	private void RemoveItem(string itemId, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::RemoveItem(System.String,System.Int32)' called when server was not active");
			return;
		}
		for (int num = storedItems.Count - 1; num >= 0; num--)
		{
			if (!(storedItems[num].itemId != itemId))
			{
				int num2 = storedItems[num].count - amount;
				if (num2 <= 0)
				{
					storedItems.RemoveAt(num);
				}
				else
				{
					storedItems[num] = new ItemStack(itemId, num2);
				}
				break;
			}
		}
	}

	public Dictionary<string, int> GetStoredItemCounts()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (ItemStack storedItem in storedItems)
		{
			if (storedItem.IsValid())
			{
				if (dictionary.ContainsKey(storedItem.itemId))
				{
					dictionary[storedItem.itemId] += storedItem.count;
				}
				else
				{
					dictionary[storedItem.itemId] = storedItem.count;
				}
			}
		}
		return dictionary;
	}

	public void SendAllItemsToStorage()
	{
		if (base.isServer)
		{
			ServerSendAllItemsToStorage();
		}
		else
		{
			CmdSendAllItemsToStorage();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSendAllItemsToStorage()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSendAllItemsToStorage();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdSendAllItemsToStorage()", 1529637126, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSendAllItemsToStorage()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerSendAllItemsToStorage()' called when server was not active");
			return;
		}
		Dictionary<string, int> storedItemCounts = GetStoredItemCounts();
		if (storedItemCounts != null && storedItemCounts.Count != 0 && !(GameManager.Instance?.storageManager == null))
		{
			DebugLog($"Sending all items to storage ({storedItemCounts.Count} type(s))");
			GameManager.Instance.storageManager.RequestAddItems(storedItemCounts);
			storedItems.Clear();
			RpcNotifyStorageChanged();
		}
	}

	public bool HasValidItemsInSack()
	{
		if (GameManager.Instance?.localEquipments == null)
		{
			return false;
		}
		GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
		if (pickupItem == null)
		{
			return false;
		}
		T_Sack component = pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return false;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts.Count == 0)
		{
			return false;
		}
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			if (IsItemValidForAnyRecipe(item.Key))
			{
				return true;
			}
		}
		return false;
	}

	public string GetRequiredItemsString()
	{
		if (selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
		{
			return "";
		}
		T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
		if (t_ItemSO == null)
		{
			return "";
		}
		List<string> list = new List<string>();
		if (t_ItemSO.Type == PickupType.Resource)
		{
			if (t_ItemSO.ore != null)
			{
				list.Add(LocalizationManager.GetTranslation(t_ItemSO.ore.Name));
			}
		}
		else if (t_ItemSO.Type == PickupType.Product && t_ItemSO.RecipeList != null)
		{
			foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
			{
				if (!(recipe.Item == null) && !string.IsNullOrEmpty(recipe.Item.Name))
				{
					string translation = LocalizationManager.GetTranslation(recipe.Item.Name);
					if (string.IsNullOrEmpty(translation))
					{
						translation = recipe.Item.Name;
					}
					if (!list.Contains(translation))
					{
						list.Add(translation);
					}
				}
			}
		}
		return string.Join(", ", list);
	}

	private void OnSelectedRecipeChanged(int oldValue, int newValue)
	{
		this.OnRecipeSelected?.Invoke(newValue);
		if (base.isServer)
		{
			UpdateSelectedRecipeProductItemId();
			UpdateMachineEventState();
			UpdateRecipeEvents();
		}
		UpdateDisplayIcons();
		if (base.isServer)
		{
			RpcUpdateMachineDisplayInfo();
		}
	}

	private void OnSelectedRecipeProductItemIdChanged(string oldValue, string newValue)
	{
		UpdateDisplayIcons();
		RpcUpdateMachineDisplayInfo();
	}

	[Server]
	private void UpdateSelectedRecipeProductItemId()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::UpdateSelectedRecipeProductItemId()' called when server was not active");
		}
		else if (selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
		{
			T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
			NetworkselectedRecipeProductItemId = ((t_ItemSO != null) ? t_ItemSO.GetItemID() : string.Empty);
		}
		else
		{
			NetworkselectedRecipeProductItemId = string.Empty;
		}
	}

	private void OnProductionStateChanged(bool oldValue, bool newValue)
	{
		this.OnProductionStateChangedEvent?.Invoke(newValue);
		if (base.isServer)
		{
			UpdateMachineEventState();
			UpdateRecipeEvents();
		}
	}

	private void OnProductionPausedChanged(bool oldValue, bool newValue)
	{
		this.OnProductionStateChangedEvent?.Invoke(isProducing);
		if (base.isServer)
		{
			UpdateMachineEventState();
			UpdateRecipeEvents();
			RpcUpdateMachineDisplayInfo();
		}
		UpdateDisplayIcons();
	}

	[Server]
	private void UpdateMachineEventState()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::UpdateMachineEventState()' called when server was not active");
			return;
		}
		int num;
		int num2;
		if (selectedRecipeIndex >= 0)
		{
			num = ((selectedRecipeIndex < acceptedRecipes.Count) ? 1 : 0);
			if (num != 0)
			{
				num2 = ((acceptedRecipes[selectedRecipeIndex] != null) ? 1 : 0);
				goto IL_0051;
			}
		}
		else
		{
			num = 0;
		}
		num2 = 0;
		goto IL_0051;
		IL_0051:
		bool flag = (byte)num2 != 0;
		bool flag2 = false;
		if (((uint)num & (flag ? 1u : 0u)) != 0 && !isProductionPaused)
		{
			flag2 = HasEnoughResources();
		}
		bool flag3 = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProductionPaused && (isProducing || flag2) && (productionAmount > 0 || isInfiniteMode);
		if (flag3 != lastMachineWorkingState)
		{
			lastMachineWorkingState = flag3;
			if (flag3)
			{
				if (machineStoppedDelayCoroutine != null)
				{
					StopCoroutine(machineStoppedDelayCoroutine);
					machineStoppedDelayCoroutine = null;
				}
				ApplyMachineWorkingState(isWorking: true);
				OnMachineWorking?.Invoke();
				RpcMachineWorking();
			}
		}
		bool flag4 = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProducing && (isProductionPaused || !flag2 || (productionAmount <= 0 && !isInfiniteMode));
		if (flag4 != lastMachineStoppedState)
		{
			lastMachineStoppedState = flag4;
			if (flag4)
			{
				machineStoppedDelayCoroutine = StartCoroutine(DelayedMachineStopped(flag4));
			}
		}
	}

	private IEnumerator DelayedMachineStopped(bool expectedState)
	{
		yield return new WaitForSeconds(3f);
		bool num = selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count;
		bool flag = num && acceptedRecipes[selectedRecipeIndex] != null;
		bool flag2 = false;
		if (num && flag && !isProductionPaused)
		{
			flag2 = HasEnoughResources();
		}
		bool flag3 = num && flag && !isProducing && (isProductionPaused || !flag2);
		if (flag3 == expectedState && flag3)
		{
			ApplyMachineWorkingState(isWorking: false);
			OnMachineStopped?.Invoke();
			RpcMachineStopped();
		}
		machineStoppedDelayCoroutine = null;
	}

	private void OnStoredItemsChanged(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
		this.OnStorageChanged?.Invoke();
		if (base.isServer)
		{
			UpdateMachineEventState();
			UpdateRecipeEvents();
		}
	}

	[ClientRpc]
	private void RpcNotifyStorageChanged()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcNotifyStorageChanged()", 1991177480, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator DelayedStorageChangedNotification()
	{
		yield return null;
		this.OnStorageChanged?.Invoke();
	}

	[ClientRpc]
	private void RpcRecipeActive()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcRecipeActive()", 1437980926, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcRecipeDeactive()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcRecipeDeactive()", -765024183, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcMachineWorking()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcMachineWorking()", -439099422, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcMachineStopped()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcMachineStopped()", -1402425872, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void NotifyItemReceived()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::NotifyItemReceived()' called when server was not active");
			return;
		}
		if (!isReceivingItems)
		{
			isReceivingItems = true;
			ApplyItemReceivingState(isReceiving: true);
			OnItemReceived?.Invoke();
			RpcItemReceived();
		}
		if (itemStoppedCoroutine != null)
		{
			StopCoroutine(itemStoppedCoroutine);
			itemStoppedCoroutine = null;
		}
		itemStoppedCoroutine = StartCoroutine(ItemStoppedTimeout());
	}

	private IEnumerator ItemStoppedTimeout()
	{
		yield return new WaitForSeconds(6f);
		isReceivingItems = false;
		itemStoppedCoroutine = null;
		ApplyItemReceivingState(isReceiving: false);
		OnItemStopped?.Invoke();
		RpcItemStopped();
	}

	[ClientRpc]
	private void RpcItemReceived()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcItemReceived()", -1171117182, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcItemStopped()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcItemStopped()", -499118920, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void NotifyItemProduced()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::NotifyItemProduced()' called when server was not active");
			return;
		}
		ApplyItemProduced();
		OnItemProduced?.Invoke();
		RpcItemProduced();
	}

	[ClientRpc]
	private void RpcItemProduced()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Machine::RpcItemProduced()", 1973757221, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void RpcUpdateMachineDisplayInfo()
	{
		UpdateDisplayIcons();
		this.OnMachineDisplayInfoChanged?.Invoke();
	}

	private void UpdateDisplayIcons()
	{
		if (itemIconRenderer != null)
		{
			if (HasSelectedRecipe && !string.IsNullOrEmpty(selectedRecipeProductItemId))
			{
				T_ItemSO itemSOById = GetItemSOById(selectedRecipeProductItemId);
				if (itemSOById != null && itemSOById.Icon != null)
				{
					itemIconRenderer.sprite = itemSOById.Icon;
					itemIconRenderer.gameObject.SetActive(value: true);
				}
				else
				{
					itemIconRenderer.gameObject.SetActive(value: false);
				}
			}
			else
			{
				itemIconRenderer.gameObject.SetActive(value: false);
			}
		}
		if (!(pauseIconRenderer != null))
		{
			return;
		}
		if (!isProductionPaused)
		{
			if (stopIconSprite != null)
			{
				pauseIconRenderer.sprite = stopIconSprite;
			}
		}
		else if (startIconSprite != null)
		{
			pauseIconRenderer.sprite = startIconSprite;
		}
	}

	[Server]
	private void CheckAndUpdateRecipeState()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::CheckAndUpdateRecipeState()' called when server was not active");
			return;
		}
		UpdateMachineEventState();
		UpdateRecipeEvents();
	}

	public void TriggerOnUIClosed()
	{
		OnUIClosed?.Invoke();
	}

	public void IncreaseAmount(int delta = 1)
	{
		if (base.isServer)
		{
			ServerIncreaseAmount(delta);
		}
		else
		{
			CmdIncreaseAmount(delta);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdIncreaseAmount(int delta)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdIncreaseAmount__Int32(delta);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(delta);
		SendCommandInternal("System.Void T_Machine::CmdIncreaseAmount(System.Int32)", 1089286276, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerIncreaseAmount(int delta)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerIncreaseAmount(System.Int32)' called when server was not active");
			return;
		}
		NetworkproductionAmount = Mathf.Max(0, productionAmount + delta);
		if (TutorialManager.Instance != null && productionAmount > 0)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.EnterAmount);
		}
		TryStartProductionIfReady();
	}

	public void DecreaseAmount(int delta = 1)
	{
		if (base.isServer)
		{
			ServerDecreaseAmount(delta);
		}
		else
		{
			CmdDecreaseAmount(delta);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdDecreaseAmount(int delta)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdDecreaseAmount__Int32(delta);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(delta);
		SendCommandInternal("System.Void T_Machine::CmdDecreaseAmount(System.Int32)", -1263679308, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerDecreaseAmount(int delta)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerDecreaseAmount(System.Int32)' called when server was not active");
		}
		else
		{
			NetworkproductionAmount = Mathf.Max(0, productionAmount - delta);
		}
	}

	public void SetMaxAmount()
	{
		if (base.isServer)
		{
			ServerSetMaxAmount();
		}
		else
		{
			CmdSetMaxAmount();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetMaxAmount()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetMaxAmount();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdSetMaxAmount()", 1671555815, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetMaxAmount()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerSetMaxAmount()' called when server was not active");
			return;
		}
		int networkproductionAmount = CalculateMaxProductionCount();
		NetworkproductionAmount = networkproductionAmount;
		if (TutorialManager.Instance != null && productionAmount > 0)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.EnterAmount);
		}
		TryStartProductionIfReady();
	}

	public int CalculateMaxProductionCount()
	{
		if (selectedRecipeIndex < 0 || selectedRecipeIndex >= acceptedRecipes.Count)
		{
			return 0;
		}
		T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
		if (t_ItemSO == null)
		{
			return 0;
		}
		if (t_ItemSO.Type == PickupType.Resource)
		{
			if (t_ItemSO.ore == null)
			{
				return 0;
			}
			return GetItemCount(t_ItemSO.ore.GetItemID()) / t_ItemSO.oreCount;
		}
		if (t_ItemSO.Type == PickupType.Product)
		{
			if (t_ItemSO.RecipeList == null || t_ItemSO.RecipeList.Count == 0)
			{
				return 0;
			}
			int num = int.MaxValue;
			foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
			{
				if (!(recipe.Item == null))
				{
					int b = GetItemCount(recipe.Item.GetItemID()) / recipe.Count;
					num = Mathf.Min(num, b);
				}
			}
			if (num != int.MaxValue)
			{
				return num;
			}
			return 0;
		}
		return 0;
	}

	public void ToggleInfiniteMode()
	{
		if (base.isServer)
		{
			ServerToggleInfiniteMode();
		}
		else
		{
			CmdToggleInfiniteMode();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdToggleInfiniteMode()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdToggleInfiniteMode();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdToggleInfiniteMode()", 704138614, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerToggleInfiniteMode()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerToggleInfiniteMode()' called when server was not active");
			return;
		}
		NetworkisInfiniteMode = !isInfiniteMode;
		DebugLog($"Infinite mode toggled: {isInfiniteMode}");
		if (isInfiniteMode)
		{
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.EnterAmount);
			}
			TryStartProductionIfReady();
		}
	}

	public void DisableInfiniteMode()
	{
		if (base.isServer)
		{
			ServerDisableInfiniteMode();
		}
		else
		{
			CmdDisableInfiniteMode();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdDisableInfiniteMode()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdDisableInfiniteMode();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Machine::CmdDisableInfiniteMode()", 827936070, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerDisableInfiniteMode()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerDisableInfiniteMode()' called when server was not active");
		}
		else
		{
			NetworkisInfiniteMode = false;
		}
	}

	[Server]
	private void TryStartProductionIfReady()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::TryStartProductionIfReady()' called when server was not active");
		}
		else if (!isProducing && !isProductionPaused && (isInfiniteMode || productionAmount > 0) && selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
		{
			T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
			if (t_ItemSO != null && CanStartProduction())
			{
				StartProduction(t_ItemSO);
			}
		}
	}

	private void OnProductionAmountChanged(int oldValue, int newValue)
	{
		UpdateAmountDisplay();
		this.OnProductionAmountChangedEvent?.Invoke(newValue);
		if (oldValue == 0 && newValue == 1 && base.isServer)
		{
			UpdateMachineEventState();
		}
	}

	private void OnInfiniteModeChanged(bool oldValue, bool newValue)
	{
		UpdateAmountDisplay();
		if (newValue)
		{
			OnInfiniteModeEnabled?.Invoke();
		}
		else
		{
			OnInfiniteModeDisabled?.Invoke();
		}
		this.OnInfiniteModeChangedEvent?.Invoke(newValue);
	}

	private void UpdateAmountDisplay()
	{
		if (!(amountText == null))
		{
			amountText.text = (isInfiniteMode ? "∞" : productionAmount.ToString());
		}
	}

	[Server]
	public void ServerTryAddItemFromCollider(T_Item item)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerTryAddItemFromCollider(T_Item)' called when server was not active");
		}
		else if (!(item == null))
		{
			string itemId = item.itemId;
			if (!string.IsNullOrEmpty(itemId) && IsItemValidForAnyRecipe(itemId) && GetMaxAddableCount(itemId, 1) > 0)
			{
				DebugLog("Auto-collected item from collider: " + itemId);
				ServerAddSingleItem(itemId);
				NetworkServer.Destroy(item.gameObject);
			}
		}
	}

	[Server]
	private void ServerAddSingleItem(string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::ServerAddSingleItem(System.String)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(itemId) || !IsItemValidForAnyRecipe(itemId) || GetMaxAddableCount(itemId, 1) <= 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < storedItems.Count; i++)
			{
				if (storedItems[i].itemId == itemId)
				{
					storedItems[i] = new ItemStack(itemId, storedItems[i].count + 1);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				storedItems.Add(new ItemStack(itemId, 1));
			}
			NotifyItemReceived();
			if (!isProductionPaused && !isProducing && selectedRecipeIndex >= 0 && selectedRecipeIndex < acceptedRecipes.Count)
			{
				T_ItemSO t_ItemSO = acceptedRecipes[selectedRecipeIndex];
				if (t_ItemSO != null && CanStartProduction())
				{
					StartProduction(t_ItemSO);
				}
				else
				{
					CheckAndUpdateRecipeState();
				}
			}
			else
			{
				CheckAndUpdateRecipeState();
			}
		}
	}

	public void OnMachinePlaced()
	{
		ApplyIdleState(turnOn: true);
		if (workingLights != null)
		{
			workingLights.SetActive(value: false);
		}
		SetVFXState(workingVFX, turnOn: false);
		SetVFXState(inputVFX, turnOn: false);
	}

	private void ApplyRecipeActiveVisuals(bool isActive)
	{
		if (recipeTrueObject != null)
		{
			recipeTrueObject.SetActive(isActive);
		}
		if (recipeFalseObject != null)
		{
			recipeFalseObject.SetActive(!isActive);
		}
	}

	private void ApplyMachineWorkingState(bool isWorking)
	{
		if (workingLights != null)
		{
			workingLights.SetActive(isWorking);
		}
		SetVFXState(workingVFX, isWorking);
		if (workingFadeCoroutine != null)
		{
			StopCoroutine(workingFadeCoroutine);
		}
		workingFadeCoroutine = StartCoroutine(FadeLoopingSource(workingSource, workingClip, isWorking, isWorking ? 0.15f : 0.15f, 1f));
		if (machineOutputAnimator != null && !string.IsNullOrEmpty(machineStartTrigger) && !string.IsNullOrEmpty(machineStopTrigger))
		{
			if (isWorking)
			{
				machineOutputAnimator.SetTrigger(machineStartTrigger);
			}
			else
			{
				machineOutputAnimator.SetTrigger(machineStopTrigger);
			}
		}
	}

	private void ApplyItemReceivingState(bool isReceiving)
	{
		SetVFXState(inputVFX, isReceiving);
		if (inputFadeCoroutine != null)
		{
			StopCoroutine(inputFadeCoroutine);
		}
		inputFadeCoroutine = StartCoroutine(FadeLoopingSource(inputSource, inputClip, isReceiving, isReceiving ? 0.15f : 0.15f, 1f));
		if (machineInputAnimator != null && !string.IsNullOrEmpty(machineStartTrigger) && !string.IsNullOrEmpty(machineStopTrigger))
		{
			if (isReceiving)
			{
				machineInputAnimator.SetTrigger(machineStartTrigger);
			}
			else
			{
				machineInputAnimator.SetTrigger(machineStopTrigger);
			}
		}
	}

	private void ApplyIdleState(bool turnOn)
	{
		if (idleFadeCoroutine != null)
		{
			StopCoroutine(idleFadeCoroutine);
		}
		idleFadeCoroutine = StartCoroutine(FadeLoopingSource(idleSource, idleClip, turnOn, turnOn ? 0.15f : 0.15f, 1f));
	}

	private void SetVFXState(ParticleSystem ps, bool turnOn)
	{
		if (ps == null)
		{
			return;
		}
		if (turnOn)
		{
			if (!ps.isPlaying)
			{
				ps.Play(withChildren: true);
			}
		}
		else if (ps.isPlaying)
		{
			ps.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}

	private void ApplyItemProduced()
	{
		if (!(outputSource == null) && outputClips != null && outputClips.Count != 0)
		{
			AudioClip audioClip = outputClips[UnityEngine.Random.Range(0, outputClips.Count)];
			if (!(audioClip == null))
			{
				outputSource.PlayOneShot(audioClip);
			}
		}
	}

	private IEnumerator FadeLoopingSource(AudioSource src, AudioClip clip, bool turnOn, float duration, float targetVolume)
	{
		if (src == null)
		{
			yield break;
		}
		float baseVolume = GetBaseVolume(src);
		float num = Mathf.Max(0f, baseVolume * Mathf.Max(0f, targetVolume));
		if (turnOn)
		{
			if (clip != null && src.clip != clip)
			{
				src.clip = clip;
			}
			src.loop = true;
			float from = 0f;
			float to = num;
			src.volume = 0f;
			if (!src.isPlaying)
			{
				src.Play();
			}
			float t = 0f;
			while (t < duration)
			{
				t += Time.deltaTime;
				float t2 = ((duration <= 0f) ? 1f : Mathf.Clamp01(t / duration));
				src.volume = Mathf.Lerp(from, to, t2);
				yield return null;
			}
			src.volume = to;
		}
		else
		{
			float t = src.volume;
			float to = 0f;
			float from = 0f;
			while (from < duration)
			{
				from += Time.deltaTime;
				float t3 = ((duration <= 0f) ? 1f : Mathf.Clamp01(from / duration));
				src.volume = Mathf.Lerp(t, to, t3);
				yield return null;
			}
			src.volume = 0f;
			if (src.isPlaying)
			{
				src.Stop();
			}
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		DebugLog($"Saving machine state (recipe: {selectedRecipeIndex}, paused: {isProductionPaused}, items: {storedItems.Count})");
		MachineSaveData machineSaveData = new MachineSaveData
		{
			selectedRecipeIndex = selectedRecipeIndex,
			isProductionPaused = isProductionPaused,
			productionAmount = productionAmount,
			isInfiniteMode = isInfiniteMode,
			storedItems = new List<ItemStackData>()
		};
		foreach (ItemStack storedItem in storedItems)
		{
			if (storedItem.IsValid())
			{
				machineSaveData.storedItems.Add(new ItemStackData(storedItem.itemId, storedItem.count));
			}
		}
		return machineSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		DebugLog("Loading machine state for: " + UniqueMachineId);
		if (!(value is MachineSaveData machineSaveData))
		{
			Debug.LogWarning("[T_Machine] OnLoad - Invalid data type for machine: " + UniqueMachineId);
			return Task.CompletedTask;
		}
		NetworkselectedRecipeIndex = machineSaveData.selectedRecipeIndex;
		NetworkisProductionPaused = machineSaveData.isProductionPaused;
		NetworkproductionAmount = machineSaveData.productionAmount;
		NetworkisInfiniteMode = machineSaveData.isInfiniteMode;
		storedItems.Clear();
		foreach (ItemStackData storedItem in machineSaveData.storedItems)
		{
			if (!string.IsNullOrEmpty(storedItem.itemId) && storedItem.count > 0)
			{
				storedItems.Add(new ItemStack(storedItem.itemId, storedItem.count));
			}
		}
		UpdateSelectedRecipeProductItemId();
		UpdateAmountDisplay();
		if (!isProductionPaused)
		{
			pendingStartAfterLoad = true;
		}
		DebugLog($"Load complete (recipe: {machineSaveData.selectedRecipeIndex}, paused: {machineSaveData.isProductionPaused}, items: {machineSaveData.storedItems.Count}, pendingStart: {pendingStartAfterLoad})");
		return Task.CompletedTask;
	}

	private IEnumerator Co_StartProductionAfterLoad()
	{
		yield return null;
		yield return null;
		TryStartProductionIfReady();
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		StartCoroutine(WaitAndFetchMaxItemCount());
		StartCoroutine(Co_SubscribeToSaveSystem());
		UpdateSelectedRecipeProductItemId();
		UpdateAmountDisplay();
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.AddListener(OnLoadingFinished);
		}
	}

	private IEnumerator Co_SubscribeToSaveSystem()
	{
		while (BuildingObj == null || string.IsNullOrEmpty(BuildingObj.UniqueBuildingId))
		{
			yield return null;
		}
		SaveLoadManager.Subscribe(this, 45);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		SaveLoadManager.Unsubscribe(this);
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.RemoveListener(OnLoadingFinished);
		}
	}

	[Server]
	private void OnLoadingFinished(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Machine::OnLoadingFinished(LoadingType)' called when server was not active");
		}
		else if (pendingStartAfterLoad)
		{
			pendingStartAfterLoad = false;
			DebugLog("Loading finished, resuming production after load");
			StartCoroutine(Co_StartProductionAfterLoad());
		}
	}

	public T_Machine()
	{
		InitSyncObject(storedItems);
		_Mirror_SyncVarHookDelegate_selectedRecipeIndex = OnSelectedRecipeChanged;
		_Mirror_SyncVarHookDelegate_selectedRecipeProductItemId = OnSelectedRecipeProductItemIdChanged;
		_Mirror_SyncVarHookDelegate_isProducing = OnProductionStateChanged;
		_Mirror_SyncVarHookDelegate_isProductionPaused = OnProductionPausedChanged;
		_Mirror_SyncVarHookDelegate_productionAmount = OnProductionAmountChanged;
		_Mirror_SyncVarHookDelegate_isInfiniteMode = OnInfiniteModeChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestEventSync__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			return;
		}
		int num;
		int num2;
		if (selectedRecipeIndex >= 0)
		{
			num = ((selectedRecipeIndex < acceptedRecipes.Count) ? 1 : 0);
			if (num != 0)
			{
				num2 = ((acceptedRecipes[selectedRecipeIndex] != null) ? 1 : 0);
				goto IL_0040;
			}
		}
		else
		{
			num = 0;
		}
		num2 = 0;
		goto IL_0040;
		IL_0040:
		bool flag = (byte)num2 != 0;
		bool flag2 = flag && !isProductionPaused && HasEnoughResources();
		bool recipeActive = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProductionPaused;
		bool recipeDeactive = num == 0 || !flag || isProductionPaused;
		bool machineWorking = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProductionPaused && (isProducing || flag2) && (productionAmount > 0 || isInfiniteMode);
		bool machineStopped = ((uint)num & (flag ? 1u : 0u)) != 0 && !isProducing && (isProductionPaused || !flag2) && (productionAmount <= 0 || !isInfiniteMode);
		TargetSyncEventStates(sender, recipeActive, recipeDeactive, machineWorking, machineStopped);
	}

	protected static void InvokeUserCode_CmdRequestEventSync__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestEventSync called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdRequestEventSync__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(NetworkConnection target, bool recipeActive, bool recipeDeactive, bool machineWorking, bool machineStopped)
	{
		lastRecipeActiveState = recipeActive;
		lastRecipeDeactiveState = recipeDeactive;
		lastMachineWorkingState = machineWorking;
		lastMachineStoppedState = machineStopped;
		if (recipeActive)
		{
			ApplyRecipeActiveVisuals(isActive: true);
			OnRecipeActive?.Invoke();
		}
		if (recipeDeactive)
		{
			ApplyRecipeActiveVisuals(isActive: false);
			OnRecipeDeactive?.Invoke();
		}
		if (machineWorking)
		{
			ApplyMachineWorkingState(isWorking: true);
			OnMachineWorking?.Invoke();
		}
		if (machineStopped)
		{
			ApplyMachineWorkingState(isWorking: false);
			OnMachineStopped?.Invoke();
		}
	}

	protected static void InvokeUserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetSyncEventStates called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(null, reader.ReadBool(), reader.ReadBool(), reader.ReadBool(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdSelectRecipe__Int32(int recipeIndex)
	{
		ServerSelectRecipe(recipeIndex);
	}

	protected static void InvokeUserCode_CmdSelectRecipe__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSelectRecipe called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdSelectRecipe__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(uint sackNetId, NetworkConnectionToClient sender)
	{
		ServerTransferItemsFromSack(sackNetId, sender);
	}

	protected static void InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTransferItemsFromSack called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkConnection target)
	{
		if (!(GameManager.Instance?.localEquipments == null))
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcClearPlayerPickupItem called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcClearPlayerPickupItem__NetworkConnection(null);
		}
	}

	protected void UserCode_CmdTransferPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender)
	{
		ServerTransferPartialItemsFromSack(sackNetId, itemId, amount, sender);
	}

	protected static void InvokeUserCode_CmdTransferPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTransferPartialItemsFromSack called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdTransferPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(reader.ReadVarUInt(), reader.ReadString(), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_CmdAddItems__String_005B_005D__Int32_005B_005D(string[] itemIds, int[] counts)
	{
		ServerAddItems(itemIds, counts);
	}

	protected static void InvokeUserCode_CmdAddItems__String_005B_005D__Int32_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddItems called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdAddItems__String_005B_005D__Int32_005B_005D(GeneratedNetworkCode._Read_System_002EString_005B_005D(reader), GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader));
		}
	}

	protected void UserCode_CmdStartProduction()
	{
		ServerStartProduction();
	}

	protected static void InvokeUserCode_CmdStartProduction(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartProduction called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdStartProduction();
		}
	}

	protected void UserCode_CmdStopProduction()
	{
		ServerStopProduction();
	}

	protected static void InvokeUserCode_CmdStopProduction(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStopProduction called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdStopProduction();
		}
	}

	protected void UserCode_CmdSendAllItemsToStorage()
	{
		ServerSendAllItemsToStorage();
	}

	protected static void InvokeUserCode_CmdSendAllItemsToStorage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSendAllItemsToStorage called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdSendAllItemsToStorage();
		}
	}

	protected void UserCode_RpcNotifyStorageChanged()
	{
		StartCoroutine(DelayedStorageChangedNotification());
	}

	protected static void InvokeUserCode_RpcNotifyStorageChanged(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyStorageChanged called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcNotifyStorageChanged();
		}
	}

	protected void UserCode_RpcRecipeActive()
	{
		lastRecipeActiveState = true;
		lastRecipeDeactiveState = false;
		ApplyRecipeActiveVisuals(isActive: true);
		OnRecipeActive?.Invoke();
	}

	protected static void InvokeUserCode_RpcRecipeActive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRecipeActive called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcRecipeActive();
		}
	}

	protected void UserCode_RpcRecipeDeactive()
	{
		lastRecipeActiveState = false;
		lastRecipeDeactiveState = true;
		ApplyRecipeActiveVisuals(isActive: false);
		OnRecipeDeactive?.Invoke();
	}

	protected static void InvokeUserCode_RpcRecipeDeactive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRecipeDeactive called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcRecipeDeactive();
		}
	}

	protected void UserCode_RpcMachineWorking()
	{
		lastMachineWorkingState = true;
		lastMachineStoppedState = false;
		ApplyMachineWorkingState(isWorking: true);
		OnMachineWorking?.Invoke();
	}

	protected static void InvokeUserCode_RpcMachineWorking(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcMachineWorking called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcMachineWorking();
		}
	}

	protected void UserCode_RpcMachineStopped()
	{
		lastMachineWorkingState = false;
		lastMachineStoppedState = true;
		ApplyMachineWorkingState(isWorking: false);
		OnMachineStopped?.Invoke();
	}

	protected static void InvokeUserCode_RpcMachineStopped(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcMachineStopped called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcMachineStopped();
		}
	}

	protected void UserCode_RpcItemReceived()
	{
		ApplyItemReceivingState(isReceiving: true);
		OnItemReceived?.Invoke();
	}

	protected static void InvokeUserCode_RpcItemReceived(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcItemReceived called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcItemReceived();
		}
	}

	protected void UserCode_RpcItemStopped()
	{
		ApplyItemReceivingState(isReceiving: false);
		OnItemStopped?.Invoke();
	}

	protected static void InvokeUserCode_RpcItemStopped(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcItemStopped called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcItemStopped();
		}
	}

	protected void UserCode_RpcItemProduced()
	{
		ApplyItemProduced();
		OnItemProduced?.Invoke();
	}

	protected static void InvokeUserCode_RpcItemProduced(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcItemProduced called on server.");
		}
		else
		{
			((T_Machine)obj).UserCode_RpcItemProduced();
		}
	}

	protected void UserCode_CmdIncreaseAmount__Int32(int delta)
	{
		ServerIncreaseAmount(delta);
	}

	protected static void InvokeUserCode_CmdIncreaseAmount__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdIncreaseAmount called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdIncreaseAmount__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdDecreaseAmount__Int32(int delta)
	{
		ServerDecreaseAmount(delta);
	}

	protected static void InvokeUserCode_CmdDecreaseAmount__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDecreaseAmount called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdDecreaseAmount__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdSetMaxAmount()
	{
		ServerSetMaxAmount();
	}

	protected static void InvokeUserCode_CmdSetMaxAmount(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetMaxAmount called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdSetMaxAmount();
		}
	}

	protected void UserCode_CmdToggleInfiniteMode()
	{
		ServerToggleInfiniteMode();
	}

	protected static void InvokeUserCode_CmdToggleInfiniteMode(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdToggleInfiniteMode called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdToggleInfiniteMode();
		}
	}

	protected void UserCode_CmdDisableInfiniteMode()
	{
		ServerDisableInfiniteMode();
	}

	protected static void InvokeUserCode_CmdDisableInfiniteMode(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDisableInfiniteMode called on client.");
		}
		else
		{
			((T_Machine)obj).UserCode_CmdDisableInfiniteMode();
		}
	}

	static T_Machine()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdRequestEventSync(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestEventSync__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdSelectRecipe(System.Int32)", InvokeUserCode_CmdSelectRecipe__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdTransferPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTransferPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdAddItems(System.String[],System.Int32[])", InvokeUserCode_CmdAddItems__String_005B_005D__Int32_005B_005D, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdStartProduction()", InvokeUserCode_CmdStartProduction, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdStopProduction()", InvokeUserCode_CmdStopProduction, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdSendAllItemsToStorage()", InvokeUserCode_CmdSendAllItemsToStorage, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdIncreaseAmount(System.Int32)", InvokeUserCode_CmdIncreaseAmount__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdDecreaseAmount(System.Int32)", InvokeUserCode_CmdDecreaseAmount__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdSetMaxAmount()", InvokeUserCode_CmdSetMaxAmount, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdToggleInfiniteMode()", InvokeUserCode_CmdToggleInfiniteMode, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Machine), "System.Void T_Machine::CmdDisableInfiniteMode()", InvokeUserCode_CmdDisableInfiniteMode, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcNotifyStorageChanged()", InvokeUserCode_RpcNotifyStorageChanged);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcRecipeActive()", InvokeUserCode_RpcRecipeActive);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcRecipeDeactive()", InvokeUserCode_RpcRecipeDeactive);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcMachineWorking()", InvokeUserCode_RpcMachineWorking);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcMachineStopped()", InvokeUserCode_RpcMachineStopped);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcItemReceived()", InvokeUserCode_RpcItemReceived);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcItemStopped()", InvokeUserCode_RpcItemStopped);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcItemProduced()", InvokeUserCode_RpcItemProduced);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::TargetSyncEventStates(Mirror.NetworkConnection,System.Boolean,System.Boolean,System.Boolean,System.Boolean)", InvokeUserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Machine), "System.Void T_Machine::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(selectedRecipeIndex);
			writer.WriteString(selectedRecipeProductItemId);
			writer.WriteBool(isProducing);
			writer.WriteBool(isProductionPaused);
			writer.WriteFloat(productionStartTime);
			writer.WriteFloat(currentProductionTime);
			writer.WriteString(producingItemId);
			writer.WriteVarInt(productionAmount);
			writer.WriteBool(isInfiniteMode);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(selectedRecipeIndex);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteString(selectedRecipeProductItemId);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isProducing);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(isProductionPaused);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteFloat(productionStartTime);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteFloat(currentProductionTime);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteString(producingItemId);
		}
		if ((syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteVarInt(productionAmount);
		}
		if ((syncVarDirtyBits & 0x100L) != 0L)
		{
			writer.WriteBool(isInfiniteMode);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref selectedRecipeIndex, _Mirror_SyncVarHookDelegate_selectedRecipeIndex, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref selectedRecipeProductItemId, _Mirror_SyncVarHookDelegate_selectedRecipeProductItemId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref isProducing, _Mirror_SyncVarHookDelegate_isProducing, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isProductionPaused, _Mirror_SyncVarHookDelegate_isProductionPaused, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref productionStartTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref currentProductionTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref producingItemId, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref productionAmount, _Mirror_SyncVarHookDelegate_productionAmount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isInfiniteMode, _Mirror_SyncVarHookDelegate_isInfiniteMode, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref selectedRecipeIndex, _Mirror_SyncVarHookDelegate_selectedRecipeIndex, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref selectedRecipeProductItemId, _Mirror_SyncVarHookDelegate_selectedRecipeProductItemId, reader.ReadString());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isProducing, _Mirror_SyncVarHookDelegate_isProducing, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isProductionPaused, _Mirror_SyncVarHookDelegate_isProductionPaused, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref productionStartTime, null, reader.ReadFloat());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentProductionTime, null, reader.ReadFloat());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref producingItemId, null, reader.ReadString());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref productionAmount, _Mirror_SyncVarHookDelegate_productionAmount, reader.ReadVarInt());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInfiniteMode, _Mirror_SyncVarHookDelegate_isInfiniteMode, reader.ReadBool());
		}
	}
}

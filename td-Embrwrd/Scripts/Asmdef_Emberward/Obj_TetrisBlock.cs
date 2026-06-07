using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_TetrisBlock : MonoBehaviour, IPlaceable, IInteractable
{
	public class InstalledRuneData
	{
		public eItemType itemType;

		public ARune rune;

		public int index;

		public InstalledRuneData(eItemType itemType, ARune rune, int index)
		{
		}
	}

	public enum eTetrisSpawnStyle
	{
		NORMAL = 0,
		FALL_FROM_SKY = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChangeMaterial_BackFromStone_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_ChangeMaterial_BackFromStone_003Ed__75(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChangeMaterial_ToStone_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_ChangeMaterial_ToStone_003Ed__73(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChangeToLavaBlock_003Ed__119 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_ChangeToLavaBlock_003Ed__119(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_FreezeBlock_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_FreezeBlock_003Ed__108(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_PartialFreezeBlock_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_PartialFreezeBlock_003Ed__106(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlacementEffect_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public Obj_TetrisBlock _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_PlacementEffect_003Ed__70(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Recall_003Ed__96 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool isForceRecall;

		public Obj_TetrisBlock _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Recall_003Ed__96(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_RemoveBlocks_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<Vector3Int> list_Blocks;

		private float _003Cinterval_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_RemoveBlocks_003Ed__58(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_RevertFromLava_003Ed__121 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private Color _003CblockColor_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_RevertFromLava_003Ed__121(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_SetTerritory_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		public int maxRange;

		public bool forceUpdateTerritory;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_SetTerritory_003Ed__60(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_UnfreezeBlock_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_UnfreezeBlock_003Ed__111(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private PanelSettingData panelSettingData;

	[SerializeField]
	[Header("物品類型")]
	protected eItemType itemType;

	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected Transform node_RuneObjects;

	[SerializeField]
	protected List<Collider> list_Colliders;

	[SerializeField]
	[Header("放在上面的砲塔")]
	protected List<ABaseTower> list_TowerOnBlock;

	[SerializeField]
	private ParticleSystem particle_PlacementEffect;

	[SerializeField]
	[Header("其他可以將方塊鎖住的物件，例如敵方砲塔")]
	protected List<GameObject> list_ExtraBlockLockers;

	protected List<Renderer> list_BlockRenderers;

	protected bool isFirstRoundAfterPlacement;

	protected bool isOutlineOn;

	protected bool isLockedByPowerGrid;

	protected bool canPlaceTower;

	protected bool isFrozen;

	protected bool isLava;

	protected Material material_Runtime;

	protected TetrisCardData tetrisCardData;

	protected List<ARune> list_InstalledRunes;

	protected List<eItemType> list_InstalledRuneTypes;

	protected bool isSpawnFinished;

	protected bool isEnlarged;

	protected bool isTerritorySet;

	protected int spinWhilePlacing;

	protected int roundSincePlacement;

	protected int roundSinceFreezeStart;

	protected int destroyedBlockCount;

	public Action<Obj_TetrisBlock> OnPlacement;

	public Action<Obj_TetrisBlock> OnPlacementFinished;

	public Action<Obj_TetrisBlock> OnRemove;

	public Action<Obj_TetrisBlock, Vector3Int> OnRemoveSingleBlock;

	private Dictionary<Collider, Vector3> dic_BlockPositions;

	private List<APowerGrid> list_BuffTilesCreatedByRune;

	private Vector3 cameraPosOnRecallStart;

	private List<Collider> list_ColliderRemovedByChisel;

	private List<APowerGrid> list_BuffTilesRemovedByChisel;

	private bool isMouseDown;

	private float mouseDownTimer;

	private int blockClickSndIndex;

	private bool doCheckRightClickRecall;

	private Vector3 rightClickPos;

	private Dictionary<Collider, Renderer> dict_EnlargedColliderRenderer;

	private List<List<Collider>> list_EnlargedColliderGroup;

	private Coroutine partialFreezeCoroutine;

	private List<Material> list_OriginalMaterials;

	private GameObject vfx_Lava;

	private HashSet<Vector3Int> set_ElectrifiedPositions;

	public PanelSettingData SettingData => null;

	public Transform Node_RuneObjects => null;

	public ParticleSystem Particle_PlacementEffect => null;

	public TetrisCardData TetrisCardData => null;

	public bool IsEnlarged => false;

	private void Awake()
	{
	}

	protected void OnEnable()
	{
	}

	protected void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void PreSpawn(TetrisCardData cardData)
	{
	}

	private void Effect_BlessedChisel()
	{
	}

	private void Effect_BlessedChisel_VFX()
	{
	}

	public void Spawn(TetrisCardData cardData, eTetrisSpawnStyle spawnStyle = eTetrisSpawnStyle.NORMAL)
	{
	}

	private void AprilFools_CalculateLineDisappear()
	{
	}

	public List<Vector3Int> CheckLine(Vector3 point, int count, ref List<Vector3Int> list_CheckedPositions)
	{
		return null;
	}

	private void RemoveBlocks(List<Vector3Int> list_Blocks)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RemoveBlocks_003Ed__58))]
	public IEnumerator CR_RemoveBlocks(List<Vector3Int> list_Blocks)
	{
		return null;
	}

	public void SetTerritory(int maxRange, bool forceUpdateTerritory = false)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SetTerritory_003Ed__60))]
	private IEnumerator CR_SetTerritory(int maxRange, bool forceUpdateTerritory = false)
	{
		return null;
	}

	private void AddTerritoryArea(int range)
	{
	}

	private void RemoveTerritory()
	{
	}

	private void InstallRunes()
	{
	}

	private void ActivateRunes()
	{
	}

	public void RegisterBuffTileFromRune(APowerGrid buffTile)
	{
	}

	public void UnregisterBuffTileFromRune(APowerGrid buffTile)
	{
	}

	public Vector3 GetBlockWorldPosition(int index)
	{
		return default(Vector3);
	}

	public Vector3 GetBlockLocalPosition(int index)
	{
		return default(Vector3);
	}

	public int GetBlockCount()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_PlacementEffect_003Ed__70))]
	private IEnumerator CR_PlacementEffect(float delay)
	{
		return null;
	}

	protected void OnBattleStart()
	{
	}

	public void SetNotRecallable(bool forceUpdateTerritory = false)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeMaterial_ToStone_003Ed__73))]
	private IEnumerator CR_ChangeMaterial_ToStone()
	{
		return null;
	}

	public void SetRecallable()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeMaterial_BackFromStone_003Ed__75))]
	private IEnumerator CR_ChangeMaterial_BackFromStone()
	{
		return null;
	}

	public void ToggleOutline(bool isOn)
	{
	}

	public void OnChildMouseEnter()
	{
	}

	public void OnChildMouseExit()
	{
	}

	public void OnChildMouseDown(int key)
	{
	}

	public void OnChildMouseUp(int key)
	{
	}

	public void Remove()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	public void DestroySingleBlock(Vector3 position, bool doRecalculateGraph = true, bool doUnregister = true, Collider specificCollider = null)
	{
	}

	public bool IsRecallAble()
	{
		return false;
	}

	public bool IsLockedByAnything()
	{
		return false;
	}

	public bool DoShowRecallTooltip()
	{
		return false;
	}

	public void RegisterBlockLocker(GameObject obj)
	{
	}

	public void UnregisterBlockLocker(GameObject obj)
	{
	}

	public bool IslockedByAnyBlockLocker()
	{
		return false;
	}

	public void Recall(bool isForceRecall = false)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Recall_003Ed__96))]
	private IEnumerator CR_Recall(bool isForceRecall = false)
	{
		return null;
	}

	private void OnRequestStartPlacement(GameObject prefab, Action callback, bool canBuildContinuously)
	{
	}

	public void RegisterTowerOnTop(ABaseTower tower)
	{
	}

	public void UnregisterTowerOnTop(ABaseTower tower)
	{
	}

	public void SetEnlarged()
	{
	}

	public bool IsFrozen()
	{
		return false;
	}

	public void PartialFreezeBlock()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PartialFreezeBlock_003Ed__106))]
	private IEnumerator CR_PartialFreezeBlock()
	{
		return null;
	}

	public void FreezeBlock()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FreezeBlock_003Ed__108))]
	private IEnumerator CR_FreezeBlock()
	{
		return null;
	}

	public void UnfreezeBlock()
	{
	}

	public void ResetFreezeCounter()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_UnfreezeBlock_003Ed__111))]
	private IEnumerator CR_UnfreezeBlock()
	{
		return null;
	}

	private void ModifyMaterial(string key, float level)
	{
	}

	public void OverrideBlockMaterial(Material material)
	{
	}

	public void RestoreMaterial()
	{
	}

	public bool IsLava()
	{
		return false;
	}

	public void ChangeToLavaBlock()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeToLavaBlock_003Ed__119))]
	private IEnumerator CR_ChangeToLavaBlock()
	{
		return null;
	}

	public void RevertFromLava()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RevertFromLava_003Ed__121))]
	private IEnumerator CR_RevertFromLava()
	{
		return null;
	}

	public void Electrify(Vector3 position)
	{
	}

	public void UpdateElectifyMaterial()
	{
	}

	public void Unelectrify(Vector3 position)
	{
	}

	public Renderer GetBlockRendererByPosition(Vector3Int position)
	{
		return null;
	}

	public bool IsTowerAttachable()
	{
		return false;
	}

	public bool IsAnyTowerOnBlock()
	{
		return false;
	}

	public bool IsPercentageOfBlockInRange(float percentage, Vector3 position, float range)
	{
		return false;
	}

	public List<Collider> GetCollisionColliders()
	{
		return null;
	}

	public List<Collider> GetPlacementColliders()
	{
		return null;
	}

	public ePlaceableType GetPlaceableType()
	{
		return default(ePlaceableType);
	}

	public Vector3 GetPlacementOffset()
	{
		return default(Vector3);
	}

	public void SwitchToPlacementMode(object data)
	{
	}

	public void OnPlacementProc()
	{
	}

	public void ToggleAllColliders(bool isOn)
	{
	}

	public void SplitColliders()
	{
	}

	public Collider[] SplitCollider(BoxCollider originalCollider)
	{
		return null;
	}

	public void OnPlayerControlEnterProc()
	{
	}

	public void OnPlayerControlExitProc()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}

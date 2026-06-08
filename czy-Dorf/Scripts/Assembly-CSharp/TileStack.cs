using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Dorfromantik;
using UnityEngine;

public class TileStack : MonoBehaviour
{
	private sealed class _003CAddRandomTilesWithDelay_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TileStack _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CAddRandomTilesWithDelay_003Ed__56(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TileStack tileStack = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				tileStack.addingRemainingTiles = true;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (tileStack.remainingTilesToAdd > 0)
			{
				tileStack.AddRandomTile();
				tileStack.OnSingleTileAdded?.Invoke();
				tileStack.remainingTilesToAdd--;
				AudioManager.Instance.PlayGlobalSound(tileStack.tileAddedSound);
				_003C_003E2__current = new WaitForSeconds(tileStack.tileGainedDelay);
				_003C_003E1__state = 1;
				return true;
			}
			tileStack.DisplayStack(topTileChanged: false);
			tileStack.addingRemainingTiles = false;
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private Vector3 stackedTileOffset = new Vector3(0f, 0.08f, 0f);

	[SerializeField]
	private Vector3 stack2TileOffset = new Vector3(0f, 0.5f, 0f);

	[SerializeField]
	private Vector3 stack1TileOffset = new Vector3(0f, 0.5f, 0f);

	[SerializeField]
	private Vector3 stack0TileOffset = new Vector3(0f, 0.9f, 0f);

	[SerializeField]
	private Vector3 currentTileRotation = new Vector3(-20f, 0f, 0f);

	[SerializeField]
	private Vector3 undoTileOffset = new Vector3(0f, 1.33f, -0.4f);

	[SerializeField]
	private int initialTileCount = 25;

	[SerializeField]
	private List<Tile> initialTiles;

	[SerializeField]
	private Biome stackBiome;

	[SerializeField]
	private float stackDelayPerTile = 0.1f;

	[SerializeField]
	private float placementRefillDelay;

	[SerializeField]
	private float advancementAnimationDuration = 0.5f;

	[SerializeField]
	private float tileGainedDelay = 0.15f;

	[SerializeField]
	private TilePlacer tilePlacer;

	[SerializeField]
	private CameraRotator cameraRotator;

	[SerializeField]
	private Transform stackedTilesContainer;

	[SerializeField]
	private InfiniteTileStack infiniteTileStack;

	[SerializeField]
	private ElementGroupManager elementGroupManager;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private AudioClipOptions tileAddedSound;

	[SerializeField]
	private List<Tile> stack = new List<Tile>();

	private int remainingTilesToAdd;

	private bool addingRemainingTiles;

	private bool locked;

	private bool stackCollapsed;

	private bool _003CIsInfinite_003Ek__BackingField;

	public int Height => stack.Count;

	public int RawHeight => stack.Count + remainingTilesToAdd;

	public bool IsInfinite
	{
		get
		{
			return _003CIsInfinite_003Ek__BackingField;
		}
		private set
		{
			_003CIsInfinite_003Ek__BackingField = value;
		}
	}

	public event Action OnAdvanced;

	public event Action OnInitialized;

	public event Action OnSingleTileAdded;

	public event Action<int> OnTilesAdded;

	private void Start()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += Advance;
		rewardSystem.OnTilesGained += AddQuestRewardTiles;
		tilePlacer.OnTileDiscarded += AdvanceAndRefill;
		tilePlacer.OnCurrentTileRotated += RotateTopTile;
		Setup();
	}

	private void AddQuestRewardTiles(int count)
	{
		AddRandomTiles(count, useDelay: true);
	}

	private void OnEnable()
	{
		if (addingRemainingTiles)
		{
			StartCoroutine(AddRandomTilesWithDelay());
		}
	}

	private void AdvanceAndRefill(bool refillStack)
	{
		if (refillStack)
		{
			AddRandomTiles(1);
		}
		Advance(ignoreLocked: true);
	}

	public void Setup()
	{
		stack = new List<Tile>(initialTiles);
		stack = Shuffle(stack);
		AddRandomTiles(initialTileCount);
		DisplayStack();
		this.OnInitialized?.Invoke();
	}

	public void AddRandomTiles(int count, bool useDelay = false)
	{
		if (IsInfinite && RawHeight >= 40)
		{
			return;
		}
		if (useDelay)
		{
			remainingTilesToAdd += count;
			if (!addingRemainingTiles)
			{
				StartCoroutine(AddRandomTilesWithDelay());
			}
			this.OnTilesAdded?.Invoke(count);
		}
		else
		{
			for (int i = 0; i < count; i++)
			{
				AddRandomTile();
			}
		}
	}

	private IEnumerator AddRandomTilesWithDelay()
	{
		return new _003CAddRandomTilesWithDelay_003Ed__56(0)
		{
			_003C_003E4__this = this
		};
	}

	private void AddRandomTile()
	{
		if (stack.Count > settingsRouter.defaultSettings.defaultVisibleTileStackHeight)
		{
			stack.Add(null);
			return;
		}
		Tile tile = tileGenerator.GenerateBaseTile();
		tile.transform.parent = stackedTilesContainer;
		tile.transform.localPosition = Vector3.zero;
		tile.transform.localRotation = Quaternion.identity;
		BiomeManager.ApplyBiomeToTile(tile, stackBiome);
		stack.Add(tile);
		tile.gameObject.SetActive(value: false);
	}

	public void Advance(Tile placedTile, bool advanceStack = true)
	{
		if (advanceStack)
		{
			Advance();
		}
	}

	public void Advance(bool ignoreLocked = false)
	{
		if (ignoreLocked || (!locked && (bool)stack[0]))
		{
			stack[0].DestroyTile();
			stack.RemoveAt(0);
		}
		DisplayStack();
		if (!ignoreLocked && locked)
		{
			stack[0].InitializeSeed();
			tilePlacer.CurrentTile.RotateTo(stack[0].RotationIndex);
		}
		this.OnAdvanced?.Invoke();
		if (stack.Count == 0)
		{
			rewardSystem.GameOver(animate: true, setHighscore: true);
		}
	}

	public void DisplayStack(bool topTileChanged = true)
	{
		int num = 0;
		for (int num2 = settingsRouter.defaultSettings.defaultVisibleTileStackHeight - 1; num2 >= 3; num2--)
		{
			if (num2 < stack.Count)
			{
				if (stack[num2] == null)
				{
					stack[num2] = tileGenerator.GenerateBaseTile();
					stack[num2].transform.parent = stackedTilesContainer;
					stack[num2].transform.localPosition = Vector3.zero;
					stack[num2].transform.localRotation = Quaternion.identity;
					BiomeManager.ApplyBiomeToTile(stack[num2], stackBiome);
				}
				Vector3 endValue = num * stackedTileOffset;
				stack[num2].transform.parent = stackedTilesContainer;
				ShortcutExtensions.DOKill(stack[num2].transform);
				TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOLocalMove(stack[num2].transform, endValue, advancementAnimationDuration), stackCollapsed ? placementRefillDelay : (stackDelayPerTile * 2f + placementRefillDelay));
				num++;
				stack[num2].ChangeTileState(TileState.stacked);
				stack[num2].gameObject.SetActive(value: true);
			}
		}
		if (stack.Count > 2)
		{
			if (!stack[2].Generated)
			{
				stack[2] = GeneratePreviewStackTile(stack[2]);
			}
			stack[2].transform.parent = (stackCollapsed ? stackedTilesContainer : base.transform);
			Vector3 endValue2 = (stackCollapsed ? (num * stackedTileOffset) : (num * stackedTileOffset + stack2TileOffset));
			ShortcutExtensions.DOKill(stack[2].transform);
			TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOLocalMove(stack[2].transform, endValue2, advancementAnimationDuration), stackCollapsed ? placementRefillDelay : (stackDelayPerTile * 2f + placementRefillDelay));
			stack[2].ChangeTileState((!stackCollapsed) ? TileState.stackPreview : TileState.stacked);
			stack[2].gameObject.SetActive(value: true);
		}
		if (stack.Count > 1)
		{
			if (!stack[1].Generated)
			{
				stack[1] = GeneratePreviewStackTile(stack[1]);
			}
			stack[1].transform.parent = (stackCollapsed ? stackedTilesContainer : base.transform);
			Vector3 endValue3 = (stackCollapsed ? ((num + 1) * stackedTileOffset) : (num * stackedTileOffset + stack2TileOffset + stack1TileOffset));
			ShortcutExtensions.DOKill(stack[1].transform);
			TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOLocalMove(stack[1].transform, endValue3, advancementAnimationDuration), stackCollapsed ? placementRefillDelay : (stackDelayPerTile * 1f + placementRefillDelay));
			stack[1].ChangeTileState((!stackCollapsed) ? TileState.stackPreview : TileState.stacked);
			stack[1].gameObject.SetActive(value: true);
		}
		if (stack.Count > 0)
		{
			if (!stack[0].Generated)
			{
				stack[0] = GeneratePreviewStackTile(stack[0]);
			}
			stack[0].transform.parent = (stackCollapsed ? stackedTilesContainer : base.transform);
			Vector3 endValue4 = (stackCollapsed ? ((num + 2) * stackedTileOffset) : (num * stackedTileOffset + stack2TileOffset + stack1TileOffset + stack0TileOffset));
			ShortcutExtensions.DOKill(stack[0].transform);
			TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOLocalMove(stack[0].transform, endValue4, advancementAnimationDuration), stackCollapsed ? placementRefillDelay : placementRefillDelay);
			if (topTileChanged && !stackCollapsed)
			{
				ShortcutExtensions.DOBlendableRotateBy(stack[0].transform, currentTileRotation, advancementAnimationDuration);
			}
			if (stackCollapsed)
			{
				ShortcutExtensions.DOLocalRotate(stack[0].transform, Vector3.zero, advancementAnimationDuration);
			}
			stack[0].SetIsCurrentTile(newIsCurrentTile: true);
			stack[0].ChangeTileState(TileState.topStackPreview);
			stack[0].gameObject.SetActive(value: true);
			if (topTileChanged)
			{
				tilePlacer.SetCurrentTile(stack[0]);
			}
		}
		else
		{
			Debug.Log($"{this} stack count is 0");
			tilePlacer.SetCurrentTile(null);
		}
	}

	private Tile GeneratePreviewStackTile(Tile baseTile)
	{
		Tile tile = tileGenerator.GenerateTile(baseTile);
		if (tile != baseTile)
		{
			tile.transform.position = baseTile.transform.position;
			tile.transform.rotation = baseTile.transform.rotation;
			tile.transform.parent = baseTile.transform.parent;
			baseTile.DestroyTile();
		}
		elementGroupManager.CreateGroupsForTile(tile);
		BiomeManager.ApplyBiomeToTile(tile, stackBiome, null, forceApplyingBiome: true);
		return tile;
	}

	public static List<T> Shuffle<T>(List<T> _list)
	{
		for (int i = 0; i < _list.Count; i++)
		{
			T value = _list[i];
			int index = UnityEngine.Random.Range(i, _list.Count);
			_list[i] = _list[index];
			_list[index] = value;
		}
		return _list;
	}

	private void Update()
	{
		if (stack.Count > 0)
		{
			RotateStack();
			if (!stackCollapsed)
			{
				RotateTopTiles();
			}
		}
	}

	private void RotateStack()
	{
		stackedTilesContainer.localRotation = Quaternion.AngleAxis(0f - cameraRotator.transform.rotation.eulerAngles.y, Vector3.up);
	}

	private void RotateTopTiles()
	{
		if (!stackCollapsed)
		{
			Quaternion quaternion = Quaternion.AngleAxis(0f - cameraRotator.transform.rotation.eulerAngles.y, Vector3.up);
			if (stack.Count > 1)
			{
				stack[1].transform.localRotation = quaternion;
			}
			if (stack.Count > 2)
			{
				stack[2].transform.localRotation = quaternion;
			}
			stack[0].transform.localRotation = Quaternion.Euler(currentTileRotation) * quaternion;
		}
	}

	private void RotateTopTile(int rotationAmount, bool animate)
	{
		if (stack.Count > 0)
		{
			stack[0].Rotate(rotationAmount, animate);
		}
	}

	public Tile ReplaceStackedTile(int stackIndex, Tile newTile, bool randomizeSeed = true, bool generateDuplicate = true)
	{
		Tile tile = stack[stackIndex];
		Tile tile2 = ((!generateDuplicate) ? newTile : (newTile.Generated ? tileGenerator.GenerateDuplicate(newTile) : UnityEngine.Object.Instantiate(newTile)));
		if (randomizeSeed)
		{
			tile2.InitializeSeed();
		}
		tileFactory.InitializePrebuiltTile(tile2);
		stack[stackIndex] = tile2;
		tile2.transform.parent = tile.transform.parent;
		tile2.transform.position = tile.transform.position;
		tile2.transform.rotation = tile.transform.rotation;
		elementGroupManager.CreateGroupsForTile(tile2);
		BiomeManager.ApplyBiomeToTile(tile2, stackBiome);
		DisplayStack(stackIndex == 0);
		tile.DestroyTile();
		return tile2;
	}

	public void InsertTile(int stackIndex, Tile newTile, bool generateDuplicate)
	{
		Tile tile = (generateDuplicate ? tileGenerator.GenerateDuplicate(newTile) : newTile);
		tileFactory.InitializePrebuiltTile(tile);
		if (stack.Count > 0)
		{
			tile.transform.parent = stack[stackIndex].transform.parent;
			tile.transform.SetPositionAndRotation(stack[stackIndex].transform.position + undoTileOffset, stack[stackIndex].transform.rotation);
		}
		else
		{
			tile.transform.parent = base.transform;
			tile.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
		}
		elementGroupManager.CreateGroupsForTile(tile);
		BiomeManager.ApplyBiomeToTile(tile, stackBiome);
		stack.Insert(stackIndex, tile);
		DisplayStack(stackIndex == 0);
		this.OnSingleTileAdded?.Invoke();
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= Advance;
		rewardSystem.OnTilesGained -= AddQuestRewardTiles;
		tilePlacer.OnTileDiscarded -= AdvanceAndRefill;
		tilePlacer.OnCurrentTileRotated -= RotateTopTile;
	}

	public void UndoTileLimitReached()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= Advance;
		rewardSystem.OnTilesGained -= AddQuestRewardTiles;
		tilePlacer.OnTileDiscarded -= AdvanceAndRefill;
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += Advance;
		rewardSystem.OnTilesGained += AddQuestRewardTiles;
		tilePlacer.OnTileDiscarded += AdvanceAndRefill;
		stackCollapsed = false;
		DisplayStack();
	}

	public void TileLimitReached()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= Advance;
		rewardSystem.OnTilesGained -= AddQuestRewardTiles;
		tilePlacer.OnTileDiscarded -= AdvanceAndRefill;
		CollapseTileStack(collapse: true);
		tilePlacer.SetCurrentTile(null);
	}

	private void CollapseTileStack(bool collapse)
	{
		stackCollapsed = collapse;
		DisplayStack(topTileChanged: false);
	}

	public Tile GetStackedTile(int index)
	{
		if (stack.Count <= index)
		{
			return null;
		}
		return stack[index];
	}

	public void SetHeight(int targetStackCount, bool revertGeneratedTileCount = false)
	{
		remainingTilesToAdd = 0;
		if (targetStackCount < stack.Count)
		{
			foreach (Tile item in stack.GetRange(targetStackCount, stack.Count - targetStackCount))
			{
				if (!(item == null))
				{
					if (revertGeneratedTileCount && item.Generated)
					{
						tileGenerator.RevertGeneratedTileCount(item);
					}
					item.DestroyTile();
				}
			}
			stack = stack.GetRange(0, targetStackCount);
			DisplayStack(topTileChanged: false);
		}
		else if (targetStackCount > stack.Count)
		{
			AddRandomTiles(targetStackCount - stack.Count);
			DisplayStack(topTileChanged: false);
		}
		this.OnAdvanced?.Invoke();
	}

	public void Regenerate()
	{
		questManager.Clear();
		elementGroupManager.Clear();
		for (int i = 0; i < 3; i++)
		{
			tileGenerator.RevertGeneratedTileCount(stack[i]);
		}
		DiscardStackedTile(1, replace: true);
		DiscardStackedTile(1, replace: true);
		tilePlacer.DiscardCurrentTile(refillStack: true, initial: true);
	}

	public void DiscardStackedTile(int stackIndex, bool replace)
	{
		stack[stackIndex].DestroyTile();
		stack.RemoveAt(stackIndex);
		if (replace)
		{
			AddRandomTiles(1);
		}
		DisplayStack(stackIndex == 0);
	}

	public List<Tile> GetGeneratedTiles()
	{
		List<Tile> list = new List<Tile>();
		for (int i = 0; i < stack.Count; i++)
		{
			Tile stackedTile = GetStackedTile(i);
			if (!(stackedTile != null) || !stackedTile.Generated)
			{
				break;
			}
			list.Add(stackedTile);
		}
		return list;
	}

	public void LockTileStack(bool shouldBeLocked)
	{
		locked = shouldBeLocked;
		CollapseTileStack(shouldBeLocked);
	}

	public void ToggleLockTileStack()
	{
		locked = !locked;
	}

	public void SetInfinite(bool setInfinite)
	{
		infiniteTileStack.gameObject.SetActive(setInfinite);
		IsInfinite = setInfinite;
	}
}

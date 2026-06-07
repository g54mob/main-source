using System;
using LightTower;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LTLevelController : LevelController
{
	[SerializeField]
	private int levelSizeX = 10;

	[SerializeField]
	private int levelSizeZ = 10;

	[SerializeField]
	private CrystalAltar[] crystalAltars;

	[SerializeField]
	private WeightedRandomSelector<ResourceActivatedGEData> perkBeaconsRecipesT1;

	[SerializeField]
	private WeightedRandomSelector<ResourceActivatedGEData> perkBeaconsRecipesT2;

	[SerializeField]
	private WeightedRandomSelector<ResourceActivatedGEData> perkBeaconsRecipesT3;

	[Header("Dev")]
	[SerializeField]
	private bool createGridFromChildren;

	private int fogUpdatesToSkip = 10;

	private int skippedFogUpdates;

	private Grid grid;

	public Grid Grid
	{
		get
		{
			return grid;
		}
		set
		{
			grid = value;
		}
	}

	public int LevelSizeX
	{
		get
		{
			return levelSizeX;
		}
		set
		{
			levelSizeX = value;
		}
	}

	public int LevelSizeZ
	{
		get
		{
			return levelSizeZ;
		}
		set
		{
			levelSizeZ = value;
		}
	}

	public DayNightCycle DayNightCycle { get; set; }

	public CrystalAltar[] CrystalAltars
	{
		get
		{
			return crystalAltars;
		}
		set
		{
			crystalAltars = value;
		}
	}

	public WeightedRandomSelector<ResourceActivatedGEData> PerkBeaconsRecipesT1 => perkBeaconsRecipesT1;

	public WeightedRandomSelector<ResourceActivatedGEData> PerkBeaconsRecipesT2 => perkBeaconsRecipesT2;

	public WeightedRandomSelector<ResourceActivatedGEData> PerkBeaconsRecipesT3 => perkBeaconsRecipesT3;

	public event Action onPathVisibilityUpdated;

	protected override void Awake()
	{
		base.Awake();
		if (createGridFromChildren)
		{
			Grid = new Grid(LevelSizeX, LevelSizeZ, base.transform.GetComponentsInChildren<Tile>());
		}
		perkBeaconsRecipesT1?.ResetSelector();
		perkBeaconsRecipesT2?.ResetSelector();
		perkBeaconsRecipesT3?.ResetSelector();
		DayNightCycle = GetComponentInChildren<DayNightCycle>();
	}

	protected override void Start()
	{
		base.Start();
		int vSyncCount = QualitySettings.vSyncCount;
		QualitySettings.SetQualityLevel((SceneManager.GetActiveScene().buildIndex == 0) ? 4 : 2, applyExpensiveChanges: true);
		QualitySettings.vSyncCount = vSyncCount;
		LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated += OnFogOfWarUpdated;
		OnFogOfWarUpdated(importantUpdate: true);
	}

	private void OnFogOfWarUpdated(bool importantUpdate)
	{
		if (importantUpdate || skippedFogUpdates >= fogUpdatesToSkip)
		{
			grid.UpdatePathTilesVisibility();
			this.onPathVisibilityUpdated?.Invoke();
			skippedFogUpdates = 0;
		}
		else
		{
			skippedFogUpdates++;
		}
	}
}

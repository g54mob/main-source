using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridController : MonoBehaviour
{
	public static GridController Instance;

	private GameControls gameControls;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip rotateSfx;

	[SerializeField]
	private GameObject finishBuildButton;

	[SerializeField]
	private GameObject screenshotButton;

	[SerializeField]
	private List<GridObjectInstance> gridObjects;

	[SerializeField]
	private List<GridObjectInstance> gridObjectInstances;

	[SerializeField]
	private int tileWidthCount;

	[SerializeField]
	private int tileSize;

	[SerializeField]
	private int worldSize;

	[SerializeField]
	private GameObject tilePrefab;

	[SerializeField]
	private Transform tileParent;

	[SerializeField]
	private List<TileObject> tiles;

	[SerializeField]
	private float timeBetweenTileSpawns;

	[SerializeField]
	private int x;

	[SerializeField]
	private int z;

	[SerializeField]
	private List<Vector3> positionsTaken;

	private bool canRotate = true;

	[SerializeField]
	private float yRot;

	private bool rotateTweenFinished = true;

	[SerializeField]
	private Material tileMaterial;

	[SerializeField]
	private Material roofMaterial;

	[SerializeField]
	private Color defaultRoofColor;

	[SerializeField]
	private List<Color> roofColorOptions;

	private int roofColorIndex;

	[SerializeField]
	private Material transparentMaterial;

	private void Awake()
	{
		Instance = this;
		gameControls = new GameControls();
	}

	private void OnEnable()
	{
		gameControls.Enable();
	}

	private void OnDisable()
	{
		gameControls.Disable();
	}

	private void Start()
	{
		gameControls.Game.RotateCW.performed += RotateWorldCW;
		gameControls.Game.RotateCCW.performed += RotateWorldCCW;
		SetRandomRoofColor();
	}

	private void Update()
	{
		finishBuildButton.SetActive(gridObjectInstances.Count + UnityEngine.Object.FindObjectsOfType<TileObject>().Count((TileObject x) => x.IsWater()) > 0);
		screenshotButton.SetActive(gridObjectInstances.Count + UnityEngine.Object.FindObjectsOfType<TileObject>().Count((TileObject x) => x.IsWater()) > 0);
	}

	public bool ExistsOnGrid(Vector3 position)
	{
		return gridObjectInstances.Exists((GridObjectInstance x) => x.gridGameObject.transform.parent.position.x == position.x && x.gridGameObject.transform.parent.position.z == position.z);
	}

	public void AddToGrid(GameObject gridGameObject)
	{
		gridObjectInstances.Add(new GridObjectInstance(gridGameObject));
	}

	public void RemoveFromGrid(Vector3 position)
	{
		gridObjectInstances.Remove(gridObjectInstances.Find((GridObjectInstance x) => x.gridGameObject.transform.parent.position == position));
	}

	public void RemoveWaterFromGrid(Vector3 position)
	{
		gridObjectInstances.Remove(gridObjectInstances.Find((GridObjectInstance x) => x.gridGameObject.transform.position == position));
	}

	public GridObjectInstance GetGridObjectInstance(Vector3 position)
	{
		return gridObjectInstances.Find((GridObjectInstance x) => x.gridGameObject.transform.parent.position == position);
	}

	public List<GridObjectInstance> GetAllGridObjects()
	{
		return gridObjectInstances;
	}

	public void SetTileWidthCount(int widthCount)
	{
		tileWidthCount = widthCount;
		worldSize = tileWidthCount;
	}

	public int GetWorldSize()
	{
		return worldSize;
	}

	public bool CanRotate()
	{
		return canRotate;
	}

	public IEnumerator BuildWorld()
	{
		canRotate = false;
		positionsTaken.Clear();
		timeBetweenTileSpawns = 0.05f / (float)tileWidthCount;
		if (tileWidthCount != 1)
		{
			if (tileWidthCount % 2 != 0)
			{
				switch (WorldSetupPreview.Instance.GetWorldShape())
				{
				case WorldShape.diamond:
				{
					int amountToPlace = 1;
					int posToPlace = amountToPlace - 1;
					bool amountToPlaceIncrease = true;
					for (int x = -tileWidthCount / 2; x <= tileWidthCount / 2; x++)
					{
						for (int i = -posToPlace; i <= posToPlace; i++)
						{
							yield return new WaitForSeconds(timeBetweenTileSpawns);
							SpawnAndAddTile(x, i);
							positionsTaken.Add(new Vector3(x, 0f, i));
						}
						if (amountToPlace <= tileWidthCount / 2 && amountToPlaceIncrease)
						{
							amountToPlace++;
							posToPlace = amountToPlace - 1;
						}
						else
						{
							amountToPlace--;
							posToPlace = amountToPlace - 1;
							amountToPlaceIncrease = false;
						}
						if (tileWidthCount >= 2)
						{
							WorldSetupPreview.Instance.PlayTileSpawnSound();
						}
					}
					break;
				}
				case WorldShape.circle:
				{
					float angle = 0f;
					float interval = 0.0031415927f;
					while (angle < MathF.PI * 2f)
					{
						this.x = (int)((float)tileWidthCount * Mathf.Cos(angle));
						z = (int)((float)tileWidthCount * Mathf.Sin(angle));
						if (positionsTaken.Contains(new Vector3(this.x, 0f, z)))
						{
							angle += interval;
							continue;
						}
						yield return new WaitForSeconds(timeBetweenTileSpawns);
						SpawnAndAddTile(this.x, z);
						positionsTaken.Add(new Vector3(this.x, 0f, z));
						WorldSetupPreview.Instance.PlayTileSpawnSound();
						angle += interval;
					}
					WorldSetupPreview.Instance.ResetPitch();
					float x2;
					for (x2 = positionsTaken.Min((Vector3 value) => value.x) + 1f; x2 < positionsTaken.Max((Vector3 value) => value.x); x2++)
					{
						for (float num = 0f - positionsTaken.Find((Vector3 value) => value.x == x2).z + 1f; num < positionsTaken.Find((Vector3 value) => value.x == x2).z; num += 1f)
						{
							SpawnAndAddTile(x2, num);
						}
						WorldSetupPreview.Instance.PlayTileSpawnSound();
						yield return new WaitForSeconds(timeBetweenTileSpawns);
					}
					WorldSetupPreview.Instance.ResetPitch();
					break;
				}
				default:
				{
					tileWidthCount = (tileWidthCount - 1) / 2;
					for (int posToPlace = -tileWidthCount; posToPlace <= tileWidthCount; posToPlace++)
					{
						for (int amountToPlace = -tileWidthCount; amountToPlace <= tileWidthCount; amountToPlace++)
						{
							yield return new WaitForSeconds(timeBetweenTileSpawns);
							SpawnAndAddTile(posToPlace, amountToPlace);
							positionsTaken.Add(new Vector3(posToPlace, 0f, amountToPlace));
							if (tileWidthCount < 2)
							{
								WorldSetupPreview.Instance.PlayTileSpawnSound();
							}
						}
						if (tileWidthCount >= 2)
						{
							WorldSetupPreview.Instance.PlayTileSpawnSound();
						}
						WorldSetupPreview.Instance.ResetPitch();
					}
					break;
				}
				}
			}
			else
			{
				tileWidthCount /= 2;
				for (int posToPlace = -tileWidthCount; posToPlace < tileWidthCount; posToPlace++)
				{
					for (int amountToPlace = -tileWidthCount; amountToPlace < tileWidthCount; amountToPlace++)
					{
						yield return new WaitForSeconds(timeBetweenTileSpawns);
						SpawnAndAddTile(posToPlace, amountToPlace);
						if (tileWidthCount < 2)
						{
							WorldSetupPreview.Instance.PlayTileSpawnSound();
						}
					}
					if (tileWidthCount >= 2)
					{
						WorldSetupPreview.Instance.PlayTileSpawnSound();
					}
					WorldSetupPreview.Instance.ResetPitch();
				}
			}
		}
		else
		{
			SpawnAndAddTile(0f, 0f);
			WorldSetupPreview.Instance.PlayTileSpawnSound();
		}
		MouseController.Instance.ChangeSelectedPrefab();
		Invoke("AllowRotatingAgain", 0.35f);
	}

	private void AllowRotatingAgain()
	{
		canRotate = true;
	}

	private void SpawnAndAddTile(float x, float z)
	{
		x = (int)x;
		z = (int)z;
		if (!positionsTaken.Contains(new Vector3(x, 0f, z)) && !ExistsOnGrid(new Vector3(x * (float)tileSize, 0f, z * (float)tileSize)))
		{
			TileObject component = UnityEngine.Object.Instantiate(tilePrefab, new Vector3(x * (float)tileSize, 0f, z * (float)tileSize), Quaternion.identity, tileParent).GetComponent<TileObject>();
			component.SetTileMaterial(tileMaterial);
			tiles.Add(component);
		}
	}

	public TileObject GetTile(Vector3 position)
	{
		return tiles.Find((TileObject x) => x.transform.position == position);
	}

	public List<TileObject> GetAllTiles()
	{
		return tiles;
	}

	public void ClearTiles()
	{
		tiles.Clear();
	}

	private void SetRotateTweenFinished()
	{
		Invoke("AllowBuildingAgain", 0.25f);
	}

	private void AllowBuildingAgain()
	{
		rotateTweenFinished = true;
	}

	public bool IsRotateTweenFinished()
	{
		return rotateTweenFinished;
	}

	public float getYRot()
	{
		return yRot;
	}

	private void RotateWorldCW(InputAction.CallbackContext context)
	{
		if (TutorialController.Instance.GetCurrentTutorialStep() >= 2 && canRotate && (TutorialController.Instance.TutorialActive() || MouseController.Instance.GetPlacedFirstObject()))
		{
			yRot += 90f;
			rotateTweenFinished = false;
			base.transform.DORotate(new Vector3(0f, yRot, 0f), 0.1f).onComplete = SetRotateTweenFinished;
			soundManager.PlaySound(rotateSfx, randomPitch: true);
			if (TutorialController.Instance.GetCurrentTutorialStep() == 2)
			{
				TutorialController.Instance.ShowNextTutorialStep();
			}
		}
	}

	private void RotateWorldCCW(InputAction.CallbackContext context)
	{
		if (TutorialController.Instance.GetCurrentTutorialStep() >= 2 && canRotate && (TutorialController.Instance.TutorialActive() || MouseController.Instance.GetPlacedFirstObject()))
		{
			yRot -= 90f;
			rotateTweenFinished = false;
			base.transform.DORotate(new Vector3(0f, yRot, 0f), 0.1f).onComplete = SetRotateTweenFinished;
			soundManager.PlaySound(rotateSfx, randomPitch: true);
			if (TutorialController.Instance.GetCurrentTutorialStep() == 2)
			{
				TutorialController.Instance.ShowNextTutorialStep();
			}
		}
	}

	public void SetTileMaterial(Material material)
	{
		tileMaterial = material;
	}

	public Color GetTileMaterialColor()
	{
		return tileMaterial.color;
	}

	private void SetRandomRoofColor()
	{
		roofColorIndex = UnityEngine.Random.Range(0, roofColorOptions.Count);
		SetRoofColor();
	}

	public void SetRoofColor()
	{
		Renderer[] array = UnityEngine.Object.FindObjectsOfType<Renderer>();
		for (int i = 0; i < array.Length; i++)
		{
			Material[] materials = array[i].materials;
			foreach (Material material in materials)
			{
				if (material.name.Contains("roof"))
				{
					material.color = roofColorOptions[roofColorIndex];
				}
			}
		}
	}

	public void ChangeRoofColor()
	{
		roofColorIndex++;
		if (roofColorIndex >= roofColorOptions.Count)
		{
			roofColorIndex = 0;
		}
		SetRoofColor();
	}

	public Color GetRoofColor()
	{
		return roofColorOptions[roofColorIndex];
	}

	public void SetRoofColorsList(List<Color> colors)
	{
		roofColorOptions.Clear();
		roofColorOptions = colors;
	}

	public Material GetTransparentMaterial()
	{
		return transparentMaterial;
	}
}

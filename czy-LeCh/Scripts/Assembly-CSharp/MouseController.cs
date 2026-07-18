using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
	public static MouseController Instance;

	private GameControls gameControls;

	[Header("Sound Variables")]
	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip placeSfx;

	[SerializeField]
	private AudioClip switchPrefabSfx;

	[SerializeField]
	private AudioClip breakSfx;

	[SerializeField]
	private AudioClip rotateSfx;

	[SerializeField]
	private AudioClip copySfx;

	[SerializeField]
	private AudioClip changeColorSfx;

	[Header("Other")]
	[SerializeField]
	private GameObject hoverOverGameObject;

	[SerializeField]
	private TileObject hoverOverTile;

	[SerializeField]
	private bool currentTileIsWaterTile;

	[SerializeField]
	private GameObject waterTilePrefab;

	[SerializeField]
	private Camera _camera;

	private bool canSave = true;

	[SerializeField]
	private float refreshRate = 0.1f;

	[SerializeField]
	private LayerMask defaultLayerMask;

	[SerializeField]
	private LayerMask transparentLayerMask;

	[SerializeField]
	private List<GridObject> gridObjectsHit;

	[SerializeField]
	private Vector3 hoverPos;

	[SerializeField]
	private GameObject placementParticleEffect;

	[SerializeField]
	private GameObject waterPlacementParticleEffect;

	[SerializeField]
	private float yToAdd = 7.475f;

	private bool canPlace = true;

	private bool placedFirstObject;

	[SerializeField]
	private GameObject _originalFoundGameObject;

	[SerializeField]
	private GameObject _foundGameObject;

	private List<ObjectType> objectTypes;

	[Header("Prefab Variables")]
	[SerializeField]
	private bool ignoreUnlocks;

	[SerializeField]
	private bool useTestObject;

	[SerializeField]
	private GameObject testObject;

	[SerializeField]
	private GameObject previewObject;

	[SerializeField]
	private GameObject selectedPrefab;

	[SerializeField]
	private Transform previewObjectParent;

	[SerializeField]
	private List<GameObject> prefabOptions;

	[SerializeField]
	private List<GameObject> waterPrefabOptions;

	[SerializeField]
	private List<GameObject> buildingsOptions;

	[SerializeField]
	private List<GameObject> otherOptions;

	[SerializeField]
	private List<GameObject> waterOptions;

	[SerializeField]
	private TextMeshProUGUI selectedTileNameText;

	[SerializeField]
	private int amountToAddToList;

	private Color whiteColor;

	private int lastChangedDirection;

	[SerializeField]
	private int currentDefaultIndex;

	[SerializeField]
	private int currentWaterIndex;

	[SerializeField]
	private Transform selectedTileSquarePreview;

	[SerializeField]
	private float rotationSpeed;

	private bool isRotating;

	[SerializeField]
	private float lastTargetYRotation;

	[SerializeField]
	private float targetYRotation;

	[SerializeField]
	private float currentYRotation;

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

	public void SetTileHover(GameObject hoverOverGameObject)
	{
		if (hoverOverGameObject == null)
		{
			this.hoverOverGameObject = hoverOverGameObject;
			if (hoverOverTile != null)
			{
				currentTileIsWaterTile = hoverOverTile.IsWater();
			}
		}
		else
		{
			if (!(this.hoverOverGameObject != hoverOverGameObject))
			{
				return;
			}
			this.hoverOverGameObject = hoverOverGameObject;
			try
			{
				if (hoverOverTile != null && hoverOverTile.IsWater() != hoverOverGameObject.GetComponent<TileObject>().IsWater())
				{
					hoverOverTile = ((hoverOverGameObject == null) ? null : hoverOverGameObject.GetComponent<TileObject>());
					currentTileIsWaterTile = hoverOverTile.IsWater();
					ChangeSelectedPrefab();
					return;
				}
			}
			catch
			{
			}
			hoverOverTile = ((hoverOverGameObject == null) ? null : hoverOverGameObject.GetComponent<TileObject>());
			currentTileIsWaterTile = hoverOverTile.IsWater();
		}
	}

	private void Start()
	{
		LockAllPrefabs();
		UnlockAllObjectsFromStart();
		LoadUnlockedTiles();
		SetupList();
		StartCoroutine(UpdateRaycast());
		StartCoroutine(UpdateTransparencyRaycast());
		gameControls.Game.Build.performed += Place;
		gameControls.Game.Build.canceled += AllowPlace;
		gameControls.Game.Duplicate.performed += Duplicate;
		gameControls.Game.Break.performed += Break;
		gameControls.Game.ChangeColor.performed += ChangeColor;
		gameControls.Game.NextPrefab.performed += SelectNextPrefab;
		gameControls.Game.PreviousPrefab.performed += SelectPreviousPrefab;
		gameControls.Game.Rotate.performed += Rotate;
	}

	private void Update()
	{
		selectedTileNameText.color = whiteColor;
		if (whiteColor.a > 0f)
		{
			whiteColor.a -= 0.15f * Time.deltaTime;
		}
		if (GridController.Instance.GetAllGridObjects().Count >= GridController.Instance.GetAllTiles().Count)
		{
			selectedTileNameText.text = "";
		}
		UpdatePreviewPosition();
		if (Keyboard.current.iKey.isPressed && canSave)
		{
			canSave = false;
			SaveUnlockedTiles();
		}
		_ = hoverOverGameObject == null;
	}

	private IEnumerator UpdateRaycast()
	{
		Vector3 pos = Vector3.Scale(GamepadCursor.Instance.GetRelevantCursorPosition(), new Vector3((float)_camera.pixelWidth / (float)Screen.width, (float)_camera.pixelHeight / (float)Screen.height));
		if (Physics.Raycast(_camera.ScreenPointToRay(pos), out var hitInfo, float.PositiveInfinity, defaultLayerMask) && !GameManager.Instance.IsBuildFinished() && !SettingsManager.Instance.IsSettingsOpen())
		{
			SetTileHover(hitInfo.collider.gameObject);
			selectedTileSquarePreview.gameObject.SetActive(value: true);
		}
		else
		{
			SetTileHover(null);
			selectedTileSquarePreview.gameObject.SetActive(value: false);
		}
		yield return new WaitForSeconds(refreshRate);
		StartCoroutine(UpdateRaycast());
	}

	private IEnumerator UpdateTransparencyRaycast()
	{
		Vector3 pos = Vector3.Scale(GamepadCursor.Instance.GetRelevantCursorPosition(), new Vector3((float)_camera.pixelWidth / (float)Screen.width, (float)_camera.pixelHeight / (float)Screen.height));
		List<RaycastHit> list = Physics.RaycastAll(_camera.ScreenPointToRay(pos), float.PositiveInfinity, transparentLayerMask).ToList();
		foreach (GridObject item in gridObjectsHit)
		{
			item.ChangeMaterialToDefault();
		}
		gridObjectsHit.Clear();
		if (!SettingsManager.Instance.IsSettingsOpen() && !TileUnlockController.Instance.TileUnlockCanvasActive())
		{
			foreach (RaycastHit item2 in list)
			{
				GridObject component = item2.collider.gameObject.GetComponent<GridObject>();
				if (component.gameObject != previewObject)
				{
					component.ChangeMaterialToTransparent();
					gridObjectsHit.Add(component);
				}
			}
		}
		yield return new WaitForSeconds(refreshRate);
		StartCoroutine(UpdateTransparencyRaycast());
	}

	private void AllowPlace(InputAction.CallbackContext context)
	{
		canPlace = true;
	}

	private void Place(InputAction.CallbackContext context)
	{
		if (!IsPointerOverUIObject() && !GameManager.Instance.IsBuildFinished() && (TutorialController.Instance.GetCurrentTutorialStep() == 4 || !TutorialController.Instance.TutorialActive()) && GridController.Instance.IsRotateTweenFinished() && !GridController.Instance.ExistsOnGrid(hoverPos) && hoverOverGameObject != null && canPlace)
		{
			canPlace = false;
			GridObject component = Object.Instantiate(selectedPrefab, new Vector3(hoverPos.x, hoverPos.y + yToAdd, hoverPos.z), Quaternion.Euler(0f, targetYRotation, 0f), GridController.Instance.GetTile(hoverPos).transform).GetComponent<GridObject>();
			GridController.Instance.GetTile(hoverPos).GetComponent<TileObject>().PlayBuildOnAnimation(component);
			component.PlaceObject();
			Object.Destroy(Object.Instantiate((component.GetIsWaterObject() || component.GetObjectTypes().Contains(ObjectType.water)) ? waterPlacementParticleEffect : placementParticleEffect, new Vector3(hoverPos.x, hoverPos.y + yToAdd, hoverPos.z), Quaternion.Euler(-90f, 0f, 0f), component.transform.parent), 3f);
			if (component.GetObjectTypes().Contains(ObjectType.water))
			{
				hoverOverTile.SetWater(isWater: true);
				Object.Destroy(component.gameObject);
			}
			else
			{
				GridController.Instance.AddToGrid(component.gameObject);
			}
			SetupList();
			targetYRotation = 0f;
			ChangeSelectedPrefab();
			SetTileHover(null);
			soundManager.PlaySound(component.GetSpawnSound(), randomPitch: false);
			placedFirstObject = true;
			GameManager.Instance.CanFinishBuild();
			if (WorldSetupPreview.Instance.IsPreviewUIActive())
			{
				WorldSetupPreview.Instance.HidePreviewUI();
			}
			if (TutorialController.Instance.GetCurrentTutorialStep() == 4)
			{
				TutorialController.Instance.ShowNextTutorialStep();
			}
		}
	}

	public bool GetPlacedFirstObject()
	{
		return placedFirstObject;
	}

	private void Duplicate(InputAction.CallbackContext context)
	{
		_originalFoundGameObject = null;
		_foundGameObject = null;
		GridObject _foundGridObject = null;
		try
		{
			_originalFoundGameObject = GridController.Instance.GetGridObjectInstance(hoverPos).gridGameObject;
			_foundGridObject = _originalFoundGameObject.GetComponent<GridObject>();
			if (_foundGridObject.GetIsWaterObject())
			{
				_foundGameObject = waterPrefabOptions.Find((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
			}
			else
			{
				try
				{
					_foundGameObject = buildingsOptions.Find((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
					if (_foundGameObject == null)
					{
						_foundGameObject = otherOptions.Find((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
					}
				}
				catch
				{
					try
					{
						_foundGameObject = otherOptions.Find((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
					}
					catch
					{
						MonoBehaviour.print("something went wrong");
					}
				}
			}
			targetYRotation = _originalFoundGameObject.transform.eulerAngles.y;
		}
		catch
		{
			MonoBehaviour.print("failed to duplicate");
		}
		soundManager.PlaySound(copySfx, randomPitch: true);
		if (waterPrefabOptions.Contains(_foundGameObject) || prefabOptions.Contains(_foundGameObject))
		{
			if (currentTileIsWaterTile)
			{
				if (_foundGameObject != null)
				{
					int num = waterPrefabOptions.FindIndex((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
					currentWaterIndex = num;
				}
				if (!prefabOptions.Contains(waterTilePrefab))
				{
					prefabOptions.Add(waterTilePrefab);
					currentDefaultIndex = prefabOptions.Count - 1;
					hoverOverGameObject.transform.localScale = Vector3.zero;
					hoverOverGameObject.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBounce);
				}
				else
				{
					int num = prefabOptions.FindIndex((GameObject x) => x == waterTilePrefab);
					currentDefaultIndex = num;
				}
			}
			else
			{
				int num = prefabOptions.FindIndex((GameObject x) => x.GetComponent<GridObject>().GetObjectID() == _foundGridObject.GetObjectID());
				currentDefaultIndex = num;
			}
		}
		else if (currentTileIsWaterTile)
		{
			if (_foundGameObject != null)
			{
				waterPrefabOptions.Add(_foundGameObject);
				currentWaterIndex = waterPrefabOptions.Count - 1;
			}
			prefabOptions.Add(waterTilePrefab);
			currentDefaultIndex = prefabOptions.Count - 1;
			hoverOverGameObject.transform.localScale = Vector3.zero;
			hoverOverGameObject.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBounce);
		}
		else
		{
			prefabOptions.Add(_foundGameObject);
			currentDefaultIndex = prefabOptions.Count - 1;
		}
		_originalFoundGameObject.transform.localScale = Vector3.zero;
		_originalFoundGameObject.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBounce);
		ChangeSelectedPrefab();
	}

	private void Break(InputAction.CallbackContext context)
	{
		if (IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished() || hoverOverTile == null || TutorialController.Instance.GetCurrentTutorialStep() < 6)
		{
			return;
		}
		if (GridController.Instance.ExistsOnGrid(hoverPos))
		{
			objectTypes = GridController.Instance.GetGridObjectInstance(hoverPos).gridGameObject.GetComponent<GridObject>().GetObjectTypes();
			Object.Destroy(GridController.Instance.GetGridObjectInstance(hoverPos).gridGameObject);
			GridController.Instance.RemoveFromGrid(hoverPos);
			if (!hoverOverTile.IsWater())
			{
				GridController.Instance.GetTile(hoverPos).PlayDeleteAnimation(objectTypes);
			}
			if (TutorialController.Instance.GetCurrentTutorialStep() == 6)
			{
				TutorialController.Instance.ShowNextTutorialStep();
			}
			soundManager.PlaySound(breakSfx, randomPitch: true);
			ChangeSelectedPrefab();
		}
		else if (hoverOverTile.IsWater())
		{
			hoverOverTile.SetWater(isWater: false);
			List<ObjectType> gridObjectTypes = new List<ObjectType> { ObjectType.water };
			GridController.Instance.GetTile(hoverPos).PlayDeleteAnimation(gridObjectTypes);
			if (TutorialController.Instance.GetCurrentTutorialStep() == 6)
			{
				TutorialController.Instance.ShowNextTutorialStep();
			}
			soundManager.PlaySound(breakSfx, randomPitch: true);
			ChangeSelectedPrefab();
		}
	}

	private void ChangeColor(InputAction.CallbackContext context)
	{
		if (!IsPointerOverUIObject() && !GameManager.Instance.IsBuildFinished())
		{
			GridController.Instance.ChangeRoofColor();
			soundManager.PlaySound(changeColorSfx, randomPitch: true);
		}
	}

	private void LockAllPrefabs()
	{
		foreach (GameObject buildingsOption in buildingsOptions)
		{
			buildingsOption.GetComponent<GridObject>().SetLocked();
		}
		foreach (GameObject otherOption in otherOptions)
		{
			otherOption.GetComponent<GridObject>().SetLocked();
		}
		foreach (GameObject waterOption in waterOptions)
		{
			waterOption.GetComponent<GridObject>().SetLocked();
		}
	}

	private void UnlockAllObjectsFromStart()
	{
		foreach (GameObject buildingsOption in buildingsOptions)
		{
			GridObject component = buildingsOption.GetComponent<GridObject>();
			if (component.IsUnlockedFromStart() || (component.IsUnlockedInDemo() && DemoController.Instance.IsDemo()))
			{
				component.SetUnlocked();
			}
		}
		foreach (GameObject otherOption in otherOptions)
		{
			GridObject component2 = otherOption.GetComponent<GridObject>();
			if (component2.IsUnlockedFromStart() || (component2.IsUnlockedInDemo() && DemoController.Instance.IsDemo()))
			{
				component2.SetUnlocked();
			}
		}
		foreach (GameObject waterOption in waterOptions)
		{
			GridObject component3 = waterOption.GetComponent<GridObject>();
			if (component3.IsUnlockedFromStart() || (component3.IsUnlockedInDemo() && DemoController.Instance.IsDemo()))
			{
				component3.SetUnlocked();
			}
		}
	}

	public bool CheckIfAllTilesUnlocked()
	{
		foreach (GameObject buildingsOption in buildingsOptions)
		{
			if (!buildingsOption.GetComponent<GridObject>().IsUnlocked())
			{
				return false;
			}
		}
		foreach (GameObject otherOption in otherOptions)
		{
			if (!otherOption.GetComponent<GridObject>().IsUnlocked())
			{
				return false;
			}
		}
		foreach (GameObject waterOption in waterOptions)
		{
			if (!waterOption.GetComponent<GridObject>().IsUnlocked())
			{
				return false;
			}
		}
		return true;
	}

	private void LoadUnlockedTiles()
	{
		List<int> list = SaveLoadManager.Instance.LoadUnlockedIDs();
		if (list == null)
		{
			return;
		}
		foreach (GameObject buildingsOption in buildingsOptions)
		{
			GridObject component = buildingsOption.GetComponent<GridObject>();
			if (list.Contains(component.GetObjectID()))
			{
				component.SetUnlocked();
			}
		}
		foreach (GameObject otherOption in otherOptions)
		{
			GridObject component2 = otherOption.GetComponent<GridObject>();
			if (list.Contains(component2.GetObjectID()))
			{
				component2.SetUnlocked();
			}
		}
		foreach (GameObject waterOption in waterOptions)
		{
			GridObject component3 = waterOption.GetComponent<GridObject>();
			if (list.Contains(component3.GetObjectID()))
			{
				component3.SetUnlocked();
			}
		}
	}

	public void SaveUnlockedTiles()
	{
		SaveLoadManager.Instance.SaveUnlockedIDs(buildingsOptions, otherOptions, waterOptions);
	}

	private void SetupList()
	{
		prefabOptions.Clear();
		waterPrefabOptions.Clear();
		foreach (GameObject buildingsOption in buildingsOptions)
		{
			if (ignoreUnlocks || buildingsOption.GetComponent<GridObject>().IsUnlocked())
			{
				prefabOptions.Add(buildingsOption);
			}
		}
		foreach (GameObject otherOption in otherOptions)
		{
			if (ignoreUnlocks || otherOption.GetComponent<GridObject>().IsUnlocked())
			{
				prefabOptions.Add(otherOption);
			}
		}
		foreach (GameObject waterOption in waterOptions)
		{
			if (ignoreUnlocks || waterOption.GetComponent<GridObject>().IsUnlocked())
			{
				waterPrefabOptions.Add(waterOption);
			}
		}
		ChangeSelectedPrefab();
		currentDefaultIndex++;
		currentWaterIndex++;
	}

	public void ChangeSelectedPrefab()
	{
		if (IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished())
		{
			return;
		}
		lastTargetYRotation = targetYRotation;
		if (currentDefaultIndex < 0)
		{
			currentDefaultIndex = prefabOptions.Count - 1;
		}
		if (currentDefaultIndex >= prefabOptions.Count)
		{
			currentDefaultIndex = 0;
		}
		if (currentWaterIndex < 0)
		{
			currentWaterIndex = waterPrefabOptions.Count - 1;
		}
		if (currentWaterIndex >= waterPrefabOptions.Count)
		{
			currentWaterIndex = 0;
		}
		if (hoverOverTile == null)
		{
			selectedPrefab = (useTestObject ? testObject : prefabOptions[currentDefaultIndex]);
		}
		else
		{
			selectedPrefab = (useTestObject ? testObject : (hoverOverTile.IsWater() ? waterPrefabOptions[currentWaterIndex] : prefabOptions[currentDefaultIndex]));
		}
		if (selectedPrefab != null && previewObject != null && previewObjectParent.childCount > 0)
		{
			Object.Destroy(previewObject);
		}
		try
		{
			previewObject = Object.Instantiate(selectedPrefab, new Vector3(0f, yToAdd, 0f), Quaternion.Euler(0f, targetYRotation, 0f), previewObjectParent);
			previewObject.GetComponent<GridObject>().ChangeMaterialToDefault();
		}
		catch
		{
			if (lastChangedDirection == -1)
			{
				currentWaterIndex--;
				currentDefaultIndex--;
			}
			else
			{
				currentWaterIndex++;
				currentDefaultIndex++;
			}
			ChangeSelectedPrefab();
		}
		UpdateSelectedTileNameText();
		if (TutorialController.Instance.GetCurrentTutorialStep() == 9)
		{
			TutorialController.Instance.ShowNextTutorialStep();
		}
	}

	private void UpdateSelectedTileNameText()
	{
		whiteColor = Color.white;
		whiteColor.a = 0.5f;
		selectedTileNameText.color = whiteColor;
		selectedTileNameText.text = LocalizationController.Instance.GetLabelTranslation(selectedPrefab.GetComponent<GridObject>().GetNameLabel());
	}

	private void SelectNextPrefab(InputAction.CallbackContext context)
	{
		if (IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished() || TutorialController.Instance.GetCurrentTutorialStep() < 8)
		{
			return;
		}
		if (hoverOverTile != null)
		{
			if (hoverOverTile.IsWater())
			{
				currentWaterIndex = waterPrefabOptions.IndexOf(selectedPrefab) + 1;
			}
			else
			{
				currentDefaultIndex = prefabOptions.IndexOf(selectedPrefab) + 1;
			}
		}
		else
		{
			Debug.LogError("Panic Here!");
		}
		lastChangedDirection = 1;
		soundManager.PlaySound(switchPrefabSfx, randomPitch: false);
		ChangeSelectedPrefab();
	}

	private void SelectPreviousPrefab(InputAction.CallbackContext context)
	{
		if (IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished() || TutorialController.Instance.GetCurrentTutorialStep() < 8)
		{
			return;
		}
		if (hoverOverTile != null)
		{
			if (hoverOverTile.IsWater())
			{
				currentWaterIndex = waterPrefabOptions.IndexOf(selectedPrefab) - 1;
			}
			else
			{
				currentDefaultIndex = prefabOptions.IndexOf(selectedPrefab) - 1;
			}
		}
		lastChangedDirection = -1;
		soundManager.PlaySound(switchPrefabSfx, randomPitch: false);
		ChangeSelectedPrefab();
	}

	private void UpdatePreviewPosition()
	{
		selectedTileSquarePreview.position = new Vector3(hoverPos.x, 5.5f, hoverPos.z);
		try
		{
			hoverPos = hoverOverGameObject.transform.position;
		}
		catch
		{
		}
		if (IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished() || previewObject == null)
		{
			previewObjectParent.gameObject.SetActive(value: false);
			return;
		}
		if (hoverOverGameObject == null || GridController.Instance.ExistsOnGrid(hoverPos) || IsPointerOverUIObject() || GameManager.Instance.IsBuildFinished())
		{
			previewObjectParent.gameObject.SetActive(value: false);
		}
		else
		{
			previewObjectParent.gameObject.SetActive(value: true);
		}
		previewObject.transform.position = new Vector3(hoverPos.x, hoverPos.y + yToAdd, hoverPos.z);
	}

	private void Rotate(InputAction.CallbackContext context)
	{
		if (!IsPointerOverUIObject() && !GameManager.Instance.IsBuildFinished())
		{
			targetYRotation = lastTargetYRotation + 90f;
			lastTargetYRotation = targetYRotation;
			previewObject.transform.DORotate(new Vector3(0f, targetYRotation, 0f), 0.2f).SetEase(Ease.InOutSine);
			soundManager.PlaySound(rotateSfx, randomPitch: false);
		}
	}

	public bool IsPointerOverUIObject()
	{
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = GamepadCursor.Instance.GetRelevantCursorPosition();
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		foreach (RaycastResult item in list)
		{
			if (item.gameObject.GetComponent<RectTransform>() != null)
			{
				return true;
			}
		}
		return false;
	}
}

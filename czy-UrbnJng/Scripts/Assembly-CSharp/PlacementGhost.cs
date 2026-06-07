using System;
using System.Collections.Generic;
using UnityEngine;

public class PlacementGhost : MonoBehaviour
{
	public class OnSunlightChangedEventArgs : EventArgs
	{
		public EnvironmentSunlight.Sunlight sunlight;
	}

	public class OnHumidityChangedEventArgs : EventArgs
	{
		public EnvironmentHumidity.Humidity humidity;
	}

	[SerializeField]
	private Transform scoreTextTemplate;

	[SerializeField]
	private Transform placementGhostRotation;

	[SerializeField]
	private Color color;

	private Transform prefabVisual;

	private ObjectSO objectSO;

	private Vector3 targetPosition;

	private List<Material[]> currentPrefabVisualMaterials = new List<Material[]>();

	private EnvironmentSunlight.Sunlight sunlight;

	private EnvironmentHumidity.Humidity humidity;

	private bool isCollidingSunlight;

	private bool isCollidingHumidity;

	private bool isInnerSunlight;

	private bool isInnerHumidity;

	private SingleScoreUI singleScoreUI;

	private int plantScore;

	private const string OUTER_SUNLIGHT = "OuterSunlight";

	private const string INNER_SUNLIGHT = "InnerSunlight";

	private const string OUTER_HUMIDITY = "OuterHumidity";

	private const string INNER_HUMIDITY = "InnerHumidity";

	private bool showVisual;

	public event EventHandler<OnSunlightChangedEventArgs> OnSunlightChanged;

	public event EventHandler<OnHumidityChangedEventArgs> OnHumidityChanged;

	public event EventHandler OnStopShowingPlacementGhost;

	private void Awake()
	{
		showVisual = false;
	}

	private void Start()
	{
		GridPlacementManager.Instance.OnSelectedChanged += GridPlacementManager_OnSelectedChanged;
		sunlight = EnvironmentSunlight.Sunlight.Low;
		humidity = EnvironmentHumidity.Humidity.Low;
	}

	private void OnDestroy()
	{
		GridPlacementManager.Instance.OnSelectedChanged -= GridPlacementManager_OnSelectedChanged;
	}

	private void GridPlacementManager_OnSelectedChanged(object sender, EventArgs e)
	{
		objectSO = GridPlacementManager.Instance.GetObjectSO();
		RefreshVisual();
	}

	private void LateUpdate()
	{
		if (showVisual)
		{
			targetPosition = GridPlacementManager.Instance.GetMouseWorldSnappedPosition();
			targetPosition.y += 0.1f;
			base.transform.position = Vector3.Lerp(base.transform.position, targetPosition, Time.deltaTime * 15f);
			placementGhostRotation.rotation = Quaternion.Lerp(placementGhostRotation.rotation, GridPlacementManager.Instance.GetPlacedObjectRotation(), Time.deltaTime * 15f);
			UpdateMaterials();
		}
	}

	private void UpdateMaterials()
	{
		Renderer[] componentsInChildren = prefabVisual.GetComponentsInChildren<Renderer>();
		if (!GridPlacementManager.Instance.BuildCheck())
		{
			Renderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Material[] materials = array[i].materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = color;
				}
			}
		}
		else
		{
			for (int k = 0; k < componentsInChildren.Length; k++)
			{
				componentsInChildren[k].materials = currentPrefabVisualMaterials[k];
			}
		}
	}

	private void RefreshVisual()
	{
		if (prefabVisual != null)
		{
			UnityEngine.Object.Destroy(prefabVisual.gameObject);
			prefabVisual = null;
		}
		if (objectSO != null)
		{
			prefabVisual = UnityEngine.Object.Instantiate(GridPlacementManager.Instance.GetPrefab(), Vector3.zero, Quaternion.identity);
			prefabVisual.parent = placementGhostRotation;
			prefabVisual.localPosition = Vector3.zero;
			prefabVisual.localEulerAngles = Vector3.zero;
			if (GridPlacementManager.Instance.GetPot() != null)
			{
				UnityEngine.Object.Instantiate(GridPlacementManager.Instance.GetPot(), prefabVisual);
			}
			Renderer[] componentsInChildren = prefabVisual.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				currentPrefabVisualMaterials.Add(renderer.materials);
			}
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
		}
	}

	public void StartShowingPlacementGhost()
	{
		showVisual = true;
		objectSO = GridPlacementManager.Instance.GetObjectSO();
		isCollidingSunlight = false;
		isCollidingHumidity = false;
		isInnerSunlight = false;
		isInnerHumidity = false;
		targetPosition = GridPlacementManager.Instance.GetMouseWorldSnappedPosition();
		targetPosition.y += 0.1f;
		base.transform.position = targetPosition;
		placementGhostRotation.rotation = GridPlacementManager.Instance.GetPlacedObjectRotation();
		singleScoreUI = SingleScoreUI.Create(scoreTextTemplate);
		plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
		singleScoreUI.UpdateText(plantScore);
		if (currentPrefabVisualMaterials.Count > 0)
		{
			currentPrefabVisualMaterials.Clear();
		}
		RefreshVisual();
	}

	public void StopShowingPlacementGhost()
	{
		showVisual = false;
		objectSO = null;
		UnityEngine.Object.Destroy(prefabVisual.gameObject);
		prefabVisual = null;
		this.OnStopShowingPlacementGhost?.Invoke(this, EventArgs.Empty);
		singleScoreUI = null;
		plantScore = 0;
		currentPrefabVisualMaterials.Clear();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<EnvironmentSunlight>(out var _) && !isInnerSunlight)
		{
			isCollidingSunlight = true;
			sunlight = other.GetComponent<EnvironmentSunlight>().sunlight;
			Debug.Log("sunlight on enter = " + sunlight);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
			if (other.CompareTag("InnerSunlight"))
			{
				isInnerSunlight = true;
			}
		}
		if (other.TryGetComponent<EnvironmentHumidity>(out var _) && !isInnerHumidity)
		{
			isCollidingHumidity = true;
			humidity = other.GetComponent<EnvironmentHumidity>().humidity;
			Debug.Log("humidity on enter = " + humidity);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
			if (other.CompareTag("InnerHumidity"))
			{
				isInnerHumidity = true;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<EnvironmentSunlight>(out var _))
		{
			isCollidingSunlight = false;
			sunlight = EnvironmentSunlight.Sunlight.Low;
			Debug.Log("sunlight on exit = " + sunlight);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
			if (other.CompareTag("InnerSunlight"))
			{
				isInnerSunlight = false;
			}
		}
		if (other.TryGetComponent<EnvironmentHumidity>(out var _))
		{
			isCollidingHumidity = false;
			humidity = EnvironmentHumidity.Humidity.Low;
			Debug.Log("humidity on exit = " + humidity);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
			if (other.CompareTag("InnerHumidity"))
			{
				isInnerHumidity = false;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent<EnvironmentSunlight>(out var component) && !isCollidingSunlight)
		{
			isCollidingSunlight = true;
			sunlight = component.sunlight;
			Debug.Log("sunlight on stay = " + sunlight);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
		}
		if (other.TryGetComponent<EnvironmentHumidity>(out var component2) && !isCollidingHumidity)
		{
			isCollidingHumidity = true;
			humidity = component2.humidity;
			Debug.Log("humidity on stay = " + humidity);
			plantScore = ScoreCalculator.Instance.CalculateScore(objectSO, sunlight, humidity);
			singleScoreUI.UpdateText(plantScore);
		}
	}

	public int GetPlantScore()
	{
		return plantScore;
	}
}

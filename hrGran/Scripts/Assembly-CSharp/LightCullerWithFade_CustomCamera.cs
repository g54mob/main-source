using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightCullerWithFade_CustomCamera : MonoBehaviour
{
	[Header("Camera Reference")]
	[Tooltip("Kameran som detta ljus ska följa. Lämna tomt för att använda Camera.main.")]
	public Camera targetCamera;

	[Header("Distance (inner = full on, outer = full off)")]
	[Tooltip("Inom detta avstånd är ljuset fullt tänt (full intensity).")]
	public float innerRadius;

	[Tooltip("Utanför detta avstånd är ljuset helt släckt (0 intensity).")]
	public float outerRadius;

	[Header("Fade Settings")]
	[Tooltip("Hur snabbt ljuset tonar mellan 0 och baseIntensity (units per second).")]
	public float fadeSpeed;

	private Light myLight;

	private float baseIntensity;

	private float targetIntensity;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetInitialIntensity()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}

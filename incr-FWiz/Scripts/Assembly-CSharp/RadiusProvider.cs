using UnityEngine;

public class RadiusProvider : MonoBehaviour
{
	[SerializeField]
	private float _radius;

	public GameObject RadiusVisualizerPrefab;

	private GameObject _radiusVisualizer;

	public float HiddenRadiusBuffer;

	public float RadiusModifier;

	public float EffectiveRadius => 0f;

	public float VisualRadius => 0f;

	public void AddRadiusModifier(float mod)
	{
	}

	public GameObject ShowRadius()
	{
		return null;
	}

	public void ClearVisualRadius()
	{
	}

	private void OnDestroy()
	{
	}
}

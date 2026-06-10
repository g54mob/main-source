using UnityEngine;

public class NeonLetterFlickerController : MonoBehaviour
{
	public CityControls.NeonMaterial neonMat;

	public bool state;

	public AudioController.LoopingSoundInfo loop;

	public Vector3 soundOffset;

	public NewNode closestStreetNode;

	public Vector3 nodeWorldPos;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}
}

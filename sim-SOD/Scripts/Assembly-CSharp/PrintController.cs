using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PrintController : MonoBehaviour
{
	public FingerprintScannerController.Print printData;

	public Material fingerprintMaterial;

	public Material instancedMaterial;

	public DecalProjector projector;

	public Color visibleColour;

	public Color invisibleColour;

	public float scanProgress;

	public bool printConfirmed;

	public Transform beamTargetTransform;

	public InteractableController printInteractable;

	private LineRenderer _lineRenderer;

	private void Awake()
	{
	}

	public void SetPoints()
	{
	}

	public void Setup(FingerprintScannerController.Print newPrint)
	{
	}

	private void Update()
	{
	}

	public void ResetScan()
	{
	}

	public void PrintConfirmed()
	{
	}

	private void OnDestroy()
	{
	}
}

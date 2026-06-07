using UnityEngine;

public class OverlayMaterialSwap : OverlaySwapBehaviour
{
	[SerializeField]
	private Material _overlayMaterial;

	[SerializeField]
	private MeshRenderer _meshRenderer;

	private Material _startMaterial;

	private void Awake()
	{
		_startMaterial = _meshRenderer.material;
	}

	protected override void Swap(Overlays.Type overlayType)
	{
		if (overlayType == _type)
		{
			_meshRenderer.material = _overlayMaterial;
		}
		else
		{
			_meshRenderer.material = _startMaterial;
		}
	}
}

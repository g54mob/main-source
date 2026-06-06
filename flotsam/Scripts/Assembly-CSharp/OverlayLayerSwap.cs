using UnityEngine;

public class OverlayLayerSwap : OverlaySwapBehaviour
{
	[SerializeField]
	private LayerMask _overlayLayer = 0;

	private int _startLayer;

	private int _overlayLayerIndex;

	private void Awake()
	{
		_startLayer = base.gameObject.layer;
		_overlayLayerIndex = _overlayLayer.ToLayer();
	}

	protected override void Swap(Overlays.Type overlayType)
	{
		if (overlayType == _type)
		{
			base.gameObject.layer = _overlayLayerIndex;
		}
		else
		{
			base.gameObject.layer = _startLayer;
		}
	}
}

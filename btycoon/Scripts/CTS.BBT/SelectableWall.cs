using CTS.Core;
using UnityEngine;

public class SelectableWall : MonoBehaviour
{
	private int _defaultLayer;

	private void Awake()
	{
		_defaultLayer = base.gameObject.layer;
	}

	public void ResetToDefaultLayer()
	{
		if (base.gameObject != null)
		{
			base.gameObject.layer = _defaultLayer;
		}
	}

	public void SetToSelectionLayer(int layer)
	{
		base.gameObject.layer = layer;
	}

	private void OnDestroy()
	{
		if (MonoSingleton<WallSelectionManager>.InstanceExists())
		{
			MonoSingleton<WallSelectionManager>.Instance.RemoveSelectable(this);
		}
	}
}

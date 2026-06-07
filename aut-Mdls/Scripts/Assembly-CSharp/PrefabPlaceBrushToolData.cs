using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabPlaceBrushToolData", menuName = "PlaceBrushToolData/PrefabPlaceBrushToolData")]
public class PrefabPlaceBrushToolData : ScriptableObject
{
	public enum RotationsMode
	{
		None = 0,
		RandomRotation = 1
	}

	[InfoBox("Shortcut \n - 'B' to toggle Brush On/Off\n - 'Alt + RMB' : Diameter & Density \n - 'E' to toggle Erase On/Off \n ", EInfoBoxType.Normal)]
	public bool UseBrush;

	public bool EraseBrush;

	[Range(0.1f, 10f)]
	public float BrushSize;

	[Range(0f, 1f)]
	public float BrushDensity;

	[SerializeField]
	private List<GameObject> _objectsToDrawOnto = new List<GameObject>();

	[SerializeField]
	private List<GameObject> _prefabsToPlace = new List<GameObject>();

	[SerializeField]
	private RotationsMode _rotationMode;

	[SerializeField]
	[MinMaxSlider(0f, 360f)]
	[ShowIf("ShowRotationValues")]
	private Vector2 _minMaxRotation;

	[SerializeField]
	[MinMaxSlider(0.1f, 1f)]
	private Vector2 _minMaxScale;

	[SerializeField]
	[MinMaxSlider(0.1f, 1f)]
	private Vector2 _minMaxHeight;

	[SerializeField]
	[Range(-5f, 5000f)]
	private float _objectsSpacing;

	[SerializeField]
	[Range(0f, 180f)]
	private float _validRotation;

	[SerializeField]
	private bool _ignoreInactiveObject;

	public List<GameObject> ObjectsToDrawOnto => _objectsToDrawOnto;

	public List<GameObject> PrefabsToPlace => _prefabsToPlace;

	public RotationsMode RotationMode => _rotationMode;

	public Vector2 MinMaxRotation => _minMaxRotation;

	public Vector2 MinMaxScale => _minMaxScale;

	public Vector2 MinMaxHeight => _minMaxHeight;

	public float ObjectsSpacing => _objectsSpacing;

	public bool IgnoreInactiveObject => _ignoreInactiveObject;

	public float ValidRotation => _validRotation;

	private bool ShowRotationValues()
	{
		return _rotationMode == RotationsMode.RandomRotation;
	}
}

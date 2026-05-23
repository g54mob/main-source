using Presentation.Locators;
using UnityEngine;

[ExecuteAlways]
public class DebugGridTilePositionText : MonoBehaviour
{
	[SerializeField]
	private GridLocator _gridLocator;

	[SerializeField]
	private GridLocator _mapGridLocator;

	[SerializeField]
	private int _textSize = 60;

	[SerializeField]
	private float _outlineWidth = 1f;
}

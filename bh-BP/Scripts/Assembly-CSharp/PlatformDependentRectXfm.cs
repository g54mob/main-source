using UnityEngine;

public class PlatformDependentRectXfm : MonoBehaviour
{
	public RectTransform Xfm;

	public bool OverrideMobile;

	public Vector2 MobileSize;

	public Vector2 MobileAnchoredPos;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}
}

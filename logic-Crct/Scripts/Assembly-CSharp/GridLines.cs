using UnityEngine;

[ExecuteInEditMode]
public class GridLines : MonoBehaviour
{
	public Material lineMat;

	public Color majorColor;

	public Color minorColor;

	public int majorSpacing;

	public int drawDistance;

	public bool drawOverride;

	private void OnPostRender()
	{
	}
}

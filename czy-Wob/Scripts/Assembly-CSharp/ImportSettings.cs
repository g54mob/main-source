using UnityEngine;

public class ImportSettings : ScriptableObject
{
	public Object svgFile;

	public bool splitMeshesByLayers;

	public bool _splitCollidersByLayers = true;

	public float scale = 0.01f;

	public int maxSubdivisonDepth = 8;

	public float minSubdivisionDistanceDelta = 0.3333333f;

	public Vector2 pivot = new Vector2(0.5f, 0.5f);

	public bool SplitCollidersByLayers
	{
		get
		{
			if (splitMeshesByLayers)
			{
				return _splitCollidersByLayers;
			}
			return false;
		}
	}
}

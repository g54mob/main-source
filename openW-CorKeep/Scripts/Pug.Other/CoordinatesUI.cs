using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class CoordinatesUI : MonoBehaviour
{
	public MapUI mapUI;

	public PugText coordinateText;

	public PugText coordinateTextOutline;

	public PugText distanceText;

	public PugText distanceTextOutline;

	private void LateUpdate()
	{
		int2 x = (int2)math.floor(mapUI.GetCursorWorldPosition());
		string text = x.x.ToString("F0") + ", " + x.y.ToString("F0");
		coordinateText.Render(text);
		coordinateTextOutline.Render(text);
		string text2 = "(" + math.length(x.ToFloat2()).ToString("F0") + ")";
		distanceText.Render(text2);
		distanceTextOutline.Render(text2);
	}
}

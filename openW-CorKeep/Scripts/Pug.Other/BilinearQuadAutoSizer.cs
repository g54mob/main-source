using UnityEngine;

[ExecuteInEditMode]
public class BilinearQuadAutoSizer : MonoBehaviour
{
	public Camera bilinearQuadCamera;

	public GameObject quad;

	private static readonly float TARGET_RATIO = 1.7777778f;

	private static readonly float INVERTED_TARGET_RATIO = 1f / TARGET_RATIO;

	private void LateUpdate()
	{
		float num = bilinearQuadCamera.orthographicSize * 2f;
		float num2 = num * bilinearQuadCamera.aspect;
		float y = num;
		float num3 = num * TARGET_RATIO;
		if (bilinearQuadCamera.aspect < TARGET_RATIO)
		{
			num3 = num2;
			y = INVERTED_TARGET_RATIO * num3;
		}
		quad.transform.localScale = new Vector3(num3, y, 1f);
	}
}

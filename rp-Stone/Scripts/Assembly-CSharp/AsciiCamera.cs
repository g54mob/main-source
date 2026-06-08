using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AsciiCamera : MonoBehaviour
{
	public float orthogonalMultiplier = 0.5f;

	private int lastScreenWidth;

	private int lastScreenHeight;

	private float lastOrthMult;

	private void Update()
	{
		if (lastScreenWidth != Screen.width || lastScreenHeight != Screen.height || lastOrthMult != orthogonalMultiplier)
		{
			lastScreenWidth = Screen.width;
			lastScreenHeight = Screen.height;
			lastOrthMult = orthogonalMultiplier;
			Camera component = GetComponent<Camera>();
			float num = (float)Screen.width * orthogonalMultiplier;
			float num2 = (component.orthographicSize = (float)Screen.height * orthogonalMultiplier);
			float x = num - Mathf.Floor(num);
			float y = num2 - Mathf.Floor(num2);
			Vector3 localPosition = base.transform.localPosition;
			localPosition.x = x;
			localPosition.y = y;
			base.transform.localPosition = localPosition;
		}
	}
}

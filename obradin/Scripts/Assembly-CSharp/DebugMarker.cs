using UnityEngine;

public class DebugMarker : MonoBehaviour
{
	public Color color;

	public string text;

	public float duration;

	private float startTime;

	private void Start()
	{
		startTime = Time.time;
	}

	private void Update()
	{
		if (startTime > 0f && Time.time > startTime + duration)
		{
			Object.Destroy(base.gameObject);
		}
		else if (DebugMenu.IsOn("Show/Debug Markers"))
		{
			DebugDrawer.World(DrawDebug);
		}
	}

	private void DrawDebug(DebugDrawer dd)
	{
		dd.DrawAxis(color, base.transform.localToWorldMatrix, 0.1f);
		Matrix4x4 mat = Matrix4x4.TRS(base.transform.position, Quaternion.LookRotation(base.transform.up), 0.1f * Vector3.one);
		dd.DrawCircle(color, mat, 16);
		dd.DrawText(color, text, base.transform.position + new Vector3(0f, 0.5f, 0f), base.transform.forward, 0.1f);
	}

	public static void Drop(Color color, Matrix4x4 mat, string text, float duration = 5f)
	{
		if (DebugMenu.IsOn("Show/Debug Markers"))
		{
			GameObject gameObject = new GameObject("DebugMarker", typeof(DebugMarker));
			DebugMarker component = gameObject.GetComponent<DebugMarker>();
			component.transform.SetLocalMatrix(mat);
			component.color = color;
			component.text = text;
			component.duration = duration;
		}
	}
}

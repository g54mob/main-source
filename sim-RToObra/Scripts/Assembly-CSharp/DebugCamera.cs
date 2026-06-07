using UnityEngine;

[ExecuteInEditMode]
public class DebugCamera : MonoBehaviour
{
	public bool clearToBlack;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			ScreenCap.TakeScreenshot();
		}
	}

	private void OnPostRender()
	{
		if (clearToBlack)
		{
			GL.Clear(true, true, Color.black);
		}
		Camera component = GetComponent<Camera>();
		DebugDrawer.Render(component);
	}
}

using UnityEngine;

public class GUI_FPS : MonoBehaviour
{
	private string FPSstring;

	private float FPSupdateTime;

	private void OnGUI()
	{
		if (Time.time > FPSupdateTime)
		{
			FPSstring = "FPS: " + (1f / Time.unscaledDeltaTime).ToString("#.00");
			FPSupdateTime = Time.time + 0.5f;
		}
		GUI.Box(new Rect((float)Screen.width * 0.5f - 40f, (float)Screen.height - 20f, 80f, 20f), FPSstring);
	}
}

using UnityEngine;

public class LetterBox : MonoBehaviour
{
	private float targetAspect = 1.7777778f;

	private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
		ApplyLetterbox(cam);
		SettingManager.S.OnSetResolution += S_OnSetResolution;
	}

	private void OnDisable()
	{
		SettingManager.S.OnSetResolution -= S_OnSetResolution;
	}

	private void S_OnSetResolution()
	{
		ApplyLetterbox(cam);
	}

	public void ApplyLetterbox(Camera cam)
	{
		if (cam == null)
		{
			return;
		}
		float num = (float)Screen.width / (float)Screen.height / targetAspect;
		if (Mathf.Abs(1f - num) < 0.01f)
		{
			cam.rect = new Rect(0f, 0f, 1f, 1f);
			return;
		}
		Rect rect = cam.rect;
		if (num < 1f)
		{
			rect.width = 1f;
			rect.height = num;
			rect.x = 0f;
			rect.y = (1f - num) / 2f;
		}
		else
		{
			float num2 = (rect.width = 1f / num);
			rect.height = 1f;
			rect.x = (1f - num2) / 2f;
			rect.y = 0f;
		}
		cam.rect = rect;
	}
}

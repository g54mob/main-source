using Rewired;
using UnityEngine;

public class JoystickCursorScript : MonoBehaviour
{
	private Player player;

	private InteractScript IScript;

	[HideInInspector]
	public RectTransform MyRect;

	[HideInInspector]
	public bool JoystickCursorActive;

	private CanvasGroup CG;

	private void Start()
	{
		player = ReInput.players.GetPlayer(0);
		IScript = GameObject.Find("PlayerCamera").GetComponent<InteractScript>();
		MyRect = GetComponent<RectTransform>();
		JoystickCursorActive = false;
		CG = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		if (IScript.MapState)
		{
			if (Mathf.Abs(player.GetAxis("JoyX")) > 0.1f || Mathf.Abs(player.GetAxis("JoyY")) > 0.1f)
			{
				JoystickCursorActive = true;
			}
			if (Mathf.Abs(player.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(player.GetAxis("Mouse Y")) > 0.1f)
			{
				JoystickCursorActive = false;
			}
			float x = player.GetAxis("JoyX") * Time.deltaTime * 500f;
			float y = player.GetAxis("JoyY") * Time.deltaTime * 500f;
			MyRect.localPosition += new Vector3(x, y, 0f);
		}
	}

	private void OnGUI()
	{
		base.transform.SetAsLastSibling();
		if (!JoystickCursorActive)
		{
			CG.alpha = 0f;
		}
		else
		{
			CG.alpha = 1f;
		}
	}
}

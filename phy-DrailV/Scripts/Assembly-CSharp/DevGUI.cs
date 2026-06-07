using DV.Debugging;
using DV.Utils;
using UnityEngine;

public class DevGUI : SingletonBehaviour<DevGUI>
{
	private Rect windowRect = new Rect(20f, -20f, 250f, 0f);

	private bool showMenu;

	private TrainsetStressDebugGUI stressGUI;

	private TextureSettingsDebugGUI textureGUI;

	public new static string AllowAutoCreate()
	{
		return "[DevGUI]";
	}

	private void OnGUI()
	{
		GUI.skin = DVGUI.skin;
		windowRect = GUILayout.Window(999, windowRect, Window, "");
	}

	private void Window(int id)
	{
		GUIExt.FoldoutButton("MENU", ref showMenu, ref windowRect);
		if (!showMenu)
		{
			return;
		}
		if (GUILayout.Button("Stress"))
		{
			if (!stressGUI)
			{
				stressGUI = base.gameObject.AddComponent<TrainsetStressDebugGUI>();
			}
			else
			{
				stressGUI.enabled = !stressGUI.enabled;
			}
		}
		if (GUILayout.Button("Game params and rendering debug"))
		{
			SingletonBehaviour<EffectsTogglerDebug>.Instance.gameObject.SetActive(!SingletonBehaviour<EffectsTogglerDebug>.Instance.gameObject.activeSelf);
		}
		if (GUILayout.Button("Textures & streaming"))
		{
			if (!textureGUI)
			{
				textureGUI = base.gameObject.AddComponent<TextureSettingsDebugGUI>();
			}
			else
			{
				textureGUI.enabled = !textureGUI.enabled;
			}
		}
	}
}

using UnityEngine;
using UnityEngine.Rendering;

public class Workspaces : MonoBehaviour
{
	public static void SetWorkspace(int index)
	{
		ReflectionProbe reflectionProbe = Object.FindObjectOfType<ReflectionProbe>();
		switch (index)
		{
		case 0:
			Camera.main.clearFlags = CameraClearFlags.Color;
			Camera.main.backgroundColor = Hex("#18181E");
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/default");
			Grid.instance.SetColor(Hex("#FFFFFF"));
			Hints.instance.SetColor(Hex("#FFFFFF"), 0.3f);
			break;
		case 1:
			Camera.main.clearFlags = CameraClearFlags.Color;
			Camera.main.backgroundColor = Hex("#D8D8D8");
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/default");
			Grid.instance.SetColor(Hex("#000000"));
			Hints.instance.SetColor(Hex("#1C1C1C"), 0.6f);
			break;
		case 2:
			Camera.main.clearFlags = CameraClearFlags.Color;
			Camera.main.backgroundColor = Hex("#040404");
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/default");
			Grid.instance.SetColor(Hex("#FFFFFF"));
			Hints.instance.SetColor(Hex("#FFFFFF"), 0.15f);
			break;
		case 3:
			Camera.main.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/Space/skybox");
			reflectionProbe.clearFlags = ReflectionProbeClearFlags.Skybox;
			Grid.instance.SetColor(Hex("#FFFFFF"));
			Hints.instance.SetColor(Hex("#FFFFFF"), 0.3f);
			break;
		case 4:
			Camera.main.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/Sky/sunset");
			reflectionProbe.clearFlags = ReflectionProbeClearFlags.Skybox;
			Grid.instance.SetColor(Hex("#000000"));
			Hints.instance.SetColor(Hex("#1C1C1C"), 0.6f);
			break;
		case 5:
			Camera.main.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.skybox = Resources.Load<Material>("Workspaces/Skybox/Sky/daytime");
			reflectionProbe.clearFlags = ReflectionProbeClearFlags.Skybox;
			Grid.instance.SetColor(Hex("#000000"));
			Hints.instance.SetColor(Hex("#1C1C1C"), 0.6f);
			break;
		}
		reflectionProbe.RenderProbe();
	}

	public static Color Hex(string hex)
	{
		ColorUtility.TryParseHtmlString(hex, out var color);
		return color;
	}
}

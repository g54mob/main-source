using UnityEngine;

public class ColorblindSimulationImageEffect : MonoBehaviour
{
	public Material material;

	public ColorDeficiencyType selectedDeficiency;

	private ColorDeficiencyType currentDeficiency;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (!(material != null))
		{
			Graphics.Blit(src, dest);
		}
		else
		{
			Graphics.Blit(src, dest, material);
		}
	}

	private void Update()
	{
		if (selectedDeficiency == currentDeficiency)
		{
			return;
		}
		object message;
		if (material != null)
		{
			if (material.HasProperty("_Deficiency"))
			{
				material.SetInt("_Deficiency", (int)selectedDeficiency);
				currentDeficiency = selectedDeficiency;
				return;
			}
			message = "ColorblindSimulationImageEffect:: The set material is not compatible with this script.";
		}
		else
		{
			message = "ColorblindSimulationImageEffect:: Cannot change deficiency type, no material set.";
		}
		Debug.Log(message);
		selectedDeficiency = currentDeficiency;
	}
}

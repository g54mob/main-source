using UnityEngine;
using UnityEngine.UI;

public class ChangeShader : MonoBehaviour
{
	public Button firstButton;

	public Button secondButton;

	public Button thirdButton;

	public void PressButton1()
	{
		Shader.DisableKeyword("_GLOBAL_WEATHER_SNOW_ON");
		Shader.DisableKeyword("_GLOBAL_WEATHER_RAIN_ON");
		Shader.EnableKeyword("_GLOBAL_WEATHER_NONE");
	}

	public void PressButton2()
	{
		Shader.EnableKeyword("_GLOBAL_WEATHER_SNOW_ON");
		Shader.DisableKeyword("_GLOBAL_WEATHER_RAIN_ON");
		Shader.DisableKeyword("_GLOBAL_WEATHER_NONE");
	}

	public void PressButton3()
	{
		Shader.DisableKeyword("_GLOBAL_WEATHER_SNOW_ON");
		Shader.EnableKeyword("_GLOBAL_WEATHER_RAIN_ON");
		Shader.DisableKeyword("_GLOBAL_WEATHER_NONE");
	}
}

using UnityEngine;
using UnityEngine.Rendering;

namespace CTS
{
	public class LightsTogglerTMP : MonoBehaviour
	{
		public bool lightsout;

		public bool toggle;

		public bool underground;

		public GameObject[] light01;

		public GameObject[] light02;

		public Color SkyColor_Light_01;

		public Color SkyColor_Light_02;

		public Color SkyColor_Light_02_underground = new Color(0.4f, 0.4f, 0.4f);

		public GameObject ppBlur;

		[Range(0f, 1f)]
		public float zoomBlur;

		public void Update()
		{
			ppBlur.GetComponent<Volume>().weight = zoomBlur;
			if (!lightsout)
			{
				GameObject[] array = light01;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(toggle);
				}
				array = light02;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(!toggle);
				}
				if (underground)
				{
					RenderSettings.ambientSkyColor = SkyColor_Light_02_underground;
				}
				else
				{
					RenderSettings.ambientSkyColor = (toggle ? SkyColor_Light_01 : SkyColor_Light_02);
				}
			}
			else
			{
				GameObject[] array = light01;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				array = light02;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				RenderSettings.ambientSkyColor = SkyColor_Light_01;
			}
		}
	}
}

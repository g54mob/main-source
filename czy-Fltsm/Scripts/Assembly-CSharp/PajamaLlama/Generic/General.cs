using UnityEngine;

namespace PajamaLlama.Generic
{
	public class General : MonoBehaviour
	{
		public static Color ColorRGB(int r, int g, int b, int a = 255)
		{
			return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)a / 255f);
		}
	}
}

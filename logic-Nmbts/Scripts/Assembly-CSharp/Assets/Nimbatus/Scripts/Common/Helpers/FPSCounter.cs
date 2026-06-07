using System.Collections;
using System.Globalization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class FPSCounter : MonoBehaviour
	{
		private float accum;

		public bool allowDrag = true;

		private Color color = Color.white;

		private int frames;

		public float frequency = 0.5f;

		public int nbDecimal = 1;

		private string sFPS = "";

		public Rect startRect = new Rect(10f, 10f, 75f, 50f);

		private GUIStyle style;

		public bool updateColor = true;

		private void Start()
		{
			StartCoroutine(FPS());
		}

		private void Update()
		{
			accum += Time.timeScale / Time.deltaTime;
			frames++;
		}

		private IEnumerator FPS()
		{
			while (true)
			{
				sFPS = (accum / (float)frames).ToString("f" + Mathf.Clamp(nbDecimal, 0, 10), CultureInfo.InvariantCulture);
				color = Color.black;
				accum = 0f;
				frames = 0;
				yield return new WaitForSeconds(frequency);
			}
		}

		private void OnGUI()
		{
			if (style == null)
			{
				style = new GUIStyle(UnityEngine.GUI.skin.label);
				style.normal.textColor = Color.white;
				style.alignment = TextAnchor.MiddleCenter;
			}
			UnityEngine.GUI.color = (updateColor ? color : Color.white);
			startRect = UnityEngine.GUI.Window(0, startRect, DoMyWindow, "");
		}

		private void DoMyWindow(int windowID)
		{
			UnityEngine.GUI.Label(new Rect(0f, 0f, startRect.width, startRect.height), sFPS + " FPS", style);
		}
	}
}

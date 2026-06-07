using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Analysis.Profiling
{
	[AddComponentMenu("Utilities/HUDFPS")]
	public class HUDFPS : MonoBehaviour
	{
		public static string sFPS = "nope";

		public bool allowDrag = true;

		public float frequency = 0.5f;

		public int nbDecimal = 1;

		public Rect startRect = new Rect(0f, 0f, 75f, 50f);

		public bool updateColor = true;

		private float accum;

		private Color color = Color.white;

		private int frames;

		private GUIStyle style;

		protected virtual void OnGUI()
		{
			if (style == null)
			{
				style = new GUIStyle(GUI.skin.label);
				style.normal.textColor = Color.white;
				style.alignment = TextAnchor.MiddleCenter;
			}
			GUI.color = (updateColor ? color : Color.white);
			startRect.x = 200f;
			startRect.y = 200f;
			startRect = GUI.Window(0, startRect, DoMyWindow, string.Empty);
		}

		protected virtual void Start()
		{
			sFPS = "Started...";
			StartCoroutine(FPS());
		}

		protected virtual void Update()
		{
			accum += Time.timeScale / Time.deltaTime;
			frames++;
		}

		private void DoMyWindow(int windowID)
		{
			GUI.Label(new Rect(0f, 0f, startRect.width, startRect.height), sFPS + " FPS", style);
			if (allowDrag)
			{
				GUI.DragWindow(new Rect(50f, 0f, Screen.width, Screen.height));
			}
		}

		private IEnumerator FPS()
		{
			while (true)
			{
				float num = accum / (float)frames;
				sFPS = num.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10));
				color = ((num >= 30f) ? Color.green : ((num > 10f) ? Color.red : Color.yellow));
				accum = 0f;
				frames = 0;
				yield return new WaitForSeconds(frequency);
			}
		}
	}
}

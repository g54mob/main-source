using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Analysis.Profiling
{
	public class FpsDisplayScript : MonoBehaviour
	{
		public bool AllowDrag = true;

		public int DecimalPlaces = 1;

		public float Frequency = 0.5f;

		public bool UpdateColor = true;

		private float _accum;

		private Color _color = Color.white;

		private string _fpsString = string.Empty;

		private int _frames;

		private Rect _startRect;

		private GUIStyle _style;

		protected virtual void OnGUI()
		{
			if (_style == null)
			{
				_style = new GUIStyle(GUI.skin.label);
				_style.normal.textColor = Color.white;
				_style.alignment = TextAnchor.MiddleCenter;
				_style.fontSize = 36;
			}
			GUI.color = (UpdateColor ? _color : Color.white);
			_startRect = GUI.Window(0, _startRect, DoMyWindow, string.Empty);
		}

		protected virtual void Start()
		{
			_startRect = new Rect(Screen.width - 130, 10f, 120f, 70f);
			StartCoroutine(FPS());
		}

		protected virtual void Update()
		{
			_accum += Time.timeScale / Time.deltaTime;
			_frames++;
		}

		private void DoMyWindow(int windowID)
		{
			if (GUI.Button(new Rect(0f, 15f, _startRect.width, _startRect.height - 15f), _fpsString, _style))
			{
				OnLabelClicked();
			}
			if (AllowDrag)
			{
				GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
			}
		}

		private IEnumerator FPS()
		{
			while (true)
			{
				float num = _accum / (float)_frames;
				_fpsString = num.ToString("f" + Mathf.Clamp(DecimalPlaces, 0, 10));
				_color = ((num >= 30f) ? Color.green : ((num > 10f) ? Color.red : Color.yellow));
				_accum = 0f;
				_frames = 0;
				yield return new WaitForSeconds(Frequency);
			}
		}

		private void OnLabelClicked()
		{
		}
	}
}

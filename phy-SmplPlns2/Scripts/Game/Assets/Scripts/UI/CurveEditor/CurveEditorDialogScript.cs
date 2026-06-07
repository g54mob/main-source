using System;
using UnityEngine;

namespace Assets.Scripts.UI.CurveEditor
{
	public class CurveEditorDialogScript : DialogScript
	{
		private Action<AnimationCurve> _callback;

		public CurveEditorScript EditorScript { get; private set; }

		public override void Close()
		{
			base.Close();
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void Initialize(AnimationCurve curve, Action<AnimationCurve> callback)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Game.Instance.ResourceLoader.LoadPrefab("UI/CurveEditor"));
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			_callback = callback;
			EditorScript = gameObject.GetComponentInChildren<CurveEditorScript>();
			EditorScript.LaunchEditor(curve, Callback);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.sizeDelta = Vector2.zero;
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private void Callback(AnimationCurve curve)
		{
			if (curve != null)
			{
				_callback?.Invoke(curve);
			}
			Close();
		}
	}
}

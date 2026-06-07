using System;
using Assets.Scripts.Ui.CurveEditor;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Ui
{
	public class CurveEditorDialogScript : DialogScript
	{
		private static GameObject _asset = Game.Instance.ResourceLoader.LoadPrefab("Ui/Prefabs/CurveEditor");

		private CurveEditorScript _editorScript;

		private Action<AnimationCurve> _callback;

		public static CurveEditorDialogScript Create(Transform parent, AnimationCurve curve, Action<AnimationCurve> callback)
		{
			CurveEditorDialogScript curveEditorDialogScript = Game.Instance.UserInterface.CreateDialog<CurveEditorDialogScript>(parent);
			curveEditorDialogScript._callback = callback;
			GameObject gameObject = UnityEngine.Object.Instantiate(_asset);
			gameObject.transform.SetParent(curveEditorDialogScript.transform, worldPositionStays: false);
			curveEditorDialogScript._editorScript = gameObject.GetComponentInChildren<CurveEditorScript>();
			curveEditorDialogScript._editorScript.LaunchEditor(curve, curveEditorDialogScript.Callback);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.sizeDelta = Vector2.zero;
			return curveEditorDialogScript;
		}

		public override void Close()
		{
			base.Close();
			UnityEngine.Object.Destroy(base.gameObject);
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
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

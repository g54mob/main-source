using System;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class GradientEditorDialogScript : DialogScript
	{
		private static GameObject _asset = Game.Instance.ResourceLoader.LoadPrefab("Ui/Prefabs/GradientEditor");

		private GradientEditorScript _script;

		private Gradient _backup;

		public static GradientEditorDialogScript Create(Transform parent, Gradient gradient, Action<Gradient> callback, bool hasAlpha, bool allowHDR)
		{
			GradientEditorDialogScript dialog = Game.Instance.UserInterface.CreateDialog<GradientEditorDialogScript>(parent);
			dialog._backup = gradient;
			GameObject gameObject = UnityEngine.Object.Instantiate(_asset);
			gameObject.transform.SetParent(dialog.transform);
			gameObject.gameObject.SetActive(value: true);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.sizeDelta = Vector2.zero;
			component.localPosition = Vector2.zero;
			dialog._script = gameObject.GetComponent<GradientEditorScript>();
			Gradient gradient2 = new Gradient();
			CopyGradient(gradient, gradient2);
			dialog._script.HasAlpha = hasAlpha;
			dialog._script.AllowHDR = allowHDR;
			dialog._script.Gradient = gradient2;
			dialog._script.OnComplete += delegate(bool save)
			{
				if (save)
				{
					callback(dialog._script.Gradient);
				}
				else
				{
					callback(dialog._backup);
				}
				dialog.Close();
				UnityEngine.Object.Destroy(dialog.gameObject);
			};
			return dialog;
		}

		public static void CopyGradient(Gradient from, Gradient to)
		{
			to.mode = from.mode;
			to.SetKeys(from.colorKeys, from.alphaKeys);
		}
	}
}

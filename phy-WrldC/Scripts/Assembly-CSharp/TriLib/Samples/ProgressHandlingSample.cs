using System;
using UnityEngine;

namespace TriLib.Samples
{
	public class ProgressHandlingSample : MonoBehaviour
	{
		private GUIStyle _centeredStyle;

		private float _assetLoadingProgress;

		private bool _assetLoaded;

		private string _error;

		private Texture2D _progressBarEmptyTexture;

		private Texture2D _progressBarFilledTexture;

		private const float WindowWidth = 400f;

		private const float WindowHeight = 100f;

		private const float HorizontalMargin = 20f;

		private void Start()
		{
			GenerateProgressBarTextures();
			using (AssetLoaderAsync assetLoaderAsync = new AssetLoaderAsync())
			{
				try
				{
					assetLoaderAsync.LoadFromFile(Application.dataPath + "/TriLib/TriLib/Samples/Models/BigModel.obj", null, base.gameObject, OnAssetLoaded, null, OnAssetLoadingProgress);
				}
				catch (Exception ex)
				{
					_error = ex.ToString();
				}
			}
		}

		private void OnAssetLoaded(GameObject loadedGameObject)
		{
			_assetLoaded = true;
		}

		private void OnAssetLoadingProgress(float progress)
		{
			_assetLoadingProgress = progress;
		}

		private void OnGUI()
		{
			if (_centeredStyle == null)
			{
				_centeredStyle = GUI.skin.GetStyle("Label");
				_centeredStyle.alignment = TextAnchor.UpperCenter;
			}
			Rect clientRect = new Rect((float)Screen.width / 2f - 200f, (float)Screen.height / 2f - 50f, 400f, 100f);
			GUI.Window(0, clientRect, ProgressWindow, "Progress Handling Sample");
		}

		private void ProgressWindow(int windowID)
		{
			Rect position = new Rect(20f, 30f, 360f, 30f);
			if (_error != null)
			{
				GUI.Label(position, $"There was an error loading your asset: '{_error}'", _centeredStyle);
			}
			else if (!_assetLoaded)
			{
				GUI.Label(position, $"Asset loading progress: {_assetLoadingProgress:P2}", _centeredStyle);
			}
			else
			{
				GUI.Label(position, "Asset loading completed", _centeredStyle);
			}
			float num = 360f;
			GUI.DrawTexture(new Rect(20f, 60f, num, 20f), _progressBarEmptyTexture);
			GUI.DrawTexture(new Rect(20f, 60f, num * _assetLoadingProgress, 20f), _progressBarFilledTexture);
		}

		private void GenerateProgressBarTextures()
		{
			_progressBarEmptyTexture = new Texture2D(1, 1);
			_progressBarEmptyTexture.SetPixels(new Color[1] { Color.black });
			_progressBarEmptyTexture.Apply();
			_progressBarFilledTexture = new Texture2D(1, 1);
			_progressBarFilledTexture.SetPixels(new Color[1] { Color.green });
			_progressBarFilledTexture.Apply();
		}
	}
}

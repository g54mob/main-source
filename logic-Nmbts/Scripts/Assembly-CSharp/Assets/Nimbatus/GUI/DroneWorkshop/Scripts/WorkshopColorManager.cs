using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class WorkshopColorManager : MonoBehaviour
	{
		public TweenPosition Tween;

		public HSVColorChooser ColorChooser;

		public UITexture GridPreview;

		public UITexture BackgroundPreview;

		public UITexture GridBorder;

		public UITexture BackgroundBorder;

		public Color SelectedColor;

		public Color NormalColor;

		public WorhkshopGridManager GridManager;

		public Camera BackgroundCamera;

		private bool _isOpen;

		private bool _isGrid;

		public void Start()
		{
			_isOpen = false;
			Tween.Play(false);
			GridManager.SetGridColor(RuntimeGlobals.Settings.GridColor);
			GridPreview.color = RuntimeGlobals.Settings.GridColor;
			BackgroundCamera.backgroundColor = RuntimeGlobals.Settings.BackgroundColor;
			BackgroundPreview.color = RuntimeGlobals.Settings.BackgroundColor;
		}

		public void OpenGridColorChooser()
		{
			if (_isOpen && _isGrid)
			{
				Tween.Play(false);
				_isOpen = false;
				return;
			}
			Tween.Play(true);
			_isGrid = true;
			ColorChooser.Init(GridPreview.color);
			_isOpen = true;
		}

		public void OpenBackgroundColorChooser()
		{
			if (_isOpen && !_isGrid)
			{
				Tween.Play(false);
				_isOpen = false;
				return;
			}
			Tween.Play(true);
			_isGrid = false;
			ColorChooser.Init(BackgroundPreview.color);
			_isOpen = true;
		}

		public void ApplyColor()
		{
			_isOpen = false;
			Tween.Play(_isOpen);
			UpdateColor(ColorChooser.SelectedColor);
			RuntimeGlobals.Settings.Save();
		}

		public void RevertColor()
		{
			_isOpen = false;
			Tween.Play(_isOpen);
			ColorChooser.Init(_isGrid ? GameSettings.DefaultGridColor : GameSettings.DefaultBackgroundColor);
			UpdateColor(ColorChooser.SelectedColor);
		}

		public void Update()
		{
			if (_isOpen)
			{
				UpdateColor(ColorChooser.SelectedColor);
				if (_isGrid)
				{
					GridBorder.color = SelectedColor;
					BackgroundBorder.color = NormalColor;
				}
				else
				{
					GridBorder.color = NormalColor;
					BackgroundBorder.color = SelectedColor;
				}
			}
			else
			{
				GridBorder.color = NormalColor;
				BackgroundBorder.color = NormalColor;
			}
		}

		private void UpdateColor(Color c)
		{
			if (_isGrid)
			{
				GridManager.SetGridColor(c);
				GridPreview.color = c;
				RuntimeGlobals.Settings.GridColor = c;
			}
			else
			{
				BackgroundCamera.backgroundColor = c;
				BackgroundPreview.color = c;
				RuntimeGlobals.Settings.BackgroundColor = c;
			}
		}
	}
}

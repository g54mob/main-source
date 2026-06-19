using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames
{
	public class MinigameProgressUI : UIView
	{
		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		private TextMeshProUGUI progressText;

		[SerializeField]
		private Image fillImage;

		[SerializeField]
		private Gradient progressGradient;

		private MinigameViewModel _viewModel;

		public void SetViewModel(MinigameViewModel viewModel)
		{
			_viewModel = viewModel;
			this.SetDataContext(_viewModel);
			BindViewModel();
		}

		private void BindViewModel()
		{
			this.CreateBindingSet<MinigameProgressUI, MinigameViewModel>().Build();
			_viewModel.BoltProgress.ValueChanged += UpdateProgress;
			_viewModel.IsEngaged.ValueChanged += UpdateEngagedState;
		}

		private void UpdateProgress(object sender, EventArgs e)
		{
			if (_viewModel != null)
			{
				float value = _viewModel.BoltProgress.Value;
				if (progressSlider != null)
				{
					progressSlider.maxValue = 2f;
					progressSlider.value = value;
				}
				if (progressText != null)
				{
					progressText.text = $"Progress: {value:F2} / 2.00";
				}
				if (fillImage != null && progressGradient != null)
				{
					float time = value / 2f;
					fillImage.color = progressGradient.Evaluate(time);
				}
				if (value >= 2f)
				{
					OnMinigameComplete();
				}
			}
		}

		private void UpdateEngagedState(object sender, EventArgs e)
		{
			_ = _viewModel;
		}

		private void OnMinigameComplete()
		{
			Debug.Log("Minigame completed!");
		}
	}
}

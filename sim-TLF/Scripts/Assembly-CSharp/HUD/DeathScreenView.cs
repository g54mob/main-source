using System.Collections;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Zenject;

namespace HUD
{
	public class DeathScreenView : UIView
	{
		[SerializeField]
		private Volume _transitionVolume;

		[SerializeField]
		private float _glitchDuration;

		[SerializeField]
		private Button _overlayButton;

		[SerializeField]
		private float _timeBeforeActive;

		private float _currentTime;

		[Inject]
		private DiContainer _diContainer;

		protected override void Awake()
		{
			_overlayButton.interactable = false;
			StartInteractionTimer();
		}

		private void StartInteractionTimer()
		{
			StartCoroutine(InteractionTimer());
		}

		private IEnumerator InteractionTimer()
		{
			while (_currentTime < _timeBeforeActive)
			{
				yield return new WaitForSeconds(Time.deltaTime);
				_currentTime += Time.deltaTime;
			}
			_overlayButton.interactable = true;
		}

		protected override void Start()
		{
			_transitionVolume.weight = 1f;
			DOTween.To(() => _transitionVolume.weight, delegate(float x)
			{
				_transitionVolume.weight = x;
			}, 0f, _glitchDuration);
			CreateBinding();
		}

		private void CreateBinding()
		{
			BindingSet<DeathScreenView, DeathScreenViewModel> bindingSet = this.CreateBindingSet<DeathScreenView, DeathScreenViewModel>();
			DeathScreenViewModel deathScreenViewModel = _diContainer.Instantiate<DeathScreenViewModel>();
			this.SetDataContext(deathScreenViewModel);
			bindingSet.Bind(_overlayButton).For((Button v) => v.onClick).To((DeathScreenViewModel vm) => vm.ScreenClickCommand)
				.OneWay();
			bindingSet.Build();
			_overlayButton.onClick.AddListener(delegate
			{
				_overlayButton.interactable = false;
			});
			deathScreenViewModel.DisableInput();
		}
	}
}

using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class FinalFireworksPage : BaseUIPage
	{
		[SerializeField]
		private ParticleEmitterManager _PfxEmitter;

		[SerializeField]
		private ParticleEmitterManager _FireworksEmitter;

		[SerializeField]
		private RectTransform _OkButton;

		[SerializeField]
		private RectTransform _DoneButton;

		[SerializeField]
		private Image _BGFader;

		[SerializeField]
		private Image _FGFader;

		[SerializeField]
		private TextMeshProUGUI _PanelText;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private GameObject _RayPrefab;

		[SerializeField]
		private RectTransform _RayContainer;

		[SerializeField]
		private Image _FakeFireworkPanel;

		[SerializeField]
		private RectTransform _ScaleContainer;

		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private TextMeshProUGUI _Tips;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private RectTransform _WeaponPanel;

		private List<Image> _rays;

		private List<Tween> _rayTweens;

		private List<ParticleSystem> _fireworks;

		private ParticleSystem _blackParticles;

		private ParticleSystem _colorParticles;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private List<string> _frames;

		[Inject]
		private void Construct(PlayerOptions player, DataManager data)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void CreateBlackParticles()
		{
		}

		private void AddItemPanel()
		{
		}

		private void PlayReveal()
		{
		}

		private void EnableDoneButton()
		{
		}

		public void OnOKButtonClicked()
		{
		}

		public void OnDoneClicked()
		{
		}

		private void OnExitScene()
		{
		}

		private void EnablePanelsInput()
		{
		}

		private void AddRays()
		{
		}

		private void StartFireworks()
		{
		}

		private void PlayFirework(int i)
		{
		}
	}
}

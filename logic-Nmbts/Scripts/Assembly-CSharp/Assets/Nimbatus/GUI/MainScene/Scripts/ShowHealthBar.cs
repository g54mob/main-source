using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowHealthBar : MonoBehaviour
	{
		public UISprite HealthBarSprite;

		private TweenPosition _tween;

		private HealthPool _selectedHealthPool;

		public void Awake()
		{
			_tween = GetComponent<TweenPosition>();
		}

		public void Initialize(HealthPool healthPool)
		{
			_selectedHealthPool = healthPool;
			_tween.PlayForward();
		}

		public void Hide()
		{
			_selectedHealthPool = null;
			_tween.PlayReverse();
		}

		public void Update()
		{
			if (HealthBarSprite != null && _selectedHealthPool != null)
			{
				HealthBarSprite.fillAmount = 1f / _selectedHealthPool.ActiveMaxHealth * _selectedHealthPool.CurrentHealth;
			}
		}
	}
}

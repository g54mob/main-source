using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Flotsam.Morale
{
	public class MoraleWarning : AgentReferenceUIElement
	{
		[SerializeField]
		private GameObject _warningGameObject;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private RangedFloat _displayInterval = new RangedFloat(45f, 75f);

		[SerializeField]
		private float _displayTime = 10f;

		private float _currentTimer;

		private float _displayTimer;

		private bool _hasNegativeMoraleModifiers;

		private void Update()
		{
			if (_warningGameObject.activeSelf)
			{
				_displayTimer += GameSpeedManager.PausableUnscaledDeltaTime;
				if (_displayTimer >= _displayTime)
				{
					_warningGameObject.SetActive(value: false);
				}
			}
			else if (_hasNegativeMoraleModifiers)
			{
				_currentTimer -= GameSpeedManager.PausableUnscaledDeltaTime;
				if (_currentTimer <= 0f)
				{
					DisplayWarning();
				}
			}
		}

		protected override void Subscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.AddListener(UpdateMorale);
			UpdateMorale();
		}

		protected override void Unsubscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.RemoveListener(UpdateMorale);
		}

		protected override void UpdateAgent(Agent agent)
		{
			base.UpdateAgent(agent);
			_currentTimer = _displayInterval.ReturnRandom();
			_currentTimer -= Random.Range(0f, _currentTimer);
		}

		private void UpdateMorale()
		{
			_currentTimer = _displayInterval.ReturnRandom();
			_hasNegativeMoraleModifiers = TryReturnMostPressingEffect(out var moraleEffect);
			if (_hasNegativeMoraleModifiers)
			{
				_iconImage.sprite = moraleEffect.ReturnSprite();
			}
		}

		private void DisplayWarning()
		{
			_currentTimer = _displayInterval.ReturnRandom();
			_displayTimer = 0f;
			_warningGameObject.SetActive(value: true);
		}

		private bool TryReturnMostPressingEffect(out MoraleEffect moraleEffect)
		{
			int num = 0;
			MoraleEffect moraleEffect2 = null;
			if (_agent.Morale.HasNegativeModifier())
			{
				MoraleEffect[] moraleEffects = _agent.Morale.MoraleEffects;
				foreach (MoraleEffect moraleEffect3 in moraleEffects)
				{
					int num2 = moraleEffect3.ReturnModifier();
					if (moraleEffect3.IsActive() && num2 < 0 && num2 < num)
					{
						moraleEffect2 = moraleEffect3;
						num = num2;
					}
				}
			}
			moraleEffect = moraleEffect2;
			return moraleEffect != null;
		}

		public bool IsActive()
		{
			return _warningGameObject.activeSelf;
		}
	}
}

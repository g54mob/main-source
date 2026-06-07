using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DefensiveParts
{
	public class EnergyShield : BindableDronePart, IEnergyConsumer
	{
		private KeyBinding _activateShield;

		public string ShieldSound;

		public float Durability;

		public float RechargeSpeed;

		public float ScaleSpeed;

		public float ShieldSize;

		public int EnergyPerSecond;

		public float ImpactForce;

		public tk2dSprite Led;

		public Color FullColor;

		public Color UseColor;

		public Color EmptyColor;

		public Color BrokenColor;

		public GrowableShield Shield;

		private bool _isActive;

		private bool _isBroken;

		private float _time;

		private bool _hasImprovedShield;

		private float _shieldSize;

		private float _shieldBaseDurability;

		private float _currentDurability;

		public override List<KeyBinding> GetKeyBindings()
		{
			_activateShield = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _activateShield };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			if (effects != null)
			{
				_hasImprovedShield = effects.OfType<ImprovedEnergyShield>().Any();
			}
			_shieldSize = ShieldSize;
			if (_hasImprovedShield)
			{
				_shieldSize = ShieldSize * 2f;
			}
			_shieldBaseDurability = Durability;
			_currentDurability = Durability;
			if (_hasImprovedShield)
			{
				_shieldBaseDurability = Durability * 2f;
			}
		}

		protected override void Start()
		{
			base.Start();
			Shield.Init(this, RootDrone.ShieldDetectionLayer);
			_currentDurability = _shieldBaseDurability;
			Led.color = FullColor;
		}

		public override void FixedUpdate()
		{
			if (IsActive())
			{
				if (_activateShield.IsPressed(KeyEventHub) && !_isBroken)
				{
					float amount = (float)EnergyPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(EResourceType.Energy, EnergyPerSecond))
					{
						_isActive = true;
						base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, amount);
					}
					else
					{
						_isActive = false;
					}
				}
				else
				{
					_isActive = false;
				}
			}
			else
			{
				_isActive = false;
			}
			if (_currentDurability <= 0f)
			{
				_isActive = false;
				_isBroken = true;
			}
			if (_currentDurability >= _shieldBaseDurability)
			{
				_isBroken = false;
			}
			else if (!_isActive)
			{
				_currentDurability += RechargeSpeed * Time.fixedDeltaTime;
			}
			if (_isBroken)
			{
				Led.color = BrokenColor;
			}
			else
			{
				float num = _currentDurability / _shieldBaseDurability;
				if (num > 0.666f)
				{
					Led.color = FullColor;
				}
				else
				{
					_time += Time.fixedDeltaTime;
					Color color = Color.Lerp(EmptyColor, UseColor, num);
					Led.color = color;
					if (num < 0.333f)
					{
						Led.color = Color.Lerp(color, Color.black, (Mathf.Cos(_time * ((0.25f - num) * 15f) * 3.1415f) + 1f) / 2f);
					}
				}
			}
			if (_isActive)
			{
				StartSoundLoop(ShieldSound);
				Shield.transform.localScale = Vector3.Lerp(Shield.transform.localScale, Vector3.one * _shieldSize, ScaleSpeed * Time.fixedDeltaTime);
			}
			else
			{
				StopActiveSoundLoop();
				Shield.transform.localScale = Vector3.Lerp(Shield.transform.localScale, Vector3.one * 0f, ScaleSpeed * Time.fixedDeltaTime);
			}
			ShowRadius = true;
			DisplayRadius = _shieldSize / 2f;
			base.FixedUpdate();
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			if (_hasImprovedShield)
			{
				text = text + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("DronePartSettings/ImprovedShield") + LabelHelper.NewLine;
			}
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Durability") + ": " + LabelHelper.Orange + _shieldBaseDurability + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Size") + ": " + LabelHelper.Orange + _shieldSize + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond;
		}

		public void TakeShieldDamage(float damage)
		{
			_currentDurability -= damage;
		}
	}
}

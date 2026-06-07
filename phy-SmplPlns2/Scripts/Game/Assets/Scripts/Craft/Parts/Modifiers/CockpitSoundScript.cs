using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CockpitSoundScript : PartModifierScript
	{
		private Func<float> _multiplierFunc;

		private float _baseIntensity;

		private CockpitSoundData _data;

		public float Intensity { get; private set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(CockpitSoundData data)
		{
			_data = data;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdateFlightLocal, CraftUpdateFlags.FlightLocal);
		}

		private void OnFixedUpdateFlightLocal(in CraftUpdateFrameData frame)
		{
			if (_multiplierFunc != null)
			{
				Intensity = _baseIntensity * Mathf.Clamp01(1f - _multiplierFunc());
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_baseIntensity = Mathf.Clamp01(_data.Intensity);
				int ag;
				if (_data.ActivationGroup == "AlwaysOn")
				{
					Intensity = _baseIntensity;
				}
				else if (_data.ActivationGroup == "AlwaysOff")
				{
					Intensity = 0f;
				}
				else if (int.TryParse(_data.ActivationGroup, out ag) && ag >= 1 && ag <= 8)
				{
					_multiplierFunc = () => (!base.PartScript.Aircraft.Controls.GetActivationState(ag)) ? 0f : 1f;
					Intensity = _baseIntensity;
				}
				else
				{
					_multiplierFunc = base.PartScript.Aircraft.Controls.GetAxisGetter(_data.ActivationGroup, -1f, base.PartScript, returnNull: true);
					Intensity = _baseIntensity;
				}
			}
			return UniTask.CompletedTask;
		}
	}
}

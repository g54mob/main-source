using Gh.Tk;
using UnityEngine;
using UnityEngine.UI;

namespace Gk.Tk
{
	public class SmallFireIcon : MonoBehaviour
	{
		public GameObject FireButton;

		public Image CurrentTemperatureFillBar;

		public Image TrailingTemperatureFillBar;

		public GameObject FireParticles;

		public GameObject SuccessParticles;

		private GameObjectX _targetGox;

		private bool _isIconBurning;

		private float _burningTime;

		private float _targetBurningTime;

		private float _currentTrailingTemperatureFillBarValue;

		private float _currentTrailingTemperatureVelocity;

		private const float TrailingFillBarSmoothTime = 1.3f;

		private const float MaxSmoothSpeed = 1f / 0f;

		private const float BurnoutDuration = 3f;

		private const float SuccessDuration = 2f;

		private const float FillAmountThreshold = 0.001f;

		private const float MinStartLifetime = 0.15f;

		private const float MaxStartLifetime = 0.3f;

		private const float MinEmissionRate = 2f;

		private const float MaxEmissionRate = 5f;

		public GameObjectX TargetGox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Update()
		{
		}

		private void UpdateVisuals()
		{
		}

		private void HandleFireProgress()
		{
		}

		private void UpdateTemperatureBars(float fireProgress)
		{
		}

		private void CheckFireDepletion()
		{
		}

		private void HandleBurningState()
		{
		}

		private void ResetTemperatureBars()
		{
		}

		private void EnableFireBurning(bool enable)
		{
		}

		private void EnableSuccess(bool enable)
		{
		}

		private void ResetBurningState()
		{
		}
	}
}

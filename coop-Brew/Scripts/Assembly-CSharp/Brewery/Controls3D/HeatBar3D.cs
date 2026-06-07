using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class HeatBar3D : MonoBehaviour
	{
		[Header("Progress Bar")]
		[SerializeField]
		private ProgressBar3D progressBar;

		[Header("Zone Thresholds")]
		[Tooltip("Heat values 0 to greenMax = green zone")]
		[SerializeField]
		private float greenMax;

		[Tooltip("Heat values greenMax to yellowMax = yellow zone")]
		[SerializeField]
		private float yellowMax;

		[Header("Zone Colors")]
		[SerializeField]
		private Color greenColor;

		[SerializeField]
		private Color yellowColor;

		[SerializeField]
		private Color redColor;

		[Header("Zone Blades")]
		[Tooltip("Blade transforms sized to show each zone's extent")]
		[SerializeField]
		private Transform greenBlade;

		[SerializeField]
		private Transform yellowBlade;

		[SerializeField]
		private Transform redBlade;

		[Header("Heat Settings")]
		[SerializeField]
		private float decayRate;

		[SerializeField]
		private float heatPerClick;

		[SerializeField]
		private float coolPerClick;

		[Header("Overheat")]
		[Tooltip("Seconds the bar stays locked at max when the player overheats")]
		[SerializeField]
		private float overheatLockDuration;

		[Header("Animation — Heat Add")]
		[Tooltip("LeanTween overshoot when AddHeat is clicked")]
		[SerializeField]
		private TweenConfig heatAddAnimation;

		[Tooltip("How far above the actual heat value the display overshoots (0-1)")]
		[SerializeField]
		private float heatOvershoot;

		[Header("Animation — Smooth Follow")]
		[Tooltip("How quickly the display follows the heat value during decay (seconds)")]
		[SerializeField]
		private float heatSmoothTime;

		private float heat;

		private int currentZone;

		private bool isOverheated;

		private float overheatTimer;

		private float displayHeat;

		private float smoothVelocity;

		private int heatTweenId;

		private Action<float> cachedSetDisplayHeat;

		public float Heat => 0f;

		public int CurrentZone => 0;

		public bool IsOverheated => false;

		public event Action<int> OnZoneChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void AddHeat()
		{
		}

		public void RemoveHeat()
		{
		}

		public void ResetHeat()
		{
		}

		private void UpdateVisuals()
		{
		}

		private int GetZoneForValue(float value)
		{
			return 0;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}

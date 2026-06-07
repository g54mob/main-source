using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Drones.UI
{
	public class DroneController : RComponent
	{
		[Header("References")]
		[SerializeField]
		protected SpriteRenderer spriteRenderer;

		[SerializeField]
		protected Animator animator;

		[SerializeField]
		private RComponent _boostDroneGO;

		[SerializeField]
		private RComponent _supervisorDroneSprite;

		[Header("Settings")]
		[SerializeField]
		private float smoothTime;

		private Drone _drone;

		private Vector3 _velocity;

		private Vector3 _previousPosition;

		protected bool _isFading;

		protected float _fadeStartTime;

		protected float _fadeDuration;

		protected float _fadeStartAlpha;

		protected float _fadeTargetAlpha;

		private readonly CatLogger _logger;

		public Drone Drone => null;

		public virtual void Initialize(Drone drone)
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		public void OnClick()
		{
		}

		private void OnStateChanged()
		{
		}

		private void StartHitAnimation()
		{
		}

		public void OnHitEvent()
		{
		}

		public void OnHitCompleteEvent()
		{
		}

		protected void StartFade(float targetAlpha, float duration)
		{
		}

		protected void UpdateFade()
		{
		}

		public void Remove()
		{
		}
	}
}

using System;
using Restory.Constants;
using Restory.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderingVfxController : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem solderingVfx;

		private readonly RaycastHit[] raysHits = new RaycastHit[1];

		private readonly float maxDistance = 5f;

		private readonly float vfxStopCooldown = 0.6f;

		private IPlayerInput playerInput;

		private Camera gameCamera;

		private bool isPlaying;

		private float vfxStopTimer;

		public event Action OnVfxStarted;

		public event Action OnVfxStopped;

		public event Action OnVfxCleared;

		[Inject]
		public void Construct(IPlayerInput playerInput, [Inject(Id = "GameCamera")] Camera gameCamera)
		{
			this.playerInput = playerInput;
			this.gameCamera = gameCamera;
		}

		private void Start()
		{
			base.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			if (Physics.RaycastNonAlloc(gameCamera.ScreenPointToRay(playerInput.GetMousePosition()), raysHits, maxDistance, ProjectConstants.Layers.DeviceMask) == 0)
			{
				ClearSolderingVfx();
				return;
			}
			base.transform.position = raysHits[0].point;
			if (isPlaying)
			{
				if (vfxStopTimer > vfxStopCooldown)
				{
					Stop();
				}
				else
				{
					vfxStopTimer += Time.deltaTime;
				}
			}
		}

		private void OnDisable()
		{
			ClearSolderingVfx();
		}

		public void Activate()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Deactivate()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Play()
		{
			vfxStopTimer = 0f;
			if (!isPlaying)
			{
				isPlaying = true;
				solderingVfx.Play();
				this.OnVfxStarted?.Invoke();
			}
		}

		public void Stop()
		{
			if (isPlaying)
			{
				isPlaying = false;
				solderingVfx.Stop();
				this.OnVfxStopped?.Invoke();
			}
		}

		private void ClearSolderingVfx()
		{
			if (isPlaying)
			{
				isPlaying = false;
				solderingVfx.Stop();
				solderingVfx.Clear();
				this.OnVfxCleared?.Invoke();
			}
		}
	}
}

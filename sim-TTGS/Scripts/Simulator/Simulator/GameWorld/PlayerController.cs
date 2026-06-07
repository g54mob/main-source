using UnityEngine;

namespace Simulator.GameWorld
{
	public class PlayerController : Controller
	{
		public delegate void ControllableChange(IControllable former, IControllable next);

		[SerializeField]
		private PlayerSensor m_sensor;

		[SerializeField]
		private HUD m_hud;

		public PlayerSensor Sensor => m_sensor;

		public HUD Hud => m_hud;

		public override bool IsPlayer => true;

		public static event ControllableChange ControllableChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_sensor.SetActive(active: false);
			m_hud.SetActive(active: false);
			EventManager.OnWorldEvent += OnWorldEvent;
			EventManager.OnGameEvent += OnGameEvent;
			EventManager.OnMenuEvent += OnMenuEvent;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			EventManager.OnWorldEvent -= OnWorldEvent;
			EventManager.OnGameEvent -= OnGameEvent;
			EventManager.OnMenuEvent -= OnMenuEvent;
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.WORLD_REGISTRATION:
				World.RegisterSingletonStatic(this);
				break;
			case EWorldEvent.INITIALISATION:
				TakeControlOfCharacter();
				break;
			case EWorldEvent.START:
				m_sensor.SetActive(active: true);
				m_hud.SetActive(active: true);
				break;
			case EWorldEvent.LOADING_PHASE1:
			case EWorldEvent.LOADING_PHASE2:
				break;
			}
		}

		private void OnGameEvent(EGameEvent gameEvent)
		{
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				m_sensor.SetActive(active: true);
				m_hud.SetActive(active: true);
				break;
			case EGameEvent.DAY_END:
				m_sensor.SetActive(active: false);
				m_hud.SetActive(active: false);
				break;
			}
		}

		private void OnMenuEvent(EMenuEvent menuEvent)
		{
			switch (menuEvent)
			{
			case EMenuEvent.OPEN:
				m_sensor.SetActive(active: false);
				m_hud.SetActive(active: false);
				break;
			case EMenuEvent.CLOSE:
				m_sensor.SetActive(active: true);
				m_hud.SetActive(active: true);
				break;
			}
		}

		protected override void OnTakeControl(IControllable controllable)
		{
			base.OnTakeControl(controllable);
			if (base.Controllable.Camera != null)
			{
				base.Controllable.Camera.Priority = 1;
			}
		}

		protected override void OnLeaveControl()
		{
			if (base.Controllable != null && base.Controllable.Camera != null)
			{
				base.Controllable.Camera.Priority = 0;
			}
			base.OnLeaveControl();
		}

		protected override void OnChangeControllable(IControllable former, IControllable next)
		{
			base.OnChangeControllable(former, next);
			PlayerController.ControllableChanged?.Invoke(former, next);
		}

		protected override void GetInputReceiver(IControllable controllable)
		{
			if (base.Controllable is IPlayerInputReceiver current)
			{
				IPlayerInputReceiver.SetCurrent(current);
			}
			else
			{
				LoseInputReceiver();
			}
		}

		protected override void LoseInputReceiver()
		{
			IPlayerInputReceiver.SetCurrent(null);
		}

		public void TakeControlOfCharacter()
		{
			TakeControl(World.PlayerCharacter);
		}
	}
}

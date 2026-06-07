using DV.Utils;
using UnityEngine;

namespace DV.RailDriver
{
	public class RailDriverDisplayDV : SingletonBehaviour<RailDriverDisplayDV>
	{
		private const float NOTIFICATION_TIMER = 0.4f;

		private float displayNotificationTimer;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			RailDriver.ConnectedStatusChanged += OnConnect;
			OnConnect(RailDriver.IsConnected);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			RailDriver.ConnectedStatusChanged -= OnConnect;
		}

		private void OnConnect(bool connected)
		{
			base.enabled = connected;
		}

		private void Update()
		{
			if (displayNotificationTimer > 0f)
			{
				displayNotificationTimer -= Time.deltaTime;
				return;
			}
			RailDriver.Wrapper activeWrapper = SingletonBehaviour<RailDriver>.Instance.activeWrapper;
			TrainCar car = PlayerManager.Car;
			if (!car)
			{
				activeWrapper.WriteDisplay(RailDriver.DisplayBuffer.EMPTY);
				return;
			}
			float absSpeed = car.GetAbsSpeed();
			activeWrapper.WriteDisplay(new RailDriver.DisplayBuffer(Mathf.RoundToInt(absSpeed * 3.6f)));
		}

		public static void DisplayNotification(RailDriver.DisplayBuffer buffer)
		{
			if (RailDriver.IsConnected)
			{
				if ((bool)SingletonBehaviour<RailDriverDisplayDV>.Instance)
				{
					SingletonBehaviour<RailDriverDisplayDV>.Instance.displayNotificationTimer = 0.4f;
				}
				SingletonBehaviour<RailDriver>.Instance.activeWrapper.WriteDisplay(buffer);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class PlayerController : InitializePlayer
	{
		private enum DeviceType
		{
			ConcoleOrPC = 0,
			Mobile = 1
		}

		public List<InitializePlayer> InitializeObjects;

		public bool NeedAddAudiolistinerToCar;

		public static PlayerController Instance;

		public VehicleUIController vehicleUI;

		public bool CanExitFromCar { get; private set; }

		public event Action<CarController> OnExitAction
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

		public static PlayerController GetOrCreatePlayerController()
		{
			return null;
		}

		private void Awake()
		{
		}

		protected override void Start()
		{
		}

		public void SetWorldPos(Transform targetPoint)
		{
		}

		public void EnterInCar(CarController car)
		{
		}

		public void ExitFromCar()
		{
		}

		public override bool Initialize(VehicleController vehicle)
		{
			return false;
		}

		public override void Uninitialize()
		{
		}

		private void OnDestroy()
		{
		}
	}
}

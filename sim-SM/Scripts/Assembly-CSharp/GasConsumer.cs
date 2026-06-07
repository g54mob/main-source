using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PG;
using UnityEngine;

public class GasConsumer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRefuelLoop_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GasConsumer _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRefuelLoop_003Ed__39(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private VehicleUIController vehicleUIController;

	[SerializeField]
	private float _GasUnitPrice;

	[SerializeField]
	private float _ConsumeSpeed;

	[SerializeField]
	private float _CurrentGasLevel;

	[SerializeField]
	private float _MaxGasLevel;

	private const string GasStationTag = "GasStation";

	private CarController m_OwnCarController;

	private float m_FillRate;

	private Rigidbody _Rb;

	private VehicleData m_VehicleData;

	private VehicleDataLoader m_VehicleDataLoader;

	private bool m_IsOutOfGasNotfySended;

	private bool m_IsOutOfGasNotfySended_20;

	private bool m_IsOutOfGasNotfySended_10;

	private VehicleInteraction m_VehicleInteraction;

	private bool m_IsVehicleInGasStation;

	private Coroutine m_RefuelCoroutine;

	private List<GasStationPump> m_GasStationPumps;

	private int m_TriggerEnterCount;

	private float startAmount;

	private float endAmount;

	public VehicleUIController VehicleUIController
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float CurrentGasLevel
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnStartEngine(float obj)
	{
	}

	private void OnSaveRequested()
	{
	}

	private bool IsVehicleActive()
	{
		return false;
	}

	private void Update()
	{
	}

	private void ConsumeGas()
	{
	}

	private void LoadGasLevel()
	{
	}

	private void ApplyRefuelCost(float _startAmount, float _endAmount)
	{
	}

	private bool CalculateRefuelCost(float startAmount, float endAmount, out float cost)
	{
		cost = default(float);
		return false;
	}

	private bool HasRefuelMoney()
	{
		return false;
	}

	private void Refuel()
	{
	}

	[IteratorStateMachine(typeof(_003CRefuelLoop_003Ed__39))]
	private IEnumerator RefuelLoop()
	{
		return null;
	}

	private void StopCarEngine()
	{
	}

	public void TeleportVehicleToGasStation()
	{
	}

	public void RefuelPressed(bool _IsRefuelPressed)
	{
	}

	public void UpdateGasLevel()
	{
	}

	public bool HasGas()
	{
		return false;
	}

	public bool IsFull()
	{
		return false;
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void OnVehicleEntered()
	{
	}
}

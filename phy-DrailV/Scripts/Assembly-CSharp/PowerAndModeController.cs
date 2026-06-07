using Stateless;
using UnityEngine;

public class PowerAndModeController
{
	public delegate void PowerAndModeChangedDelegate(bool isOn, bool isRadio);

	private enum State
	{
		Radio_Off = 0,
		Radio_On = 1,
		Cassette_Off = 2,
		Cassette_On = 3
	}

	private enum Trigger
	{
		Turn_On = 0,
		Turn_Off = 1,
		Switch_To_Cassette = 2,
		Switch_To_Radio = 3
	}

	private bool isOn;

	private State state = State.Cassette_Off;

	private StateMachine<State, Trigger> fsm;

	public event PowerAndModeChangedDelegate PowerAndModeChanged;

	public void TurnOn()
	{
		fsm.Fire(Trigger.Turn_On);
	}

	public void TurnOff()
	{
		fsm.Fire(Trigger.Turn_Off);
	}

	public void SwitchToRadio()
	{
		fsm.Fire(Trigger.Switch_To_Radio);
	}

	public void SwitchToCassette()
	{
		fsm.Fire(Trigger.Switch_To_Cassette);
	}

	public void OnPowerSwitched(bool on)
	{
		fsm.Fire((!on) ? Trigger.Turn_Off : Trigger.Turn_On);
	}

	public void OnModeSwitched(bool isRadio)
	{
		fsm.Fire(isRadio ? Trigger.Switch_To_Radio : Trigger.Switch_To_Cassette);
	}

	public bool IsPoweredOn()
	{
		if (fsm.State != State.Radio_On)
		{
			return fsm.State == State.Cassette_On;
		}
		return true;
	}

	public bool IsInRadioMode()
	{
		if (fsm.State != State.Radio_On)
		{
			return fsm.State == State.Radio_Off;
		}
		return true;
	}

	private StateMachine<State, Trigger> MakeFSM()
	{
		StateMachine<State, Trigger> stateMachine = new StateMachine<State, Trigger>(() => state, delegate(State s)
		{
			state = s;
		});
		stateMachine.Configure(State.Radio_Off).OnEntry(Entry_Radio_Off).Permit(Trigger.Switch_To_Cassette, State.Cassette_Off)
			.Permit(Trigger.Turn_On, State.Radio_On);
		stateMachine.Configure(State.Radio_On).OnEntry(Entry_Radio_On).Permit(Trigger.Switch_To_Cassette, State.Cassette_On)
			.Permit(Trigger.Turn_Off, State.Radio_Off);
		stateMachine.Configure(State.Cassette_Off).OnEntry(Entry_Cassette_Off).Permit(Trigger.Switch_To_Radio, State.Radio_Off)
			.Permit(Trigger.Turn_On, State.Cassette_On);
		stateMachine.Configure(State.Cassette_On).OnEntry(Entry_Cassette_On).Permit(Trigger.Switch_To_Radio, State.Radio_On)
			.Permit(Trigger.Turn_Off, State.Cassette_Off);
		stateMachine.OnUnhandledTrigger(delegate(State state, Trigger trigger)
		{
			Debug.LogWarning($"[PowerAndMode] Unhandled trigger '{trigger}' for state '{state}'");
		});
		return stateMachine;
	}

	public PowerAndModeController()
	{
		fsm = MakeFSM();
	}

	private void Entry_Radio_Off()
	{
		this.PowerAndModeChanged?.Invoke(isOn: false, isRadio: true);
	}

	private void Entry_Radio_On()
	{
		this.PowerAndModeChanged?.Invoke(isOn: true, isRadio: true);
	}

	private void Entry_Cassette_Off()
	{
		this.PowerAndModeChanged?.Invoke(isOn: false, isRadio: false);
	}

	private void Entry_Cassette_On()
	{
		this.PowerAndModeChanged?.Invoke(isOn: true, isRadio: false);
	}
}

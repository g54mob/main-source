using System;
using Timberborn.Automation;
using Timberborn.BaseComponentSystem;
using Timberborn.DuplicationSystem;
using Timberborn.Persistence;
using Timberborn.WorldPersistence;

namespace Timberborn.AutomationBuildings
{
	public class Relay : BaseComponent, IAwakableComponent, IPersistentEntity, IDuplicable<Relay>, IDuplicable, ICombinationalTransmitter, ITransmitter
	{
		private static readonly ComponentKey RelayKey = new ComponentKey("Relay");

		private static readonly PropertyKey<RelayMode> ModeKey = new PropertyKey<RelayMode>("Mode");

		private static readonly PropertyKey<Automator> InputAKey = new PropertyKey<Automator>("InputA");

		private static readonly PropertyKey<Automator> InputBKey = new PropertyKey<Automator>("InputB");

		private readonly ReferenceSerializer _referenceSerializer;

		private AutomatorConnection _inputA;

		private AutomatorConnection _inputB;

		private Automator _automator;

		public RelayMode Mode { get; private set; }

		public Automator InputA => _inputA.Transmitter;

		public Automator InputB => _inputB.Transmitter;

		public bool UsesInputB => Mode switch
		{
			RelayMode.Not => false, 
			RelayMode.And => true, 
			RelayMode.Or => true, 
			RelayMode.Xor => true, 
			RelayMode.Passthrough => false, 
			_ => throw new ArgumentOutOfRangeException($"Unexpected value: {Mode}"), 
		};

		public Relay(ReferenceSerializer referenceSerializer)
		{
			_referenceSerializer = referenceSerializer;
		}

		public void Awake()
		{
			_automator = GetComponent<Automator>();
			_inputA = _automator.AddInput();
			_inputB = _automator.AddInput();
		}

		public void Save(IEntitySaver entitySaver)
		{
			IObjectSaver component = entitySaver.GetComponent(RelayKey);
			component.Set(ModeKey, Mode);
			if ((bool)InputA)
			{
				component.Set(InputAKey, InputA, _referenceSerializer.Of<Automator>());
			}
			if ((bool)InputB)
			{
				component.Set(InputBKey, InputB, _referenceSerializer.Of<Automator>());
			}
		}

		public void Load(IEntityLoader entityLoader)
		{
			IObjectLoader component = entityLoader.GetComponent(RelayKey);
			Mode = component.Get(ModeKey);
			if (component.Has(InputAKey) && component.GetObsoletable(InputAKey, _referenceSerializer.Of<Automator>(), out var value))
			{
				_inputA.Connect(value);
			}
			if (UsesInputB && component.Has(InputBKey) && component.GetObsoletable(InputBKey, _referenceSerializer.Of<Automator>(), out var value2))
			{
				_inputB.Connect(value2);
			}
		}

		public void DuplicateFrom(Relay source)
		{
			SetMode(source.Mode);
			_inputA.Connect(source.InputA);
			_inputB.Connect(source.InputB);
			Evaluate();
		}

		public void SetMode(RelayMode relayMode)
		{
			Mode = relayMode;
			if (!UsesInputB)
			{
				_inputB.Disconnect();
			}
			Evaluate();
		}

		public void SetInputA(Automator automator)
		{
			_inputA.Connect(automator);
		}

		public void SetInputB(Automator automator)
		{
			if (UsesInputB)
			{
				_inputB.Connect(automator);
			}
		}

		public void Evaluate()
		{
			Automator automator = _automator;
			automator.SetState(Mode switch
			{
				RelayMode.Not => !_inputA.BooleanState, 
				RelayMode.And => _inputA.BooleanState && _inputB.BooleanState, 
				RelayMode.Or => _inputA.BooleanState || _inputB.BooleanState, 
				RelayMode.Xor => _inputA.BooleanState ^ _inputB.BooleanState, 
				RelayMode.Passthrough => _inputA.BooleanState, 
				_ => throw new ArgumentOutOfRangeException($"Unexpected value: {Mode}"), 
			});
		}
	}
}

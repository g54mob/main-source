using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTC
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	[TaskCategory(" TH20")]
	public class HasReceivedGameEvent : Conditional
	{
		[Tooltip("The name of the event to receive")]
		public SharedString _eventName = "";

		[SharedRequired]
		[Tooltip("Optionally store the first sent argument")]
		public SharedVariable _storedValue1;

		[SharedRequired]
		[Tooltip("Optionally store the second sent argument")]
		public SharedVariable _storedValue2;

		[SharedRequired]
		[Tooltip("Optionally store the third sent argument")]
		public SharedVariable _storedValue3;

		private bool _eventReceived;

		private bool _registered;

		public override void OnAwake()
		{
			base.OnAwake();
			if (!_registered)
			{
				base.Owner.RegisterEvent(_eventName.Value, ReceivedEvent);
				base.Owner.RegisterEvent<object>(_eventName.Value, ReceivedEvent);
				base.Owner.RegisterEvent<object, object>(_eventName.Value, ReceivedEvent);
				base.Owner.RegisterEvent<object, object, object>(_eventName.Value, ReceivedEvent);
				_registered = true;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (!_eventReceived)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}

		public override void OnEnd()
		{
			_eventReceived = false;
		}

		private void ReceivedEvent()
		{
			_eventReceived = true;
		}

		private void ReceivedEvent(object arg1)
		{
			ReceivedEvent();
			if (_storedValue1 != null && !_storedValue1.IsNone)
			{
				_storedValue1.SetValue(arg1);
			}
		}

		private void ReceivedEvent(object arg1, object arg2)
		{
			ReceivedEvent();
			if (_storedValue1 != null && !_storedValue1.IsNone)
			{
				_storedValue1.SetValue(arg1);
			}
			if (_storedValue2 != null && !_storedValue2.IsNone)
			{
				_storedValue2.SetValue(arg2);
			}
		}

		private void ReceivedEvent(object arg1, object arg2, object arg3)
		{
			ReceivedEvent();
			if (_storedValue1 != null && !_storedValue1.IsNone)
			{
				_storedValue1.SetValue(arg1);
			}
			if (_storedValue2 != null && !_storedValue2.IsNone)
			{
				_storedValue2.SetValue(arg2);
			}
			if (_storedValue3 != null && !_storedValue3.IsNone)
			{
				_storedValue3.SetValue(arg3);
			}
		}

		public override void OnBehaviorComplete()
		{
			if (_registered)
			{
				base.Owner.UnregisterEvent(_eventName.Value, ReceivedEvent);
				base.Owner.UnregisterEvent<object>(_eventName.Value, ReceivedEvent);
				base.Owner.UnregisterEvent<object, object>(_eventName.Value, ReceivedEvent);
				base.Owner.UnregisterEvent<object, object, object>(_eventName.Value, ReceivedEvent);
			}
			_eventReceived = false;
		}

		public override void OnReset()
		{
			_eventName = "";
		}
	}
}

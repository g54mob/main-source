using System;
using UnityEngine;

namespace R3
{
	[Serializable]
	public class SerializableReactiveProperty<T> : ReactiveProperty<T>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private T value;

		public SerializableReactiveProperty()
			: base(default(T))
		{
		}

		public SerializableReactiveProperty(T value)
			: base(value)
		{
		}

		protected override void OnValueChanged(T value)
		{
			this.value = value;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			GetValueRef() = value;
		}
	}
}

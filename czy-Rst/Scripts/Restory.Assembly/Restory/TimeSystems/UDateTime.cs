using System;
using UnityEngine;

namespace Restory.TimeSystems
{
	[Serializable]
	public class UDateTime : ISerializationCallbackReceiver
	{
		[SerializeField]
		private DateTime dateTime;

		[HideInInspector]
		[SerializeField]
		private long dateTimeTicks;

		public DateTime DateTime => dateTime;

		public UDateTime(DateTime dateTime)
		{
			Set(dateTime);
		}

		public void Add(TimeSpan timeSpan)
		{
			dateTime = dateTime.Add(timeSpan);
		}

		public void Set(DateTime dateTime)
		{
			this.dateTime = dateTime;
			OnBeforeSerialize();
		}

		public static implicit operator DateTime(UDateTime udt)
		{
			return udt.dateTime;
		}

		public static implicit operator UDateTime(DateTime dt)
		{
			return new UDateTime(dt);
		}

		public void OnAfterDeserialize()
		{
			dateTime = new DateTime(dateTimeTicks);
		}

		public void OnBeforeSerialize()
		{
			dateTimeTicks = dateTime.Ticks;
		}
	}
}

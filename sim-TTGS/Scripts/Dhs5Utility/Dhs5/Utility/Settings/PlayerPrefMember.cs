using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public abstract class PlayerPrefMember
	{
	}
	[Serializable]
	public abstract class PlayerPrefMember<T> : PlayerPrefMember
	{
		[SerializeField]
		private string m_key;

		[SerializeField]
		private T m_default;

		[SerializeField]
		protected T m_current;

		protected virtual string Key => m_key;

		protected T Default => m_default;

		public T Value
		{
			get
			{
				if (!Application.isPlaying)
				{
					return m_default;
				}
				return m_current;
			}
			set
			{
				m_current = value;
				Save(m_current);
				this.OnValueChanged?.Invoke(m_current);
			}
		}

		public event Action<T> OnValueChanged;

		public void Reset()
		{
			Value = Default;
		}

		public abstract void Load();

		public abstract void Save(T value);

		public static implicit operator T(PlayerPrefMember<T> member)
		{
			return member.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}

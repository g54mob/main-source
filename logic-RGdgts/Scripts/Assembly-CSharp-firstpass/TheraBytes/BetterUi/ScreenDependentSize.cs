using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public abstract class ScreenDependentSize<T> : ScreenDependentSize, IScreenConfigConnection
	{
		[SerializeField]
		private string screenConfigName;

		public T OptimizedSize;

		public T MinSize;

		public T MaxSize;

		protected T value;

		public override string ScreenConfigName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public T LastCalculatedSize => default(T);

		protected ScreenDependentSize(T opt, T min, T max, T initValue)
		{
		}

		public T CalculateSize(Component caller)
		{
			return default(T);
		}

		protected float GetSize(float factor, float opt, float min, float max)
		{
			return 0f;
		}

		public void SetSize(Component caller, T size)
		{
		}

		public void OverrideLastCalculatedSize(T newValue)
		{
		}

		protected abstract void CalculateOptimizedSize(T baseValue, float factor, SizeModifierCollection mod, int index);
	}
	[Serializable]
	public abstract class ScreenDependentSize
	{
		public abstract string ScreenConfigName { get; set; }

		protected void UpdateSize(Component caller)
		{
		}

		public virtual void DynamicInitialization()
		{
		}

		public abstract IEnumerable<SizeModifierCollection> GetModifiers();

		protected abstract void AdjustSize(float factor, SizeModifierCollection mod, int index);
	}
}

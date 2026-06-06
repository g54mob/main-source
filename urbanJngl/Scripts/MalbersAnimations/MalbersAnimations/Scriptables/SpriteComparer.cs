using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Variables/Sprite Comparer")]
	public class SpriteComparer : VarListener
	{
		[Serializable]
		public class SpriteComparerUnit
		{
			public SpriteReference Target;

			public SpriteEvent Equal = new SpriteEvent();

			public SpriteEvent NotEqual = new SpriteEvent();
		}

		public SpriteReference value;

		public SpriteComparerUnit[] sprites;

		private void OnEnable()
		{
			if (value.Variable != null)
			{
				SpriteVar variable = value.Variable;
				variable.OnValueChanged = (Action<Sprite>)Delegate.Combine(variable.OnValueChanged, new Action<Sprite>(Invoke));
			}
			if (InvokeOnEnable)
			{
				Invoke(value.Value);
			}
		}

		private void OnDisable()
		{
			if (value.Variable != null)
			{
				SpriteVar variable = value.Variable;
				variable.OnValueChanged = (Action<Sprite>)Delegate.Remove(variable.OnValueChanged, new Action<Sprite>(Invoke));
			}
		}

		public virtual void Invoke(Sprite value)
		{
			for (int i = 0; i < sprites.Length; i++)
			{
				SpriteComparerUnit spriteComparerUnit = sprites[i];
				if (value == spriteComparerUnit.Target.Value)
				{
					spriteComparerUnit.Equal.Invoke(value);
					Debbuging($"Sprite Target [{spriteComparerUnit.Target.Value.name}][{i}] is equal to the current Value");
				}
				else
				{
					spriteComparerUnit.NotEqual.Invoke(value);
					Debbuging($"Sprite Target [{spriteComparerUnit.Target.Value.name}][{i}] is NOT equal to the Current Value");
				}
			}
		}

		public virtual void Invoke()
		{
			Invoke(value.Value);
		}

		private void Debbuging(string log)
		{
			if (debug)
			{
				Debug.Log(base.name + ": <B>" + log + "</B>", this);
			}
		}
	}
}

using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/UI/Value to String")]
	public class ValueToString : MonoBehaviour
	{
		[Tooltip("Decimal values after the coma 0.0")]
		public int decimals = 2;

		[Tooltip("String to add before the value")]
		public string Prefix;

		[Tooltip("String to add after the value")]
		public string Suffix;

		public StringEvent toString = new StringEvent();

		public virtual void ToString(float value)
		{
			toString.Invoke(Prefix + value.ToString("F" + decimals) + Suffix);
		}

		public virtual void ToString(int value)
		{
			toString.Invoke(Prefix + value + Suffix);
		}

		public virtual void ToString(bool value)
		{
			toString.Invoke(Prefix + value + Suffix);
		}

		public virtual void ToString(string value)
		{
			toString.Invoke(Prefix + value + Suffix);
		}

		public virtual void SetPrefix(string value)
		{
			Prefix = value;
		}

		public virtual void SetSufix(string value)
		{
			Suffix = value;
		}

		public virtual void ToString(Object value)
		{
			toString.Invoke(Prefix + value.name + Suffix);
		}

		public virtual void ToString(Vector3 value)
		{
			toString.Invoke(Prefix + value.ToString() + Suffix);
		}

		public virtual void ToString(Vector2 value)
		{
			toString.Invoke(Prefix + value.ToString() + Suffix);
		}
	}
}

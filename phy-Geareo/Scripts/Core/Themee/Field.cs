using UnityEngine;

namespace Themee
{
	public abstract class Field : MonoBehaviour
	{
		public string key;

		public virtual bool clear => false;

		public abstract object GetValue();

		private void OnValidate()
		{
		}
	}
	public abstract class Field<T> : Field
	{
		public T value;

		public override object GetValue()
		{
			return null;
		}
	}
}

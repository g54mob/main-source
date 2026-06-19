using UnityEngine;

namespace TH20
{
	public abstract class DepartureMethod : MustCallDestroy
	{
		protected readonly Character _character;

		[DontSave]
		protected IDepartedCallback _departedCallback;

		public Character Character => _character;

		public IDepartedCallback DepartedCallback
		{
			set
			{
				_departedCallback = value;
			}
		}

		protected DepartureMethod(Character character, IDepartedCallback callback)
		{
			_character = character;
			DepartedCallback = callback;
		}

		public abstract void ReadyToDepart();

		public abstract bool Update();

		public abstract Vector3 Position();

		public abstract float Rotation();
	}
}

using System;
using Reactivity;

namespace FractureField.Achievements
{
	public class Achievement
	{
		public string Id { get; set; }

		public int Number { get; set; }

		public string LocalizationKey { get; set; }

		public Func<bool> ShouldRegister { get; set; }

		public Func<bool> ShouldGrant { get; set; }

		public RBool IsCompleted { get; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		private CBool CShouldRegister { get; set; }

		private CBool CShouldGrant { get; set; }

		public void Init(bool isCompleted)
		{
		}

		public void Dispose()
		{
		}

		private void OnShouldRegisterChanged()
		{
		}

		private void OnShouldGrantChanged()
		{
		}

		private void UnlockOnSteam()
		{
		}
	}
}

using System;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.World
{
	public abstract class WaitForLoadBehaviour : SerializedMonoBehaviour
	{
		private bool _hasStarted;

		protected virtual void OnEnable()
		{
			RuntimeGlobals.WakeUp += WakeUp;
		}

		private void WakeUp(object sender, EventArgs e)
		{
			if (!_hasStarted)
			{
				_hasStarted = true;
				WakeUp();
			}
		}

		public virtual void Update()
		{
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !_hasStarted)
			{
				WakeUp();
				_hasStarted = true;
			}
		}

		protected virtual void OnDisable()
		{
			RuntimeGlobals.WakeUp -= WakeUp;
		}

		public abstract void WakeUp();
	}
}

using CTS.Core;

namespace CTS
{
	public class CameraLocker : CTSBehaviour
	{
		private LockToggle _toggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
		}

		private void Start()
		{
			_toggle.Add(MonoSingleton<MainCamera>.Instance.Movements);
			_toggle.Add(MonoSingleton<MainCamera>.Instance.CameraRotation);
		}

		public void Lock()
		{
			_toggle.Lock();
		}

		public void Unlock()
		{
			_toggle.Unlock();
		}
	}
}

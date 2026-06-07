using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class DepthOfFieldConnection : Connection<bool>
	{
		protected DepthOfField _dof;

		public DepthOfFieldConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_dof = SettingsVolume.Instance.GetOrAddComponent<DepthOfField>();
				_dof.Override(_dof, 1f);
				_dof.active = false;
				_dof.mode.overrideState = true;
				_dof.mode.value = DepthOfFieldMode.Gaussian;
				_dof.gaussianStart.overrideState = true;
				_dof.gaussianStart.value = float.MaxValue;
				_dof.gaussianEnd.overrideState = true;
				_dof.gaussianEnd.value = float.MaxValue;
			}
		}

		public override bool Get()
		{
			if (_dof == null)
			{
				return true;
			}
			return !_dof.active;
		}

		public override void Set(bool enable)
		{
			if (!(_dof == null))
			{
				_dof.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}

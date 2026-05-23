using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	public class CwDemo : MonoBehaviour
	{
		[SerializeField]
		private bool upgradeInputModule = true;

		[SerializeField]
		private bool changeExposureInHDRP = true;

		[SerializeField]
		private bool changeVisualEnvironmentInHDRP = true;

		[SerializeField]
		private bool changeFogInHDRP = true;

		[SerializeField]
		private bool changeCloudsInHDRP = true;

		[SerializeField]
		private bool changeMotionBlurInHDRP = true;

		[SerializeField]
		private bool upgradeLightsInHDRP = true;

		[SerializeField]
		private bool upgradeCamerasInHDRP = true;

		public bool UpgradeInputModule
		{
			get
			{
				return upgradeInputModule;
			}
			set
			{
				upgradeInputModule = value;
			}
		}

		public bool ChangeExposureInHDRP
		{
			get
			{
				return changeExposureInHDRP;
			}
			set
			{
				changeExposureInHDRP = value;
			}
		}

		public bool ChangeVisualEnvironmentInHDRP
		{
			get
			{
				return changeVisualEnvironmentInHDRP;
			}
			set
			{
				changeVisualEnvironmentInHDRP = value;
			}
		}

		public bool ChangeFogInHDRP
		{
			get
			{
				return changeFogInHDRP;
			}
			set
			{
				changeFogInHDRP = value;
			}
		}

		public bool ChangeCloudsInHDRP
		{
			get
			{
				return changeCloudsInHDRP;
			}
			set
			{
				changeCloudsInHDRP = value;
			}
		}

		public bool ChangeMotionBlurInHDRP
		{
			get
			{
				return changeMotionBlurInHDRP;
			}
			set
			{
				changeMotionBlurInHDRP = value;
			}
		}

		public bool UpgradeLightsInHDRP
		{
			get
			{
				return upgradeLightsInHDRP;
			}
			set
			{
				upgradeLightsInHDRP = value;
			}
		}

		public bool UpgradeCamerasInHDRP
		{
			get
			{
				return upgradeCamerasInHDRP;
			}
			set
			{
				upgradeCamerasInHDRP = value;
			}
		}

		protected virtual void OnEnable()
		{
			if (upgradeInputModule)
			{
				TryUpgradeEventSystem();
			}
			if (CwHelper.IsURP)
			{
				TryApplyURP();
			}
			if (CwHelper.IsHDRP)
			{
				TryApplyHDRP();
			}
		}

		protected virtual void TryApplyURP()
		{
		}

		protected virtual void TryApplyHDRP()
		{
			if (changeExposureInHDRP || changeVisualEnvironmentInHDRP || changeFogInHDRP)
			{
				TryCreateVolume();
			}
			if (upgradeLightsInHDRP)
			{
				TryUpgradeLights();
			}
			if (upgradeCamerasInHDRP)
			{
				TryUpgradeCameras();
			}
		}

		private void TryCreateVolume()
		{
		}

		private void TryUpgradeLights()
		{
		}

		private void TryUpgradeCameras()
		{
		}

		private void TryUpgradeEventSystem()
		{
		}
	}
}

using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[AddComponentMenu(null)]
	public class CwDemo : MonoBehaviour
	{
		[SerializeField]
		private bool upgradeInputModule;

		[SerializeField]
		private bool changeExposureInHDRP;

		[SerializeField]
		private bool changeVisualEnvironmentInHDRP;

		[SerializeField]
		private bool changeFogInHDRP;

		[SerializeField]
		private bool changeCloudsInHDRP;

		[SerializeField]
		private bool changeMotionBlurInHDRP;

		[SerializeField]
		private bool upgradeLightsInHDRP;

		[SerializeField]
		private bool upgradeCamerasInHDRP;

		public bool UpgradeInputModule
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ChangeExposureInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ChangeVisualEnvironmentInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ChangeFogInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ChangeCloudsInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ChangeMotionBlurInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UpgradeLightsInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UpgradeCamerasInHDRP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void TryApplyURP()
		{
		}

		protected virtual void TryApplyHDRP()
		{
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

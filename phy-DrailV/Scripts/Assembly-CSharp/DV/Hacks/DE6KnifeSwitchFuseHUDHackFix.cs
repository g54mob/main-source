using System.Collections;
using DV.CabControls;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.Hacks
{
	public class DE6KnifeSwitchFuseHUDHackFix : MonoBehaviour
	{
		private InteriorControlsManager manager;

		private HUDLocoControls controls;

		private void Awake()
		{
			if (VRManager.IsVREnabled())
			{
				Object.Destroy(this);
				return;
			}
			manager = GetComponent<InteriorControlsManager>();
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += OnHUDChanged;
		}

		private void OnDestroy()
		{
			if ((bool)SingletonBehaviour<HUDInterfacer>.Instance)
			{
				SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged -= OnHUDChanged;
			}
			if ((bool)controls && (bool)controls.mechanical.electricsFuse)
			{
				controls.mechanical.electricsFuse.controlModule.ValueChanged -= ControlModuleOnValueChanged;
			}
		}

		private void OnHUDChanged(HUDInterfacer.HUDChangeEvent obj)
		{
			if (manager == obj.oldManager && (bool)obj.oldControls && (bool)obj.oldControls.mechanical.electricsFuse)
			{
				obj.oldControls.mechanical.electricsFuse.controlModule.ValueChanged -= ControlModuleOnValueChanged;
			}
			if (manager == obj.newManager && (bool)obj.newControls)
			{
				controls = obj.newControls;
				if ((bool)controls.mechanical.electricsFuse)
				{
					controls.mechanical.electricsFuse.controlModule.ValueChanged += ControlModuleOnValueChanged;
				}
			}
		}

		private void ControlModuleOnValueChanged(float value)
		{
			if (!(value < 0.5f) && manager.TryGetControl(InteriorControlsManager.ControlType.ElectricsFuse, out var reference))
			{
				reference.controlImplBase.SetValue((reference.controlImplBase.Value < 0.5f) ? 1 : 0);
				reference.controlImplBase.BlockControl(setBlock: true);
				StartCoroutine(UnblockFuse(reference.controlImplBase));
			}
		}

		private IEnumerator UnblockFuse(ControlImplBase controlImplBase)
		{
			yield return WaitFor.EndOfFrame;
			controlImplBase.BlockControl(setBlock: false);
		}
	}
}

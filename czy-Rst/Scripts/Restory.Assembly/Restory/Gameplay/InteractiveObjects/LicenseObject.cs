using Restory.Data.Licenses;
using Restory.Gameplay.Licenses;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class LicenseObject : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private MeshRenderer meshRenderer;

		[SerializeField]
		private string companyIconPropertyName = "_Company_Icon";

		[SerializeField]
		private string deviceIconPropertyName = "_Device_Icon";

		private LicensePanelActivator licensePanelActivator;

		private LicenseInfo licenseInfo;

		[Inject]
		private void Constructor(LicensePanelActivator licensePanelActivator)
		{
			this.licensePanelActivator = licensePanelActivator;
			interactiveObject.IsActivatable = true;
		}

		private void OnEnable()
		{
			interactiveObject.OnInitialized += ResolveInitialized;
			interactiveObject.OnActivated += ShowLicense;
		}

		private void OnDisable()
		{
			interactiveObject.OnInitialized -= ResolveInitialized;
			interactiveObject.OnActivated -= ShowLicense;
		}

		public void Init(LicenseInfo licenseInfo)
		{
			this.licenseInfo = licenseInfo;
			if (meshRenderer.sharedMaterials.Length == 0)
			{
				return;
			}
			Material[] materials = meshRenderer.materials;
			foreach (Material material in materials)
			{
				if ((bool)material)
				{
					material.SetTexture(companyIconPropertyName, licenseInfo.Icon.texture);
					material.SetTexture(deviceIconPropertyName, licenseInfo.DeviceInfo.Icon.texture);
				}
			}
		}

		private void ResolveInitialized()
		{
			if (!interactiveObject.HasChanged)
			{
				interactiveObject.HasChanged = true;
				ShowLicense();
			}
		}

		private void ShowLicense()
		{
			if (!licenseInfo)
			{
				Debug.LogError("Failed to activate not initialized license object " + base.gameObject.name);
			}
			else
			{
				licensePanelActivator.ShowLicensePanel(licenseInfo);
			}
		}
	}
}

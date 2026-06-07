using DV.Utils;
using PI.NGSS;
using UnityEngine;
using UnityEngine.Rendering;

public class NGSS_ProviderDV : MonoBehaviour, NGSS_IExternalEnvironmentProvider
{
	private void Awake()
	{
		StereoPostProcUtility.InitializeAssets();
		if ((bool)NGSS_FrustumShadows.instance)
		{
			NGSS_FrustumShadows.instance.SetProvider(this);
			SingletonBehaviour<GraphicsOptions>.Instance.UpdateShadows();
		}
		else
		{
			NGSS_FrustumShadows.InstanceCreated += OnInstanceCreated;
		}
	}

	public void RenderFullscreenEffect(CommandBuffer buffer, Camera camera, Material material, Light light, int shaderPass)
	{
		StereoPostProcUtility.RenderFullscreenEffect(buffer, camera, material, light, shaderPass);
	}

	public bool IsVREnabled()
	{
		return VRManager.IsVREnabled();
	}

	private void OnInstanceCreated(NGSS_FrustumShadows newInstance)
	{
		NGSS_FrustumShadows.InstanceCreated -= OnInstanceCreated;
		newInstance.SetProvider(this);
		SingletonBehaviour<GraphicsOptions>.Instance.UpdateShadows();
	}
}

using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SetPointLightCookie : MonoBehaviour
{
	[SerializeField]
	private float intensityRange = 0.1f;

	[SerializeField]
	private float angleRange = 15f;

	public void Setup(string cookieId)
	{
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PointLight\\SetPointLightCookie.cs");
		if (isEnabled)
		{
			messageBuilder.AppendFormatted(cookieId);
			messageBuilder.AppendLiteral(" cookie load");
		}
		Log.Debug(messageBuilder);
		AsyncOperationHandle<RenderTexture> asyncOperationHandle = MonoSingleton<AddressableLoadingManager>.Instance.LoadAddressableAsync<RenderTexture>(cookieId);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle<RenderTexture> operation)
		{
			if (operation.Status == AsyncOperationStatus.Succeeded && operation.Result != null)
			{
				ApplyCookie(operation.Result);
			}
			else
			{
				bool isEnabled2;
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(10, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\PointLight\\SetPointLightCookie.cs");
				if (isEnabled2)
				{
					messageBuilder2.AppendLiteral("No cookie ");
					messageBuilder2.AppendFormatted(cookieId);
				}
				Log.Error(messageBuilder2);
			}
		};
	}

	private void ApplyCookie(RenderTexture cookie)
	{
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PointLight\\SetPointLightCookie.cs");
		if (isEnabled)
		{
			messageBuilder.AppendFormatted(cookie.name);
			messageBuilder.AppendLiteral(" loaded");
		}
		Log.Debug(messageBuilder);
		Light component = GetComponent<Light>();
		component.cookie = cookie;
		float intensity = Random.Range(component.intensity - intensityRange, component.intensity + intensityRange);
		component.intensity = intensity;
		float yAngle = Random.Range(0f - angleRange, angleRange);
		base.transform.Rotate(0f, yAngle, 0f);
	}
}

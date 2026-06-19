using UnityEngine;

public class GUIManagerBase : MonoBehaviour
{
	public static int aspectX = 16;

	public static int aspectY = 9;

	public static float imagePPU = 100f;

	public static float baseGUIScale = 1f;

	private static Vector2 defaultAssetResolution = new Vector2(2048f, 2048f);

	private static Vector2 defaultUIAspectResolution = new Vector2(16f, 9f);

	private static Vector2 defaultTargetScreenResolution = new Vector2(16f, 9f);

	public static Vector2 UIAspectResolution = new Vector2(16f, 9f);

	public static Vector2 targetScreenResolution = new Vector2(16f, 9f);

	protected Camera UI_Cam;

	private void Awake()
	{
		Initialize();
	}

	private void Update()
	{
		UpdateFunctionality();
	}

	public virtual void OnSceneTransitionFinished()
	{
	}

	protected virtual void Initialize()
	{
		UI_Cam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA, nullAllowed: true);
		UpdateOrthoSize();
	}

	protected virtual void UpdateFunctionality()
	{
	}

	private void UpdateOrthoSize()
	{
		if (!(UI_Cam == null))
		{
			float num = defaultUIAspectResolution.x / defaultUIAspectResolution.y;
			UIAspectResolution = new Vector2(defaultAssetResolution.x / num, defaultAssetResolution.y / num);
			float num2 = defaultTargetScreenResolution.x / defaultTargetScreenResolution.y;
			targetScreenResolution = new Vector2(defaultAssetResolution.x / num2, defaultAssetResolution.y / num2);
			UI_Cam.orthographicSize = targetScreenResolution.y / (imagePPU / baseGUIScale) / 2f;
		}
	}

	public static Vector2 GetAbsoluteScreenSize()
	{
		return new Vector2(Screen.width, Screen.height);
	}

	public static Vector2 GetAspectFromXY(float x, float y)
	{
		Camera globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		float num = x / y;
		float num2 = globalComponent.orthographicSize * 2f;
		return new Vector2(num * num2, num2);
	}

	public static Vector2 GetAspectSize()
	{
		Vector2 absoluteScreenSize = GetAbsoluteScreenSize();
		return GetAspectFromXY(absoluteScreenSize.x, absoluteScreenSize.y);
	}

	public static Vector2 GetIdealAspectSize()
	{
		return GetAspectFromXY(aspectX, aspectY);
	}

	public static Vector2 GetResolutionClampedAspectSize()
	{
		Vector2 aspectSize = GetAspectSize();
		Vector2 idealAspectSize = GetIdealAspectSize();
		if (Mathf.Approximately(aspectSize.x / aspectSize.y, idealAspectSize.x / idealAspectSize.y))
		{
			return aspectSize;
		}
		Vector2 result = new Vector2(aspectSize.x, aspectSize.x / (idealAspectSize.x / idealAspectSize.y));
		if (result.y <= aspectSize.y)
		{
			return result;
		}
		return new Vector2(aspectSize.y * (idealAspectSize.x / idealAspectSize.y), aspectSize.y);
	}
}

using System.Collections;
using DV.Localization;
using UnityEngine;
using Valve.VR;

public class VrLoading : MonoBehaviour
{
	public float progress;

	public Texture loadingScreen;

	public Texture progressBarEmpty;

	public Texture progressBarFull;

	public float loadingScreenWidthInMeters = 6f;

	public float progressBarWidthInMeters = 3f;

	public float loadingScreenDistance;

	public float progressBarDistance;

	public Texture front;

	public Texture back;

	public Texture left;

	public Texture right;

	public Texture top;

	public Texture bottom;

	public Color backgroundColor = Color.black;

	public float fadeOutTime = 0.5f;

	public float fadeInTime = 0.5f;

	public float postLoadSettleTime;

	public float loadingScreenFadeInTime = 1f;

	public float loadingScreenFadeOutTime = 0.25f;

	private bool isLoading;

	private float fadeRate = 1f;

	private float alpha;

	private RenderTexture renderTexture;

	private ulong loadingScreenOverlayHandle;

	private ulong progressBarOverlayHandle;

	private void OnEnable()
	{
		if (!isLoading)
		{
			StartCoroutine(LoadLevel());
		}
	}

	private void OnGUI()
	{
		if (!isLoading)
		{
			return;
		}
		if (progressBarEmpty != null && progressBarFull != null)
		{
			if (progressBarOverlayHandle == 0L)
			{
				SteamVR_Utils.RigidTransform rigidTransform = SteamVR_Controller.Input(0).transform;
				rigidTransform.rot = Quaternion.Euler(0f, rigidTransform.rot.eulerAngles.y, 0f);
				rigidTransform.pos += rigidTransform.rot * new Vector3(0f, 0f, progressBarDistance);
				base.transform.SetPositionAndRotation(rigidTransform.pos, rigidTransform.rot);
				progressBarOverlayHandle = GetOverlayHandle("progressBar", base.transform, progressBarWidthInMeters);
			}
			if (progressBarOverlayHandle != 0L)
			{
				int num = (int)((float)progressBarFull.width * 1.4f);
				int height = progressBarFull.height;
				if (renderTexture == null)
				{
					renderTexture = new RenderTexture(num, height, 0);
					renderTexture.Create();
				}
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = renderTexture;
				if (Event.current.type == EventType.Repaint)
				{
					GL.Clear(clearDepth: false, clearColor: true, Color.clear);
				}
				GUILayout.BeginArea(new Rect(0f, 0f, num, height));
				GUI.DrawTexture(new Rect(0f, 0f, num, height), progressBarEmpty);
				GUI.TextArea(new Rect(0f, 0f, num, (float)height * 0.6f), LocalizationAPI.L("loading/please_wait_no_perc"), new GUIStyle
				{
					alignment = TextAnchor.LowerLeft,
					fontSize = 68,
					normal = new GUIStyleState
					{
						textColor = Color.white
					}
				});
				GUI.DrawTextureWithTexCoords(new Rect(0f, 0f, progress * (float)num, height), progressBarFull, new Rect(0f, 0f, progress, 1f));
				GUILayout.EndArea();
				RenderTexture.active = active;
				CVROverlay overlay = OpenVR.Overlay;
				if (overlay != null)
				{
					Texture_t pTexture = new Texture_t
					{
						handle = renderTexture.GetNativeTexturePtr(),
						eType = SteamVR.instance.textureType,
						eColorSpace = EColorSpace.Auto
					};
					overlay.SetOverlayTexture(progressBarOverlayHandle, ref pTexture);
				}
			}
		}
		if (renderTexture != null)
		{
			int num2 = Screen.width / 2 - renderTexture.width / 2;
			float y = (float)Screen.height * 0.9f - (float)renderTexture.height;
			GUI.DrawTexture(new Rect(num2, y, renderTexture.width, renderTexture.height), renderTexture);
		}
	}

	private void Update()
	{
		if (!isLoading)
		{
			return;
		}
		alpha = Mathf.Clamp01(alpha + fadeRate * Time.unscaledDeltaTime);
		CVROverlay overlay = OpenVR.Overlay;
		if (overlay != null)
		{
			if (loadingScreenOverlayHandle != 0L)
			{
				overlay.SetOverlayAlpha(loadingScreenOverlayHandle, alpha);
			}
			if (progressBarOverlayHandle != 0L)
			{
				overlay.SetOverlayAlpha(progressBarOverlayHandle, alpha);
			}
		}
	}

	private IEnumerator LoadLevel()
	{
		yield return null;
		if (loadingScreen != null && loadingScreenDistance > 0f)
		{
			SteamVR_Controller.Device hmd = SteamVR_Controller.Input(0);
			while (!hmd.hasTracking)
			{
				yield return null;
			}
			SteamVR_Utils.RigidTransform rigidTransform = hmd.transform;
			rigidTransform.rot = Quaternion.Euler(0f, rigidTransform.rot.eulerAngles.y, 0f);
			rigidTransform.pos += rigidTransform.rot * new Vector3(0f, 0f, loadingScreenDistance);
			base.transform.position = rigidTransform.pos;
			base.transform.rotation = rigidTransform.rot;
		}
		isLoading = true;
		SteamVR_Events.Loading.Send(arg0: true);
		fadeRate = 1f / loadingScreenFadeInTime;
		CVROverlay overlay = OpenVR.Overlay;
		if (loadingScreen != null && overlay != null)
		{
			loadingScreenOverlayHandle = GetOverlayHandle("loadingScreen", base.transform, loadingScreenWidthInMeters);
			if (loadingScreenOverlayHandle != 0L)
			{
				Texture_t pTexture = new Texture_t
				{
					handle = loadingScreen.GetNativeTexturePtr(),
					eType = SteamVR.instance.textureType,
					eColorSpace = EColorSpace.Auto
				};
				overlay.SetOverlayTexture(loadingScreenOverlayHandle, ref pTexture);
			}
		}
		bool fadedForeground = false;
		SteamVR_Events.LoadingFadeOut.Send(fadeOutTime);
		CVRCompositor compositor = OpenVR.Compositor;
		if (compositor != null)
		{
			if (front != null)
			{
				SteamVR_Skybox.SetOverride(front, back, left, right, top, bottom);
				compositor.FadeGrid(fadeOutTime, bFadeIn: true);
				yield return WaitFor.SecondsRealtime(fadeOutTime);
			}
			else if (backgroundColor != Color.clear)
			{
				compositor.FadeToColor(fadeOutTime, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a, bBackground: false);
				yield return WaitFor.SecondsRealtime(fadeOutTime + 0.1f);
				compositor.FadeGrid(0f, bFadeIn: true);
				fadedForeground = true;
			}
		}
		SteamVR_Render.pauseRendering = true;
		while (alpha < 1f)
		{
			yield return null;
		}
		while (progress < 1f)
		{
			yield return WaitFor.SecondsRealtime(0.1f);
		}
		yield return null;
		yield return WaitFor.SecondsRealtime(postLoadSettleTime);
		SteamVR_Render.pauseRendering = false;
		fadeRate = -1f / loadingScreenFadeOutTime;
		SteamVR_Events.LoadingFadeIn.Send(fadeInTime);
		compositor = OpenVR.Compositor;
		if (compositor != null)
		{
			if (fadedForeground)
			{
				compositor.FadeGrid(0f, bFadeIn: false);
				compositor.FadeToColor(fadeInTime, 0f, 0f, 0f, 0f, bBackground: false);
				yield return WaitFor.SecondsRealtime(fadeInTime);
			}
			else
			{
				compositor.FadeGrid(fadeInTime, bFadeIn: false);
				yield return WaitFor.SecondsRealtime(fadeInTime);
				if (front != null)
				{
					SteamVR_Skybox.ClearOverride();
				}
			}
		}
		while (alpha > 0f)
		{
			yield return null;
		}
		if (overlay != null)
		{
			if (progressBarOverlayHandle != 0L)
			{
				overlay.HideOverlay(progressBarOverlayHandle);
			}
			if (loadingScreenOverlayHandle != 0L)
			{
				overlay.HideOverlay(loadingScreenOverlayHandle);
			}
		}
		isLoading = false;
		SteamVR_Events.Loading.Send(arg0: false);
		Object.Destroy(base.gameObject);
	}

	private ulong GetOverlayHandle(string overlayName, Transform transform, float widthInMeters = 1f)
	{
		ulong pOverlayHandle = 0uL;
		CVROverlay overlay = OpenVR.Overlay;
		if (overlay == null)
		{
			return pOverlayHandle;
		}
		string pchOverlayKey = SteamVR_Overlay.key + "." + overlayName;
		EVROverlayError eVROverlayError = overlay.FindOverlay(pchOverlayKey, ref pOverlayHandle);
		if (eVROverlayError != EVROverlayError.None)
		{
			eVROverlayError = overlay.CreateOverlay(pchOverlayKey, overlayName, ref pOverlayHandle);
		}
		if (eVROverlayError == EVROverlayError.None)
		{
			overlay.ShowOverlay(pOverlayHandle);
			overlay.SetOverlayAlpha(pOverlayHandle, alpha);
			overlay.SetOverlayWidthInMeters(pOverlayHandle, widthInMeters);
			if (SteamVR.instance.textureType == ETextureType.DirectX)
			{
				VRTextureBounds_t pOverlayTextureBounds = new VRTextureBounds_t
				{
					uMin = 0f,
					vMin = 1f,
					uMax = 1f,
					vMax = 0f
				};
				overlay.SetOverlayTextureBounds(pOverlayHandle, ref pOverlayTextureBounds);
			}
			SteamVR_Camera steamVR_Camera = ((loadingScreenDistance == 0f) ? SteamVR_Render.Top() : null);
			if (steamVR_Camera != null && steamVR_Camera.origin != null)
			{
				SteamVR_Utils.RigidTransform rigidTransform = new SteamVR_Utils.RigidTransform(steamVR_Camera.origin, transform);
				rigidTransform.pos.x /= steamVR_Camera.origin.localScale.x;
				rigidTransform.pos.y /= steamVR_Camera.origin.localScale.y;
				rigidTransform.pos.z /= steamVR_Camera.origin.localScale.z;
				HmdMatrix34_t pmatTrackingOriginToOverlayTransform = rigidTransform.ToHmdMatrix34();
				overlay.SetOverlayTransformAbsolute(pOverlayHandle, SteamVR_Render.instance.trackingSpace, ref pmatTrackingOriginToOverlayTransform);
			}
			else
			{
				HmdMatrix34_t pmatTrackingOriginToOverlayTransform2 = new SteamVR_Utils.RigidTransform(transform).ToHmdMatrix34();
				overlay.SetOverlayTransformAbsolute(pOverlayHandle, SteamVR_Render.instance.trackingSpace, ref pmatTrackingOriginToOverlayTransform2);
			}
		}
		return pOverlayHandle;
	}
}

using UnityEngine;

public class Monitor : MonoBehaviour
{
	public bool blurAtEdges;

	public Material monitorMaterial;

	public GaussianBlur gaussianBlur;

	public Texture2D borderTexture;

	[HideInInspector]
	public OneBit oneBit;

	private RenderTarget finalTarget;

	private int borderTextureW;

	private int borderTextureH;

	private const int kPassMonitorSoft = 0;

	private const int kPassMonitorExact = 1;

	private const int kPassMonitorBorder = 2;

	private static int wantBlackoutUntilFrame;

	public static bool blackingOut
	{
		get
		{
			return wantBlackoutUntilFrame > Time.frameCount;
		}
	}

	public static void BlackOut(int numFrames)
	{
		int b = Time.frameCount + numFrames;
		wantBlackoutUntilFrame = Mathf.Max(wantBlackoutUntilFrame, b);
	}

	private void OnPreRender()
	{
		monitorMaterial.SetVector("_BlackColor", Settings.colorBlack);
		monitorMaterial.SetVector("_WhiteColor", Settings.colorWhite);
		oneBit.RenderForMonitor(finalTarget);
		if (blackingOut)
		{
			Util.ClearRenderTexture(finalTarget, Color.black);
		}
	}

	private void OnEnable()
	{
		if (oneBit == null)
		{
			oneBit = GetComponent<OneBit>();
			finalTarget = new RenderTarget(new RenderTarget.Spec(Resolution.screenW, Resolution.screenH).InitWantDepth());
			monitorMaterial = new Material(monitorMaterial);
		}
		if (finalTarget != null)
		{
			finalTarget.Alloc();
		}
	}

	private void OnDisable()
	{
		if (finalTarget != null)
		{
			finalTarget.Free();
		}
	}

	private void Update()
	{
		Settings.OutputMode outputMode = Settings.outputMode;
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Settings.outputMode = (Settings.OutputMode)Mathf.Max(0, (int)(Settings.outputMode - 1));
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Settings.outputMode = (Settings.OutputMode)Mathf.Min((int)Settings.CalcOutputModeMax(), (int)(Settings.outputMode + 1));
		}
		if (outputMode != Settings.outputMode)
		{
			ScreenHelper.ApplyScreenResolution();
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (oneBit.debugging)
		{
			RenderTarget.Blit((RenderTexture)finalTarget, destination);
		}
		else
		{
			Util.ClearRenderTexture(destination, Settings.colorBlack);
			float scale = CalcViewportScale(finalTarget.rt.width, finalTarget.rt.height);
			Vector2 vector = CalcViewportScale2(scale, finalTarget.rt.width, finalTarget.rt.height);
			monitorMaterial.SetVector("_MonitorViewportScale", vector);
			monitorMaterial.SetFloat("_EdgeBlurStep", (!blurAtEdges) ? 0f : 1.5f);
			if (Settings.outputModeIsAnalog)
			{
				if (blurAtEdges)
				{
					using (RenderTargetPool.Temp temp = gaussianBlur.BlurToTemp(finalTarget, 1f, 1f * (float)finalTarget.rt.width / 1600f))
					{
						monitorMaterial.SetTexture("_BlurMainTex", (RenderTexture)temp);
						RenderTarget.BlitBilinear(finalTarget, destination, monitorMaterial, 0);
					}
				}
				else
				{
					monitorMaterial.SetTexture("_BlurMainTex", (RenderTexture)finalTarget);
					RenderTarget.BlitBilinear(finalTarget, destination, monitorMaterial, 0);
				}
			}
			else
			{
				RenderTarget.Blit((RenderTexture)finalTarget, destination, monitorMaterial, 1);
				if (borderTexture != null)
				{
					Vector2 vector2 = CalcViewportScale2(scale, borderTexture.width, borderTexture.height);
					if (vector2.x < 0.9f || vector2.y < 0.9f)
					{
						monitorMaterial.SetVector("_MonitorViewportScale", vector2);
						RenderTarget.Blit(borderTexture, destination, monitorMaterial, 2);
					}
				}
			}
		}
		if (DebugDrawer.needsRender)
		{
			DebugDrawer.Render(oneBit.sourceCamera, destination);
		}
		Framerate.Draw(destination);
	}

	private float CalcViewportScale(int sourceW, int sourceH)
	{
		float num = 1f;
		Vector2 vector = new Vector2(sourceW, sourceH);
		Vector2 vector2 = new Vector2(Resolution.screenW, Resolution.screenH);
		float num2 = vector2.x / vector2.y;
		float num3 = vector.x / vector.y;
		int index = ((num2 > num3) ? 1 : 0);
		if (Settings.outputModeIsFramed)
		{
			num = 20f;
			while (num > 1f && num * vector[index] > vector2[index])
			{
				num -= 1f;
			}
			int num4 = (int)(Settings.outputMode - 1);
			return Mathf.Max(1f, num - (float)num4);
		}
		return vector2[index] / vector[index];
	}

	private Vector2 CalcViewportScale2(float scale, int sourceW, int sourceH)
	{
		Vector2 vector = new Vector2(sourceW, sourceH);
		Vector2 vector2 = new Vector2(Resolution.screenW, Resolution.screenH);
		return new Vector2(scale * vector.x / vector2.x, scale * vector.y / vector2.y);
	}
}

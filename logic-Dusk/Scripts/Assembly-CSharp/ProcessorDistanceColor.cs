using UnityEngine;

public class ProcessorDistanceColor : IProcessor
{
	public Color lowerColor = Color.blue;

	public Color upperColor = Color.red;

	public float lowerColorBounds = 0.41f;

	public float upperColorBounds = 0.9f;

	public float colorBandSize = 0.2f;

	public float clampLight = 0.45f;

	private Color modLowerColor = Color.blue;

	private Color modUpperColor = Color.red;

	private float modLowerColorBounds = 0.41f;

	private float modUpperColorBounds = 0.9f;

	private float modColorBandSize = 0.2f;

	private float modClampLight = 0.45f;

	private CameraDistanceColorization shader;

	public string dvpName { get; private set; }

	private ProcessorDistanceColor()
	{
	}

	public ProcessorDistanceColor(CameraDistanceColorization shader)
		: this(shader, string.Empty)
	{
	}

	public ProcessorDistanceColor(CameraDistanceColorization shader, string dvpName)
	{
		this.shader = shader;
		this.dvpName = dvpName;
		if (dvpName != string.Empty)
		{
			shader.LowerColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderColorization", "lowerColor", shader.LowerColor);
			shader.UpperColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderColorization", "upperColor", shader.UpperColor);
			shader.LowerColorBounds = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "lowerColorBounds", shader.LowerColorBounds);
			shader.UpperColorBounds = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "upperColorBounds", shader.UpperColorBounds);
			shader.ColorBandSize = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "colorBandSize", shader.ColorBandSize);
			shader.ClampLight = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "clampLight", shader.ClampLight);
		}
		lowerColor = shader.LowerColor;
		modLowerColor = shader.LowerColor;
		upperColor = shader.UpperColor;
		modUpperColor = shader.UpperColor;
		lowerColorBounds = shader.LowerColorBounds;
		modLowerColorBounds = shader.LowerColorBounds;
		upperColorBounds = shader.UpperColorBounds;
		modUpperColorBounds = shader.UpperColorBounds;
		colorBandSize = shader.ColorBandSize;
		modColorBandSize = shader.ColorBandSize;
		clampLight = shader.ClampLight;
		modClampLight = shader.ClampLight;
	}

	public void BringOnline()
	{
		if (dvpName != string.Empty)
		{
			shader.LowerColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderColorization", "lowerColor", shader.LowerColor);
			shader.UpperColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderColorization", "upperColor", shader.UpperColor);
			shader.LowerColorBounds = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "lowerColorBounds", shader.LowerColorBounds);
			shader.UpperColorBounds = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "upperColorBounds", shader.UpperColorBounds);
			shader.ColorBandSize = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "colorBandSize", shader.ColorBandSize);
			shader.ClampLight = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderColorization", "clampLight", shader.ClampLight);
		}
		else
		{
			shader.LowerColor = lowerColor;
			shader.UpperColor = upperColor;
			shader.LowerColorBounds = lowerColorBounds;
			shader.UpperColorBounds = upperColorBounds;
			shader.ColorBandSize = colorBandSize;
			shader.ClampLight = clampLight;
		}
	}

	public void Update()
	{
		if (modLowerColor != lowerColor)
		{
			lowerColor = modLowerColor;
			shader.LowerColor = modLowerColor;
		}
		else
		{
			modLowerColor = shader.LowerColor;
			lowerColor = shader.LowerColor;
		}
		if (modUpperColor != upperColor)
		{
			upperColor = modUpperColor;
			shader.UpperColor = modUpperColor;
		}
		else
		{
			modUpperColor = shader.UpperColor;
			upperColor = shader.UpperColor;
		}
		if (modLowerColorBounds != lowerColorBounds)
		{
			lowerColorBounds = modLowerColorBounds;
			shader.LowerColorBounds = modLowerColorBounds;
		}
		else
		{
			modLowerColorBounds = shader.LowerColorBounds;
			lowerColorBounds = shader.LowerColorBounds;
		}
		if (modUpperColorBounds != upperColorBounds)
		{
			upperColorBounds = modUpperColorBounds;
			shader.UpperColorBounds = modUpperColorBounds;
		}
		else
		{
			modUpperColorBounds = shader.UpperColorBounds;
			upperColorBounds = shader.UpperColorBounds;
		}
		if (modColorBandSize != colorBandSize)
		{
			colorBandSize = modColorBandSize;
			shader.ColorBandSize = modColorBandSize;
		}
		else
		{
			colorBandSize = shader.ColorBandSize;
			modColorBandSize = shader.ColorBandSize;
		}
		if (modClampLight != clampLight)
		{
			clampLight = modClampLight;
			shader.ClampLight = modClampLight;
		}
		else
		{
			clampLight = shader.ClampLight;
			modClampLight = shader.ClampLight;
		}
	}

	public void DebugDraw(ref Rect rect)
	{
	}
}

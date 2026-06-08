using UnityEngine;

public class ProcessorMultiShader : IProcessor
{
	public Color flatAreaColor = Color.blue;

	public Color raisedAreaColor = Color.red;

	public float scaleOfFlat = 0.41f;

	public float scaleOfRaised = 0.9f;

	public float brightnessOfFlat = 0.2f;

	public float brightnessOfRaised = 0.45f;

	public bool enableColorBanding = true;

	public float firstColorBandStart;

	public float secondColorBandStart;

	public float firstColorBandDelta;

	public float secondColorBandDelta;

	public float staleDataDimFactor;

	private Color modFlatAreaColor = Color.blue;

	private Color modRaisedAreaColor = Color.red;

	private float modScaleOfFlat = 0.41f;

	private float modScaleOfRaised = 0.9f;

	private float modBrightnessOfFlat = 0.2f;

	private float modBrightnessOfRaised = 0.45f;

	public bool modEnableColorBanding = true;

	public float modFirstColorBandStart;

	public float modSecondColorBandStart;

	public float modFirstColorBandDelta;

	public float modSecondColorBandDelta;

	public float modStaleDataDimFactor;

	private CameraReplacementTest shader;

	public string dvpName { get; private set; }

	private ProcessorMultiShader()
	{
	}

	public ProcessorMultiShader(CameraReplacementTest shader)
		: this(shader, string.Empty)
	{
	}

	public ProcessorMultiShader(CameraReplacementTest shader, string dvpName)
	{
		this.shader = shader;
		this.dvpName = dvpName;
		if (dvpName != string.Empty)
		{
			shader.flatAreaColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderMulti", "flatAreaColor", shader.flatAreaColor);
			shader.raisedAreaColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderMulti", "raisedAreaColor", shader.raisedAreaColor);
			shader.scaleOfFlat = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "pixelScaleOfFlat", shader.scaleOfFlat);
			shader.scaleOfRaised = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "pixelScaleOfRaised", shader.scaleOfRaised);
			shader.brightnessOfFlat = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "flatBrightness", shader.brightnessOfFlat);
			shader.brightnessOfRaised = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "raisedBrightness", shader.brightnessOfRaised);
			shader.enableColorBanding = DVPConfigurationManager.GetBool(dvpName, "shaderMulti", "enableColorBanding", shader.enableColorBanding);
			shader.firstColorBandStart = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "firstColorBandStart", shader.firstColorBandStart);
			shader.secondColorBandStart = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "secondColorBandStart", shader.secondColorBandStart);
			shader.firstColorBandDelta = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "firstColorBandDelta", shader.firstColorBandDelta);
			shader.secondColorBandDelta = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "secondColorBandDelta", shader.secondColorBandDelta);
			shader.staleDataDimFactor = DVPConfigurationManager.GetNumeric(dvpName, "shaderMulti", "staleDataDimFactor", shader.staleDataDimFactor);
		}
		flatAreaColor = shader.flatAreaColor;
		modFlatAreaColor = shader.flatAreaColor;
		raisedAreaColor = shader.raisedAreaColor;
		modRaisedAreaColor = shader.raisedAreaColor;
		scaleOfFlat = shader.scaleOfFlat;
		modScaleOfFlat = shader.scaleOfFlat;
		scaleOfRaised = shader.scaleOfRaised;
		modScaleOfRaised = shader.scaleOfRaised;
		brightnessOfFlat = shader.brightnessOfFlat;
		modBrightnessOfFlat = shader.brightnessOfFlat;
		brightnessOfRaised = shader.brightnessOfRaised;
		modBrightnessOfRaised = shader.brightnessOfRaised;
		enableColorBanding = shader.enableColorBanding;
		modEnableColorBanding = shader.enableColorBanding;
		firstColorBandStart = shader.firstColorBandStart;
		modFirstColorBandStart = shader.firstColorBandStart;
		secondColorBandStart = shader.secondColorBandStart;
		modSecondColorBandStart = shader.secondColorBandStart;
		firstColorBandDelta = shader.firstColorBandDelta;
		modFirstColorBandDelta = shader.firstColorBandDelta;
		secondColorBandDelta = shader.secondColorBandDelta;
		modSecondColorBandDelta = shader.secondColorBandDelta;
		staleDataDimFactor = shader.staleDataDimFactor;
		modStaleDataDimFactor = shader.staleDataDimFactor;
	}

	public void BringOnline()
	{
		if (dvpName != string.Empty)
		{
			shader.flatAreaColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderMulti", "flatAreaColor", shader.flatAreaColor);
			shader.raisedAreaColor = DVPConfigurationManager.GetRandomColor(dvpName, "shaderMulti", "raisedAreaColor", shader.raisedAreaColor);
			shader.scaleOfFlat = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "pixelScaleOfFlat", shader.scaleOfFlat);
			shader.scaleOfRaised = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "pixelScaleOfRaised", shader.scaleOfRaised);
			shader.brightnessOfFlat = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "flatBrightness", shader.brightnessOfFlat);
			shader.brightnessOfRaised = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "raisedBrightness", shader.brightnessOfRaised);
			shader.enableColorBanding = DVPConfigurationManager.GetBool(dvpName, "shaderMulti", "enableColorBanding", shader.enableColorBanding);
			shader.firstColorBandStart = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "firstColorBandStart", shader.firstColorBandStart);
			shader.secondColorBandStart = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "secondColorBandStart", shader.secondColorBandStart);
			shader.firstColorBandDelta = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "firstColorBandDelta", shader.firstColorBandDelta);
			shader.secondColorBandDelta = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderMulti", "secondColorBandDelta", shader.secondColorBandDelta);
			shader.staleDataDimFactor = DVPConfigurationManager.GetNumeric(dvpName, "shaderMulti", "staleDataDimFactor", shader.staleDataDimFactor);
		}
		else
		{
			shader.flatAreaColor = flatAreaColor;
			shader.raisedAreaColor = raisedAreaColor;
			shader.scaleOfFlat = scaleOfFlat;
			shader.scaleOfRaised = scaleOfRaised;
			shader.brightnessOfFlat = brightnessOfFlat;
			shader.brightnessOfRaised = brightnessOfRaised;
			shader.enableColorBanding = enableColorBanding;
			shader.firstColorBandStart = firstColorBandStart;
			shader.secondColorBandStart = secondColorBandStart;
			shader.firstColorBandDelta = firstColorBandDelta;
			shader.secondColorBandDelta = secondColorBandDelta;
			shader.staleDataDimFactor = staleDataDimFactor;
		}
	}

	public void Update()
	{
		if (modFlatAreaColor != flatAreaColor)
		{
			flatAreaColor = modFlatAreaColor;
			shader.flatAreaColor = modFlatAreaColor;
		}
		else
		{
			modFlatAreaColor = shader.flatAreaColor;
			flatAreaColor = shader.flatAreaColor;
		}
		if (modRaisedAreaColor != raisedAreaColor)
		{
			raisedAreaColor = modRaisedAreaColor;
			shader.raisedAreaColor = modRaisedAreaColor;
		}
		else
		{
			modRaisedAreaColor = shader.raisedAreaColor;
			raisedAreaColor = shader.raisedAreaColor;
		}
		if (modScaleOfFlat != scaleOfFlat)
		{
			scaleOfFlat = modScaleOfFlat;
			shader.scaleOfFlat = modScaleOfFlat;
		}
		else
		{
			modScaleOfFlat = shader.scaleOfFlat;
			scaleOfFlat = shader.scaleOfFlat;
		}
		if (modScaleOfRaised != scaleOfRaised)
		{
			scaleOfRaised = modScaleOfRaised;
			shader.scaleOfRaised = modScaleOfRaised;
		}
		else
		{
			modScaleOfRaised = shader.scaleOfRaised;
			scaleOfRaised = shader.scaleOfRaised;
		}
		if (modBrightnessOfFlat != brightnessOfFlat)
		{
			brightnessOfFlat = modBrightnessOfFlat;
			shader.brightnessOfFlat = modBrightnessOfFlat;
		}
		else
		{
			brightnessOfFlat = shader.brightnessOfFlat;
			modBrightnessOfFlat = shader.brightnessOfFlat;
		}
		if (modBrightnessOfRaised != brightnessOfRaised)
		{
			brightnessOfRaised = modBrightnessOfRaised;
			shader.brightnessOfRaised = modBrightnessOfRaised;
		}
		else
		{
			brightnessOfRaised = shader.brightnessOfRaised;
			modBrightnessOfRaised = shader.brightnessOfRaised;
		}
		if (modEnableColorBanding != enableColorBanding)
		{
			enableColorBanding = modEnableColorBanding;
			shader.enableColorBanding = modEnableColorBanding;
		}
		else
		{
			enableColorBanding = shader.enableColorBanding;
			modEnableColorBanding = shader.enableColorBanding;
		}
		if (modFirstColorBandStart != firstColorBandStart)
		{
			firstColorBandStart = modFirstColorBandStart;
			shader.firstColorBandStart = modFirstColorBandStart;
		}
		else
		{
			firstColorBandStart = shader.firstColorBandStart;
			modFirstColorBandStart = shader.firstColorBandStart;
		}
		if (modSecondColorBandStart != secondColorBandStart)
		{
			secondColorBandStart = modSecondColorBandStart;
			shader.secondColorBandStart = modSecondColorBandStart;
		}
		else
		{
			secondColorBandStart = shader.secondColorBandStart;
			modSecondColorBandStart = shader.secondColorBandStart;
		}
		if (modFirstColorBandDelta != firstColorBandDelta)
		{
			firstColorBandDelta = modFirstColorBandDelta;
			shader.firstColorBandDelta = modFirstColorBandDelta;
		}
		else
		{
			firstColorBandDelta = shader.firstColorBandDelta;
			modFirstColorBandDelta = shader.firstColorBandDelta;
		}
		if (modSecondColorBandDelta != secondColorBandDelta)
		{
			secondColorBandDelta = modSecondColorBandDelta;
			shader.secondColorBandDelta = modSecondColorBandDelta;
		}
		else
		{
			secondColorBandDelta = shader.secondColorBandDelta;
			modSecondColorBandDelta = shader.secondColorBandDelta;
		}
		if (modStaleDataDimFactor != staleDataDimFactor)
		{
			staleDataDimFactor = modStaleDataDimFactor;
			shader.staleDataDimFactor = modStaleDataDimFactor;
		}
		else
		{
			staleDataDimFactor = shader.staleDataDimFactor;
			modStaleDataDimFactor = shader.staleDataDimFactor;
		}
	}

	public void DebugDraw(ref Rect rect)
	{
	}
}

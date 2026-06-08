using UnityEngine;

public class ProcessorEdgeDetection : IProcessor
{
	public float SensitivityNormals = 1f;

	public float SampleDist = 1f;

	private float modSensitivityNormals = 1f;

	private float modSampleDist = 1f;

	private float pixelUVScale;

	private float dullnessOfNonData;

	private float sensitivityDepth;

	private float edgeExp;

	private CameraEdgeDetectionAndColorEffect shader;

	public string dvpName { get; private set; }

	private ProcessorEdgeDetection()
	{
	}

	public ProcessorEdgeDetection(CameraEdgeDetectionAndColorEffect shader)
		: this(shader, string.Empty)
	{
	}

	public ProcessorEdgeDetection(CameraEdgeDetectionAndColorEffect shader, string dvpName)
	{
		this.shader = shader;
		this.dvpName = dvpName;
		if (dvpName != string.Empty)
		{
			shader.pixelUVScale = DVPConfigurationManager.GetNumeric(dvpName, "shaderEdge", "pixelUVScale", shader.pixelUVScale);
			shader.dullnessOfNonData = DVPConfigurationManager.GetNumeric(dvpName, "shaderEdge", "staleDataDimFactor", shader.dullnessOfNonData);
			shader.sensitivityDepth = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sensitivityDepth", shader.sensitivityDepth);
			shader.sensitivityNormals = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sensitivityNormals", shader.sensitivityNormals);
			shader.sampleDist = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sampleDist", shader.sampleDist);
			shader.edgeExp = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "edgeExp", shader.edgeExp);
		}
		SensitivityNormals = shader.sensitivityNormals;
		modSensitivityNormals = SensitivityNormals;
		SampleDist = shader.sampleDist;
		modSampleDist = SampleDist;
		pixelUVScale = shader.pixelUVScale;
		dullnessOfNonData = shader.dullnessOfNonData;
		sensitivityDepth = shader.sensitivityDepth;
		edgeExp = shader.edgeExp;
	}

	public void BringOnline()
	{
		if (dvpName != string.Empty)
		{
			shader.pixelUVScale = DVPConfigurationManager.GetNumeric(dvpName, "shaderEdge", "pixelUVScale", shader.pixelUVScale);
			shader.dullnessOfNonData = DVPConfigurationManager.GetNumeric(dvpName, "shaderEdge", "staleDataDimFactor", shader.dullnessOfNonData);
			shader.sensitivityDepth = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sensitivityDepth", shader.sensitivityDepth);
			shader.sensitivityNormals = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sensitivityNormals", shader.sensitivityNormals);
			shader.sampleDist = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "sampleDist", shader.sampleDist);
			shader.edgeExp = DVPConfigurationManager.GetRandomNumeric(dvpName, "shaderEdge", "edgeExp", shader.edgeExp);
		}
		else
		{
			shader.sensitivityNormals = SensitivityNormals;
			shader.sampleDist = SampleDist;
			shader.pixelUVScale = pixelUVScale;
			shader.dullnessOfNonData = dullnessOfNonData;
			shader.sensitivityDepth = sensitivityDepth;
			shader.edgeExp = edgeExp;
		}
	}

	public void Update()
	{
		if (modSensitivityNormals != SensitivityNormals)
		{
			SensitivityNormals = modSensitivityNormals;
			shader.sensitivityNormals = SensitivityNormals;
		}
		else
		{
			modSensitivityNormals = shader.sensitivityNormals;
			SensitivityNormals = shader.sensitivityNormals;
		}
		if (modSampleDist != SampleDist)
		{
			SampleDist = modSampleDist;
			shader.sampleDist = SampleDist;
		}
		else
		{
			modSampleDist = shader.sampleDist;
			SampleDist = shader.sampleDist;
		}
	}

	public void DebugDraw(ref Rect rect)
	{
	}
}

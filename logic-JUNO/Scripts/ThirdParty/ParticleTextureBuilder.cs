using System;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Texture Setup", menuName = "Normal Map Texture", order = 1)]
public class ParticleTextureBuilder : ScriptableObject
{
	[Serializable]
	public class EmissiveMapLayer
	{
		public Texture2D _texLayer;

		public float _fAlphaAddMultplier;

		public bool _bReMapValues;

		public float _fBrightnessMultiplyer;

		public AnimationCurve _amcEmissiveValueRemap;

		public float[] GetEmissiveBrightness()
		{
			Color[] pixels = _texLayer.GetPixels();
			float[] array = new float[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				array[i] = pixels[i].b;
				if (_bReMapValues)
				{
					array[i] = _amcEmissiveValueRemap.Evaluate(array[i]) * _fBrightnessMultiplyer;
				}
			}
			return array;
		}
	}

	public enum BuildAction
	{
		SUB_FRAME_SELECTION = 0,
		NORMALIZE = 1,
		TRANSPARENCY_NORMALIZE = 2,
		TRANSPARENCY_OCCLUSION_NORMALIZE = 3,
		TRANSPARENCY_EMISSIVE_NORMALIZE = 4,
		TRANSPARENCY = 5
	}

	[CleanInspectorName]
	public BuildAction _bacBuildAction;

	[Button("BuildTexture", "")]
	public bool _bBuildTextureButton;

	[CleanInspectorName]
	public ParticleTextureBuilder[] _SubBuildActions;

	[CleanInspectorName]
	public Texture2D _texRawNormalMap;

	[Range(0f, 1f)]
	public float _fReduceNormalMapNoise;

	[CleanInspectorName]
	public int iNumberOfNoiseReducePasses;

	[CleanInspectorName]
	public float _fLowNormalAngleMultiplyer;

	[CleanInspectorName]
	public Texture2D _texOcclusionMap;

	[CleanInspectorName]
	public bool _bGetOcclusionMapFromNormals;

	[CleanInspectorName]
	public float _fOcclusionIntensity;

	[CleanInspectorName]
	public AnimationCurve _amcOcclusionRemapping;

	[CleanInspectorName]
	public Texture2D _texOpacityMap;

	[CleanInspectorName]
	public float _fOpacityMultiplyer;

	[CleanInspectorName]
	public AnimationCurve _amcOpacityRemapping;

	[SerializeField]
	public EmissiveMapLayer[] _emlEmissiveMaps;

	[Button("RunBuildSubFrameList", "Calculate frames using curve")]
	public bool _bBuildSubFrameList;

	[Button("SaveSubFrameSelection", "Save new image sequence")]
	public bool _bMakeSubFrameSelection;

	[CleanInspectorName("Sub Frame Settings")]
	public bool _bSubFrameSettings;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public Texture2D _texSubFrameTargetTexture;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public AnimationCurve _amcSubFrameOverTime;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public int[] _iSubFrameSelection;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public int _iSourceRows;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public int _iSourceColumns;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public int _iSubFrameRows;

	[CleanInspectorName("", "_bSubFrameSettings")]
	public int _iSubFrameColumns;

	[FileStructureString(FileStructureStringAttribute.FileAddressOptions.FOLDER_REFFERENCE_ONLY)]
	public string _strSaveDirectory;

	public string _strFileName;

	[Button("NormalizeAndSaveTexture", "Normalize texture")]
	public bool _bNormalizeTextureButton;

	[Button("TransparencyAndNormalizeTexture", "Apply transparency and normalize")]
	public bool _bTransparencyAndNormalizeButton;

	[Button("TransparencyOcclusionAndNormalizeTexture", "Apply transparency, occlusion and normalization")]
	public bool _bTransparencyOcclusionAndNormalizationButton;

	[Button("TransparencyEmissiveAndNormalizeTexture", "Apply transparency, emissive and normalize")]
	public bool _bTransparencyEmissiveAndNormalizationButton;

	[Button("TransparencyTexture", "Apple transparency to target")]
	public bool _bApplyTransparencyButton;

	public void Update()
	{
		if (_bNormalizeTextureButton)
		{
			_bNormalizeTextureButton = false;
			NormalizeAndSaveTexture();
		}
		if (_bTransparencyAndNormalizeButton)
		{
			_bTransparencyAndNormalizeButton = false;
			TransparencyAndNormalizeTexture();
		}
		if (_bTransparencyOcclusionAndNormalizationButton)
		{
			_bTransparencyOcclusionAndNormalizationButton = false;
			TransparencyOcclusionAndNormalizeTexture();
		}
		if (_bTransparencyEmissiveAndNormalizationButton)
		{
			_bTransparencyEmissiveAndNormalizationButton = false;
			TransparencyEmissiveAndNormalizeTexture();
		}
		if (_bApplyTransparencyButton)
		{
			_bApplyTransparencyButton = false;
			TransparencyTexture();
		}
		if (_bBuildSubFrameList)
		{
			_bBuildSubFrameList = false;
			RunBuildSubFrameList();
		}
		if (_bMakeSubFrameSelection)
		{
			_bMakeSubFrameSelection = false;
			SaveSubFrameSelection();
		}
	}

	public void BuildTexture()
	{
		switch (_bacBuildAction)
		{
		case BuildAction.SUB_FRAME_SELECTION:
			SaveSubFrameSelection();
			break;
		case BuildAction.NORMALIZE:
			NormalizeAndSaveTexture();
			break;
		case BuildAction.TRANSPARENCY:
			TransparencyTexture();
			break;
		case BuildAction.TRANSPARENCY_NORMALIZE:
			TransparencyAndNormalizeTexture();
			break;
		case BuildAction.TRANSPARENCY_OCCLUSION_NORMALIZE:
			TransparencyOcclusionAndNormalizeTexture();
			break;
		case BuildAction.TRANSPARENCY_EMISSIVE_NORMALIZE:
			TransparencyEmissiveAndNormalizeTexture();
			break;
		}
		if (_SubBuildActions == null)
		{
			return;
		}
		for (int i = 0; i < _SubBuildActions.Length; i++)
		{
			if (_SubBuildActions[i] != null)
			{
				_SubBuildActions[i].BuildTexture();
			}
		}
	}

	public void NormalizeAndSaveTexture()
	{
		ReduceNoise(_texRawNormalMap, _fReduceNormalMapNoise, iNumberOfNoiseReducePasses);
		Texture2D texTexture = NormalizeTexture(_texRawNormalMap);
		SaveTexture(texTexture);
		Resources.UnloadUnusedAssets();
	}

	public void TransparencyAndNormalizeTexture()
	{
		Texture2D texNormal = ReduceNoise(_texRawNormalMap, _fReduceNormalMapNoise, iNumberOfNoiseReducePasses);
		Texture2D texTexture = ApplyEmissiveTransparency(ApplyTransparencyTexture(NormalizeTexture(texNormal), _texOpacityMap), _emlEmissiveMaps);
		SaveTexture(texTexture);
		Resources.UnloadUnusedAssets();
	}

	public void TransparencyOcclusionAndNormalizeTexture()
	{
		Texture2D texNormal = ReduceNoise(_texRawNormalMap, _fReduceNormalMapNoise, iNumberOfNoiseReducePasses);
		Texture2D texTexture = ApplyOcclusionMap(ApplyEmissiveTransparency(ApplyTransparencyTexture(NormalizeTexture(texNormal), _texOpacityMap), _emlEmissiveMaps), _texOcclusionMap);
		SaveTexture(texTexture);
		Resources.UnloadUnusedAssets();
	}

	public void TransparencyEmissiveAndNormalizeTexture()
	{
		Texture2D texNormal = ReduceNoise(_texRawNormalMap, _fReduceNormalMapNoise, iNumberOfNoiseReducePasses);
		Texture2D texTexture = ApplyEmissiveMap(ApplyEmissiveTransparency(ApplyTransparencyTexture(NormalizeTexture(texNormal), _texOpacityMap), _emlEmissiveMaps), _emlEmissiveMaps);
		SaveTexture(texTexture);
		Resources.UnloadUnusedAssets();
	}

	public void TransparencyTexture()
	{
		Texture2D texTexture = ApplyEmissiveTransparency(ApplyTransparencyTexture(_texRawNormalMap, _texOpacityMap), _emlEmissiveMaps);
		SaveTexture(texTexture);
		Resources.UnloadUnusedAssets();
	}

	public void RunBuildSubFrameList()
	{
		_iSubFrameSelection = BuildSubFrameList(_iSubFrameRows * _iSubFrameColumns, _iSourceColumns * _iSourceRows, _amcSubFrameOverTime);
	}

	public void SaveSubFrameSelection()
	{
		Texture2D texTexture = SepperateOutSubFrameSelection(_texSubFrameTargetTexture, _iSourceRows, _iSourceColumns, _iSubFrameRows, _iSubFrameColumns, new Color(0.5f, 0.5f, 0.5f, 0f), _iSubFrameSelection);
		SaveTexture(texTexture);
	}

	public Texture2D ReduceNoise(Texture2D texTargetTexture, float fNoiseReductionAmount, int iNumberOfPasses = 1)
	{
		if (iNumberOfNoiseReducePasses == 0)
		{
			return texTargetTexture;
		}
		Color[,] colPixels = ConvertPixelListTo2DArray(texTargetTexture.GetPixels(), texTargetTexture.width, texTargetTexture.height);
		return ReduceNoise(colPixels, fNoiseReductionAmount, iNumberOfPasses);
	}

	public Texture2D ReduceNoise(Color[,] colPixels, float fNoiseReductionAmount, int iNumberOfPasses = 1)
	{
		Color[,] array = new Color[colPixels.GetLength(0), colPixels.GetLength(1)];
		for (int i = 0; i < colPixels.GetLength(0); i++)
		{
			for (int j = 0; j < colPixels.GetLength(1); j++)
			{
				array[i, j] = new Color(colPixels[i, j].r, colPixels[i, j].g, colPixels[i, j].b, colPixels[i, j].a);
			}
		}
		for (int k = 0; k < colPixels.GetLength(0); k++)
		{
			for (int l = 0; l < colPixels.GetLength(1); l++)
			{
				int num = Mathf.Clamp(l - 1, 0, array.GetLength(1) - 1);
				int num2 = Mathf.Clamp(l + 1, 0, array.GetLength(1) - 1);
				int num3 = Mathf.Clamp(k - 1, 0, array.GetLength(0) - 1);
				int num4 = Mathf.Clamp(k + 1, 0, array.GetLength(0) - 1);
				Color color = array[k, num] * 0.5f + array[k, num2] * 0.5f;
				Color color2 = array[num3, l] * 0.5f + array[num4, l] * 0.5f;
				Color color3 = array[num3, num] * 0.5f + array[num4, num2] * 0.5f;
				Color color4 = array[num3, num2] * 0.5f + array[num4, num] * 0.5f;
				Color b = color * 0.25f + color2 * 0.25f + color3 * 0.25f + color4 * 0.25f;
				colPixels[k, l] = Color.Lerp(colPixels[k, l], b, fNoiseReductionAmount);
			}
		}
		iNumberOfPasses--;
		if (iNumberOfPasses > 0)
		{
			return ReduceNoise(colPixels, fNoiseReductionAmount, iNumberOfPasses);
		}
		Texture2D texture2D = new Texture2D(colPixels.GetLength(0), colPixels.GetLength(1));
		texture2D.SetPixels(Convert2DArrayToPixelList(colPixels));
		return texture2D;
	}

	public Texture2D ApplyEmissiveTransparency(Texture2D texTargetTexture, EmissiveMapLayer[] emlEmmisiveLayers)
	{
		Texture2D texture2D = texTargetTexture;
		for (int i = 0; i < emlEmmisiveLayers.Length; i++)
		{
			texture2D = ApplyEmissiveTransparency(texture2D, emlEmmisiveLayers[i]);
		}
		return texture2D;
	}

	public Texture2D ApplyEmissiveTransparency(Texture2D texTargetTexture, EmissiveMapLayer emlEmissiveMap)
	{
		Color[] pixels = texTargetTexture.GetPixels();
		float[] emissiveBrightness = emlEmissiveMap.GetEmissiveBrightness();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i].a += emissiveBrightness[i] * emlEmissiveMap._fAlphaAddMultplier;
		}
		Texture2D texture2D = new Texture2D(texTargetTexture.width, texTargetTexture.height);
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	public Texture2D ApplyOcclusionMap(Texture2D texTargetTexture, Texture2D texOcclusionMap)
	{
		Color[] pixels = texTargetTexture.GetPixels();
		Color[] pixels2 = texOcclusionMap.GetPixels();
		for (int i = 0; i < pixels.Length && i < pixels2.Length; i++)
		{
			float num = 0f;
			num = ((!_bGetOcclusionMapFromNormals) ? (1f - pixels2[i].maxColorComponent) : (1f - DecodeNormal(pixels2[i]).magnitude));
			num = _amcOcclusionRemapping.Evaluate(num) * _fOcclusionIntensity;
			Vector3 vecNormal = DecodeNormal(pixels[i]);
			vecNormal *= 1f - num;
			float a = pixels[i].a;
			pixels[i] = EncodeNormal(vecNormal);
			pixels[i].a = a;
		}
		Texture2D texture2D = new Texture2D(texTargetTexture.width, texTargetTexture.height);
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	public Texture2D NormalizeTexture(Texture2D texNormal)
	{
		Color[] pixels = texNormal.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			Vector3 vector = DecodeNormal(pixels[i]);
			float magnitude = vector.magnitude;
			float num = Mathf.Clamp01(1f - magnitude) * _fLowNormalAngleMultiplyer + 1f;
			vector = new Vector3(vector.x * num, vector.y * num, vector.z);
			vector.Normalize();
			pixels[i] = EncodeNormal(vector);
		}
		Texture2D texture2D = new Texture2D(texNormal.width, texNormal.height);
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	public Texture2D ApplyTransparencyTexture(Texture2D texTargetTexture, Texture2D texTransparency)
	{
		Color[] pixels = texTargetTexture.GetPixels();
		Color[] pixels2 = texTransparency.GetPixels();
		for (int i = 0; i < pixels.Length && i < pixels2.Length; i++)
		{
			pixels[i].a = _amcOpacityRemapping.Evaluate(pixels2[i].a) * _fOpacityMultiplyer;
			if (pixels[i].a <= 0f)
			{
				pixels[i].r = 0.5f;
				pixels[i].g = 0.5f;
				pixels[i].b = 0.5f;
			}
		}
		Texture2D texture2D = new Texture2D(texTargetTexture.width, texTargetTexture.height);
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	public Texture2D ApplyEmissiveMap(Texture2D texTargetTexture, EmissiveMapLayer[] emlEmissiveMaps)
	{
		Color[] pixels = texTargetTexture.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i].b = 0f;
		}
		for (int j = 0; j < emlEmissiveMaps.Length; j++)
		{
			float[] emissiveBrightness = emlEmissiveMaps[j].GetEmissiveBrightness();
			for (int k = 0; k < pixels.Length && k < emissiveBrightness.Length; k++)
			{
				pixels[k].b += emissiveBrightness[k];
			}
		}
		Texture2D texture2D = new Texture2D(texTargetTexture.width, texTargetTexture.height);
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	public void SaveTexture(Texture2D texTexture)
	{
		byte[] bytes = texTexture.EncodeToPNG();
		Debug.Log("Attempted save directory | " + Application.dataPath + "/" + _strSaveDirectory + "/" + _strFileName + ".png");
		File.WriteAllBytes(Application.dataPath + "/../" + _strSaveDirectory + "/" + _strFileName + ".png", bytes);
	}

	public Vector3 DecodeNormal(Color colNormal)
	{
		return new Vector3(colNormal.r, colNormal.g, colNormal.b) * 2f - Vector3.one;
	}

	public Color EncodeNormal(Vector3 vecNormal)
	{
		vecNormal += Vector3.one;
		vecNormal *= 0.5f;
		return new Color(vecNormal.x, vecNormal.y, vecNormal.z);
	}

	public Color[,] ConvertPixelListTo2DArray(Color[] colPixels, int iImagetWidth, int iImageHeight)
	{
		Color[,] array = new Color[iImagetWidth, iImageHeight];
		Debug.Log("Width " + iImagetWidth + " Height " + iImageHeight);
		for (int i = 0; i < colPixels.Length; i++)
		{
			int num = i % iImagetWidth;
			int num2 = (i - num) / iImagetWidth;
			if (num > iImagetWidth || num < 0)
			{
				Debug.Log("Width Error");
				Debug.Log("target address ( X = " + num + ", Y = " + num2 + " ) at index " + i + " of " + colPixels.Length);
			}
			if (num2 > iImageHeight - 1 || num2 < 0)
			{
				Debug.Log("Height Error");
				Debug.Log("target address ( X = " + num + ", Y = " + num2 + " ) at index " + i + " of " + colPixels.Length);
			}
			if (i > colPixels.Length)
			{
				Debug.Log("source length error");
				Debug.Log("target address ( X = " + num + ", Y = " + num2 + " ) at index " + i + " of " + colPixels.Length);
			}
			array[num, num2] = colPixels[i];
		}
		return array;
	}

	public Color[] Convert2DArrayToPixelList(Color[,] col2DPixelList)
	{
		Color[] array = new Color[col2DPixelList.Length];
		for (int i = 0; i < col2DPixelList.Length; i++)
		{
			int num = i % col2DPixelList.GetLength(0);
			int num2 = (i - num) / col2DPixelList.GetLength(0);
			array[i] = col2DPixelList[num, num2];
		}
		return array;
	}

	public Texture2D SepperateOutSubFrameSelection(Texture2D texSourceTexture, int iSourceRows, int iSourceColumns, int iDestRows, int iDestColumns, Color colDestStartColour, int[] iFrameIndexes, Func<int, Color, Color> fncPerFrameAction = null)
	{
		int num = texSourceTexture.width / iSourceColumns;
		int num2 = texSourceTexture.height / iSourceRows;
		int num3 = num * iDestColumns;
		int num4 = num2 * iDestRows;
		Color[,] array = ConvertPixelListTo2DArray(texSourceTexture.GetPixels(), texSourceTexture.width, texSourceTexture.height);
		Color[,] array2 = new Color[num3, num4];
		for (int i = 0; i < array2.GetLength(0); i++)
		{
			for (int j = 0; j < array2.GetLength(1); j++)
			{
				array2[i, j] = colDestStartColour;
			}
		}
		for (int k = 0; k < iFrameIndexes.Length; k++)
		{
			int num5 = iFrameIndexes[k] % iSourceColumns;
			int num6 = iSourceRows - ((iFrameIndexes[k] - num5) / iSourceColumns + 1);
			int num7 = k % iDestColumns;
			int num8 = iDestRows - ((k - num7) / iDestColumns + 1);
			for (int l = 0; l < num; l++)
			{
				for (int m = 0; m < num2; m++)
				{
					Color color = array[l + num5 * num, m + num6 * num2];
					if (fncPerFrameAction != null)
					{
						color = fncPerFrameAction(k, color);
					}
					array2[l + num7 * num, m + num8 * num2] = color;
				}
			}
		}
		Texture2D texture2D = new Texture2D(array2.GetLength(0), array2.GetLength(1));
		texture2D.SetPixels(Convert2DArrayToPixelList(array2));
		return texture2D;
	}

	public int[] BuildSubFrameList(int iOutputFrameCount, int iInputFrameCount, AnimationCurve amcFramesOverTime)
	{
		int[] array = new int[iOutputFrameCount];
		for (int i = 0; i < iOutputFrameCount; i++)
		{
			float time = (float)i / (float)iOutputFrameCount;
			float num = amcFramesOverTime.Evaluate(time);
			array[i] = (int)(num * (float)iInputFrameCount);
		}
		return array;
	}
}

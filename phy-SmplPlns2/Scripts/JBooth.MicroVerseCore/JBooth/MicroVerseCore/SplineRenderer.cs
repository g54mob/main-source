using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Splines;

namespace JBooth.MicroVerseCore
{
	public class SplineRenderer
	{
		public struct RenderDesc
		{
			public enum Mode
			{
				Path = 0,
				Area = 1,
				Intersection = 2,
				Road = 3
			}

			public SplineContainer splineContainer;

			public List<SplinePath.SplineWidthData> widths;

			public Easing widthEasing;

			public Noise positionNoise;

			public Noise widthNoise;

			public float widthBoost;

			public float sdfMult;

			public Mode mode;

			public int numSteps;
		}

		private ComputeBuffer curveBuffer;

		private ComputeBuffer lengthBuffer;

		private ComputeBuffer widthBuffer;

		private Vector4 info;

		private Vector4 widthInfo;

		public RenderTexture splineSDF;

		private static Shader slineRenderShader = null;

		private static Shader splineClearShader = null;

		private static int _MaxSDF = Shader.PropertyToID("_MaxSDF");

		private static int _RealSize = Shader.PropertyToID("_RealSize");

		private static int _Transform = Shader.PropertyToID("_Transform");

		private static int _Info = Shader.PropertyToID("_Info");

		private static int _WidthInfo = Shader.PropertyToID("_WidthInfo");

		private static int _Curves = Shader.PropertyToID("_Curves");

		private static int _CurveLengths = Shader.PropertyToID("_CurveLengths");

		private static int _WidthBoost = Shader.PropertyToID("_WidthBoost");

		private static int _SDFMult = Shader.PropertyToID("_SDFMult");

		private static int _NumSegments = Shader.PropertyToID("_NumSegments");

		private static int _SplineBounds = Shader.PropertyToID("_SplineBounds");

		private static int _Widths = Shader.PropertyToID("_Widths");

		public float lastMaxSDF;

		public void Render(SplineContainer sc, Terrain terrain, Noise positionNoise, Noise widthNoise, int sdfRes = 512, float maxSDF = 256f, RenderDesc.Mode mode = RenderDesc.Mode.Area, int numSteps = 128)
		{
			RenderDesc renderDesc = new RenderDesc
			{
				splineContainer = sc,
				widthBoost = 0f,
				mode = mode,
				positionNoise = positionNoise,
				widthNoise = widthNoise,
				numSteps = numSteps
			};
			Render(new RenderDesc[1] { renderDesc }, terrain, sdfRes, maxSDF, numSteps);
		}

		public void Render(SplineContainer sc, Terrain terrain, Noise positionNoise, Noise widthNoise, List<SplinePath.SplineWidthData> widths = null, Easing easing = null, int sdfRes = 512, float maxSDF = 256f, int numSteps = 128)
		{
			RenderDesc renderDesc = new RenderDesc
			{
				splineContainer = sc,
				widths = widths,
				widthEasing = easing,
				positionNoise = positionNoise,
				widthNoise = widthNoise,
				widthBoost = 0f,
				mode = RenderDesc.Mode.Path,
				numSteps = numSteps
			};
			Render(new RenderDesc[1] { renderDesc }, terrain, sdfRes, maxSDF, numSteps);
		}

		public void Render(RenderDesc[] renderDescs, Terrain terrain, int sdfRes = 512, float maxSDF = 256f, int numSteps = 128)
		{
			lastMaxSDF = maxSDF;
			int num = terrain.terrainData.alphamapResolution;
			if (sdfRes > num)
			{
				num = sdfRes;
			}
			if (num > 2048)
			{
				num = 2048;
			}
			if (splineSDF != null)
			{
				splineSDF.Release();
				Object.DestroyImmediate(splineSDF);
			}
			RenderTextureFormat format = RenderTextureFormat.ARGBFloat;
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
			{
				format = RenderTextureFormat.ARGBHalf;
			}
			splineSDF = new RenderTexture(sdfRes, sdfRes, 0, format, RenderTextureReadWrite.Linear);
			splineSDF.name = "SplineRenderer::SplineSDFFill";
			splineSDF.wrapMode = TextureWrapMode.Clamp;
			if (slineRenderShader == null)
			{
				slineRenderShader = Shader.Find("Hidden/MicroVerse/SplineSDFFill");
			}
			Material material = new Material(slineRenderShader);
			RenderTexture renderTexture = RenderTexture.GetTemporary(num, num, 0, format, RenderTextureReadWrite.Linear);
			RenderTexture renderTexture2 = RenderTexture.GetTemporary(num, num, 0, format, RenderTextureReadWrite.Linear);
			material.SetVector(_RealSize, TerrainUtil.ComputeTerrainSize(terrain));
			material.SetMatrix(_Transform, terrain.transform.localToWorldMatrix);
			Graphics.Blit(Texture2D.blackTexture, splineSDF);
			RenderTexture renderTexture3 = RenderTexture.GetTemporary(sdfRes, sdfRes, 0, format, RenderTextureReadWrite.Linear);
			RenderTexture renderTexture4 = RenderTexture.GetTemporary(sdfRes, sdfRes, 0, format, RenderTextureReadWrite.Linear);
			if (splineClearShader == null)
			{
				splineClearShader = Shader.Find("Hidden/MicroVerse/SplineClear");
			}
			Material material2 = new Material(splineClearShader);
			Graphics.Blit(null, renderTexture3, material2);
			Graphics.Blit(null, renderTexture4, material2);
			Graphics.Blit(null, renderTexture, material2);
			Graphics.Blit(null, renderTexture2, material2);
			Object.DestroyImmediate(material2);
			for (int i = 0; i < renderDescs.Length; i++)
			{
				RenderDesc renderDesc = renderDescs[i];
				int num2 = -1;
				SplineContainer splineContainer = renderDesc.splineContainer;
				List<SplinePath.SplineWidthData> widths = renderDesc.widths;
				Easing widthEasing = renderDesc.widthEasing;
				float widthBoost = renderDesc.widthBoost;
				float sdfMult = renderDesc.sdfMult;
				if (splineContainer == null)
				{
					continue;
				}
				List<string> list = new List<string>(32);
				foreach (Spline spline in splineContainer.Splines)
				{
					list.Clear();
					switch (renderDesc.mode)
					{
					case RenderDesc.Mode.Area:
						list.Add("_AREA");
						break;
					case RenderDesc.Mode.Intersection:
						list.Add("_INTERSECTION");
						break;
					case RenderDesc.Mode.Road:
						list.Add("_ROAD");
						break;
					}
					num2++;
					int count = spline.Count;
					if (count < 2)
					{
						continue;
					}
					if (curveBuffer != null)
					{
						curveBuffer.Dispose();
					}
					if (lengthBuffer != null)
					{
						lengthBuffer.Dispose();
					}
					if (widthBuffer != null)
					{
						widthBuffer.Dispose();
					}
					widthBuffer = null;
					widthInfo = Vector4.zero;
					float num3 = 0f;
					if (widths != null && num2 < widths.Count)
					{
						SplineData<float> widthData = widths[num2].widthData;
						if (widthData.Count > 0)
						{
							widthData.SortIfNecessary();
							widthData.ConvertPathUnit(spline, PathIndexUnit.Knot);
							widthBuffer = new ComputeBuffer(widthData.Count, UnsafeUtility.SizeOf<Vector2>());
							NativeArray<Vector2> data = new NativeArray<Vector2>(widthData.Count, Allocator.Temp);
							for (int j = 0; j < widthData.Count; j++)
							{
								data[j] = new Vector2(widthData[j].Index, widthData[j].Value);
								num3 = Mathf.Max(num3, widthData[j].Value);
							}
							widthBuffer.SetData(data);
							widthInfo.x = widthData.Count;
							data.Dispose();
							widthEasing?.PrepareMaterial(material, "_WIDTH", list);
							widthData.ConvertPathUnit(spline, PathIndexUnit.Normalized);
						}
					}
					if (widthBuffer == null)
					{
						widthBuffer = new ComputeBuffer(1, UnsafeUtility.SizeOf<Vector2>());
					}
					curveBuffer = new ComputeBuffer(count, UnsafeUtility.SizeOf<BezierCurve>());
					lengthBuffer = new ComputeBuffer(count, 4);
					NativeArray<BezierCurve> data2 = new NativeArray<BezierCurve>(count, Allocator.Temp);
					NativeArray<float> data3 = new NativeArray<float>(count, Allocator.Temp);
					Matrix4x4 localToWorldMatrix = splineContainer.transform.localToWorldMatrix;
					for (int k = 0; k < count; k++)
					{
						BezierCurve curve = spline.GetCurve(k);
						curve.P0 = localToWorldMatrix.MultiplyPoint(curve.P0);
						curve.P1 = localToWorldMatrix.MultiplyPoint(curve.P1);
						curve.P2 = localToWorldMatrix.MultiplyPoint(curve.P2);
						curve.P3 = localToWorldMatrix.MultiplyPoint(curve.P3);
						data2[k] = curve;
						data3[k] = spline.GetCurveLength(k);
					}
					curveBuffer.SetData(data2);
					lengthBuffer.SetData(data3);
					data2.Dispose();
					data3.Dispose();
					info = new Vector4(spline.Count, spline.Closed ? 1 : 0, spline.GetLength(), 0f);
					material.SetFloat(_MaxSDF, maxSDF + num3);
					material.SetVector(_Info, info);
					material.SetVector(_WidthInfo, widthInfo);
					material.SetBuffer(_Curves, curveBuffer);
					material.SetBuffer(_CurveLengths, lengthBuffer);
					material.SetFloat(_WidthBoost, widthBoost);
					material.SetFloat(_SDFMult, sdfMult);
					material.SetFloat(_NumSegments, numSteps);
					Bounds bounds = spline.GetBounds(localToWorldMatrix);
					material.SetVector(_SplineBounds, new Vector4(bounds.min.x, bounds.max.x, bounds.min.z, bounds.max.z));
					if (widthBuffer != null)
					{
						material.SetBuffer(_Widths, widthBuffer);
					}
					if (renderDesc.positionNoise != null && renderDesc.positionNoise.amplitude != 0f)
					{
						renderDesc.positionNoise.PrepareMaterial(material, "_POSITION", "_Position", list);
					}
					if (renderDesc.widthNoise != null && renderDesc.widthNoise.amplitude != 0f)
					{
						renderDesc.widthNoise.PrepareMaterial(material, "_WIDTH", "_Width", list);
					}
					material.shaderKeywords = list.ToArray();
					Graphics.Blit(renderTexture4, renderTexture3, material);
					RenderTexture renderTexture5 = renderTexture4;
					RenderTexture renderTexture6 = renderTexture3;
					renderTexture3 = renderTexture5;
					renderTexture4 = renderTexture6;
					list.Add("_EDGES");
					material.shaderKeywords = list.ToArray();
					material.SetTexture("_Prev", renderTexture4);
					Graphics.Blit(renderTexture2, renderTexture, material);
					RenderTexture renderTexture7 = renderTexture2;
					renderTexture6 = renderTexture;
					renderTexture = renderTexture7;
					renderTexture2 = renderTexture6;
					curveBuffer.Dispose();
					lengthBuffer.Dispose();
					widthBuffer.Dispose();
				}
			}
			Graphics.Blit(renderTexture2, splineSDF);
			Object.DestroyImmediate(material);
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture3);
			RenderTexture.ReleaseTemporary(renderTexture4);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture.ReleaseTemporary(renderTexture2);
		}

		public void Dispose()
		{
			if ((bool)splineSDF)
			{
				RenderTexture.active = null;
				splineSDF.Release();
				Object.DestroyImmediate(splineSDF);
				splineSDF = null;
			}
		}
	}
}

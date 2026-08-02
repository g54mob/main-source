using System;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	public class GPUINoGOUpdates : MonoBehaviour
	{
		[BurstCompile]
		private struct MatrixDataGeneratorJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<Matrix4x4> matrices;

			[ReadOnly]
			public float time;

			[ReadOnly]
			public int radial;

			[ReadOnly]
			public int vertical;

			[ReadOnly]
			public int circular;

			[ReadOnly]
			public Vector2 spinSpeed;

			public void Execute(int r)
			{
				Matrix4x4 matrix = Matrix4x4.identity;
				Vector3 one = Vector3.one;
				int num = r * vertical * circular;
				float num2 = (float)r * 0.001f * math.sin(spinSpeed.y * time);
				for (int i = 0; i < vertical; i++)
				{
					float num3 = 5f + (float)r * (Mathf.Pow((float)i * 0.02f, 1.6f) + 1f);
					for (int j = 0; j < circular; j++)
					{
						float num4 = (float)i * num2 + MathF.PI * 2f * (float)j / (float)circular;
						one.x = num3 * math.cos(num4 - time * spinSpeed.x);
						one.y = i;
						one.z = num3 * math.sin(num4 - time * spinSpeed.x);
						matrix.SetPosition(one);
						matrices[num] = matrix;
						num++;
					}
				}
			}
		}

		[BurstCompile]
		private struct ColorDataGeneratorJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<Color> colors;

			[ReadOnly]
			public float time;

			[ReadOnly]
			public int radial;

			[ReadOnly]
			public int vertical;

			[ReadOnly]
			public int circular;

			[ReadOnly]
			public Vector3 colorSpeeds;

			public void Execute(int r)
			{
				Color white = Color.white;
				int num = r * vertical * circular;
				white.r = ((float)(r / radial) + time * colorSpeeds.x) % 1f;
				for (float num2 = 0f; num2 < (float)vertical; num2 += 1f)
				{
					white.g = (num2 / (float)vertical + time * colorSpeeds.y) % 1f;
					for (float num3 = 0f; num3 < (float)circular; num3 += 1f)
					{
						white.b = (num3 / (float)circular - time * colorSpeeds.z) % 1f;
						colors[num] = white;
						num++;
					}
				}
			}
		}

		public GameObject prefab;

		public GPUIProfile profile;

		[Range(1f, 100f)]
		public int radial = 32;

		[Range(1f, 100f)]
		public int vertical = 32;

		[Range(1f, 100f)]
		public int circular = 32;

		public Material material;

		public bool enableColorVariations;

		public bool runUpdate;

		public Vector2 spinSpeed = Vector2.one;

		public Vector3 colorSpeeds = Vector3.one;

		public Text instanceCountText;

		private int _rendererKey;

		private NativeArray<Matrix4x4> _matrix4X4s;

		private NativeArray<Color> _colors;

		private GraphicsBuffer _colorBuffer;

		private int _instanceCount;

		private JobHandle _jobHandle;

		public void OnEnable()
		{
			Dispose();
			if (prefab == null)
			{
				return;
			}
			_instanceCount = radial * vertical * circular;
			if (_instanceCount > 0)
			{
				GPUICoreAPI.RegisterRenderer(this, prefab, profile, out _rendererKey);
				if (_rendererKey != 0)
				{
					_matrix4X4s = new NativeArray<Matrix4x4>(_instanceCount, Allocator.Persistent);
					if (enableColorVariations)
					{
						_colors = new NativeArray<Color>(_instanceCount, Allocator.Persistent);
					}
					GenerateInstanceMatrices();
					_jobHandle.Complete();
					GPUICoreAPI.SetTransformBufferData(_rendererKey, _matrix4X4s);
					if (enableColorVariations)
					{
						_colorBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, _instanceCount, Marshal.SizeOf(typeof(Color)));
						_colorBuffer.SetData(_colors);
						material.EnableKeyword("GPUI_COLOR_VARIATION");
						GPUICoreAPI.AddMaterialPropertyOverride(_rendererKey, "gpuiProFloat4Variation", _colorBuffer);
					}
					else
					{
						material.DisableKeyword("GPUI_COLOR_VARIATION");
					}
				}
			}
			if (instanceCountText != null)
			{
				instanceCountText.text = _instanceCount.FormatNumberWithSuffix();
			}
		}

		public void OnDisable()
		{
			Dispose();
		}

		private void Update()
		{
			if (_rendererKey != 0 && runUpdate && _jobHandle.IsCompleted)
			{
				_jobHandle.Complete();
				GPUICoreAPI.SetTransformBufferData(_rendererKey, _matrix4X4s);
				if (enableColorVariations)
				{
					_colorBuffer.SetData(_colors);
				}
				GenerateInstanceMatrices();
			}
		}

		public void Dispose()
		{
			_jobHandle.Complete();
			if (_rendererKey != 0)
			{
				GPUICoreAPI.DisposeRenderer(_rendererKey);
				_rendererKey = 0;
			}
			if (_matrix4X4s.IsCreated)
			{
				_matrix4X4s.Dispose();
			}
			if (_colors.IsCreated)
			{
				_colors.Dispose();
			}
			if (_colorBuffer != null)
			{
				_colorBuffer.Dispose();
			}
			_colorBuffer = null;
		}

		private void OnValidate()
		{
			if (GPUIRenderingSystem.IsActive && _rendererKey != 0)
			{
				OnEnable();
			}
		}

		private void GenerateInstanceMatrices()
		{
			_jobHandle = new MatrixDataGeneratorJob
			{
				matrices = _matrix4X4s,
				time = Time.time,
				radial = radial,
				vertical = vertical,
				circular = circular,
				spinSpeed = spinSpeed
			}.Schedule(radial, 2);
			if (enableColorVariations)
			{
				_jobHandle = new ColorDataGeneratorJob
				{
					colors = _colors,
					time = Time.time,
					radial = radial,
					vertical = vertical,
					circular = circular,
					colorSpeeds = colorSpeeds
				}.Schedule(radial, 2, _jobHandle);
			}
		}
	}
}

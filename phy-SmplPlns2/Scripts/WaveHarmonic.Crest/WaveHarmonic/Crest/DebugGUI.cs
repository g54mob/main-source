using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Debug/Crest Debug GUI")]
	internal sealed class DebugGUI : ManagedBehaviour<WaterRenderer>
	{
		private static class ShaderIDs
		{
			public static readonly int s_Depth = Shader.PropertyToID("_Depth");

			public static readonly int s_Scale = Shader.PropertyToID("_Scale");

			public static readonly int s_Bias = Shader.PropertyToID("_Bias");
		}

		[SerializeField]
		private bool _ShowWaterData = true;

		[SerializeField]
		private bool _GuiVisible = true;

		[SerializeField]
		private bool _DrawLodDatasActualSize;

		[RangeAttribute(0f, 1f)]
		[SerializeField]
		private float _PausedScroll;

		[Header("Simulations")]
		[SerializeField]
		private bool _DrawAnimatedWaves = true;

		[SerializeField]
		private bool _DrawDynamicWaves;

		[SerializeField]
		private bool _DrawFoam;

		[SerializeField]
		private bool _DrawFlow;

		[SerializeField]
		private bool _DrawShadow;

		[SerializeField]
		private bool _DrawDepth;

		[SerializeField]
		private bool _DrawClip;

		private const float k_ScrollBarWidth = 20f;

		private float _Scroll;

		private static readonly float s_LeftPanelWidth = 180f;

		private static readonly float s_BottomPanelHeight = 25f;

		private static readonly Color s_GuiColor = Color.black * 0.7f;

		private WaterRenderer _Water;

		private static readonly Dictionary<Type, string> s_SimulationNames = new Dictionary<Type, string>();

		private static Material s_DebugArrayMaterial;

		private static DebugGUI s_Instance;

		private Vector3 _ViewerPositionLastFrame;

		private Vector3 _ViewerVelocity;

		private static Material DebugArrayMaterial
		{
			get
			{
				if (s_DebugArrayMaterial == null)
				{
					s_DebugArrayMaterial = new Material(ScriptableSingleton<WaterResources>.Instance.Shaders._DebugTextureArray);
				}
				return s_DebugArrayMaterial;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		public static bool OverGUI(Vector2 screenPosition)
		{
			if (s_Instance == null)
			{
				return false;
			}
			if (s_Instance._GuiVisible && screenPosition.x < s_LeftPanelWidth)
			{
				return true;
			}
			if (s_Instance._ShowWaterData && screenPosition.y < s_BottomPanelHeight)
			{
				return true;
			}
			if (s_Instance._ShowWaterData && screenPosition.x > (float)Screen.width - 20f)
			{
				return true;
			}
			return false;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			s_Instance = this;
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			s_Instance = null;
		}

		private void OnDestroy()
		{
			Helpers.Destroy(s_DebugArrayMaterial);
			s_DebugArrayMaterial = null;
		}

		private void OnUpdate(WaterRenderer water)
		{
			_Water = water;
			if (_Water.Viewpoint != null)
			{
				_ViewerVelocity = (_Water.Viewpoint.position - _ViewerPositionLastFrame) / Time.deltaTime;
				_ViewerPositionLastFrame = ((_Water != null) ? _Water.Viewpoint.position : Vector3.zero);
			}
			if (Application.isFocused)
			{
				if (Keyboard.current.gKey.wasPressedThisFrame)
				{
					ToggleGUI();
				}
				if (Keyboard.current.fKey.wasPressedThisFrame)
				{
					Time.timeScale = ((Time.timeScale == 0f) ? 1f : 0f);
				}
				if (Keyboard.current.rKey.wasPressedThisFrame)
				{
					SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
				}
			}
		}

		private void OnGUI()
		{
			_Water = ManagerBehaviour<WaterRenderer>.Instance;
			Color color = GUI.color;
			if (_GuiVisible)
			{
				GUI.skin.toggle.normal.textColor = Color.white;
				GUI.skin.label.normal.textColor = Color.white;
				float num = 5f;
				float num2 = 0f;
				float num3 = s_LeftPanelWidth - 2f * num;
				float num4 = 25f;
				GUI.color = s_GuiColor;
				GUI.DrawTexture(new Rect(0f, 0f, num3 + 2f * num, Screen.height), Texture2D.whiteTexture);
				GUI.color = Color.white;
				GUI.changed = false;
				bool flag = GUI.Toggle(new Rect(num, num2, num3, num4), Time.timeScale == 0f, "Freeze time (F)");
				num2 += num4;
				if (GUI.changed)
				{
					Time.timeScale = (flag ? 0f : 1f);
				}
				if ((bool)_Water)
				{
					GUI.Label(new Rect(num, num2, num3, num4), $"Time Scale: {Time.timeScale}");
					num2 += num4;
					Time.timeScale = GUI.HorizontalSlider(new Rect(num, num2, num3, num4), Time.timeScale, 1f, 30f);
					num2 += num4;
				}
				if ((bool)_Water)
				{
					GUI.Label(new Rect(num, num2, num3, num4), "Global Wind Speed");
					num2 += num4;
					_Water._WindSpeed = GUI.HorizontalSlider(new Rect(num, num2, num3, num4), _Water._WindSpeed, 0f, 150f);
					num2 += num4;
				}
				OnGUIGerstnerSection(num, ref num2, num3, num4);
				_ShowWaterData = GUI.Toggle(new Rect(num, num2, num3, num4), _ShowWaterData, "Show sim data");
				num2 += num4;
				AnimatedWavesLod.s_Combine = GUI.Toggle(new Rect(num, num2, num3, num4), AnimatedWavesLod.s_Combine, "Shape combine pass");
				num2 += num4;
				ShadowLod.s_ProcessData = GUI.Toggle(new Rect(num, num2, num3, num4), ShadowLod.s_ProcessData, "Process Shadows");
				num2 += num4;
				if ((bool)_Water)
				{
					if (_Water._DynamicWavesLod.Enabled)
					{
						float num5 = 1f / (float)_Water._DynamicWavesLod.SimulationFrequency;
						GUI.Label(text: $"Sim steps: {num5:0.00000} x {_Water._DynamicWavesLod.LastUpdateSubstepCount}", position: new Rect(num, num2, num3, num4));
						num2 += num4;
					}
					if (_Water.AnimatedWavesLod.Provider is IQueryable queryable)
					{
						GUI.Label(new Rect(num, num2, num3, num4), $"Query result GUIDs: {queryable.ResultGuidCount}");
						num2 += num4;
						GUI.Label(new Rect(num, num2, num3, num4), $"Queries in flight: {queryable.RequestCount}");
						num2 += num4;
						GUI.Label(new Rect(num, num2, num3, num4), $"Query Count: {queryable.QueryCount}");
						num2 += num4;
					}
				}
				if (GUI.Button(new Rect(num, num2, num3, num4), "Hide GUI (G)"))
				{
					ToggleGUI();
				}
				num2 += num4;
			}
			if (_ShowWaterData && _Water != null)
			{
				DrawShapeTargets();
			}
			GUI.color = color;
		}

		private void OnGUIGerstnerSection(float x, ref float y, float w, float h)
		{
			GUI.Label(new Rect(x, y, w, h), "Gerstner weight(s)");
			y += h;
			foreach (KeyValuePair<int, ShapeGerstner> s_Instance in ShapeGerstner.s_Instances)
			{
				float num = 75f;
				s_Instance.Value.Weight = GUI.HorizontalSlider(new Rect(x, y, w - num - 5f, h), s_Instance.Value.Weight, 0f, 1f);
				y += h;
			}
			GUI.Label(new Rect(x, y, w, h), $"FFT generator(s): {FFTCompute.GeneratorCount}");
			y += h;
		}

		private void DrawShapeTargets()
		{
			Rect position = new Rect(_GuiVisible ? s_LeftPanelWidth : 0f, (float)Screen.height - s_BottomPanelHeight, Screen.width, s_BottomPanelHeight);
			GUI.color = s_GuiColor;
			GUI.DrawTexture(position, Texture2D.whiteTexture);
			GUI.color = Color.white;
			position.x += 10f;
			GUI.Label(position, "Viewer Height Above Water: " + _Water.ViewerHeightAboveWater);
			position.x += 250f;
			GUI.Label(position, "Speed: " + 3.6f * _ViewerVelocity.magnitude + "km/h");
			DrawSims();
		}

		private void DrawSims()
		{
			float offset = 1f;
			DrawVerticalScrollBar();
			DrawSim(_Water._AnimatedWavesLod, ref _DrawAnimatedWaves, ref offset, 0.5f);
			DrawSim(_Water._DynamicWavesLod, ref _DrawDynamicWaves, ref offset, 0.5f, 2f);
			DrawSim(_Water._FoamLod, ref _DrawFoam, ref offset);
			DrawSim(_Water._FlowLod, ref _DrawFlow, ref offset, 0.5f, 2f);
			DrawSim(_Water._ShadowLod, ref _DrawShadow, ref offset);
			DrawSim(_Water._DepthLod, ref _DrawDepth, ref offset);
			DrawSim(_Water._ClipLod, ref _DrawClip, ref offset);
		}

		private void DrawVerticalScrollBar()
		{
			if (_DrawLodDatasActualSize)
			{
				AnimatedWavesLod animatedWavesLod = _Water._AnimatedWavesLod;
				GUIStyle verticalScrollbar = GUI.skin.verticalScrollbar;
				verticalScrollbar.fixedWidth = 20f;
				float num = (float)Screen.height - s_BottomPanelHeight;
				Rect position = new Rect((float)Screen.width - verticalScrollbar.fixedWidth, 0f, verticalScrollbar.fixedWidth, num);
				GUI.color = s_GuiColor;
				GUI.DrawTexture(position, Texture2D.whiteTexture);
				GUI.color = Color.white;
				_ = animatedWavesLod.DataTexture.height;
				_ = animatedWavesLod.DataTexture.volumeDepth;
				_Scroll = GUI.VerticalScrollbar(position, _Scroll, num, 0f, animatedWavesLod.DataTexture.height * animatedWavesLod.DataTexture.volumeDepth, verticalScrollbar);
			}
		}

		private void DrawSim(Lod lodData, ref bool doDraw, ref float offset, float bias = 0f, float scale = 1f)
		{
			if (lodData == null || !lodData.Enabled)
			{
				return;
			}
			Type type = lodData.GetType();
			if (!s_SimulationNames.ContainsKey(type))
			{
				s_SimulationNames.Add(type, lodData.ID);
			}
			bool flag = offset == 1f;
			float num = (_DrawLodDatasActualSize ? _Scroll : 0f);
			float num2 = (float)Screen.height - s_BottomPanelHeight;
			float num3 = 7f;
			float num4 = (_DrawLodDatasActualSize ? ((float)lodData.DataTexture.height) : (num2 / (float)lodData.DataTexture.volumeDepth));
			float num5 = num4 + num3;
			float num6 = (float)Screen.width - num5 * offset + num3 * (offset - 1f);
			if (_DrawLodDatasActualSize)
			{
				num6 -= 20f;
			}
			if (doDraw)
			{
				GUI.color = s_GuiColor;
				GUI.DrawTexture(new Rect(num6, 0f, flag ? num5 : (num5 - num3), (float)Screen.height - s_BottomPanelHeight), Texture2D.whiteTexture);
				GUI.color = Color.white;
				if (Event.current.type == EventType.Repaint)
				{
					for (int i = 0; i < lodData.DataTexture.volumeDepth; i++)
					{
						float num7 = (float)i * num4;
						if (flag)
						{
							num5 += num3;
						}
						DebugArrayMaterial.SetInteger(ShaderIDs.s_Depth, i);
						DebugArrayMaterial.SetFloat(ShaderIDs.s_Scale, scale);
						DebugArrayMaterial.SetFloat(ShaderIDs.s_Bias, bias);
						Graphics.DrawTexture(new Rect(num6 + num3, num7 + num3 / 2f - num, num4 - num3, num4 - num3), lodData.DataTexture, DebugArrayMaterial);
					}
				}
			}
			doDraw = GUI.Toggle(new Rect(num6 + num3, num2, num5 - 2f * num3, s_BottomPanelHeight), doDraw, s_SimulationNames[type]);
			offset += 1f;
		}

		public static void DrawTextureArray(RenderTexture data, int columnOffsetFromRightSide, float bias = 0f, float scale = 1f)
		{
			float num = (float)Screen.height - s_BottomPanelHeight;
			float num2 = 1f;
			float num3 = num / (float)data.volumeDepth;
			float num4 = num3 + num2;
			float num5 = (float)Screen.width - num4 * (float)columnOffsetFromRightSide + num2 * ((float)columnOffsetFromRightSide - 1f);
			GUI.color = s_GuiColor;
			GUI.DrawTexture(new Rect(num5, 0f, ((float)columnOffsetFromRightSide == 1f) ? num4 : (num4 - num2), (float)Screen.height - s_BottomPanelHeight), Texture2D.whiteTexture);
			GUI.color = Color.white;
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			for (int i = 0; i < data.volumeDepth; i++)
			{
				float num6 = (float)i * num3;
				if ((float)columnOffsetFromRightSide == 1f)
				{
					num4 += num2;
				}
				DebugArrayMaterial.SetInteger(ShaderIDs.s_Depth, i);
				DebugArrayMaterial.SetFloat(ShaderIDs.s_Scale, scale);
				DebugArrayMaterial.SetFloat(ShaderIDs.s_Bias, bias);
				Graphics.DrawTexture(new Rect(num5 + num2, num6 + num2 / 2f, num3 - num2, num3 - num2), data, DebugArrayMaterial);
			}
		}

		private void ToggleGUI()
		{
			_GuiVisible = !_GuiVisible;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitStatics()
		{
			s_SimulationNames.Clear();
		}
	}
}

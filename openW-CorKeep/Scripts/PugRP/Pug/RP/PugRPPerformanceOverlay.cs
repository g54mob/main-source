using System;
using UnityEngine;

namespace Pug.RP
{
	public class PugRPPerformanceOverlay : MonoBehaviour
	{
		private Material m_perfGraphMaterial;

		private Material m_perfGraphMaterialFPS;

		private Material m_perfGraphMaterialShadows;

		private void DrawPerformanceGraph(AvgFloat avgFloat, float width, float height, Material material, string label, string format = "", Func<float, float> conversion = null)
		{
			float num = 30f;
			Rect rect = GUILayoutUtility.GetRect(width, height);
			avgFloat.SetMaterialProperties(material);
			material.SetVector("_RectSize", new Vector4(rect.width, rect.height, 1f / rect.width, 1f / rect.height));
			material.SetFloat("_Padding", num);
			rect.height += num;
			Graphics.DrawTexture(rect, Texture2D.whiteTexture, material);
			float num2;
			float num3;
			float num4;
			float num5;
			if (conversion != null)
			{
				num2 = conversion(avgFloat.latest);
				num3 = conversion(avgFloat.value);
				num4 = conversion(avgFloat.min);
				num5 = conversion(avgFloat.max);
			}
			else
			{
				num2 = avgFloat.latest;
				num3 = avgFloat.value;
				num4 = avgFloat.min;
				num5 = avgFloat.max;
			}
			if (num4 > num5)
			{
				float num6 = num4;
				num4 = num5;
				num5 = num6;
			}
			GUILayout.BeginHorizontal();
			GUILayout.Label(label + ": " + num2.ToString(format), GUILayout.Width(200f));
			GUILayout.Label("Avg: " + num3.ToString(format), GUILayout.Width(100f));
			GUILayout.Label("Min: " + num4.ToString(format), GUILayout.Width(100f));
			GUILayout.Label("Max: " + num5.ToString(format), GUILayout.Width(100f));
			GUILayout.EndHorizontal();
		}

		private float FrametimeToFramerate(float f)
		{
			return 1f / f * 1000f;
		}

		private void OnGUI()
		{
			if (m_perfGraphMaterial == null)
			{
				m_perfGraphMaterial = new Material(Shader.Find("Hidden/PugRP/DataVisualizer"));
				m_perfGraphMaterialFPS = new Material(Shader.Find("Hidden/PugRP/DataVisualizer"));
				m_perfGraphMaterialFPS.EnableKeyword("FPS_MODE");
				m_perfGraphMaterialShadows = new Material(Shader.Find("Hidden/PugRP/DataVisualizer"));
				m_perfGraphMaterialShadows.EnableKeyword("SHADOWS_MODE");
			}
			GUILayout.BeginArea(new Rect(20f, 20f, 500f, 500f));
			DrawPerformanceGraph(PugRP.avgFrametimer, 500f, 100f, m_perfGraphMaterial, "Frametime", "###.##");
			GUILayout.Space(5f);
			DrawPerformanceGraph(PugRP.avgFrametimer, 500f, 100f, m_perfGraphMaterialFPS, "Framerate", "###", FrametimeToFramerate);
			GUILayout.Space(5f);
			DrawPerformanceGraph(Shadows.avgShadowUpdates, 500f, 100f, m_perfGraphMaterialShadows, "Shadow Updates", "###");
			GUILayout.Space(5f);
			GUILayout.Label("CullOps: " + PugRP.cullOps);
			GUILayout.Label("RP: " + PugRP.avgInternalTime.value.ToString("###.##"));
			GUILayout.EndArea();
		}
	}
}

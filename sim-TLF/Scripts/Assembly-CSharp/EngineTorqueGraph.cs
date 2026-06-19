using System;
using System.Collections.Generic;
using UnityEngine;

public class EngineTorqueGraph : MonoBehaviour
{
	[Header("Graph Window")]
	[SerializeField]
	private Rect windowRect = new Rect(10f, 10f, 400f, 220f);

	[SerializeField]
	private bool showGraph;

	[SerializeField]
	private KeyCode toggleKey = KeyCode.F3;

	[Header("Colors")]
	[SerializeField]
	private Color modelCurveColor = new Color(0.3f, 0.8f, 1f);

	[SerializeField]
	private Color liveSampleColor = new Color(1f, 0.5f, 0.1f);

	[SerializeField]
	private Color rpmMarkerColor = Color.yellow;

	[SerializeField]
	private Color gridColor = new Color(1f, 1f, 1f, 0.1f);

	[Header("Graph Settings")]
	[SerializeField]
	private int modelCurveSteps = 100;

	[SerializeField]
	private bool showLiveSamples = true;

	[SerializeField]
	private bool showRPMMarker = true;

	[SerializeField]
	private bool showPowerCurve;

	private EngineComponent _engine;

	private Texture2D _graphTex;

	private GUIStyle _labelStyle;

	private const int TEX_W = 380;

	private const int TEX_H = 160;

	private void Awake()
	{
		_engine = GetComponent<EngineComponent>();
		_graphTex = new Texture2D(380, 160, TextureFormat.RGBA32, mipChain: false);
		_graphTex.filterMode = FilterMode.Bilinear;
	}

	private void Update()
	{
	}

	private void RenderGraph()
	{
		ClearTexture(new Color(0.08f, 0.08f, 0.12f, 1f));
		EngineModel engineModel = _engine.engineModel;
		float maxTorque = engineModel.peakTorqueNm * 1.1f;
		float redlineRPM = engineModel.redlineRPM;
		DrawGrid(redlineRPM, maxTorque);
		DrawModelCurve(engineModel, redlineRPM, maxTorque);
		if (showPowerCurve)
		{
			DrawPowerCurve(engineModel, redlineRPM, maxTorque);
		}
		if (showLiveSamples)
		{
			DrawLiveSamples(redlineRPM, maxTorque);
		}
		if (showRPMMarker)
		{
			DrawRPMMarker(redlineRPM, maxTorque);
		}
		_graphTex.Apply();
	}

	private void DrawGrid(float maxRPM, float maxTorque)
	{
		int num = 4;
		int num2 = 5;
		for (int i = 1; i < num; i++)
		{
			float num3 = (float)i / (float)num;
			DrawHorizontalLine(Mathf.RoundToInt(num3 * 160f), gridColor);
		}
		for (int j = 1; j < num2; j++)
		{
			float num4 = (float)j / (float)num2;
			DrawVerticalLine(Mathf.RoundToInt(num4 * 380f), gridColor);
		}
	}

	private void DrawModelCurve(EngineModel model, float maxRPM, float maxTorque)
	{
		Vector2 a = Vector2.zero;
		for (int i = 0; i <= modelCurveSteps; i++)
		{
			float rpm = (float)i / (float)modelCurveSteps * maxRPM;
			float torque = model.EvaluateTorque(rpm);
			Vector2 vector = ToPixel(rpm, torque, maxRPM, maxTorque);
			if (i > 0)
			{
				DrawLine(a, vector, modelCurveColor);
			}
			a = vector;
		}
	}

	private void DrawPowerCurve(EngineModel model, float maxRPM, float maxTorque)
	{
		float num = model.peakPowerKW * 1.1f;
		Color c = new Color(0.2f, 1f, 0.4f, 0.7f);
		Vector2 a = Vector2.zero;
		for (int i = 0; i <= modelCurveSteps; i++)
		{
			float num2 = (float)i / (float)modelCurveSteps * maxRPM;
			float num3 = model.EvaluateTorque(num2);
			float num4 = num2 * MathF.PI / 30f;
			float torque = num3 * num4 / 1000f / num * maxTorque;
			Vector2 vector = ToPixel(num2, torque, maxRPM, maxTorque);
			if (i > 0)
			{
				DrawLine(a, vector, c);
			}
			a = vector;
		}
	}

	private void DrawLiveSamples(float maxRPM, float maxTorque)
	{
		List<Vector2> torqueCurveSamples = _engine.TorqueCurveSamples;
		for (int i = 1; i < torqueCurveSamples.Count; i++)
		{
			Vector2 a = ToPixel(torqueCurveSamples[i - 1].x, torqueCurveSamples[i - 1].y, maxRPM, maxTorque);
			Vector2 b = ToPixel(torqueCurveSamples[i].x, torqueCurveSamples[i].y, maxRPM, maxTorque);
			DrawLine(a, b, liveSampleColor);
		}
	}

	private void DrawRPMMarker(float maxRPM, float maxTorque)
	{
		float rPM = _engine.RPM;
		float torque = _engine.Torque;
		Vector2 vector = ToPixel(rPM, torque, maxRPM, maxTorque);
		DrawFilledCircle((int)vector.x, (int)vector.y, 4, rpmMarkerColor);
	}

	private void DrawBackground()
	{
		GUI.color = new Color(0f, 0f, 0f, 0.75f);
		GUI.DrawTexture(new Rect(0f, 0f, windowRect.width, windowRect.height), Texture2D.whiteTexture);
		GUI.color = Color.white;
	}

	private void DrawHeader()
	{
		GUI.color = Color.white;
		GUI.Label(new Rect(5f, 2f, 300f, 18f), "<b>TORQUE GRAPH</b>  [" + _engine.engineName + "]  (F3 toggle)");
	}

	private void DrawGraphTexture()
	{
		GUI.DrawTexture(new Rect(5f, 22f, 380f, 160f), _graphTex);
	}

	private void DrawStats()
	{
		float num = 186f;
		GUI.color = Color.white;
		GUI.Label(new Rect(5f, num, 130f, 16f), $"RPM: <color=yellow>{_engine.RPM:F0}</color>");
		GUI.Label(new Rect(140f, num, 130f, 16f), $"Torque: <color=#FF8822>{_engine.Torque:F0} N·m</color>");
		GUI.Label(new Rect(275f, num, 130f, 16f), $"Power: <color=#44FF88>{_engine.Power:F1} kW</color>");
		num += 16f;
		string text = ((_engine.AFR != null) ? $"AFR: {_engine.AFR.CurrentAFR:F1}  λ={_engine.AFR.Lambda:F2}  [{_engine.AFR.Mixture}]" : "");
		GUI.Label(new Rect(5f, num, 400f, 16f), text);
		num += 16f;
		string text2 = ((_engine.Timing != null) ? ($"Timing: {_engine.Timing.IgnitionAdvanceDeg:F1}° BTDC  " + (_engine.Timing.KnockDetected ? "<color=red>KNOCK!</color>" : "")) : "");
		GUI.Label(new Rect(5f, num, 400f, 16f), text2);
	}

	private Vector2 ToPixel(float rpm, float torque, float maxRPM, float maxTorque)
	{
		float x = rpm / maxRPM * 380f;
		float y = torque / maxTorque * 160f;
		return new Vector2(x, y);
	}

	private void ClearTexture(Color c)
	{
		Color[] array = new Color[60800];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = c;
		}
		_graphTex.SetPixels(array);
	}

	private void DrawLine(Vector2 a, Vector2 b, Color c)
	{
		int num = (int)a.x;
		int num2 = (int)a.y;
		int num3 = (int)b.x;
		int num4 = (int)b.y;
		int num5 = Mathf.Abs(num3 - num);
		int num6 = Mathf.Abs(num4 - num2);
		int num7 = ((num < num3) ? 1 : (-1));
		int num8 = ((num2 < num4) ? 1 : (-1));
		int num9 = num5 - num6;
		while (true)
		{
			SetPixelSafe(num, num2, c);
			if (num != num3 || num2 != num4)
			{
				int num10 = 2 * num9;
				if (num10 > -num6)
				{
					num9 -= num6;
					num += num7;
				}
				if (num10 < num5)
				{
					num9 += num5;
					num2 += num8;
				}
				continue;
			}
			break;
		}
	}

	private void DrawHorizontalLine(int y, Color c)
	{
		for (int i = 0; i < 380; i++)
		{
			SetPixelSafe(i, y, c);
		}
	}

	private void DrawVerticalLine(int x, Color c)
	{
		for (int i = 0; i < 160; i++)
		{
			SetPixelSafe(x, i, c);
		}
	}

	private void DrawFilledCircle(int cx, int cy, int r, Color c)
	{
		for (int i = cx - r; i <= cx + r; i++)
		{
			for (int j = cy - r; j <= cy + r; j++)
			{
				if ((i - cx) * (i - cx) + (j - cy) * (j - cy) <= r * r)
				{
					SetPixelSafe(i, j, c);
				}
			}
		}
	}

	private void SetPixelSafe(int x, int y, Color c)
	{
		if (x >= 0 && x < 380 && y >= 0 && y < 160)
		{
			_graphTex.SetPixel(x, y, c);
		}
	}
}

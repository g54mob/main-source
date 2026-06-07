using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmileyChart : MaskableGraphic, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class SmileyData
	{
		public string Name;

		public float Skill;

		public float Score;

		public float Bias;

		public SmileyData()
		{
		}

		public SmileyData(string name, float skill, float score, float bias)
		{
			Name = name;
			Skill = skill;
			Score = score;
			Bias = bias;
		}

		private string BiasString()
		{
			if (Bias < -0.1f)
			{
				return "NegativePostfixBias".Loc(BalanceLabels[(0f - Bias).MapRange(0.1f, 1f, 0f, 1f).Quantize(BalanceLabels.Length)].Loc());
			}
			if (Bias > 0.1f)
			{
				return "PositivePostfixBias".Loc(BalanceLabels[Bias.MapRange(0.1f, 1f, 0f, 1f).Quantize(BalanceLabels.Length)].Loc());
			}
			return "BiasNone".Loc();
		}

		public override string ToString()
		{
			return Name + "\n" + "Skill".Loc() + ": " + BalanceLabels[Skill.Quantize(BalanceLabels.Length)].Loc() + "\n" + "Bias".Loc() + ": " + BiasString();
		}
	}

	public static string[] BalanceLabels = new string[5] { "BalanceAmount1", "BalanceAmount2", "BalanceAmount3", "BalanceAmount4", "BalanceAmount5" };

	public List<SmileyData> Scores = new List<SmileyData>();

	public Gradient Colors;

	public int Smileys;

	public int Dimensions;

	public float size;

	private bool _toolTip;

	public Texture tex;

	public override Texture mainTexture
	{
		get
		{
			return tex;
		}
	}

	public static string ScoreString(float score)
	{
		return (Mathf.Round(score * 100f) / 10f).ToString("0.#");
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 vector = new Vector2((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		if (Scores.Count > 0)
		{
			float num = 0f;
			float num2;
			if (base.rectTransform.rect.width < (float)(Scores.Count * 32))
			{
				num2 = ((float)Scores.Count * base.rectTransform.rect.width + base.rectTransform.rect.width - (float)(32 * Scores.Count)) / (float)(Scores.Count * Scores.Count);
			}
			else
			{
				num2 = base.rectTransform.rect.width / (float)Scores.Count;
				num = num2 / 2f - 16f;
			}
			for (int num3 = Scores.Count - 1; num3 > -1; num3--)
			{
				float num4 = (float)num3 / (float)Mathf.Max(1, Scores.Count - 1);
				num4 *= 0.9f;
				num4 = Mathf.Max(0f, size - num4) / (1f - num4);
				DrawSmiley(new Rect(vector.x + (float)num3 * num2 + num + 16f * (1f - num4), vector.y - 32f + 16f * (1f - num4), 32f * num4, 32f * num4), Scores[num3].Score, vh);
			}
		}
	}

	private void DrawSmiley(Rect r, float score, VertexHelper vh)
	{
		int num = Mathf.Clamp(Mathf.FloorToInt(score * (float)Smileys), 0, Smileys - 1);
		int num2 = num % Dimensions;
		int num3 = Dimensions - Mathf.FloorToInt((float)num / (float)Dimensions);
		float num4 = 1f / (float)Dimensions;
		Color color = Colors.Evaluate(score);
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMin, r.yMin, 0f),
				uv0 = new Vector2((float)num2 * num4, (float)num3 * num4 - num4)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMax, r.yMin, 0f),
				uv0 = new Vector2((float)num2 * num4 + num4, (float)num3 * num4 - num4)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMax, r.yMax, 0f),
				uv0 = new Vector2((float)num2 * num4 + num4, (float)num3 * num4)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMin, r.yMax, 0f),
				uv0 = new Vector2((float)num2 * num4, (float)num3 * num4)
			}
		});
	}

	private void UpdateTooltip(SmileyData data)
	{
		Tooltip.UpdateToolTip("Score".Loc() + ": " + ScoreString(data.Score) + "/10", data.ToString());
	}

	public void Update()
	{
		if (!Mathf.Approximately(size, 1f))
		{
			size = Mathf.Lerp(size, 1f, Time.deltaTime * 8f);
			SetVerticesDirty();
		}
		if (!_toolTip)
		{
			return;
		}
		if (Tooltip.IsShowing)
		{
			Vector2 localPoint;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				return;
			}
			float num = localPoint.x + base.rectTransform.pivot.x * base.rectTransform.rect.width;
			if (base.rectTransform.rect.width < (float)(Scores.Count * 32))
			{
				if (num < 32f)
				{
					UpdateTooltip(Scores[0]);
					return;
				}
				float num2 = (base.rectTransform.rect.width - 32f) / (float)(Scores.Count - 1);
				int value = Mathf.FloorToInt((num - 32f) / num2) + 1;
				UpdateTooltip(Scores[Mathf.Clamp(value, 0, Scores.Count - 1)]);
			}
			else
			{
				float num3 = base.rectTransform.rect.width / (float)Scores.Count;
				int value2 = Mathf.FloorToInt(num / num3);
				UpdateTooltip(Scores[Mathf.Clamp(value2, 0, Scores.Count - 1)]);
			}
		}
		else
		{
			_toolTip = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Scores.Count > 0)
		{
			_toolTip = true;
			Tooltip.SetToolTip("0", null, base.rectTransform);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_toolTip = false;
	}
}

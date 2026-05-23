using System;
using System.Collections.Generic;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct GradientEffect : IMPUIComponent
	{
		[SerializeField]
		private bool m_Enabled;

		[SerializeField]
		private GradientType m_GradientType;

		[SerializeField]
		private Gradient m_Gradient;

		[SerializeField]
		private Color[] m_CornerGradientColors;

		[SerializeField]
		private float m_Rotation;

		private static readonly int SpGradientType = Shader.PropertyToID("_GradientType");

		private static readonly int SpGradientColors = Shader.PropertyToID("colors");

		private static readonly int SpGradientAlphas = Shader.PropertyToID("alphas");

		private static readonly int SpGradientColorsLength = Shader.PropertyToID("_GradientColorLength");

		private static readonly int SpGradientAlphasLength = Shader.PropertyToID("_GradientAlphaLength");

		private static readonly int SpGradientInterpolationType = Shader.PropertyToID("_GradientInterpolationType");

		private static readonly int SpEnableGradient = Shader.PropertyToID("_EnableGradient");

		private static readonly int SpGradientRotation = Shader.PropertyToID("_GradientRotation");

		public bool Enabled
		{
			get
			{
				return m_Enabled;
			}
			set
			{
				m_Enabled = value;
				if (ShouldModifySharedMat)
				{
					SharedMat.SetInt(SpEnableGradient, m_Enabled ? 1 : 0);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public GradientType GradientType
		{
			get
			{
				return m_GradientType;
			}
			set
			{
				m_GradientType = value;
				if (ShouldModifySharedMat)
				{
					SharedMat.SetInt(SpGradientType, (int)m_GradientType);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public float Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				m_Rotation = value;
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpGradientRotation, m_Rotation);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Gradient Gradient
		{
			get
			{
				return m_Gradient;
			}
			set
			{
				m_Gradient = value;
				if (ShouldModifySharedMat)
				{
					List<Color> list = new List<Color>(8);
					List<Color> list2 = new List<Color>(8);
					for (int i = 0; i < 8; i++)
					{
						if (i < m_Gradient.colorKeys.Length)
						{
							Color color = m_Gradient.colorKeys[i].color;
							Vector4 vector = new Vector4(color.r, color.g, color.b, m_Gradient.colorKeys[i].time);
							list.Add(vector);
							SharedMat.SetColor("_GradientColor" + i, vector);
						}
						else
						{
							SharedMat.SetColor("_GradientColor" + i, Vector4.zero);
						}
						if (i < m_Gradient.alphaKeys.Length)
						{
							Vector4 vector2 = new Vector4(m_Gradient.alphaKeys[i].alpha, m_Gradient.alphaKeys[i].time);
							list2.Add(vector2);
							SharedMat.SetColor("_GradientAlpha" + i, vector2);
						}
						else
						{
							SharedMat.SetColor("_GradientAlpha" + i, Vector4.zero);
						}
					}
					SharedMat.SetInt(SpGradientColorsLength, m_Gradient.colorKeys.Length);
					SharedMat.SetInt(SpGradientAlphasLength, m_Gradient.alphaKeys.Length);
					for (int j = list.Count; j < 8; j++)
					{
						list.Add(Vector4.zero);
					}
					for (int k = list2.Count; k < 8; k++)
					{
						list2.Add(Vector4.zero);
					}
					SharedMat.SetColorArray(SpGradientColors, list);
					SharedMat.GetColorArray(SpGradientAlphas, list2);
					SharedMat.SetInt(SpGradientInterpolationType, (int)m_Gradient.mode);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Color[] CornerGradientColors
		{
			get
			{
				return m_CornerGradientColors;
			}
			set
			{
				if (m_CornerGradientColors.Length != 4)
				{
					m_CornerGradientColors = new Color[4];
				}
				for (int i = 0; i < value.Length && i < 4; i++)
				{
					m_CornerGradientColors[i] = value[i];
				}
				if (ShouldModifySharedMat)
				{
					for (int j = 0; j < m_CornerGradientColors.Length; j++)
					{
						SharedMat.SetColor("_CornerGradientColor" + j, m_CornerGradientColors[j]);
					}
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Material SharedMat { get; set; }

		public bool ShouldModifySharedMat { get; set; }

		public RectTransform RectTransform { get; set; }

		public event EventHandler OnComponentSettingsChanged;

		public void Init(Material SharedMat, Material renderMat, RectTransform rectTransform)
		{
			this.SharedMat = SharedMat;
			ShouldModifySharedMat = SharedMat == renderMat;
			RectTransform = rectTransform;
			if (m_CornerGradientColors == null || m_CornerGradientColors.Length != 4)
			{
				m_CornerGradientColors = new Color[4];
			}
		}

		public void OnValidate()
		{
			Enabled = m_Enabled;
			GradientType = m_GradientType;
			Gradient = m_Gradient;
			CornerGradientColors = m_CornerGradientColors;
			Rotation = m_Rotation;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_Enabled = material.GetInt(SpEnableGradient) == 1;
			m_GradientType = (GradientType)material.GetInt(SpGradientType);
			m_Rotation = material.GetFloat(SpGradientRotation);
			int num = material.GetInt(SpGradientColorsLength);
			int num2 = material.GetInt(SpGradientAlphasLength);
			Gradient gradient = new Gradient();
			GradientColorKey[] array = new GradientColorKey[num];
			GradientAlphaKey[] array2 = new GradientAlphaKey[num2];
			for (int i = 0; i < num; i++)
			{
				Color color = material.GetColor("_GradientColor" + i);
				array[i].color = new Color(color.r, color.g, color.b);
				array[i].time = color.a;
			}
			gradient.colorKeys = array;
			for (int j = 0; j < num2; j++)
			{
				Color color2 = material.GetColor("_GradientAlpha" + j);
				array2[j].alpha = color2.r;
				array2[j].time = color2.g;
			}
			gradient.alphaKeys = array2;
			gradient.mode = (GradientMode)material.GetInt(SpGradientInterpolationType);
			m_Gradient = gradient;
			m_CornerGradientColors = new Color[4];
			for (int k = 0; k < CornerGradientColors.Length; k++)
			{
				CornerGradientColors[k] = material.GetColor("_CornerGradientColor" + k);
			}
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.DisableKeyword("GRADIENT_LINEAR");
			material.DisableKeyword("GRADIENT_RADIAL");
			material.DisableKeyword("GRADIENT_CORNER");
			if (!m_Enabled)
			{
				return;
			}
			material.SetInt(SpEnableGradient, m_Enabled ? 1 : 0);
			material.SetInt(SpGradientType, (int)m_GradientType);
			switch (m_GradientType)
			{
			case GradientType.Linear:
				material.EnableKeyword("GRADIENT_LINEAR");
				break;
			case GradientType.Radial:
				material.EnableKeyword("GRADIENT_RADIAL");
				break;
			case GradientType.Corner:
				material.EnableKeyword("GRADIENT_CORNER");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (m_GradientType == GradientType.Corner)
			{
				for (int i = 0; i < m_CornerGradientColors.Length; i++)
				{
					material.SetColor("_CornerGradientColor" + i, m_CornerGradientColors[i]);
				}
				return;
			}
			Color[] array = new Color[8];
			Color[] array2 = new Color[8];
			for (int j = 0; j < m_Gradient.colorKeys.Length; j++)
			{
				Color color = m_Gradient.colorKeys[j].color;
				array[j] = new Color(color.r, color.g, color.b, m_Gradient.colorKeys[j].time);
			}
			for (int k = 0; k < m_Gradient.alphaKeys.Length; k++)
			{
				array2[k] = new Color(m_Gradient.alphaKeys[k].alpha, m_Gradient.alphaKeys[k].time, 0f, 0f);
			}
			material.SetFloat(SpGradientColorsLength, m_Gradient.colorKeys.Length);
			material.SetFloat(SpGradientAlphasLength, m_Gradient.alphaKeys.Length);
			material.SetFloat(SpGradientInterpolationType, (float)m_Gradient.mode);
			material.SetFloat(SpGradientRotation, m_Rotation);
			for (int l = 0; l < array.Length; l++)
			{
				material.SetColor("_GradientColor" + l, array[l]);
			}
			for (int m = 0; m < array2.Length; m++)
			{
				material.SetColor("_GradientAlpha" + m, array2[m]);
			}
		}
	}
}

using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct Circle : IMPUIComponent
	{
		[SerializeField]
		private float m_Radius;

		[SerializeField]
		private bool m_FitRadius;

		private static readonly int SpRadius = Shader.PropertyToID("_CircleRadius");

		private static readonly int SpFitRadius = Shader.PropertyToID("_CircleFitRadius");

		public float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = Mathf.Max(value, 0f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpRadius, m_Radius);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public bool FitToRect
		{
			get
			{
				return m_FitRadius;
			}
			set
			{
				m_FitRadius = value;
				if (ShouldModifySharedMat)
				{
					SharedMat.SetInt(SpFitRadius, m_FitRadius ? 1 : 0);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private float CircleFitRadius => Mathf.Min(RectTransform.rect.width, RectTransform.rect.height) / 2f;

		public Material SharedMat { get; set; }

		public bool ShouldModifySharedMat { get; set; }

		public RectTransform RectTransform { get; set; }

		public event EventHandler OnComponentSettingsChanged;

		public void Init(Material sharedMat, Material renderMat, RectTransform rectTransform)
		{
			SharedMat = sharedMat;
			ShouldModifySharedMat = sharedMat == renderMat;
			RectTransform = rectTransform;
		}

		public void OnValidate()
		{
			Radius = m_Radius;
			FitToRect = m_FitRadius;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_Radius = material.GetFloat(SpRadius);
			m_FitRadius = material.GetInt(SpFitRadius) == 1;
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.SetFloat(SpRadius, m_Radius);
			material.SetInt(SpFitRadius, m_FitRadius ? 1 : 0);
		}

		internal void UpdateCircleRadius(RectTransform rectT)
		{
			RectTransform = rectT;
			if (m_FitRadius)
			{
				m_Radius = CircleFitRadius;
			}
		}
	}
}

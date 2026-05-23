using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct Pentagon : IMPUIComponent
	{
		[SerializeField]
		private Vector4 m_CornerRadius;

		[SerializeField]
		private bool m_UniformCornerRadius;

		[SerializeField]
		private float m_TipRadius;

		[SerializeField]
		private float m_TipSize;

		private static readonly int SpPentagonRectCornerRadius = Shader.PropertyToID("_PentagonCornerRadius");

		private static readonly int SpPentagonTriangleCornerRadius = Shader.PropertyToID("_PentagonTipRadius");

		private static readonly int SpPentagonTriangleSize = Shader.PropertyToID("_PentagonTipSize");

		public Vector4 CornerRadius
		{
			get
			{
				return m_CornerRadius;
			}
			set
			{
				m_CornerRadius = Vector4.Max(value, Vector4.zero);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpPentagonRectCornerRadius, m_CornerRadius);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public float TipRadius
		{
			get
			{
				return m_TipRadius;
			}
			set
			{
				m_TipRadius = Mathf.Max(value, 0.001f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpPentagonTriangleCornerRadius, m_TipRadius);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public float TipSize
		{
			get
			{
				return m_TipSize;
			}
			set
			{
				m_TipSize = Mathf.Max(value, 1f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpPentagonTriangleSize, m_TipSize);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Material SharedMat { get; set; }

		public bool ShouldModifySharedMat { get; set; }

		public RectTransform RectTransform { get; set; }

		public event EventHandler OnComponentSettingsChanged;

		public void Init(Material sharedMat, Material renderMat, RectTransform rectTransform)
		{
			SharedMat = sharedMat;
			ShouldModifySharedMat = sharedMat == renderMat;
			RectTransform = rectTransform;
			TipSize = m_TipSize;
			TipRadius = m_TipRadius;
		}

		public void OnValidate()
		{
			CornerRadius = m_CornerRadius;
			TipSize = m_TipSize;
			TipRadius = m_TipRadius;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_CornerRadius = material.GetVector(SpPentagonRectCornerRadius);
			m_TipSize = material.GetFloat(SpPentagonTriangleSize);
			m_TipRadius = material.GetFloat(SpPentagonTriangleCornerRadius);
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.SetVector(SpPentagonRectCornerRadius, m_CornerRadius);
			material.SetFloat(SpPentagonTriangleCornerRadius, m_TipRadius);
			material.SetFloat(SpPentagonTriangleSize, m_TipSize);
		}
	}
}

using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct Hexagon : IMPUIComponent
	{
		[SerializeField]
		private Vector4 m_CornerRadius;

		[SerializeField]
		private bool m_UniformCornerRadius;

		[SerializeField]
		private Vector2 m_TipSize;

		[SerializeField]
		private bool m_UniformTipSize;

		[SerializeField]
		private Vector2 m_TipRadius;

		[SerializeField]
		private bool m_UniformTipRadius;

		private static readonly int SpHexagonTipSizes = Shader.PropertyToID("_HexagonTipSize");

		private static readonly int SpHexagonTipRadius = Shader.PropertyToID("_HexagonTipRadius");

		private static readonly int SpHexagonRectCornerRadius = Shader.PropertyToID("_HexagonCornerRadius");

		public Vector2 TipSize
		{
			get
			{
				return m_TipSize;
			}
			set
			{
				m_TipSize = Vector2.Max(value, Vector2.one);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpHexagonTipSizes, m_TipSize);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Vector2 TipRadius
		{
			get
			{
				return m_TipRadius;
			}
			set
			{
				m_TipRadius = Vector2.Max(value, Vector2.one);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpHexagonTipRadius, m_TipRadius);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Vector4 CornerRadius
		{
			get
			{
				return m_CornerRadius;
			}
			set
			{
				m_CornerRadius = Vector4.Max(value, Vector4.one);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpHexagonRectCornerRadius, m_CornerRadius);
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
			TipRadius = m_TipRadius;
			TipSize = m_TipSize;
		}

		public void OnValidate()
		{
			CornerRadius = m_CornerRadius;
			TipSize = m_TipSize;
			TipRadius = m_TipRadius;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_CornerRadius = material.GetVector(SpHexagonRectCornerRadius);
			m_TipRadius = material.GetVector(SpHexagonTipRadius);
			m_TipSize = material.GetVector(SpHexagonTipSizes);
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.SetVector(SpHexagonTipSizes, m_TipSize);
			material.SetVector(SpHexagonTipRadius, m_TipRadius);
			material.SetVector(SpHexagonRectCornerRadius, m_CornerRadius);
		}
	}
}

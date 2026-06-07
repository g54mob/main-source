using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct NStarPolygon : IMPUIComponent
	{
		[SerializeField]
		private float m_SideCount;

		[SerializeField]
		private float m_Inset;

		[SerializeField]
		private float m_CornerRadius;

		[SerializeField]
		private Vector2 m_Offset;

		private static readonly int SpNStarPolygonSideCount = Shader.PropertyToID("_NStarPolygonSideCount");

		private static readonly int SpNStarPolygonInset = Shader.PropertyToID("_NStarPolygonInset");

		private static readonly int SpNStarPolygonCornerRadius = Shader.PropertyToID("_NStarPolygonCornerRadius");

		private static readonly int SpNStarPolygonOffset = Shader.PropertyToID("_NStarPolygonOffset");

		public float SideCount
		{
			get
			{
				return m_SideCount;
			}
			set
			{
				m_SideCount = Mathf.Clamp(value, 3f, 10f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpNStarPolygonSideCount, m_SideCount);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
				Inset = m_Inset;
			}
		}

		public float Inset
		{
			get
			{
				return m_Inset;
			}
			set
			{
				m_Inset = Mathf.Clamp(value, 2f, SideCount - 0.01f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpNStarPolygonInset, m_Inset);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public float CornerRadius
		{
			get
			{
				return m_CornerRadius;
			}
			set
			{
				m_CornerRadius = Mathf.Max(value, 0f);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetFloat(SpNStarPolygonCornerRadius, m_CornerRadius);
				}
				this.OnComponentSettingsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public Vector2 Offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				m_Offset = value;
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpNStarPolygonOffset, m_Offset);
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
			OnValidate();
		}

		public void OnValidate()
		{
			SideCount = m_SideCount;
			Inset = m_Inset;
			CornerRadius = m_CornerRadius;
			Offset = m_Offset;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_SideCount = material.GetFloat(SpNStarPolygonSideCount);
			m_Inset = material.GetFloat(SpNStarPolygonInset);
			m_CornerRadius = material.GetFloat(SpNStarPolygonCornerRadius);
			m_Offset = material.GetVector(SpNStarPolygonOffset);
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.SetFloat(SpNStarPolygonSideCount, m_SideCount);
			material.SetFloat(SpNStarPolygonInset, m_Inset);
			material.SetFloat(SpNStarPolygonCornerRadius, m_CornerRadius);
			material.SetVector(SpNStarPolygonOffset, m_Offset);
		}
	}
}

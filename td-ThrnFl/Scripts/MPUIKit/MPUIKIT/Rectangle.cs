using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct Rectangle : IMPUIComponent
	{
		[SerializeField]
		private Vector4 m_CornerRadius;

		private static readonly int SpRectangleCornerRadius = Shader.PropertyToID("_RectangleCornerRadius");

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
					SharedMat.SetVector(SpRectangleCornerRadius, m_CornerRadius);
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
		}

		public void OnValidate()
		{
			CornerRadius = m_CornerRadius;
		}

		public void InitValuesFromMaterial(ref Material material)
		{
			m_CornerRadius = material.GetVector(SpRectangleCornerRadius);
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			Vector4 value = FixRadius(m_CornerRadius);
			material.SetVector(SpRectangleCornerRadius, value);
		}

		private Vector4 FixRadius(Vector4 radius)
		{
			Rect rect = RectTransform.rect;
			radius = Vector4.Max(radius, Vector4.zero);
			radius = Vector4.Min(radius, Vector4.one * Mathf.Min(rect.width, rect.height));
			float num = Mathf.Min(Mathf.Min(Mathf.Min(Mathf.Min(rect.width / (radius.x + radius.y), rect.width / (radius.z + radius.w)), rect.height / (radius.x + radius.w)), rect.height / (radius.z + radius.y)), 1f);
			return radius * num;
		}
	}
}

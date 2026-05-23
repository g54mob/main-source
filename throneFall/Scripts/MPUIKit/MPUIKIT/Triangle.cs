using System;
using UnityEngine;

namespace MPUIKIT
{
	[Serializable]
	public struct Triangle : IMPUIComponent
	{
		[SerializeField]
		private Vector3 m_CornerRadius;

		private static readonly int SpTriangleCornerRadius = Shader.PropertyToID("_TriangleCornerRadius");

		public Vector3 CornerRadius
		{
			get
			{
				return m_CornerRadius;
			}
			set
			{
				m_CornerRadius = Vector3.Max(value, Vector3.zero);
				if (ShouldModifySharedMat)
				{
					SharedMat.SetVector(SpTriangleCornerRadius, m_CornerRadius);
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
			m_CornerRadius = material.GetVector(SpTriangleCornerRadius);
		}

		public void ModifyMaterial(ref Material material, params object[] otherProperties)
		{
			material.SetVector(SpTriangleCornerRadius, m_CornerRadius);
		}
	}
}

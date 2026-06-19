using UnityEngine;

namespace TH20
{
	public class GoboProjector : MonoBehaviour
	{
		public Vector2 ScrollSpeed = new Vector2(0.01f, 0.01f);

		public float Scale;

		public Color ShadowColor;

		public Texture ShadowMask;

		public Vector2 MaskCutoff = new Vector2(0f, 1f);

		public float MaskMultiplier = 1f;

		public bool UpdateParameters;

		public Projector Projector;

		private Material _material;

		private void Start()
		{
			_material = new Material(Projector.material);
			Projector.orthographic = true;
			Projector.material = _material;
			_material.SetTexture("_ShadowTex", ShadowMask);
			_material.SetVector("_AnimInfo", new Vector4(ScrollSpeed.x, ScrollSpeed.y, Scale, Time.unscaledTime));
			_material.SetVector("_Color", ShadowColor);
			_material.SetFloat("_MinMaskCutoff", MaskCutoff.x);
			_material.SetFloat("_MaxMaskCutoff", MaskCutoff.y);
			_material.SetFloat("_MaskMultiplier", MaskMultiplier);
		}

		private void Update()
		{
			bool flag = QualitySettings.GetQualityLevel() > 2;
			if (Projector.enabled != flag)
			{
				Projector.enabled = flag;
			}
			if (flag)
			{
				_material.SetVector("_AnimInfo", new Vector4(ScrollSpeed.x, ScrollSpeed.y, Scale, Time.unscaledTime));
				if (UpdateParameters)
				{
					_material.SetVector("_Color", ShadowColor);
					_material.SetFloat("_MinMaskCutoff", MaskCutoff.x);
					_material.SetFloat("_MaxMaskCutoff", MaskCutoff.y);
					_material.SetFloat("_MaskMultiplier", MaskMultiplier);
				}
			}
		}
	}
}

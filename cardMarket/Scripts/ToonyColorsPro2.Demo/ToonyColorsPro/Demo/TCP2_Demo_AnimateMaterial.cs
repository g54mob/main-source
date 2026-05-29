using System;
using UnityEngine;

namespace ToonyColorsPro.Demo
{
	public class TCP2_Demo_AnimateMaterial : MonoBehaviour
	{
		[Serializable]
		public class AnimatedProperty
		{
			public enum MaterialPropertyType
			{
				Float = 0,
				Color = 1,
				Vector4 = 2
			}

			public string Name = "_Color";

			public MaterialPropertyType Type;

			public AnimationCurve Curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

			public float Duration = 1f;

			[Space]
			public float FloatFrom;

			public float FloatTo = 1f;

			[Space]
			public Color ColorFrom = Color.black;

			public Color ColorTo = Color.white;

			[Space]
			public Vector4 VectorFrom = Vector4.zero;

			public Vector4 VectorTo = Vector4.one;

			private int propertyId;

			public void Init()
			{
				propertyId = Shader.PropertyToID(Name);
			}

			public void Update(Material material)
			{
				float t = Curve.Evaluate(Time.time % Duration / Duration);
				switch (Type)
				{
				case MaterialPropertyType.Float:
					material.SetFloat(propertyId, Mathf.Lerp(FloatFrom, FloatTo, t));
					break;
				case MaterialPropertyType.Color:
					material.SetColor(propertyId, Color.Lerp(ColorFrom, ColorTo, t));
					break;
				case MaterialPropertyType.Vector4:
					material.SetVector(propertyId, Vector4.Lerp(VectorFrom, VectorTo, t));
					break;
				}
			}
		}

		public Material material;

		public AnimatedProperty[] animatedProperties;

		private void Awake()
		{
			if (animatedProperties != null)
			{
				AnimatedProperty[] array = animatedProperties;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Init();
				}
			}
		}

		private void Update()
		{
			if (animatedProperties != null)
			{
				AnimatedProperty[] array = animatedProperties;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Update(material);
				}
			}
		}
	}
}

using TMPro;
using UnityEngine;

namespace Shapes
{
	public class TextMeshProShapes : TextMeshPro
	{
		[SerializeField]
		protected float curvature;

		[SerializeField]
		protected Vector2 curvaturePivot;

		public float Curvature
		{
			get
			{
				return curvature;
			}
			set
			{
				if (curvature != value)
				{
					m_havePropertiesChanged = true;
					curvature = value;
					SetVerticesDirty();
				}
			}
		}

		public Vector2 CurvaturePivot
		{
			get
			{
				return curvaturePivot;
			}
			set
			{
				if (!(curvaturePivot == value))
				{
					m_havePropertiesChanged = true;
					curvaturePivot = value;
					SetVerticesDirty();
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			OnPreRenderText += ApplyDeformation;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			OnPreRenderText -= ApplyDeformation;
		}

		private void ApplyDeformation(TMP_TextInfo obj)
		{
			if (curvature == 0f)
			{
				return;
			}
			Vector3 vector = curvaturePivot;
			TMP_CharacterInfo[] characterInfo = base.textInfo.characterInfo;
			for (int i = 0; i < characterInfo.Length; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					int vertexIndex = tMP_CharacterInfo.vertexIndex;
					Vector3[] vertices = base.textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].vertices;
					for (int j = 0; j < 4; j++)
					{
						vertices[vertexIndex + j] = Bend(vertices[vertexIndex + j] - vector, curvature) + vector;
					}
				}
			}
		}

		private static Vector3 Bend(Vector3 p, float curvature)
		{
			float num = 1f - curvature * p.y;
			float num2 = p.x * num;
			float num3 = curvature / num;
			float x = num2 * num3;
			return new Vector3(num2 * ShapesMath.Sinc(x), num2 * ShapesMath.Cosinc(x) + p.y, p.z);
		}
	}
}

using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	public class GradientText : TextMeshProUGUI
	{
		[SerializeField]
		private bool colorGradientLine = true;

		[SerializeField]
		private Gradient gradientColors;

		protected override void FillCharacterVertexBuffers(int i)
		{
			int materialReferenceIndex = m_textInfo.characterInfo[i].materialReferenceIndex;
			int vertexCount = m_textInfo.meshInfo[materialReferenceIndex].vertexCount;
			if (vertexCount >= m_textInfo.meshInfo[materialReferenceIndex].vertices.Length)
			{
				m_textInfo.meshInfo[materialReferenceIndex].ResizeMeshInfo(Mathf.NextPowerOfTwo((vertexCount + 4) / 4));
			}
			TMP_CharacterInfo[] characterInfo = m_textInfo.characterInfo;
			m_textInfo.characterInfo[i].vertexIndex = vertexCount;
			m_textInfo.meshInfo[materialReferenceIndex].vertices[vertexCount] = characterInfo[i].vertex_BL.position;
			m_textInfo.meshInfo[materialReferenceIndex].vertices[1 + vertexCount] = characterInfo[i].vertex_TL.position;
			m_textInfo.meshInfo[materialReferenceIndex].vertices[2 + vertexCount] = characterInfo[i].vertex_TR.position;
			m_textInfo.meshInfo[materialReferenceIndex].vertices[3 + vertexCount] = characterInfo[i].vertex_BR.position;
			m_textInfo.meshInfo[materialReferenceIndex].uvs0[vertexCount] = characterInfo[i].vertex_BL.uv;
			m_textInfo.meshInfo[materialReferenceIndex].uvs0[1 + vertexCount] = characterInfo[i].vertex_TL.uv;
			m_textInfo.meshInfo[materialReferenceIndex].uvs0[2 + vertexCount] = characterInfo[i].vertex_TR.uv;
			m_textInfo.meshInfo[materialReferenceIndex].uvs0[3 + vertexCount] = characterInfo[i].vertex_BR.uv;
			m_textInfo.meshInfo[materialReferenceIndex].uvs2[vertexCount] = characterInfo[i].vertex_BL.uv2;
			m_textInfo.meshInfo[materialReferenceIndex].uvs2[1 + vertexCount] = characterInfo[i].vertex_TL.uv2;
			m_textInfo.meshInfo[materialReferenceIndex].uvs2[2 + vertexCount] = characterInfo[i].vertex_TR.uv2;
			m_textInfo.meshInfo[materialReferenceIndex].uvs2[3 + vertexCount] = characterInfo[i].vertex_BR.uv2;
			m_textInfo.meshInfo[materialReferenceIndex].colors32[vertexCount] = characterInfo[i].vertex_BL.color;
			m_textInfo.meshInfo[materialReferenceIndex].colors32[1 + vertexCount] = characterInfo[i].vertex_TL.color;
			m_textInfo.meshInfo[materialReferenceIndex].colors32[2 + vertexCount] = characterInfo[i].vertex_TR.color;
			m_textInfo.meshInfo[materialReferenceIndex].colors32[3 + vertexCount] = characterInfo[i].vertex_BR.color;
			m_textInfo.meshInfo[materialReferenceIndex].vertexCount = vertexCount + 4;
			if (!colorGradientLine)
			{
				return;
			}
			TMP_MeshInfo tMP_MeshInfo = m_textInfo.meshInfo[materialReferenceIndex];
			float num = tMP_MeshInfo.vertices[0].x;
			float num2 = tMP_MeshInfo.vertices[0].x;
			float num3 = 0f;
			for (int num4 = (i + 1) * 4 - 1; num4 >= 1; num4--)
			{
				num3 = tMP_MeshInfo.vertices[num4].x;
				if (num3 > num2)
				{
					num2 = num3;
				}
				else if (num3 < num)
				{
					num = num3;
				}
			}
			float num5 = 0f;
			if (num2 - num > 0f)
			{
				num5 = 1f / (num2 - num);
			}
			for (int j = 0; j < vertexCount + 4; j++)
			{
				Color32 color = gradientColors.Evaluate((tMP_MeshInfo.vertices[j].x - num) * num5);
				m_textInfo.meshInfo[materialReferenceIndex].colors32[j] = color;
			}
		}
	}
}

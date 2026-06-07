using TMPro;

public static class LeadingZerosDimmer
{
	public static void ApplyDim(TMP_Text field, float alpha)
	{
		if (!field || !field.mesh)
		{
			return;
		}
		field.ForceMeshUpdate();
		TMP_TextInfo textInfo = field.textInfo;
		byte b = (byte)(alpha * 255f);
		bool flag = false;
		int num = -1;
		for (int i = 0; i < textInfo.characterCount; i++)
		{
			TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
			char character = tMP_CharacterInfo.character;
			bool flag2;
			if (!flag)
			{
				if (!char.IsDigit(character) || character == '0')
				{
					flag2 = ((character == '0' || character == ',') ? true : false);
				}
				else
				{
					flag = true;
					flag2 = false;
				}
			}
			else
			{
				flag2 = false;
			}
			if (tMP_CharacterInfo.isVisible)
			{
				if (flag2)
				{
					num = i;
				}
				int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				byte a = (flag2 ? b : byte.MaxValue);
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex].a = a;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 1].a = a;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 2].a = a;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 3].a = a;
			}
		}
		if (!flag && num >= 0)
		{
			TMP_CharacterInfo tMP_CharacterInfo2 = textInfo.characterInfo[num];
			int materialReferenceIndex2 = tMP_CharacterInfo2.materialReferenceIndex;
			int vertexIndex2 = tMP_CharacterInfo2.vertexIndex;
			textInfo.meshInfo[materialReferenceIndex2].colors32[vertexIndex2].a = byte.MaxValue;
			textInfo.meshInfo[materialReferenceIndex2].colors32[vertexIndex2 + 1].a = byte.MaxValue;
			textInfo.meshInfo[materialReferenceIndex2].colors32[vertexIndex2 + 2].a = byte.MaxValue;
			textInfo.meshInfo[materialReferenceIndex2].colors32[vertexIndex2 + 3].a = byte.MaxValue;
		}
		field.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
	}

	public static void ResetDim(TMP_Text field)
	{
		if (!field || !field.mesh)
		{
			return;
		}
		field.ForceMeshUpdate();
		TMP_TextInfo textInfo = field.textInfo;
		for (int i = 0; i < textInfo.characterCount; i++)
		{
			TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
			if (tMP_CharacterInfo.isVisible)
			{
				int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex].a = byte.MaxValue;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 1].a = byte.MaxValue;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 2].a = byte.MaxValue;
				textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex + 3].a = byte.MaxValue;
			}
		}
		field.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
	}
}

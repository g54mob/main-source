using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class TextScaleInEffect
{
	public delegate void TextInFinishedCallback(ulong key);

	[Serializable]
	private class ScaleClass
	{
		public int index;

		public int matIndex;

		public float currentTime;

		public Vector3 startingPosBotLeft;

		public Vector3 startingPosTopLeft;

		public Vector3 startingPosTopRight;

		public Vector3 startingPosBotRight;

		public Vector3 boxCenter;

		public ScaleClass(int index, int matIndex, float currentTime, Vector3 startingPosBotLeft, Vector3 startingPosTopLeft, Vector3 startingPosTopRight, Vector3 startingPosBotRight, Vector3 boxCenter)
		{
			this.index = index;
			this.matIndex = matIndex;
			this.currentTime = currentTime;
			this.startingPosBotLeft = startingPosBotLeft;
			this.startingPosTopLeft = startingPosTopLeft;
			this.startingPosTopRight = startingPosTopRight;
			this.startingPosBotRight = startingPosBotRight;
			this.boxCenter = boxCenter;
		}
	}

	private static float idleLead = 0.25f;

	private static ulong keyCount = 0uL;

	private static Dictionary<ulong, Coroutine> routineMap = new Dictionary<ulong, Coroutine>();

	private static Dictionary<ulong, TextInFinishedCallback> callbacks = new Dictionary<ulong, TextInFinishedCallback>();

	public static ulong ScaleInText(TextMeshProUGUI characterText, SimpleConversationManager conversationRef = null, TextInFinishedCallback callback = null, float scaleTime = 0.25f, float letterOffest = 0.015f, Inchworm.GetEaseValue GetEaseValue = null, bool scaleOut = false, float initialDelay = 0f)
	{
		return ScaleInText(characterText, null, conversationRef, callback, scaleTime, letterOffest, GetEaseValue, scaleOut, initialDelay);
	}

	public static ulong ScaleInText(TextMeshPro characterText, SimpleConversationManager conversationRef = null, TextInFinishedCallback callback = null, float scaleTime = 0.25f, float letterOffest = 0.015f, Inchworm.GetEaseValue GetEaseValue = null, bool scaleOut = false, float initialDelay = 0f)
	{
		return ScaleInText(null, characterText, conversationRef, callback, scaleTime, letterOffest, GetEaseValue, scaleOut, initialDelay);
	}

	private static ulong ScaleInText(TextMeshProUGUI characterTextUGUI = null, TextMeshPro characterText = null, SimpleConversationManager conversationRef = null, TextInFinishedCallback callback = null, float scaleTime = 0.25f, float letterOffest = 0.015f, Inchworm.GetEaseValue GetEaseValue = null, bool scaleOut = false, float initialDelay = 0f)
	{
		ulong num = keyCount;
		if (callback != null)
		{
			callbacks[num] = callback;
		}
		routineMap[num] = ObjectRegistration.GetRegistrationScript().StartCoroutine(CharacterScaleRoutine(num, characterTextUGUI, characterText, conversationRef, scaleTime, letterOffest, GetEaseValue, scaleOut, initialDelay));
		keyCount++;
		return num;
	}

	public static void RequestEffectEnd(ulong key, TextMeshProUGUI characterText, SimpleConversationManager conversationRef = null)
	{
		RequestEffectEnd(key, characterText, null, conversationRef);
	}

	public static void RequestEffectEnd(ulong key, TextMeshPro characterText, SimpleConversationManager conversationRef = null)
	{
		RequestEffectEnd(key, null, characterText, conversationRef);
	}

	private static void RequestEffectEnd(ulong key, TextMeshProUGUI characterTextUGUI = null, TextMeshPro characterText = null, SimpleConversationManager conversationRef = null)
	{
		OnTextInFinished(key, characterTextUGUI, characterText, conversationRef);
	}

	private static IEnumerator CharacterScaleRoutine(ulong key, TextMeshProUGUI characterTextUGUI = null, TextMeshPro characterText = null, SimpleConversationManager conversationRef = null, float scaleTime = 0.25f, float letterOffest = 0.015f, Inchworm.GetEaseValue GetEaseValue = null, bool scaleOut = false, float initialDelay = 0f)
	{
		if (GetEaseValue == null)
		{
			GetEaseValue = Inchworm.GetBouncePastValue;
		}
		Mesh characterMesh = null;
		TMP_TextInfo textInfo = null;
		if (characterText != null)
		{
			characterText.text = characterText.text;
			characterText.ForceMeshUpdate(ignoreActiveState: true);
			textInfo = characterText.textInfo;
			characterMesh = characterText.mesh;
		}
		else if (characterTextUGUI != null)
		{
			characterTextUGUI.text = characterTextUGUI.text;
			characterTextUGUI.ForceMeshUpdate(ignoreActiveState: true);
			textInfo = characterTextUGUI.textInfo;
			characterMesh = characterTextUGUI.mesh;
		}
		float maxLead = 0f;
		bool hasIdled = false;
		List<bool> submeshUseMapping = new List<bool>();
		List<Vector3[]> vertices = new List<Vector3[]>();
		for (int i = 0; i < textInfo.meshInfo.Length; i++)
		{
			submeshUseMapping.Add(item: false);
			vertices.Add(textInfo.meshInfo[i].vertices);
		}
		int realIndex = 0;
		List<ScaleClass> scalers = new List<ScaleClass>();
		for (int j = 0; j < textInfo.characterCount; j++)
		{
			if (j >= textInfo.characterInfo.Length)
			{
				OnTextInFinished(key, characterTextUGUI, characterText, conversationRef);
				yield return 0;
			}
			TMP_CharacterInfo info = textInfo.characterInfo[j];
			if (info.isVisible)
			{
				int vertexIndex = info.vertexIndex;
				if (vertexIndex >= vertices[info.materialReferenceIndex].Length)
				{
					OnTextInFinished(key, characterTextUGUI, characterText, conversationRef);
					yield return 0;
				}
				submeshUseMapping[info.materialReferenceIndex] = true;
				Vector3 position = info.vertex_BL.position;
				Vector3 position2 = info.vertex_TL.position;
				Vector3 position3 = info.vertex_TR.position;
				Vector3 position4 = info.vertex_BR.position;
				Vector3 lineCenter = MathUtil.GetLineCenter(position2, position3);
				Vector3 lineCenter2 = MathUtil.GetLineCenter(position, position4);
				Vector3 lineCenter3 = MathUtil.GetLineCenter(lineCenter, lineCenter2);
				if (!scaleOut)
				{
					vertices[info.materialReferenceIndex][vertexIndex] = lineCenter3;
					vertices[info.materialReferenceIndex][vertexIndex + 1] = lineCenter3;
					vertices[info.materialReferenceIndex][vertexIndex + 2] = lineCenter3;
					vertices[info.materialReferenceIndex][vertexIndex + 3] = lineCenter3;
				}
				else
				{
					vertices[info.materialReferenceIndex][vertexIndex] = position;
					vertices[info.materialReferenceIndex][vertexIndex + 1] = position2;
					vertices[info.materialReferenceIndex][vertexIndex + 2] = position3;
					vertices[info.materialReferenceIndex][vertexIndex + 3] = position4;
				}
				scalers.Add(new ScaleClass(vertexIndex, info.materialReferenceIndex, (float)(-realIndex) * letterOffest, position, position2, position3, position4, lineCenter3));
				realIndex++;
				maxLead = (float)realIndex * letterOffest;
			}
		}
		if (conversationRef != null && maxLead > idleLead)
		{
			conversationRef.RequestTalkAnimation();
		}
		for (int k = 0; k < textInfo.meshInfo.Length; k++)
		{
			if (!submeshUseMapping[k])
			{
				textInfo.meshInfo[k].ClearUnusedVertices();
				continue;
			}
			textInfo.meshInfo[k].mesh.vertices = vertices[k];
			if (characterTextUGUI != null)
			{
				characterTextUGUI.UpdateGeometry(textInfo.meshInfo[k].mesh, k);
			}
			else if (characterText != null)
			{
				characterText.UpdateGeometry(textInfo.meshInfo[k].mesh, k);
			}
		}
		if (initialDelay > 0f)
		{
			yield return new WaitForSecondsRealtime(initialDelay);
		}
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		while (scalers.Count > 0)
		{
			maxLead = 0f;
			for (int num = scalers.Count - 1; num >= 0; num--)
			{
				if (characterText != null && characterText.havePropertiesChanged)
				{
					characterText.ForceMeshUpdate();
				}
				if (characterTextUGUI != null && characterTextUGUI.havePropertiesChanged)
				{
					characterTextUGUI.ForceMeshUpdate();
				}
				scalers[num].currentTime += Time.unscaledDeltaTime;
				if (scalers[num].currentTime <= 0f)
				{
					maxLead = -1f;
				}
				else
				{
					if (scalers[num].currentTime > scaleTime)
					{
						scalers[num].currentTime = scaleTime;
					}
					int index = scalers[num].index;
					int matIndex = scalers[num].matIndex;
					float currentTime = scalers[num].currentTime;
					Vector3 boxCenter = scalers[num].boxCenter;
					Vector3 startingPosBotLeft = scalers[num].startingPosBotLeft;
					Vector3 startingPosTopLeft = scalers[num].startingPosTopLeft;
					Vector3 startingPosTopRight = scalers[num].startingPosTopRight;
					Vector3 startingPosBotRight = scalers[num].startingPosBotRight;
					if (!scaleOut)
					{
						vertices[matIndex][index] = new Vector3(GetEaseValue(currentTime, boxCenter.x, 0f - (startingPosBotLeft.x - boxCenter.x), scaleTime), GetEaseValue(currentTime, boxCenter.y, 0f - (startingPosBotLeft.y - boxCenter.y), scaleTime), 0f);
						vertices[matIndex][index + 1] = new Vector3(GetEaseValue(currentTime, boxCenter.x, 0f - (startingPosTopLeft.x - boxCenter.x), scaleTime), GetEaseValue(currentTime, boxCenter.y, 0f - (startingPosTopLeft.y - boxCenter.y), scaleTime), 0f);
						vertices[matIndex][index + 2] = new Vector3(GetEaseValue(currentTime, boxCenter.x, 0f - (startingPosTopRight.x - boxCenter.x), scaleTime), GetEaseValue(currentTime, boxCenter.y, 0f - (startingPosTopRight.y - boxCenter.y), scaleTime), 0f);
						vertices[matIndex][index + 3] = new Vector3(GetEaseValue(currentTime, boxCenter.x, 0f - (startingPosBotRight.x - boxCenter.x), scaleTime), GetEaseValue(currentTime, boxCenter.y, 0f - (startingPosBotRight.y - boxCenter.y), scaleTime), 0f);
					}
					else
					{
						vertices[matIndex][index] = new Vector3(GetEaseValue(currentTime, startingPosBotLeft.x, startingPosBotLeft.x, scaleTime), GetEaseValue(currentTime, startingPosBotLeft.y, startingPosBotLeft.y, scaleTime), 0f);
						vertices[matIndex][index + 1] = new Vector3(GetEaseValue(currentTime, startingPosTopLeft.x, startingPosTopLeft.x, scaleTime), GetEaseValue(currentTime, startingPosTopLeft.y, startingPosTopLeft.y, scaleTime), 0f);
						vertices[matIndex][index + 2] = new Vector3(GetEaseValue(currentTime, startingPosTopRight.x, startingPosTopRight.x, scaleTime), GetEaseValue(currentTime, startingPosTopRight.y, startingPosTopRight.y, scaleTime), 0f);
						vertices[matIndex][index + 3] = new Vector3(GetEaseValue(currentTime, startingPosBotRight.x, startingPosBotRight.x, scaleTime), GetEaseValue(currentTime, startingPosBotRight.y, startingPosBotRight.y, scaleTime), 0f);
					}
					if (scalers[num].currentTime >= scaleTime)
					{
						if (!scaleOut)
						{
							scalers.RemoveAt(num);
							vertices[matIndex][index] = startingPosBotLeft;
							vertices[matIndex][index + 1] = startingPosTopLeft;
							vertices[matIndex][index + 2] = startingPosTopRight;
							vertices[matIndex][index + 3] = startingPosBotRight;
						}
						else
						{
							scalers.RemoveAt(num);
							vertices[matIndex][index] = boxCenter;
							vertices[matIndex][index + 1] = boxCenter;
							vertices[matIndex][index + 2] = boxCenter;
							vertices[matIndex][index + 3] = boxCenter;
						}
					}
				}
			}
			if (conversationRef != null && maxLead == 0f && !hasIdled)
			{
				hasIdled = true;
				conversationRef.RequestIdleAnimation();
			}
			if ((characterText == null && characterTextUGUI == null) || characterMesh == null)
			{
				OnTextInFinished(key, characterTextUGUI, characterText, conversationRef);
				yield return 0;
			}
			for (int l = 0; l < textInfo.meshInfo.Length; l++)
			{
				textInfo.meshInfo[l].mesh.vertices = vertices[l];
				if (characterTextUGUI != null)
				{
					characterTextUGUI.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
				}
				else if (characterText != null)
				{
					characterText.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
				}
			}
			if (characterTextUGUI != null)
			{
				characterTextUGUI.canvasRenderer.SetMesh(characterMesh);
			}
			yield return frameWait;
		}
		routineMap[key] = null;
		routineMap.Remove(key);
		OnTextInFinished(key, characterTextUGUI, characterText, conversationRef, scaleOut);
	}

	private static void OnTextInFinished(ulong key, TextMeshProUGUI characterTextUGUI, TextMeshPro characterText, SimpleConversationManager conversationRef = null, bool scaleOut = false)
	{
		if (routineMap.ContainsKey(key))
		{
			if (routineMap[key] != null)
			{
				ObjectRegistration.GetRegistrationScript().StopCoroutine(routineMap[key]);
				routineMap[key] = null;
			}
			routineMap.Remove(key);
		}
		if (callbacks.ContainsKey(key))
		{
			callbacks[key](key);
			callbacks[key] = null;
			callbacks.Remove(key);
		}
		if (characterText != null && characterText.mesh != null && !scaleOut)
		{
			characterText.ForceMeshUpdate();
			characterText.canvasRenderer.SetMesh(characterText.mesh);
		}
		if (characterTextUGUI != null && characterTextUGUI.mesh != null && !scaleOut)
		{
			characterTextUGUI.ForceMeshUpdate();
			characterTextUGUI.canvasRenderer.SetMesh(characterTextUGUI.mesh);
		}
		if (conversationRef != null)
		{
			conversationRef.RequestIdleAnimation();
		}
	}
}

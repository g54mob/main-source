using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace LitMotion.Extensions
{
	internal sealed class TextMeshProMotionAnimator
	{
		internal struct CharInfo
		{
			public Vector3 position;

			public Vector3 scale;

			public Quaternion rotation;

			public Color color;
		}

		private static bool initialized;

		private static TextMeshProMotionAnimator rootNode;

		private static readonly Dictionary<TMP_Text, TextMeshProMotionAnimator> textToAnimator = new Dictionary<TMP_Text, TextMeshProMotionAnimator>();

		private static TextMeshProMotionAnimator[] animators = new TextMeshProMotionAnimator[8];

		private static int tail;

		private TMP_Text target;

		internal readonly Action updateAction;

		internal CharInfo[] charInfoArray;

		private bool isDirty;

		private TextMeshProMotionAnimator nextNode;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			if (!initialized)
			{
				PlayerLoopHelper.OnUpdate += UpdateAnimators;
				initialized = true;
			}
		}

		internal static TextMeshProMotionAnimator Get(TMP_Text text)
		{
			if (textToAnimator.TryGetValue(text, out var value))
			{
				value.Reset();
				return value;
			}
			value = rootNode ?? new TextMeshProMotionAnimator();
			rootNode = value.nextNode;
			value.nextNode = null;
			value.target = text;
			value.Reset();
			if (tail == animators.Length)
			{
				Array.Resize(ref animators, tail * 2);
			}
			animators[tail] = value;
			tail++;
			textToAnimator.Add(text, value);
			return value;
		}

		internal static void Return(TextMeshProMotionAnimator animator)
		{
			animator.nextNode = rootNode;
			rootNode = animator;
			textToAnimator.Remove(animator.target);
			animator.target = null;
		}

		private static void UpdateAnimators()
		{
			int num = tail - 1;
			for (int i = 0; i < animators.Length; i++)
			{
				TextMeshProMotionAnimator textMeshProMotionAnimator = animators[i];
				if (textMeshProMotionAnimator != null)
				{
					if (textMeshProMotionAnimator.TryUpdate())
					{
						continue;
					}
					Return(textMeshProMotionAnimator);
					animators[i] = null;
				}
				TextMeshProMotionAnimator textMeshProMotionAnimator2;
				while (true)
				{
					if (i < num)
					{
						textMeshProMotionAnimator2 = animators[num];
						if (textMeshProMotionAnimator2 != null)
						{
							if (textMeshProMotionAnimator2.TryUpdate())
							{
								break;
							}
							Return(textMeshProMotionAnimator2);
							animators[num] = null;
							num--;
						}
						else
						{
							num--;
						}
						continue;
					}
					tail = i;
					return;
				}
				animators[i] = textMeshProMotionAnimator2;
				animators[num] = null;
				num--;
			}
		}

		public TextMeshProMotionAnimator()
		{
			charInfoArray = new CharInfo[32];
			for (int i = 0; i < charInfoArray.Length; i++)
			{
				charInfoArray[i].color = Color.white;
				charInfoArray[i].rotation = Quaternion.identity;
				charInfoArray[i].scale = Vector3.one;
				charInfoArray[i].position = Vector3.zero;
			}
			updateAction = UpdateCore;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EnsureCapacity(int length)
		{
			int num = charInfoArray.Length;
			if (length <= num)
			{
				return;
			}
			Array.Resize(ref charInfoArray, length);
			if (length > num)
			{
				for (int i = num; i < length; i++)
				{
					charInfoArray[i].color = new Color(target.color.r, target.color.g, target.color.b, target.color.a);
					charInfoArray[i].rotation = Quaternion.identity;
					charInfoArray[i].scale = Vector3.one;
					charInfoArray[i].position = Vector3.zero;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update()
		{
			TryUpdate();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetDirty()
		{
			isDirty = true;
		}

		public void Reset()
		{
			for (int i = 0; i < charInfoArray.Length; i++)
			{
				charInfoArray[i].color = new Color(target.color.r, target.color.g, target.color.b, target.color.a);
				charInfoArray[i].rotation = Quaternion.identity;
				charInfoArray[i].scale = Vector3.one;
				charInfoArray[i].position = Vector3.zero;
			}
			isDirty = false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool TryUpdate()
		{
			if (target == null)
			{
				return false;
			}
			if (isDirty)
			{
				UpdateCore();
			}
			return true;
		}

		private void UpdateCore()
		{
			target.ForceMeshUpdate();
			TMP_TextInfo textInfo = target.textInfo;
			EnsureCapacity(textInfo.characterCount);
			for (int i = 0; i < textInfo.characterCount; i++)
			{
				ref TMP_CharacterInfo reference = ref textInfo.characterInfo[i];
				if (reference.isVisible)
				{
					int materialReferenceIndex = reference.materialReferenceIndex;
					int vertexIndex = reference.vertexIndex;
					ref Color32[] colors = ref textInfo.meshInfo[materialReferenceIndex].colors32;
					ref CharInfo reference2 = ref charInfoArray[i];
					Color color = reference2.color;
					for (int j = 0; j < 4; j++)
					{
						colors[vertexIndex + j] = color;
					}
					Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
					Vector3 vector = (vertices[vertexIndex] + vertices[vertexIndex + 2]) * 0.5f;
					Quaternion rotation = reference2.rotation;
					Vector3 scale = reference2.scale;
					Vector3 position = reference2.position;
					for (int k = 0; k < 4; k++)
					{
						Vector3 vector2 = vertices[vertexIndex + k] - vector;
						vertices[vertexIndex + k] = vector + rotation * new Vector3(vector2.x * scale.x, vector2.y * scale.y, vector2.z * scale.z) + position;
					}
				}
			}
			for (int l = 0; l < textInfo.materialCount; l++)
			{
				if (!(textInfo.meshInfo[l].mesh == null))
				{
					textInfo.meshInfo[l].mesh.colors32 = textInfo.meshInfo[l].colors32;
					textInfo.meshInfo[l].mesh.vertices = textInfo.meshInfo[l].vertices;
					target.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
				}
			}
		}
	}
}

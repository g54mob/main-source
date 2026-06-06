using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.Numbers;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorForUnity.UIToolkit;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

namespace Febucci.TextAnimatorForUnity
{
	[UxmlElement]
	public sealed class AnimatedLabel : AnimatedLabelBase
	{
		[Serializable]
		public new sealed class UxmlSerializedData : AnimatedLabelBase.UxmlSerializedData
		{
			[SerializeField]
			private bool EnableInEditMode;

			[SerializeField]
			private bool IsGeometryUpdated;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags EnableInEditMode_UxmlAttributeFlags;

			[SerializeField]
			[UxmlIgnore]
			[HideInInspector]
			private UxmlAttributeFlags IsGeometryUpdated_UxmlAttributeFlags;

			[RegisterUxmlCache]
			[Conditional("UNITY_EDITOR")]
			public new static void Register()
			{
				UxmlDescriptionCache.RegisterType(typeof(UxmlSerializedData), new UxmlAttributeNames[2]
				{
					new UxmlAttributeNames("EnableInEditMode", "enable-in-edit-mode", null),
					new UxmlAttributeNames("IsGeometryUpdated", "is-geometry-updated", null)
				});
			}

			public override object CreateInstance()
			{
				return new AnimatedLabel();
			}

			public override void Deserialize(object obj)
			{
				base.Deserialize(obj);
				AnimatedLabel animatedLabel = (AnimatedLabel)obj;
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(EnableInEditMode_UxmlAttributeFlags))
				{
					animatedLabel.EnableInEditMode = EnableInEditMode;
				}
				if (UnityEngine.UIElements.UxmlSerializedData.ShouldWriteAttributeValue(IsGeometryUpdated_UxmlAttributeFlags))
				{
					animatedLabel.IsGeometryUpdated = IsGeometryUpdated;
				}
			}
		}

		private MeshData[] sources = new MeshData[0];

		private MeshData[] currents = new MeshData[0];

		private int targetCharacters;

		private int currentCapacity;

		private bool shouldBeCopied = true;

		private const int targetHz = 60;

		private const int CAPACITY_GROWTH_FACTOR = 2;

		private IVisualElementScheduledItem animationJob;

		[UxmlAttribute]
		public bool EnableInEditMode;

		[UxmlAttribute]
		public bool IsGeometryUpdated = true;

		private bool onSyncedContext;

		private int latestPostProcessFrame = -1;

		private double latestPostProcessTime = -1.0;

		public AnimatedLabel()
		{
			shouldBeCopied = true;
			base.PostProcessTextVertices = (Action<GlyphsEnumerable>)Delegate.Combine(base.PostProcessTextVertices, new Action<GlyphsEnumerable>(OnPostProcessTextVertices));
			base.schedule.Execute(AnimateLabelSafe);
			animationJob = base.schedule.Execute(base.Animate).Every(16L);
			animationJob.Resume();
		}

		private void AnimateLabelSafe()
		{
			if (Application.isPlaying || EnableInEditMode)
			{
				MarkDirtyRepaint();
			}
		}

		public override string GetFullText()
		{
			return text;
		}

		public override int GetCharactersCount()
		{
			return base.animator.TextWithoutAnyTag.Length;
		}

		protected override void OnTextParsed()
		{
			base.OnTextParsed();
		}

		public override void CopyMeshFromSource(ref CharacterData[] characters, int charactersCount)
		{
			targetCharacters = charactersCount;
			shouldBeCopied = true;
			if (!onSyncedContext)
			{
				base.schedule.Execute(AnimateLabelSafe);
			}
		}

		private unsafe void CopyGlyphs(GlyphsEnumerable glyphs, bool hasAdvancedTextGeneration)
		{
			if (targetCharacters > currentCapacity)
			{
				int num = Math.Max(targetCharacters, currentCapacity * 2);
				int num2 = sources.Length;
				Array.Resize(ref sources, num);
				for (int i = num2; i < num; i++)
				{
					sources[i] = new MeshData(true);
				}
				currentCapacity = num;
			}
			int j = 0;
			int num3 = 0;
			float fontSize = base.resolvedStyle.fontSize;
			float num4 = 0f;
			float num5 = 0f;
			for (; j < targetCharacters && char.IsWhiteSpace(text[j]); j++)
			{
			}
			GlyphsEnumerator enumerator = glyphs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Glyph current = enumerator.Current;
				float y = current.vertices[0].position.y;
				SetupCharIndexUITkShenanigans(ref j, num3, hasAdvancedTextGeneration, y, num4, num5);
				if (j < targetCharacters)
				{
					ref MeshData reference = ref sources[j];
					Vertex* unsafeReadOnlyPtr = (Vertex*)current.vertices.GetUnsafeReadOnlyPtr();
					for (int k = 0; k < 4; k++)
					{
						ref Febucci.Numbers.Vector3 reference2 = ref reference.positions[k];
						reference2.X = unsafeReadOnlyPtr[k].position.x;
						reference2.Y = unsafeReadOnlyPtr[k].position.y;
						reference2.Z = unsafeReadOnlyPtr[k].position.z;
						ref Febucci.Numbers.Color32 reference3 = ref reference.colors[k];
						reference3.R = unsafeReadOnlyPtr[k].tint.r;
						reference3.G = unsafeReadOnlyPtr[k].tint.g;
						reference3.B = unsafeReadOnlyPtr[k].tint.b;
						reference3.A = unsafeReadOnlyPtr[k].tint.a;
					}
					ref CharacterData reference4 = ref base.animator.Characters[j];
					ref MeshData source = ref reference4.source;
					for (int l = 0; l < 4; l++)
					{
						ref Febucci.Numbers.Vector3 reference5 = ref source.positions[l];
						ref Febucci.Numbers.Vector3 reference6 = ref reference.positions[l];
						reference5.X = reference6.X;
						reference5.Y = reference6.Y;
						reference5.Z = reference6.Z;
						ref Febucci.Numbers.Color32 reference7 = ref source.colors[l];
						ref Febucci.Numbers.Color32 reference8 = ref reference.colors[l];
						reference7.R = reference8.R;
						reference7.G = reference8.G;
						reference7.B = reference8.B;
						reference7.A = reference8.A;
					}
					ref CharInfo info = ref reference4.info;
					info.pointSize = fontSize;
					info.character = base.animator.TextWithoutAnyTag[j];
					info.isRendered = true;
					reference4.info = info;
					if (j == 0)
					{
						num4 = current.vertices[0].position.y;
						num5 = UnityEngine.Mathf.Abs((current.vertices[1].position.y - num4) / 2f);
					}
					else if (!ShouldSkipCharacter(reference4.info.character) && UnityEngine.Mathf.Abs(current.vertices[0].position.y - num4) >= num5)
					{
						num4 = reference4.source.positions[0].Y;
					}
					j++;
					num3++;
					continue;
				}
				break;
			}
		}

		public override void PasteMeshToSource(CharacterData[] characters, int charactersCount)
		{
			if (shouldBeCopied)
			{
				return;
			}
			if (currents.Length < currentCapacity)
			{
				int num = currents.Length;
				Array.Resize(ref currents, currentCapacity);
				for (int i = num; i < currentCapacity; i++)
				{
					currents[i] = new MeshData(true);
				}
			}
			int num2 = Math.Min(charactersCount, currentCapacity);
			for (int j = 0; j < num2; j++)
			{
				ref MeshData reference = ref currents[j];
				ref MeshData current = ref characters[j].current;
				for (int k = 0; k < 4; k++)
				{
					ref Febucci.Numbers.Vector3 reference2 = ref reference.positions[k];
					ref Febucci.Numbers.Vector3 reference3 = ref current.positions[k];
					reference2.X = reference3.X;
					reference2.Y = reference3.Y;
					reference2.Z = reference3.Z;
					ref Febucci.Numbers.Color32 reference4 = ref reference.colors[k];
					ref Febucci.Numbers.Color32 reference5 = ref current.colors[k];
					reference4.R = reference5.R;
					reference4.G = reference5.G;
					reference4.B = reference5.B;
					reference4.A = reference5.A;
				}
			}
			if (!onSyncedContext)
			{
				base.schedule.Execute(base.MarkDirtyRepaint);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldSkipCharacter(char character)
		{
			return char.IsWhiteSpace(character);
		}

		private void SetupCharIndexUITkShenanigans(ref int charIndex, int glyphIndex, bool hasAdvancedTextGeneration, float currentY, float lastY, float heightThreshold)
		{
			if (!hasAdvancedTextGeneration)
			{
				while (charIndex < base.CharactersCountWithoutTAnimTags && ShouldSkipCharacter(text[charIndex]))
				{
					charIndex++;
				}
				return;
			}
			while (charIndex < targetCharacters && text[charIndex] == ' ')
			{
				int i;
				for (i = charIndex; i < targetCharacters && text[i] == ' '; i++)
				{
				}
				if (i < targetCharacters && text[i] == '\n')
				{
					charIndex = i;
					break;
				}
				if (glyphIndex <= 0 || !(UnityEngine.Mathf.Abs(currentY - lastY) >= heightThreshold))
				{
					break;
				}
				charIndex++;
			}
			bool flag = false;
			while (charIndex < targetCharacters && text[charIndex] == '\n')
			{
				charIndex++;
				flag = true;
			}
			if (flag)
			{
				while (charIndex < targetCharacters && text[charIndex] == ' ')
				{
					charIndex++;
				}
			}
		}

		private unsafe void PasteGlyphs(GlyphsEnumerable glyphs, bool hasAdvancedTextGeneration)
		{
			if (currents.Length == 0)
			{
				return;
			}
			int i = 0;
			int num = 0;
			float num2 = 0f;
			float heightThreshold = 0f;
			for (; i < currents.Length && i < base.CharactersCountWithoutTAnimTags && char.IsWhiteSpace(text[i]); i++)
			{
			}
			GlyphsEnumerator enumerator = glyphs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Glyph current = enumerator.Current;
				float y = current.vertices[0].position.y;
				if (num == 0)
				{
					num2 = y;
					heightThreshold = UnityEngine.Mathf.Abs((current.vertices[1].position.y - num2) / 2f);
				}
				SetupCharIndexUITkShenanigans(ref i, num, hasAdvancedTextGeneration, y, num2, heightThreshold);
				if (i < currents.Length)
				{
					ref MeshData reference = ref currents[i];
					num2 = y;
					NativeSlice<Vertex> vertices = current.vertices;
					int num3 = Math.Min(vertices.Length, 4);
					Vertex* unsafePtr = (Vertex*)vertices.GetUnsafePtr();
					for (int j = 0; j < num3; j++)
					{
						ref Febucci.Numbers.Vector3 reference2 = ref reference.positions[j];
						unsafePtr[j].position.x = reference2.X;
						unsafePtr[j].position.y = reference2.Y;
						unsafePtr[j].position.z = reference2.Z;
						ref Febucci.Numbers.Color32 reference3 = ref reference.colors[j];
						unsafePtr[j].tint.r = reference3.R;
						unsafePtr[j].tint.g = reference3.G;
						unsafePtr[j].tint.b = reference3.B;
						unsafePtr[j].tint.a = reference3.A;
					}
					i++;
					num++;
					continue;
				}
				break;
			}
		}

		private void OnPostProcessTextVertices(GlyphsEnumerable glyphs)
		{
			if (!base.isValid || !IsGeometryUpdated || (!Application.isPlaying && !EnableInEditMode) || string.IsNullOrEmpty(text) || targetCharacters == 0)
			{
				return;
			}
			int frameCount = Time.frameCount;
			if (frameCount != latestPostProcessFrame)
			{
				latestPostProcessFrame = frameCount;
				onSyncedContext = true;
				Animate();
				bool hasAdvancedTextGeneration = base.resolvedStyle.unityTextGenerator == TextGeneratorType.Advanced;
				if (shouldBeCopied)
				{
					CopyGlyphs(glyphs, hasAdvancedTextGeneration);
					shouldBeCopied = false;
				}
				PasteGlyphs(glyphs, hasAdvancedTextGeneration);
				onSyncedContext = false;
			}
		}

		public override void ForceMeshUpdate()
		{
			base.ForceMeshUpdate();
			shouldBeCopied = true;
		}

		public override bool HasChangedMeshRenderingSettings()
		{
			return true;
		}

		public void SetEffectsDatabase(IDatabaseProvider<IEffect> database)
		{
			if (base.animator != null)
			{
				base.animator.effectsDatabase = database;
			}
		}
	}
}

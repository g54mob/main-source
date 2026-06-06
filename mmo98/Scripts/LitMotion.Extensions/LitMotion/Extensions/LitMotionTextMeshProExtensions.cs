using System.Buffers;
using Cysharp.Text;
using TMPro;
using Unity.Collections;
using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionTextMeshProExtensions
	{
		public static MotionHandle BindToFontSize<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.fontSize = x;
			});
		}

		public static MotionHandle BindToMaxVisibleCharacters<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, TMP_Text target)
			{
				target.maxVisibleCharacters = x;
			});
		}

		public static MotionHandle BindToMaxVisibleLines<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, TMP_Text target)
			{
				target.maxVisibleLines = x;
			});
		}

		public static MotionHandle BindToCharacterSpacing<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.characterSpacing = x;
			});
		}

		public static MotionHandle BindToWordSpacing<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.wordSpacing = x;
			});
		}

		public static MotionHandle BindToParagraphSpacing<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.paragraphSpacing = x;
			});
		}

		public static MotionHandle BindToLineSpacing<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.lineSpacing = x;
			});
		}

		public static MotionHandle BindToMaxVisibleWords<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, TMP_Text target)
			{
				target.maxVisibleWords = x;
			});
		}

		public static MotionHandle BindToColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(Color x, TMP_Text target)
			{
				target.color = x;
			});
		}

		public static MotionHandle BindToColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				Color color = target.color;
				color.r = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				Color color = target.color;
				color.g = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				Color color = target.color;
				color.b = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				Color color = target.color;
				color.a = x;
				target.color = color;
			});
		}

		public unsafe static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString32Bytes, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString32Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString32Bytes x, TMP_Text target)
			{
				x.GetEnumerator();
				int utf16Length = 0;
				char[] array = ArrayPool<char>.Shared.Rent(64);
				fixed (char* utf16Buffer = array)
				{
					Unicode.Utf8ToUtf16(x.GetUnsafePtr(), x.Length, utf16Buffer, out utf16Length, x.Length * 2);
				}
				target.SetText(array, 0, utf16Length);
				ArrayPool<char>.Shared.Return(array);
			});
		}

		public unsafe static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString64Bytes, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString64Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString64Bytes x, TMP_Text target)
			{
				x.GetEnumerator();
				int utf16Length = 0;
				char[] array = ArrayPool<char>.Shared.Rent(128);
				fixed (char* utf16Buffer = array)
				{
					Unicode.Utf8ToUtf16(x.GetUnsafePtr(), x.Length, utf16Buffer, out utf16Length, x.Length * 2);
				}
				target.SetText(array, 0, utf16Length);
				ArrayPool<char>.Shared.Return(array);
			});
		}

		public unsafe static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString128Bytes, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString128Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString128Bytes x, TMP_Text target)
			{
				x.GetEnumerator();
				int utf16Length = 0;
				char[] array = ArrayPool<char>.Shared.Rent(256);
				fixed (char* utf16Buffer = array)
				{
					Unicode.Utf8ToUtf16(x.GetUnsafePtr(), x.Length, utf16Buffer, out utf16Length, x.Length * 2);
				}
				target.SetText(array, 0, utf16Length);
				ArrayPool<char>.Shared.Return(array);
			});
		}

		public unsafe static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString512Bytes, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString512Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString512Bytes x, TMP_Text target)
			{
				x.GetEnumerator();
				int utf16Length = 0;
				char[] array = ArrayPool<char>.Shared.Rent(1024);
				fixed (char* utf16Buffer = array)
				{
					Unicode.Utf8ToUtf16(x.GetUnsafePtr(), x.Length, utf16Buffer, out utf16Length, x.Length * 2);
				}
				target.SetText(array, 0, utf16Length);
				ArrayPool<char>.Shared.Return(array);
			});
		}

		public unsafe static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString4096Bytes, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString4096Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString4096Bytes x, TMP_Text target)
			{
				x.GetEnumerator();
				int utf16Length = 0;
				char[] array = ArrayPool<char>.Shared.Rent(8192);
				fixed (char* utf16Buffer = array)
				{
					Unicode.Utf8ToUtf16(x.GetUnsafePtr(), x.Length, utf16Buffer, out utf16Length, x.Length * 2);
				}
				target.SetText(array, 0, utf16Length);
				ArrayPool<char>.Shared.Return(array);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, TMP_Text target)
			{
				char[] buffer = ArrayPool<char>.Shared.Rent(128);
				int bufferOffset = 0;
				Utf16StringHelper.WriteInt32(ref buffer, ref bufferOffset, x);
				target.SetText(buffer, 0, bufferOffset);
				ArrayPool<char>.Shared.Return(buffer);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TMP_Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(int x, TMP_Text text2, string format2)
			{
				text2.SetTextFormat(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(long x, TMP_Text target)
			{
				char[] buffer = ArrayPool<char>.Shared.Rent(128);
				int bufferOffset = 0;
				Utf16StringHelper.WriteInt64(ref buffer, ref bufferOffset, x);
				target.SetText(buffer, 0, bufferOffset);
				ArrayPool<char>.Shared.Return(buffer);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, TMP_Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(long x, TMP_Text text2, string format2)
			{
				text2.SetTextFormat(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, TMP_Text target)
			{
				target.SetTextFormat("{0}", x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(float x, TMP_Text text2, string format2)
			{
				text2.SetTextFormat(format2, x);
			});
		}

		public static MotionHandle BindToTMPCharColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(Color x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].color = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].color.r = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].color.g = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].color.b = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].color.a = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharPosition<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(Vector3 x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].position = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].position.x = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].position.y = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharPositionZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].position.z = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharRotation<TOptions, TAdapter>(this MotionBuilder<Quaternion, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Quaternion, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(Quaternion x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].rotation = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharEulerAngles<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(Vector3 x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].rotation = Quaternion.Euler(x);
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharEulerAnglesX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				Vector3 eulerAngles = animator.charInfoArray[box.Value].rotation.eulerAngles;
				eulerAngles.x = x;
				animator.charInfoArray[box.Value].rotation = Quaternion.Euler(eulerAngles);
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharEulerAnglesY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				Vector3 eulerAngles = animator.charInfoArray[box.Value].rotation.eulerAngles;
				eulerAngles.y = x;
				animator.charInfoArray[box.Value].rotation = Quaternion.Euler(eulerAngles);
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharEulerAnglesZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				Vector3 eulerAngles = animator.charInfoArray[box.Value].rotation.eulerAngles;
				eulerAngles.z = x;
				animator.charInfoArray[box.Value].rotation = Quaternion.Euler(eulerAngles);
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharScale<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(Vector3 x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].scale = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharScaleX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].scale.x = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharScaleY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].scale.y = x;
				animator.SetDirty();
			});
		}

		public static MotionHandle BindToTMPCharScaleZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TMP_Text text, int charIndex) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			TextMeshProMotionAnimator textMeshProMotionAnimator = TextMeshProMotionAnimator.Get(text);
			textMeshProMotionAnimator.EnsureCapacity(charIndex + 1);
			return builder.WithOnComplete(textMeshProMotionAnimator.updateAction).Bind(textMeshProMotionAnimator, Box.Create(charIndex), delegate(float x, TextMeshProMotionAnimator animator, Box<int> box)
			{
				animator.charInfoArray[box.Value].scale.z = x;
				animator.SetDirty();
			});
		}
	}
}

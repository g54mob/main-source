using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIEffects;

[Serializable]
public class ParameterTexture
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Canvas.WillRenderCanvases _003C_003E9__16_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CInitialize_003Eb__16_0()
		{
			//IL_0025: Expected O, but got I4
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			List<Action> updates = ParameterTexture.updates;
			bool flag = updates._size <= 0;
			object obj = 0;
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<Action> updates2 = ParameterTexture.updates;
				if ((nint)obj >= updates2._size)
				{
					break;
				}
				Action[] items = updates2._items;
				Action action = items[obj];
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				obj++;
				if ((nint)obj < updates._size)
				{
					continue;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
	}

	private Texture2D _texture;

	private bool _needUpload;

	private int _propertyId;

	private readonly string _propertyName;

	private readonly int _channels;

	private readonly int _instanceLimit;

	private readonly byte[] _data;

	private readonly Stack<int> _stack;

	private static List<Action> updates;

	public ParameterTexture(int channels, int instanceLimit, string propertyName)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected I4, but got Unknown
		//IL_0074: Expected O, but got I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected I4, but got Unknown
		//IL_00da: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_0172: Expected O, but got I
		//IL_01d0: Expected O, but got I
		//IL_021b: Expected O, but got I4
		_propertyName = propertyName;
		object obj = channels - 1;
		object obj2 = obj >> 31;
		object obj3 = obj2 & 3;
		object obj4 = obj + obj3;
		object obj5 = obj4 >> 2;
		object obj6 = obj5 * 4;
		int num = obj6 + 4;
		int num2 = default(int);
		object obj7 = num2 - 1;
		_channels = num;
		object obj8 = obj7 >> 31;
		object obj9 = obj7 - obj8;
		object obj10 = obj9 >> 1;
		object obj11 = obj10 * 2;
		object obj12 = (_instanceLimit = obj11 + 2) * num;
		byte[] data = new byte[obj12];
		_data = data;
		Stack<int> stack = new Stack<int>(_instanceLimit);
		_stack = stack;
		object obj13 = _instanceLimit + 1;
		bool flag = (nint)obj13 <= 1;
		int num3 = 1;
		if (flag)
		{
			return;
		}
		object obj16;
		do
		{
			Stack<int> stack2 = _stack;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v21 (System.Collections.Generic.Stack`1<System.Int32>)+10]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v21 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rdx_v12+18]");
			if (num4 >= 0)
			{
				stack2.PushWithResize(num3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v21 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
				object obj15 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v21 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
			}
			num3++;
			obj16 = _instanceLimit + 1;
		}
		while (num3 < (nint)obj16);
	}

	public void Register(IParameterTexture target)
	{
		Initialize();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			Stack<int> stack = _stack;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v7 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FC120");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
			}
		}
	}

	public void Unregister(IParameterTexture target)
	{
		//IL_0058: Expected O, but got I
		//IL_00b6: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if ((nint)obj > 0)
		{
			Stack<int> stack = _stack;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v5 (System.Collections.Generic.Stack`1<System.Int32>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v5 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v6+18]");
			if (num >= 0)
			{
				int item = default(int);
				stack.PushWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v5 (System.Collections.Generic.Stack`1<System.Int32>)+18]");
				object obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v5 (System.Collections.Generic.Stack`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
		}
	}

	public void SetData(IParameterTexture target, int channelId, byte value)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = obj2 - 1;
		object obj3 = obj * _channels;
		object obj4 = channelId + obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj5 = default(object);
		if ((nint)obj5 > 0)
		{
			byte[] data = _data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdi_v4+20+v60 @ rcx_v7 (System.Byte[])]");
			if ((nint)0 != (int)value)
			{
				_needUpload = true;
			}
		}
	}

	public void SetData(IParameterTexture target, int channelId, float value)
	{
		//IL_0009: Invalid comparison between I4 and F4
		if (0f > value || value > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm3\"");
		byte value2 = default(byte);
		SetData(target, channelId, value2);
	}

	public void RegisterMaterial(Material mat)
	{
		if (_propertyId == 0)
		{
			int propertyId = Shader.PropertyToID(_propertyName);
			_propertyId = propertyId;
		}
		if ((object)mat != null && ((UnityEngine.Object)mat).m_CachedPtr != (IntPtr)0)
		{
			mat.SetTextureImpl(_propertyId, (Texture)_texture);
		}
	}

	public float GetNormalizedIndex(IParameterTexture target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		float num = (float)obj - 0.5f;
		return num / (float)_instanceLimit;
	}

	private void Initialize()
	{
		//IL_0182: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_01f1: Expected I4, but got O
		if (updates == null)
		{
			List<Action> list = new List<Action>();
			updates = list;
			Canvas.WillRenderCanvases value = _003C_003Ec._003C_003E9__16_0;
			if (_003C_003Ec._003C_003E9__16_0 == null)
			{
				value = (_003C_003Ec._003C_003E9__16_0 = delegate
				{
					//IL_0025: Expected O, but got I4
					//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a5: Expected O, but got Unknown
					List<Action> list2 = updates;
					bool flag = list2._size <= 0;
					object obj3 = 0;
					if (flag)
					{
						return;
					}
					while (true)
					{
						List<Action> list3 = updates;
						if ((nint)obj3 >= list3._size)
						{
							break;
						}
						Action[] items = list3._items;
						Action action2 = items[obj3];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						obj3++;
						if ((nint)obj3 >= list2._size)
						{
							return;
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new NullReferenceException();
				});
			}
			Canvas.willRenderCanvases += value;
		}
		Texture2D texture = _texture;
		if ((object)_texture == null || ((UnityEngine.Object)texture).m_CachedPtr == (IntPtr)0)
		{
			object obj = QualitySettings.activeColorSpace;
			int mipCount = default(int);
			bool linear = default(bool);
			IntPtr nativeTex = default(IntPtr);
			bool createUninitialized = default(bool);
			int width = default(int);
			Texture2D texture2 = new Texture2D(width, _instanceLimit, TextureFormat.RGBA32, mipCount, linear, nativeTex, createUninitialized, (MipmapLimitDescriptor)1);
			int num = _channels >> 31;
			int num2 = num & 3;
			object obj2 = _channels + num2;
			width = obj2 >> 2;
			_texture = texture2;
			_texture.filterMode = FilterMode.Point;
			_texture.wrapMode = TextureWrapMode.Clamp;
			Action action = UpdateParameterTexture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
			_needUpload = true;
		}
	}

	private void UpdateParameterTexture()
	{
		if (_needUpload)
		{
			Texture2D texture = _texture;
			if ((object)_texture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
			{
				_needUpload = false;
				_texture.LoadRawTextureData(_data);
				_texture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
		}
	}
}

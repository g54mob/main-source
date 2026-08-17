using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public struct ColorId : ISerializationCallbackReceiver
{
	private Color m_color;

	private byte[] SerializedGuid;

	private Guid m_id;

	public unsafe Guid Id
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Guid guid = default(Guid);
			((Guid*)(nint)guid)->_a = (int)m_id;
			return guid;
		}
		set
		{
			//IL_000f: Expected O, but got I4
			m_id = (Guid)value._a;
		}
	}

	public unsafe Color Color
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)m_color;
			return color;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			m_color = (Color)value.r;
		}
	}

	public unsafe ColorId(Color color)
	{
		//IL_000b: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0040: Expected O, but got F4
		m_color = (Color)0;
		SerializedGuid = null;
		_ = 0;
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		m_id = (Guid)0;
		m_color = (Color)color.r;
	}

	public ColorId(Guid id, Color color)
	{
		//IL_0016: Expected O, but got I4
		//IL_0025: Expected O, but got F4
		SerializedGuid = null;
		m_id = (Guid)id._a;
		m_color = (Color)color.r;
	}

	public void OnBeforeSerialize()
	{
		byte[] serializedGuid;
		if ((object)m_id == (object)Guid.Empty)
		{
			object obj = (object)m_id >> 32;
			object obj2 = (object)Guid.Empty >> 32;
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if ((object)m_id == (object)Guid.Empty)
				{
					object obj3 = (object)m_id >> 32;
					object obj4 = (object)Guid.Empty >> 32;
					if (obj3 == obj4)
					{
						serializedGuid = null;
						goto IL_00d3;
					}
				}
			}
		}
		Guid guid = default(Guid);
		serializedGuid = guid.ToByteArray();
		goto IL_00d3;
		IL_00d3:
		SerializedGuid = serializedGuid;
	}

	public unsafe void OnAfterDeserialize()
	{
		//IL_006e: Expected O, but got Ref
		byte[] serializedGuid = SerializedGuid;
		if (SerializedGuid == null || serializedGuid.Length != 16)
		{
			m_id = Guid.Empty;
			return;
		}
		object obj = default(object);
		Guid id = new Guid((ReadOnlySpan<byte>)(&obj));
		m_id = id;
	}

	public void SetId(Guid newGuid)
	{
		//IL_000f: Expected O, but got I4
		m_id = (Guid)newGuid._a;
	}

	public void SetColor(Color color)
	{
		//IL_000f: Expected O, but got F4
		m_color = (Color)color.r;
	}
}

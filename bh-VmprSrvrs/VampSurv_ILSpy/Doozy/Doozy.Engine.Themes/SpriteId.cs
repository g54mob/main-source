using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public struct SpriteId : ISerializationCallbackReceiver
{
	private Sprite m_sprite;

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

	public Sprite Sprite
	{
		get
		{
			return m_sprite;
		}
		set
		{
			m_sprite = value;
		}
	}

	public unsafe SpriteId(Sprite sprite)
	{
		//IL_0012: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		m_sprite = null;
		m_id = (Guid)0;
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		m_sprite = sprite;
		m_id = (Guid)0;
	}

	public SpriteId(Guid id, Sprite sprite)
	{
		//IL_0020: Expected O, but got I4
		SerializedGuid = null;
		m_sprite = sprite;
		m_id = (Guid)id._a;
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

	public void SetSprite(Sprite sprite)
	{
		m_sprite = sprite;
	}
}

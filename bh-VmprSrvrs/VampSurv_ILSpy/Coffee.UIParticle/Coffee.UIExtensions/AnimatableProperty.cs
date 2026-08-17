using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Coffee.UIExtensions;

[Serializable]
public class AnimatableProperty : ISerializationCallbackReceiver
{
	public enum ShaderPropertyType
	{
		Color,
		Vector,
		Float,
		Range,
		Texture
	}

	private string m_Name;

	private ShaderPropertyType m_Type;

	private int _003Cid_003Ek__BackingField;

	public int id
	{
		get
		{
			return _003Cid_003Ek__BackingField;
		}
		private set
		{
			_003Cid_003Ek__BackingField = value;
		}
	}

	public ShaderPropertyType type => m_Type;

	public unsafe void UpdateMaterialProperties(Material material, MaterialPropertyBlock mpb)
	{
		//IL_0060: Expected O, but got I4
		//IL_03b4: Invalid comparison between F4 and O
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_01c6: Expected O, but got Ref
		//IL_030a: Invalid comparison between F4 and O
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_018b: Expected O, but got Ref
		//IL_024d: Expected O, but got F4
		//IL_0256: Invalid comparison between F4 and I4
		//IL_03c3->IL0119: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0319->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0190->IL0119: Incompatible stack heights: 1 vs 0
		//IL_026f->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0155->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0230->IL0119: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL0119: Incompatible stack heights: 1 vs 0
		//IL_0119->IL0119: Incompatible stack heights: 1 vs 0
		if (!material.HasProperty(_003Cid_003Ek__BackingField))
		{
			return;
		}
		bool flag = m_Type == ShaderPropertyType.Color;
		Color ret;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj9 = default(object);
		object obj15 = default(object);
		if (!flag)
		{
			object obj = m_Type - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 == 1)
						{
							bool flag2 = mpb.m_Ptr == (IntPtr)0;
							IntPtr textureImpl_Injected = MaterialPropertyBlock.GetTextureImpl_Injected(mpb.m_Ptr, _003Cid_003Ek__BackingField);
							Texture texture = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Texture>(textureImpl_Injected);
							if ((object)texture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
							{
								material.SetTextureImpl(_003Cid_003Ek__BackingField, texture);
							}
						}
						return;
					}
				}
				bool flag3 = mpb.m_Ptr == (IntPtr)0;
				object obj4 = MaterialPropertyBlock.GetFloatImpl_Injected(mpb.m_Ptr, _003Cid_003Ek__BackingField);
				float num = default(float);
				bool flag4 = num == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000181B96128h\"");
				if (!flag4)
				{
					material.SetFloatImpl(_003Cid_003Ek__BackingField, num);
				}
			}
			else
			{
				bool flag5 = mpb.m_Ptr == (IntPtr)0;
				MaterialPropertyBlock.GetVectorImpl_Injected(mpb.m_Ptr, _003Cid_003Ek__BackingField, out *(Vector4*)(&ret));
				object obj5 = obj6 - obj7;
				object obj8 = obj9 - obj7;
				object obj10 = obj5 * obj5;
				object obj11 = ret * ret;
				object obj12 = obj8 * obj8;
				object obj13 = obj10 + obj11;
				object obj14 = obj15 * obj15;
				object obj16 = obj13 + obj12;
				object obj17 = obj16 + obj14;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17))
				{
					material.SetVector(_003Cid_003Ek__BackingField, (Vector4)(&ret));
				}
			}
		}
		else
		{
			bool flag6 = mpb.m_Ptr == (IntPtr)0;
			MaterialPropertyBlock.GetColorImpl_Injected(mpb.m_Ptr, _003Cid_003Ek__BackingField, out ret);
			object obj18 = obj6 - obj7;
			object obj19 = obj9 - obj7;
			object obj20 = obj18 * obj18;
			object obj21 = ret * ret;
			object obj22 = obj19 * obj19;
			object obj23 = obj20 + obj21;
			object obj24 = obj15 * obj15;
			object obj25 = obj23 + obj22;
			object obj26 = obj25 + obj24;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj26))
			{
				material.SetColor(_003Cid_003Ek__BackingField, (Color)(&ret));
			}
		}
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		int num = Shader.PropertyToID(m_Name);
		_003Cid_003Ek__BackingField = num;
	}

	public AnimatableProperty()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189979005]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		m_Name = "";
		m_Type = ShaderPropertyType.Vector;
	}
}

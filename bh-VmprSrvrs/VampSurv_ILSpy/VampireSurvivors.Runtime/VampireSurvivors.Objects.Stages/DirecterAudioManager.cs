using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Stages;

public class DirecterAudioManager : MonoBehaviour
{
	public Dictionary<BgmType, AudioClip> _clips;

	public unsafe void GetAudioClips()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0508: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0564: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_05b4: Expected O, but got I
		//IL_029c: Expected O, but got I
		//IL_05f0: Expected O, but got I
		//IL_030f: Expected O, but got I
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_032b: Expected O, but got Ref
		//IL_041a: Expected O, but got Ref
		List<BgmType> list = new List<BgmType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)38);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v8+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)39);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 39;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v10+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v12+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)41);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 41;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v14+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)42);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 42;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)43);
			list2 = (List<System.Int32Enum>)(object)list;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj11 = (nint)0 + (nint)1;
			_ = 43;
		}
		object obj12 = default(object);
		object obj13 = default(object);
		object obj15 = default(object);
		IntPtr intPtr = default(IntPtr);
		object obj18 = default(object);
		IntPtr intPtr2 = default(IntPtr);
		object value = default(object);
		while (true)
		{
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-38_v4+1C]");
				if (obj13 != null)
				{
					break;
				}
				object obj14 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-38_v4+18]");
				if ((nint)obj14 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-38_v4+10]");
				object obj16 = 0;
				object obj17 = obj15 + 1;
				string text = ((Enum)(&intPtr)).ToString();
				MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(text);
				bool flag = playlist == null;
				obj15 = obj17;
				list2 = (List<System.Int32Enum>)(object)text;
				if (flag)
				{
					continue;
				}
				list2 = (List<System.Int32Enum>)(object)playlist.MusicSettings;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				bool flag2 = (nint)0 <= (nint)0;
				obj15 = obj17;
				if (flag2)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag3 = obj18 == null;
				obj15 = obj17;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ rax_v45+38]");
					bool flag4 = (nint)0 == 0;
					obj15 = obj17;
					if (!flag4)
					{
						string text2 = ((Enum)(&intPtr2)).ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F948D0");
						Dictionary<BgmType, AudioClip> clips = _clips;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v884 @ rdx_v24+20+v1000 @ rcx_v30*4]");
						bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)clips).TryInsert((System.Int32Enum)0, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						obj15 = obj17;
						list2 = (List<System.Int32Enum>)(object)_clips;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag6 = obj12 == null;
		list2 = (List<System.Int32Enum>)0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-38_v4+1C]");
			if (obj13 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
	}

	public unsafe AudioSource Add(BgmType phase)
	{
		//IL_00c4: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, text);
		if ((object)gameObject != null)
		{
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			if (_clips != null)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)_clips).get_Item((System.Int32Enum)phase);
				if ((object)audioSource != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1863D0710");
					audioSource.volume = 1f;
					return audioSource;
				}
			}
		}
		return (AudioSource)(object)new NullReferenceException();
	}

	public DirecterAudioManager()
	{
		Dictionary<BgmType, AudioClip> clips = new Dictionary<BgmType, AudioClip>();
		_clips = clips;
	}
}

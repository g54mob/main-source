using System;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Soundy;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.UI.Nodes;

public class SoundNode : Node
{
	public enum SoundActions
	{
		Play,
		Stop,
		Pause,
		Unpause,
		Mute,
		Unmute
	}

	public SoundyData SoundData;

	public SoundActions SoundAction;

	public unsafe bool HasSound
	{
		get
		{
			//IL_02d2: Expected I4, but got O
			//IL_003a: Expected O, but got I4
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected Ref, but got Unknown
			//IL_020e: Expected I8, but got I4
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected Ref, but got Unknown
			SoundyData soundData = SoundData;
			if (SoundData != null)
			{
				bool flag = soundData.SoundSource == SoundSource.Soundy;
				if (!flag)
				{
					object obj = soundData.SoundSource - 1;
					if (!flag)
					{
						if ((nint)obj == 1)
						{
							SoundyData soundData2 = SoundData;
							string soundName = soundData2.SoundName;
							if (soundData2.SoundName != null && soundName._stringLength > 0)
							{
								goto IL_00c6;
							}
						}
					}
					else
					{
						SoundyData soundData3 = SoundData;
						AudioClip audioClip = soundData3.AudioClip;
						if ((object)soundData3.AudioClip != null)
						{
							bool flag2 = ((UnityEngine.Object)audioClip).m_CachedPtr == (IntPtr)0;
							return !flag2;
						}
					}
				}
				else
				{
					SoundyData soundData4 = SoundData;
					if (SoundData == null)
					{
						goto IL_02c4;
					}
					string soundName2 = soundData4.SoundName;
					object obj2 = "No Sound";
					if ((object)soundData4.SoundName != "No Sound")
					{
						if (soundData4.SoundName != null && "No Sound" != null)
						{
							int stringLength = soundName2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v3+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("No Sound" + 20);
								ulong length = (ulong)(soundName2._stringLength + soundName2._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref *(byte*)(soundData4.SoundName + 20), ref second, length))
								{
									goto IL_02be;
								}
							}
						}
						SoundyData soundData5 = SoundData;
						if (SoundData == null)
						{
							goto IL_02c4;
						}
						string soundName3 = soundData5.SoundName;
						if (soundData5.SoundName != null && soundName3._stringLength > 0)
						{
							goto IL_00c6;
						}
					}
				}
				goto IL_02be;
			}
			goto IL_02c4;
			IL_00c6:
			return true;
			IL_02c4:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02be:
			return false;
		}
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.SoundNodeName;
		base.m_allowDuplicateNodeName = true;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
	}

	public override void CopyNode(Node original)
	{
		//IL_0174: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_00a5: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_01b0: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_010d: Expected O, but got I
		//IL_01ef: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(SoundNode);
		if ((object)original != null)
		{
			nint num2 = (nint)original;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.SoundNode>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v4 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.SoundNode>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v4 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v11+FFFFFFF8+v53 @ rax_v8*8]");
				if (0 == (nint)typeof(SoundNode))
				{
					SoundyData soundyData = new SoundyData();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v12+28]");
					soundyData.AudioClip = (AudioClip)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v15+18]");
					soundyData.DatabaseName = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v18+30]");
					soundyData.OutputAudioMixerGroup = (AudioMixerGroup)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v21+20]");
					soundyData.SoundName = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v24+10]");
					soundyData.SoundSource = SoundSource.Soundy;
					SoundData = soundyData;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
					SoundAction = SoundActions.Play;
					return;
				}
			}
			throw new InvalidCastException();
		}
		SoundyData soundyData2 = new SoundyData();
		throw new NullReferenceException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		//IL_006c: Expected O, but got I8
		//IL_0086: Expected O, but got I8
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			SoundActions soundAction = SoundAction;
			if (SoundAction > SoundActions.Unmute)
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v4+2BD6B80+v158 @ rax_v9 (Doozy.Engine.UI.Nodes.SoundNode+SoundActions)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v161 @ rcx_v15 (should have been resolved before IL gen)");
		}
	}

	public override void CheckForErrors()
	{
	}
}

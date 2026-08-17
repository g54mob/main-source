using System;
using Coherence.Connection;
using Coherence.Toolkit.ReplicationServer;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors;
using VampireSurvivors.UI;
using Zenject;

namespace Coherence.Toolkit;

public class StageManagerInstantiator : INetworkObjectInstantiator
{
	public void OnUniqueObjectReplaced(ICoherenceSync instance)
	{
	}

	public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
	{
	}

	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_016a: Expected I, but got O
		//IL_0182: Expected O, but got I
		//IL_0202: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_0068: Expected I, but got O
		//IL_0080: Expected O, but got I
		//IL_0421: Expected O, but got I4
		//IL_01be: Expected O, but got I
		//IL_0112: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_00bc: Expected O, but got I
		//IL_01f4: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0451: Expected O, but got Ref
		//IL_026b: Expected O, but got Ref
		//IL_0309: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_0380: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2 - 72;
		bool flag = (object)spawnInfo.rotation == null;
		ConnectionType? connectionType = spawnInfo.connectionType;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [spawnInfo @ rdx (Coherence.Toolkit.SpawnInfo)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [spawnInfo @ rdx (Coherence.Toolkit.SpawnInfo)+10]");
		_ = 0;
		object obj8;
		ConnectionType? connectionType2;
		if (!flag)
		{
			if ((object)spawnInfo.connectionType == null)
			{
				connectionType2 = (ConnectionType?)(object)0;
			}
			else
			{
				nint num = (nint)typeof(MonoBehaviour);
				object obj3 = connectionType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v13 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r9_v2+130]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v13 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
				if (num2 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r9_v2+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v53+FFFFFFF8+v90 @ rax_v50*8]");
					if (0 == (nint)typeof(MonoBehaviour))
					{
						connectionType2 = (ConnectionType?)(object)0;
						connectionType2 = spawnInfo.connectionType;
						goto IL_0219;
					}
				}
				connectionType2 = (ConnectionType?)(object)0;
			}
		}
		else
		{
			if ((object)spawnInfo.connectionType != null)
			{
				nint num3 = (nint)typeof(MonoBehaviour);
				object obj3 = connectionType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v12 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r9_v2+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v12 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r9_v2+C8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v48+FFFFFFF8+v106 @ rax_v44*8]");
					if (0 == (nint)typeof(MonoBehaviour))
					{
						obj8 = 1;
						goto IL_0409;
					}
				}
				obj8 = 0;
				goto IL_0409;
			}
			connectionType2 = (ConnectionType?)(object)0;
		}
		goto IL_0219;
		IL_0219:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,4\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496A80");
		RoomSelectionPage roomSelectionPage = RoomSelectionPage._003CInstance_003Ek__BackingField;
		bool flag2 = (object)RoomSelectionPage._003CInstance_003Ek__BackingField == null;
		object obj10 = default(object);
		object obj9 = (object)(&obj10);
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)roomSelectionPage).m_CachedPtr == (IntPtr)0;
			obj9 = (object)(&obj10);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8E0");
				object obj11 = default(object);
				Component component = default(Component);
				if (obj11 != null && (object)component != null)
				{
					GameObject gameObject = component.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v17+1A0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v17+1A0]");
						((DiContainer)0).InjectGameObject(gameObject);
						OnlineStageManager component2 = component.GetComponent<OnlineStageManager>();
						OnlineStageManager component3 = component.GetComponent<OnlineStageManager>();
						if ((object)component3 != null && (object)component2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v23 (VampireSurvivors.OnlineStageManager)+1D0]");
							component2._replicationServer = (IReplicationServer)0;
							obj9 = 0;
							goto IL_0385;
						}
					}
				}
				return (ICoherenceSync)new NullReferenceException();
			}
		}
		goto IL_0385;
		IL_0385:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		ICoherenceSync result = default(ICoherenceSync);
		return result;
		IL_0409:
		bool flag4 = obj8 == null;
		connectionType2 = (ConnectionType?)(object)0;
		if (!flag4)
		{
			connectionType2 = spawnInfo.connectionType;
		}
		goto IL_0219;
	}

	public void Destroy(ICoherenceSync obj)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		nint num = (nint)typeof(MonoBehaviour);
		nint num2 = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v21+FFFFFFF8+v49 @ rax_v4*8]");
			if (0 == (nint)typeof(MonoBehaviour))
			{
				obj4 = 1;
				goto IL_0153;
			}
		}
		obj4 = 0;
		goto IL_0153;
		IL_0153:
		bool flag = obj4 == null;
		ICoherenceSync coherenceSync = null;
		if (!flag)
		{
			coherenceSync = obj;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj6 = default(object);
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v16+10]");
				if ((nint)0 > (nint)0)
				{
					GameObject gameObject = ((Component)coherenceSync).gameObject;
					gameObject.SetActive(value: false);
					return;
				}
			}
		}
		GameObject gameObject2 = ((Component)coherenceSync).gameObject;
		UnityEngine.Object.Destroy(gameObject2, 0f);
	}

	public void OnApplicationQuit()
	{
	}
}

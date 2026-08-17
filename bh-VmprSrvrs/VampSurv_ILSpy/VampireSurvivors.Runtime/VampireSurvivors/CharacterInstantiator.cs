using System;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public class CharacterInstantiator : INetworkObjectInstantiator
{
	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		//IL_0066: Expected O, but got Ref
		//IL_0066: Expected O, but got Ref
		bool flag = (object)spawnInfo.rotation == null;
		ConnectionType? connectionType = spawnInfo.connectionType;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
			bool flag2 = (object)spawnInfo.connectionType == null;
			UnityEngine.Object original = null;
			if (!flag2)
			{
				bool flag3 = (object)connectionType != typeof(CoherenceSync);
				original = null;
				if (!flag3)
				{
					original = (UnityEngine.Object)spawnInfo.connectionType;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
			ConnectionType? connectionType2 = default(ConnectionType?);
			object obj2 = default(object);
			UnityEngine.Object obj = UnityEngine.Object.Instantiate(original, (Vector3)(&connectionType2), (Quaternion)(&obj2));
			Component component;
			if ((object)obj == null)
			{
				component = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Component component2 = default(Component);
				bool flag4 = (object)component2 == null;
				component = component2;
				if (flag4)
				{
					return (ICoherenceSync)new InvalidCastException();
				}
			}
			int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("SyncedCharacterType");
			GameManager core = GM.Core;
			GameObject gameObject = component.gameObject;
			core._diContainer.InjectGameObject(gameObject);
			GameObject gameObject2 = component.gameObject;
			GameManager._003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574 obj3 = null;
			obj3._003C_003E1__state = 0;
			obj3._003C_003E4__this = core;
			obj3.characterInstance = gameObject2;
			obj3.characterType = (CharacterType)bindingValue;
			Coroutine coroutine = core.StartCoroutine(obj3);
			return (ICoherenceSync)component;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new NullReferenceException();
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v24+FFFFFFF8+v49 @ rax_v4*8]");
			if (0 == (nint)typeof(MonoBehaviour))
			{
				obj4 = 1;
				goto IL_0142;
			}
		}
		obj4 = 0;
		goto IL_0142;
		IL_0142:
		bool flag = obj4 == null;
		ICoherenceSync coherenceSync = null;
		if (!flag)
		{
			coherenceSync = obj;
		}
		GameObject gameObject = ((Component)coherenceSync).gameObject;
		gameObject.SetActive(value: false);
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController component = ((Component)coherenceSync).GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			GM.Core.OnCharacterDestroyed(component);
		}
	}

	public void OnApplicationQuit()
	{
	}

	public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
	{
	}

	public void OnUniqueObjectReplaced(ICoherenceSync instance)
	{
	}
}

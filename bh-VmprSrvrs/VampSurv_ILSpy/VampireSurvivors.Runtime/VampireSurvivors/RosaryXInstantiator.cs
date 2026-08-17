using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors;

public class RosaryXInstantiator : INetworkObjectInstantiator
{
	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("SyncedPickupType");
		if (bindingValue == 9)
		{
			Vector2 pos = default(Vector2);
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.ROSARYX);
			if ((object)pickup != null)
			{
				if (pickup._003CIsStagePickup_003Ek__BackingField)
				{
					if ((object)GM.Core == null)
					{
						goto IL_0134;
					}
					GM.Core.RegisterStagePickup(pickup);
				}
				return pickup.GetComponent<CoherenceSync>();
			}
			goto IL_0134;
		}
		int num = default(int);
		object obj = (ItemType)num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		string text2 = default(string);
		string text = "RosaryXInstantiator is exclusive to the RosaryX Pickup, " + text2;
		object obj2 = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj2;
		IL_0134:
		return (ICoherenceSync)new NullReferenceException();
	}

	public void Destroy(ICoherenceSync obj)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_009c: Expected I, but got O
		//IL_00ac: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		nint num = (nint)typeof(Component);
		nint num2 = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v2 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v2 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v5+FFFFFFF8+v47 @ rax_v4*8]");
			if (0 == (nint)typeof(Component))
			{
				nint num4 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v6 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v7+FFFFFFF8+v91 @ rcx_v4*8]");
				object obj6 = ((0 != (nint)typeof(Component)) ? ((object)0) : ((object)1));
				bool flag = obj6 == null;
				ICoherenceSync coherenceSync = null;
				if (!flag)
				{
					coherenceSync = obj;
				}
				Pickup component = ((Component)coherenceSync).GetComponent<Pickup>();
				PickupManager.ReturnPickup(component);
				return;
			}
		}
		throw new NullReferenceException();
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

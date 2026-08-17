using System;
using System.Text;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors;

public class TreasureInstantiator : INetworkObjectInstantiator
{
	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("SyncedPickupType");
		if (bindingValue == 8)
		{
			object bindingValue2 = ((SpawnInfo*)spawnInfo)->GetBindingValue<object>("SerializedTreasure");
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				string value = uTF.GetString((byte[])bindingValue2);
				Treasure treasure = JsonConvert.DeserializeObject<Treasure>(value);
				if ((object)GM.Core != null)
				{
					Vector2 pos = default(Vector2);
					TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure, isRemote: true);
					if ((object)treasureChest != null)
					{
						return treasureChest.GetComponent<CoherenceSync>();
					}
				}
			}
			return (ICoherenceSync)new NullReferenceException();
		}
		object obj = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5+FFFFFFF8+v47 @ rax_v4*8]");
			if (0 == (nint)typeof(Component))
			{
				nint num4 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v6 (Il2CppClass<Coherence.Toolkit.ICoherenceSync>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v7+FFFFFFF8+v108 @ rcx_v4*8]");
				object obj6 = ((0 != (nint)typeof(Component)) ? ((object)0) : ((object)1));
				bool flag = obj6 == null;
				ICoherenceSync coherenceSync = null;
				if (!flag)
				{
					coherenceSync = obj;
				}
				NetworkPickup component = ((Component)coherenceSync).GetComponent<NetworkPickup>();
				if (!((Pickup)component)._doOnlineDespawn)
				{
					component._003CForceDespawn_003Ek__BackingField = true;
					component.Despawn();
				}
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

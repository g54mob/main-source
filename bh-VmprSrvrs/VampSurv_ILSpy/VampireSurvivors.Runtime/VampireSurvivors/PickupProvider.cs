using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using QFSW.MOP2;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors;

public class PickupProvider : INetworkObjectProvider
{
	private ItemType _itemType;

	public void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
	{
		//IL_004a: Expected O, but got I
		//IL_005a: Expected O, but got I
		//IL_006a: Expected O, but got I
		while (true)
		{
			ObjectPool pool = PickupManager._pickupFactory.GetPool(_itemType);
			ICoherenceSync component = pool._template.GetComponent<ICoherenceSync>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v150 @ rax_v10 (should have been resolved before IL gen)");
		}
	}

	public ICoherenceSync LoadAsset(string networkAssetId)
	{
		if ((object)PickupManager._pickupFactory != null)
		{
			ObjectPool pool = PickupManager._pickupFactory.GetPool(_itemType);
			if ((object)pool != null && (object)pool._template != null)
			{
				return pool._template.GetComponent<ICoherenceSync>();
			}
		}
		return (ICoherenceSync)new NullReferenceException();
	}

	public void Release(ICoherenceSync obj)
	{
	}

	public void OnApplicationQuit()
	{
	}

	public void Initialize(CoherenceSyncConfig entry)
	{
	}

	public bool Validate(CoherenceSyncConfig entry)
	{
		bool flag = _itemType < ItemType.VOID;
		bool flag2 = _itemType == ItemType.VOID;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}

using System;
using Coherence.Toolkit;
using Cpp2ILInjected;
using QFSW.MOP2;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors;

public class DestructibleProvider : INetworkObjectProvider
{
	private PropType _propType;

	private bool _initialized;

	public void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
	{
		//IL_002c: Expected O, but got I
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		while (true)
		{
			ObjectPool pool = DestructibleManager.GetPool(_propType);
			ICoherenceSync component = pool._template.GetComponent<ICoherenceSync>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v88 @ rax_v6 (should have been resolved before IL gen)");
		}
	}

	public ICoherenceSync LoadAsset(string networkAssetId)
	{
		ObjectPool pool = DestructibleManager.GetPool(_propType);
		if ((object)pool != null && (object)pool._template != null)
		{
			return pool._template.GetComponent<ICoherenceSync>();
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
		return _initialized;
	}
}

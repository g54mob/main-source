using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace Coherence.Toolkit;

[Serializable]
public sealed class CharacterProvider : INetworkObjectProvider
{
	private CharacterType _characterType;

	public unsafe void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
	{
		//IL_007d: Expected I4, but got O
		//IL_00a2: Expected O, but got Ref
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterPrefab = core._characterFactory.GetCharacterPrefab(_characterType);
		if ((object)characterPrefab != null && ((UnityEngine.Object)characterPrefab).m_CachedPtr != (IntPtr)0)
		{
			ICoherenceSync component = characterPrefab.GetComponent<ICoherenceSync>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onLoaded @ r8 (System.Action`1<Coherence.Toolkit.ICoherenceSync>)+18] (should have been resolved before IL gen)");
			return;
		}
		object obj = default(object);
		object arg = (CharacterType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Character Prefab could not be loaded for {0}", (System.ParamsArray)(&obj2));
		Debug.LogError(message);
	}

	public ICoherenceSync LoadAsset(string networkAssetId)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._characterFactory != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterPrefab = core._characterFactory.GetCharacterPrefab(_characterType);
			if ((object)characterPrefab != null)
			{
				return characterPrefab.GetComponent<ICoherenceSync>();
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
		bool flag = _characterType < CharacterType.VOID;
		bool flag2 = _characterType == CharacterType.VOID;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}

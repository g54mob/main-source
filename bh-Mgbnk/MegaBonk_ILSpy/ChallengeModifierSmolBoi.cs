using System;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class ChallengeModifierSmolBoi : ChallengeModifier
{
	public override void Init(ChallengeData challengeData)
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerInventory> b = OnPlayerInit;
		Delegate obj = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b);
		if ((object)obj == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action = default(Action<PlayerInventory>);
		if (action != null)
		{
			MyPlayer.A_PlayerInventoryInitialized = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerInventory>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerInventory>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerInventory> value = OnPlayerInit;
		Delegate obj = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value);
		if ((object)obj == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action = default(Action<PlayerInventory>);
		if (action != null)
		{
			MyPlayer.A_PlayerInventoryInitialized = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerInventory>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerInventory>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnPlayerInit(PlayerInventory obj)
	{
		//IL_0038: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		CharacterData characterData = DataManager.Instance.GetCharacterData(instance.character);
		object obj2 = default(object);
		MyPlayer.Instance.RefreshSize(characterData, (Vector3)(&obj2), 0.5f);
	}
}

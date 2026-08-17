using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
	public AudioClip dungeonAmbience;

	public AudioSource audioSource;

	private void Start()
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		audioSource.clip = mapData.ambience;
		audioSource.Play();
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if (instance._003CisCrypt_003Ek__BackingField)
			{
				audioSource.clip = dungeonAmbience;
				audioSource.Play();
			}
		}
	}

	private void Awake()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0294: Expected I, but got O
		//IL_029d: Expected O, but got I4
		Action b = OnDungeonStarted;
		Delegate obj = Delegate.Combine(GameManager.A_DungeonStarted, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_DungeonStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02ce;
			}
			GameManager.A_DungeonStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b3;
			}
		}
		Action b2 = OnDungeonEnded;
		Delegate obj6 = Delegate.Combine(GameManager.A_DungeonEnded, b2);
		if ((object)obj6 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02be;
		}
		GameManager.A_DungeonEnded = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02ce;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b3;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02be;
	}

	private void OnDestroy()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0294: Expected I, but got O
		//IL_029d: Expected O, but got I4
		Action value = OnDungeonStarted;
		Delegate obj = Delegate.Remove(GameManager.A_DungeonStarted, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_DungeonStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02ce;
			}
			GameManager.A_DungeonStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b3;
			}
		}
		Action value2 = OnDungeonEnded;
		Delegate obj6 = Delegate.Remove(GameManager.A_DungeonEnded, value2);
		if ((object)obj6 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02be;
		}
		GameManager.A_DungeonEnded = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02ce;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b3;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02be;
	}

	private void OnDungeonStarted()
	{
		audioSource.clip = dungeonAmbience;
		audioSource.Play();
	}

	private void OnDungeonEnded()
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		audioSource.clip = mapData.ambience;
		audioSource.Play();
	}
}

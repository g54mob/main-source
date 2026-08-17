using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public class TestShowAllCharactersAndSkins : MonoBehaviour
{
	public CharacterData[] characters;

	public SkinData[] skins;

	public Transform startPoint;

	public GameObject playerRendererPrefab;

	public float xSpacing;

	public float zSpacing;

	private void Start()
	{
		SpawnAllCharactersAndSkins();
	}

	private unsafe void SpawnAllCharactersAndSkins()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00dc: Expected O, but got I4
		//IL_00e5: Expected O, but got I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_016d: Expected O, but got Ref
		//IL_016d: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		Dictionary<ECharacter, List<SkinData>> dictionary = new Dictionary<ECharacter, List<SkinData>>();
		SkinData[] array = skins;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			SkinData skinData = array[obj];
			if (!((Dictionary<System.Int32Enum, object>)(object)dictionary).ContainsKey((System.Int32Enum)skinData.character))
			{
				List<SkinData> value = new List<SkinData>();
				((Dictionary<System.Int32Enum, object>)(object)dictionary).Add((System.Int32Enum)skinData.character, (object)value);
			}
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)skinData.character);
			((List<SkinData>)obj3).Add(skinData);
			obj++;
			obj2 = obj;
		}
		CharacterData[] array2 = characters;
		object obj4 = 0;
		object obj5 = 0;
		object obj8 = default(object);
		Quaternion identityQuaternion = default(Quaternion);
		float x = default(float);
		object obj10 = default(object);
		while ((nint)obj4 < array2.Length)
		{
			object obj6 = obj5 + 1;
			CharacterData characterData = array2[obj5];
			int num = 0;
			while (true)
			{
				object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)characterData.eCharacter);
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v13 (System.Object)+18]");
				if ((nint)num2 >= (nint)0)
				{
					break;
				}
				Vector3 position = startPoint.position;
				GameObject gameObject = UnityEngine.Object.Instantiate(playerRendererPrefab, (Vector3)(&obj8), (Quaternion)(&identityQuaternion));
				PlayerRenderer component = gameObject.GetComponent<PlayerRenderer>();
				Transform transform = gameObject.transform;
				Vector3 forward = transform.forward;
				component.SetCharacter(characterData, null, (Vector3)(&x));
				PlayerRenderer component2 = gameObject.GetComponent<PlayerRenderer>();
				object obj9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)characterData.eCharacter);
				SkinData skin = ((List<SkinData>)obj9).get_Item(num);
				num++;
				component2.SetSkin(skin);
				x = forward.x;
				identityQuaternion = Quaternion.identityQuaternion;
				obj8 = obj10;
			}
			obj4 = obj6;
			obj5 = obj6;
		}
	}
}

using System;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class Funfact : MonoBehaviour
{
	public TextMeshProUGUI t_text;

	private string[] facts = new string[27]
	{
		"i hate this game", "bonking at the speed of light is highly discouraged", "shh they're not bugs, they're features", "to bonk or not to bonk", "scientists agree: bonking is 74% effective.", "the local skeletons are on a union break.", "im in your walls", "no, you cant speedrun this game", "bonking is a lifestyle, not a choice.", "just one more run",
		"bonk or be bonked", "now with 10% more bonk!", "100% organically sourced bonks!", "bonk responsibly", "bonk with friends", "hello :)", "i think im gonna bonk", "bonk bonk bonk", "a severe case of skill issue", "no refunds",
		"beep boop, I am human", "do not eat yellow snow", "do not eat the enemies", "(real)", "megaing my bonk", "moldy cheese my beloved", "there might be bonk"
	};

	private void Start()
	{
		string[] array = facts;
		int num = UnityEngine.Random.Range(0, array.Length);
		t_text.text = array[num];
	}

	private string GetRandomFact()
	{
		string[] array = facts;
		int num = UnityEngine.Random.Range(0, array.Length);
		if (num < array.Length)
		{
			return array[num];
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private unsafe void Update()
	{
		//IL_014a: Expected I, but got O
		//IL_00d4: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		//IL_0129: Expected O, but got Ref
		Behaviour behaviour;
		bool flag;
		if (t_text.enabled && !LocalizationUtility.IsEnglish())
		{
			behaviour = t_text;
			flag = false;
		}
		else
		{
			if (t_text.enabled || !LocalizationUtility.IsEnglish())
			{
				goto IL_00b8;
			}
			behaviour = t_text;
			flag = true;
		}
		behaviour.enabled = flag;
		goto IL_00b8;
		IL_00b8:
		Transform transform = base.transform;
		nint num = (nint)typeof(Vector3);
		float time = Time.time;
		float num2 = time * 2.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		float num3 = default(float);
		transform.localScale = (Vector3)(&num3);
		Transform transform2 = base.transform;
		float time2 = Time.time;
		float num4 = time2 + time2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num3));
		transform2.localRotation = (Quaternion)(&num3);
	}
}

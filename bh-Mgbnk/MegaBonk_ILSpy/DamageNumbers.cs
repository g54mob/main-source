using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class DamageNumbers : MonoBehaviour
{
	public TextMeshProUGUI damageText;

	private Vector3 randomDir;

	private Vector3 defaultScale;

	private float fadeTime = 0.4f;

	private float startFadeoutTime = 0.5f;

	private bool started;

	private IEnumerator shakeRoutine;

	private static StringBuilder sb;

	private float moveMultiplier = 1f;

	private float speed = 8f;

	private Vector3 moveDir;

	private static string[] suffixes;

	private float desiredScale = 4f;

	private void StartFadeOut()
	{
	}

	public unsafe void SetDamage(float dmg, Color color, Vector3 position, int textSize = 24)
	{
		//IL_002d: Expected O, but got Ref
		//IL_002d: Expected O, but got Ref
		string text = FormatDamageNumber(dmg);
		object obj = default(object);
		object obj2 = default(object);
		int textSize2 = default(int);
		SetDamage(text, (Color)(&obj), (Vector3)(&obj2), textSize2);
	}

	public unsafe void SetDamage(string text, Color color, Vector3 position, int textSize = 24)
	{
		//IL_0238: Expected I, but got O
		//IL_0275: Expected O, but got I
		//IL_0292: Expected O, but got I
		//IL_02dc: Invalid comparison between F4 and O
		//IL_0093: Expected O, but got Ref
		//IL_00b0: Expected O, but got Ref
		//IL_0077: Expected O, but got F4
		//IL_0132: Expected O, but got Ref
		//IL_014f: Expected O, but got F4
		//IL_0301: Expected I, but got O
		//IL_01d2: Expected O, but got Ref
		float fontSize = default(float);
		damageText.fontSize = fontSize;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		speed = 8f;
		desiredScale = 5f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = defaultScale - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DamageNumbers)+38]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DamageNumbers)+3C]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj3 * obj3;
		object obj6 = obj * obj;
		object obj7 = obj4 + obj6;
		object obj8 = obj7 + obj5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Transform transform = base.transform;
			Vector3 localScale = transform.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
		}
		Transform transform2 = base.transform;
		float num5 = default(float);
		transform2.localScale = (Vector3)(&num5);
		Transform transform3 = base.transform;
		transform3.position = (Vector3)(&num5);
		Transform transform4 = PlayerCamera.Instance.transform;
		Vector3 position2 = transform4.position;
		Transform transform5 = base.transform;
		Vector3 position3 = transform5.position;
		Transform transform6 = base.transform;
		Transform transform7 = PlayerCamera.Instance.transform;
		Vector3 position4 = transform7.position;
		transform6.LookAt((Vector3)(&num5));
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		randomDir = (Vector3)insideUnitSphere.x;
		_ = insideUnitSphere.z;
		nint num6 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num7 = 0;
		Transform transform8 = base.transform;
		float num8 = transform8.forward.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DamageNumbers)+30]");
		float num9 = num8 + 0f;
		float num10 = num9 * moveMultiplier;
		float num11 = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num12 = num11 + 0f;
		Vector3 vector = default(Vector3);
		moveDir = vector;
		object obj9 = default(object);
		damageText.color = (Color)(&obj9);
		damageText.text = text;
		Invoke("StartFadeOut", startFadeoutTime);
		float time = startFadeoutTime + fadeTime;
		Invoke("DestroySelf", time);
		started = true;
	}

	private unsafe void Update()
	{
		//IL_0079: Expected O, but got Ref
		//IL_00a0: Invalid comparison between I4 and F4
		//IL_00eb: Expected F4, but got I4
		//IL_0125: Invalid comparison between I4 and F4
		//IL_0170: Expected F4, but got I4
		//IL_0182: Expected O, but got Ref
		//IL_01a9: Invalid comparison between I4 and F4
		//IL_01f4: Expected F4, but got I4
		if (!started)
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float deltaTime = Time.deltaTime;
		float num = default(float);
		transform.position = (Vector3)(&num);
		float deltaTime2 = Time.deltaTime;
		float num2 = deltaTime2 * 6f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = 0.02f - speed;
		float num4 = num3 * num2;
		float num5 = num4 + speed;
		speed = num5;
		Transform transform2 = base.transform;
		Transform transform3 = base.transform;
		Vector3 localScale = transform3.localScale;
		float deltaTime3 = Time.deltaTime;
		float num6 = deltaTime3 * 10f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		transform2.localScale = (Vector3)(&num);
		float deltaTime4 = Time.deltaTime;
		float num7 = deltaTime4 * 4f;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num8 = 1f - desiredScale;
		float num9 = num8 * num7;
		float num10 = num9 + desiredScale;
		desiredScale = num10;
	}

	public static string FormatDamageNumber(float number, string decimalFormat = "0.0")
	{
		//IL_0048: Expected O, but got I4
		//IL_0118: Expected I, but got O
		//IL_0067: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		StringBuilder stringBuilder = sb.Clear();
		StringBuilder stringBuilder3;
		string value2;
		if (!(10000f > number))
		{
			bool flag = number < 1000f;
			object obj = 0;
			float num = number;
			if (!flag)
			{
				object obj2 = 0;
				float num2 = number;
				num = number;
				bool flag3;
				do
				{
					string[] array = suffixes;
					object obj3 = array.Length - 1;
					bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
					obj = obj2;
					if (flag2)
					{
						break;
					}
					num2 /= 1000f;
					obj = obj2 + 1;
					flag3 = !(num2 < 1000f);
					num = num2;
					obj2 = obj;
					num = num2;
				}
				while (flag3);
			}
			nint num3 = (nint)typeof(Math);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm7\"");
			double num4 = Math.Round(0.0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
			}
			string value = num.ToString("0");
			StringBuilder stringBuilder2 = sb.Append(value);
			string[] array2 = suffixes;
			if ((nint)obj >= array2.Length)
			{
				return (string)(object)new IndexOutOfRangeException();
			}
			stringBuilder3 = sb;
			value2 = array2[obj];
		}
		else
		{
			float num = default(float);
			string text = num.ToString("N0");
			value2 = text;
			stringBuilder3 = sb;
		}
		StringBuilder stringBuilder4 = stringBuilder3.Append(value2);
		return sb.ToString();
	}

	private void DestroySelf()
	{
		PoolManager instance = PoolManager.Instance;
		ObjectPool<GameObject> damageNumbersPool = instance.damageNumbersPool;
		GameObject gameObject = base.gameObject;
		Action<GameObject> actionOnRelease = damageNumbersPool.m_ActionOnRelease;
		if (damageNumbersPool.m_ActionOnRelease != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ rax_v10 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if ((object)damageNumbersPool.m_FreshlyReleased != null)
		{
			int countInactive = damageNumbersPool.CountInactive;
			if (countInactive >= damageNumbersPool.m_MaxSize)
			{
				int num = damageNumbersPool._003CCountAll_003Ek__BackingField - 1;
				damageNumbersPool._003CCountAll_003Ek__BackingField = num;
				Action<GameObject> actionOnDestroy = damageNumbersPool.m_ActionOnDestroy;
				if (damageNumbersPool.m_ActionOnDestroy != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rax_v24 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
			}
			else
			{
				List<object> list = (List<object>)(object)damageNumbersPool.m_List;
				object[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				if (list._size >= items.Length)
				{
					list.AddWithResize((object)gameObject);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					int num2 = default(int);
					items[num2] = gameObject;
				}
			}
		}
		else
		{
			damageNumbersPool.m_FreshlyReleased = gameObject;
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
	}

	static DamageNumbers()
	{
		StringBuilder stringBuilder = new StringBuilder();
		sb = stringBuilder;
		suffixes = new string[13]
		{
			"", "K", "M", "B", "T", "Q", "Qi", "Sx", "Sp", "Oc",
			"No", "Dc", "Ud"
		};
	}
}

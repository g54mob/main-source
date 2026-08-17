using Cpp2ILInjected;
using MK.Toon;
using UnityEngine;

public class TestDeleteMe : MonoBehaviour
{
	private Material[] activeMaterials;

	public Color colorFreeze;

	public Color poisonColor;

	private void Start()
	{
		//IL_002c: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0084: Expected I, but got O
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		Material[] array = new Material[componentsInChildren.Length];
		activeMaterials = array;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while (true)
		{
			if ((nint)obj2 >= componentsInChildren.Length)
			{
				return;
			}
			Material[] array2 = activeMaterials;
			Material sharedMaterial = componentsInChildren[obj].GetSharedMaterial();
			if ((object)sharedMaterial != null)
			{
				nint num = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				if (obj3 == null)
				{
					break;
				}
			}
			array2[obj] = sharedMaterial;
			obj++;
			obj2 = obj;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
		object obj4 = default(object);
		throw obj4;
	}

	private void Update()
	{
	}

	private unsafe void SetColorBleed()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_009c: Expected O, but got I
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.iridescence).SetValue(array[obj], (T)1);
			Properties.iridescenceColor.SetValue(array[obj], (Color)(&obj3));
			Properties.iridescenceSize.SetValue(array[obj], 0.18f);
			obj++;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED40]");
			obj3 = 0;
			obj2 = obj;
		}
	}

	private void SetNothing()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.iridescence).SetValue(array[obj], (T)null);
			obj++;
			obj2 = obj;
		}
	}

	private unsafe void SetColorFreeze()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		Color color = default(Color);
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.iridescence).SetValue(array[obj], (T)1);
			Properties.iridescenceColor.SetValue(array[obj], (Color)(&color));
			Properties.iridescenceSize.SetValue(array[obj], 0.18f);
			obj++;
			color = colorFreeze;
			obj2 = obj;
		}
	}

	private unsafe void SetPoison()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		Color color = default(Color);
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.iridescence).SetValue(array[obj], (T)1);
			Properties.iridescenceColor.SetValue(array[obj], (Color)(&color));
			Properties.iridescenceSize.SetValue(array[obj], 0.5f);
			obj++;
			color = poisonColor;
			obj2 = obj;
		}
	}
}

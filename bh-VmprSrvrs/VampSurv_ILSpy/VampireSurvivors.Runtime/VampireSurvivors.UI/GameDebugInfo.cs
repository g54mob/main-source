using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class GameDebugInfo : MonoBehaviour
{
	private TextMeshProUGUI _DebugText;

	private Stage _stage;

	private DestructibleFactory _destructibleFactory;

	private void Construct(Stage stage, DestructibleFactory destructibleFactory)
	{
		_stage = stage;
		_destructibleFactory = destructibleFactory;
	}

	private void Update()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	private unsafe void BuildDebugInfo()
	{
		//IL_010e: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_01c2: Expected O, but got I
		//IL_0247: Expected I, but got O
		//IL_02ac: Expected I, but got O
		//IL_0311: Expected I, but got O
		//IL_0376: Expected I, but got O
		//IL_03db: Expected I, but got O
		//IL_0440: Expected I, but got O
		//IL_04f7: Expected O, but got Ref
		//IL_04a5: Expected I, but got O
		if (PhysicsManager._sInstance == null)
		{
			return;
		}
		PhysicsManager sInstance = PhysicsManager._sInstance;
		if (sInstance._bulletGroup == null)
		{
			return;
		}
		PhysicsManager sInstance2 = PhysicsManager._sInstance;
		if (sInstance2._destructiblesGroup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v33+20]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v34+30]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v35+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v36+28]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v38+40]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v39+18]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v40+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v41+18]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v42+30]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v43+18]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
		World s_world = ArcadePhysics.s_world;
		RBush staticTree = s_world._staticTree;
		List<BaseBody> result = new List<BaseBody>();
		List<BaseBody> list = s_world._staticTree._all(staticTree.data, result);
		object[] array = new object[7];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj8 = default(object);
		if (obj8 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj10 = default(object);
		if (obj10 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj12 = default(object);
		if (obj12 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			if (obj13 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj14 = default(object);
		if (obj14 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj15 = default(object);
			if (obj15 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj16 = default(object);
		if (obj16 != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			if (obj17 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj18 = default(object);
		if (obj18 != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj19 = default(object);
			if (obj19 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj20 = default(object);
		if (obj20 != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj21 = default(object);
			if (obj21 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj22 = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "Dynamic Bodies: {0}\n\nStatic Bodies: {1}\n\nbulletBodyCount: {2}\n\ndestructibleBodies: {3}\n\nenemyBodies: {4}\n\npickupBodies: {5}\n\nplayerBodies: {6}", (System.ParamsArray)(&obj22));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public GameDebugInfo()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

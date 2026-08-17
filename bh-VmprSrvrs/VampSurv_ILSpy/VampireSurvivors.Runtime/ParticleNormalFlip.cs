using System;
using Cpp2ILInjected;
using UnityEngine;

public class ParticleNormalFlip : MonoBehaviour
{
	private bool DefaultIsFrontFaceCulling;

	private bool hasFlippedNormal;

	private Renderer ren;

	private float defaultCull;

	private float negativeCull;

	private void Start()
	{
		ParticleSystem component = GetComponent<ParticleSystem>();
		Renderer component2 = component.GetComponent<Renderer>();
		ren = component2;
		bool flag = !DefaultIsFrontFaceCulling;
		bool flag2 = !flag;
		float num = (float)(flag2 ? 1 : 0) + 1f;
		defaultCull = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb ecx,ecx\"");
		float num2 = (float)component + 2f;
		negativeCull = num2;
	}

	private unsafe void Update()
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_01a1: Expected O, but got Ref
		//IL_009a->IL00f0: Incompatible stack heights: 1 vs 0
		//IL_00c6->IL00f0: Incompatible stack heights: 1 vs 0
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_lossyScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			bool flag2 = 0 < (nint)ret;
			object obj = 0 - ret;
			bool flag3 = obj == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			bool flag6 = flag5 & flag4;
			if (hasFlippedNormal == flag6)
			{
				return;
			}
			hasFlippedNormal = flag6;
			float value = ((!flag6) ? defaultCull : negativeCull);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Cull is {0}", (System.ParamsArray)(&obj2));
			Debug.Log(message);
			if ((object)ren != null)
			{
				Material material = ren.GetMaterial();
				if ((object)material != null)
				{
					int num = Shader.PropertyToID("_Cull");
					material.SetFloatImpl(num, value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public ParticleNormalFlip()
	{
		//IL_0020: Expected I, but got O
		DefaultIsFrontFaceCulling = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private unsafe void _003CUpdate_003Eg__FlipCull_007C6_0(bool isNegative)
	{
		//IL_00d5: Expected O, but got Ref
		if (hasFlippedNormal != isNegative)
		{
			hasFlippedNormal = isNegative;
			float value = ((!isNegative) ? defaultCull : negativeCull);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Cull is {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			Material material = ren.GetMaterial();
			int num = Shader.PropertyToID("_Cull");
			material.SetFloatImpl(num, value);
		}
	}
}

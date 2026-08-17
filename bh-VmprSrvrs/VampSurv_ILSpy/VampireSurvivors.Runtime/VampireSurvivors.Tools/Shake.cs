using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class Shake : MonoBehaviour
{
	private Transform _target;

	private bool _isRunning;

	private float _duration;

	private Vector2 _intensity;

	private float _progress;

	private float _elapsed;

	private float _offsetX;

	private float _offsetY;

	private bool _force;

	private Vector2 _basePosition;

	private Action updateCallback;

	public unsafe void StartShake(float duration, Vector2 intensity, bool force = false, Action callback = null)
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_015c: Expected I, but got O
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0149->IL00f1: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL00f1: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874A96BBh\"");
		bool flag = duration != 0f;
		float duration2 = duration;
		if (!flag)
		{
			duration2 = 0.1f;
		}
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		object obj = intensity - Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj3 = default(object);
		object obj2 = obj3 - 0;
		object obj4 = obj * obj;
		object obj5 = obj2 * obj2;
		float num3 = (float)obj5 + (float)obj4;
		bool flag2 = !(9.9999994E-11f > num3);
		Vector2 intensity2 = intensity;
		if (!flag2)
		{
			num3 = 0.05f;
			Vector2 vector = default(Vector2);
			intensity2 = vector;
		}
		_force = force;
		if (force || _isRunning == force)
		{
			_duration = duration2;
			_elapsed = 0f;
			_offsetY = 0f;
			_isRunning = true;
			_intensity = intensity2;
			Transform transform = base.transform;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			_basePosition = ret;
			Action action = default(Action);
			if (action != null)
			{
				updateCallback = action;
			}
		}
	}

	private void Update()
	{
		//IL_01d0: Expected O, but got F4
		//IL_0205: Invalid comparison between I4 and F4
		//IL_005b: Expected F4, but got I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_00b5: Expected O, but got I
		//IL_0292: Expected O, but got I
		//IL_0186: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_0282->IL01c6: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL0273: Incompatible stack heights: 2 vs 1
		//IL_01c6->IL01c6: Incompatible stack heights: 2 vs 0
		if (!_isRunning)
		{
			return;
		}
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (_elapsed = (float)obj2 + _elapsed) / _duration;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		bool flag = updateCallback == null;
		_progress = num;
		if (!flag)
		{
			Action action = updateCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v314.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		object obj7 = default(object);
		if (!(_duration > _elapsed))
		{
			_offsetX = 0f;
			_isRunning = false;
			updateCallback = null;
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v16 (VampireSurvivors.Tools.Shake)+50]");
			object obj3 = 0;
			bool flag2 = (object)transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v32 (UnityEngine.Transform)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v32 (UnityEngine.Transform)+10]");
			bool flag3 = (nint)0 == 0;
			object obj5 = 0;
			object obj6 = obj7;
			object obj8 = obj7;
		}
		else
		{
			float num2 = UnityEngine.Random.Range(-1f, 1f);
			float offsetX = num2 * (float)_intensity;
			_offsetX = offsetX;
			float num3 = UnityEngine.Random.Range(-1f, 1f);
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v16 (VampireSurvivors.Tools.Shake)+34]");
			float offsetY = num4 * 0f;
			_offsetY = offsetY;
			Transform transform2 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v16 (VampireSurvivors.Tools.Shake)+50]");
			object obj3 = 0 + _offsetY;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rax_v24 (UnityEngine.Transform)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rax_v24 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			object obj5 = 0;
			bool flag5 = (nint)0 != 0;
			object obj6 = obj7;
			object obj8 = obj7;
			if (!flag5)
			{
				bool flag6 = (nint)0 == 0;
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v704 @ rax_v21 (should have been resolved before IL gen)");
	}

	private void Complete()
	{
		_offsetX = 0f;
		_isRunning = false;
		updateCallback = null;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public Shake()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

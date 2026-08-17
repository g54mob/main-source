using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using Zenject;

namespace VampireSurvivors.App.Tools;

public class ResolutionManager : IInitializable, IDisposable, ITickable
{
	private static Action<Vector2> m_OnResolutionChange;

	private static Action<DeviceOrientation> m_OnOrientationChange;

	private static Vector2 _resolution;

	private static DeviceOrientation _orientation;

	private static float _checkTimer;

	private const float CHECK_DELAY = 0.5f;

	public static event Action<Vector2> OnResolutionChange
	{
		add
		{
			Delegate obj = ResolutionManager.m_OnResolutionChange;
			Action<Vector2> action = default(Action<Vector2>);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				Action<Vector2> onResolutionChange;
				if ((object)obj2 == null)
				{
					onResolutionChange = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					onResolutionChange = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == ResolutionManager.m_OnResolutionChange;
				Delegate obj3;
				if ((object)obj == ResolutionManager.m_OnResolutionChange)
				{
					ResolutionManager.m_OnResolutionChange = onResolutionChange;
					obj3 = obj;
				}
				else
				{
					obj3 = ResolutionManager.m_OnResolutionChange;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = ResolutionManager.m_OnResolutionChange;
			Action<Vector2> action = default(Action<Vector2>);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				Action<Vector2> onResolutionChange;
				if ((object)obj2 == null)
				{
					onResolutionChange = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					onResolutionChange = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == ResolutionManager.m_OnResolutionChange;
				Delegate obj3;
				if ((object)obj == ResolutionManager.m_OnResolutionChange)
				{
					ResolutionManager.m_OnResolutionChange = onResolutionChange;
					obj3 = obj;
				}
				else
				{
					obj3 = ResolutionManager.m_OnResolutionChange;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event Action<DeviceOrientation> OnOrientationChange
	{
		add
		{
			//IL_000e: Expected O, but got I4
			//IL_0050: Expected I, but got O
			//IL_0066: Expected O, but got I
			Delegate obj = ResolutionManager.m_OnOrientationChange;
			object obj4 = default(object);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				object obj3;
				if ((object)obj2 == null)
				{
					obj3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj4 == null;
					obj3 = obj4;
					if (flag)
					{
						break;
					}
				}
				nint num = (nint)typeof(ResolutionManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
				object obj5 = (nint)0 + (nint)8;
				bool flag2 = obj == obj5;
				Delegate obj6;
				if (obj == obj5)
				{
					obj5 = obj3;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj5;
				}
				Delegate obj7 = obj;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj;
				obj = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_000e: Expected O, but got I4
			//IL_0050: Expected I, but got O
			//IL_0066: Expected O, but got I
			Delegate obj = ResolutionManager.m_OnOrientationChange;
			object obj4 = default(object);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				object obj3;
				if ((object)obj2 == null)
				{
					obj3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj4 == null;
					obj3 = obj4;
					if (flag)
					{
						break;
					}
				}
				nint num = (nint)typeof(ResolutionManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
				object obj5 = (nint)0 + (nint)8;
				bool flag2 = obj == obj5;
				Delegate obj6;
				if (obj == obj5)
				{
					obj5 = obj3;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj5;
				}
				Delegate obj7 = obj;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj;
				obj = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public void Initialize()
	{
		//IL_004d: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0021: Expected I, but got O
		Vector2 resolution = (Vector2)Screen.width;
		object obj = Screen.height;
		nint num = (nint)typeof(ResolutionManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v8 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
		nint num2 = 0;
		_resolution = resolution;
		DeviceOrientation deviceOrientation = Input.deviceOrientation;
		_orientation = deviceOrientation;
	}

	public void Dispose()
	{
	}

	public void Tick()
	{
		//IL_01b2: Invalid comparison between F4 and I4
		//IL_01ff: Expected O, but got F4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0044: Invalid comparison between O and F4
		//IL_01f0: Expected O, but got I4
		//IL_0067: Expected I, but got O
		//IL_0247: Expected I, but got O
		//IL_0273: Expected I, but got O
		//IL_0093: Expected O, but got I
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00b1: Invalid comparison between O and F4
		//IL_0213: Expected O, but got I4
		//IL_00e6: Expected F4, but got I
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		float checkTimer = _checkTimer;
		if (!(_checkTimer > 0f))
		{
			_checkTimer = 0.5f;
			nint num = Screen.width;
			object obj = _resolution - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = obj & 0;
			IntPtr intPtr;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
			{
				nint num2 = (nint)typeof(ResolutionManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v53 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
				nint num3 = 0;
				nint num4 = Screen.height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v18 (Il2CppStaticFields<VampireSurvivors.App.Tools.ResolutionManager>)+14]");
				object obj3 = -num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj4 = obj3 & 0;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon);
				intPtr = num4;
				if (flag)
				{
					goto IL_020a;
				}
			}
			Vector2 resolution = (Vector2)Screen.width;
			nint num5 = Screen.height;
			nint num6 = (nint)typeof(ResolutionManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rax_v48 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
			nint num7 = 0;
			_resolution = resolution;
			nint num8 = (nint)typeof(ResolutionManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rcx_v38 (Il2CppClass<VampireSurvivors.App.Tools.ResolutionManager>)+B8]");
			nint num9 = 0;
			Action<Vector2> onResolutionChange = ResolutionManager.m_OnResolutionChange;
			bool flag2 = ResolutionManager.m_OnResolutionChange == null;
			intPtr = num5;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v49 (Il2CppStaticFields<VampireSurvivors.App.Tools.ResolutionManager>)+14]");
				checkTimer = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v458 @ r9_v6 (System.Action`1<UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
				IntPtr intPtr2 = default(IntPtr);
				intPtr = intPtr2;
			}
			goto IL_020a;
		}
		object obj5 = Time.deltaTime;
		_checkTimer = _checkTimer;
		return;
		IL_020a:
		object obj6 = Input.deviceOrientation;
		if (obj6 == null)
		{
			return;
		}
		object obj7 = obj6 + -5;
		if ((nint)obj7 <= 1)
		{
			return;
		}
		DeviceOrientation deviceOrientation = Input.deviceOrientation;
		if (_orientation != deviceOrientation)
		{
			DeviceOrientation deviceOrientation2 = Input.deviceOrientation;
			_orientation = deviceOrientation2;
			Action<DeviceOrientation> onOrientationChange = ResolutionManager.m_OnOrientationChange;
			if (ResolutionManager.m_OnOrientationChange != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v630 @ r9_v5 (System.Action`1<UnityEngine.DeviceOrientation>)+18] (should have been resolved before IL gen)");
			}
		}
	}
}

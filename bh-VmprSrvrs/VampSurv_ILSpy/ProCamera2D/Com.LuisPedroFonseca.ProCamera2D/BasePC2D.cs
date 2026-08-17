using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Com.LuisPedroFonseca.ProCamera2D;

public abstract class BasePC2D : MonoBehaviour, ISerializationCallbackReceiver
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Vector3, float> _003C_003E9__19_0;

		public static Func<Vector3, float> _003C_003E9__19_1;

		public static Func<Vector3, float> _003C_003E9__19_2;

		public static Func<float, float, Vector3> _003C_003E9__19_3;

		public static Func<float, float, float, Vector3> _003C_003E9__19_4;

		public static Func<Vector3, float> _003C_003E9__19_5;

		public static Func<Vector3, float> _003C_003E9__19_6;

		public static Func<Vector3, float> _003C_003E9__19_7;

		public static Func<float, float, Vector3> _003C_003E9__19_8;

		public static Func<float, float, float, Vector3> _003C_003E9__19_9;

		public static Func<Vector3, float> _003C_003E9__19_10;

		public static Func<Vector3, float> _003C_003E9__19_11;

		public static Func<Vector3, float> _003C_003E9__19_12;

		public static Func<float, float, Vector3> _003C_003E9__19_13;

		public static Func<float, float, float, Vector3> _003C_003E9__19_14;

		public static Func<Vector3, float> _003C_003E9__21_0;

		public static Func<Vector3, float> _003C_003E9__21_1;

		public static Func<Vector3, float> _003C_003E9__21_2;

		public static Func<float, float, Vector3> _003C_003E9__21_3;

		public static Func<float, float, float, Vector3> _003C_003E9__21_4;

		public static Func<Vector3, float> _003C_003E9__21_5;

		public static Func<Vector3, float> _003C_003E9__21_6;

		public static Func<Vector3, float> _003C_003E9__21_7;

		public static Func<float, float, Vector3> _003C_003E9__21_8;

		public static Func<float, float, float, Vector3> _003C_003E9__21_9;

		public static Func<Vector3, float> _003C_003E9__21_10;

		public static Func<Vector3, float> _003C_003E9__21_11;

		public static Func<Vector3, float> _003C_003E9__21_12;

		public static Func<float, float, Vector3> _003C_003E9__21_13;

		public static Func<float, float, float, Vector3> _003C_003E9__21_14;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CResetAxisFunctions_003Eb__19_0(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003CResetAxisFunctions_003Eb__19_1(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003CResetAxisFunctions_003Eb__19_2(Vector3 vector)
		{
			return vector.z;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_3(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_4(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float z = default(float);
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			return vector;
		}

		internal float _003CResetAxisFunctions_003Eb__19_5(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003CResetAxisFunctions_003Eb__19_6(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003CResetAxisFunctions_003Eb__19_7(Vector3 vector)
		{
			return vector.y;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_8(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			((Vector3*)(nint)vector)->y = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_9(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float y = default(float);
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			return vector;
		}

		internal float _003CResetAxisFunctions_003Eb__19_10(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003CResetAxisFunctions_003Eb__19_11(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003CResetAxisFunctions_003Eb__19_12(Vector3 vector)
		{
			return vector.x;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_13(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			((Vector3*)(nint)vector)->x = 0f;
			return vector;
		}

		internal unsafe Vector3 _003CResetAxisFunctions_003Eb__19_14(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float x = default(float);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			return vector;
		}

		internal float _003COnAfterDeserialize_003Eb__21_0(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003COnAfterDeserialize_003Eb__21_1(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003COnAfterDeserialize_003Eb__21_2(Vector3 vector)
		{
			return vector.z;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_3(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_4(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float z = default(float);
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->y = v;
			return vector;
		}

		internal float _003COnAfterDeserialize_003Eb__21_5(Vector3 vector)
		{
			return vector.x;
		}

		internal float _003COnAfterDeserialize_003Eb__21_6(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003COnAfterDeserialize_003Eb__21_7(Vector3 vector)
		{
			return vector.y;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_8(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			((Vector3*)(nint)vector)->y = 0f;
			return vector;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_9(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float y = default(float);
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->x = h;
			((Vector3*)(nint)vector)->z = v;
			return vector;
		}

		internal float _003COnAfterDeserialize_003Eb__21_10(Vector3 vector)
		{
			return vector.z;
		}

		internal float _003COnAfterDeserialize_003Eb__21_11(Vector3 vector)
		{
			return vector.y;
		}

		internal float _003COnAfterDeserialize_003Eb__21_12(Vector3 vector)
		{
			return vector.x;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_13(float h, float v)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			((Vector3*)(nint)vector)->x = 0f;
			return vector;
		}

		internal unsafe Vector3 _003COnAfterDeserialize_003Eb__21_14(float h, float v, float d)
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float x = default(float);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->y = v;
			((Vector3*)(nint)vector)->z = h;
			return vector;
		}
	}

	private ProCamera2D _pc2D;

	protected Func<Vector3, float> Vector3H;

	protected Func<Vector3, float> Vector3V;

	protected Func<Vector3, float> Vector3D;

	protected Func<float, float, Vector3> VectorHV;

	protected Func<float, float, float, Vector3> VectorHVD;

	protected Transform _transform;

	private bool _enabled;

	private MovementAxis _serializedAxis;

	public ProCamera2D ProCamera2D
	{
		get
		{
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Expected O, but got Unknown
			//IL_01d8: Expected I, but got O
			//IL_01e6: Expected I, but got O
			//IL_01f6: Expected O, but got I
			//IL_0276: Expected O, but got I4
			//IL_0232: Expected O, but got I
			//IL_0268: Expected O, but got I4
			ProCamera2D pc2D = _pc2D;
			UnityEngine.Object obj3;
			UnityEngine.Object pc2D4;
			object obj6;
			if ((object)_pc2D == null || ((UnityEngine.Object)pc2D).m_CachedPtr == (IntPtr)0)
			{
				ProCamera2D component = GetComponent<ProCamera2D>();
				_pc2D = component;
				ProCamera2D pc2D2 = _pc2D;
				if ((object)_pc2D == null || ((UnityEngine.Object)pc2D2).m_CachedPtr == (IntPtr)0)
				{
					Camera main = Camera.main;
					if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
					{
						Camera main2 = Camera.main;
						if ((object)main2 == null)
						{
							return (ProCamera2D)(object)new NullReferenceException();
						}
						ProCamera2D component2 = main2.GetComponent<ProCamera2D>();
						_pc2D = component2;
					}
				}
				ProCamera2D pc2D3 = _pc2D;
				if ((object)_pc2D == null || ((UnityEngine.Object)pc2D3).m_CachedPtr == (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj2 = default(object);
					object obj = obj2 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type type2 = default(Type);
					Type type = type2;
					obj3 = UnityEngine.Object.FindObjectOfType(type);
					bool flag = (object)obj3 == null;
					pc2D4 = null;
					if (flag)
					{
						goto IL_0344;
					}
					nint num = (nint)obj3;
					nint num2 = (nint)typeof(ProCamera2D);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rdx_v11 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2D>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r9_v4 (Il2CppClass<UnityEngine.Object>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rdx_v11 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.ProCamera2D>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r9_v4 (Il2CppClass<UnityEngine.Object>)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rax_v37+FFFFFFF8+v775 @ rax_v33*8]");
						if (0 == (nint)typeof(ProCamera2D))
						{
							obj6 = 1;
							goto IL_0353;
						}
					}
					obj6 = 0;
					goto IL_0353;
				}
			}
			goto IL_02c9;
			IL_0353:
			bool flag2 = obj6 == null;
			pc2D4 = null;
			if (!flag2)
			{
				pc2D4 = obj3;
			}
			goto IL_0344;
			IL_0344:
			_pc2D = (ProCamera2D)pc2D4;
			goto IL_02c9;
			IL_02c9:
			return _pc2D;
		}
		set
		{
			_pc2D = value;
		}
	}

	protected virtual void Awake()
	{
		//IL_006a: Expected O, but got I4
		Transform transform = base.transform;
		_transform = transform;
		while (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
		}
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			Enable();
		}
		ResetAxisFunctions();
	}

	protected virtual void OnEnable()
	{
		Enable();
	}

	protected virtual void OnDisable()
	{
		Disable();
	}

	protected virtual void OnDestroy()
	{
		Disable();
	}

	public virtual void OnReset()
	{
	}

	private void Enable()
	{
		//IL_007a: Expected I, but got O
		if (_enabled)
		{
			return;
		}
		ProCamera2D pc2D = _pc2D;
		if ((object)_pc2D == null || ((UnityEngine.Object)pc2D).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ProCamera2D pc2D2 = _pc2D;
		_enabled = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ r8_v5 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.BasePC2D>)+1E0]");
		Action b = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Delegate obj = Delegate.Combine(pc2D2.OnReset, b);
		if ((object)obj == null)
		{
			pc2D2.OnReset = (Action)obj;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			pc2D2.OnReset = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			if ((object)obj3 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void Disable()
	{
		//IL_008a: Expected I, but got O
		ProCamera2D pc2D = _pc2D;
		if ((object)_pc2D == null || ((UnityEngine.Object)pc2D).m_CachedPtr == (IntPtr)0 || !_enabled)
		{
			return;
		}
		ProCamera2D pc2D2 = _pc2D;
		_enabled = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v4 (Il2CppClass<Com.LuisPedroFonseca.ProCamera2D.BasePC2D>)+1E0]");
		Action value = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Delegate obj = Delegate.Remove(pc2D2.OnReset, value);
		if ((object)obj == null)
		{
			pc2D2.OnReset = (Action)obj;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			pc2D2.OnReset = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			if ((object)obj3 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void ResetAxisFunctions()
	{
		//IL_0089: Expected O, but got I4
		if (Vector3H != null)
		{
			return;
		}
		ProCamera2D proCamera2D = ProCamera2D;
		if ((object)proCamera2D == null || ((UnityEngine.Object)proCamera2D).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ProCamera2D pc2D = _pc2D;
		bool flag = pc2D.Axis == MovementAxis.XY;
		Func<float, float, float, Vector3> vectorHVD;
		if (!flag)
		{
			object obj = pc2D.Axis - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					return;
				}
				Func<Vector3, float> vector3H = _003C_003Ec._003C_003E9__19_10;
				if (_003C_003Ec._003C_003E9__19_10 == null)
				{
					Func<Vector3, float> func = null;
					float num = ((_003C_003Ec)(object)func)._003CResetAxisFunctions_003Eb__19_10((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_10 = func;
					vector3H = func;
				}
				Vector3H = vector3H;
				Func<Vector3, float> vector3V = _003C_003Ec._003C_003E9__19_11;
				if (_003C_003Ec._003C_003E9__19_11 == null)
				{
					Func<Vector3, float> func2 = null;
					float num2 = ((_003C_003Ec)(object)func2)._003CResetAxisFunctions_003Eb__19_11((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_11 = func2;
					vector3V = func2;
				}
				Vector3V = vector3V;
				Func<Vector3, float> vector3D = _003C_003Ec._003C_003E9__19_12;
				if (_003C_003Ec._003C_003E9__19_12 == null)
				{
					Func<Vector3, float> func3 = null;
					float num3 = ((_003C_003Ec)(object)func3)._003CResetAxisFunctions_003Eb__19_12((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_12 = func3;
					vector3D = func3;
				}
				Vector3D = vector3D;
				Func<float, float, Vector3> vectorHV = _003C_003Ec._003C_003E9__19_13;
				if (_003C_003Ec._003C_003E9__19_13 == null)
				{
					Func<float, float, Vector3> func4 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__19_13 = func4;
					vectorHV = func4;
				}
				VectorHV = vectorHV;
				vectorHVD = _003C_003Ec._003C_003E9__19_14;
				if (_003C_003Ec._003C_003E9__19_14 == null)
				{
					Func<float, float, float, Vector3> func5 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
					_003C_003Ec._003C_003E9__19_14 = func5;
					vectorHVD = func5;
				}
			}
			else
			{
				Func<Vector3, float> vector3H2 = _003C_003Ec._003C_003E9__19_5;
				if (_003C_003Ec._003C_003E9__19_5 == null)
				{
					Func<Vector3, float> func6 = null;
					float num4 = ((_003C_003Ec)(object)func6)._003CResetAxisFunctions_003Eb__19_5((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_5 = func6;
					vector3H2 = func6;
				}
				Vector3H = vector3H2;
				Func<Vector3, float> vector3V2 = _003C_003Ec._003C_003E9__19_6;
				if (_003C_003Ec._003C_003E9__19_6 == null)
				{
					Func<Vector3, float> func7 = null;
					float num5 = ((_003C_003Ec)(object)func7)._003CResetAxisFunctions_003Eb__19_6((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_6 = func7;
					vector3V2 = func7;
				}
				Vector3V = vector3V2;
				Func<Vector3, float> vector3D2 = _003C_003Ec._003C_003E9__19_7;
				if (_003C_003Ec._003C_003E9__19_7 == null)
				{
					Func<Vector3, float> func8 = null;
					float num6 = ((_003C_003Ec)(object)func8)._003CResetAxisFunctions_003Eb__19_7((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__19_7 = func8;
					vector3D2 = func8;
				}
				Vector3D = vector3D2;
				Func<float, float, Vector3> vectorHV2 = _003C_003Ec._003C_003E9__19_8;
				if (_003C_003Ec._003C_003E9__19_8 == null)
				{
					Func<float, float, Vector3> func9 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__19_8 = func9;
					vectorHV2 = func9;
				}
				VectorHV = vectorHV2;
				vectorHVD = _003C_003Ec._003C_003E9__19_9;
				if (_003C_003Ec._003C_003E9__19_9 == null)
				{
					Func<float, float, float, Vector3> func10 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
					_003C_003Ec._003C_003E9__19_9 = func10;
					vectorHVD = func10;
				}
			}
		}
		else
		{
			Func<Vector3, float> vector3H3 = _003C_003Ec._003C_003E9__19_0;
			if (_003C_003Ec._003C_003E9__19_0 == null)
			{
				Func<Vector3, float> func11 = null;
				float num7 = ((_003C_003Ec)(object)func11)._003CResetAxisFunctions_003Eb__19_0((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__19_0 = func11;
				vector3H3 = func11;
			}
			Vector3H = vector3H3;
			Func<Vector3, float> vector3V3 = _003C_003Ec._003C_003E9__19_1;
			if (_003C_003Ec._003C_003E9__19_1 == null)
			{
				Func<Vector3, float> func12 = null;
				float num8 = ((_003C_003Ec)(object)func12)._003CResetAxisFunctions_003Eb__19_1((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__19_1 = func12;
				vector3V3 = func12;
			}
			Vector3V = vector3V3;
			Func<Vector3, float> vector3D3 = _003C_003Ec._003C_003E9__19_2;
			if (_003C_003Ec._003C_003E9__19_2 == null)
			{
				Func<Vector3, float> func13 = null;
				float num9 = ((_003C_003Ec)(object)func13)._003CResetAxisFunctions_003Eb__19_2((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__19_2 = func13;
				vector3D3 = func13;
			}
			Vector3D = vector3D3;
			Func<float, float, Vector3> vectorHV3 = _003C_003Ec._003C_003E9__19_3;
			if (_003C_003Ec._003C_003E9__19_3 == null)
			{
				Func<float, float, Vector3> func14 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
				_003C_003Ec._003C_003E9__19_3 = func14;
				vectorHV3 = func14;
			}
			VectorHV = vectorHV3;
			vectorHVD = _003C_003Ec._003C_003E9__19_4;
			if (_003C_003Ec._003C_003E9__19_4 == null)
			{
				Func<float, float, float, Vector3> func15 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
				_003C_003Ec._003C_003E9__19_4 = func15;
				vectorHVD = func15;
			}
		}
		VectorHVD = vectorHVD;
	}

	public void OnBeforeSerialize()
	{
		ProCamera2D proCamera2D = ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = ProCamera2D;
			_serializedAxis = proCamera2D2.Axis;
		}
	}

	public void OnAfterDeserialize()
	{
		//IL_0015: Expected O, but got I4
		bool flag = _serializedAxis == MovementAxis.XY;
		if (!flag)
		{
			object obj = _serializedAxis - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				Func<Vector3, float> vector3H = _003C_003Ec._003C_003E9__21_10;
				if (_003C_003Ec._003C_003E9__21_10 == null)
				{
					Func<Vector3, float> func = null;
					float num = ((_003C_003Ec)(object)func)._003COnAfterDeserialize_003Eb__21_10((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_10 = func;
					vector3H = func;
				}
				Vector3H = vector3H;
				Func<Vector3, float> vector3V = _003C_003Ec._003C_003E9__21_11;
				if (_003C_003Ec._003C_003E9__21_11 == null)
				{
					Func<Vector3, float> func2 = null;
					float num2 = ((_003C_003Ec)(object)func2)._003COnAfterDeserialize_003Eb__21_11((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_11 = func2;
					vector3V = func2;
				}
				Vector3V = vector3V;
				Func<Vector3, float> vector3D = _003C_003Ec._003C_003E9__21_12;
				if (_003C_003Ec._003C_003E9__21_12 == null)
				{
					Func<Vector3, float> func3 = null;
					float num3 = ((_003C_003Ec)(object)func3)._003COnAfterDeserialize_003Eb__21_12((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_12 = func3;
					vector3D = func3;
				}
				Vector3D = vector3D;
				Func<float, float, Vector3> vectorHV = _003C_003Ec._003C_003E9__21_13;
				if (_003C_003Ec._003C_003E9__21_13 == null)
				{
					Func<float, float, Vector3> func4 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__21_13 = func4;
					vectorHV = func4;
				}
				VectorHV = vectorHV;
				Func<float, float, float, Vector3> vectorHVD = _003C_003Ec._003C_003E9__21_14;
				if (_003C_003Ec._003C_003E9__21_14 == null)
				{
					Func<float, float, float, Vector3> func5 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
					_003C_003Ec._003C_003E9__21_14 = func5;
					vectorHVD = func5;
				}
				VectorHVD = vectorHVD;
			}
			else
			{
				Func<Vector3, float> vector3H2 = _003C_003Ec._003C_003E9__21_5;
				if (_003C_003Ec._003C_003E9__21_5 == null)
				{
					Func<Vector3, float> func6 = null;
					float num4 = ((_003C_003Ec)(object)func6)._003COnAfterDeserialize_003Eb__21_5((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_5 = func6;
					vector3H2 = func6;
				}
				Vector3H = vector3H2;
				Func<Vector3, float> vector3V2 = _003C_003Ec._003C_003E9__21_6;
				if (_003C_003Ec._003C_003E9__21_6 == null)
				{
					Func<Vector3, float> func7 = null;
					float num5 = ((_003C_003Ec)(object)func7)._003COnAfterDeserialize_003Eb__21_6((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_6 = func7;
					vector3V2 = func7;
				}
				Vector3V = vector3V2;
				Func<Vector3, float> vector3D2 = _003C_003Ec._003C_003E9__21_7;
				if (_003C_003Ec._003C_003E9__21_7 == null)
				{
					Func<Vector3, float> func8 = null;
					float num6 = ((_003C_003Ec)(object)func8)._003COnAfterDeserialize_003Eb__21_7((Vector3)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__21_7 = func8;
					vector3D2 = func8;
				}
				Vector3D = vector3D2;
				Func<float, float, Vector3> vectorHV2 = _003C_003Ec._003C_003E9__21_8;
				if (_003C_003Ec._003C_003E9__21_8 == null)
				{
					Func<float, float, Vector3> func9 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
					_003C_003Ec._003C_003E9__21_8 = func9;
					vectorHV2 = func9;
				}
				VectorHV = vectorHV2;
				Func<float, float, float, Vector3> vectorHVD2 = _003C_003Ec._003C_003E9__21_9;
				if (_003C_003Ec._003C_003E9__21_9 == null)
				{
					Func<float, float, float, Vector3> func10 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
					_003C_003Ec._003C_003E9__21_9 = func10;
					vectorHVD2 = func10;
				}
				VectorHVD = vectorHVD2;
			}
		}
		else
		{
			Func<Vector3, float> vector3H3 = _003C_003Ec._003C_003E9__21_0;
			if (_003C_003Ec._003C_003E9__21_0 == null)
			{
				Func<Vector3, float> func11 = null;
				float num7 = ((_003C_003Ec)(object)func11)._003COnAfterDeserialize_003Eb__21_0((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__21_0 = func11;
				vector3H3 = func11;
			}
			Vector3H = vector3H3;
			Func<Vector3, float> vector3V3 = _003C_003Ec._003C_003E9__21_1;
			if (_003C_003Ec._003C_003E9__21_1 == null)
			{
				Func<Vector3, float> func12 = null;
				float num8 = ((_003C_003Ec)(object)func12)._003COnAfterDeserialize_003Eb__21_1((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__21_1 = func12;
				vector3V3 = func12;
			}
			Vector3V = vector3V3;
			Func<Vector3, float> vector3D3 = _003C_003Ec._003C_003E9__21_2;
			if (_003C_003Ec._003C_003E9__21_2 == null)
			{
				Func<Vector3, float> func13 = null;
				float num9 = ((_003C_003Ec)(object)func13)._003COnAfterDeserialize_003Eb__21_2((Vector3)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__21_2 = func13;
				vector3D3 = func13;
			}
			Vector3D = vector3D3;
			Func<float, float, Vector3> vectorHV3 = _003C_003Ec._003C_003E9__21_3;
			if (_003C_003Ec._003C_003E9__21_3 == null)
			{
				Func<float, float, Vector3> func14 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7230");
				_003C_003Ec._003C_003E9__21_3 = func14;
				vectorHV3 = func14;
			}
			VectorHV = vectorHV3;
			Func<float, float, float, Vector3> vectorHVD3 = _003C_003Ec._003C_003E9__21_4;
			if (_003C_003Ec._003C_003E9__21_4 == null)
			{
				Func<float, float, float, Vector3> func15 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B7300");
				_003C_003Ec._003C_003E9__21_4 = func15;
				vectorHVD3 = func15;
			}
			VectorHVD = vectorHVD3;
		}
	}

	protected BasePC2D()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

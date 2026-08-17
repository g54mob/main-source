using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DLetterbox : MonoBehaviour
{
	private sealed class _003CTweenToRoutine_003Ed__13(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DLetterbox _003C_003E4__this;

		public float duration;

		public float targetAmount;

		private float _003CinitialAmount_003E5__2;

		private float _003Ct_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_008c: Expected I4, but got I8
			//IL_02a8: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0078: Expected I4, but got I8
			//IL_005b: Expected I4, but got I8
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_0168: Invalid comparison between I4 and F4
			//IL_01b3: Expected F4, but got I4
			//IL_0328: Invalid comparison between I4 and F4
			//IL_01ef: Expected F4, but got I4
			ProCamera2DLetterbox proCamera2DLetterbox = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool result;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					bool flag2 = (nint)obj != 1;
					result = false;
					if (!flag2)
					{
						_003C_003E1__state = -1;
						result = false;
					}
					goto IL_02d1;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_029a;
				}
				_003CinitialAmount_003E5__2 = proCamera2DLetterbox.Amount;
				_003Ct_003E5__3 = 0f;
			}
			if (!(1f < _003Ct_003E5__3))
			{
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					if (instance.IgnoreTimeScale)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
					}
					object obj3 = default(object);
					object obj2 = obj3 / duration;
					float num = (_003Ct_003E5__3 = (float)obj2 + _003Ct_003E5__3);
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
					float num2 = num * (float)Math.PI;
					float num3 = num2 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					if (!(0f > num3))
					{
						if (num3 > 1f)
						{
							num3 = 1f;
						}
					}
					else
					{
						num3 = 0f;
					}
					if ((object)_003C_003E4__this != null)
					{
						float num4 = targetAmount - _003CinitialAmount_003E5__2;
						float num5 = num4 * num3;
						float amount = num5 + _003CinitialAmount_003E5__2;
						proCamera2DLetterbox.Amount = amount;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						goto IL_035b;
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				proCamera2DLetterbox.Amount = targetAmount;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				goto IL_035b;
			}
			goto IL_029a;
			IL_02d1:
			return result;
			IL_035b:
			result = true;
			goto IL_02d1;
			IL_029a:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public float Amount;

	public Color Color;

	private Material _material;

	private int TopPropertyID;

	private int BottomPropertyID;

	private int ColorPropertyID;

	private float _previousAmount;

	private Material material
	{
		get
		{
			Material material = _material;
			if ((object)_material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				return _material;
			}
			Shader shader = Shader.Find("Hidden/ProCamera2D/Letterbox");
			Material material2 = new Material(shader);
			if ((object)material2 != null)
			{
				material2.hideFlags = HideFlags.HideAndDontSave;
				_material = material2;
				return _material;
			}
			return (Material)(object)new NullReferenceException();
		}
	}

	private void OnEnable()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C34F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_previousAmount = 3.4028235E+38f;
		if (TopPropertyID == 0)
		{
			int topPropertyID = Shader.PropertyToID("_Top");
			TopPropertyID = topPropertyID;
		}
		if (BottomPropertyID == 0)
		{
			int bottomPropertyID = Shader.PropertyToID("_Bottom");
			BottomPropertyID = bottomPropertyID;
		}
		if (ColorPropertyID == 0)
		{
			int colorPropertyID = Shader.PropertyToID("_Color");
			ColorPropertyID = colorPropertyID;
		}
	}

	private unsafe void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007b: Invalid comparison between O and F4
		//IL_00a7: Invalid comparison between I4 and F4
		//IL_00f2: Expected F4, but got I4
		//IL_0162: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj = default(object);
		if (obj == null)
		{
			Material material = this.material;
			if ((object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				float num = Amount - _previousAmount;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj2 = num & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f))
				{
					float num2 = Amount;
					if (!(0f > Amount))
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
					Amount = num2;
					Material material2 = this.material;
					float value = 1f - Amount;
					material2.SetFloatImpl(TopPropertyID, value);
					Material material3 = this.material;
					material3.SetFloatImpl(BottomPropertyID, Amount);
					Material material4 = this.material;
					object obj3 = default(object);
					material4.SetColor(ColorPropertyID, (Color)(&obj3));
				}
				Material mat = this.material;
				Graphics.Blit(sourceTexture, destTexture, mat);
				_previousAmount = Amount;
				return;
			}
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	private void OnDisable()
	{
		Material material = _material;
		if ((object)_material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.DestroyImmediate(_material, allowDestroyingAssets: false);
		}
	}

	public void TweenTo(float targetAmount, float duration)
	{
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)this).m_CachedPtr);
		_003CTweenToRoutine_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.targetAmount = targetAmount;
		obj.duration = duration;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator TweenToRoutine(float targetAmount, float duration)
	{
		_003CTweenToRoutine_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.targetAmount = targetAmount;
		obj.duration = duration;
		return obj;
	}

	public ProCamera2DLetterbox()
	{
		//IL_0020: Expected I, but got O
		_previousAmount = 3.4028235E+38f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

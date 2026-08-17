using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DContentFitter : BasePC2D, ISizeOverrider
{
	private sealed class _003CStart_003Ed__34(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DContentFitter _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00bc: Expected I4, but got I8
			//IL_0254: Expected I4, but got O
			//IL_01f0: Invalid comparison between F4 and I4
			ProCamera2DContentFitter proCamera2DContentFitter = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if ((proCamera2DContentFitter._useLetterOrPillarboxing ? 1 : 0) != _003C_003E1__state)
					{
						_003C_003E4__this.CreateLetterPillarboxingCamera();
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0285;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (proCamera2DContentFitter._contentFitterMode != ContentFitterMode.AspectRatio)
					{
						goto IL_0285;
					}
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D2 != null && (object)proCamera2D2.GameCamera != null)
						{
							float aspect = proCamera2D2.GameCamera.aspect;
							float num = proCamera2DContentFitter._targetWidth * 0.5f;
							float num2 = proCamera2DContentFitter._targetHeight * 0.5f;
							float num3 = num / aspect;
							bool flag = num2 < num3;
							float num4 = num2 - num3;
							bool flag2 = num4 == 0f;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							bool isPillarbox = flag4 & flag3;
							float verticalAlignment = default(float);
							UpdateCameraAlignment(proCamera2D.GameCamera, isPillarbox, proCamera2DContentFitter._targetAspectRatio, proCamera2DContentFitter.HorizontalAlignment, verticalAlignment);
							goto IL_0285;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0285:
			return false;
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

	private sealed class _003CUpdateFixedAspectRatio_003Ed__42(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DContentFitter _003C_003E4__this;

		private bool _003CisPillarbox_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_01f7: Expected I4, but got I8
			//IL_0298: Expected I4, but got O
			//IL_00a7: Invalid comparison between F4 and I4
			//IL_0277: Expected F4, but got I
			//IL_0277: Expected F4, but got I
			//IL_01a8: Expected F4, but got I
			//IL_01a8: Expected F4, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			float verticalAlignment = default(float);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+68]");
					float num = 0f * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+6C]");
					float num2 = 0f * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
					object obj = default(object);
					float num3 = num2 / (float)obj;
					bool flag = num < num3;
					float num4 = num - num3;
					bool flag2 = num4 == 0f;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool flag5 = flag4 & flag3;
					_003CisPillarbox_003E5__2 = flag5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+94]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+64]");
					if (num5 != 0)
					{
						ProCamera2DContentFitter proCamera2DContentFitter = _003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+64]");
						proCamera2DContentFitter.ToggleLetterPillarboxing(value: false);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+64]");
					if ((nint)0 != 0)
					{
						ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D == null)
						{
							goto IL_028a;
						}
						Camera gameCamera = proCamera2D.GameCamera;
						bool isPillarbox = _003CisPillarbox_003E5__2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+78]");
						UpdateLetterPillarbox(gameCamera, isPillarbox, num6, 0f, verticalAlignment);
					}
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_027c;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D2 != null)
					{
						Camera gameCamera2 = proCamera2D2.GameCamera;
						bool isPillarbox2 = _003CisPillarbox_003E5__2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+78]");
						UpdateCameraAlignment(gameCamera2, isPillarbox2, num7, 0f, verticalAlignment);
						goto IL_027c;
					}
				}
			}
			goto IL_028a;
			IL_027c:
			return false;
			IL_028a:
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

	public static string ExtensionName = "Content Fitter";

	private ContentFitterMode _contentFitterMode;

	private bool _useLetterOrPillarboxing;

	private float _targetHeight;

	private float _targetWidth;

	private float _targetAspectRatio;

	public float VerticalAlignment;

	public float HorizontalAlignment;

	private float _prevTargetHeight;

	private float _prevTargetWidth;

	private float _prevTargetAspectRatio;

	private float _prevAspectRatio;

	private float _prevVerticalAlignment;

	private float _prevHorizontalAlignment;

	private bool _prevUseLetterOrPillarboxing;

	private Camera _letterPillarboxingCamera;

	private int _soOrder;

	public ContentFitterMode ContentFitterMode
	{
		get
		{
			return _contentFitterMode;
		}
		set
		{
			_contentFitterMode = value;
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				Camera gameCamera = proCamera2D.GameCamera;
				if ((object)proCamera2D.GameCamera != null)
				{
					bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
					Camera.ResetProjectionMatrix_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
					if (_contentFitterMode == ContentFitterMode.AspectRatio)
					{
						float num = (_targetWidth = _targetAspectRatio * _targetHeight);
						float targetHeight;
						if (_contentFitterMode == ContentFitterMode.AspectRatio)
						{
							targetHeight = num / _targetAspectRatio;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
							object obj = default(object);
							targetHeight = num / (float)obj;
						}
						_targetHeight = targetHeight;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	public bool UseLetterOrPillarboxing
	{
		get
		{
			return _useLetterOrPillarboxing;
		}
		set
		{
			_useLetterOrPillarboxing = value;
			ToggleLetterPillarboxing(value);
		}
	}

	private static float ScreenAspectRatio
	{
		get
		{
			//IL_000e: Expected O, but got I4
			//IL_001c: Expected O, but got I4
			object obj = Screen.width;
			object obj2 = Screen.height;
			return (float)obj / (float)obj2;
		}
	}

	public float TargetHeight
	{
		get
		{
			return _targetHeight;
		}
		set
		{
			_targetHeight = value;
			float targetAspectRatio = default(float);
			if (_contentFitterMode == ContentFitterMode.AspectRatio)
			{
				targetAspectRatio = _targetAspectRatio;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
			}
			float targetWidth = targetAspectRatio * value;
			_targetWidth = targetWidth;
		}
	}

	public float TargetWidth
	{
		get
		{
			return _targetWidth;
		}
		set
		{
			_targetWidth = value;
			if (_contentFitterMode == ContentFitterMode.AspectRatio)
			{
				float targetHeight = value / _targetAspectRatio;
				_targetHeight = targetHeight;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
				object obj = default(object);
				float targetHeight2 = value / (float)obj;
				_targetHeight = targetHeight2;
			}
		}
	}

	public float TargetAspectRatio
	{
		get
		{
			return _targetAspectRatio;
		}
		set
		{
			_targetAspectRatio = value;
			float targetWidth = value * _targetHeight;
			_targetWidth = targetWidth;
		}
	}

	public int SOOrder
	{
		get
		{
			return _soOrder;
		}
		set
		{
			_soOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddSizeOverrider(this);
	}

	private IEnumerator Start()
	{
		_003CStart_003Ed__34 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._sizeOverriders).Remove((object)this);
		}
	}

	public float OverrideSize(float deltaTime, float originalSize)
	{
		//IL_0062: Expected O, but got I4
		//IL_0039->IL0082: Incompatible stack heights: 1 vs 0
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj == null)
			{
				return originalSize;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 102 Invalid \"Jump target not found in method: 0x1851B15B0\"");
		}
		throw new NullReferenceException();
	}

	private float GetSize(ContentFitterMode mode)
	{
		//IL_002b: Expected O, but got I4
		bool flag = mode == ContentFitterMode.AspectRatio;
		if (!flag)
		{
			object obj = mode - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					return _targetHeight * 0.5f;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null && (object)proCamera2D.GameCamera != null)
			{
				float num = _targetWidth * 0.5f;
				float aspect = proCamera2D.GameCamera.aspect;
				return num / aspect;
			}
			goto IL_0455;
		}
		float num2 = _prevTargetWidth;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851B16D6h\"");
		float num3;
		if (_prevTargetWidth == _targetWidth)
		{
			num2 = _prevTargetHeight;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B16D6h\"");
			if (_prevTargetHeight == _targetHeight)
			{
				num2 = _prevTargetAspectRatio;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B16D6h\"");
				if (_prevTargetAspectRatio == _targetAspectRatio)
				{
					ProCamera2D proCamera2D2 = base.ProCamera2D;
					if ((object)proCamera2D2 == null || (object)proCamera2D2.GameCamera == null)
					{
						goto IL_0455;
					}
					num2 = proCamera2D2.GameCamera.aspect;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B16D6h\"");
					if (_prevAspectRatio == num2)
					{
						num2 = _prevVerticalAlignment;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B16D6h\"");
						if (_prevVerticalAlignment == VerticalAlignment)
						{
							num2 = _prevHorizontalAlignment;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B16D6h\"");
							if (_prevHorizontalAlignment == HorizontalAlignment)
							{
								bool flag2 = _prevUseLetterOrPillarboxing == _useLetterOrPillarboxing;
								num3 = _prevHorizontalAlignment;
								if (flag2)
								{
									goto IL_02dc;
								}
							}
						}
					}
				}
			}
		}
		_003CUpdateFixedAspectRatio_003Ed__42 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
		num3 = num2;
		goto IL_02dc;
		IL_02dc:
		_prevTargetWidth = _targetWidth;
		_prevTargetHeight = _targetHeight;
		_prevTargetAspectRatio = _targetAspectRatio;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		bool flag3 = (object)proCamera2D3 == null;
		num2 = num3;
		if (!flag3)
		{
			bool flag4 = (object)proCamera2D3.GameCamera == null;
			num2 = num3;
			if (!flag4)
			{
				num2 = proCamera2D3.GameCamera.aspect;
				_prevVerticalAlignment = VerticalAlignment;
				_prevHorizontalAlignment = HorizontalAlignment;
				_prevUseLetterOrPillarboxing = _useLetterOrPillarboxing;
				_prevAspectRatio = num2;
				ProCamera2D proCamera2D4 = base.ProCamera2D;
				if ((object)proCamera2D4 != null && (object)proCamera2D4.GameCamera != null)
				{
					float num4 = _targetWidth * 0.5f;
					float aspect2 = proCamera2D4.GameCamera.aspect;
					float num5 = _targetHeight * 0.5f;
					float num6 = num4 / aspect2;
					if (!(num5 > num6))
					{
						num5 = num6;
					}
					return num5;
				}
			}
		}
		goto IL_0455;
		IL_0455:
		throw new NullReferenceException();
	}

	private IEnumerator UpdateFixedAspectRatio()
	{
		_003CUpdateFixedAspectRatio_003Ed__42 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe static void UpdateCameraAlignment(Camera cam, bool isPillarbox, float targetAspectRatio, float horizontalAlignment, float verticalAlignment)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_00ee: Expected F4, but got I4
		//IL_008d: Expected F4, but got I4
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 79;
		bool flag = ((UnityEngine.Object)cam).m_CachedPtr == (IntPtr)0;
		Camera.ResetProjectionMatrix_Injected(((UnityEngine.Object)cam).m_CachedPtr);
		if (isPillarbox)
		{
			float aspect = cam.aspect;
			float num = targetAspectRatio / aspect;
			float num2 = num * 0.5f;
			float num3 = num2 - 0.5f;
			float num4 = num3 * horizontalAlignment;
			float num5 = num4;
			float num6 = 0f;
		}
		else
		{
			float aspect2 = cam.aspect;
			float num7 = aspect2 / targetAspectRatio;
			float num8 = num7 * 0.5f;
			float num9 = num8 - 0.5f;
			float num10 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			float num6 = num10 * 0f;
			float num5 = 0f;
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag2 = ((UnityEngine.Object)cam).m_CachedPtr == (IntPtr)0;
		object obj3 = obj - 105;
		Camera.get_projectionMatrix_Injected(((UnityEngine.Object)cam).m_CachedPtr, out *(Matrix4x4*)obj3);
		Matrix4x4 camProjectionMatrix = (Matrix4x4)(obj - 41);
		Rect targetScissor = (Rect)(obj - 121);
		_ = 1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		_ = 0;
		_ = 1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Matrix4x4 scissorRect = GetScissorRect(targetScissor, camProjectionMatrix);
		_ = scissorRect.m00;
		_ = scissorRect.m01;
		_ = scissorRect.m02;
		_ = scissorRect.m03;
		bool flag3 = ((UnityEngine.Object)cam).m_CachedPtr == (IntPtr)0;
		object obj4 = obj - 41;
		Camera.set_projectionMatrix_Injected(((UnityEngine.Object)cam).m_CachedPtr, ref *(Matrix4x4*)obj4);
	}

	private unsafe static Matrix4x4 GetScissorRect(Rect targetScissor, Matrix4x4 camProjectionMatrix)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00ad: Expected O, but got I
		//IL_00e1: Expected O, but got Ref
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0122: Expected O, but got F4
		//IL_0172: Expected native int or pointer, but got O
		//IL_0184: Expected native int or pointer, but got O
		//IL_0196: Expected native int or pointer, but got O
		//IL_01a8: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = obj2 - 200;
		_ = Quaternion.identityQuaternion;
		_ = 0;
		_ = 0;
		object obj3 = obj + 32;
		Vector3 pos = default(Vector3);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos, ref *(Quaternion*)obj3, ref s, out Matrix4x4 ret);
		_ = Quaternion.identityQuaternion;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		object obj4 = obj - 96;
		object obj5 = obj + 48;
		Vector3 pos2 = default(Vector3);
		Vector3 s2 = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos2, ref *(Quaternion*)obj5, ref s2, out *(Matrix4x4*)obj4);
		Matrix4x4 matrix4x = (Matrix4x4)(obj - 32);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-80]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-30]");
		_ = 0;
		Matrix4x4 matrix4x2 = (Matrix4x4)(&ret) * matrix4x;
		Matrix4x4 matrix4x3 = (Matrix4x4)(obj - 32);
		Matrix4x4 matrix4x4 = (Matrix4x4)(obj - 96);
		_ = camProjectionMatrix.m00;
		_ = camProjectionMatrix.m01;
		obj = camProjectionMatrix.m02;
		_ = camProjectionMatrix.m03;
		_ = matrix4x2.m00;
		_ = matrix4x2.m01;
		_ = matrix4x2.m02;
		_ = matrix4x2.m03;
		Matrix4x4 matrix4x5 = matrix4x4 * matrix4x3;
		Matrix4x4 matrix4x6 = default(Matrix4x4);
		((Matrix4x4*)(nint)matrix4x6)->m00 = matrix4x5.m00;
		((Matrix4x4*)(nint)matrix4x6)->m01 = matrix4x5.m01;
		((Matrix4x4*)(nint)matrix4x6)->m02 = matrix4x5.m02;
		((Matrix4x4*)(nint)matrix4x6)->m03 = matrix4x5.m03;
		return matrix4x6;
	}

	private static void UpdateLetterPillarbox(Camera cam, bool isPillarbox, float targetAspectRatio, float horizontalAlignment, float verticalAlignment)
	{
		//IL_00c1: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_003c: Expected O, but got I
		//IL_001e: Expected O, but got I
		//IL_0027: Expected F4, but got I4
		//IL_0074->IL0074: Incompatible stack heights: 2 vs 0
		Camera camera = default(Camera);
		bool num7;
		float num2;
		float num4;
		float num6;
		IntPtr cachedPtr;
		object obj4;
		float num8;
		if (isPillarbox)
		{
			object obj = Screen.width;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
			object obj2 = Screen.height;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
			object obj3 = 0 / 0;
			float num = targetAspectRatio / (float)obj3;
			num2 = 1f - num;
			float num3 = num2 * 0.5f;
			num4 = num2 * 0.5f;
			float num5 = num3 * horizontalAlignment;
			num6 = num5 + num4;
			cachedPtr = ((UnityEngine.Object)camera).m_CachedPtr;
			bool flag = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
			num7 = flag;
			obj4 = 0;
			bool flag2 = (nint)0 != 0;
			num8 = num6;
			if (flag2)
			{
				goto IL_00ad;
			}
			bool flag3 = (nint)0 == 0;
		}
		object obj5 = Screen.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
		object obj6 = Screen.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
		object obj7 = 0 / 0;
		float num9 = (float)obj7 / targetAspectRatio;
		num2 = 1f - num9;
		float num10 = num2 * 0.5f;
		num4 = num2 * 0.5f;
		object obj8 = default(object);
		float num11 = num10 * (float)obj8;
		num6 = num11 + num4;
		cachedPtr = ((UnityEngine.Object)camera).m_CachedPtr;
		bool flag4 = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
		num7 = flag4;
		obj4 = 0;
		num8 = 0f;
		goto IL_00ad;
		IL_00ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v622 @ rax_v18 (should have been resolved before IL gen)");
	}

	private void ToggleLetterPillarboxing(bool value)
	{
		//IL_0129: Invalid comparison between F4 and I4
		//IL_02b9: Invalid comparison between F4 and I4
		//IL_030e->IL0179: Incompatible stack heights: 1 vs 0
		Component letterPillarboxingCamera2;
		if (value)
		{
			Camera letterPillarboxingCamera = _letterPillarboxingCamera;
			if ((object)_letterPillarboxingCamera == null || ((UnityEngine.Object)letterPillarboxingCamera).m_CachedPtr == (IntPtr)0)
			{
				CreateLetterPillarboxingCamera();
				letterPillarboxingCamera2 = _letterPillarboxingCamera;
				goto IL_0352;
			}
		}
		letterPillarboxingCamera2 = _letterPillarboxingCamera;
		if (!value)
		{
			if ((object)_letterPillarboxingCamera == null || ((UnityEngine.Object)letterPillarboxingCamera2).m_CachedPtr == (IntPtr)0)
			{
				goto IL_0226;
			}
			if ((object)_letterPillarboxingCamera != null)
			{
				GameObject gameObject = _letterPillarboxingCamera.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: false);
					goto IL_0226;
				}
			}
			goto IL_030e;
		}
		goto IL_0352;
		IL_0226:
		ProCamera2D proCamera2D = base.ProCamera2D;
		Component gameCamera = proCamera2D.GameCamera;
		bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
		Rect value2 = default(Rect);
		Camera.set_rect_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref value2);
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
		float num = _targetWidth * 0.5f;
		float num2 = _targetHeight * 0.5f;
		object obj = default(object);
		float num3 = num / (float)obj;
		bool flag2 = num2 < num3;
		float num4 = num2 - num3;
		bool flag3 = num4 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		bool isPillarbox = flag5 & flag4;
		float verticalAlignment = default(float);
		UpdateCameraAlignment(proCamera2D2.GameCamera, isPillarbox, _targetAspectRatio, HorizontalAlignment, verticalAlignment);
		return;
		IL_0352:
		if ((object)letterPillarboxingCamera2 != null)
		{
			GameObject gameObject2 = letterPillarboxingCamera2.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: true);
				ProCamera2D proCamera2D3 = base.ProCamera2D;
				if ((object)proCamera2D3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
					float num5 = _targetWidth * 0.5f;
					float num6 = _targetHeight * 0.5f;
					object obj2 = default(object);
					float num7 = num5 / (float)obj2;
					bool flag6 = num6 < num7;
					float num8 = num6 - num7;
					bool flag7 = num8 == 0f;
					bool flag8 = !flag6;
					bool flag9 = !flag7;
					bool isPillarbox2 = flag9 & flag8;
					UpdateLetterPillarbox(proCamera2D3.GameCamera, isPillarbox2, _targetAspectRatio, HorizontalAlignment, verticalAlignment);
					return;
				}
			}
		}
		goto IL_030e;
		IL_030e:
		throw new NullReferenceException();
	}

	private void CreateLetterPillarboxingCamera()
	{
		//IL_01cc: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0063: Expected I, but got O
		//IL_00ef: Expected I, but got O
		//IL_0214: Expected F4, but got I
		//IL_021e: Expected I, but got O
		//IL_027e: Expected I, but got O
		//IL_02d9: Expected I, but got O
		//IL_0238->IL019f: Incompatible stack heights: 1 vs 0
		Type[] array = new Type[1];
		nint num = (nint)typeof(Camera);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (array != null)
		{
			if (num != 0)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			GameObject gameObject = new GameObject("PC2DBackgroundCamera", array);
			if ((object)gameObject != null)
			{
				Camera component = gameObject.GetComponent<Camera>();
				_letterPillarboxingCamera = component;
				nint num3 = (nint)_letterPillarboxingCamera;
				if ((object)_letterPillarboxingCamera != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v17 (Il2CppClass<UnityEngine.Camera>)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v17 (Il2CppClass<UnityEngine.Camera>)+10]");
					Camera.set_depth_Injected((IntPtr)0, 0f);
					nint num4 = (nint)_letterPillarboxingCamera;
					if ((object)_letterPillarboxingCamera != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v18 (Il2CppClass<UnityEngine.Camera>)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v18 (Il2CppClass<UnityEngine.Camera>)+10]");
						Camera.set_clearFlags_Injected((IntPtr)0, CameraClearFlags.Color);
						nint num5 = (nint)_letterPillarboxingCamera;
						bool flag3 = (object)_letterPillarboxingCamera == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rbx_v19 (Il2CppClass<UnityEngine.Camera>)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rbx_v19 (Il2CppClass<UnityEngine.Camera>)+10]");
						Color value = default(Color);
						Camera.set_backgroundColor_Injected((IntPtr)0, ref value);
						nint num6 = (nint)_letterPillarboxingCamera;
						bool flag5 = (object)_letterPillarboxingCamera == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rbx_v20 (Il2CppClass<UnityEngine.Camera>)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rbx_v20 (Il2CppClass<UnityEngine.Camera>)+10]");
						Camera.set_cullingMask_Injected((IntPtr)0, 0);
						bool flag7 = (object)_letterPillarboxingCamera == null;
						Transform transform = _letterPillarboxingCamera.transform;
						bool flag8 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rax_v59 (UnityEngine.Transform)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rax_v59 (UnityEngine.Transform)+10]");
						Vector3 value2 = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value2);
						bool flag10 = (object)_letterPillarboxingCamera == null;
						GameObject gameObject2 = _letterPillarboxingCamera.gameObject;
						bool flag11 = (object)gameObject2 == null;
						gameObject2.hideFlags = HideFlags.HideInHierarchy;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private Vector3[] DrawGizmoRectangle(float x, float y, float width, float height, Color fillColor, Color borderColor)
	{
		float num = width * 0.5f;
		float num2 = x - num;
		object obj = default(object);
		float num3 = (float)obj * 0.5f;
		float num4 = y - num3;
		Vector3[] array = new Vector3[4];
		Func<float, float, float, Vector3> vectorHVD = VectorHVD;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v53 @ rdx_v2 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		if (array.Length > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7+8]");
			_ = 0;
			Func<float, float, float, Vector3> vectorHVD2 = VectorHVD;
			float num5 = num2 + width;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v109 @ rdx_v6 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			if (array.Length > 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v10+8]");
				_ = 0;
				Func<float, float, float, Vector3> vectorHVD3 = VectorHVD;
				float num6 = num4 + (float)obj;
				float num7 = num2 + width;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ rdx_v8 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				if (array.Length > 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v13+8]");
					_ = 0;
					Func<float, float, float, Vector3> vectorHVD4 = VectorHVD;
					float num8 = num4 + (float)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rdx_v10 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
					if (array.Length > 3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v16+8]");
						_ = 0;
						return array;
					}
				}
			}
		}
		return (Vector3[])(object)new IndexOutOfRangeException();
	}

	public ProCamera2DContentFitter()
	{
		//IL_0041: Expected I, but got O
		_targetHeight = 5.625f;
		_targetWidth = 10f;
		_targetAspectRatio = 1.7777778f;
		_soOrder = 5000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DTransitionsFX : BasePC2D
{
	private sealed class _003CTransitionRoutine_003Ed__48(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DTransitionsFX _003C_003E4__this;

		public float startValue;

		public Material material;

		public float endValue;

		public float delay;

		public float duration;

		public EaseType easeType;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0096: Expected I4, but got I8
			//IL_060a: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0082: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_00f0: Expected O, but got I
			//IL_0138: Expected O, but got I
			//IL_006e: Expected I4, but got I8
			//IL_0413: Invalid comparison between F4 and I4
			//IL_01ab: Expected F4, but got I
			//IL_01ab: Expected O, but got I
			//IL_01c0: Invalid comparison between F4 and I4
			//IL_0701: Invalid comparison between F4 and I4
			//IL_04da: Expected O, but got I
			//IL_045f: Expected O, but got I
			//IL_06d8: Invalid comparison between F4 and I4
			//IL_04c5: Expected O, but got I
			//IL_0287: Expected O, but got I
			//IL_020c: Expected O, but got I
			//IL_0272: Expected O, but got I
			//IL_0524: Expected O, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_0529;
						}
						_003C_003E1__state = -1;
						goto IL_0633;
					}
				}
				_003C_003E1__state = -1;
				goto IL_0296;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
					((Behaviour)0).enabled = true;
					_ = startValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
					if ((nint)0 != 0)
					{
						_ = material;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v32+20]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v32+20]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+130]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+110]");
								((Material)num).SetFloatImpl((int)num2, 0f);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CC5E7h\"");
								if (endValue == 0f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
										object obj4 = 0;
										goto IL_0677;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CC604h\"");
									if (endValue == 1f)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+70]");
											object obj4 = 0;
											goto IL_0677;
										}
									}
								}
								goto IL_0652;
							}
						}
					}
				}
			}
			goto IL_05fc;
			IL_0296:
			_003Ct_003E5__2 = 0f;
			goto IL_0633;
			IL_05fc:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_06ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v610 @ rax_v7+18] (should have been resolved before IL gen)");
			goto IL_0686;
			IL_0529:
			return false;
			IL_06bf:
			return true;
			IL_0652:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+80]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+80]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v703 @ rax_v43+18] (should have been resolved before IL gen)");
			}
			if (delay > 0f)
			{
				ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D == null)
				{
					goto IL_05fc;
				}
				if (!proCamera2D.IgnoreTimeScale)
				{
					WaitForSeconds waitForSeconds = null;
					waitForSeconds.m_Seconds = delay;
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
				}
				else
				{
					WaitForSecondsRealtime waitForSecondsRealtime = null;
					waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = delay;
					waitForSecondsRealtime.m_WaitUntilTime = -1f;
					_003C_003E2__current = waitForSecondsRealtime;
					_003C_003E1__state = 1;
				}
				goto IL_06bf;
			}
			goto IL_0296;
			IL_0677:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v701 @ rax_v34+18] (should have been resolved before IL gen)");
			goto IL_0652;
			IL_0686:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+88]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v612 @ rax_v12+18] (should have been resolved before IL gen)");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CC7D7h\"");
			if (endValue == 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
				if ((nint)0 == 0)
				{
					goto IL_05fc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+128]");
				((Behaviour)0).enabled = false;
			}
			goto IL_0529;
			IL_0633:
			if (!(1f < _003Ct_003E5__2))
			{
				if ((object)_003C_003E4__this != null)
				{
					ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D2 != null)
					{
						float num3 = proCamera2D2._003CDeltaTime_003Ek__BackingField / duration;
						float value = Utils.EaseFromTo(value: _003Ct_003E5__2 = num3 + _003Ct_003E5__2, start: startValue, end: endValue, type: easeType);
						if ((object)material != null)
						{
							Material obj7 = material;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+130]");
							obj7.SetFloatImpl(0, value);
							_003C_003E2__current = null;
							_003C_003E1__state = 3;
							goto IL_06bf;
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				_ = endValue;
				if ((object)material != null)
				{
					Material obj8 = material;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+130]");
					obj8.SetFloatImpl(0, endValue);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CC778h\"");
					if (endValue == 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+68]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+68]");
							object obj9 = 0;
							goto IL_06ab;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851CC795h\"");
						if (endValue == 1f)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+78]");
								object obj9 = 0;
								goto IL_06ab;
							}
						}
					}
					goto IL_0686;
				}
			}
			goto IL_05fc;
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

	public static string ExtensionName = "TransitionsFX";

	public Action OnTransitionEnterStarted;

	public Action OnTransitionEnterEnded;

	public Action OnTransitionExitStarted;

	public Action OnTransitionExitEnded;

	public Action OnTransitionStarted;

	public Action OnTransitionEnded;

	private static ProCamera2DTransitionsFX _instance;

	public TransitionsFXShaders TransitionShaderEnter;

	public float DurationEnter;

	public float DelayEnter;

	public EaseType EaseTypeEnter;

	public Color BackgroundColorEnter;

	public TransitionFXSide SideEnter;

	public TransitionFXDirection DirectionEnter;

	public int BlindsEnter;

	public Texture TextureEnter;

	public float TextureSmoothingEnter;

	public TransitionsFXShaders TransitionShaderExit;

	public float DurationExit;

	public float DelayExit;

	public EaseType EaseTypeExit;

	public Color BackgroundColorExit;

	public TransitionFXSide SideExit;

	public TransitionFXDirection DirectionExit;

	public int BlindsExit;

	public Texture TextureExit;

	public float TextureSmoothingExit;

	public bool StartSceneOnEnterState;

	private Coroutine _transitionCoroutine;

	private float _step;

	private Material _transitionEnterMaterial;

	private Material _transitionExitMaterial;

	private BasicBlit _blit;

	private int _material_StepID;

	private int _material_BackgroundColorID;

	private string _previousEnterShader;

	private string _previousExitShader;

	public static ProCamera2DTransitionsFX Instance
	{
		get
		{
			if ((object)_instance == null)
			{
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance == null)
				{
					return (ProCamera2DTransitionsFX)(object)new NullReferenceException();
				}
				ProCamera2DTransitionsFX component = instance.GetComponent<ProCamera2DTransitionsFX>();
				_instance = component;
				if ((object)_instance == null)
				{
					UnityException ex = new UnityException("ProCamera2D does not have a TransitionFX extension.");
					throw ex;
				}
			}
			return _instance;
		}
	}

	protected override void Awake()
	{
		//IL_0263->IL01e6: Incompatible stack heights: 1 vs 0
		//IL_0133->IL01e6: Incompatible stack heights: 2 vs 0
		//IL_0170->IL01e6: Incompatible stack heights: 2 vs 0
		//IL_0192->IL01e6: Incompatible stack heights: 2 vs 0
		//IL_01cb->IL01e6: Incompatible stack heights: 2 vs 0
		base.Awake();
		_instance = this;
		int material_StepID = Shader.PropertyToID("_Step");
		_material_StepID = material_StepID;
		int material_BackgroundColorID = Shader.PropertyToID("_BackgroundColor");
		_material_BackgroundColorID = material_BackgroundColorID;
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			BasicBlit blit = gameObject.AddComponent<BasicBlit>();
			_blit = blit;
			if ((object)_blit != null)
			{
				_blit.enabled = false;
				UpdateTransitionsShaders();
				UpdateTransitionsProperties();
				object transitionEnterMaterial = _transitionEnterMaterial;
				if ((object)_transitionEnterMaterial != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v6 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v6 (System.Object)+10]");
					Color value = default(Color);
					Material.SetColorImpl_Injected((IntPtr)0, _material_BackgroundColorID, ref value);
					object transitionExitMaterial = _transitionExitMaterial;
					if ((object)_transitionExitMaterial != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdi_v7 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdi_v7 (System.Object)+10]");
						Color value2 = default(Color);
						Material.SetColorImpl_Injected((IntPtr)0, _material_BackgroundColorID, ref value2);
						if (!StartSceneOnEnterState)
						{
							return;
						}
						BasicBlit blit2 = _blit;
						_step = 1f;
						if ((object)_blit != null)
						{
							blit2.CurrentMaterial = _transitionEnterMaterial;
							BasicBlit blit3 = _blit;
							if ((object)_blit != null && (object)blit3.CurrentMaterial != null)
							{
								blit3.CurrentMaterial.SetFloatImpl(_material_StepID, _step);
								if ((object)_blit != null)
								{
									_blit.enabled = true;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void TransitionEnter()
	{
		float startValue = default(float);
		float endValue = default(float);
		EaseType easeType = default(EaseType);
		Transition(_transitionEnterMaterial, DurationEnter, DelayEnter, startValue, endValue, easeType);
	}

	public void TransitionExit()
	{
		float startValue = default(float);
		float endValue = default(float);
		EaseType easeType = default(EaseType);
		Transition(_transitionExitMaterial, DurationExit, DelayExit, startValue, endValue, easeType);
	}

	public unsafe void UpdateTransitionsShaders()
	{
		//IL_022f: Expected O, but got Ref
		//IL_0110: Expected O, but got Ref
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Ref, but got Unknown
		//IL_008e: Expected I8, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Ref, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected Ref, but got Unknown
		//IL_01ac: Expected I8, but got I4
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Ref, but got Unknown
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		string previousEnterShader = _previousEnterShader;
		if ((object)_previousEnterShader != text)
		{
			if (text != null && previousEnterShader._stringLength == text._stringLength)
			{
				ref byte second = ref *(byte*)(text + 20);
				ulong length = (ulong)(previousEnterShader._stringLength + previousEnterShader._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(_previousEnterShader + 20), ref second, length))
				{
					goto IL_0107;
				}
			}
			string text2 = "Hidden/ProCamera2D/TransitionsFX/" + text;
			Shader shader = Shader.Find(text2);
			Material transitionEnterMaterial = new Material(shader);
			_transitionEnterMaterial = transitionEnterMaterial;
			_previousEnterShader = text;
		}
		goto IL_0107;
		IL_0107:
		string text3 = ((Enum)(&intPtr)).ToString();
		string previousExitShader = _previousExitShader;
		if ((object)_previousExitShader == text3)
		{
			return;
		}
		if (text3 != null && previousExitShader._stringLength == text3._stringLength)
		{
			ref byte second2 = ref *(byte*)(text3 + 20);
			ulong length2 = (ulong)(previousExitShader._stringLength + previousExitShader._stringLength);
			if (System.SpanHelpers.SequenceEqual(ref *(byte*)(_previousExitShader + 20), ref second2, length2))
			{
				return;
			}
		}
		string text4 = "Hidden/ProCamera2D/TransitionsFX/" + text3;
		Shader shader2 = Shader.Find(text4);
		Material transitionExitMaterial = new Material(shader2);
		_transitionExitMaterial = transitionExitMaterial;
		_previousExitShader = text3;
	}

	public void UpdateTransitionsProperties()
	{
		//IL_0131: Expected F4, but got I4
		//IL_02f3: Expected F4, but got I4
		//IL_027c: Expected F4, but got I4
		//IL_0323: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C343]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material transitionEnterMaterial;
		int num2;
		float value;
		int num3;
		string text;
		if (TransitionShaderEnter != TransitionsFXShaders.Wipe && TransitionShaderEnter != TransitionsFXShaders.Blinds)
		{
			if (TransitionShaderEnter != TransitionsFXShaders.Shutters)
			{
				if (TransitionShaderEnter != TransitionsFXShaders.Texture)
				{
					goto IL_015d;
				}
				int num = Shader.PropertyToID("_TransitionTex");
				_transitionEnterMaterial.SetTextureImpl(num, TextureEnter);
				transitionEnterMaterial = _transitionEnterMaterial;
				num2 = Shader.PropertyToID("_Smoothing");
				value = TextureSmoothingEnter;
				goto IL_02c8;
			}
			transitionEnterMaterial = _transitionEnterMaterial;
			num3 = (int)DirectionEnter;
			text = "_Direction";
		}
		else
		{
			int num4 = Shader.PropertyToID("_Direction");
			_transitionEnterMaterial.SetFloatImpl(num4, (float)SideEnter);
			transitionEnterMaterial = _transitionEnterMaterial;
			num3 = BlindsEnter;
			text = "_Blinds";
		}
		num2 = Shader.PropertyToID(text);
		value = num3;
		goto IL_02c8;
		IL_02f8:
		Material transitionExitMaterial;
		int num5;
		float value2;
		transitionExitMaterial.SetFloatImpl(num5, value2);
		return;
		IL_015d:
		TransitionFXDirection transitionFXDirection;
		string text2;
		if (TransitionShaderExit != TransitionsFXShaders.Wipe && TransitionShaderExit != TransitionsFXShaders.Blinds)
		{
			if (TransitionShaderExit != TransitionsFXShaders.Shutters)
			{
				if (TransitionShaderExit == TransitionsFXShaders.Texture)
				{
					int num6 = Shader.PropertyToID("_TransitionTex");
					_transitionExitMaterial.SetTextureImpl(num6, TextureExit);
					transitionExitMaterial = _transitionExitMaterial;
					num5 = Shader.PropertyToID("_Smoothing");
					value2 = TextureSmoothingExit;
					goto IL_02f8;
				}
				return;
			}
			transitionExitMaterial = _transitionExitMaterial;
			transitionFXDirection = DirectionExit;
			text2 = "_Direction";
		}
		else
		{
			int num7 = Shader.PropertyToID("_Direction");
			_transitionExitMaterial.SetFloatImpl(num7, (float)SideExit);
			transitionExitMaterial = _transitionExitMaterial;
			text2 = "_Blinds";
			transitionFXDirection = (TransitionFXDirection)BlindsExit;
		}
		num5 = Shader.PropertyToID(text2);
		value2 = (float)transitionFXDirection;
		goto IL_02f8;
		IL_02c8:
		transitionEnterMaterial.SetFloatImpl(num2, value);
		goto IL_015d;
	}

	public void UpdateTransitionsColor()
	{
		//IL_00a8->IL0047: Incompatible stack heights: 1 vs 0
		Material transitionEnterMaterial = _transitionEnterMaterial;
		if ((object)_transitionEnterMaterial != null)
		{
			bool flag = ((UnityEngine.Object)transitionEnterMaterial).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			Material.SetColorImpl_Injected(((UnityEngine.Object)transitionEnterMaterial).m_CachedPtr, _material_BackgroundColorID, ref value);
			Material transitionExitMaterial = _transitionExitMaterial;
			if ((object)_transitionExitMaterial != null)
			{
				bool flag2 = ((UnityEngine.Object)transitionExitMaterial).m_CachedPtr == (IntPtr)0;
				Color value2 = default(Color);
				Material.SetColorImpl_Injected(((UnityEngine.Object)transitionExitMaterial).m_CachedPtr, _material_BackgroundColorID, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Clear()
	{
		_blit.enabled = false;
	}

	private void Transition(Material material, float duration, float delay, float startValue, float endValue, EaseType easeType)
	{
		Material transitionEnterMaterial = _transitionEnterMaterial;
		if ((object)_transitionEnterMaterial != null && ((UnityEngine.Object)transitionEnterMaterial).m_CachedPtr != (IntPtr)0)
		{
			if (_transitionCoroutine != null)
			{
				StopCoroutine(_transitionCoroutine);
			}
			_003CTransitionRoutine_003Ed__48 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.material = material;
			float startValue2 = default(float);
			obj.startValue = startValue2;
			float endValue2 = default(float);
			obj.endValue = endValue2;
			obj.duration = duration;
			obj.delay = delay;
			EaseType easeType2 = default(EaseType);
			obj.easeType = easeType2;
			Coroutine transitionCoroutine = StartCoroutine(obj);
			_transitionCoroutine = transitionCoroutine;
		}
		else
		{
			Debug.LogWarning("TransitionsFX not initialized yet. You're probably calling TransitionEnter/Exit from an Awake method. Please call it from a Start method instead.");
		}
	}

	private IEnumerator TransitionRoutine(Material material, float duration, float delay, float startValue, float endValue, EaseType easeType)
	{
		_003CTransitionRoutine_003Ed__48 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.material = material;
		EaseType easeType2 = default(EaseType);
		obj.easeType = easeType2;
		obj.duration = duration;
		obj.delay = delay;
		float startValue2 = default(float);
		obj.startValue = startValue2;
		float endValue2 = default(float);
		obj.endValue = endValue2;
		return obj;
	}

	public ProCamera2DTransitionsFX()
	{
		//IL_0062: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_00df: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C346]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DurationEnter = 0.5f;
		EaseTypeEnter = EaseType.EaseOut;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		BackgroundColorEnter = (Color)0;
		BlindsEnter = 16;
		TextureSmoothingEnter = 0.2f;
		DurationExit = 0.5f;
		EaseTypeExit = EaseType.EaseOut;
		BlindsExit = 16;
		TextureSmoothingExit = 0.2f;
		StartSceneOnEnterState = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		BackgroundColorExit = (Color)0;
		_previousEnterShader = "";
		_previousExitShader = "";
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v6 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

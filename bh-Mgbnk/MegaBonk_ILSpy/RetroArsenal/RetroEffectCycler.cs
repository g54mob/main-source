using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroEffectCycler : MonoBehaviour
{
	private sealed class _003CEffectLoop_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroEffectCycler _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CEffectLoop_003Ed__15(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_029d: Expected I4, but got I8
			//IL_0036: Expected O, but got I
			//IL_02b8: Expected O, but got I
			//IL_008e: Expected O, but got Ref
			//IL_008e: Expected O, but got Ref
			//IL_03e0: Expected O, but got I
			//IL_0317: Expected O, but got I
			//IL_01d1: Expected O, but got I
			//IL_00d2: Expected O, but got I
			//IL_01e3: Expected O, but got I4
			//IL_0164: Expected O, but got I
			//IL_023f: Expected F4, but got I
			//IL_0112: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_03aa: Expected I4, but got O
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Expected O, but got Unknown
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+28]");
				GameObject original = ((List<GameObject>)num).get_Item(0);
				Transform transform = component.transform;
				Vector3 position = transform.position;
				Transform transform2 = component.transform;
				Quaternion rotation = transform2.rotation;
				object obj = default(object);
				object obj2 = default(object);
				GameObject gameObject = UnityEngine.Object.Instantiate(original, (Vector3)(&obj), (Quaternion)(&obj2));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+34]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
					Light component2 = ((GameObject)0).GetComponent<Light>();
					if ((bool)component2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
						Light component3 = ((GameObject)0).GetComponent<Light>();
						component3.enabled = false;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+35]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
					AudioSource component4 = ((GameObject)0).GetComponent<AudioSource>();
					if ((bool)component4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
						AudioSource component5 = ((GameObject)0).GetComponent<AudioSource>();
						component5.enabled = false;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
				ParticleSystem[] componentsInChildren = ((GameObject)0).GetComponentsInChildren<ParticleSystem>();
				object obj3 = 0;
				while (true)
				{
					if ((nint)obj3 < componentsInChildren.Length)
					{
						if ((nint)obj3 >= componentsInChildren.Length)
						{
							break;
						}
						componentsInChildren[obj3].Play();
						obj3++;
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+2C]");
					WaitForSeconds waitForSeconds = new WaitForSeconds(0f);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					return true;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (byte)(int)ex != 0;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+40]");
				UnityEngine.Object.Destroy((UnityEngine.Object)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+36]");
				if ((nint)0 == 0)
				{
					((RetroEffectCycler)component).PlayEffect();
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+20]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v13+18]");
					object obj5 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+28]");
					if (0 >= (nint)obj5)
					{
						_ = 0;
						((RetroEffectCycler)component).RestartEffect();
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+28]");
						_ = (nint)0 + (nint)1;
						((RetroEffectCycler)component).RestartEffect();
					}
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public List<GameObject> listOfEffects;

	private int effectIndex;

	public float loopLength = 1f;

	public float startDelay = 1f;

	public bool disableLights = true;

	public bool disableSound;

	public bool autoMode = true;

	public Text effectNameText;

	private GameObject currentEffect;

	private void Start()
	{
		if (!(effectNameText == null))
		{
			PlayEffect();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	public void PlayEffect()
	{
		_003CEffectLoop_003Ed__15 obj = new _003CEffectLoop_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		UpdateEffectUI();
	}

	public void NextEffect()
	{
		//IL_0018: Expected O, but got I4
		List<GameObject> list = listOfEffects;
		object obj = list._size - 1;
		if (effectIndex >= (nint)obj)
		{
			effectIndex = 0;
			RestartEffect();
		}
		else
		{
			int num = effectIndex + 1;
			effectIndex = num;
			RestartEffect();
		}
	}

	public void PreviousEffect()
	{
		bool flag = effectIndex > 0;
		RetroEffectCycler retroEffectCycler = this;
		if (!flag)
		{
			List<GameObject> list = listOfEffects;
			int num = list._size - 1;
			effectIndex = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 53 Invalid \"Jump target not found in method: 0x1804B7F70\"");
			RetroEffectCycler retroEffectCycler2 = default(RetroEffectCycler);
			retroEffectCycler = retroEffectCycler2;
		}
		int num2 = retroEffectCycler.effectIndex - 1;
		retroEffectCycler.effectIndex = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x1804B7F70\"");
		throw new NullReferenceException();
	}

	public void ToggleAutoMode()
	{
		bool flag = !autoMode;
		autoMode = flag;
		UpdateEffectUI();
	}

	private void RestartEffect()
	{
		StopAllCoroutines();
		if (currentEffect != null)
		{
			UnityEngine.Object.Destroy(currentEffect);
		}
		PlayEffect();
	}

	private IEnumerator EffectLoop()
	{
		_003CEffectLoop_003Ed__15 obj = new _003CEffectLoop_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void UpdateEffectUI()
	{
		if (effectNameText != null)
		{
			GameObject gameObject = listOfEffects.get_Item(effectIndex);
			string arg = gameObject.name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			string text = $"{arg} ({arg2} of {arg3})";
			effectNameText.text = text;
		}
	}

	private void Update()
	{
	}
}

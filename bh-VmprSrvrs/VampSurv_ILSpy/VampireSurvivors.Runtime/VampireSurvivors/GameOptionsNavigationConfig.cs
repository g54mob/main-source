using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class GameOptionsNavigationConfig : MonoBehaviour
{
	private sealed class _003CWaitFrame_003Ed__7(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameOptionsNavigationConfig _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_0828: Expected I4, but got O
			GameOptionsNavigationConfig gameOptionsNavigationConfig = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0378;
			}
			_003C_003E1__state = -1;
			Selectable origin;
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.SetNavigationLeft(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._QuitButton);
				_003C_003E4__this.SetNavigationLeft(gameOptionsNavigationConfig._FancyBackground, gameOptionsNavigationConfig._QuitButton);
				_003C_003E4__this.SetNavigationLeft(gameOptionsNavigationConfig._VisibleJoystick, gameOptionsNavigationConfig._QuitButton);
				_003C_003E4__this.SetNavigationLeft(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._QuitButton);
				_003C_003E4__this.SetNavigationLeft(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._ResumeButton);
				_003C_003E4__this.SetNavigationRight(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._ResumeButton);
				_003C_003E4__this.SetNavigationRight(gameOptionsNavigationConfig._FancyBackground, gameOptionsNavigationConfig._ResumeButton);
				_003C_003E4__this.SetNavigationRight(gameOptionsNavigationConfig._VisibleJoystick, gameOptionsNavigationConfig._ResumeButton);
				_003C_003E4__this.SetNavigationRight(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._ResumeButton);
				_003C_003E4__this.SetNavigationRight(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._QuitButton);
				if ((object)gameOptionsNavigationConfig._VisibleJoystick != null)
				{
					GameObject gameObject = gameOptionsNavigationConfig._VisibleJoystick.gameObject;
					if ((object)gameObject != null)
					{
						if (!gameObject.activeInHierarchy)
						{
							goto IL_037e;
						}
						if ((object)gameOptionsNavigationConfig._FancyBackground != null)
						{
							GameObject gameObject2 = gameOptionsNavigationConfig._FancyBackground.gameObject;
							if ((object)gameObject2 != null)
							{
								if (gameObject2.activeInHierarchy)
								{
									goto IL_037e;
								}
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._VisibleJoystick);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._VisibleJoystick);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._VisibleJoystick, gameOptionsNavigationConfig._ResumeButton);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._VisibleJoystick);
								origin = gameOptionsNavigationConfig._VisibleJoystick;
								goto IL_0828;
							}
						}
					}
				}
			}
			goto IL_081a;
			IL_037e:
			if ((object)gameOptionsNavigationConfig._VisibleJoystick != null)
			{
				GameObject gameObject3 = gameOptionsNavigationConfig._VisibleJoystick.gameObject;
				if ((object)gameObject3 != null)
				{
					if (gameObject3.activeInHierarchy)
					{
						goto IL_04f1;
					}
					if ((object)gameOptionsNavigationConfig._FancyBackground != null)
					{
						GameObject gameObject4 = gameOptionsNavigationConfig._FancyBackground.gameObject;
						if ((object)gameObject4 != null)
						{
							if (!gameObject4.activeInHierarchy)
							{
								goto IL_04f1;
							}
							_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._FancyBackground);
							_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._FancyBackground);
							_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._FancyBackground, gameOptionsNavigationConfig._ResumeButton);
							_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._FancyBackground);
							origin = gameOptionsNavigationConfig._FancyBackground;
							goto IL_0828;
						}
					}
				}
			}
			goto IL_081a;
			IL_081a:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0378:
			return false;
			IL_0828:
			_003C_003E4__this.SetNavigationUp(origin, gameOptionsNavigationConfig._DamageNumbers);
			goto IL_0356;
			IL_06e1:
			if ((object)gameOptionsNavigationConfig._VisibleJoystick != null)
			{
				GameObject gameObject5 = gameOptionsNavigationConfig._VisibleJoystick.gameObject;
				if ((object)gameObject5 != null)
				{
					if (gameObject5.activeInHierarchy)
					{
						goto IL_0378;
					}
					if ((object)gameOptionsNavigationConfig._FancyBackground != null)
					{
						GameObject gameObject6 = gameOptionsNavigationConfig._FancyBackground.gameObject;
						if ((object)gameObject6 != null)
						{
							if (!gameObject6.activeInHierarchy)
							{
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._DamageNumbers);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._DamageNumbers);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._ResumeButton);
								goto IL_0356;
							}
							goto IL_0378;
						}
					}
				}
			}
			goto IL_081a;
			IL_0356:
			_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._FlashingVFX);
			goto IL_0378;
			IL_04f1:
			if ((object)gameOptionsNavigationConfig._VisibleJoystick != null)
			{
				GameObject gameObject7 = gameOptionsNavigationConfig._VisibleJoystick.gameObject;
				if ((object)gameObject7 != null)
				{
					if (!gameObject7.activeInHierarchy)
					{
						goto IL_06e1;
					}
					if ((object)gameOptionsNavigationConfig._FancyBackground != null)
					{
						GameObject gameObject8 = gameOptionsNavigationConfig._FancyBackground.gameObject;
						if ((object)gameObject8 != null)
						{
							if (gameObject8.activeInHierarchy)
							{
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._QuitButton, gameOptionsNavigationConfig._VisibleJoystick);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._ResumeButton, gameOptionsNavigationConfig._VisibleJoystick);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._VisibleJoystick, gameOptionsNavigationConfig._ResumeButton);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._FancyBackground, gameOptionsNavigationConfig._VisibleJoystick);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._VisibleJoystick, gameOptionsNavigationConfig._FancyBackground);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._FancyBackground, gameOptionsNavigationConfig._DamageNumbers);
								_003C_003E4__this.SetNavigationUp(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._FlashingVFX);
								_003C_003E4__this.SetNavigationDown(gameOptionsNavigationConfig._DamageNumbers, gameOptionsNavigationConfig._FancyBackground);
								return false;
							}
							goto IL_06e1;
						}
					}
				}
			}
			goto IL_081a;
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

	private Button _QuitButton;

	private Button _ResumeButton;

	private Selectable _FancyBackground;

	private Selectable _VisibleJoystick;

	private Selectable _DamageNumbers;

	private Selectable _FlashingVFX;

	private void OnEnable()
	{
		_003CWaitFrame_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitFrame()
	{
		_003CWaitFrame_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected unsafe void SetNavigationUp(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	protected unsafe void SetNavigationDown(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationLeft(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	protected unsafe void SetNavigationRight(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	public GameOptionsNavigationConfig()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

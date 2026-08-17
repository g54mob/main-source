using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PhotosensWarning : MonoBehaviour
{
	private sealed class _003CShowWarning_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PhotosensWarning _003C_003E4__this;

		private float _003Ct_003E5__2;

		private float _003CfadeOverTime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowWarning_003Ed__6(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_038c: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0135: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_03c9: Expected I4, but got O
			//IL_0121: Expected I4, but got I8
			//IL_0278: Invalid comparison between I4 and F4
			//IL_006e: Expected I4, but got I8
			//IL_02c3: Expected F4, but got I4
			//IL_02d1: Invalid comparison between I4 and F4
			//IL_031c: Expected F4, but got I4
			PhotosensWarning photosensWarning = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (flag)
					{
						_003C_003E1__state = -1;
						goto IL_03f7;
					}
					if ((nint)obj2 != 1)
					{
						goto IL_0104;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)photosensWarning.btn != null)
					{
						GameObject gameObject = photosensWarning.btn.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							ButtonManager.ForceHoverButton(photosensWarning.btn);
							goto IL_0104;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					ButtonManager.SetNull();
					AlwaysUi instance = AlwaysUi.Instance;
					if ((object)AlwaysUi.Instance != null && (object)instance.selectionArrow != null)
					{
						instance.selectionArrow.Hide();
						if ((object)_003C_003E4__this != null && (object)photosensWarning.window != null)
						{
							photosensWarning.window.SetActive(value: true);
							if ((object)photosensWarning.cg != null)
							{
								photosensWarning.cg.alpha = 0f;
								_003Ct_003E5__2 = 0f;
								_003CfadeOverTime_003E5__3 = 0.55f;
								goto IL_03f7;
							}
						}
					}
				}
				goto IL_03bb;
			}
			_003C_003E1__state = -1;
			WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 1;
			return true;
			IL_0468:
			return true;
			IL_03f7:
			if (_003CfadeOverTime_003E5__3 > _003Ct_003E5__2)
			{
				float unscaledDeltaTime = Time.unscaledDeltaTime;
				float num = (_003Ct_003E5__2 = unscaledDeltaTime + _003Ct_003E5__2) / _003CfadeOverTime_003E5__3;
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
				float num2 = Easing.InOutQuad(num);
				if ((object)_003C_003E4__this != null)
				{
					if (!(0f > num2))
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
					if ((object)photosensWarning.cg != null)
					{
						photosensWarning.cg.alpha = num2;
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						goto IL_0468;
					}
				}
				goto IL_03bb;
			}
			WaitForSeconds waitForSeconds2 = new WaitForSeconds(0.8f);
			_003C_003E2__current = waitForSeconds2;
			_003C_003E1__state = 3;
			goto IL_0468;
			IL_03bb:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0104:
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

	public GameObject window;

	public CanvasGroup cg;

	public MyButton btn;

	private void Start()
	{
		//IL_0111: Expected I, but got O
		if (SaveManager.loaded)
		{
			OnSavesLoaded();
		}
		Action b = OnSavesLoaded;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
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
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = OnSavesLoaded;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
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
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnSavesLoaded()
	{
		if (!(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if (saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			ConfigSettingsExtra otherSettings = config.otherSettings;
			if (!otherSettings.hasAcceptedPhotoSensitivity)
			{
				_003CShowWarning_003Ed__6 obj = new _003CShowWarning_003Ed__6(0);
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj);
			}
		}
	}

	private IEnumerator ShowWarning()
	{
		_003CShowWarning_003Ed__6 obj = new _003CShowWarning_003Ed__6(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void Confirm()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		ConfigSettingsExtra otherSettings = config.otherSettings;
		otherSettings.hasAcceptedPhotoSensitivity = true;
		window.SetActive(value: false);
	}
}

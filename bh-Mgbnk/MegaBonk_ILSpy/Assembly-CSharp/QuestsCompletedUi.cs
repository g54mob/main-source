using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.UI.Animation;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class QuestsCompletedUi : MonoBehaviour
{
	private sealed class _003CAnimateQuests_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<MyAchievement> achievements;

		public QuestsCompletedUi _003C_003E4__this;

		private int _003Cindex_003E5__2;

		private List<MyAchievement>.Enumerator _003C_003E7__wrap2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateQuests_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		unsafe void IDisposable.Dispose()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			if (_003C_003E1__state == -3 || _003C_003E1__state == 2)
			{
				_ = 4294967295L;
				object obj = default(object);
				List<MyAchievement>.Enumerator enumerator = (List<MyAchievement>.Enumerator)(obj + 56);
				((List<MyAchievement>.Enumerator*)enumerator)->Dispose();
			}
		}

		private unsafe bool MoveNext()
		{
			//IL_029d: Expected O, but got I
			//IL_001b: Expected O, but got I
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Expected O, but got Unknown
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Expected O, but got Unknown
			//IL_012d: Expected O, but got I
			//IL_012d: Expected O, but got I
			//IL_01a1: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+28]");
			QuestsCompletedUi questsCompletedUi = (QuestsCompletedUi)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+10]");
			bool flag = (nint)0 == 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+10]");
				object obj = -1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						return false;
					}
					_ = 4294967293L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+30]");
					_ = (nint)0 + (nint)1;
				}
				else
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					_ = 4294967293L;
				}
				object obj2 = default(object);
				List<object>.Enumerator enumerator = (List<object>.Enumerator)(obj2 + 56);
				if (((List<object>.Enumerator*)enumerator)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+28]");
					bool flag2 = (nint)0 == 0;
					nint num = 0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+28]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+48]");
						((QuestsCompletedUi)num2).TestAddItem((MyAchievement)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+20]");
						if ((nint)0 != 0)
						{
							if ((object)questsCompletedUi.source != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_8_v2+30]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v14 (Il2CppMethodInfo)+18]");
								object obj3 = num3 / 0;
								float num4 = (float)obj3 * 0.5f;
								float pitch = num4 + 1f;
								questsCompletedUi.source.pitch = pitch;
								questsCompletedUi.source.Play();
								WaitForSeconds waitForSeconds = new WaitForSeconds(questsCompletedUi.delay);
								_ = 2;
								return true;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				_ = 4294967295L;
				List<MyAchievement>.Enumerator enumerator2 = (List<MyAchievement>.Enumerator)(obj2 + 56);
				((List<MyAchievement>.Enumerator*)enumerator2)->Dispose();
				_ = 0;
				_ = 0;
				return false;
			}
			_ = 4294967295L;
			WaitForSeconds waitForSeconds2 = new WaitForSeconds(0.4f);
			_ = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private unsafe void _003C_003Em__Finally1()
		{
			//IL_0014: Expected I4, but got I8
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			_003C_003E1__state = -1;
			List<MyAchievement>.Enumerator enumerator = (List<MyAchievement>.Enumerator)(this + 56);
			((List<MyAchievement>.Enumerator*)enumerator)->Dispose();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject prefab;

	public Transform contentParent;

	public ScrollRect scrollRect;

	public AudioSource source;

	private float delay = 0.35f;

	private void Start()
	{
		_003CAnimateQuests_003Ed__6 obj = new _003CAnimateQuests_003Ed__6(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.achievements = RunStats.achievements;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator AnimateQuests(List<MyAchievement> achievements)
	{
		_003CAnimateQuests_003Ed__6 obj = new _003CAnimateQuests_003Ed__6(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.achievements = achievements;
		return obj;
	}

	private unsafe void TestAddItem(MyAchievement ach)
	{
		//IL_0100: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab, contentParent);
		GameObject gameObject2 = gameObject.gameObject;
		gameObject2.SetActive(value: true);
		QuestsCompletedEntry component = gameObject.GetComponent<QuestsCompletedEntry>();
		Texture icon = ach.GetIcon();
		component.icon.texture = icon;
		string displayName = ach.GetDisplayName();
		component.t_name.text = displayName;
		string unlockRequirement = ach.GetUnlockRequirement();
		component.t_description.text = unlockRequirement;
		string unlockedString = ach.GetUnlockedString();
		component.t_unlock.text = unlockedString;
		Transform transform = component.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		component.uiAnimation.Scale(1f, 0.2f, EEasing.InOutCirc);
		GameObject gameObject3 = component.myButton.gameObject;
		gameObject3.SetActive(value: true);
		Canvas.ForceUpdateCanvases();
		scrollRect.verticalNormalizedPosition = 0f;
		Canvas.ForceUpdateCanvases();
	}
}

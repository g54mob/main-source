using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class AchievementPopup : MonoBehaviour
{
	private sealed class _003CShowAchievements_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AchievementPopup _003C_003E4__this;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowAchievements_003Ed__14(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0148: Expected I4, but got I8
			//IL_04bf: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0134: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_04f7: Expected I4, but got I8
			//IL_0617: Invalid comparison between I4 and F4
			//IL_0581: Invalid comparison between I4 and F4
			//IL_0276: Expected I, but got O
			//IL_02b7: Expected I, but got O
			//IL_02d1: Expected I, but got O
			AchievementPopup achievementPopup = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			Vector2 anchoredPosition = default(Vector2);
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_05bc;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_005c;
					}
				}
				else
				{
					_003Ct_003E5__2 = 0f;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (!(achievementPopup.moveTime > _003Ct_003E5__2))
					{
						goto IL_0516;
					}
					float deltaTime = Time.deltaTime;
					float num = deltaTime + _003Ct_003E5__2;
					_003Ct_003E5__2 = num;
					float t = _003Ct_003E5__2 / achievementPopup.moveTime;
					float num2 = Easing.InOutQuad(t);
					float num3 = 1f - num2;
					if (0f > num3 || num3 > 1f)
					{
					}
					if ((object)achievementPopup.content != null)
					{
						achievementPopup.content.anchoredPosition = anchoredPosition;
						_003C_003E2__current = null;
						_003C_003E1__state = 3;
						return true;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)achievementPopup.content != null)
				{
					GameObject gameObject = achievementPopup.content.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						achievementPopup.isAnimating = true;
						goto IL_0516;
					}
				}
			}
			goto IL_04b1;
			IL_0516:
			Queue<object> queue = (Queue<object>)(object)achievementPopup.queue;
			if (achievementPopup.queue != null)
			{
				if (queue._size > 0)
				{
					object obj3 = ((Queue<object>)(object)achievementPopup.queue).Dequeue();
					if (obj3 != null)
					{
						Texture icon = ((MyAchievement)obj3).GetIcon();
						if ((object)achievementPopup.icon != null)
						{
							achievementPopup.icon.texture = icon;
							nint num4 = (nint)obj3;
							TextMeshProUGUI t_title = achievementPopup.t_title;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v677 @ rax_v21 (Il2CppClass<System.Object>)+188] (should have been resolved before IL gen)");
							if ((object)achievementPopup.t_title != null)
							{
								nint num5 = (nint)t_title;
								string text = default(string);
								achievementPopup.t_title.text = text;
								nint num6 = (nint)obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v681 @ rax_v24 (Il2CppClass<System.Object>)+198] (should have been resolved before IL gen)");
								if ((object)achievementPopup.t_description != null)
								{
									string text2 = default(string);
									achievementPopup.t_description.text = text2;
									if ((object)achievementPopup.sfx != null)
									{
										achievementPopup.sfx.Play();
										_003Ct_003E5__2 = 0f;
										goto IL_05bc;
									}
								}
							}
						}
					}
				}
				else if ((object)achievementPopup.content != null)
				{
					GameObject gameObject2 = achievementPopup.content.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
						achievementPopup.isAnimating = false;
						goto IL_005c;
					}
				}
			}
			goto IL_04b1;
			IL_04b1:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_05bc:
			if ((object)_003C_003E4__this != null)
			{
				if (!(achievementPopup.moveTime > _003Ct_003E5__2))
				{
					WaitForSeconds waitForSeconds = new WaitForSeconds(achievementPopup.stayTime);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
					return true;
				}
				float deltaTime2 = Time.deltaTime;
				float num7 = deltaTime2 + _003Ct_003E5__2;
				_003Ct_003E5__2 = num7;
				float t2 = _003Ct_003E5__2 / achievementPopup.moveTime;
				float num8 = Easing.InOutQuad(t2);
				float num9 = 1f - num8;
				if (0f > num9 || num9 > 1f)
				{
				}
				if ((object)achievementPopup.content != null)
				{
					achievementPopup.content.anchoredPosition = anchoredPosition;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			goto IL_04b1;
			IL_005c:
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

	public RectTransform content;

	public RawImage icon;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public RandomSfx sfx;

	private Queue<MyAchievement> queue;

	private bool isAnimating;

	private float contentHeight;

	private float moveTime;

	private float stayTime;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyAchievement> b = OnAchievementUnlocked;
		Delegate obj = Delegate.Combine(MyAchievements.A_Unlocked, b);
		if ((object)obj == null)
		{
			MyAchievements.A_Unlocked = (Action<MyAchievement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyAchievement> action = default(Action<MyAchievement>);
		if (action != null)
		{
			MyAchievements.A_Unlocked = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyAchievement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyAchievement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyAchievement> value = OnAchievementUnlocked;
		Delegate obj = Delegate.Remove(MyAchievements.A_Unlocked, value);
		if ((object)obj == null)
		{
			MyAchievements.A_Unlocked = (Action<MyAchievement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyAchievement> action = default(Action<MyAchievement>);
		if (action != null)
		{
			MyAchievements.A_Unlocked = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyAchievement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyAchievement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		Vector2 sizeDelta = content.sizeDelta;
		float num = default(float);
		contentHeight = num;
	}

	private void OnAchievementUnlocked(MyAchievement achievement)
	{
		((Queue<object>)(object)queue).Enqueue((object)achievement);
		if (!isAnimating)
		{
			_003CShowAchievements_003Ed__14 obj = new _003CShowAchievements_003Ed__14(0);
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private IEnumerator ShowAchievements()
	{
		_003CShowAchievements_003Ed__14 obj = new _003CShowAchievements_003Ed__14(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public AchievementPopup()
	{
		Queue<MyAchievement> queue = new Queue<MyAchievement>();
		this.queue = queue;
		moveTime = 0.75f;
		stayTime = 4f;
		base._002Ector();
	}
}

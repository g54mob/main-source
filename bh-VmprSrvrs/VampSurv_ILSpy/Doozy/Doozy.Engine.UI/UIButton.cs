using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Internal;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

public class UIButton : UIComponentBase<UIButton>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ecctor_003Eb__110_0(UIButton _003Cp0_003E, UIButtonBehaviorType _003Cp1_003E)
		{
		}
	}

	private sealed class _003CDeselectButtonEnumerator_003Ed__102(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UIButton _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0096: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_016a: Expected I4, but got O
			//IL_0052: Expected I4, but got I8
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag || (nint)obj == 1)
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						goto IL_015c;
					}
					_003C_003E4__this.DeselectButton();
				}
				return false;
			}
			_003C_003E1__state = -1;
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				if (!instance.IgnoreUnityTimescale)
				{
					WaitForSeconds waitForSeconds = null;
					waitForSeconds.m_Seconds = delay;
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
					return true;
				}
				WaitForSecondsRealtime waitForSecondsRealtime = null;
				waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = delay;
				waitForSecondsRealtime.m_WaitUntilTime = -1f;
				_003C_003E2__current = waitForSecondsRealtime;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_015c;
			IL_015c:
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

	private sealed class _003CDisableButtonBehaviorEnumerator_003Ed__105(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIButtonBehavior behavior;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00a7: Expected I4, but got I8
			//IL_01f6: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_005c: Expected I4, but got I8
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag || (nint)obj == 1)
				{
					UIButtonBehavior uIButtonBehavior = behavior;
					_003C_003E1__state = -1;
					if (behavior == null)
					{
						goto IL_01e8;
					}
					uIButtonBehavior.Ready = true;
				}
				return false;
			}
			UIButtonBehavior uIButtonBehavior2 = behavior;
			_003C_003E1__state = -1;
			if (behavior != null)
			{
				uIButtonBehavior2.Ready = false;
				DoozySettings instance = DoozySettings.Instance;
				if ((object)instance != null)
				{
					UIButtonBehavior uIButtonBehavior3 = behavior;
					if (!instance.IgnoreUnityTimescale)
					{
						if (behavior != null)
						{
							WaitForSeconds waitForSeconds = null;
							waitForSeconds.m_Seconds = uIButtonBehavior3.DisableInterval;
							_003C_003E2__current = waitForSeconds;
							_003C_003E1__state = 2;
							return true;
						}
					}
					else if (behavior != null)
					{
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = uIButtonBehavior3.DisableInterval;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_01e8;
			IL_01e8:
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

	private sealed class _003CDisableButtonEnumerator_003Ed__104(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIButton _003C_003E4__this;

		public float duration;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00cf: Expected I4, but got I8
			//IL_01fc: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0052: Expected I4, but got I8
			UIButton uIButton = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag && (nint)obj != 1)
				{
					goto IL_00ba;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Button button = _003C_003E4__this.Button;
					if ((object)button != null)
					{
						button.interactable = true;
						uIButton.m_disableButtonCoroutine = null;
						goto IL_00ba;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Button button2 = _003C_003E4__this.Button;
					if ((object)button2 != null)
					{
						button2.interactable = false;
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							if (!instance.IgnoreUnityTimescale)
							{
								WaitForSeconds waitForSeconds = null;
								waitForSeconds.m_Seconds = duration;
								_003C_003E2__current = waitForSeconds;
								_003C_003E1__state = 2;
								return true;
							}
							WaitForSecondsRealtime waitForSecondsRealtime = null;
							waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = duration;
							waitForSecondsRealtime.m_WaitUntilTime = -1f;
							_003C_003E2__current = waitForSecondsRealtime;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00ba:
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

	private sealed class _003CExecuteButtonBehaviorEnumerator_003Ed__103(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIButtonBehavior behavior;

		public UIButton _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_0411: Expected I4, but got I8
			//IL_07e2: Expected I4, but got O
			//IL_00ae: Expected I, but got O
			//IL_07a1: Expected O, but got I8
			//IL_07bb: Expected O, but got I8
			//IL_03db: Expected F4, but got I4
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				UIButtonBehavior uIButtonBehavior = behavior;
				_003C_003E1__state = -1;
				if (behavior != null)
				{
					if (!uIButtonBehavior.Enabled)
					{
						goto IL_07c5;
					}
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v1 (UnityEngine.Component)+134]");
						if ((nint)0 == 0)
						{
							nint num = (nint)component;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v608 @ rax_v49 (Il2CppClass<UnityEngine.Component>)+238] (should have been resolved before IL gen)");
							_ = 1;
						}
						UIButtonBehavior uIButtonBehavior2 = behavior;
						if (behavior != null)
						{
							if (uIButtonBehavior2.m_behaviorType <= UIButtonBehaviorType.OnPointerUp || uIButtonBehavior2.m_behaviorType == UIButtonBehaviorType.OnRightClick)
							{
								Button button = _003C_003E4__this.Button;
								if ((object)button == null)
								{
									goto IL_07d3;
								}
								if (!((Selectable)button).m_Interactable || UIComponentBase<UIButton>.UIInteractionsDisabled)
								{
									goto IL_07c5;
								}
							}
							_003C_003E4__this.StopNormalLoopAnimation();
							_003C_003E4__this.StopSelectedLoopAnimation();
							if (behavior != null)
							{
								UnityAction onCompleteCallback = default(UnityAction);
								behavior.PlayAnimation(_003C_003E4__this, withSound: true, null, onCompleteCallback);
								UIButtonBehavior uIButtonBehavior3 = behavior;
								if (behavior != null)
								{
									GameObject gameObject = _003C_003E4__this.gameObject;
									if (uIButtonBehavior3.OnTrigger != null)
									{
										Canvas canvas = uIButtonBehavior3.OnTrigger.GetCanvas(gameObject);
										uIButtonBehavior3.OnTrigger.ExecuteEffect(canvas);
										UIButtonBehavior uIButtonBehavior4 = behavior;
										if (behavior != null && uIButtonBehavior4.OnTrigger != null)
										{
											uIButtonBehavior4.OnTrigger.InvokeAnimatorEvents();
											UIButtonBehavior uIButtonBehavior5 = behavior;
											if (behavior != null)
											{
												bool flag = !uIButtonBehavior5.TriggerEventsAfterAnimation;
												UnityEngine.Object obj = null;
												Action<GameObject> action = null;
												if (!flag)
												{
													float num2;
													if (uIButtonBehavior5.ButtonAnimationType == ButtonAnimationType.Punch)
													{
														if (uIButtonBehavior5.PunchAnimation == null)
														{
															goto IL_07d3;
														}
														float totalDuration = uIButtonBehavior5.PunchAnimation.TotalDuration;
														num2 = totalDuration;
													}
													else if (uIButtonBehavior5.ButtonAnimationType == ButtonAnimationType.State)
													{
														if (uIButtonBehavior5.StateAnimation == null)
														{
															goto IL_07d3;
														}
														float totalDuration2 = uIButtonBehavior5.StateAnimation.TotalDuration;
														num2 = totalDuration2;
													}
													else
													{
														num2 = 0f;
													}
													WaitForSecondsRealtime waitForSecondsRealtime = null;
													waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = num2;
													waitForSecondsRealtime.m_WaitUntilTime = -1f;
													_003C_003E2__current = waitForSecondsRealtime;
													_003C_003E1__state = 1;
													return true;
												}
												goto IL_0837;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_07d3;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_07c5;
			}
			_003C_003E1__state = -1;
			goto IL_0837;
			IL_0837:
			UIButtonBehavior uIButtonBehavior6 = behavior;
			if (behavior != null)
			{
				UIAction onTrigger = uIButtonBehavior6.OnTrigger;
				if ((object)_003C_003E4__this != null)
				{
					GameObject gameObject2 = _003C_003E4__this.gameObject;
					if (uIButtonBehavior6.OnTrigger != null)
					{
						if (onTrigger.GameEvents != null)
						{
							List<string> gameEvents = onTrigger.GameEvents;
							if (onTrigger.GameEvents == null)
							{
								goto IL_07d3;
							}
							if (gameEvents._size > 0)
							{
								if ((object)gameObject2 == null)
								{
									goto IL_07d3;
								}
								GameEventMessage.SendEvents(onTrigger.GameEvents, gameObject2);
								UnityEngine.Object obj = null;
								Action<GameObject> action = null;
							}
						}
						UIButtonBehavior uIButtonBehavior7 = behavior;
						if (behavior != null)
						{
							UIAction onTrigger2 = uIButtonBehavior7.OnTrigger;
							GameObject gameObject3 = _003C_003E4__this.gameObject;
							if (uIButtonBehavior7.OnTrigger != null)
							{
								if (onTrigger2.Action != null)
								{
									Action<GameObject> action = onTrigger2.Action;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v120 @ r9_v4 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
								}
								UIButtonBehavior uIButtonBehavior8 = behavior;
								if (behavior != null)
								{
									UIAction onTrigger3 = uIButtonBehavior8.OnTrigger;
									if (uIButtonBehavior8.OnTrigger != null)
									{
										if (onTrigger3.Event != null)
										{
											onTrigger3.Event.Invoke();
										}
										if (!_003C_003E4__this.IsBackButton)
										{
											goto IL_06f5;
										}
										UIButtonBehavior uIButtonBehavior9 = behavior;
										if (behavior != null)
										{
											if (uIButtonBehavior9.m_behaviorType != UIButtonBehaviorType.OnClick && uIButtonBehavior9.m_behaviorType != UIButtonBehaviorType.OnDoubleClick && uIButtonBehavior9.m_behaviorType != UIButtonBehaviorType.OnLongClick)
											{
												goto IL_06f5;
											}
											BackButton instance = BackButton.Instance;
											if ((object)instance != null)
											{
												instance.Execute();
												goto IL_073c;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_07d3;
			IL_07d3:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_07c5:
			return false;
			IL_06f5:
			UIButtonBehavior uIButtonBehavior10 = behavior;
			if (behavior != null)
			{
				_003C_003E4__this.NotifySystemOfTriggeredBehavior(uIButtonBehavior10.m_behaviorType);
				UnityEngine.Object obj = null;
				goto IL_073c;
			}
			goto IL_07d3;
			IL_073c:
			UIButtonBehavior uIButtonBehavior11 = behavior;
			if (behavior != null)
			{
				UIButtonBehaviorType behaviorType = uIButtonBehavior11.m_behaviorType;
				if (uIButtonBehavior11.m_behaviorType <= UIButtonBehaviorType.OnRightClick)
				{
					object obj2 = 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rdx_v10+2B9CCFC+v453 @ rcx_v13 (Doozy.Engine.UI.UIButtonBehaviorType)*4]");
					object obj3 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v592 @ rcx_v15 (should have been resolved before IL gen)");
				}
				goto IL_07c5;
			}
			goto IL_07d3;
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

	private sealed class _003CRunOnClickEnumerator_003Ed__106(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIButton _003C_003E4__this;

		public bool debug;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_046f: Expected I4, but got I8
			//IL_0570: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0052: Expected I4, but got I8
			//IL_045b: Expected F4, but got I4
			//IL_0412: Expected I4, but got F4
			//IL_0308: Expected F4, but got I4
			//IL_0362: Expected F4, but got I4
			//IL_038d: Expected F4, but got I4
			//IL_03f3: Expected F4, but got I4
			UIButton uIButton = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			float num;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag && (nint)obj != 1)
				{
					goto IL_0599;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (!(uIButton.DoubleClickRegisterInterval > uIButton.m_doubleClickTimeoutCounter))
					{
						if (uIButton.ClickMode == SingleClickMode.Delayed)
						{
							_003C_003E4__this.ExecuteClick(debug);
						}
						num = 0f;
						goto IL_03f8;
					}
					if (uIButton.m_clickedOnce)
					{
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							if (!instance.IgnoreUnityTimescale)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
							}
							object obj2 = default(object);
							float doubleClickTimeoutCounter = (float)obj2 + uIButton.m_doubleClickTimeoutCounter;
							uIButton.m_doubleClickTimeoutCounter = doubleClickTimeoutCounter;
							_003C_003E2__current = null;
							_003C_003E1__state = 2;
							return true;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064E]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						UIButtonBehavior onDoubleClick = uIButton.OnDoubleClick;
						if (uIButton.OnDoubleClick != null)
						{
							if (onDoubleClick.Enabled)
							{
								_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnDoubleClick, "initiated", debug);
								Button button = _003C_003E4__this.Button;
								if ((object)button == null)
								{
									goto IL_0562;
								}
								if (((Selectable)button).m_Interactable)
								{
									IEnumerator routine = _003C_003E4__this.ExecuteButtonBehaviorEnumerator(uIButton.OnDoubleClick);
									Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
									_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnDoubleClick, "executed", debug);
								}
								if (!uIButton.AllowMultipleClicks)
								{
									_003C_003E4__this.DisableButton(uIButton.DisableButtonBetweenClicksInterval);
								}
							}
							Button button2 = _003C_003E4__this.Button;
							if ((object)button2 != null)
							{
								bool flag2 = ((Selectable)button2).m_Interactable;
								num = 0f;
								if (!flag2)
								{
									UIButtonBehavior onPointerExit = uIButton.OnPointerExit;
									if (uIButton.OnPointerExit == null)
									{
										goto IL_0562;
									}
									bool flag3 = !onPointerExit.Enabled;
									num = 0f;
									if (!flag3)
									{
										bool flag4 = !onPointerExit.Ready;
										num = 0f;
										if (!flag4)
										{
											IEnumerator routine2 = _003C_003E4__this.ExecuteButtonBehaviorEnumerator(uIButton.OnPointerExit);
											Coroutine coroutine2 = _003C_003E4__this.StartCoroutine(routine2);
											_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnPointerExit, "executed", debug);
											num = 0f;
										}
									}
								}
								goto IL_03f8;
							}
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (uIButton.ClickMode == SingleClickMode.Instant)
					{
						_003C_003E4__this.ExecuteClick(debug);
					}
					if (!uIButton.m_clickedOnce && uIButton.DoubleClickRegisterInterval > uIButton.m_doubleClickTimeoutCounter)
					{
						uIButton.m_clickedOnce = true;
						WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
						_003C_003E2__current = waitForEndOfFrame;
						_003C_003E1__state = 1;
						return true;
					}
					uIButton.m_clickedOnce = false;
					return false;
				}
			}
			goto IL_0562;
			IL_03f8:
			uIButton.m_doubleClickTimeoutCounter = num;
			uIButton.m_clickedOnce = (byte)(int)num != 0;
			goto IL_0599;
			IL_0562:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0599:
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

	private sealed class _003CRunOnLongClickEnumerator_003Ed__107(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIButton _003C_003E4__this;

		public bool debug;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_039a: Expected I4, but got O
			UIButton uIButton = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (uIButton.LongClickRegisterInterval > uIButton.m_longClickTimeoutCounter)
					{
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							if (!instance.IgnoreUnityTimescale)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B10");
							}
							object obj = default(object);
							float longClickTimeoutCounter = (float)obj + uIButton.m_longClickTimeoutCounter;
							uIButton.m_longClickTimeoutCounter = longClickTimeoutCounter;
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064F]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						UIButtonBehavior onLongClick = uIButton.OnLongClick;
						if (uIButton.OnLongClick != null)
						{
							if (onLongClick.Enabled)
							{
								_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnLongClick, "initiated", debug);
								Button button = _003C_003E4__this.Button;
								if ((object)button == null)
								{
									goto IL_038c;
								}
								if (((Selectable)button).m_Interactable)
								{
									IEnumerator routine = _003C_003E4__this.ExecuteButtonBehaviorEnumerator(uIButton.OnLongClick);
									Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
									_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnLongClick, "executed", debug);
								}
								if (!uIButton.AllowMultipleClicks)
								{
									_003C_003E4__this.DisableButton(uIButton.DisableButtonBetweenClicksInterval);
								}
							}
							Button button2 = _003C_003E4__this.Button;
							if ((object)button2 != null)
							{
								if (!((Selectable)button2).m_Interactable)
								{
									UIButtonBehavior onPointerExit = uIButton.OnPointerExit;
									if (uIButton.OnPointerExit == null)
									{
										goto IL_038c;
									}
									if (onPointerExit.Enabled && onPointerExit.Ready)
									{
										IEnumerator routine2 = _003C_003E4__this.ExecuteButtonBehaviorEnumerator(uIButton.OnPointerExit);
										Coroutine coroutine2 = _003C_003E4__this.StartCoroutine(routine2);
										_003C_003E4__this.PrintBehaviorDebugMessage(uIButton.OnPointerExit, "executed", debug);
									}
								}
								uIButton.m_executedLongClick = true;
								goto IL_03f2;
							}
						}
					}
				}
				goto IL_038c;
			}
			goto IL_03f2;
			IL_03f2:
			return false;
			IL_038c:
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

	public static Action<UIButton, UIButtonBehaviorType> OnUIButtonAction;

	public bool AllowMultipleClicks;

	public string ButtonCategory;

	public string ButtonName;

	public SingleClickMode ClickMode;

	public bool DeselectButtonAfterClick;

	public float DisableButtonBetweenClicksInterval;

	public float DoubleClickRegisterInterval;

	public InputData InputData;

	public float LongClickRegisterInterval;

	public UIButtonBehavior OnPointerEnter;

	public UIButtonBehavior OnPointerExit;

	public UIButtonBehavior OnPointerDown;

	public UIButtonBehavior OnPointerUp;

	public UIButtonBehavior OnClick;

	public UIButtonBehavior OnDoubleClick;

	public UIButtonBehavior OnLongClick;

	public UIButtonBehavior OnRightClick;

	public UIButtonBehavior OnSelected;

	public UIButtonBehavior OnDeselected;

	public UIButtonLoopAnimation NormalLoopAnimation;

	public UIButtonLoopAnimation SelectedLoopAnimation;

	public TargetLabel TargetLabel;

	public Text TextLabel;

	private Button m_button;

	private CanvasGroup m_canvasGroup;

	private bool m_clickedOnce;

	private Coroutine m_disableButtonCoroutine;

	private float m_doubleClickTimeoutCounter;

	private bool m_executedLongClick;

	private Coroutine m_longClickRegisterCoroutine;

	private float m_longClickTimeoutCounter;

	private bool m_updateStartValuesRequired;

	public static string BackButtonName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Back";
		}
	}

	public static string CustomButtonCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Custom";
		}
	}

	public static string DefaultButtonCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "General";
		}
	}

	public static string DefaultButtonName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Unnamed";
		}
	}

	public Button Button
	{
		get
		{
			Button button = m_button;
			if ((object)m_button == null || ((UnityEngine.Object)button).m_CachedPtr == (IntPtr)0)
			{
				Button component = GetComponent<Button>();
				m_button = component;
			}
			return m_button;
		}
	}

	public CanvasGroup CanvasGroup
	{
		get
		{
			CanvasGroup canvasGroup = m_canvasGroup;
			if ((object)m_canvasGroup != null && ((UnityEngine.Object)canvasGroup).m_CachedPtr != (IntPtr)0)
			{
				return m_canvasGroup;
			}
			CanvasGroup component = GetComponent<CanvasGroup>();
			m_canvasGroup = component;
			CanvasGroup canvasGroup2 = m_canvasGroup;
			if ((object)m_canvasGroup == null || ((UnityEngine.Object)canvasGroup2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject == null)
				{
					return (CanvasGroup)(object)new NullReferenceException();
				}
				CanvasGroup canvasGroup3 = gameObject.AddComponent<CanvasGroup>();
				m_canvasGroup = canvasGroup3;
			}
			return m_canvasGroup;
		}
	}

	public bool HasLabel
	{
		get
		{
			if (TargetLabel != TargetLabel.None && TargetLabel == TargetLabel.Text)
			{
				Text textLabel = TextLabel;
				if ((object)TextLabel != null)
				{
					bool flag = ((UnityEngine.Object)textLabel).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public bool Interactable
	{
		get
		{
			//IL_003f: Expected I4, but got O
			Button button = Button;
			if ((object)button != null)
			{
				return ((Selectable)button).m_Interactable;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		set
		{
			Button button = Button;
			button.interactable = value;
		}
	}

	public unsafe bool IsBackButton
	{
		get
		{
			//IL_010b: Expected I4, but got O
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected Ref, but got Unknown
			//IL_00c8: Expected I8, but got I4
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected Ref, but got Unknown
			string buttonName = ButtonName;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj = "Back";
			if (ButtonName != null)
			{
				if ((object)ButtonName != "Back")
				{
					if ("Back" != null)
					{
						int stringLength = buttonName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(ButtonName + 20);
							ulong length = (ulong)(buttonName._stringLength + buttonName._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Back" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsSelected
	{
		get
		{
			//IL_0172: Expected I4, but got O
			//IL_01ce: Expected O, but got I4
			//IL_01e8: Expected O, but got I4
			EventSystem unityEventSystem = UIComponentBase<UIButton>.UnityEventSystem;
			if ((object)unityEventSystem != null && ((UnityEngine.Object)unityEventSystem).m_CachedPtr != (IntPtr)0)
			{
				EventSystem unityEventSystem2 = UIComponentBase<UIButton>.UnityEventSystem;
				if ((object)unityEventSystem2 != null)
				{
					GameObject currentSelected = unityEventSystem2.m_CurrentSelected;
					GameObject gameObject = base.gameObject;
					bool flag = (object)gameObject == null;
					bool flag2 = (object)unityEventSystem2.m_CurrentSelected == null;
					object obj = flag2 & flag;
					bool flag3 = obj == null;
					object obj2 = !flag3;
					if (obj2 != null)
					{
						return true;
					}
					if ((object)gameObject != null)
					{
						if ((object)unityEventSystem2.m_CurrentSelected != null)
						{
							object obj3 = (object)unityEventSystem2.m_CurrentSelected - (object)gameObject;
							return obj3 == null;
						}
						return ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
					if ((object)unityEventSystem2.m_CurrentSelected != null)
					{
						return ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
	}

	public bool UpdateStartValuesRequired
	{
		get
		{
			return m_updateStartValuesRequired;
		}
		set
		{
			m_updateStartValuesRequired = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIButton)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIButton;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Reset()
	{
		UIButtonSettings instance = UIButtonSettings.Instance;
		instance.ResetComponent(this);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonName = "Unnamed";
		m_disableButtonCoroutine = null;
		DoubleClickRegisterInterval = 0.2f;
		m_clickedOnce = false;
		m_doubleClickTimeoutCounter = 0f;
		LongClickRegisterInterval = 0.5f;
		m_longClickTimeoutCounter = 0f;
		m_executedLongClick = false;
		m_longClickRegisterCoroutine = null;
	}

	public override void Awake()
	{
		base.Awake();
		LoadPresets();
	}

	public override void OnEnable()
	{
		if (!IsSelected)
		{
			StartNormalLoopAnimation();
		}
		else
		{
			StartSelectedLoopAnimation();
		}
	}

	public override void OnDisable()
	{
		RectTransform rectTransform = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform, AnimationType.Punch);
		RectTransform rectTransform2 = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform2, AnimationType.State);
		StopSelectedLoopAnimation();
		StopNormalLoopAnimation();
		base.ResetToStartValues();
		UIButtonBehavior onPointerEnter = OnPointerEnter;
		onPointerEnter.Ready = true;
		UIButtonBehavior onPointerExit = OnPointerExit;
		onPointerExit.Ready = true;
		UIButtonBehavior onPointerUp = OnPointerUp;
		onPointerUp.Ready = true;
		UIButtonBehavior onPointerDown = OnPointerDown;
		onPointerDown.Ready = true;
		UIButtonBehavior onClick = OnClick;
		onClick.Ready = true;
		UIButtonBehavior onDoubleClick = OnDoubleClick;
		onDoubleClick.Ready = true;
		UIButtonBehavior onLongClick = OnLongClick;
		onLongClick.Ready = true;
		UIButtonBehavior onRightClick = OnRightClick;
		onRightClick.Ready = true;
		UIButtonBehavior onSelected = OnSelected;
		onSelected.Ready = true;
		UIButtonBehavior onDeselected = OnDeselected;
		onDeselected.Ready = true;
		if (m_disableButtonCoroutine != null)
		{
			StopCoroutine(m_disableButtonCoroutine);
			m_disableButtonCoroutine = null;
			Button button = Button;
			button.interactable = true;
		}
	}

	private void Update()
	{
		InputData inputData = InputData;
		if (inputData.InputMode == InputMode.None || !IsSelected)
		{
			return;
		}
		InputData inputData2 = InputData;
		if (inputData2.InputMode == InputMode.KeyCode)
		{
			if (!UnityEngine.Input.GetKeyDownInt(inputData2.KeyCode))
			{
				InputData inputData3 = InputData;
				if (!inputData3.EnableAlternateInputs || !UnityEngine.Input.GetKeyDownInt(inputData3.KeyCodeAlt))
				{
					return;
				}
			}
		}
		else
		{
			if (inputData2.InputMode != InputMode.VirtualButton)
			{
				return;
			}
			if (!UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData2.VirtualButtonName))
			{
				InputData inputData4 = InputData;
				if (!inputData4.EnableAlternateInputs || !UnityEngine.Internal.InputUnsafeUtility.GetButtonDown(inputData4.VirtualButtonNameAlt))
				{
					return;
				}
			}
		}
		ExecuteClick();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		TriggerButtonBehavior(OnPointerEnter);
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		TriggerButtonBehavior(OnPointerExit);
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		TriggerButtonBehavior(OnPointerDown);
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		TriggerButtonBehavior(OnPointerUp);
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (eventData._003Cbutton_003Ek__BackingField != PointerEventData.InputButton.Left)
		{
			if (eventData._003Cbutton_003Ek__BackingField == PointerEventData.InputButton.Right)
			{
				TriggerButtonBehavior(OnRightClick);
			}
		}
		else
		{
			TriggerButtonBehavior(OnClick);
		}
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		//IL_0166: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		EventSystem eventSystem = eventData.m_EventSystem;
		GameObject currentSelected = eventSystem.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)eventSystem.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)eventSystem.m_CurrentSelected != null)
				{
					object obj3 = (object)eventSystem.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		StopNormalLoopAnimation();
		UIButtonBehavior onSelected = OnSelected;
		if (onSelected.Enabled)
		{
			TriggerButtonBehavior(onSelected);
		}
		else
		{
			StartSelectedLoopAnimation();
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		//IL_0166: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		EventSystem eventSystem = eventData.m_EventSystem;
		GameObject currentSelected = eventSystem.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)eventSystem.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)eventSystem.m_CurrentSelected != null)
				{
					object obj3 = (object)eventSystem.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		StopSelectedLoopAnimation();
		UIButtonBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled)
		{
			TriggerButtonBehavior(onDeselected);
		}
		else
		{
			StartNormalLoopAnimation();
		}
	}

	public void DeselectButton()
	{
		if (IsSelected)
		{
			EventSystem unityEventSystem = UIComponentBase<UIButton>.UnityEventSystem;
			unityEventSystem.SetSelectedGameObject(null);
		}
	}

	public void DeselectButton(float delay)
	{
		_003CDeselectButtonEnumerator_003Ed__102 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.delay = delay;
		Coroutine coroutine = Coroutiner.Start(obj);
	}

	public void DisableButton()
	{
		Button button = Button;
		button.interactable = false;
	}

	public void DisableButton(float duration)
	{
		Button button = Button;
		if (((Selectable)button).m_Interactable)
		{
			Button button2 = Button;
			button2.interactable = false;
			_003CDisableButtonEnumerator_003Ed__104 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.duration = duration;
			Coroutine disableButtonCoroutine = StartCoroutine(obj);
			m_disableButtonCoroutine = disableButtonCoroutine;
		}
	}

	public void EnableButton()
	{
		Button button = Button;
		button.interactable = true;
	}

	public void ExecutePointerEnter(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980649]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onPointerEnter = OnPointerEnter;
		if (onPointerEnter.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerEnter, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnPointerEnter);
			Coroutine coroutine = StartCoroutine(routine);
			UIButtonBehavior onPointerEnter2 = OnPointerEnter;
			if (onPointerEnter2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableButtonBehaviorEnumerator(onPointerEnter2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnPointerEnter, "executed", debug);
		}
		else
		{
			StopNormalLoopAnimation();
			StopSelectedLoopAnimation();
		}
	}

	public void ExecutePointerExit(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onPointerExit = OnPointerExit;
		if (onPointerExit.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerExit, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnPointerExit);
			Coroutine coroutine = StartCoroutine(routine);
			UIButtonBehavior onPointerExit2 = OnPointerExit;
			if (onPointerExit2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableButtonBehaviorEnumerator(onPointerExit2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
		}
	}

	public void ExecutePointerDown(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ResetLongClick(debug);
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			Button button = Button;
			if (((Selectable)button).m_Interactable)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998065B]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				UIButtonBehavior onLongClick2 = OnLongClick;
				if (onLongClick2.Enabled)
				{
					PrintBehaviorDebugMessage(onLongClick2, "registered");
				}
				if (!m_executedLongClick)
				{
					ResetLongClick();
					_003CRunOnLongClickEnumerator_003Ed__107 obj = null;
					obj._003C_003E1__state = 0;
					obj._003C_003E4__this = this;
					obj.debug = false;
					Coroutine longClickRegisterCoroutine = StartCoroutine(obj);
					m_longClickRegisterCoroutine = longClickRegisterCoroutine;
				}
			}
		}
		UIButtonBehavior onPointerDown = OnPointerDown;
		if (onPointerDown.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerDown, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnPointerDown);
			Coroutine coroutine = StartCoroutine(routine);
			PrintBehaviorDebugMessage(OnPointerDown, "executed", debug);
		}
	}

	public void ExecutePointerUp(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998065C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			PrintBehaviorDebugMessage(onLongClick, "unregistered");
		}
		if (!m_executedLongClick)
		{
			ResetLongClick();
		}
		UIButtonBehavior onPointerUp = OnPointerUp;
		if (onPointerUp.Enabled)
		{
			PrintBehaviorDebugMessage(onPointerUp, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnPointerUp);
			Coroutine coroutine = StartCoroutine(routine);
			PrintBehaviorDebugMessage(OnPointerUp, "executed", debug);
		}
	}

	public void ExecuteClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onClick = OnClick;
		if (onClick.Enabled)
		{
			PrintBehaviorDebugMessage(onClick, "initiated", debug);
			Button button = Button;
			if (((Selectable)button).m_Interactable)
			{
				IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnClick);
				Coroutine coroutine = StartCoroutine(routine);
				PrintBehaviorDebugMessage(OnClick, "executed", debug);
			}
			if (!AllowMultipleClicks)
			{
				DisableButton(DisableButtonBetweenClicksInterval);
			}
		}
		Button button2 = Button;
		if (!((Selectable)button2).m_Interactable)
		{
			UIButtonBehavior onPointerExit = OnPointerExit;
			if (onPointerExit.Enabled && onPointerExit.Ready)
			{
				IEnumerator routine2 = ExecuteButtonBehaviorEnumerator(onPointerExit);
				Coroutine coroutine2 = StartCoroutine(routine2);
				PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
			}
		}
	}

	public void ExecuteDoubleClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onDoubleClick = OnDoubleClick;
		if (onDoubleClick.Enabled)
		{
			PrintBehaviorDebugMessage(onDoubleClick, "initiated", debug);
			Button button = Button;
			if (((Selectable)button).m_Interactable)
			{
				IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnDoubleClick);
				Coroutine coroutine = StartCoroutine(routine);
				PrintBehaviorDebugMessage(OnDoubleClick, "executed", debug);
			}
			if (!AllowMultipleClicks)
			{
				DisableButton(DisableButtonBetweenClicksInterval);
			}
		}
		Button button2 = Button;
		if (!((Selectable)button2).m_Interactable)
		{
			UIButtonBehavior onPointerExit = OnPointerExit;
			if (onPointerExit.Enabled && onPointerExit.Ready)
			{
				IEnumerator routine2 = ExecuteButtonBehaviorEnumerator(onPointerExit);
				Coroutine coroutine2 = StartCoroutine(routine2);
				PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
			}
		}
	}

	public void ExecuteLongClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998064F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			PrintBehaviorDebugMessage(onLongClick, "initiated", debug);
			Button button = Button;
			if (((Selectable)button).m_Interactable)
			{
				IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnLongClick);
				Coroutine coroutine = StartCoroutine(routine);
				PrintBehaviorDebugMessage(OnLongClick, "executed", debug);
			}
			if (!AllowMultipleClicks)
			{
				DisableButton(DisableButtonBetweenClicksInterval);
			}
		}
		Button button2 = Button;
		if (!((Selectable)button2).m_Interactable)
		{
			UIButtonBehavior onPointerExit = OnPointerExit;
			if (onPointerExit.Enabled && onPointerExit.Ready)
			{
				IEnumerator routine2 = ExecuteButtonBehaviorEnumerator(onPointerExit);
				Coroutine coroutine2 = StartCoroutine(routine2);
				PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
			}
		}
	}

	public void ExecuteRightClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980650]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onRightClick = OnRightClick;
		if (onRightClick.Enabled)
		{
			PrintBehaviorDebugMessage(onRightClick, "initiated", debug);
			Button button = Button;
			if (((Selectable)button).m_Interactable)
			{
				IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnRightClick);
				Coroutine coroutine = StartCoroutine(routine);
				PrintBehaviorDebugMessage(OnClick, "OnRightClick", debug);
			}
			if (!AllowMultipleClicks)
			{
				DisableButton(DisableButtonBetweenClicksInterval);
			}
		}
		Button button2 = Button;
		if (!((Selectable)button2).m_Interactable)
		{
			UIButtonBehavior onPointerExit = OnPointerExit;
			if (onPointerExit.Enabled && onPointerExit.Ready)
			{
				IEnumerator routine2 = ExecuteButtonBehaviorEnumerator(onPointerExit);
				Coroutine coroutine2 = StartCoroutine(routine2);
				PrintBehaviorDebugMessage(OnPointerExit, "executed", debug);
			}
		}
	}

	public void ExecuteOnButtonDeselected(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980651]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled)
		{
			PrintBehaviorDebugMessage(onDeselected, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnDeselected);
			Coroutine coroutine = StartCoroutine(routine);
			UIButtonBehavior onDeselected2 = OnDeselected;
			if (onDeselected2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableButtonBehaviorEnumerator(onDeselected2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnDeselected, "executed", debug);
		}
	}

	public void ExecuteOnButtonSelected(bool debug = false)
	{
		//IL_00a8: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980652]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onSelected = OnSelected;
		if (onSelected.Enabled)
		{
			PrintBehaviorDebugMessage(onSelected, "initiated", debug);
			IEnumerator routine = ExecuteButtonBehaviorEnumerator(OnSelected);
			Coroutine coroutine = StartCoroutine(routine);
			UIButtonBehavior onSelected2 = OnSelected;
			if (onSelected2.DisableInterval > 0f)
			{
				IEnumerator routine2 = DisableButtonBehaviorEnumerator(onSelected2);
				Coroutine coroutine2 = StartCoroutine(routine2);
			}
			PrintBehaviorDebugMessage(OnSelected, "executed", debug);
		}
	}

	public void LoadPresets()
	{
		UIButtonBehavior onPointerEnter = OnPointerEnter;
		if (onPointerEnter.Enabled && onPointerEnter.LoadSelectedPresetAtRuntime)
		{
			onPointerEnter.LoadPreset();
		}
		UIButtonBehavior onPointerExit = OnPointerExit;
		if (onPointerExit.Enabled && onPointerExit.LoadSelectedPresetAtRuntime)
		{
			onPointerExit.LoadPreset();
		}
		UIButtonBehavior onPointerDown = OnPointerDown;
		if (onPointerDown.Enabled && onPointerDown.LoadSelectedPresetAtRuntime)
		{
			onPointerDown.LoadPreset();
		}
		UIButtonBehavior onPointerUp = OnPointerUp;
		if (onPointerUp.Enabled && onPointerUp.LoadSelectedPresetAtRuntime)
		{
			onPointerUp.LoadPreset();
		}
		UIButtonBehavior onClick = OnClick;
		if (onClick.Enabled && onClick.LoadSelectedPresetAtRuntime)
		{
			onClick.LoadPreset();
		}
		UIButtonBehavior onDoubleClick = OnDoubleClick;
		if (onDoubleClick.Enabled && onDoubleClick.LoadSelectedPresetAtRuntime)
		{
			onDoubleClick.LoadPreset();
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled && onLongClick.LoadSelectedPresetAtRuntime)
		{
			onLongClick.LoadPreset();
		}
		UIButtonBehavior onSelected = OnSelected;
		if (onSelected.Enabled && onSelected.LoadSelectedPresetAtRuntime)
		{
			onSelected.LoadPreset();
		}
		UIButtonBehavior onDeselected = OnDeselected;
		if (onDeselected.Enabled && onDeselected.LoadSelectedPresetAtRuntime)
		{
			onDeselected.LoadPreset();
		}
		UIButtonLoopAnimation normalLoopAnimation = NormalLoopAnimation;
		if (normalLoopAnimation.Enabled && normalLoopAnimation.LoadSelectedPresetAtRuntime)
		{
			normalLoopAnimation.LoadPreset();
		}
		UIButtonLoopAnimation selectedLoopAnimation = SelectedLoopAnimation;
		if (selectedLoopAnimation.Enabled && selectedLoopAnimation.LoadSelectedPresetAtRuntime)
		{
			selectedLoopAnimation.LoadPreset();
		}
	}

	public void NotifySystemOfTriggeredBehavior(UIButtonBehaviorType behaviorType)
	{
		if (OnUIButtonAction != null)
		{
			Action<UIButton, UIButtonBehaviorType> onUIButtonAction = OnUIButtonAction;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v82 @ r10_v3 (System.Action`2<Doozy.Engine.UI.UIButton, Doozy.Engine.UI.UIButtonBehaviorType>)+18] (should have been resolved before IL gen)");
		}
		UIButtonMessage uIButtonMessage = null;
		uIButtonMessage.ButtonName = ButtonName;
		uIButtonMessage.Button = this;
		uIButtonMessage.Type = behaviorType;
		Message.Send(uIButtonMessage);
	}

	public void SelectButton()
	{
		EventSystem unityEventSystem = UIComponentBase<UIButton>.UnityEventSystem;
		GameObject selectedGameObject = base.gameObject;
		unityEventSystem.SetSelectedGameObject(selectedGameObject);
	}

	public void SetLabelText(string text)
	{
		if (TargetLabel != TargetLabel.None && TargetLabel == TargetLabel.Text)
		{
			Text textLabel = TextLabel;
			bool flag2;
			if ((object)TextLabel != null)
			{
				bool flag = ((UnityEngine.Object)textLabel).m_CachedPtr == (IntPtr)0;
				flag2 = !flag;
			}
			else
			{
				flag2 = false;
			}
			if (flag2 && TargetLabel == TargetLabel.Text)
			{
				TextLabel.text = text;
			}
		}
	}

	public unsafe void StartNormalLoopAnimation()
	{
		//IL_005d: Expected O, but got Ref
		//IL_005d: Expected O, but got Ref
		if (NormalLoopAnimation != null)
		{
			UIButtonLoopAnimation normalLoopAnimation = NormalLoopAnimation;
			if (normalLoopAnimation.Enabled)
			{
				base.ResetToStartValues();
				RectTransform rectTransform = base.RectTransform;
				object obj = default(object);
				object obj2 = default(object);
				NormalLoopAnimation.Start(rectTransform, (Vector3)(&obj), (Vector3)(&obj2));
			}
		}
	}

	public unsafe void StartSelectedLoopAnimation()
	{
		//IL_005d: Expected O, but got Ref
		//IL_005d: Expected O, but got Ref
		if (SelectedLoopAnimation != null)
		{
			UIButtonLoopAnimation selectedLoopAnimation = SelectedLoopAnimation;
			if (selectedLoopAnimation.Enabled)
			{
				base.ResetToStartValues();
				RectTransform rectTransform = base.RectTransform;
				object obj = default(object);
				object obj2 = default(object);
				SelectedLoopAnimation.Start(rectTransform, (Vector3)(&obj), (Vector3)(&obj2));
			}
		}
	}

	public void StopNormalLoopAnimation()
	{
		if (NormalLoopAnimation != null)
		{
			UIButtonLoopAnimation normalLoopAnimation = NormalLoopAnimation;
			if (normalLoopAnimation.IsPlaying)
			{
				RectTransform rectTransform = base.RectTransform;
				normalLoopAnimation.Stop(rectTransform);
				base.ResetToStartValues();
			}
		}
	}

	public void StopSelectedLoopAnimation()
	{
		if (SelectedLoopAnimation != null)
		{
			UIButtonLoopAnimation selectedLoopAnimation = SelectedLoopAnimation;
			if (selectedLoopAnimation.IsPlaying)
			{
				RectTransform rectTransform = base.RectTransform;
				selectedLoopAnimation.Stop(rectTransform);
				base.ResetToStartValues();
			}
		}
	}

	private unsafe void PrintBehaviorDebugMessage(UIButtonBehavior behavior, string action, bool debug = false)
	{
		//IL_006b: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIButton)+20]");
		bool flag = (nint)0 == 0;
		if (flag)
		{
			DoozySettings instance = DoozySettings.Instance;
			flag = (object)instance == null;
		}
		if (!flag)
		{
			string[] array = new string[7];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array);
			DDebug.Log(message, this);
		}
	}

	private void TriggerButtonBehavior(UIButtonBehavior behavior, bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 44 Invalid \"Jump target not found in method: 0x182B9A9E7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 59 Invalid \"Jump target not found in method: 0x182B9A2B8\"");
	}

	private void InitiateClick(bool debug = false)
	{
		if (!m_executedLongClick)
		{
			_003CRunOnClickEnumerator_003Ed__106 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.debug = debug;
			Coroutine coroutine = StartCoroutine(obj);
		}
		else
		{
			ResetLongClick(debug);
		}
	}

	private void ReadyAllBehaviors()
	{
		UIButtonBehavior onPointerEnter = OnPointerEnter;
		onPointerEnter.Ready = true;
		UIButtonBehavior onPointerExit = OnPointerExit;
		onPointerExit.Ready = true;
		UIButtonBehavior onPointerUp = OnPointerUp;
		onPointerUp.Ready = true;
		UIButtonBehavior onPointerDown = OnPointerDown;
		onPointerDown.Ready = true;
		UIButtonBehavior onClick = OnClick;
		onClick.Ready = true;
		UIButtonBehavior onDoubleClick = OnDoubleClick;
		onDoubleClick.Ready = true;
		UIButtonBehavior onLongClick = OnLongClick;
		onLongClick.Ready = true;
		UIButtonBehavior onRightClick = OnRightClick;
		onRightClick.Ready = true;
		UIButtonBehavior onSelected = OnSelected;
		onSelected.Ready = true;
		UIButtonBehavior onDeselected = OnDeselected;
		onDeselected.Ready = true;
	}

	private void RegisterLongClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998065B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			PrintBehaviorDebugMessage(onLongClick, "registered", debug);
		}
		if (!m_executedLongClick)
		{
			ResetLongClick(debug);
			_003CRunOnLongClickEnumerator_003Ed__107 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.debug = debug;
			Coroutine longClickRegisterCoroutine = StartCoroutine(obj);
			m_longClickRegisterCoroutine = longClickRegisterCoroutine;
		}
	}

	private void UnregisterLongClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998065C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			PrintBehaviorDebugMessage(onLongClick, "unregistered", debug);
		}
		if (!m_executedLongClick)
		{
			ResetLongClick(debug);
		}
	}

	private void ResetLongClick(bool debug = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998065D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonBehavior onLongClick = OnLongClick;
		if (onLongClick.Enabled)
		{
			PrintBehaviorDebugMessage(onLongClick, "reset", debug);
		}
		bool flag = m_longClickRegisterCoroutine == null;
		m_executedLongClick = false;
		m_longClickTimeoutCounter = 0f;
		if (!flag)
		{
			StopCoroutine(m_longClickRegisterCoroutine);
			m_longClickRegisterCoroutine = null;
		}
	}

	private bool BehaviorEnabled(UIButtonBehaviorType behaviorType)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (behaviorType <= UIButtonBehaviorType.OnRightClick)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ r9_v2+2B9AFE0+behaviorType @ rdx (Doozy.Engine.UI.UIButtonBehaviorType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ r8_v3 (should have been resolved before IL gen)");
		}
		UIButtonBehaviorType uIButtonBehaviorType = default(UIButtonBehaviorType);
		object actualValue = uIButtonBehaviorType;
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("behaviorType", actualValue, null);
		throw ex;
	}

	private IEnumerator DeselectButtonEnumerator(float delay)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CDeselectButtonEnumerator_003Ed__102 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.delay = delay;
			return obj;
		}
		obj.delay = delay;
		return obj;
	}

	private IEnumerator ExecuteButtonBehaviorEnumerator(UIButtonBehavior behavior)
	{
		_003CExecuteButtonBehaviorEnumerator_003Ed__103 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.behavior = behavior;
		return obj;
	}

	private IEnumerator DisableButtonEnumerator(float duration)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CDisableButtonEnumerator_003Ed__104 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.duration = duration;
			return obj;
		}
		obj.duration = duration;
		return obj;
	}

	private IEnumerator DisableButtonBehaviorEnumerator(UIButtonBehavior behavior)
	{
		_003CDisableButtonBehaviorEnumerator_003Ed__105 obj = null;
		obj._003C_003E1__state = 0;
		obj.behavior = behavior;
		return obj;
	}

	private IEnumerator RunOnClickEnumerator(bool debug = false)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CRunOnClickEnumerator_003Ed__106 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.debug = debug;
			return obj;
		}
		obj.debug = debug;
		return obj;
	}

	private IEnumerator RunOnLongClickEnumerator(bool debug = false)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CRunOnLongClickEnumerator_003Ed__107 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.debug = debug;
			return obj;
		}
		obj.debug = debug;
		return obj;
	}

	public unsafe static List<UIButton> GetButtons(string buttonCategory, string buttonName)
	{
		//IL_031b: Expected I, but got O
		//IL_0017: Expected O, but got Ref
		List<UIButton> result = new List<UIButton>();
		nint num = (nint)typeof(UIComponentBase<UIButton>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppClass<Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIButton>>)+E4]");
		bool flag = (nint)0 != 0;
		List<UIButton> database = UIComponentBase<UIButton>.Database;
		List<UIButton>.Enumerator enumerator = default(List<UIButton>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = null;
			List<UIButton>.Enumerator enumerator2 = (List<UIButton>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public UIButton()
	{
		InputData inputData = new InputData();
		InputData = inputData;
		UIButtonBehavior uIButtonBehavior = null;
		uIButtonBehavior.Reset(UIButtonBehaviorType.OnPointerEnter);
		uIButtonBehavior.Enabled = false;
		OnPointerEnter = uIButtonBehavior;
		UIButtonBehavior uIButtonBehavior2 = null;
		uIButtonBehavior2.Reset(UIButtonBehaviorType.OnPointerExit);
		uIButtonBehavior2.Enabled = false;
		OnPointerExit = uIButtonBehavior2;
		UIButtonBehavior uIButtonBehavior3 = null;
		uIButtonBehavior3.Reset(UIButtonBehaviorType.OnPointerDown);
		uIButtonBehavior3.Enabled = false;
		OnPointerDown = uIButtonBehavior3;
		UIButtonBehavior uIButtonBehavior4 = null;
		uIButtonBehavior4.Reset(UIButtonBehaviorType.OnPointerUp);
		uIButtonBehavior4.Enabled = false;
		OnPointerUp = uIButtonBehavior4;
		UIButtonBehavior uIButtonBehavior5 = null;
		uIButtonBehavior5.Reset(UIButtonBehaviorType.OnClick);
		uIButtonBehavior5.Enabled = false;
		OnClick = uIButtonBehavior5;
		UIButtonBehavior uIButtonBehavior6 = null;
		uIButtonBehavior6.Reset(UIButtonBehaviorType.OnDoubleClick);
		uIButtonBehavior6.Enabled = false;
		OnDoubleClick = uIButtonBehavior6;
		UIButtonBehavior uIButtonBehavior7 = null;
		uIButtonBehavior7.Reset(UIButtonBehaviorType.OnLongClick);
		uIButtonBehavior7.Enabled = false;
		OnLongClick = uIButtonBehavior7;
		UIButtonBehavior uIButtonBehavior8 = null;
		uIButtonBehavior8.Reset(UIButtonBehaviorType.OnRightClick);
		uIButtonBehavior8.Enabled = false;
		OnRightClick = uIButtonBehavior8;
		UIButtonBehavior uIButtonBehavior9 = null;
		uIButtonBehavior9.Reset(UIButtonBehaviorType.OnSelected);
		uIButtonBehavior9.Enabled = false;
		OnSelected = uIButtonBehavior9;
		UIButtonBehavior uIButtonBehavior10 = null;
		uIButtonBehavior10.Reset(UIButtonBehaviorType.OnDeselected);
		uIButtonBehavior10.Enabled = false;
		OnDeselected = uIButtonBehavior10;
		NormalLoopAnimation = new UIButtonLoopAnimation(ButtonLoopAnimationType.Normal);
		SelectedLoopAnimation = new UIButtonLoopAnimation(ButtonLoopAnimationType.Selected);
		base._002Ector();
	}

	static UIButton()
	{
		Action<UIButton, UIButtonBehaviorType> onUIButtonAction = delegate
		{
		};
		OnUIButtonAction = onUIButtonAction;
	}
}

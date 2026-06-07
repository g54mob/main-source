using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamgam.UGUIComponentsForSettings
{
	[Serializable]
	public class InputBindingForInputSystem : IInputBindingForGUI
	{
		public enum LocalConfigBehaviours
		{
			OverrideGlobalIfLocalExists = 0,
			AppendLocalToGlobal = 1
		}

		public delegate Action OnBeforeRebindStartDelegate(InputActionRebindingExtensions.RebindingOperation rebindingOpteration);

		[Tooltip("Defines how the paths configs should be combined with the GLOBAL path configs. See IputBindingUGUI.cs")]
		public LocalConfigBehaviours LocalConfigBehaviour = LocalConfigBehaviours.AppendLocalToGlobal;

		public static string[] GlobalIgnoreControlPaths = new string[4] { "<Pointer>/position", "<Pointer>/delta", "<Pointer>/{PrimaryAction}", "<Mouse>/clickCount" };

		public static string[] GlobalAbortControlPaths = new string[2] { "<Keyboard>/escape", "<Gamepad>/start" };

		[Tooltip("Local ignore control paths. These are handed to RebindingOperation.WithControlsExcluding().")]
		public string[] IgnoreControlPaths = new string[0];

		[Tooltip("Local abort control paths. These are handed to RebindingOperation.WithCancelingThrough().")]
		public string[] AbortControlPaths = new string[0];

		public static string GlobalControlsHavingToMatchPath;

		public string ControlsHavingToMatchPath;

		[Tooltip("Local match paths. Used to limit the controls which react to this input.\nExample: Set to <Keyboard>/* to limit to keyboard inputs only or <Gamepad>/<Button> for gamepad buttons.")]
		public string[] MatchControlPaths = new string[0];

		[Tooltip("At runtime this is the selected binding path.")]
		[SerializeField]
		protected string _bindingPath = "<Keyboard>/space";

		public OnBeforeRebindStartDelegate OnBeforeRebindStart;

		protected InputActionRebindingExtensions.RebindingOperation _rebindingOperation;

		public event Action OnComplete;

		public event Action OnCanceled;

		public string GetBindingPath()
		{
			return _bindingPath;
		}

		public void SetBindingPath(string path)
		{
			_bindingPath = path;
		}

		public void AddOnCompleteCallback(Action callback)
		{
			OnComplete += callback;
		}

		public void RemoveOnCompleteCallback(Action callback)
		{
			OnComplete -= callback;
		}

		public void AddOnCanceledCallback(Action callback)
		{
			OnCanceled += callback;
		}

		public void RemoveOnCanceledCallback(Action callback)
		{
			OnCanceled -= callback;
		}

		public void StartListening()
		{
			InputUtils.ResetStuckKeyStates();
			_rebindingOperation = new InputActionRebindingExtensions.RebindingOperation();
			string[] array = resolveConfigStrings(GlobalIgnoreControlPaths, IgnoreControlPaths);
			foreach (string path in array)
			{
				_rebindingOperation.WithControlsExcluding(path);
			}
			string[] abortControlPaths = resolveConfigStrings(GlobalAbortControlPaths, AbortControlPaths);
			_rebindingOperation.OnPotentialMatch(delegate(InputActionRebindingExtensions.RebindingOperation operation)
			{
				if (InputSystem.version.CompareTo(Version.Parse("1.4.1")) < 0)
				{
					string[] array2 = abortControlPaths;
					foreach (string text3 in array2)
					{
						string text4 = text3;
						if (text4[0] == '<')
						{
							text4 = "/" + text4;
						}
						text4 = Regex.Replace(text4, "[><{}*]+", "");
						text4 = text4.ToLower();
						string text5 = operation.selectedControl.path.ToLower();
						int num = text5.IndexOf("/");
						int num2 = text5.Length - num;
						int num3 = text4.IndexOf("/");
						int num4 = text4.Length - num3;
						if (Mathf.Abs(num2 - num4) <= 1 && InputControlPath.Matches(text3, operation.selectedControl))
						{
							_rebindingOperation.Cancel();
							break;
						}
					}
				}
				else
				{
					string[] array2 = abortControlPaths;
					for (int j = 0; j < array2.Length; j++)
					{
						if (InputControlPath.Matches(array2[j], operation.selectedControl))
						{
							_rebindingOperation.Cancel();
							break;
						}
					}
				}
			});
			array = MatchControlPaths;
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					_rebindingOperation.WithControlsHavingToMatchPath(text);
				}
			}
			string text2 = resolveConfigString(GlobalControlsHavingToMatchPath, ControlsHavingToMatchPath);
			if (!string.IsNullOrEmpty(text2))
			{
				_rebindingOperation.WithControlsHavingToMatchPath(text2);
			}
			_rebindingOperation.OnMatchWaitForAnother(0.1f);
			_rebindingOperation.OnApplyBinding(delegate(InputActionRebindingExtensions.RebindingOperation rebindingOp, string bindingPath)
			{
				rebindingOp.Dispose();
				_rebindingOperation = null;
				SetBindingPath(bindingPath);
				this.OnComplete?.Invoke();
			});
			_rebindingOperation.OnCancel(delegate(InputActionRebindingExtensions.RebindingOperation rebindingOp)
			{
				rebindingOp.Dispose();
				_rebindingOperation = null;
				this.OnCanceled?.Invoke();
			});
			OnBeforeRebindStart?.Invoke(_rebindingOperation);
			_rebindingOperation.Start();
		}

		protected string[] resolveConfigStrings(string[] globals, string[] locals)
		{
			if (LocalConfigBehaviour == LocalConfigBehaviours.OverrideGlobalIfLocalExists)
			{
				if (locals != null && locals.Length != 0)
				{
					return locals;
				}
				return globals;
			}
			if (LocalConfigBehaviour == LocalConfigBehaviours.AppendLocalToGlobal)
			{
				if (globals == null)
				{
					return locals;
				}
				List<string> list = new List<string>(globals);
				if (locals != null && locals.Length != 0)
				{
					list.AddRange(locals);
				}
				return list.ToArray();
			}
			return new string[0];
		}

		protected string resolveConfigString(string global, string local)
		{
			if (LocalConfigBehaviour == LocalConfigBehaviours.OverrideGlobalIfLocalExists)
			{
				if (!string.IsNullOrEmpty(local))
				{
					return local;
				}
				return global;
			}
			if (LocalConfigBehaviour == LocalConfigBehaviours.AppendLocalToGlobal)
			{
				if (global == null)
				{
					return local;
				}
				string text = global;
				if (!string.IsNullOrEmpty(local))
				{
					text += local;
				}
				return text;
			}
			return null;
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
			if (_rebindingOperation != null)
			{
				_rebindingOperation.Cancel();
				if (_rebindingOperation != null)
				{
					_rebindingOperation.Dispose();
					_rebindingOperation = null;
				}
			}
		}
	}
}

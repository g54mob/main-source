using System;
using System.Collections;
using System.Collections.Generic;
using Coherence.Log;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

internal class SimulatorFramerate
{
	public class SimulatorFramerateLimiter : MonoBehaviour
	{
		private sealed class _003CForceTargetFrameRateLoop_003Ed__8(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state = _003C_003E1__state;

			private object _003C_003E2__current;

			public SimulatorFramerateLimiter _003C_003E4__this;

			object IEnumerator<object>.Current => _003C_003E2__current;

			object IEnumerator.Current => _003C_003E2__current;

			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				//IL_0031: Expected I4, but got I8
				//IL_0067: Expected I4, but got I8
				//IL_00c7: Expected I4, but got O
				if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
				}
				else
				{
					if (_003C_003E1__state != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					_003C_003E4__this.ForceTargetFrameRate();
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
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

		private Coherence.Log.Logger logger;

		private static int targetFrameRate = 30;

		private Coroutine loop;

		private bool changed;

		public static void Init()
		{
			if (SimulatorUtility.IsSimulator)
			{
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, (string)null);
				SimulatorFramerateLimiter simulatorFramerateLimiter = gameObject.AddComponent<SimulatorFramerateLimiter>();
				gameObject.hideFlags = HideFlags.HideInHierarchy;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}

		private unsafe void Awake()
		{
			//IL_005f: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_0042: Expected O, but got I
			Coherence.Log.Logger logger = this.logger;
			nint num = (nint)typeof(SimulatorFramerateLimiter);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3 (Il2CppClass<Coherence.SimulatorFramerate+SimulatorFramerateLimiter>)+B8]");
				string text = ((int*)null)->ToString();
				string log = "Forcing simulator target frame rate to " + text;
				(string, object)[] args = Array.Empty<(string, object)>();
				nint num2 = (nint)logger;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r10_v2 (Il2CppClass<Coherence.Log.Logger>)+1F0]");
				object obj = 0;
				logger.Info(log, args);
				int num3 = targetFrameRate;
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ rax_v14 (should have been resolved before IL gen)");
			}
		}

		private void OnEnable()
		{
			_003CForceTargetFrameRateLoop_003Ed__8 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			loop = coroutine;
		}

		private void OnDisable()
		{
			if (loop != null)
			{
				StopCoroutine(loop);
				loop = null;
			}
		}

		private IEnumerator ForceTargetFrameRateLoop()
		{
			_003CForceTargetFrameRateLoop_003Ed__8 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			return obj;
		}

		private unsafe void ForceTargetFrameRate()
		{
			//IL_0095: Expected O, but got I4
			//IL_00a9: Expected O, but got I4
			//IL_00cf: Expected O, but got Ref
			//IL_00fe: Expected O, but got Ref
			object obj = Application.targetFrameRate;
			if ((nint)obj != targetFrameRate)
			{
				if (!changed)
				{
					changed = true;
					object obj2 = Application.targetFrameRate;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					System.ParamsArray paramsArray2 = default(System.ParamsArray);
					string text = string.FormatHelper((IFormatProvider)null, "Detected target frame rate {0}.\n", (System.ParamsArray)(&paramsArray2));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg2 = default(object);
					paramsArray2 = new System.ParamsArray(arg2);
					object obj3 = default(object);
					string text2 = string.FormatHelper((IFormatProvider)null, "Simulators target frame rate is forced to {0} every frame.", (System.ParamsArray)(&obj3));
					string msg = text + text2;
					(string, object)[] args = Array.Empty<(string, object)>();
					logger.Warning(Warning.SimulatorFrameRateChanged, msg, args);
				}
				Application.targetFrameRate = targetFrameRate;
			}
		}

		public SimulatorFramerateLimiter()
		{
			//IL_0038: Expected I, but got O
			Coherence.Log.Logger logger = Coherence.Log.Log.GetLogger<SimulatorFramerateLimiter>();
			this.logger = logger;
			nint num = (nint)typeof(UnityEngine.Object);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v6 (Il2CppClass<UnityEngine.Object>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	private static void Init()
	{
		if (SimulatorUtility.IsSimulator)
		{
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			SimulatorFramerateLimiter simulatorFramerateLimiter = gameObject.AddComponent<SimulatorFramerateLimiter>();
			gameObject.hideFlags = HideFlags.HideInHierarchy;
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[DefaultExecutionOrder(500000000)]
	public class MScriptableCoroutine : MonoBehaviour
	{
		internal List<ScriptableCoroutine> ScriptableCoroutines;

		public static MScriptableCoroutine Main;

		internal void Restart()
		{
			if (Main == null)
			{
				Main = this;
				ScriptableCoroutines = new List<ScriptableCoroutine>();
				base.transform.parent = null;
				Object.DontDestroyOnLoad(base.transform);
			}
			else
			{
				Object.Destroy(this);
			}
		}

		private void Awake()
		{
			Restart();
		}

		public static void PlayCoroutine(ScriptableCoroutine SC, IEnumerator Coroutine)
		{
			Initialize();
			if (Main != null && Main.enabled && Main.isActiveAndEnabled)
			{
				if (!Main.ScriptableCoroutines.Contains(SC))
				{
					Main.ScriptableCoroutines.Add(SC);
				}
				Main.StartCoroutine(Coroutine);
			}
		}

		public static void Stop_Coroutine(IEnumerator Coroutine)
		{
			Main.StopCoroutine(Coroutine);
		}

		public static void Initialize()
		{
			if (Main == null && Application.isPlaying)
			{
				GameObject obj = new GameObject();
				obj.name = "Scriptable Coroutines";
				obj.AddComponent<MScriptableCoroutine>();
			}
		}

		protected virtual void OnDisable()
		{
			if (ScriptableCoroutines != null)
			{
				foreach (ScriptableCoroutine scriptableCoroutine in ScriptableCoroutines)
				{
					scriptableCoroutine.CleanCoroutine();
				}
			}
			StopAllCoroutines();
		}
	}
}

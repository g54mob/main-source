using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MapSceneFogOfWarControl : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_SceneTimeChangeEffect_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapSceneFogOfWarControl _003C_003E4__this;

		public float duration;

		public float from;

		public float to;

		private float _003Ctime_003E5__2;

		private Color _003Ccolor_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_SceneTimeChangeEffect_003Ed__13(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Camera uiCamera;

	[SerializeField]
	private Image image_FogOfWarEffect;

	[SerializeField]
	private Material fogOfWar_Material;

	private Material runtimeMaterial;

	private Vector3 posVector;

	private Vector3 delta;

	private Vector3 camStartPos;

	private void Reset()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnStartSceneTimeChange(eSceneTimeType type, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SceneTimeChangeEffect_003Ed__13))]
	private IEnumerator CR_SceneTimeChangeEffect(float from, float to, float duration)
	{
		return null;
	}
}

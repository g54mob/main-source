using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[Obsolete("Use GenericLOD instead")]
public class OccludeeData : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeCoroutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OccludeeData _003C_003E4__this;

		public bool value;

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
		public _003CFadeCoroutine_003Ed__15(int _003C_003E1__state)
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

	public Vector3 Offset;

	public Light[] Lights;

	public Renderer[] Renderers;

	public TMP_Text[] Texts;

	public float OccludeeRadius;

	[SerializeField]
	private GameObject m_LowQualityRepresentation;

	private Renderer m_LowQualityRepresentationRenderer;

	private const float XFADE_DURATION = 0.4f;

	private static int m_LqrAlphaId;

	private Coroutine m_FadeCoroutine;

	private void Awake()
	{
	}

	public void OnDistanceBandChanged(int sphereCurrentDistance, int spherePreviousDistance)
	{
	}

	public void OnHasBecomeInvisible()
	{
	}

	public void OnHasBecomeVisible()
	{
	}

	public void ToggleVisibility(bool value)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeCoroutine_003Ed__15))]
	private IEnumerator FadeCoroutine(bool value)
	{
		return null;
	}

	private void ToggleRenderers(bool value)
	{
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IceCreamRequestVisualGenerator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRender_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IceCreamRequestVisualGenerator _003C_003E4__this;

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
		public _003CRender_003Ed__12(int _003C_003E1__state)
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
	private Camera m_Camera;

	[SerializeField]
	private GameObject m_Container;

	[SerializeField]
	private IceCreamCone[] m_ConePrefabs;

	private RTPool m_RTPool;

	[SerializeField]
	private string m_RenderingLayer;

	[SerializeField]
	private Shader m_PreviewShader;

	public RenderTexture Texture => null;

	private void Awake()
	{
	}

	private void PreprocessRenderTexture(RenderTexture rt)
	{
	}

	public void SetRequest(IceCreamRequest request)
	{
	}

	private void ClearRT(RenderTexture rt)
	{
	}

	[IteratorStateMachine(typeof(_003CRender_003Ed__12))]
	public IEnumerator Render()
	{
		return null;
	}

	public void ReleaseRT(RenderTexture texture)
	{
	}
}

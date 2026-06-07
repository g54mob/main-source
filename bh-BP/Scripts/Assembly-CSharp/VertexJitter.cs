using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class VertexJitter : MonoBehaviour
{
	private struct VertexAnim
	{
		public float angleRange;

		public float angle;

		public float speed;
	}

	[CompilerGenerated]
	private sealed class _003C_AnimateVertexColors_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public VertexJitter _003C_003E4__this;

		private TMP_TextInfo _003CtextInfo_003E5__2;

		private int _003CloopCount_003E5__3;

		private VertexAnim[] _003CvertexAnim_003E5__4;

		private TMP_MeshInfo[] _003CcachedMeshInfo_003E5__5;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_AnimateVertexColors_003Ed__11(int _003C_003E1__state)
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

	public float AngleMultiplier;

	public float SpeedMultiplier;

	public float CurveScale;

	private TMP_Text m_TextComponent;

	private bool hasTextChanged;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void ON_TEXT_CHANGED(UnityEngine.Object obj)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateVertexColors_003Ed__11))]
	private IEnumerator<float> _AnimateVertexColors()
	{
		return null;
	}
}

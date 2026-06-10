using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimateTiledTexture : MonoBehaviour
{
	public delegate void VoidEvent();

	[CompilerGenerated]
	private sealed class _003CupdateTiling_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AnimateTiledTexture _003C_003E4__this;

		private int _003CcheckAgainst_003E5__2;

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
		public _003CupdateTiling_003Ed__27(int _003C_003E1__state)
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

	public int _columns;

	public int _rows;

	public Vector2 _scale;

	public Vector2 _offset;

	public Vector2 _buffer;

	public float _framesPerSecond;

	public bool _playOnce;

	public bool _disableUponCompletion;

	public bool _enableEvents;

	public bool _playOnEnable;

	public bool _newMaterialInstance;

	private int _index;

	private Vector2 _textureSize;

	private Material _materialInstance;

	private bool _hasMaterialInstance;

	private bool _isPlaying;

	private List<VoidEvent> _voidEventCallbackList;

	public void RegisterCallback(VoidEvent cbFunction)
	{
	}

	public void UnRegisterCallback(VoidEvent cbFunction)
	{
	}

	public void Play()
	{
	}

	public void ChangeMaterial(Material newMaterial, bool newInstance = false)
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void HandleCallbacks(List<VoidEvent> cbList)
	{
	}

	private void OnEnable()
	{
	}

	private void CalcTextureSize()
	{
	}

	[IteratorStateMachine(typeof(_003CupdateTiling_003Ed__27))]
	private IEnumerator updateTiling()
	{
		return null;
	}

	private void ApplyOffset()
	{
	}
}

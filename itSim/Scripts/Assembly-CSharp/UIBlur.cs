using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class UIBlur : MonoBehaviour
{
	[Serializable]
	public class BlurChangedEvent : UnityEvent<float>
	{
	}

	[CompilerGenerated]
	private sealed class _003CBeginBlurCoroutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UIBlur _003C_003E4__this;

		public float speed;

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
		public _003CBeginBlurCoroutine_003Ed__47(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CEndBlurCoroutine_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UIBlur _003C_003E4__this;

		public float speed;

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
		public _003CEndBlurCoroutine_003Ed__48(int _003C_003E1__state)
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
	private Color _color;

	[SerializeField]
	private FlipMode _buildFlipMode;

	[SerializeField]
	[Range(0f, 3f)]
	private float _intensity;

	[SerializeField]
	[Range(0f, 1f)]
	private float _multiplier;

	[SerializeField]
	private UnityEvent _onBeginBlur;

	[SerializeField]
	private UnityEvent _onEndBlur;

	[SerializeField]
	private BlurChangedEvent _onBlurChanged;

	private Material _material;

	private int _colorId;

	private int _flipXId;

	private int _flipYId;

	private int _intensityId;

	private int _multiplierId;

	private float lastIntensity;

	private float lastMultiplier;

	public Color Color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public FlipMode BuildFlipMode
	{
		get
		{
			return default(FlipMode);
		}
		set
		{
		}
	}

	public float Intensity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Multiplier
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public UnityEvent OnBeginBlur
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public UnityEvent OnEndBlur
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public BlurChangedEvent OnBlurChanged
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void UpdateBlur()
	{
	}

	public void SetBlur(Color color, float intensity, float multiplier)
	{
	}

	public void BeginBlur(float speed)
	{
	}

	public void EndBlur(float speed)
	{
	}

	private void Start()
	{
	}

	private void SetComponents()
	{
	}

	private Material FindMaterial()
	{
		return null;
	}

	private void UpdateColor()
	{
	}

	private void UpdateIntensity()
	{
	}

	private void UpdateMultiplier()
	{
	}

	private void UpdateFlipMode()
	{
	}

	[IteratorStateMachine(typeof(_003CBeginBlurCoroutine_003Ed__47))]
	private IEnumerator BeginBlurCoroutine(float speed)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CEndBlurCoroutine_003Ed__48))]
	private IEnumerator EndBlurCoroutine(float speed)
	{
		return null;
	}
}

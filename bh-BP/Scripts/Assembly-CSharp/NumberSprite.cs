using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class NumberSprite : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public bool randomizePos;

		public Vector3 pos;

		public NumberSprite _003C_003E4__this;

		public float fadeOutLen;

		private float _003CstartTime_003E5__2;

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
		public _003C_Run_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003C_RunHarvestClock_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Vector3 pos;

		public NumberSprite _003C_003E4__this;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunHarvestClock_003Ed__18(int _003C_003E1__state)
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

	public SpriteRenderer[] SprNumbers;

	private CoroutineHandle _curAnim;

	public int NumChars;

	public Color Color;

	public float Size;

	public Vector3 DefaultScale;

	public int TgtNum;

	public float SpawnTime;

	public Vector3 SpawnPos;

	public const float kDefaultBaseFontSize = 12f;

	public ResourceType TgtResource;

	public void RunCrit(Vector3 pos, DamageType dt, int num)
	{
	}

	public void Run(Vector3 pos, DamageType dt, int num)
	{
	}

	public void Run(Vector3 pos, Color c, int num)
	{
	}

	public void Run(Vector3 pos, Color c, int num, float size, Sprite startSprite, Sprite endSprite)
	{
	}

	public void Run(Vector3 pos, ResourceType rt, int num, bool sendToUI)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__16))]
	private IEnumerator<float> _Run(Vector3 pos, bool randomizePos, float fadeOutLen = 0.75f)
	{
		return null;
	}

	public void RunHarvestClock(Vector3 pos, float num)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunHarvestClock_003Ed__18))]
	public IEnumerator<float> _RunHarvestClock(Vector3 pos)
	{
		return null;
	}

	public void SetNumber(int num, Sprite startSprite, Sprite endSprite)
	{
	}

	public void SetFloat(float num, Sprite startSprite)
	{
	}

	public void SetSize(float size)
	{
	}

	public void SetColor(Color c)
	{
	}

	public void SetAlpha(float a)
	{
	}
}

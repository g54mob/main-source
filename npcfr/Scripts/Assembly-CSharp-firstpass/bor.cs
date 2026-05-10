using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

public class bor : MonoBehaviour
{
	private sealed class boq : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int uhe;

		private object uhf;

		public bor uhg;

		public Vector3 uhh;

		public Vector3 uhi;

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
		public boq(int a)
		{
		}

		[DebuggerHidden]
		private void lee()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lee
			this.lee();
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
		private void leh()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in leh
			this.leh();
		}
	}

	public boo mechSpider;

	public bor unSync;

	public Vector3 offset;

	public float minDelay;

	public float maxOffset;

	public float stepSpeed;

	public float footHeight;

	public float velocityPrediction;

	public float raycastFocus;

	public AnimationCurve yOffset;

	public Transform foot;

	public Vector3 footUpAxis;

	public float footRotationSpeed;

	public ParticleSystem sand;

	private IK uhj;

	private float uhk;

	private float uhl;

	private Vector3 uhm;

	private RaycastHit uhn;

	private Quaternion uho;

	private Vector3 uhp;

	private Vector3 uhq;

	public bool xtt => false;

	public Vector3 xtu
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	private void muz()
	{
	}

	private void bqd()
	{
	}

	private void hsz()
	{
	}

	private void dqj(float a)
	{
	}

	private void fqo()
	{
	}

	private void nab()
	{
	}

	private Vector3 len(out bool a, float b, float c)
	{
		a = default(bool);
		return default(Vector3);
	}

	private void Update()
	{
	}

	private void leo(float a)
	{
	}

	private Vector3 pz(out bool a, float b, float c)
	{
		a = default(bool);
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(boq))]
	private IEnumerator lep(Vector3 a, Vector3 b)
	{
		return null;
	}

	private void ldl()
	{
	}

	private void ofo()
	{
	}

	private void lem()
	{
	}

	private void kgo()
	{
	}

	private void fuy()
	{
	}

	private void gnf(float a)
	{
	}

	private Vector3 juz(out bool a, float b, float c)
	{
		a = default(bool);
		return default(Vector3);
	}

	private void mgb()
	{
	}

	private Vector3 ecf(out bool a, float b, float c)
	{
		a = default(bool);
		return default(Vector3);
	}

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void dud(float a)
	{
	}

	private Vector3 iap(out bool a, float b, float c)
	{
		a = default(bool);
		return default(Vector3);
	}

	private void htr(float a)
	{
	}

	private void mrn()
	{
	}
}

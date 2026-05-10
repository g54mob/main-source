using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Infrastructure.Project.Registration;
using Infrastructure.Project.Registration.Native.LVAEntities;
using LVA.Creatures.Implementations;
using LVA.Limbs;
using LVA.Puppeteers.Humanoid;
using UnityEngine;

public class bij : bim
{
	private sealed class bih<a> : IEnumerator<object>, IEnumerator, IDisposable where a : AbstractLimb
	{
		private int tau;

		private object tav;

		public bij taw;

		public PrefabPassport<a> tax;

		public Vector3 tay;

		public Human taz;

		public List<AbstractLimb> tba;

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
		public bih(int a)
		{
		}

		[DebuggerHidden]
		private void izt()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in izt
			this.izt();
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
		private void izv()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in izv
			this.izv();
		}
	}

	private sealed class bii : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int tbb;

		private object tbc;

		public bij tbd;

		public Vector3 tbe;

		public Quaternion tbf;

		public big tbg;

		private Human tbh;

		private List<AbstractLimb> tbi;

		private List<AbstractLimb>.Enumerator tbj;

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
		public bii(int a)
		{
		}

		[DebuggerHidden]
		private void izx()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in izx
			this.izx();
		}

		private void izy()
		{
		}

		[DebuggerHidden]
		private void jaa()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in jaa
			this.jaa();
		}
	}

	private readonly bio tbk;

	private readonly bie tbl;

	private readonly HumanGroupHandler tbm;

	private readonly bhy tbn;

	private readonly gd tbo;

	public bij(bhy a, bgm b, bio c, bie d, gd e)
	{
	}

	public void jac(Vector3 a, Quaternion b)
	{
	}

	public bil jad(Vector3 a, Quaternion b)
	{
		return null;
	}

	public HumanoidPuppeteer jae(bam a)
	{
		return null;
	}

	[IteratorStateMachine(typeof(bii))]
	private IEnumerator jaf(Vector3 a, Quaternion b, big c)
	{
		return null;
	}

	[IteratorStateMachine(typeof(bih<>))]
	private IEnumerator jag<a>(Human a, PrefabPassport<a> b, Vector3 c, List<AbstractLimb> d) where a : AbstractLimb
	{
		return null;
	}
}

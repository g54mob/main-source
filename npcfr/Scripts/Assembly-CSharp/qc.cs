using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LVA.Creatures;
using UnityEngine;

public abstract class qc<a, b> : qb where a : vg<b> where b : Enum
{
	[Serializable]
	public class PuppeteerLimb
	{
		public b LimbType { get; private set; }

		public Transform Reference { get; private set; }

		public PuppeteerLimb(b limbType, Transform reference)
		{
		}
	}

	private Dictionary<b, Transform> rex;

	public bool rey
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public Creature<a> rez
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	protected abstract void ghb();

	private void fdc()
	{
	}

	public override Transform ggt(vf a)
	{
		return null;
	}

	public sealed override void ggs(bam a)
	{
	}

	private void kjn()
	{
	}

	protected abstract List<PuppeteerLimb> gha();

	private void ghc()
	{
	}
}

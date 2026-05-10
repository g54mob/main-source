using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LVA.Limbs.References;
using LVA.Limbs.Systems.Node;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration.Separation.Performing;
using Zenject;

namespace LVA.Limbs
{
	public abstract class AbstractLimb : bcz<zq, AbstractLimb.wv>
	{
		public abstract class wv : bcw
		{
			protected AbstractLimb rxb
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

			protected zk xgp => null;

			public void hfq(qb a)
			{
			}

			public void hfp(bam a)
			{
			}

			public void ccb(qb a)
			{
			}

			public void q(bam a)
			{
			}

			protected virtual void hfw(float a)
			{
			}

			public sealed override void gqo()
			{
			}

			public void cdb(qb a)
			{
			}

			public virtual void hfu(AbstractLimb a, SeparatedMeshData b, IReadOnlyCollection<int3> c)
			{
			}

			protected virtual void hft(qb a)
			{
			}

			public void nj(bam a)
			{
			}

			public void nts(qb a)
			{
			}

			protected virtual void hfv(wy a)
			{
			}

			public void eep(bam a)
			{
			}

			public void hfo(bam a)
			{
			}

			protected virtual void hfs(bam a)
			{
			}

			protected sealed override void gqn(bcx a)
			{
			}

			public void mnn(bam a)
			{
			}

			protected virtual void hfr(bam a)
			{
			}

			public void jan(bam a)
			{
			}

			public void gw(bam a)
			{
			}
		}

		[SerializeField]
		private LimbReferencesPrivate m_referencesInternal;

		private ber rxc;

		public int rxd
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		protected virtual Vector3 rxe
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
		}

		protected virtual bool xgq => false;

		protected virtual int xgr => 0;

		protected virtual HumanoidLimbHoldGroupType? xgs => null;

		public zk xgt => null;

		public xc rxf
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

		[Inject]
		private void hfx(ber a)
		{
		}

		public virtual string hgh()
		{
			return null;
		}

		public void hgi(bool a)
		{
		}

		public void hgj(bam a)
		{
		}

		public void hgk()
		{
		}

		public void hgl()
		{
		}

		protected sealed override void gra()
		{
		}

		protected sealed override void grb()
		{
		}

		protected sealed override HashSet<zq> grd()
		{
			return null;
		}

		protected sealed override List<wv> grg()
		{
			return null;
		}

		protected sealed override List<wv> grh()
		{
			return null;
		}

		protected sealed override void grc()
		{
		}

		protected sealed override void cxl()
		{
		}

		protected abstract List<rx> hgm();

		protected abstract void hgn();

		protected abstract vd hgo();

		protected virtual void hgp()
		{
		}

		protected virtual void hgq(wy a)
		{
		}

		protected virtual bab hgr()
		{
			return null;
		}

		protected virtual wx hgs()
		{
			return null;
		}
	}
}

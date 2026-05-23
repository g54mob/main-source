using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;
using Zenject;

namespace LVA.Limbs.References
{
	public sealed class LimbReferencesPrivate : zk
	{
		[SerializeField]
		private LimbPhysics m_physics;

		[SerializeField]
		private VoxelMesh m_mesh;

		[SerializeField]
		private VoxelMeshSeparationModule m_meshSeparationModule;

		[SerializeField]
		private LimbDismembermentModule m_dismembermentModule;

		[SerializeField]
		private nt m_holdInteractionEventsReceiver;

		[SerializeField]
		private xa m_limbProvider;

		[SerializeField]
		private baj m_limbContextMenuActionsHandler;

		private bes sjc;

		private vd sjd;

		private AbstractLimb sje;

		private wz sjf;

		private zl sjg;

		private baa sjh;

		private bad sji;

		private zh sjj;

		private zz sjk;

		private bool sjl;

		private LimbPhysicsInternalReferences sjm;

		private zv sjo;

		public override bam xju => null;

		public override qb xjv => null;

		public wy sjn
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

		public override AbstractLimb xjw => null;

		public override LimbPhysics xjx => null;

		public override VoxelMesh xjy => null;

		public override VoxelMeshSeparationModule xjz => null;

		public override LimbDismembermentModule xka => null;

		public override vd xkb => null;

		public override bcl xkc => null;

		public override bck xkd => null;

		public override baa xke => null;

		public override zs xkf => null;

		public override zf xkg => null;

		public override bad xkh => null;

		public override nr xki => null;

		[Inject]
		private void hun(bes a)
		{
		}

		public void hvf(AbstractLimb a, vd b)
		{
		}

		public void hvg(bcf a, bbw<zq, AbstractLimb.wv> b, bch c)
		{
		}

		public void hvh(Vector3 a, List<rx> b, bool c)
		{
		}

		public void hvi(bam a, bcx.bcn b, bcf c, bca d, bbw<zq, AbstractLimb.wv> e, bab f, int g)
		{
		}

		public void hvj(bcx.bcn a)
		{
		}

		public void hvk()
		{
		}

		public void hvl()
		{
		}

		public void hvm()
		{
		}
	}
}

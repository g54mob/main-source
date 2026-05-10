using System.Runtime.CompilerServices;
using ActiveRagdoll.Scripts;
using UnityEngine;
using Zenject;

namespace LVA.Puppeteers.Humanoid
{
	public class HumanoidPuppeteerReferences : PuppeteerCoreReferences
	{
		private Transform rny;

		private qq rnz;

		private hd roa;

		private gd rob;

		private ru roc;

		private bev rod;

		public HumanoidPuppeteer roe
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

		public rj rof
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

		[field: SerializeField]
		public HumanoidPuppeteerStaticData StaticData { get; private set; }

		[field: SerializeField]
		public HumanoidPuppeteerRuntimeData RuntimeData { get; private set; }

		[field: SerializeField]
		public FootFrictionControl FootFrictionControl { get; private set; }

		[field: SerializeField]
		public HumanoidMoveControl MoveControl { get; private set; }

		[field: SerializeField]
		public COMTransformControl COMTransformControl { get; private set; }

		public qz rog
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

		[field: SerializeField]
		public HumanoidPuppeteerCoreServices Services { get; private set; }

		[field: SerializeField]
		public HumanoidAnimationReferences Animation { get; private set; }

		[field: SerializeField]
		public IKReferences IK { get; private set; }

		private baz xeh => null;

		private bam xei => null;

		public override ru xds => null;

		[Inject]
		private void goc(hd a, gd b, bev c)
		{
		}

		public void gol(HumanoidPuppeteer a)
		{
		}

		public void gom()
		{
		}

		public Transform gon()
		{
			return null;
		}

		private void goo()
		{
		}

		private void gop()
		{
		}

		private void OnDestroy()
		{
		}
	}
}

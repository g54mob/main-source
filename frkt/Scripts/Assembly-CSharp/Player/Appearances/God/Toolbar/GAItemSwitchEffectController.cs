using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Components.Audio;
using Core.MeshData;
using UnityEngine;

namespace Player.Appearances.God.Toolbar
{
	public class GAItemSwitchEffectController : MonoBehaviour
	{
		public enum DissolveState
		{
			Idle = 0,
			Performing = 1,
			Reverting = 2
		}

		private sealed class ph
		{
			public float qzw;

			internal void opl(pi a)
			{
			}

			internal void gbl(pi a)
			{
			}

			internal void etk(pi a)
			{
			}

			internal void bix(pi a)
			{
			}
		}

		private float qzz;

		[SerializeField]
		private cvt m_cutoutController;

		[SerializeField]
		private GAToolbarSwitchEffectParticles m_particles;

		[SerializeField]
		private GADissolveCutoutGeometryPositionController m_cutoutPositionController;

		private pg raa;

		private LerpSound rab;

		private float rac;

		private Vector3 rad;

		private bool rae;

		private DissolveState raf;

		private Coroutine rag;

		private List<pi> rah;

		public DissolveState xdl => default(DissolveState);

		public event Action qzx
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action qzy
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void gbr(bds a, Transform b, ow c)
		{
		}

		public void gbs(MeshDataHandler a)
		{
		}

		public void gbt()
		{
		}

		public void gbu()
		{
		}

		public void gbv()
		{
		}

		public void gbw()
		{
		}

		public void gbx()
		{
		}

		public void gby()
		{
		}

		public void gbz()
		{
		}

		private bool gca()
		{
			return false;
		}

		private void gcb()
		{
		}

		private void gcc(float a)
		{
		}

		private void gcd()
		{
		}

		private void gce(MeshDataHandler a)
		{
		}
	}
}

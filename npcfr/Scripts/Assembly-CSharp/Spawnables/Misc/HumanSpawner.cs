using System.Runtime.CompilerServices;
using Core.MeshData;
using UnityEngine;
using Views.Generic;
using Zenject;

namespace Spawnables.Misc
{
	public class HumanSpawner : pv
	{
		private bim rdb;

		private ok rdc;

		private gd rdd;

		[SerializeField]
		private MeshDataHandler m_meshDataHandler;

		[SerializeField]
		private GameObject m_projectorLens;

		[SerializeField]
		private Canvas m_creatureFaceCanvas;

		[SerializeField]
		private PopupWindow m_creatureFacePopUp;

		[SerializeField]
		private Highlighter m_canBePlacedDisplay;

		[SerializeField]
		private Transform m_buttonPivot;

		[SerializeField]
		private Transform m_topBodyPivot;

		[SerializeField]
		private Transform m_bottomBodyPivot;

		[SerializeField]
		private Transform m_humanGerm;

		public pu rde
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

		public pw rdf
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

		public override MeshDataHandler xdm => null;

		[Inject]
		private void gfa(bim a, ok b, gd c)
		{
		}

		public override bil gff(Vector3 a, Quaternion b)
		{
			return null;
		}

		protected override void cxh()
		{
		}
	}
}

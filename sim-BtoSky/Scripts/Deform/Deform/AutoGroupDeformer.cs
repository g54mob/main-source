using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[Deformer(Name = "Auto Group", Description = "Delegates deformation to deformers on child game objects", Type = typeof(AutoGroupDeformer), Category = Category.Utility)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/AutoGroupDeformer")]
	public class AutoGroupDeformer : Deformer
	{
		[SerializeField]
		[HideInInspector]
		private bool refreshGroup = true;

		[SerializeField]
		[HideInInspector]
		private List<Deformer> deformers = new List<Deformer>();

		private DataFlags dataFlags;

		public bool RefreshGroup
		{
			get
			{
				return refreshGroup;
			}
			set
			{
				refreshGroup = value;
			}
		}

		public override DataFlags DataFlags => dataFlags;

		private void OnEnable()
		{
			if (RefreshGroup)
			{
				Refresh();
			}
		}

		private void Update()
		{
			if (RefreshGroup)
			{
				Refresh();
			}
		}

		public void Refresh()
		{
			GetComponentsInChildren(deformers);
			deformers.Remove(this);
		}

		public int GetGroupSize()
		{
			if (deformers == null)
			{
				return 0;
			}
			return deformers.Count;
		}

		public override void PreProcess()
		{
			foreach (Deformer deformer in deformers)
			{
				if (deformer != null && deformer.CanProcess())
				{
					deformer.PreProcess();
				}
			}
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			dataFlags = DataFlags.None;
			if (deformers == null)
			{
				return dependency;
			}
			foreach (Deformer deformer in deformers)
			{
				if (deformer != null && deformer != this && deformer.CanProcess())
				{
					dependency = deformer.Process(data, dependency);
					dataFlags |= deformer.DataFlags;
				}
			}
			return dependency;
		}
	}
}

using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Group", Description = "Combines deformers into a group", Type = typeof(GroupDeformer), Category = Category.Utility)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/GroupDeformer")]
	public class GroupDeformer : Deformer
	{
		[SerializeField]
		[HideInInspector]
		private List<DeformerElement> deformerElements = new List<DeformerElement>();

		private DataFlags dataFlags;

		public List<DeformerElement> DeformerElements
		{
			get
			{
				return deformerElements;
			}
			set
			{
				deformerElements = value;
			}
		}

		public override DataFlags DataFlags => dataFlags;

		public override void PreProcess()
		{
			foreach (DeformerElement deformerElement in deformerElements)
			{
				if (deformerElement.CanProcess())
				{
					deformerElement.Component.PreProcess();
				}
			}
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			dataFlags = DataFlags.None;
			foreach (DeformerElement deformerElement in deformerElements)
			{
				if (deformerElement.CanProcess())
				{
					Deformer component = deformerElement.Component;
					dependency = component.Process(data, dependency);
					dataFlags |= component.DataFlags;
				}
			}
			return dependency;
		}

		public void AddDeformer(Deformer deformer, bool active = true)
		{
			DeformerElements.Add(new DeformerElement(deformer, active));
		}

		public void RemoveDeformer(Deformer deformer)
		{
			for (int i = 0; i < DeformerElements.Count; i++)
			{
				if (DeformerElements[i].Component == deformer)
				{
					DeformerElements.RemoveAt(i);
					i--;
				}
			}
		}
	}
}

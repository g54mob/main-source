using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Repeater", Description = "Applies the same deformer multiple times", Type = typeof(RepeaterDeformer), Category = Category.Utility)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/RepeaterDeformer")]
	public class RepeaterDeformer : Deformer
	{
		[SerializeField]
		[HideInInspector]
		private int iterations = 1;

		[SerializeField]
		[HideInInspector]
		private DeformerElement deformerElement = new DeformerElement(null);

		private DataFlags dataFlags;

		public int Iterations
		{
			get
			{
				return iterations;
			}
			set
			{
				iterations = Mathf.Max(0, value);
			}
		}

		public DeformerElement DeformerElement
		{
			get
			{
				return deformerElement;
			}
			set
			{
				deformerElement = value;
			}
		}

		public override DataFlags DataFlags => dataFlags;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			dataFlags = DataFlags.None;
			Deformer component = DeformerElement.Component;
			if (component == null || !DeformerElement.CanProcess())
			{
				return dependency;
			}
			dataFlags |= component.DataFlags;
			for (int i = 0; i < Iterations; i++)
			{
				dependency = component.Process(data, dependency);
			}
			return dependency;
		}
	}
}

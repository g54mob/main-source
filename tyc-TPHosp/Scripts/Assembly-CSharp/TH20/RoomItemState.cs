using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemState
	{
		public string Name;

		public RuntimeAnimatorController AnimGraph;

		public void OnActive(RoomItem item)
		{
			if (item.Visual != null)
			{
				item.Visual.AnimationGraph = AnimGraph;
				return;
			}
			RoomItem.VisualSetDelegate visualSetDelegate = null;
			visualSetDelegate = delegate
			{
				item.OnVisualSet -= visualSetDelegate;
				item.Visual.AnimationGraph = AnimGraph;
			};
			item.OnVisualSet += visualSetDelegate;
		}
	}
}

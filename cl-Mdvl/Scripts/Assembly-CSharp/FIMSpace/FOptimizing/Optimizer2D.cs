using UnityEngine;
using UnityEngine.EventSystems;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/2D Optimizer", 2)]
	public class Optimizer2D : EssentialOptimizer, IDropHandler, IEventSystemHandler, IFHierarchyIcon
	{
		public new string EditorIconPath
		{
			get
			{
				if (PlayerPrefs.GetInt("OptH", 1) == 0)
				{
					return "";
				}
				return "FIMSpace/Optimizers 2/OptEsIconSmall";
			}
		}

		public new void OnDrop(PointerEventData data)
		{
		}

		protected override void Reset()
		{
			LODLevels = 1;
			base.Reset();
			MaxDistance = 25f;
		}

		protected override void Start()
		{
			DetectionBounds.z = 1f;
			DetectionOffset.z = 0f;
			base.Start();
		}

		public override float GetReferenceDistance()
		{
			return Vector2.Distance(base.PreviousPosition, base.LastDynamicCheckCameraPosition);
		}

		public override Vector3 GetReferencePosition()
		{
			Vector3 position = base.transform.position;
			position.z = OptimizersManager.MainCamera.transform.position.z;
			return position;
		}

		public override void OnValidate()
		{
			OptimizingMethod = EOptimizingMethod.Dynamic;
			base.OnValidate();
		}
	}
}

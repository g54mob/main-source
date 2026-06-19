using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	[DontSaveAssetReference]
	public class RoomTemplateItem
	{
		public Vector3 Position;

		public float Rotation;

		public SharedInstance<RoomItemDefinition> Definition;

		public RoomItemDefinitionUGC UGCDefinition;

		public bool IsHospitalWindow;

		public bool Equals(RoomItem item)
		{
			if (Definition.Instance == item.Definition && Position == item.LocalPosition)
			{
				return MathUtils.ApproximatelyZero(Rotation - item.Rotation);
			}
			return false;
		}

		public bool Equals(HospitalPlotItem item)
		{
			if (Definition.Instance == item.Definition.Instance && Position == item.Position)
			{
				return MathUtils.ApproximatelyZero(Rotation - item.Rotation);
			}
			return false;
		}
	}
}

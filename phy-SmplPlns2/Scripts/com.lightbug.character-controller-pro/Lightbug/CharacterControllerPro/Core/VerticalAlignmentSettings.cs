using System;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[Serializable]
	public class VerticalAlignmentSettings
	{
		public enum VerticalReferenceMode
		{
			Towards = 0,
			Away = 1
		}

		[Tooltip("By assigning this object, the character up direction will be automatically calculated based on it. A null value means that the character up direction will be the one defined in the \"alignment direction\" field")]
		public Transform alignmentReference;

		[Tooltip("The mode defines how the up direction is calculated (alignment reference not null).")]
		public VerticalReferenceMode referenceMode = VerticalReferenceMode.Away;

		[Tooltip("The desired up direction (null alignment reference).")]
		public Vector3 alignmentDirection = Vector3.up;
	}
}

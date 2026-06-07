using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class PartConnectionElementScript : MonoBehaviour
	{
		public AttachPoint AttachPoint { get; set; }

		public PartData OtherPart { get; set; }

		public PartData Part { get; set; }

		public PartConnection PartConnection { get; set; }
	}
}

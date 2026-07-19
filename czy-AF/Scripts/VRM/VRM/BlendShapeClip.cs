using UnityEngine;

namespace VRM
{
	[CreateAssetMenu(menuName = "VRM/BlendShapeClip")]
	public class BlendShapeClip : ScriptableObject
	{
		[SerializeField]
		public string BlendShapeName = "";

		[SerializeField]
		public BlendShapePreset Preset;

		[SerializeField]
		public BlendShapeBinding[] Values = new BlendShapeBinding[0];

		[SerializeField]
		public MaterialValueBinding[] MaterialValues = new MaterialValueBinding[0];

		[SerializeField]
		public bool IsBinary;

		public BlendShapeKey Key => BlendShapeKey.CreateFromClip(this);
	}
}

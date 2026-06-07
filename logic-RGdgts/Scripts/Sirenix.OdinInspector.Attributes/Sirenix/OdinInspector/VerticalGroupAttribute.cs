namespace Sirenix.OdinInspector
{
	public class VerticalGroupAttribute : PropertyGroupAttribute
	{
		public float PaddingTop;

		public float PaddingBottom;

		public VerticalGroupAttribute(string groupId, float order = 0f)
			: base(null, 0f)
		{
		}

		public VerticalGroupAttribute(float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}

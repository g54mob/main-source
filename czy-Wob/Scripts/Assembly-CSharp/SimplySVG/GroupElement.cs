namespace SimplySVG
{
	public class GroupElement : SVGElement, SVGStylable, SVGTransformable
	{
		protected GraphicalAttributes localGraphicalAttributes;

		protected TransformAttributes localTransformAttributes;

		public GroupElement()
		{
			localGraphicalAttributes = new GraphicalAttributes();
			localTransformAttributes = new TransformAttributes();
		}

		public override bool AddAttribute(string attributeName, string attributeValue)
		{
			if (!base.AddAttribute(attributeName, attributeValue) && !AddStyleAttribute(attributeName, attributeValue))
			{
				return AddTransformAttribute(attributeName, attributeValue);
			}
			return true;
		}

		public bool AddStyleAttribute(string attributeName, string attributeValue)
		{
			return localGraphicalAttributes.AddAttribute(attributeName, attributeValue);
		}

		public bool AddTransformAttribute(string attributeName, string attributeValue)
		{
			return localTransformAttributes.AddAttribute(attributeName, attributeValue);
		}

		public GraphicalAttributes GetLocalAttributes()
		{
			return localGraphicalAttributes;
		}

		public TransformAttributes GetLocalTransformation()
		{
			return localTransformAttributes;
		}
	}
}

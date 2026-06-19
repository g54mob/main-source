namespace SimplySVG
{
	public interface SVGTransformable
	{
		TransformAttributes GetLocalTransformation();

		bool AddTransformAttribute(string attributeName, string attributeValue);
	}
}

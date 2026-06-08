using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectAttributesPartsUnmarshaller : IXmlUnmarshaller<GetObjectAttributesParts, XmlUnmarshallerContext>
	{
		private static GetObjectAttributesPartsUnmarshaller _instance = new GetObjectAttributesPartsUnmarshaller();

		public static GetObjectAttributesPartsUnmarshaller Instance => _instance;

		public GetObjectAttributesParts Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectAttributesParts getObjectAttributesParts = new GetObjectAttributesParts();
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("IsTruncated", num))
					{
						BoolUnmarshaller instance = BoolUnmarshaller.Instance;
						getObjectAttributesParts.IsTruncated = instance.Unmarshall(context);
					}
					else if (context.TestExpression("MaxParts", num))
					{
						IntUnmarshaller instance2 = IntUnmarshaller.Instance;
						getObjectAttributesParts.MaxParts = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("NextPartNumberMarker", num))
					{
						IntUnmarshaller instance3 = IntUnmarshaller.Instance;
						getObjectAttributesParts.NextPartNumberMarker = instance3.Unmarshall(context);
					}
					else if (context.TestExpression("PartNumberMarker", num))
					{
						IntUnmarshaller instance4 = IntUnmarshaller.Instance;
						getObjectAttributesParts.PartNumberMarker = instance4.Unmarshall(context);
					}
					else if (context.TestExpression("Part", num))
					{
						if (getObjectAttributesParts.Parts == null)
						{
							getObjectAttributesParts.Parts = new List<ObjectPart>();
						}
						ObjectPartUnmarshaller instance5 = ObjectPartUnmarshaller.Instance;
						getObjectAttributesParts.Parts.Add(instance5.Unmarshall(context));
					}
					else if (context.TestExpression("PartsCount", num))
					{
						IntUnmarshaller instance6 = IntUnmarshaller.Instance;
						getObjectAttributesParts.TotalPartsCount = instance6.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return getObjectAttributesParts;
				}
			}
			return getObjectAttributesParts;
		}
	}
}

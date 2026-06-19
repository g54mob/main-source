using System.Text;
using Pug.Conversion;

public class DescriptionConverter : SingleAuthoringComponentConverter<DescriptionAuthoring>
{
	protected override void Convert(DescriptionAuthoring authoring)
	{
		EnsureHasBuffer<DescriptionBuffer>();
		if (!string.IsNullOrEmpty(authoring.initialText))
		{
			byte[] bytes = Encoding.UTF8.GetBytes(authoring.initialText);
			AddToBuffer<DescriptionBuffer, byte>(bytes);
		}
	}
}

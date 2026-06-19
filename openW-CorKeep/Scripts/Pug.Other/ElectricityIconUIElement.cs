using System.Collections.Generic;

public class ElectricityIconUIElement : UIelement
{
	private const string electrictyIconHoverDesc = "electrictyIconHoverDesc";

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		return new List<TextAndFormatFields>
		{
			new TextAndFormatFields
			{
				text = "electrictyIconHoverDesc"
			}
		};
	}
}

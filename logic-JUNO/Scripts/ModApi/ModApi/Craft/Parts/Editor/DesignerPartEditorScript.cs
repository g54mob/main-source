using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public class DesignerPartEditorScript : PartEditorScriptBase<DesignerPart>
	{
		public override bool Validate()
		{
			bool result = base.Validate();
			if (Data.Category == null)
			{
				Debug.LogError("The category for the designer part has not been specified", this);
				result = false;
			}
			return result;
		}
	}
}

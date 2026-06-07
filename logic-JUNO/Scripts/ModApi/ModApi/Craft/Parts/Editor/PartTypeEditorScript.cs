using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public class PartTypeEditorScript : PartEditorScriptBase<PartType>
	{
		public override bool Validate()
		{
			bool result = base.Validate();
			if (string.IsNullOrWhiteSpace(Data.Id))
			{
				Debug.LogError("The Id for the part has not been specified.", this);
				result = false;
			}
			if (string.IsNullOrWhiteSpace(Data.Name))
			{
				Debug.LogError("The name for the part has not been specified.", this);
				result = false;
			}
			return result;
		}
	}
}

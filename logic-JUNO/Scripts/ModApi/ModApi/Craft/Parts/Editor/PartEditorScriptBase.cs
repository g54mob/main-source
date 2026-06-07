using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public abstract class PartEditorScriptBase : MonoBehaviour
	{
		public abstract bool Validate();
	}
	public class PartEditorScriptBase<T> : PartEditorScriptBase
	{
		public T Data;

		public override bool Validate()
		{
			if (Data == null)
			{
				Debug.LogError("The data to validate is null");
				return false;
			}
			return true;
		}
	}
}

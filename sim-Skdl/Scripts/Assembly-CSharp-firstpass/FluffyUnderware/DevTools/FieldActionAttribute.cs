namespace FluffyUnderware.DevTools
{
	public class FieldActionAttribute : ActionAttribute, IDTFieldRenderAttribute
	{
		public FieldActionAttribute(string actionData, ActionEnum action = ActionEnum.Callback)
			: base(null, default(ActionEnum))
		{
		}
	}
}

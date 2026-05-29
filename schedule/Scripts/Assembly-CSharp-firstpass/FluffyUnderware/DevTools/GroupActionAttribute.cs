namespace FluffyUnderware.DevTools
{
	public class GroupActionAttribute : ActionAttribute, IDTGroupRenderAttribute
	{
		public GroupActionAttribute(string actionData, ActionEnum action = ActionEnum.Callback)
			: base(null, default(ActionEnum))
		{
		}
	}
}

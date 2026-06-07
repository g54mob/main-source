namespace Sirenix.OdinInspector
{
	[HideInTables]
	[DontApplyToListElements]
	[IncludeMyAttributes]
	public class OnInspectorDisposeAttribute : ShowInInspectorAttribute
	{
		public string Action;

		public OnInspectorDisposeAttribute()
		{
		}

		public OnInspectorDisposeAttribute(string action)
		{
		}
	}
}

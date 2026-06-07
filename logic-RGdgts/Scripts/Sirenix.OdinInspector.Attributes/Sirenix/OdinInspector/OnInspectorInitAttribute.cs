namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[IncludeMyAttributes]
	[HideInTables]
	public class OnInspectorInitAttribute : ShowInInspectorAttribute
	{
		public string Action;

		public OnInspectorInitAttribute()
		{
		}

		public OnInspectorInitAttribute(string action)
		{
		}
	}
}

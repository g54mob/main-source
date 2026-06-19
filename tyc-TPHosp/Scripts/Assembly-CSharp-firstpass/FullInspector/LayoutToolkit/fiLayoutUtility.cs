namespace FullInspector.LayoutToolkit
{
	public static class fiLayoutUtility
	{
		public static fiLayout Margin(float margin, fiLayout layout)
		{
			return new fiHorizontalLayout
			{
				margin,
				new fiVerticalLayout { margin, layout, margin },
				margin
			};
		}
	}
}

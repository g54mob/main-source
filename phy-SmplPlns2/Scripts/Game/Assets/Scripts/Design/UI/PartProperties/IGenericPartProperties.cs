namespace Assets.Scripts.Design.UI.PartProperties
{
	public interface IGenericPartProperties
	{
		public enum PropertyStatus
		{
			Visible = 0,
			Hidden = 1
		}

		T GetProperty<T>(string propertyName) where T : class, IConfigurableProperty;

		void RefreshUI();

		void SetModifierHeaderText(string text);

		void SetPropertyStatus(string propertyName, PropertyStatus status);
	}
}

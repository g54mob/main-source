using System.Reflection;

namespace ModApi.Design.PartProperties
{
	public interface IDesignerPartProperties
	{
		IPartPropertiesFlyout Flyout { get; }

		T GetProperty<T>(FieldInfo field) where T : class, IConfigurableProperty;

		void OnPropertyChanged(FieldInfo field);

		void RefreshUI();

		void SetVisibility(FieldInfo field, bool visible);

		void UpdateVisibility(FieldInfo field);
	}
}

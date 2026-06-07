using System.Reflection;

namespace ModApi.Design.PartProperties
{
	public interface IConfigurableProperty
	{
		object CurrentFieldTarget { get; }

		FieldInfo Field { get; }

		void RefreshUI();

		void SetPreferredHeight(float height);
	}
}

using System.Reflection;

namespace ModApi.Ui.Inspector
{
	public class ObjectInspectorFieldInfo
	{
		public FieldInfo Field { get; }

		public string GroupName { get; }

		public string Label { get; }

		public int Order { get; }

		public ObjectInspectorFieldInfo(FieldInfo field, string label, int order, string groupName)
		{
			Field = field;
			Label = label;
			Order = order;
			GroupName = groupName;
		}
	}
}

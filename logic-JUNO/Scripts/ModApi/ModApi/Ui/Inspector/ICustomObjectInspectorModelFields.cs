using System.Reflection;

namespace ModApi.Ui.Inspector
{
	public interface ICustomObjectInspectorModelFields
	{
		bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex);
	}
}

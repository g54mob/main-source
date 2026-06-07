using System;
using System.Collections.Generic;
using System.Reflection;

namespace ModApi.Ui.Inspector
{
	public interface IObjectInspector
	{
		Func<object, FieldInfo, bool> PreprocessField { get; }

		object Target { get; }

		void BuildModelForField(FieldInfo field, GroupModel group, object target, string name = null);

		void ForceRebuildModel();

		IReadOnlyList<ObjectInspectorFieldInfo> GetInspectorFields(Type type);
	}
}

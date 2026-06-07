using System.Collections.Generic;
using System.Reflection;

namespace ModApi.Planet.Modifiers.VertexData
{
	public interface ICustomInspectorFields
	{
		List<FieldInfo> GetInspectorFields();
	}
}

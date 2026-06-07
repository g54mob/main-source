using System.Reflection;
using Sirenix.Serialization;
using UnityEngine.Localization;

namespace Sirenix.OdinInspector.Modules.Localization
{
	public class LocalizedStringFormatter : ReflectionOrEmittedBaseFormatter<LocalizedString>
	{
		private static readonly FieldInfo m_LocalVariables_Field;

		static LocalizedStringFormatter()
		{
		}

		protected override LocalizedString GetUninitializedObject()
		{
			return null;
		}

		protected override void DeserializeImplementation(ref LocalizedString value, IDataReader reader)
		{
		}
	}
}

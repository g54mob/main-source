using System;
using Rhizomatic.ImUI;

namespace GRP
{
	public static class EntityPickerViewExt
	{
		public static Id EntityPicker(this ImUIBuilder builder, EntityManager manager, Id id, params ViewParam[] viewParams)
		{
			return default(Id);
		}

		public static Id EntityPicker(this ImUIBuilder builder, EntityManager manager, Id id, Func<Entity, bool> filter, params ViewParam[] viewParams)
		{
			return default(Id);
		}

		public static Id EntityPicker(this ImUIBuilder builder, string label, EntityManager manager, Id id, params ViewParam[] viewParams)
		{
			return default(Id);
		}
	}
}

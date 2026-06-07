using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int _reInputId;

		private readonly int _id;

		private readonly Guid _templateTypeGuid;

		private readonly List<ControllerTemplateActionElementMap> _elementMaps;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> _elementMaps_readOnly;

		private bool _enabled;

		private int _categoryId;

		private int _layoutId;

		private int _sourceMapId;

		private static int __idCounter;

		public int id => 0;

		public Guid templateTypeGuid => default(Guid);

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int categoryId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int layoutId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps => null;

		internal ControllerTemplateMap(Guid templateTypeGuid)
		{
		}

		internal ControllerTemplateMap(Guid templateTypeGuid, int categoryId, int layoutId, int sourceMapId)
		{
		}

		public string ToXmlString()
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			return null;
		}

		internal virtual void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
		}

		internal virtual void Import(SerializedObject serializedObject)
		{
		}

		private void Clear()
		{
		}

		private SerializedObject Export()
		{
			return null;
		}

		internal void AddElementMap(ControllerTemplateActionElementMap elementMap)
		{
		}

		internal static ControllerTemplateMap FromControllerMap(IControllerTemplate controllerTemplate, ControllerMap controllerMap)
		{
			return null;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			return null;
		}

		public static ControllerTemplateMap FromJson(string jsonString)
		{
			return null;
		}

		private static ControllerTemplateMap FromSerializedData(SerializedObject serializedObject)
		{
			return null;
		}
	}
}

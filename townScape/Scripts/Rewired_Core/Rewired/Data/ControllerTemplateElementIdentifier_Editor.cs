using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor
	{
		[SerializeField]
		[CustomObfuscation]
		private string _scriptingName;

		[SerializeField]
		[CustomObfuscation]
		private string _alternateScriptingName;

		[SerializeField]
		[CustomObfuscation]
		private bool _excludeFromExport;

		[SerializeField]
		[CustomObfuscation]
		private bool _useEditorElementTypeOverride;

		[SerializeField]
		[CustomObfuscation]
		private ControllerElementType _editorElementTypeOverride;

		internal string scriptingName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal string alternateScriptingName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal bool excludeFromExport => false;

		internal override bool useEditorElementTypeOverride => false;

		internal override ControllerElementType editorElementTypeOverride => default(ControllerElementType);

		internal ControllerTemplateElementType effectiveElementType => default(ControllerTemplateElementType);

		string IControllerTemplateElementIdentifier_Editor.scriptingName => null;

		string IControllerTemplateElementIdentifier_Editor.alternateScriptingName => null;

		public ControllerTemplateElementIdentifier_Editor()
		{
		}

		public ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor source)
		{
		}

		public override ControllerTemplateElementIdentifier Clone()
		{
			return null;
		}
	}
}

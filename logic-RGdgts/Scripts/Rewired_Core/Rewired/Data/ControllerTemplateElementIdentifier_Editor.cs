using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor
	{
		[SerializeField]
		[CustomObfuscation]
		private string _scriptingName;

		[CustomObfuscation]
		[SerializeField]
		private string _alternateScriptingName;

		[CustomObfuscation]
		[SerializeField]
		private bool _excludeFromExport;

		[CustomObfuscation]
		[SerializeField]
		private bool _useEditorElementTypeOverride;

		[CustomObfuscation]
		[SerializeField]
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

		public ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor P_0)
		{
		}

		public override ControllerTemplateElementIdentifier Clone()
		{
			return null;
		}
	}
}

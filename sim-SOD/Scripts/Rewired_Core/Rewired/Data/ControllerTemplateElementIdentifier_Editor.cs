using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _scriptingName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _alternateScriptingName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _excludeFromExport;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useEditorElementTypeOverride;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

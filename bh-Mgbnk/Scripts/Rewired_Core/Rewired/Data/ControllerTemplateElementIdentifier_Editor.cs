using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor, IControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _scriptingName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _alternateScriptingName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor P_0)
		{
		}

		public override ControllerTemplateElementIdentifier Clone()
		{
			return null;
		}
	}
}

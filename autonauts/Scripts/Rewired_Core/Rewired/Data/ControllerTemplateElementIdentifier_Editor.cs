using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class ControllerTemplateElementIdentifier_Editor : ControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, IControllerTemplateElementIdentifier_Editor
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _scriptingName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				return _scriptingName;
			}
			set
			{
				_scriptingName = value;
			}
		}

		internal string alternateScriptingName
		{
			get
			{
				return _alternateScriptingName;
			}
			set
			{
				_alternateScriptingName = value;
			}
		}

		internal bool excludeFromExport
		{
			get
			{
				return _excludeFromExport;
			}
		}

		internal override bool useEditorElementTypeOverride
		{
			get
			{
				return _useEditorElementTypeOverride;
			}
		}

		internal override ControllerElementType editorElementTypeOverride
		{
			get
			{
				return _editorElementTypeOverride;
			}
		}

		internal ControllerTemplateElementType effectiveElementType
		{
			get
			{
				if (!_useEditorElementTypeOverride)
				{
					return base.elementType;
				}
				return KVNLqybISELdZVRJeMgGCnyHIcv.epHGbImMBWbvvjSPHgtWxljmdtP(_editorElementTypeOverride, false);
			}
		}

		string IControllerTemplateElementIdentifier_Editor.scriptingName
		{
			get
			{
				return _scriptingName;
			}
		}

		string IControllerTemplateElementIdentifier_Editor.alternateScriptingName
		{
			get
			{
				return _alternateScriptingName;
			}
		}

		public ControllerTemplateElementIdentifier_Editor()
		{
		}

		public ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor source)
			: base(source)
		{
			_scriptingName = source._scriptingName;
			_alternateScriptingName = source._alternateScriptingName;
			_excludeFromExport = source._excludeFromExport;
			_editorElementTypeOverride = source._editorElementTypeOverride;
			_useEditorElementTypeOverride = source._useEditorElementTypeOverride;
		}

		internal ControllerTemplateElementIdentifier_Editor(int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, string scriptingName, string alternateScriptingName, bool excludeFromExport, bool useEditorElementTypeOverride, ControllerElementType editorElementTypeOverride, bool isMappableOnPlatform)
			: base(id, name, positiveName, negativeName, elementType, isMappableOnPlatform)
		{
			while (true)
			{
				int num = 1860933270;
				while (true)
				{
					switch (num ^ 0x6EEB9694)
					{
					case 0:
						break;
					case 2:
						goto IL_002d;
					default:
						_useEditorElementTypeOverride = useEditorElementTypeOverride;
						return;
					}
					break;
					IL_002d:
					_scriptingName = scriptingName;
					_alternateScriptingName = alternateScriptingName;
					_excludeFromExport = excludeFromExport;
					_editorElementTypeOverride = editorElementTypeOverride;
					num = 1860933269;
				}
			}
		}

		internal ControllerTemplateElementIdentifier_Editor(ControllerTemplateElementIdentifier_Editor source, ControllerTemplateElementType changedElementType, bool isMappableOnPlatform)
			: base(source, changedElementType, isMappableOnPlatform)
		{
			_scriptingName = source._scriptingName;
			_alternateScriptingName = source._alternateScriptingName;
			_excludeFromExport = source._excludeFromExport;
			_editorElementTypeOverride = source._editorElementTypeOverride;
			_useEditorElementTypeOverride = source._useEditorElementTypeOverride;
		}

		public override ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier_Editor(this);
		}
	}
}

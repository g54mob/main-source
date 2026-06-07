using System;
using System.Collections.Generic;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class CustomInstruction : ProgramInstruction
	{
		[ProgramNodeProperty]
		private string _callFormat = string.Empty;

		[ProgramNodeProperty]
		private string _format = string.Empty;

		private List<LocalVariableDefinition> _localVariables;

		[ProgramNodeProperty]
		private string _name;

		public string CallFormat
		{
			get
			{
				return _callFormat;
			}
			set
			{
				_callFormat = value;
			}
		}

		public string Format
		{
			get
			{
				return _format;
			}
			set
			{
				_format = value;
			}
		}

		public List<LocalVariableDefinition> LocalVariables
		{
			get
			{
				if (_localVariables == null)
				{
					_localVariables = new List<LocalVariableDefinition>();
					foreach (NodeFormat.Token item in NodeFormat.Tokenize(Format))
					{
						if (item.TokenType == NodeFormat.TokenType.LocalVariableDefinition)
						{
							LocalVariableDefinition localVariableDefinition = new LocalVariableDefinition();
							localVariableDefinition.Name = item.Text;
							_localVariables.Add(localVariableDefinition);
						}
					}
				}
				return _localVariables;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
	}
}

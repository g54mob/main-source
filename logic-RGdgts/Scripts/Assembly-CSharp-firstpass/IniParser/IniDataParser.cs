using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using IniParser.Configuration;
using IniParser.Model;
using IniParser.Parser;

namespace IniParser
{
	public class IniDataParser
	{
		private uint _currentLineNumber;

		private readonly List<Exception> _errorExceptions;

		private List<string> _currentCommentListTemp;

		private string _currentSectionNameTemp;

		private readonly StringBuffer _mBuffer;

		public virtual IniParserConfiguration Configuration { get; protected set; }

		public IniScheme Scheme { get; protected set; }

		public bool HasError => false;

		public ReadOnlyCollection<Exception> Errors => null;

		public List<string> CurrentCommentListTemp
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public IniData Parse(string iniString)
		{
			return null;
		}

		public IniData Parse(TextReader textReader)
		{
			return null;
		}

		public void Parse(TextReader textReader, ref IniData iniData)
		{
		}

		protected virtual void ProcessLine(StringBuffer currentLine, IniData iniData)
		{
		}

		protected virtual bool ProcessComment(StringBuffer currentLine)
		{
			return false;
		}

		protected virtual bool ProcessSection(StringBuffer currentLine, IniData iniData)
		{
			return false;
		}

		protected virtual bool ProcessProperty(StringBuffer currentLine, IniData iniData)
		{
			return false;
		}

		private void HandleDuplicatedKeyInCollection(string key, string value, PropertyCollection keyDataCollection, string sectionName)
		{
		}

		private void AddKeyToKeyValueCollection(string key, string value, PropertyCollection keyDataCollection, string sectionName)
		{
		}
	}
}

using System;
using I2.Loc;

namespace TH20
{
	[Serializable]
	public struct CharacterName
	{
		public LocalisedString FirstName;

		public LocalisedString LastName;

		public static CharacterName Empty;

		public const int cMaxNumUserSpecifiedNameCharacters = 32;

		private string _userSpecifiedName;

		public void UpdateLocalisedFirstName(string firstNameTerm)
		{
			FirstName = new LocalisedString(firstNameTerm);
		}

		public void UpdateLocalisedLastName(string lastNameTerm)
		{
			LastName = new LocalisedString(lastNameTerm);
		}

		public bool IsUserSpecifiedName()
		{
			return !string.IsNullOrEmpty(_userSpecifiedName);
		}

		public void SetUserSpecifiedName(string userSpecifiedName)
		{
			_userSpecifiedName = userSpecifiedName;
			if (_userSpecifiedName.Length > 32)
			{
				_userSpecifiedName = _userSpecifiedName.Substring(0, 32);
			}
		}

		public string GetUserSpecifiedName()
		{
			return _userSpecifiedName;
		}

		public string GetCharacterName()
		{
			return TranslateInternal("", "");
		}

		public string GetCharacterName(string postFixName)
		{
			return TranslateInternal(postFixName, "");
		}

		public string GetCharacterName(string postFixName, string titleTermStr)
		{
			return TranslateInternal(postFixName, titleTermStr);
		}

		private bool Equals(CharacterName other)
		{
			if (object.Equals(FirstName, other.FirstName))
			{
				return object.Equals(LastName, other.LastName);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is CharacterName)
			{
				return Equals((CharacterName)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (FirstName.GetHashCode() * 397) ^ LastName.GetHashCode();
		}

		public static bool operator ==(CharacterName n1, CharacterName n2)
		{
			return n1.Equals(n2);
		}

		public static bool operator !=(CharacterName n1, CharacterName n2)
		{
			return !(n1 == n2);
		}

		public override string ToString()
		{
			return string.Format("{0}{2}{1}", FirstName, LastName, ScriptLocalization.Misc.NameSeparator_CS);
		}

		public string GetCharacterFirstNameDebug()
		{
			return FirstName.ToString();
		}

		public string GetCharacterLastNameDebug()
		{
			return LastName.ToString();
		}

		private string Translate()
		{
			return TranslateInternal("", "");
		}

		private string Translate(string postFix)
		{
			return TranslateInternal(postFix, "");
		}

		private string TranslateInternal(string postFixName, string titleTermStr)
		{
			string text = string.Empty;
			if (!IsUserSpecifiedName())
			{
				if (!FirstName.IsNull() && !LastName.IsNull())
				{
					if (!string.IsNullOrEmpty(titleTermStr))
					{
						string translation = LocalizationManager.GetTranslation(titleTermStr);
						text = ScriptLocalization.Staff.StaffFormattedTitleAndName_CS;
						text = text.Replace("{[TITLE]}", translation);
						text = text.Replace("{[NAME_SEPARATOR]}", ScriptLocalization.Misc.NameSeparator_CS);
						text = text.Replace("{[FIRST_NAME]}", FirstName.Translation);
						text = text.Replace("{[LAST_NAME]}", LastName.Translation);
					}
					else
					{
						text = string.Format("{0}{2}{1}", FirstName.Translation, LastName.Translation, ScriptLocalization.Misc.NameSeparator_CS);
					}
					if (!string.IsNullOrEmpty(postFixName))
					{
						text += " ";
						text += postFixName;
					}
				}
			}
			else
			{
				text = _userSpecifiedName;
			}
			return text;
		}
	}
}

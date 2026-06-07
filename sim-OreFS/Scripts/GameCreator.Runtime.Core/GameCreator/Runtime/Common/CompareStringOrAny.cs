using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareStringOrAny
	{
		private enum Option
		{
			Any = 0,
			Specific = 1
		}

		[SerializeField]
		private Option m_Option;

		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		public bool Any => m_Option == Option.Any;

		public CompareStringOrAny()
		{
		}

		public CompareStringOrAny(PropertyGetString text)
			: this(defaultAny: false, text)
		{
		}

		public CompareStringOrAny(bool defaultAny, PropertyGetString text)
			: this()
		{
			m_Option = ((!defaultAny) ? Option.Specific : Option.Any);
			m_Text = text;
		}

		public bool Match(string compareTo, Args args)
		{
			if (Any)
			{
				return true;
			}
			return compareTo == Get(args);
		}

		public bool Match(string compareTo, GameObject args)
		{
			if (Any)
			{
				return true;
			}
			return compareTo == Get(args);
		}

		public string Get(Args args)
		{
			return m_Text.Get(args);
		}

		public string Get(GameObject target)
		{
			return m_Text.Get(target);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace TH20.Analytics
{
	public class EventParameters : IDictionaryContainer
	{
		private readonly Dictionary<string, object> _params = new Dictionary<string, object>();

		public EventParameters AddParam(string key, object value)
		{
			try
			{
				if (value is EventParameters)
				{
					_params[key] = ((EventParameters)value).AsDictionary();
				}
				else
				{
					_params[key] = value;
				}
			}
			catch (ArgumentNullException innerException)
			{
				throw new ArgumentNullException("Key can not be null.", innerException);
			}
			return this;
		}

		public object GetParam(string key)
		{
			try
			{
				return _params.ContainsKey(key) ? _params[key] : null;
			}
			catch (ArgumentNullException innerException)
			{
				throw new Exception("Key can not be null.", innerException);
			}
			catch (KeyNotFoundException innerException2)
			{
				throw new Exception("Key " + key + " not found.", innerException2);
			}
		}

		public IDictionary AsIDictionary()
		{
			return _params;
		}

		public Dictionary<string, object> AsDictionary()
		{
			return _params;
		}
	}
}

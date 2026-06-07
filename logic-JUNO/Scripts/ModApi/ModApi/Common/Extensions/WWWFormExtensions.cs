using System;
using System.Text;
using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class WWWFormExtensions
	{
		public static void AddField(this WWWForm form, string fieldName, object value, Encoding encoding = null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (encoding == null)
			{
				form.AddField(fieldName, value.ToString());
			}
			else
			{
				form.AddField(fieldName, value.ToString(), encoding);
			}
		}

		public static void AddOptionalField(this WWWForm form, string fieldName, object value, Encoding encoding = null)
		{
			if (value != null)
			{
				if (encoding == null)
				{
					form.AddField(fieldName, value.ToString());
				}
				else
				{
					form.AddField(fieldName, value.ToString(), encoding);
				}
			}
		}
	}
}

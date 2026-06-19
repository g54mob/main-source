using System;
using System.Text;
using Loxodon.Framework.Binding;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class LocalizedBindingDescription
	{
		[SerializeField]
		public string TypeName;

		[SerializeField]
		public string PropertyName;

		[SerializeField]
		public string Key;

		[SerializeField]
		public BindingMode Mode = BindingMode.OneWay;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(TypeName).Append(" ");
			stringBuilder.Append("{binding ").Append(PropertyName);
			stringBuilder.Append(" Key:").Append(Key);
			stringBuilder.Append(" Mode:").Append(Mode);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}

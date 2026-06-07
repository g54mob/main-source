using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Params
{
	public class ListParam : ContractParam
	{
		private string _value;

		public override string Value => _value;

		public ListParam(XElement xml)
			: base(xml)
		{
			string[] array = xml.GetStringAttribute("values").Split(new char[1] { ';' });
			int num = Mathf.Clamp((int)xml.GetFloatAttribute("index"), 0, array.Length);
			_value = array[num];
		}
	}
}

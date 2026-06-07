using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class Matrix4x4XmlSerializer : UnityXmlAttributeSerializer<Matrix4x4>
	{
		public override Matrix4x4 ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Matrix4x4
			{
				m00 = DataIO.ParseFloat(array[0]),
				m01 = DataIO.ParseFloat(array[1]),
				m02 = DataIO.ParseFloat(array[2]),
				m03 = DataIO.ParseFloat(array[3]),
				m10 = DataIO.ParseFloat(array[4]),
				m11 = DataIO.ParseFloat(array[5]),
				m12 = DataIO.ParseFloat(array[6]),
				m13 = DataIO.ParseFloat(array[7]),
				m20 = DataIO.ParseFloat(array[8]),
				m21 = DataIO.ParseFloat(array[9]),
				m22 = DataIO.ParseFloat(array[10]),
				m23 = DataIO.ParseFloat(array[11]),
				m30 = DataIO.ParseFloat(array[12]),
				m31 = DataIO.ParseFloat(array[13]),
				m32 = DataIO.ParseFloat(array[14]),
				m33 = DataIO.ParseFloat(array[15])
			};
		}

		public override void WriteValue(XAttribute attribute, Matrix4x4 value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(string.Join(",", DataIO.ToString(value.m00), DataIO.ToString(value.m01), DataIO.ToString(value.m02), DataIO.ToString(value.m03), DataIO.ToString(value.m10), DataIO.ToString(value.m11), DataIO.ToString(value.m12), DataIO.ToString(value.m13), DataIO.ToString(value.m20), DataIO.ToString(value.m21), DataIO.ToString(value.m22), DataIO.ToString(value.m23), DataIO.ToString(value.m30), DataIO.ToString(value.m31), DataIO.ToString(value.m32), DataIO.ToString(value.m33)));
		}
	}
}

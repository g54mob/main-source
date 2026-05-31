using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class TinyJsonSerializer
	{
		private StringBuilder output;

		private Dictionary<Type, Action<object>> serializers;

		private static readonly CultureInfo invariantCulture;

		public static void Serialize(object obj, StringBuilder output)
		{
		}

		private TinyJsonSerializer()
		{
		}

		private void Serialize(object obj)
		{
		}

		private void QuotedField(string name, string contents)
		{
		}

		private void SerializeUnityObject(UnityEngine.Object obj)
		{
		}
	}
}

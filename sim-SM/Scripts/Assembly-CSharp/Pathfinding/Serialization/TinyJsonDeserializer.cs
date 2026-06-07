using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class TinyJsonDeserializer
	{
		private TextReader reader;

		private GameObject contextRoot;

		private static readonly NumberFormatInfo numberFormat;

		private StringBuilder builder;

		public static object Deserialize(string text, Type type, object populate = null, GameObject contextRoot = null)
		{
			return null;
		}

		private object Deserialize(Type tp, object populate = null)
		{
			return null;
		}

		private UnityEngine.Object DeserializeUnityObject()
		{
			return null;
		}

		private UnityEngine.Object DeserializeUnityObjectInner()
		{
			return null;
		}

		private void EatWhitespace()
		{
		}

		private void Eat(string s)
		{
		}

		private string EatUntil(string c, bool inString)
		{
			return null;
		}

		private bool TryEat(char c)
		{
			return false;
		}

		private string EatField()
		{
			return null;
		}

		private void SkipFieldData()
		{
		}
	}
}

using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public abstract class UMAProperty
	{
		public static string precision;

		public static string splitter;

		public static string vectorprecision;

		public static string transformprecision;

		public static char[] vectorsplitter;

		public string stringRepresentation;

		public string name;

		public abstract void Apply(Material mpb, int overlayNumber);

		public abstract UMAProperty Clone();

		public string GetPropertyName(int overlayNumber)
		{
			return null;
		}

		public static UMAProperty FromString(string serializedString)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}

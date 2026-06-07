using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Image(typeof(IconNull), ColorTheme.Type.Gray)]
	[Title("Null")]
	[Category("Values/Null")]
	public class ValueNull : TValue
	{
		public static readonly IdString TYPE_ID = IdString.EMPTY;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => null;

		public override bool CanSave => false;

		public override TValue Copy => new ValueNull();

		protected override object Get()
		{
			return null;
		}

		protected override void Set(object value)
		{
		}

		public override string ToString()
		{
			return "Null";
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueNull), CreateValue), null);
		}

		private static ValueNull CreateValue(object value)
		{
			return new ValueNull();
		}
	}
}

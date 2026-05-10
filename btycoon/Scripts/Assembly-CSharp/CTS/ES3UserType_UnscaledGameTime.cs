using CTS.Utilities;
using ES3Types;
using UnityEngine;

namespace CTS
{
	public class ES3UserType_UnscaledGameTime : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_UnscaledGameTime()
			: base(typeof(UnscaledGameTime))
		{
			Instance = this;
			priority = 1;
			isPrimitive = true;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.Write(((UnscaledGameTime)obj).Value - Time.unscaledTime, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			float num = reader.Read<float>(ES3Type_float.Instance);
			return new UnscaledGameTime(Time.unscaledTime + num);
		}
	}
}

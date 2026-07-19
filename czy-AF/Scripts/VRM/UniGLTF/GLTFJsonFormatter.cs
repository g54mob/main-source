using System.Collections.Generic;
using UniJSON;

namespace UniGLTF
{
	public class GLTFJsonFormatter : JsonFormatter
	{
		public void GLTFValue(JsonSerializableBase s)
		{
			CommaCheck();
			base.Store.Write(s.ToJson());
		}

		public void GLTFValue<T>(IEnumerable<T> values) where T : JsonSerializableBase
		{
			BeginList();
			foreach (T value in values)
			{
				GLTFValue(value);
			}
			EndList();
		}

		public void GLTFValue(List<string> values)
		{
			BeginList();
			foreach (string value in values)
			{
				Value(value);
			}
			EndList();
		}
	}
}

namespace MyBox.Internal
{
	internal class SceneBundle
	{
		private Bundle<string> stringData;

		private Bundle<float> floatData;

		private Bundle<int> intData;

		private Bundle<bool> boolData;

		private Bundle<object> objectData;

		internal Bundle<string> StringData => stringData;

		internal Bundle<float> FloatData => floatData;

		internal Bundle<int> IntData => intData;

		internal Bundle<bool> BoolData => boolData;

		internal Bundle<object> ObjectData => objectData;

		internal SceneBundle()
		{
			stringData = new Bundle<string>();
			floatData = new Bundle<float>();
			intData = new Bundle<int>();
			boolData = new Bundle<bool>();
			objectData = new Bundle<object>();
		}
	}
}

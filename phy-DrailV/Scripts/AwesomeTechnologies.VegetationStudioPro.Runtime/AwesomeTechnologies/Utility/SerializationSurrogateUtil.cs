using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class SerializationSurrogateUtil
	{
		public static BinaryFormatter GetBinaryFormatter()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			SurrogateSelector surrogateSelector = new SurrogateSelector();
			surrogateSelector.AddSurrogate(surrogate: new Vector3SerializationSurrogate(), type: typeof(Vector3), context: new StreamingContext(StreamingContextStates.All));
			surrogateSelector.AddSurrogate(surrogate: new QuaternionSerializationSurrogate(), type: typeof(Quaternion), context: new StreamingContext(StreamingContextStates.All));
			binaryFormatter.SurrogateSelector = surrogateSelector;
			return binaryFormatter;
		}
	}
}
